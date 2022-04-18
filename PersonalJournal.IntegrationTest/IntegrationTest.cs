using Microsoft.VisualStudio.TestTools.UnitTesting;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Support.UI;
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

        //CREATE
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
            titleInput.SendKeys("Category Test Only");
            var longDescriptionInput = _webDriver.FindElement(By.Id("LongDescription"));
            longDescriptionInput.SendKeys("Category Description");
            longDescriptionInput.Submit();
        }

        [TestMethod]
        public void Test_Edit_Category()
        {
            simulateLogin();
            //click on one record, modify the value and submit
            _webDriver.Navigate().GoToUrl("https://localhost:5001/Categories");
            _webDriver.FindElement(By.CssSelector("table tr:nth-child(1) td>a:nth-child(1)")).Click();
            var titleInput = _webDriver.FindElement(By.Id("Title"));
            titleInput.Clear();
            titleInput.SendKeys("Category Test Edit");
            titleInput.Submit();
            simulateLogin();
        }

        [TestMethod]
        public void Test_Details_Category()
        {
            simulateLogin();
            //click on one record to view details
            _webDriver.Navigate().GoToUrl("https://localhost:5001/Categories");
            _webDriver.FindElement(By.CssSelector("table tr:nth-child(1) td>a:nth-child(2)")).Click();
            Assert.IsTrue(_webDriver.Title.Contains("Category Details"));
        }

        [TestMethod]
        public void Test_Title_Delete_Category()
        {
            simulateLogin();
            _webDriver.Navigate().GoToUrl("https://localhost:5001/Categories");
            _webDriver.FindElement(By.CssSelector("table tr:nth-child(1) td>a:nth-child(3)")).Click();
            Assert.IsTrue(_webDriver.Title.Contains("Delete Category"));
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

        [TestMethod]
        public void Test_Create_Subsection()
        {
            simulateLogin();
            //navigate to add new subsection and submit
            _webDriver.Navigate().GoToUrl("https://localhost:5001/Subsections/Create/");
            var titleInput = _webDriver.FindElement(By.Id("Title"));
            titleInput.SendKeys("Subsection Test Only");
            var longDescriptionInput = _webDriver.FindElement(By.Id("LongDescription"));
            longDescriptionInput.SendKeys("Subsection Description");
            longDescriptionInput.Submit();
        }

        [TestMethod]
        public void Test_Edit_Subsection()
        {
            simulateLogin();
            //click on one record, modify the value and submit
            _webDriver.Navigate().GoToUrl("https://localhost:5001/Subsections");
            _webDriver.FindElement(By.CssSelector("table tr:nth-child(1) td>a:nth-child(1)")).Click();
            var titleInput = _webDriver.FindElement(By.Id("Title"));
            titleInput.Clear();
            titleInput.SendKeys("Subsection Test Edit");
            titleInput.Submit();
        }

        [TestMethod]
        public void Test_Details_Subsection()
        {
            simulateLogin();
            //click on one record to view details
            _webDriver.Navigate().GoToUrl("https://localhost:5001/Subsections");
            _webDriver.FindElement(By.CssSelector("table tr:nth-child(1) td>a:nth-child(2)")).Click();
            Assert.IsTrue(_webDriver.Title.Contains("Subsection Details"));
        }

        [TestMethod]
        public void Test_Title_Delete_Subsection()
        {
            simulateLogin();
            _webDriver.Navigate().GoToUrl("https://localhost:5001/Subsections");
            _webDriver.FindElement(By.CssSelector("table tr:nth-child(1) td>a:nth-child(3)")).Click();
            Assert.IsTrue(_webDriver.Title.Contains("Delete Subsection"));
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

        [TestMethod]
        public void Test_Create_MoodTypes()
        {
            simulateLogin();
            //navigate to add new subsection and submit
            _webDriver.Navigate().GoToUrl("https://localhost:5001/Moods/Create/");
            var titleInput = _webDriver.FindElement(By.Id("Title"));
            titleInput.SendKeys("Mood Test Only");
            titleInput.Submit();
        }

        [TestMethod]
        public void Test_Edit_MoodTypes()
        {
            simulateLogin();
            //click on one record, modify the value and submit
            _webDriver.Navigate().GoToUrl("https://localhost:5001/Moods");
            _webDriver.FindElement(By.CssSelector("table tr:nth-child(1) td>a:nth-child(1)")).Click();
            var titleInput = _webDriver.FindElement(By.Id("Title"));
            titleInput.Clear();
            titleInput.SendKeys("Mood Test Edit");
            titleInput.Submit();
        }

        [TestMethod]
        public void Test_Details_MoodTypes()
        {
            simulateLogin();
            //click on one record to view details
            _webDriver.Navigate().GoToUrl("https://localhost:5001/Moods");
            _webDriver.FindElement(By.CssSelector("table tr:nth-child(1) td>a:nth-child(2)")).Click();
            Assert.IsTrue(_webDriver.Title.Contains("Mood Type Details"));
        }

        [TestMethod]
        public void Test_Title_Delete_MoodType()
        {
            simulateLogin();
            _webDriver.Navigate().GoToUrl("https://localhost:5001/Moods");
            _webDriver.FindElement(By.CssSelector("table tr:nth-child(1) td>a:nth-child(3)")).Click();
            Assert.IsTrue(_webDriver.Title.Contains("Delete Mood Type"));
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

        [TestMethod]
        public void Test_Create_JournalEntry()
        {
            
            simulateLogin();

            //navigate to add new subsection and submit
            _webDriver.Navigate().GoToUrl("https://localhost:5001/JournalEntries/Create/");
            
            var titleInput = _webDriver.FindElement(By.Id("Title"));
            titleInput.SendKeys("Journal Entry Test Only");

            var categoryDropdown = new SelectElement(_webDriver.FindElement(By.Id("CategoryId")));
            categoryDropdown.SelectByIndex(0);

            var moodDropdown = new SelectElement(_webDriver.FindElement(By.Id("MoodId")));
            moodDropdown.SelectByIndex(0);

            var locationInput = _webDriver.FindElement(By.Id("location"));
            locationInput.SendKeys("Eaton Centre, Yonge Street, Toronto, ON, Canada");

            var datetimeInput = _webDriver.FindElement(By.Id("DateTime"));
            datetimeInput.SendKeys("2022");
            datetimeInput.SendKeys(Keys.Tab);
            datetimeInput.SendKeys("04171200AM");

            var descriptionInput = _webDriver.FindElement(By.Id("Description"));
            descriptionInput.SendKeys("Journal Description");

            var subsection1Dropdown = new SelectElement(_webDriver.FindElement(By.Id("SubsectionId1")));
            subsection1Dropdown.SelectByIndex(0);
            var subsection1Text = _webDriver.FindElement(By.Id("SubsectionText1"));
            subsection1Text.SendKeys("Subsection 1 Test Text");

            var subsection2Dropdown = new SelectElement(_webDriver.FindElement(By.Id("SubsectionId2")));
            subsection2Dropdown.SelectByIndex(0);
            var subsection2Text = _webDriver.FindElement(By.Id("SubsectionText2"));
            subsection1Text.SendKeys("Subsection 2 Test Text");

            var subsection3Dropdown = new SelectElement(_webDriver.FindElement(By.Id("SubsectionId3")));
            subsection3Dropdown.SelectByIndex(0);
            var subsection3Text = _webDriver.FindElement(By.Id("SubsectionText3"));
            subsection1Text.SendKeys("Subsection 3 Test Text");

            var subsection4Dropdown = new SelectElement(_webDriver.FindElement(By.Id("SubsectionId4")));
            subsection4Dropdown.SelectByIndex(0);
            var subsection4Text = _webDriver.FindElement(By.Id("SubsectionText4"));
            subsection1Text.SendKeys("Subsection 4 Test Text");

            var subsection5Dropdown = new SelectElement(_webDriver.FindElement(By.Id("SubsectionId5")));
            subsection5Dropdown.SelectByIndex(0);
            var subsection5Text = _webDriver.FindElement(By.Id("SubsectionText5"));
            subsection1Text.SendKeys("Subsection 5 Test Text");

            titleInput.Submit();
        }

        [TestMethod]
        public void Test_Edit_JournalEntry()
        {
            simulateLogin();
            //click on one record, modify the value and submit
            _webDriver.Navigate().GoToUrl("https://localhost:5001/JournalEntries");
            _webDriver.FindElement(By.ClassName("fa-edit")).Click();
            var titleInput = _webDriver.FindElement(By.Id("Title"));
            titleInput.Clear();
            titleInput.SendKeys("Journal Entry Test Edit");
            titleInput.Submit();
        }

        [TestMethod]
        public void Test_Details_JournalEntries()
        {
            simulateLogin();
            //click on one record to view details
            _webDriver.Navigate().GoToUrl("https://localhost:5001/JournalEntries/");
            _webDriver.FindElement(By.CssSelector("td > a")).Click();
            Assert.IsTrue(_webDriver.Title.Contains("Journal Entry Details"));
        }

        [TestMethod]
        public void Test_Title_Delete_JournalEntry()
        {
            simulateLogin();
            _webDriver.Navigate().GoToUrl("https://localhost:5001/JournalEntries");
            _webDriver.FindElement(By.ClassName("fa-trash-alt")).Click();
            Assert.IsTrue(_webDriver.Title.Contains("Delete Journal Entry"));
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
