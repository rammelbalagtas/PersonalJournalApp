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

        [TestCleanup]
        public void Teardown()
        {
            _webDriver.Quit();
        }
    }
}
