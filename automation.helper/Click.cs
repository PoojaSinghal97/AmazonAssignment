using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OpenQA.Selenium.Chrome;
namespace automation.helper
{
    public interface IClick
    {
        public  void byId(IWebDriver webDriver, string key);
        public  void byId(IWebElement webDriver, string key);


        public  void byClass(IWebDriver webDriver, string key);
        public  void byClass(IWebElement webDriver, string key);


        public  void byPath(IWebDriver webDriver, string key);
        public  void byPath(IWebElement webDriver, string key);


        public  void byCssSelector(IWebDriver webDriver, string key);
        public  void byCssSelector(IWebElement webDriver, string key);


    }

    public  class Click : IClick
    {
        public  void byId(IWebDriver webDriver, string key)
        {
            webDriver.FindElement(By.Id(key)).Click();
            Thread.Sleep(2000);
        }
        public  void byClass(IWebDriver webDriver, string key)
        {
            webDriver.FindElement(By.ClassName(key)).Click();
            Thread.Sleep(2000);
        }
        public  void byPath(IWebDriver webDriver, string key)
        {
            webDriver.FindElement(By.XPath(key)).Click();
            Thread.Sleep(2000);
        }
        public  void byCssSelector(IWebDriver webDriver, string key)
        {
            webDriver.FindElement(By.CssSelector(key)).Click();
            Thread.Sleep(2000);
        }
            
        public  void byId(IWebElement webDriver, string key)
        {
            webDriver.FindElement(By.Id(key)).Click();
            Thread.Sleep(2000);
        }
        public  void byClass(IWebElement webDriver, string key)
        {
            webDriver.FindElement(By.ClassName(key)).Click();
            Thread.Sleep(2000);
        }
        public  void byPath(IWebElement webDriver, string key)
        {
            webDriver.FindElement(By.XPath(key)).Click();
            Thread.Sleep(2000);
        }
        public  void byCssSelector(IWebElement webDriver, string key)
        {
            webDriver.FindElement(By.CssSelector(key)).Click();
            Thread.Sleep(2000);
        }
    }


    public interface IFind
    {
        public IWebElement byId(IWebDriver webDriver, string key);
        public IWebElement byId(IWebElement webDriver, string key);

        public IWebElement byClass(IWebDriver webDriver, string key);
        public IWebElement byClass(IWebElement webDriver, string key);

        public IWebElement byPath(IWebDriver webDriver, string key);
        public IWebElement byPath(IWebElement webDriver, string key);
        public IWebElement byCssSelector(IWebDriver webDriver, string key);
        public IWebElement byCssSelector(IWebElement webDriver, string key);
        
        public IWebElement byxpath(IWebElement webDriver, string key);
         
    }
    public   class Find : IFind
    {
        public   IWebElement byId(IWebDriver webDriver, string key)
        {
           return webDriver.FindElement(By.Id(key));
        }
        public   IWebElement byClass(IWebDriver webDriver, string key)
        {
            return webDriver.FindElement(By.ClassName(key));
        }
        public   IWebElement byPath(IWebDriver webDriver, string key)
        {
            return webDriver.FindElement(By.XPath(key));
        }
        public   IWebElement byCssSelector(IWebDriver webDriver, string key)
        {
            return webDriver.FindElement(By.CssSelector(key));
        }
        public   IWebElement byId(IWebElement webDriver, string key)
        {
           return webDriver.FindElement(By.Id(key));
        }
        public   IWebElement byClass(IWebElement webDriver, string key)
        {
            return webDriver.FindElement(By.ClassName(key));
        }
        public   IWebElement byPath(IWebElement webDriver, string key)
        {
            return webDriver.FindElement(By.XPath(key));
        }
        public   IWebElement byCssSelector(IWebElement webDriver, string key)
        {
            return webDriver.FindElement(By.CssSelector(key));
        }
        public   IWebElement byxpath(IWebElement webDriver, string key)
        {
            return webDriver.FindElement(By.XPath(key));
        }
        
    }



    public interface ISubmit
    {
        public void byId(IWebDriver webDriver, string key, string submitText);

        public void byClass(IWebDriver webDriver, string key, string submitText);

        public void byPath(IWebDriver webDriver, string key, string submitText);

        public void byCssSelector(IWebDriver webDriver, string key, string submitText);
        
        public void send(IWebElement webDriver,string submitText);

        
         
    }
    public   class Submit : ISubmit
    {
        public   void byId(IWebDriver webDriver, string key, string submitText)
        {
            webDriver.FindElement(By.Id(key)).SendKeys(submitText); Thread.Sleep(2000);
        }
        public   void byClass(IWebDriver webDriver, string key, string submitText)
        {
            webDriver.FindElement(By.ClassName(key)).SendKeys(submitText); Thread.Sleep(2000);
        }
        public   void byPath(IWebDriver webDriver, string key, string submitText)
        {
            webDriver.FindElement(By.XPath(key)).SendKeys(submitText); Thread.Sleep(2000);
        }
        public   void byCssSelector(IWebDriver webDriver, string key,string submitText)
        {
             webDriver.FindElement(By.CssSelector(key)).SendKeys(submitText); Thread.Sleep(2000);
        }
         public   void send(IWebElement element, string submitText)
        {
            element.SendKeys(submitText); Thread.Sleep(2000);
        }
    }
}
