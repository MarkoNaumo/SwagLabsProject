using SwagProject.Driver;
using SwagProject.Pages;

namespace SwagProject.Test
{
    public class Tests
    {
        LoginPage loginPage;
        ProductPage productPage;

        [SetUp]
        public void Setup()
        {
            WebDrivers.Initialize();
            loginPage = new LoginPage();
            productPage = new ProductPage();    
        }

        [TearDown]
        public void ClodePage()
        {
            WebDrivers.CleanUp();
        }

        [Test]
        public void TC01_AddTwoProductsInCart_ShouldDisplayedTwoProducts()
        {
            loginPage.Login("standard_user", "secret_sauce");
            productPage.AddBackPac.Click();
            productPage.AddT_Shirt.Click();

            Assert.That("2",Is.EqualTo(productPage.Cart.Text));

        }
    }
}