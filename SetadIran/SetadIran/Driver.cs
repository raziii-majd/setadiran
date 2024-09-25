using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Support.UI;
using OpenQA.Selenium;
using SeleniumExtras.WaitHelpers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using System.Threading.Tasks;
using SetadIran.Service;

namespace SetadIran
{
    internal class Driver
    {

        public static string currentCookie = "";
        public static string BaseURL = "https://fe.setadiran.ir/centralboard/#/central-board-0";
        public static int timeout = 120;
        public IWebDriver driver;
        public WebDriverWait wait;
        public static bool LoggedIn = false;
        public Driver()
        {

            var chromeOptions = new ChromeOptions();
            //chromeOptions.AddArguments("no-startup-window");
            //chromeOptions.AddArguments("headless"); // Run Chrome in headless mode
            chromeOptions.AddArguments("disable-gpu");
            chromeOptions.AddArguments("ignore-certificate-errors");
            chromeOptions.AddArguments("ignore-ssl-errors");
            chromeOptions.AddArguments("--disable-gpu");
            chromeOptions.AddArguments("--ignore-certificate-errors");
            chromeOptions.AddArguments("--ignore-ssl-errors");
            chromeOptions.AddArgument("no-sandbox");
            driver = new ChromeDriver(chromeOptions);
            //driver = new ChromeDriver();
            //driver = new FirefoxDriver();
            wait = new WebDriverWait(driver, new TimeSpan(0, 0, timeout));



        }

        public void OpenSite()
        {
            LoggedIn = false;
            LoggingService.Log("opensite started", "CrawlerGeneral", "OpenSite", false, "opensite started", "", "Info");
            driver.Navigate().GoToUrl(Driver.BaseURL);
            driver.Manage().Timeouts().AsynchronousJavaScript = TimeSpan.FromSeconds(Driver.timeout);
            driver.Manage().Window.Maximize();

            LoggingService.Log("opensite done", "CrawlerGeneral", "OpenSite", false, "opensite done", "", "Info");
        }

    
        public static string? GetCurrentCookie(IWebDriver driver)
        {
            while (true)
            {
                string cookiesText = "";
                try
                {
                    var cookies = driver.Manage().Cookies.AllCookies;
                    foreach (var cookie in cookies)
                        cookiesText += cookie.Name + "=" + cookie.Value + "; ";
                    if (string.IsNullOrWhiteSpace(cookiesText))
                    {
                        Thread.Sleep(100);
                        continue;
                    }
                }
                catch (Exception e)
                {
                    Thread.Sleep(100);
                    continue;
                }
                return cookiesText;
            }
        }
    }
}
