using automation.helper;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Interactions;
using OpenQA.Selenium.Support.UI;
using SeleniumExtras.WaitHelpers;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;
using System.Text;
using System.Threading.Tasks;
namespace Automation.Assignment
{
    public class AmazonPage
    {
        private IWebDriver driver;
        private IJavaScriptExecutor jsExecutor;
        private WebDriverWait wait;
        private IFind find;
        private IClick click;
        private ISubmit submit;
        public AmazonPage(IWebDriver Driver) {

            driver = Driver;

            driver.Navigate().GoToUrl("https://www.amazon.in");
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
            IWebElement  searchBox = find.byId(driver, "twotabsearchtextbox");
            submit.send(searchBox,"Laptop");
            click.byId(driver, "nav-search-submit-button");

            // Wait for search results to load
            Thread.Sleep(2000);
            IWebElement firstCart = find.byPath(driver,"//*[@data-cel-widget='MAIN-SEARCH_RESULTS-3']");
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
                jsExecutor.ExecuteScript("var script = document.createElement('script');" +
                                        "script.src = 'https://code.jquery.com/jquery-3.6.0.min.js';" +
                                        "document.head.appendChild(script);");

                Thread.Sleep(3000);
                jsExecutor.ExecuteScript("window.scrollBy(0, 500);");

                // Wait until the element is present
                IWebElement buyBoxAccordion = wait.Until(ExpectedConditions.ElementIsVisible(By.Id("buyBoxAccordion")));
               // IWebElement addToCart_feature_div = find.byId(buyBoxAccordion,"addToCart_feature_div");
                IWebElement addToCart_feature_div = find.byPath(buyBoxAccordion, "/html/body/div[2]/div/div[5]/div[3]/div[1]/div[4]/div/div[1]/div/div[1]/div/div/div[2]/div/div[2]/div/form/div/div/div[38]");
                IWebElement buttonstack = find.byId(addToCart_feature_div, "submit.add-to-cart");
                Thread.Sleep(1000);

                   // jsExecutor.ExecuteScript("$('#add-to-cart-button').click();"); 
                IWebElement addToCartButton = buttonstack.FindElement(By.Id("add-to-cart-button"));
                    //jsExecutor.ExecuteScript("arguments[0].click();", addToCartButton);
                 

                // Once clickable, interact with the button
                addToCartButton.Click();

                IWebElement addcardpopup = find.byId(driver, "attach-sidesheet-checkout-button");
                click.byClass(addcardpopup, "a-button-input");
            }
            catch (NoSuchElementException ex)
            {
                Console.WriteLine("Add to cart button not found: " + ex.Message);
            }
            return productprice;
        }                  
    }

}

