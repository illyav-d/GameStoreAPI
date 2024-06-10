using AutoMapper;
using GameStoreAPI.Business.Models;
using GameStoreAPI.Data.Entities;
using GameStoreAPI.Data.Repositories;

namespace GameStoreAPI.Business.Services
{
    public class OrderService : IOrderService
    {
        private readonly IOrderRepository _orderRepository;
        private readonly IUserRepository _userRepository;
        private readonly IShoppingCartProductRepository _shoppingCartProductRepository;
        private IMapper _mapper;

        public OrderService(IOrderRepository orderRepository, IUserRepository userRepository, IShoppingCartProductRepository shoppingCartProductRepository, IMapper mapper)
        {
            _orderRepository = orderRepository;
            _userRepository = userRepository;
            _shoppingCartProductRepository = shoppingCartProductRepository;
            _mapper = mapper;
        }

        public async Task<IEnumerable<Order>> GetAllOrdersAsync()
        {
            List<Order> allOrders = new List<Order>();
            IEnumerable<OrderEntity> orderEntities = await _orderRepository.GetAllOrdersAsync();

            foreach (OrderEntity orderEntity in orderEntities)
            {
                string[] gameTitles = orderEntity.GameTitles.Split(',');
                Order orderModel = new Order();
                orderModel.ID = orderEntity.ID;
                orderModel.CustomerID = orderEntity.CustomerID;
                orderModel.TotalPriceInEuro = orderEntity.TotalPriceInEuro;
                orderModel.GameTitles = gameTitles;
                orderModel.OrderDate = orderEntity.OrderDate;
                allOrders.Add(orderModel);
            }

            return allOrders;
        }

        public async Task AddOrderAsync(int customerID)
        {
            User currentUser = await GetUserDataAsync(customerID);

            string[] stringArray = currentUser.ShoppingCartProducts
                .Select(x => x.GameProduct.Name)
                .ToArray();

            OrderEntity orderEntity = new OrderEntity();
            orderEntity.CustomerID = customerID;
            orderEntity.GameTitles = ConvertGameTitlesArrayToString(stringArray);
            orderEntity.TotalPriceInEuro = currentUser.TotalPriceOfCart;
            orderEntity.OrderDate = DateTime.Now;
            orderEntity.Created = DateTime.Now;
            orderEntity.Updated = DateTime.Now;

            await _orderRepository.AddItemAsync(orderEntity);
        }

        public async Task CheckoutAsync(int customerID)
        {
            await AddOrderAsync(customerID);
            await _shoppingCartProductRepository.DeleteShoppingCartItemsByUserID(customerID);

            //TODO transaction (sql transactions)
            //Als 1 van de twee niet lukt dan mag transaction niet doorgaan
            //throw exception om te testen
        }

        private async Task<User> GetUserDataAsync(int customerID)
        {
            UserEntity currentUserEntity = await _userRepository.GetUserAndItemsInCartByIDAsync(customerID);
            User currentUser = _mapper.Map<User>(currentUserEntity);
            return currentUser;
        }

        public string ConvertGameTitlesArrayToString(string[] stringArray)
        {
            string gameTitles = string.Join(",", stringArray);

            return gameTitles;
        }
    }
}
