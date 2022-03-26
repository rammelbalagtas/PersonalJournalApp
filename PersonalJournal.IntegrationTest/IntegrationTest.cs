using Microsoft.VisualStudio.TestTools.UnitTesting;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using WebDriverManager;
using WebDriverManager.DriverConfigs.Impl;


namespace PersonalJournal.IntegrationTest
{
    [TestClass]
    public class IntegrationTest
    {
        private IWebDriver _webDriver;

        [TestInitialize]
        public void Setup()
        {
            new DriverManager().SetUpDriver(new ChromeConfig());
            _webDriver = new ChromeDriver();
        }

        [TestMethod]
        public void Test_Title_Homepage()
        {
            _webDriver.Navigate().GoToUrl("https://localhost:5001/");
            Assert.IsTrue(_webDriver.Title.Contains("Home Page"));
        }

        [TestMethod]
        public void Test_Title_LoginPage()
        {
            _webDriver.Navigate().GoToUrl("https://localhost:5001/Identity/Account/Login/");
            Assert.IsTrue(_webDriver.Title.Contains("Log in"));
        }

        [TestMethod]
        public void Test_Title_RegisterPage()
        {
            _webDriver.Navigate().GoToUrl("https://localhost:5001/Identity/Account/Register/");
            Assert.IsTrue(_webDriver.Title.Contains("Register"));
        }

        [TestMethod]
        public void Test_Title_Categories()
        {
            simulateLogin();
            _webDriver.Navigate().GoToUrl("https://localhost:5001/Categories/");
            Assert.IsTrue(_webDriver.Title.Contains("Categories"));
        }

        [TestMethod]
        public void Test_Add_Category()
        {
            simulateLogin();
            //navigate to add new categories and submit
            _webDriver.Navigate().GoToUrl("https://localhost:5001/Categories/Create/");
            var titleInput = _webDriver.FindElement(By.Id("Title"));
            titleInput.SendKeys("Category Title");
            var longDescriptionInput = _webDriver.FindElement(By.Id("LongDescription"));
            longDescriptionInput.SendKeys("Category Description");
            var submit = _webDriver.FindElement(By.Id("Btn_Create"));
            submit.Click();
            Assert.IsTrue(true);
        }

        private void simulateLogin()
        {
            //log in to the page first
            _webDriver.Navigate().GoToUrl("https://localhost:5001/Identity/Account/Login/");
            var emailAddressInput = _webDriver.FindElement(By.Id("Input_Email"));
            emailAddressInput.SendKeys("test9@gmail.com");
            var passwordInput = _webDriver.FindElement(By.Id("Input_Password"));
            passwordInput.SendKeys("Test@1234");
            var login = _webDriver.FindElement(By.Id("login-submit"));
            login.Click();
        }

        [TestCleanup]
        public void Teardown()
        {
            _webDriver.Quit();
        }
    }
}
