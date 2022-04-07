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

        // CATEGORIES TESTING
        [TestMethod]
        public void Test_Title_Categories()
        {
            simulateLogin();
            _webDriver.Navigate().GoToUrl("https://localhost:5001/Categories/");
            Assert.IsTrue(_webDriver.Title.Contains("Categories"));
        }

        [TestMethod]
        public void Test_Title_Create_Category()
        {
            simulateLogin();
            _webDriver.Navigate().GoToUrl("https://localhost:5001/Categories/Create/");
            Assert.IsTrue(_webDriver.Title.Contains("Create Category"));
        }

        [TestMethod]
        public void Test_Create_Category()
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

        // SUBSECTION TESTING
        [TestMethod]
        public void Test_Title_Subsections()
        {
            simulateLogin();
            _webDriver.Navigate().GoToUrl("https://localhost:5001/Subsections/");
            Assert.IsTrue(_webDriver.Title.Contains("Subsections"));
        }

        [TestMethod]
        public void Test_Title_Create_Subsection()
        {
            simulateLogin();
            _webDriver.Navigate().GoToUrl("https://localhost:5001/Subsections/Create/");
            Assert.IsTrue(_webDriver.Title.Contains("Create Subsection"));
        }

        // MOOD TYPES TESTING
        [TestMethod]
        public void Test_Title_MoodTypes()
        {
            simulateLogin();
            _webDriver.Navigate().GoToUrl("https://localhost:5001/Moods/");
            Assert.IsTrue(_webDriver.Title.Contains("Mood Type"));
        }

        [TestMethod]
        public void Test_Title_Create_MoodTypes()
        {
            simulateLogin();
            _webDriver.Navigate().GoToUrl("https://localhost:5001/Moods/Create/");
            Assert.IsTrue(_webDriver.Title.Contains("Create Mood Type"));
        }

        // JOURNAL ENTRIES TESTING
        [TestMethod]
        public void Test_Title_JournalEntries()
        {
            simulateLogin();
            _webDriver.Navigate().GoToUrl("https://localhost:5001/JournalEntries/");
            Assert.IsTrue(_webDriver.Title.Contains("Journal Entries"));
        }

        [TestMethod]
        public void Test_Title_Create_JournalEntries()
        {
            simulateLogin();
            _webDriver.Navigate().GoToUrl("https://localhost:5001/JournalEntries/Create/");
            Assert.IsTrue(_webDriver.Title.Contains("Create Journal Entry"));
        }

        // HELPER METHOD TO SIMULATE LOGIN
        private void simulateLogin()
        {
            //log in to the page first
            _webDriver.Navigate().GoToUrl("https://localhost:5001/Identity/Account/Login/");
            var emailAddressInput = _webDriver.FindElement(By.Id("Input_Email"));
            emailAddressInput.SendKeys("test1@gmail.com");
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
