using GameStoreAPI.Business.Models;

namespace GameStoreAPI.Business.Tests.Models
{
    public class UserTests
    {
        [Test]
        public void TotalPriceOfCart_ShouldReturnCorrectValue()
        {
            // Arrange
            User user = new User();

            GameProduct gameProduct1 = new GameProduct { PriceInEuro = 59.99 };
            ShoppingCartProduct shoppingCartProduct1 = new ShoppingCartProduct
            {
                Amount = 1,
                GameProduct = gameProduct1
            };

            GameProduct gameProduct2 = new GameProduct { PriceInEuro = 39.99 };
            ShoppingCartProduct shoppingCartProduct2 = new ShoppingCartProduct
            {
                Amount = 2,
                GameProduct = gameProduct2
            };

            user.ShoppingCartProducts.Add(shoppingCartProduct1);
            user.ShoppingCartProducts.Add(shoppingCartProduct2);

            double expectedResult = 139.97;

            // Act
            double totalPriceOfCart = user.TotalPriceOfCart;

            // Assert
            Assert.AreEqual(expectedResult, totalPriceOfCart);
        }
    }
}
