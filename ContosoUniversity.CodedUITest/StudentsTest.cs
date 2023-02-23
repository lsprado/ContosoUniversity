﻿using Microsoft.VisualStudio.TestTools.UnitTesting;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Firefox;
using OpenQA.Selenium.IE;
using OpenQA.Selenium.Remote;
using System;

namespace ContosoUniversity.CodedUITest
{
    [TestClass]
    public class StudentsTest
    {
        private string baseURL = "https://ase-contosouniversityapp-uat.azurewebsites.net/";
        private RemoteWebDriver driver;
        private string browser = string.Empty;

        public TestContext TestContext { get; set; }

        [TestMethod]
        [TestCategory("CodedUI")]
        [Priority(1)]
        public void StudentIndex()
        {
            try
            {
                driver = new ChromeDriver(Environment.GetEnvironmentVariable("ChromeWebDriver"));
                driver.Manage().Window.Maximize();
                driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(30);
                driver.Navigate().GoToUrl(this.baseURL);

                //disable cookie alert
                //driver.FindElement(By.Id("btn-cookie")).Click();

                driver.FindElementById("link-students").Click();
                string resDep = driver.FindElementById("title").Text;
                Assert.AreEqual("Students", resDep);
            }
            catch (Exception ex)
            {
                Assert.Fail(ex.ToString());
            }
            finally
            {
                driver.Quit();
                driver.Dispose();
            }
        }

        [TestMethod]
        [TestCategory("CodedUI")]
        [Priority(1)]
        public void StudentEdit()
        {
            try
            {
                driver = new ChromeDriver(Environment.GetEnvironmentVariable("ChromeWebDriver"));
                driver.Manage().Window.Maximize();
                driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(30);
                driver.Navigate().GoToUrl(this.baseURL);

                //disable cookie alert
                //driver.FindElement(By.Id("btn-cookie")).Click();

                driver.FindElementById("link-students").Click();
                string resDep = driver.FindElementById("title").Text;
                Assert.AreEqual("Students", resDep);

                // localiza a tablea e recupera o body
                IWebElement body = driver.FindElementById("table-list").FindElement(By.TagName("tbody"));

                // Pega a primeira linha da tabela e clica no link
                body.FindElements(By.TagName("tr"))[0].FindElement(By.LinkText("Edit")).Click();

                //procura o titulo da pagina
                string title = driver.FindElementById("title").Text;
                Assert.AreEqual("Edit", title);

            }
            catch (Exception ex)
            {
                Assert.Fail(ex.ToString());
            }
            finally
            {
                driver.Quit();
                driver.Dispose();
            }
        }

        [TestMethod]
        [TestCategory("CodedUI")]
        [Priority(1)]
        public void DepartamentDetails()
        {
            try
            {
                driver = new ChromeDriver(Environment.GetEnvironmentVariable("ChromeWebDriver"));
                driver.Manage().Window.Maximize();
                driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(30);
                driver.Navigate().GoToUrl(this.baseURL);

                //disable cookie alert
                //driver.FindElement(By.Id("btn-cookie")).Click();

                driver.FindElementById("link-students").Click();
                string resDep = driver.FindElementById("title").Text;
                Assert.AreEqual("Students", resDep);

                // localiza a tablea e recupera o body
                IWebElement body = driver.FindElementById("table-list").FindElement(By.TagName("tbody"));

                // Pega a primeira linha da tabela e clica no link
                body.FindElements(By.TagName("tr"))[0].FindElement(By.LinkText("Details")).Click();

                //procura o titulo da pagina
                string title = driver.FindElementById("title").Text;
                Assert.AreEqual("Details", title);

            }
            catch (Exception ex)
            {
                Assert.Fail(ex.ToString());
            }
            finally
            {
                driver.Quit();
                driver.Dispose();
            }
        }


        [TestMethod]
        [TestCategory("CodedUI")]
        [Priority(1)]
        public void DepartamentCreate()
        {
            try
            {
                driver = new ChromeDriver(Environment.GetEnvironmentVariable("ChromeWebDriver"));
                driver.Manage().Window.Maximize();
                driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(30);
                driver.Navigate().GoToUrl(this.baseURL);

                //disable cookie alert
                //driver.FindElement(By.Id("btn-cookie")).Click();

                driver.FindElementById("link-students").Click();
                string resDep = driver.FindElementById("title").Text;
                Assert.AreEqual("Students", resDep);

                // clica no link create new
                driver.FindElementById("link-create").Click();

                // input das informações
                driver.FindElement(By.Name("Student.LastName")).SendKeys("Last");
                driver.FindElement(By.Name("Student.FirstName")).SendKeys("5000");
                driver.FindElement(By.Name("Student.EnrollmentDate")).SendKeys("23/02/2023 11:45 AM");

                // clica no botão create
                driver.FindElement(By.Id("btn-create")).Click();
               
            }
            catch (Exception ex)
            {
                Assert.Fail(ex.ToString());
            }
            finally
            {
                driver.Quit();
                driver.Dispose();
            }
        }

        [TestInitialize()]
        public void MyTestInitialize()
        {
            //if (this.TestContext.Properties["Url"] != null) //Set URL from a build
            //{
            //    this.baseURL = this.TestContext.Properties["Url"].ToString();
            //}
        }

        [TestCleanup()]
        public void MyTestCleanup()
        {
            try
            {
                driver.Quit();
                driver.Dispose();

            }
            catch (Exception)
            {
            }
        }

    }
}
