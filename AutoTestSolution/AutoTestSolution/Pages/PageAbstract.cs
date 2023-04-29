using AutoTestSolution;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Interactions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AutotestProject.Pages
{
    /// <summary>
    /// Абстрактный класс, описывающий базовые свойства и методы по работе со страницами приложения 
    /// </summary>
    public abstract class PageAbstract
    {
        /// <summary>
        /// Веб-драйвер
        /// </summary>
        protected static IWebDriver WebDriver { get; set; }
        protected OpenQA.Selenium.Support.UI.WebDriverWait Wait { get; set; }

        /// <summary>
        /// Конструктор
        /// </summary>
        public PageAbstract()
        {
            if (WebDriver == null)
            {
                WebDriver = InitializeLocalWebDriver();
                WebDriver.Manage().Timeouts().PageLoad = new TimeSpan(0, 0, Settings.SecondsToPageLoadWait);
                //webDriver.Manage().Timeouts().ImplicitWait = new TimeSpan(0, 0, Settings.SecondsToImplicitWait);
                WebDriver.Url = Settings.UrlMain;
            }
        }

        public IWebDriver InitializeLocalWebDriver()
        {
            ChromeOptions chromeOptions = new ChromeOptions();
            chromeOptions.AddArgument("start-maximized");
            IWebDriver driver = new ChromeDriver(chromeOptions);
            //IWebDriver driver = new InternetExplorerDriver(GetLocalInternetExplorerOptions());
            ////driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(Settings.SecondsToImplicitWait);
            ////SetImplicitWait(driver, Settings.SecondsToImplicitWait);
            return driver;
        }

        /// <summary>
        /// Навести курсор мыши на элемент (у IWebElement такого метода нет)
        /// </summary>
        internal void Hover(IWebElement element)
        {
            Actions actions = new Actions(WebDriver);
            actions.MoveToElement(element).Perform();
        }
    }
}
