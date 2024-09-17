using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;

namespace Automation
{
    public class Tests
    {
        private IWebDriver _driver;
        private IJavaScriptExecutor _js;
        [SetUp]
        public void Setup()
        {
            _driver = new ChromeDriver();
            _js = (IJavaScriptExecutor)_driver;
        }
        [TearDown]
        protected void TearDown()
        {
            _driver.Quit();
        }
        [Test]
        public void Test1()
        {
            Assert.Pass();
        }
    }
}