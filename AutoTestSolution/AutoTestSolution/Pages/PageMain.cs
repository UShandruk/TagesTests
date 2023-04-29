using AutoTestSolution;
using NUnit.Framework;
using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AutotestProject.Pages
{
    /// <summary>
    /// https://tages.ru/
    /// </summary>
    internal class PageMain : PageAbstract
    {
        /// <summary>
        /// Логотип
        /// </summary>
        internal IWebElement BtnLogo => WebDriver.FindElement(By.CssSelector("#__layout > div > header > div.header__sticky-wrapper > div > div > a > svg"));

        /// <summary>
        /// Кнопка "О компании"
        /// </summary>
        internal IWebElement BtnAboutCompany => WebDriver.FindElement(By.CssSelector("#__layout > div > header > div.header__sticky-wrapper > div > div > div > nav > ul > li:nth-child(1) > a"));

        /// <summary>
        /// Кнопка "Академия"
        /// </summary>
        internal IWebElement BtnAcademy => WebDriver.FindElement(By.CssSelector("#__layout > div > header > div.header__sticky-wrapper > div > div > div > nav > ul > li:nth-child(2) > a"));

        /// <summary>
        /// Кнопка "Мероприятия"
        /// </summary>
        internal IWebElement BtnEvents => WebDriver.FindElement(By.CssSelector("#__layout > div > header > div.header__sticky-wrapper > div > div > div > nav > ul > li:nth-child(3) > a"));

        /// <summary>
        /// Кнопка "Блог"
        /// </summary>
        internal IWebElement BtnBlog => WebDriver.FindElement(By.CssSelector("#__layout > div > header > div.header__sticky-wrapper > div > div > div > nav > ul > li:nth-child(4) > a"));

        /// <summary>
        /// Кнопка "Вакансии"
        /// </summary>
        internal IWebElement BtnVacancies => WebDriver.FindElement(By.CssSelector("#__layout > div > header > div.header__sticky-wrapper > div > div > div > nav > ul > li:nth-child(5) > a"));

        /// <summary>
        /// Кнопка "Вакансии" (на странице "Блог")
        /// </summary>
        internal IWebElement BtnVacanciesFromBlog => WebDriver.FindElement(By.CssSelector("body > div > header > div > div > div > div.header__menus > nav > ul > li:nth-child(5) > a"));

        /// <summary>
        /// Кнопка "Контакты"
        /// </summary>
        internal IWebElement BtnContacts => WebDriver.FindElement(By.CssSelector("#__layout > div > header > div.header__sticky-wrapper > div > div > div > nav > ul > li:nth-child(6) > a"));

        /// <summary>
        /// Форма обратной связи -> Поле "Имя*"
        /// </summary>
        internal IWebElement FieldName_FormFeedback => WebDriver.FindElement(By.XPath("//input[@placeholder = \"Имя*\"]"));

        /// <summary>
        /// Форма обратной связи -> Поле "Телефон*"
        /// </summary>
        internal IWebElement FieldPhone_FormFeedback => WebDriver.FindElement(By.XPath("//input[@placeholder = \"Телефон*\"]"));

        /// <summary>
        /// Форма обратной связи -> Поле "Компания"
        /// </summary>
        internal IWebElement FieldCompany_FormFeedback => WebDriver.FindElement(By.XPath("//input[@placeholder = \"Компания\"]"));

        /// <summary>
        /// Форма обратной связи -> Поле "Почта*"
        /// </summary>
        internal IWebElement FieldEmail_FormFeedback => WebDriver.FindElement(By.XPath("//input[@placeholder = \"Почта*\"]"));

        /// <summary>
        /// Форма обратной связи -> Поле "Комментарий"
        /// </summary>
        internal IWebElement FieldComment_FormFeedback => WebDriver.FindElement(By.XPath("//input[@placeholder = \"Комментарий\"]"));

        /// <summary>
        /// Форма обратной связи -> Кнопка "Отправить"
        /// </summary>
        internal IWebElement BtnSend_FormFeedback => WebDriver.FindElement(By.XPath("//button[@class = \"form__send-form-button button\"]"));

        /// <summary>
        /// Класс, которым отмечаются поля не прошедшие валидацию (и становятся красными)
        /// </summary>
        internal string ClassError_Fields_FormFeedback = "form__input_error";

        /// <summary>
        /// Форма обратной связи -> Значок "Ваше обращение получено"
        /// </summary>
        internal IWebElement IconSuccess_FormFeedback => WebDriver.FindElement(By.XPath("//div[@class = \"form__success-badge\"]"));

        /// <summary>
        /// Низ страницы -> Контакты: -> Телефон
        /// </summary>
        internal IWebElement LinkTel_Contacts_Bottom => WebDriver.FindElement(By.XPath("//a[@aria-label = \"Телефон компании\"]"));

        /// <summary>
        /// Низ страницы -> Контакты: -> Email
        /// </summary>
        internal IWebElement LinkEmail_Contacts_Bottom => WebDriver.FindElement(By.XPath("//a[@aria-label = \"Почтовый адрес компании\"]"));

        /// <summary>
        /// Низ страницы -> Пресс-служба (контакты для СМИ): -> Телефон
        /// </summary>
        internal IWebElement LinkTel_PressOffice_Bottom => WebDriver.FindElement(By.XPath("//a[@aria-label = \"Телефон пресс-службы\"]"));

        /// <summary>
        /// Низ страницы -> Пресс-служба (контакты для СМИ): -> Email
        /// </summary>
        internal IWebElement LinkEmail_PressOffice_Bottom => WebDriver.FindElement(By.XPath("//a[@aria-label = \"Почтовый адрес пресс-службы\"]"));
    }
}