using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using System;
using System.Collections.Generic;
using System.IO;
using System.Security.Permissions;
using System.Text;

namespace SeleniumVSTS.UITests
{
    public static class WebDriverExtensions
    {        
        public static void CarregarPagina(this IWebDriver webDriver,TimeSpan timeToWait, string url)
        {
            webDriver.Manage().Timeouts().PageLoad = timeToWait;
            webDriver.Navigate().GoToUrl(url);
        }

        public static string ObterTexto(this IWebDriver webDriver, By by)
        {
            IWebElement webElement = webDriver.FindElement(by);
            return webElement.Text;
        }

        public static string ObterValue(this IWebDriver webDriver, By by)
        {
            IWebElement webElement = webDriver.FindElement(by);
            return webElement.GetAttribute("value");
        }

        public static void AtribuirTexto(this IWebDriver webDriver,By by, string text)
        {
            IWebElement webElement = webDriver.FindElement(by);
            webElement.SendKeys(text);
        }

        public static void Submit(this IWebDriver webDriver, By by)
        {
            IWebElement webElement = webDriver.FindElement(by);
            webElement.Submit();
        }

        public static bool ValidarUrl(this IWebDriver webDriver, string conteudo)
        {            
            var wait  = new WebDriverWait(webDriver, TimeSpan.FromSeconds(30));
            return wait.Until(a => a.Url == conteudo);
        }
        
        public static void SalvarScreenShot(this IWebDriver webDriver, string pasta, string nome,string prefix = "")
        {
            var folder = string.Format(@"{0}/{1}/{2}", Directory.GetCurrentDirectory() , @"Screenshots", pasta);
            if (!Directory.Exists(folder))            
               Directory.CreateDirectory(folder);            
            
            var filename = string.Format(prefix +"_{0}_" + nome+".png", DateTime.Now.ToFileTime());
            var screenshot = ((ITakesScreenshot)webDriver).GetScreenshot();
            screenshot.SaveAsFile(string.Format(@"{0}/{1}", folder, filename),
                ScreenshotImageFormat.Png);
        }
    }
}
