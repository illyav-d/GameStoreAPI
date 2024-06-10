using GameStoreAPI.Business.Models;

namespace GameStoreAPI.Business.Tests.Models
{
    public class ShoppingCartProductTests
    {
        [Test]
        public void TotalPrice_ShouldReturnCorrectValue()
        {
            // Arrange
            GameProduct gameProduct = new GameProduct { PriceInEuro = 59.99 };
            ShoppingCartProduct cartProduct = new ShoppingCartProduct
            {
                Amount = 2,
                GameProduct = gameProduct
            };

            double expectedResult = 119.98;

            // Act
            double actualresult = cartProduct.TotalPrice;

            // Assert
            Assert.AreEqual(expectedResult, actualresult);
        }
    }
}
