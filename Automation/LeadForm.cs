using automation.helper;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Support.UI;

namespace Automation
{
    public class LeadForm
    {
        private IWebDriver driver;
        private IJavaScriptExecutor _js;
        private WebDriverWait wait;
        private IFind find;
        private IClick click;
        private ISubmit submit;
        [SetUp]
        public void Setup() 
        {
            driver = new ChromeDriver();

            driver.Navigate().GoToUrl("https://www.squareyards.com/sale/property-for-sale-in-mumbai");
            driver.Manage().Window.Maximize();
            _js = (IJavaScriptExecutor)driver;
            wait = new WebDriverWait(driver, TimeSpan.FromSeconds(3));
            find = new Find();
            click = new Click();
            submit = new Submit();
        } 
        [TearDown]
        protected void TearDown()
        {
            driver.Quit();
        }


        // start
        [Test]
        public void submitLead()
        {
            IWebElement leadForm = find.byClass(driver, "tlWrp");
            click.byCssSelector(driver, ".btn-primary.tlBtnBoCtaBtn.tlBxCta.DSE_Resale_C2");
            IWebElement listingDSEContactAgentForm = find.byId(driver, "listingDSEContactAgentForm");
            IWebElement nameInput = find.byId(listingDSEContactAgentForm, "name");
            IWebElement emailInput = find.byId(listingDSEContactAgentForm, "email");
            IWebElement mobileInput = find.byId(listingDSEContactAgentForm, "mobile");

            if (nameInput != null && emailInput != null && mobileInput != null)
            {
                submit.send(nameInput, " ");
                submit.send(emailInput, " ");
                submit.send(mobileInput, " ");

                IWebElement fromotptextbox = find.byId(driver, "BoxOtpDSE");
                IWebElement otptextbox = find.byId(fromotptextbox, "otpInput");
                submit.send(otptextbox, " ");
                Thread.Sleep(2000);

            }
            else
            {
                Console.WriteLine("error");
            }
            Assert.Pass();
        }
    }
}
