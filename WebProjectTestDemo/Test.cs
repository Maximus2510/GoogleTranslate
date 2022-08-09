
using Microsoft.VisualStudio.TestTools.UnitTesting;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;

namespace WebProjectTestDemo
{
    [TestClass]
    public class Test
    {

        private IWebDriver driver;
        private string baseUrl;

        [TestInitialize]
        public void SetupTest()
        {
            //var service = ChromeDriverService.CreateDefaultService();
            this.driver = new ChromeDriver();
            this.baseUrl = "https://translate.google.com";
            this.driver.Manage().Window.Maximize();
            this.driver.Navigate().GoToUrl(baseUrl);
        }

        [TestMethod]
        public void TestMethod()
        {
            this.driver.FindElement(By.ClassName("er8xn")).Click();
            this.driver.FindElement(By.ClassName("er8xn")).SendKeys("Тест");
            Thread.Sleep(3000);
            this.driver.FindElement(By.ClassName("J0lOec")).Click();
            string checkTranslateResultText = this.driver.FindElement(By.ClassName("J0lOec")).Text;
            Assert.AreEqual(checkTranslateResultText, "Test");
            Thread.Sleep(5000);
            
        }

        [TestMethod]
        public void CheckHeader()
        {
            var source = this.driver.FindElement(By.XPath("//*[@id='sdgBod']/span[2]")).Text;
            Assert.AreEqual(source, "Translate");
            Thread.Sleep(5000);
        }

        [TestCleanup]
        public void CleanUp()
        {
            this.driver.Close();
        }
    }
}