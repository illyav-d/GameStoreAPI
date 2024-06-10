using AutoMapper;
using GameStoreAPI.Business.Models;
using GameStoreAPI.Data.Entities;
using GameStoreAPI.Data.Repositories;

namespace GameStoreAPI.Business.Services
{
    public class ShoppingCartProductService : IShoppingCartProductService
    {
        private readonly IShoppingCartProductRepository _shoppingCartProductRepository;
        private readonly IGameProductRepository _gameProductRepository;
        private IMapper _mapper;

        public ShoppingCartProductService(IShoppingCartProductRepository shoppingCartProductRepository, IGameProductRepository gameProductRepository, IMapper mapper)
        {
            _shoppingCartProductRepository = shoppingCartProductRepository;
            _gameProductRepository = gameProductRepository;
            _mapper = mapper;
        }

        public async Task<IEnumerable<ShoppingCartProduct>> GetAllShoppingCartProductsAsync()
        {
            List<ShoppingCartProduct> cartProducts = new List<ShoppingCartProduct>();
            IEnumerable<ShoppingCartProductEntity> shoppingCartProductEntity = await _shoppingCartProductRepository.GetAllShoppingCartProductsAsync();

            // Map the GameProductEntities to GameProduct models
            cartProducts = _mapper.Map<List<ShoppingCartProduct>>(shoppingCartProductEntity);
            return cartProducts;
        }

        public async Task UpdateProductAmountAsync(int id, ShoppingCartProduct shoppingCartProduct)
        {
            ShoppingCartProductEntity objectDB = await _shoppingCartProductRepository.GetItemByIDAsync(id);

            ShoppingCartProductEntity updatedObject = _mapper.Map<ShoppingCartProductEntity>(shoppingCartProduct);

            updatedObject.GameProductID = objectDB.GameProductID;

            await CheckAmountChangesInCartAsync(objectDB, updatedObject);

            objectDB.Updated = DateTime.Now;
            await _shoppingCartProductRepository.UpdateItemAsync(objectDB);
        }

        public async Task AddShoppingCartProductAsync(ShoppingCartProduct cartItem)
        {
            ShoppingCartProductEntity shoppingCartProductEntity = _mapper.Map<ShoppingCartProductEntity>(cartItem);
            if (await CheckIfItemIsAlreadyInCartAsync(cartItem) == false)
            {
                shoppingCartProductEntity.Created = DateTime.Now;
                shoppingCartProductEntity.Updated = DateTime.Now;
                await UpdateStockAsync(shoppingCartProductEntity, false);

                //shoppingCartProductEntity.GameProduct.Stock--; //Remove 1 game from stock
                await _shoppingCartProductRepository.AddItemAsync(shoppingCartProductEntity);
            }
        }

        public async Task DeleteShoppingCartProductByIDAsync(int id)
        {
            ShoppingCartProductEntity shoppingCartProductEntity = await _shoppingCartProductRepository.GetItemByIDAsync(id);
            await UpdateStockAsync(shoppingCartProductEntity, true);
            await _shoppingCartProductRepository.DeleteItemAsync(shoppingCartProductEntity);
        }

        public async Task DeleteUserShoppingCartProductsByUserIDAsync(int userID)
        {
            await _shoppingCartProductRepository.GetShoppingCartByUserID(userID);
        }

        public async Task<bool> CheckIfItemIsAlreadyInCartAsync(ShoppingCartProduct shoppingCartProduct)
        {
            bool isInCart = false;
            
            IEnumerable<ShoppingCartProductEntity> userShoppingCart = await _shoppingCartProductRepository.GetShoppingCartByUserID(shoppingCartProduct.UserID);

            if (userShoppingCart.Count() != 0 || userShoppingCart != null)
            {
                foreach (ShoppingCartProductEntity item in userShoppingCart)
                {
                    if (item.GameProductID == shoppingCartProduct.GameProductID)
                    {
                        ShoppingCartProductEntity shoppingCartProductEntity = _mapper.Map<ShoppingCartProductEntity>(shoppingCartProduct);
                        isInCart = true;
                        await UpdateStockAsync(shoppingCartProductEntity, false);
                        await UpdateItemAsync(shoppingCartProduct, item);
                        break;
                    }
                }
            }
            return isInCart;
        }

        private async Task UpdateItemAsync(ShoppingCartProduct shoppingCartProduct, ShoppingCartProductEntity item)
        {
            item.Amount += shoppingCartProduct.Amount;
            await _shoppingCartProductRepository.UpdateItemAsync(item);
        }
        
        private async Task UpdateStockAsync(ShoppingCartProductEntity shoppingCartProductEntity, bool addStock)
        {
            GameProductEntity gameProductEntity = await _gameProductRepository.GetItemByIDAsync(shoppingCartProductEntity.GameProductID);
            if (addStock == false)
            {
                gameProductEntity.Stock -= shoppingCartProductEntity.Amount;
            }
            else
            {
                gameProductEntity.Stock += shoppingCartProductEntity.Amount;
            }
           
            gameProductEntity.Updated = DateTime.Now;
            await _gameProductRepository.UpdateItemAsync(gameProductEntity);
        }

        private async Task CheckAmountChangesInCartAsync(ShoppingCartProductEntity objectDB, ShoppingCartProductEntity updatedObject)
        {
            int amountToChangeInStock = 0;

            if (objectDB.Amount > updatedObject.Amount)
            {
                amountToChangeInStock = objectDB.Amount - updatedObject.Amount;
                updatedObject.Amount = amountToChangeInStock;
                objectDB.Amount -= updatedObject.Amount;
                await UpdateStockAsync(updatedObject, true);
            }
            else if (objectDB.Amount < updatedObject.Amount)
            {
                amountToChangeInStock = updatedObject.Amount - objectDB.Amount;
                updatedObject.Amount = amountToChangeInStock;
                objectDB.Amount += updatedObject.Amount;
                await UpdateStockAsync(updatedObject, false);
            }
        }
    }
}
