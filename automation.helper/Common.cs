using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Support.UI;
namespace automation.helper
{
    public  static  class Common
    {
        public static void Slowindow(IWebDriver driver, int xOffset, int yOffset)
        {
            // Cast driver to JavaScript Executor
            IJavaScriptExecutor js = (IJavaScriptExecutor)driver;

            // Execute JavaScript to scroll the window
            js.ExecuteScript($"window.scrollBy({xOffset}, {yOffset})");

            // Wait for a short time to allow scrolling to complete
            System.Threading.Thread.Sleep(1000); // You may adjust the sleep time according to your requirement
        }
        public static bool IsPageLoaded(IWebDriver driver)
        {
            try
            {
                // Set up an explicit wait for document.readyState to be "complete"
                WebDriverWait wait = new WebDriverWait(driver, TimeSpan.FromSeconds(10));
                wait.Until(driver => ((IJavaScriptExecutor)driver).ExecuteScript("return document.readyState").Equals("complete"));

                // Optionally, you can add additional checks here if needed

                return true;
            }
            catch (WebDriverTimeoutException)
            {
                // If the timeout exception occurs, return false indicating the page hasn't loaded completely
                return false;
            }
        }
        /// <summary>
        /// Scrolls the browser window down by a specific amount.
        /// </summary>
        /// <param name="driver">The WebDriver instance.</param>
        /// <param name="pixels">The number of pixels to scroll down.</param>
        public static void ScrollDown(this IWebDriver driver, int pixels)
        {
            IJavaScriptExecutor js = (IJavaScriptExecutor)driver;
            js.ExecuteScript($"window.scrollBy(0, {pixels});");
        }
        /// <summary>
        /// Scrolls the browser window up by a specific amount.
        /// </summary>
        /// <param name="driver">The WebDriver instance.</param>
        /// <param name="pixels">The number of pixels to scroll up.</param>
        public static void ScrollUp(this IWebDriver driver, int pixels)
        {
            IJavaScriptExecutor js = (IJavaScriptExecutor)driver;
            js.ExecuteScript($"window.scrollBy(0, {-pixels});");
        }

        /// <summary>
        /// Scrolls the browser window to a specific element.
        /// </summary>
        /// <param name="driver">The WebDriver instance.</param>
        /// <param name="element">The WebElement to scroll into view.</param>
        public static void ScrollToElement(this IWebDriver driver, IWebElement element)
        {
            IJavaScriptExecutor js = (IJavaScriptExecutor)driver;
            js.ExecuteScript("arguments[0].scrollIntoView(true);", element);
        }
    }
}
