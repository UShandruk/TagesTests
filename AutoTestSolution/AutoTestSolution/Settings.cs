//using AutoTestSolution.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AutoTestSolution
{
    /// <summary>
    /// Общие настройки для всех тестов
    /// </summary>
    public static class Settings
    {
        /// <summary>
        /// URL главной страницы - https://tages.ru
        /// </summary>
        public static string UrlMain = "https://tages.ru";

        /// <summary>
        /// URL раздела "О компании" - https://tages.ru/about
        /// </summary>
        public static string UrlAboutCompany = UrlMain + "/about";

        /// <summary>
        /// URL раздела "Академия" - https://tages.ru/academy
        /// </summary>
        public static string UrlAcademy = UrlMain + "/academy";

        /// <summary>
        /// URL раздела "Мероприятия" - Либо https://tages.ru/events, либо https://tages.ru/events?archive=true
        /// </summary>
        public static string UrlEvents = UrlMain + "/events?archive=true"; // || /events

        /// <summary>
        /// URL раздела "Блог" - https://tages.ru/blog
        /// </summary>
        public static string UrlBlog = UrlMain + "/blog/";

        /// <summary>
        /// URL раздела "Вакансии" - https://tages.ru/vacancies
        /// </summary>
        public static string UrlVacancies = UrlMain + "/vacancies";

        /// <summary>
        /// URL раздела "Контакты" - https://tages.ru/contacts
        /// </summary>
        public static string UrlContacts = UrlMain + "/contacts";

        /// <summary>
        /// Время ожидания загрузки элемента и/или страницы, сек
        /// </summary>
        public static int SecondsToPageLoadWait = 30;

        /// <summary>
        /// Время ожидания дополнительное, сек
        /// </summary>
        public static int SecondsToAdditionalWait = 4;

        /// <summary>
        /// Название процесса приложения для отправки электронной почты (без ".exe")
        /// </summary>
        public static string ProcessEmailName = "HxOutlook";

        /// <summary>
        /// Название процесса приложения для совершения телефонных звонков (без ".exe")
        /// </summary>
        public static string ProcessPhoneName = "Phone";
    }
}
