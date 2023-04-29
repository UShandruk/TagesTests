using AutotestProject.Pages;
using AutotestProject.Utilites;
using Microsoft.VisualStudio.TestPlatform.CommunicationUtilities;
//using AutoTestSolution.Model;
//using Microsoft.VisualStudio.TestPlatform.PlatformAbstractions.Interfaces;
using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using System;
using System.Diagnostics;
using System.Threading;

namespace AutoTestSolution
{
    [TestFixture]
    [Category("Category_MainPage")]
    public class TestsMainPage : PageAbstract
    {
        /// <summary>
        /// Кейс 1 - Проверить кликабельность всех ссылок и разделов
        /// </summary>
        [Test]
        public void Case_1_ClickableAllLinks()
        {
            PageMain pageMain = new PageMain();

            // 1) Проверить кликабельность кнопки "О компании"
            pageMain.BtnAboutCompany.Click();
            string message = "Текущий URL - '" + WebDriver.Url + "'. Ожидаемый URL - '" + Settings.UrlAboutCompany + "'.";
            Assert.AreEqual(WebDriver.Url, Settings.UrlAboutCompany, message);

            // 2) Проверить кликабельность кнопки "Академия"
            pageMain.BtnAcademy.Click();
            message = "Текущий URL - '" + WebDriver.Url + "'. Ожидаемый URL - '" + Settings.UrlAcademy + "'.";
            Assert.AreEqual(WebDriver.Url, Settings.UrlAcademy, message);

            // 3) Проверить кликабельность кнопки "Мероприятия"
            pageMain.BtnEvents.Click();
            message = "Текущий URL - '" + WebDriver.Url + "'. Ожидаемый URL - '" + Settings.UrlEvents + "'.";
            Assert.IsTrue(WebDriver.Url == Settings.UrlEvents || WebDriver.Url == Settings.UrlEvents + "/?archive=true", message);
 
            // 4) Проверить кликабельность кнопки "Блог" 
            pageMain.BtnBlog.Click();
            message = "Текущий URL - '" + WebDriver.Url + "'. Ожидаемый URL - '" + Settings.UrlBlog + "'.";
            Assert.AreEqual(WebDriver.Url, Settings.UrlBlog, message);

            //TODO: не работает переход со страницы БЛОГ
            // 5) Проверить кликабельность кнопки "Вакансии"
            pageMain.BtnVacanciesFromBlog.Click();
            message = "Текущий URL - '" + WebDriver.Url + "'. Ожидаемый URL - '" + Settings.UrlVacancies + "'.";
            Assert.AreEqual(WebDriver.Url, Settings.UrlVacancies, message);

            // 6) Проверить кликабельность кнопки "Контакты"
            pageMain.BtnContacts.Click();
            message = "Текущий URL - '" + WebDriver.Url + "'. Ожидаемый URL - '" + Settings.UrlContacts + "'.";
            Assert.AreEqual(WebDriver.Url, Settings.UrlContacts, message);

            // 7) Проверить кликабельность логотипа в левом верхнем углу
            pageMain.BtnLogo.Click();
            message = "Текущий URL - '" + WebDriver.Url + "'. Ожидаемый URL - '" + Settings.UrlMain + "'.";
            Assert.IsTrue(WebDriver.Url == Settings.UrlMain || WebDriver.Url == Settings.UrlMain + "/", message);

            WebDriver.Close();
        }

        /// <summary>
        /// Кейс 2 - Проверить вызовы email и tel
        /// </summary>
        [Test]
        public void Case_2_EmailAndTel()
        {
            PageMain pageMain = new PageMain();

            // 1) Проверить вызов email
            string message = "Процесс '" + Settings.ProcessEmailName + "' не найден";
            Assert.IsFalse(Utilites.GetProcessesNames().Contains(Settings.ProcessEmailName), message);
            pageMain.LinkEmail_Contacts_Bottom.Click();
            Utilites.DoAdditionalWait();
            Process processEmail = Utilites.GetProcessByName(Settings.ProcessEmailName);
            processEmail.Kill();

            // 2) Проверить вызов tel
            message = "Процесс '" + Settings.ProcessPhoneName + "' не найден";
            Assert.IsFalse(Utilites.GetProcessesNames().Contains(Settings.ProcessPhoneName), message);
            pageMain.LinkTel_Contacts_Bottom.Click();
            Utilites.DoAdditionalWait();
            Process processPhone = Utilites.GetProcessByName(Settings.ProcessPhoneName);
            processPhone.Kill();
            WebDriver.Close();
        }

