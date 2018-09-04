using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Remote;
using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace SeleniumVSTS.UITests
{
    public static class WebDriverFactory
    {
        static string UrlSeleniumGrid = Environment.GetEnvironmentVariable("urlSeleniumGrid");
        public static IWebDriver CreateWebDriver()
        {
            try
            {
                if (!string.IsNullOrWhiteSpace(Environment.GetEnvironmentVariable("usehub")))
                {
                    IWebDriver webDriver = null;
                    var opt = new ChromeOptions();
                    webDriver = new RemoteWebDriver(new Uri(UrlSeleniumGrid + "/wd/hub"), opt.ToCapabilities());
                    return webDriver;
                }
                else
                {
                    IWebDriver webDriver = null;
                    webDriver = new ChromeDriver();
                    return webDriver;
                }
            }
            catch (Exception ex)
            {
                throw;
            }
        }
    }
}
