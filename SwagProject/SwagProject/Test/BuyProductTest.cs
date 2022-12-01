namespace SwagProject.Test
{
    public class Tests
    {
        LoginPage loginPage;
        ProductPage productPage;
        CardPage cardPage;

        [SetUp]
        public void Setup()
        {
            WebDrivers.Initialize();
            loginPage = new LoginPage();
            productPage = new ProductPage();
            cardPage = new CardPage();
        }

        [TearDown]
        public void ClosePage()
        {
            WebDrivers.CleanUp();
        }

        [Test]
        public void TC01_AddTwoProductsInCart_ShouldDisplayedTwoProducts()
        {
            loginPage.Login("standard_user", "secret_sauce");
            productPage.AddBackPac.Click();
            productPage.AddT_Shirt.Click();

            Assert.That("2", Is.EqualTo(productPage.Cart.Text));
        }

        [Test]
        public void TC02_SortProductByPrice_ShouldSortByHighPrice()
        {
            //Act
            loginPage.Login("standard_user", "secret_sauce");

            //Arrange
            productPage.SelectOption("Price (high to low)");

            //Assert
            Assert.That(productPage.SortByPrice.Displayed);
        }

        [Test]
        public void TC03_GoToAboutPage_ShouldRedactioToNewPage()
        {
            loginPage.Login("standard_user", "secret_sauce");
            productPage.MenuClick.Click();
            productPage.AboutClick.Click();

            Assert.That("https://saucelabs.com/", Is.EqualTo(WebDrivers.Instance.Url));
        }

        [Test]
        public void TC04_BuyProducts_ShouldBeFhishedShopping()
        {
            loginPage.Login("standard_user", "secret_sauce");
            productPage.AddBackPac.Click();
            productPage.AddT_Shirt.Click();
            productPage.ShoppingCardClick.Click();

            cardPage.Checkout.Click();
            cardPage.FirstName.SendKeys("Marko");
            cardPage.LastName.SendKeys("Naumovic");
            cardPage.ZipCode.SendKeys("11000");
            cardPage.ButtonContinue.Submit();

            cardPage.Finish.Click();

            Assert.That("THANK YOU FOR YOUR ORDER", Is.EqualTo(cardPage.OrderFinished.Text));
        }

    }
}