        /// <summary>
        /// Кейс 3 и 4 - Проверить валидацию формы обратной связи
        /// </summary>
        [Test]
        public void Case_3_4_FormFeedbackValidationCheck_TestFeedbackRequestSend()
        {
            PageMain pageMain = new PageMain();

            // [ Кейс 3 ]
            // Проверка обязательности обязательных полей
            pageMain.BtnSend_FormFeedback.Click();
            string message = "Поле 'Имя' не отмечено как не прошедшее валидацию";
            Assert.IsTrue(pageMain.FieldName_FormFeedback.GetAttribute("class").Contains(pageMain.ClassError_Fields_FormFeedback), message);
            message = "Поле 'Телефон' не отмечено как не прошедшее валидацию";
            Assert.IsTrue(pageMain.FieldPhone_FormFeedback.GetAttribute("class").Contains(pageMain.ClassError_Fields_FormFeedback), message);
            message = "Поле 'Почта' не отмечено как не прошедшее валидацию";
            Assert.IsTrue(pageMain.FieldEmail_FormFeedback.GetAttribute("class").Contains(pageMain.ClassError_Fields_FormFeedback), message);

            // Проверка поля "Имя*". В настоящий момент допустимо: два любых символа, включая спецсимволы, цифры и пробелы.
            pageMain.FieldName_FormFeedback.Click();
            pageMain.FieldName_FormFeedback.SendKeys("а");
            pageMain.BtnSend_FormFeedback.Click();
            message = "Поле 'Имя' не отмечено как не прошедшее валидацию";
            Assert.IsTrue(pageMain.FieldName_FormFeedback.GetAttribute("class").Contains(pageMain.ClassError_Fields_FormFeedback), message);

            pageMain.FieldName_FormFeedback.SendKeys("б");
            pageMain.BtnSend_FormFeedback.Click();
            Assert.IsFalse(pageMain.FieldName_FormFeedback.GetAttribute("class").Contains(pageMain.ClassError_Fields_FormFeedback), message);

            // Проверка поля "Телефон*". В настоящий момент допустимо: 10 цифр. В результате получаем номер в формате 123 456 78 90.
            pageMain.FieldPhone_FormFeedback.Click();
            pageMain.FieldPhone_FormFeedback.SendKeys("а");
            pageMain.BtnSend_FormFeedback.Click();
            message = "Поле 'Телефон' не отмечено как не прошедшее валидацию";
            Assert.IsTrue(pageMain.FieldPhone_FormFeedback.GetAttribute("class").Contains(pageMain.ClassError_Fields_FormFeedback), message);

            pageMain.FieldPhone_FormFeedback.SendKeys("1234567890");
            pageMain.BtnSend_FormFeedback.Click();
            Assert.IsFalse(pageMain.FieldPhone_FormFeedback.GetAttribute("class").Contains(pageMain.ClassError_Fields_FormFeedback), message);

            pageMain.FieldPhone_FormFeedback.SendKeys("f");
            pageMain.BtnSend_FormFeedback.Click();
            Assert.IsFalse(pageMain.FieldPhone_FormFeedback.GetAttribute("class").Contains(pageMain.ClassError_Fields_FormFeedback), message);

            // У поля "Компания" нет правил валидации.

            // Проверка поля "Почта". В настоящий момент допустимо: латинские буквы и цифры + @ + латинские буквы и цифры + .ru. В результате получаем email номер в формате example@domain.ru
            pageMain.FieldEmail_FormFeedback.Click();
            pageMain.FieldEmail_FormFeedback.SendKeys("e");
            pageMain.BtnSend_FormFeedback.Click();
            message = "Поле 'Почта' не отмечено как не прошедшее валидацию";
            Assert.IsTrue(pageMain.FieldEmail_FormFeedback.GetAttribute("class").Contains(pageMain.ClassError_Fields_FormFeedback), message);

            pageMain.FieldEmail_FormFeedback.Click();
            pageMain.FieldEmail_FormFeedback.SendKeys("xample@");
            pageMain.BtnSend_FormFeedback.Click();
            Assert.IsTrue(pageMain.FieldEmail_FormFeedback.GetAttribute("class").Contains(pageMain.ClassError_Fields_FormFeedback), message);

            pageMain.FieldEmail_FormFeedback.Click();
            pageMain.FieldEmail_FormFeedback.SendKeys("domain");
            pageMain.BtnSend_FormFeedback.Click();
            Assert.IsTrue(pageMain.FieldEmail_FormFeedback.GetAttribute("class").Contains(pageMain.ClassError_Fields_FormFeedback), message);

            pageMain.FieldEmail_FormFeedback.Click();
            pageMain.FieldEmail_FormFeedback.SendKeys(Keys.End);
            pageMain.FieldEmail_FormFeedback.SendKeys(".ru");

            pageMain.BtnSend_FormFeedback.Click();
            message = "Поле 'Почта' отмечено как не прошедшее валидацию";
            Assert.IsFalse(pageMain.FieldEmail_FormFeedback.GetAttribute("class").Contains(pageMain.ClassError_Fields_FormFeedback), message);

            // [ Кейс 4 ]
            // Отправить тестовый запрос Обратной связи
            Utilites.DoAdditionalWait();
            message = "Значок 'Ваше обращение получено' не виден";
            Assert.IsTrue(pageMain.IconSuccess_FormFeedback.Displayed, message);
        }
    }
}