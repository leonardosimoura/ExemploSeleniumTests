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
        static string UrlNodeChorme = Environment.GetEnvironmentVariable("urlNodeChorme");
        public static IWebDriver CreateWebDriver()
        {
            try
            {
                IWebDriver webDriver = null;
                var opt = new ChromeOptions();  
                webDriver = new RemoteWebDriver(new Uri(UrlNodeChorme + "/wd/hub"), opt.ToCapabilities());
                return webDriver;
            }
            catch (Exception ex)
            {
                throw new Exception(UrlNodeChorme + "/wd/hub", ex);
            }
        }

        //public static IWebDriver CreateWebDriver()
        //{
        //    IWebDriver webDriver = null;
        //    webDriver = new ChromeDriver(Directory.GetCurrentDirectory());
        //    return webDriver;
        //}
    }
}
