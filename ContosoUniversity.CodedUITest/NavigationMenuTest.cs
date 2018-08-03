using Microsoft.VisualStudio.TestTools.UnitTesting;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Firefox;
using OpenQA.Selenium.IE;
using OpenQA.Selenium.Remote;
using System;

namespace ContosoUniversity.CodedUITest
{
    [TestClass]
    public class NavigationMenuTest
    {
        private string baseURL = "http://localhost:7884/";
        private RemoteWebDriver driver;
        private string browser = string.Empty;

        public TestContext TestContext { get; set; }

        [TestMethod]
        [TestCategory("Selenium")]
        [Priority(1)]
        public void MenuNavigate()
        {
            try
            {
                //disable cookie alert
                driver.FindElement(By.Id("btn-cookie")).Click();

                driver.FindElement(By.Id("link-home")).Click();
                string resHome = driver.FindElementById("text-welcome").Text;
                Assert.AreEqual("Welcome to Contoso University", resHome);

                driver.FindElementById("link-about").Click();
                string resAbout = driver.FindElementById("title").Text;
                Assert.AreEqual("Student Body Statistics", resAbout);

                driver.FindElementById("link-departments").Click();
                string resDep = driver.FindElementById("title").Text;
                Assert.AreEqual("Departments", resDep);

                driver.FindElementById("link-courses").Click();
                string resCou = driver.FindElementById("title").Text;
                Assert.AreEqual("Courses", resCou);

                driver.FindElementById("link-instructors").Click();
                string resIns = driver.FindElementById("title").Text;
                Assert.AreEqual("Instructors", resIns);

                driver.FindElementById("link-students").Click();
                string resStu = driver.FindElementById("title").Text;
                Assert.AreEqual("Students", resStu);

                driver.FindElementById("link-contact").Click();
                string resCon = driver.FindElementById("title").Text;
                Assert.AreEqual("Contact", resCon);
            }
            catch (Exception ex)
            {
                Assert.Fail(ex.ToString());
            }
        }


        [TestInitialize()]
        public void MyTestInitialize()
        {
            //Set the browswer from a build
            //browser = this.TestContext.Properties["browser"] != null ? this.TestContext.Properties["browser"].ToString() : "chrome";
            browser = "chrome";
            switch (browser)
            {
                case "firefox":
                    driver = new FirefoxDriver();
                    break;
                case "chrome":
                    driver = new ChromeDriver(@"C:\Selenium\chromedriver_win32");
                    break;
                case "ie":
                    driver = new InternetExplorerDriver();
                    break;
                default:
                    driver = new ChromeDriver();
                    break;
            }

            //if (this.TestContext.Properties["Url"] != null) //Set URL from a build
            //{
            //    this.baseURL = this.TestContext.Properties["Url"].ToString();
            //}

            driver.Manage().Window.Maximize();
            driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(30);
            driver.Navigate().GoToUrl(this.baseURL);

        }

        [TestCleanup()]
        public void MyTestCleanup()
        {
            if (driver != null)
                driver.Quit();
        }

    }
}
