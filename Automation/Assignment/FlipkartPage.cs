using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Support.UI;
using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using automation.helper;
using SeleniumExtras.WaitHelpers;

namespace Automation.Assignment
{
    public class FlipkartPage
   
    {
        private IWebDriver driver;
        private IJavaScriptExecutor jsExecutor;
        private WebDriverWait wait;
        private IFind find;
        private IClick click;
        private ISubmit submit;
        public FlipkartPage(IWebDriver Driver)
        {

            driver = new ChromeDriver();

            driver.Navigate().GoToUrl("https://www.flipkart.com/");
            driver.Manage().Window.Maximize();
            jsExecutor = (IJavaScriptExecutor)driver;
            jsExecutor.ExecuteScript("var script = document.createElement('script');" +
                                        "script.src = 'https://code.jquery.com/jquery-3.6.0.min.js';" +
                                        "document.head.appendChild(script);");
            wait = new WebDriverWait(driver, TimeSpan.FromSeconds(3));
            find = new Find();
            click = new Click();
            submit = new Submit();
        }
        public string searchProduct_AddToCart()
        {

            // Find the search box, enter "Laptop" and submit the search
            IWebElement searchBox = find.byClass(driver, "Pke_EE");
            submit.send(searchBox, "Laptop");
            click.byClass(driver, "_2iLD__");

            // Wait for search results to load
            Thread.Sleep(2000);
            IWebElement firstCart = find.byPath(driver, "//*[@data-cel-widget='MAIN-SEARCH_RESULTS-3']");
            click.byClass(firstCart, "s-image");
            Thread.Sleep(1000);

            // Wait for the product page to load
            var windowHandles = driver.WindowHandles;
            WebDriverWait wait = new WebDriverWait(driver, TimeSpan.FromSeconds(10));
            driver.SwitchTo().Window(windowHandles.Last());


            //  ************** get name or price  ******************************************
            IWebElement TextName = find.byId(driver, "titleSection");

            IWebElement Costdiv = find.byId(driver, "corePriceDisplay_desktop_feature_div");
            IWebElement Costtest = find.byClass(Costdiv, "a-price-whole");
            string productname = TextName.Text;
            string productprice = Costtest.Text;




            //  ************** add to cart  ******************************************                       
            try
            {


                // Wait until the element is present
                IWebElement buyBoxAccordion = wait.Until(ExpectedConditions.ElementIsVisible(By.Id("buyBoxAccordion")));
                IWebElement addToCart_feature_div = find.byId(buyBoxAccordion, "addToCart_feature_div");
                IWebElement buttonstack = find.byClass(addToCart_feature_div, "a-button-stack");
                Thread.Sleep(1000);
                jsExecutor.ExecuteScript(@"
                                        var element = document.getElementById('add-to-cart-button');
                                        element.dispatchEvent(new Event('mouseover'));
                                        element.dispatchEvent(new Event('mousedown'));
                                        element.click();
                                    ");

                Thread.Sleep(3000);
                // jsExecutor.ExecuteScript("$('#add-to-cart-button').click();"); 
                Thread.Sleep(3000);


                IWebElement addcardpopup = find.byId(driver, "attach-accessory-pane");
                click.byClass(addcardpopup, "a-button-input");
            }
            catch (NoSuchElementException ex)
            {
                Console.WriteLine("Add to cart button not found: " + ex.Message);
            }
            return "";
        }
    }

}

