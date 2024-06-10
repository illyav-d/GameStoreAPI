using AutoMapper;
using GameStoreAPI.Business.Services;
using GameStoreAPI.Data.Repositories;
using Moq;

namespace GameStoreAPI.Business.Tests.Services
{
    public class OrderServiceTests
    {
        [Test]
        public void WhenMethodIsLaunched_ThenIGetAStringSeperatedByComma()
        {
            //Arrange:
            Mock<IOrderRepository> mockOrderRepo = new Mock<IOrderRepository>();
            Mock<IMapper> mockMapper = new Mock<IMapper>();
            Mock<IShoppingCartProductRepository> mockShoppingCartProductRepo = new Mock<IShoppingCartProductRepository>();
            Mock<IUserRepository> mockUserRepository = new Mock<IUserRepository>();
            OrderService orderService = new OrderService(mockOrderRepo.Object, mockUserRepository.Object, mockShoppingCartProductRepo.Object, mockMapper.Object);
            
            string[] strings = { "test1", "test2", "test3" };
            string expectedResult = "test1,test2,test3";

            //Act:
            string actualkResult = orderService.ConvertGameTitlesArrayToString(strings);

            //Assert:
            Assert.AreEqual(expectedResult, actualkResult);
        }
    }
}
