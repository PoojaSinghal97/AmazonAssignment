using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using Automation.Assignment;


namespace ProductPriceComparisonTests
{
    public class ProductPriceComparisonTests
    {
        private IWebDriver driver;
        
         

        [SetUp]
        public void SetUp()
        {
            driver = new ChromeDriver();
            
        }

        [Test]
        public void BuyProduct_onAmazon()
        {
            string product = "Laptop";

            AmazonPage amazonPage = new AmazonPage(driver);
            string productPrice=  amazonPage.searchProduct_AddToCart();
            Console.WriteLine("productPrice ="+productPrice);
        }

        [TearDown]
        public void TearDown()
        {
            driver.Quit();
        }
    }
}




