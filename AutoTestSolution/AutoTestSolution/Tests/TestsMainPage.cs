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
        /// ���� 1 - ��������� �������������� ���� ������ � ��������
        /// </summary>
        [Test]
        public void Case_1_ClickableAllLinks()
        {
            PageMain pageMain = new PageMain();

            // 1) ��������� �������������� ������ "� ��������"
            pageMain.BtnAboutCompany.Click();
            string message = "������� URL - '" + WebDriver.Url + "'. ��������� URL - '" + Settings.UrlAboutCompany + "'.";
            Assert.AreEqual(WebDriver.Url, Settings.UrlAboutCompany, message);

            // 2) ��������� �������������� ������ "��������"
            pageMain.BtnAcademy.Click();
            message = "������� URL - '" + WebDriver.Url + "'. ��������� URL - '" + Settings.UrlAcademy + "'.";
            Assert.AreEqual(WebDriver.Url, Settings.UrlAcademy, message);

            // 3) ��������� �������������� ������ "�����������"
            pageMain.BtnEvents.Click();
            message = "������� URL - '" + WebDriver.Url + "'. ��������� URL - '" + Settings.UrlEvents + "'.";
            Assert.IsTrue(WebDriver.Url == Settings.UrlEvents || WebDriver.Url == Settings.UrlEvents + "/?archive=true", message);
 
            // 4) ��������� �������������� ������ "����" 
            pageMain.BtnBlog.Click();
            message = "������� URL - '" + WebDriver.Url + "'. ��������� URL - '" + Settings.UrlBlog + "'.";
            Assert.AreEqual(WebDriver.Url, Settings.UrlBlog, message);

            //TODO: �� �������� ������� �� �������� ����
            // 5) ��������� �������������� ������ "��������"
            pageMain.BtnVacanciesFromBlog.Click();
            message = "������� URL - '" + WebDriver.Url + "'. ��������� URL - '" + Settings.UrlVacancies + "'.";
            Assert.AreEqual(WebDriver.Url, Settings.UrlVacancies, message);

            // 6) ��������� �������������� ������ "��������"
            pageMain.BtnContacts.Click();
            message = "������� URL - '" + WebDriver.Url + "'. ��������� URL - '" + Settings.UrlContacts + "'.";
            Assert.AreEqual(WebDriver.Url, Settings.UrlContacts, message);

            // 7) ��������� �������������� �������� � ����� ������� ����
            pageMain.BtnLogo.Click();
            message = "������� URL - '" + WebDriver.Url + "'. ��������� URL - '" + Settings.UrlMain + "'.";
            Assert.IsTrue(WebDriver.Url == Settings.UrlMain || WebDriver.Url == Settings.UrlMain + "/", message);

            WebDriver.Close();
        }

        /// <summary>
        /// ���� 2 - ��������� ������ email � tel
        /// </summary>
        [Test]
        public void Case_2_EmailAndTel()
        {
            PageMain pageMain = new PageMain();

            // 1) ��������� ����� email
            string message = "������� '" + Settings.ProcessEmailName + "' �� ������";
            Assert.IsFalse(Utilites.GetProcessesNames().Contains(Settings.ProcessEmailName), message);
            pageMain.LinkEmail_Contacts_Bottom.Click();
            Utilites.DoAdditionalWait();
            Process processEmail = Utilites.GetProcessByName(Settings.ProcessEmailName);
            processEmail.Kill();

            // 2) ��������� ����� tel
            message = "������� '" + Settings.ProcessPhoneName + "' �� ������";
            Assert.IsFalse(Utilites.GetProcessesNames().Contains(Settings.ProcessPhoneName), message);
            pageMain.LinkTel_Contacts_Bottom.Click();
            Utilites.DoAdditionalWait();
            Process processPhone = Utilites.GetProcessByName(Settings.ProcessPhoneName);
            processPhone.Kill();
            WebDriver.Close();
        }

        /// <summary>
        /// ���� 3 � 4 - ��������� ��������� ����� �������� �����
        /// </summary>
        [Test]
        public void Case_3_4_FormFeedbackValidationCheck_TestFeedbackRequestSend()
        {
            PageMain pageMain = new PageMain();

            // [ ���� 3 ]
            // �������� �������������� ������������ �����
            pageMain.BtnSend_FormFeedback.Click();
            string message = "���� '���' �� �������� ��� �� ��������� ���������";
            Assert.IsTrue(pageMain.FieldName_FormFeedback.GetAttribute("class").Contains(pageMain.ClassError_Fields_FormFeedback), message);
            message = "���� '�������' �� �������� ��� �� ��������� ���������";
            Assert.IsTrue(pageMain.FieldPhone_FormFeedback.GetAttribute("class").Contains(pageMain.ClassError_Fields_FormFeedback), message);
            message = "���� '�����' �� �������� ��� �� ��������� ���������";
            Assert.IsTrue(pageMain.FieldEmail_FormFeedback.GetAttribute("class").Contains(pageMain.ClassError_Fields_FormFeedback), message);

            // �������� ���� "���*". � ��������� ������ ���������: ��� ����� �������, ������� �����������, ����� � �������.
            pageMain.FieldName_FormFeedback.Click();
            pageMain.FieldName_FormFeedback.SendKeys("�");
            pageMain.BtnSend_FormFeedback.Click();
            message = "���� '���' �� �������� ��� �� ��������� ���������";
            Assert.IsTrue(pageMain.FieldName_FormFeedback.GetAttribute("class").Contains(pageMain.ClassError_Fields_FormFeedback), message);

            pageMain.FieldName_FormFeedback.SendKeys("�");
            pageMain.BtnSend_FormFeedback.Click();
            Assert.IsFalse(pageMain.FieldName_FormFeedback.GetAttribute("class").Contains(pageMain.ClassError_Fields_FormFeedback), message);

            // �������� ���� "�������*". � ��������� ������ ���������: 10 ����. � ���������� �������� ����� � ������� 123 456 78 90.
            pageMain.FieldPhone_FormFeedback.Click();
            pageMain.FieldPhone_FormFeedback.SendKeys("�");
            pageMain.BtnSend_FormFeedback.Click();
            message = "���� '�������' �� �������� ��� �� ��������� ���������";
            Assert.IsTrue(pageMain.FieldPhone_FormFeedback.GetAttribute("class").Contains(pageMain.ClassError_Fields_FormFeedback), message);

            pageMain.FieldPhone_FormFeedback.SendKeys("1234567890");
            pageMain.BtnSend_FormFeedback.Click();
            Assert.IsFalse(pageMain.FieldPhone_FormFeedback.GetAttribute("class").Contains(pageMain.ClassError_Fields_FormFeedback), message);

            pageMain.FieldPhone_FormFeedback.SendKeys("f");
            pageMain.BtnSend_FormFeedback.Click();
            Assert.IsFalse(pageMain.FieldPhone_FormFeedback.GetAttribute("class").Contains(pageMain.ClassError_Fields_FormFeedback), message);

            // � ���� "��������" ��� ������ ���������.

            // �������� ���� "�����". � ��������� ������ ���������: ��������� ����� � ����� + @ + ��������� ����� � ����� + .ru. � ���������� �������� email ����� � ������� example@domain.ru
            pageMain.FieldEmail_FormFeedback.Click();
            pageMain.FieldEmail_FormFeedback.SendKeys("e");
            pageMain.BtnSend_FormFeedback.Click();
            message = "���� '�����' �� �������� ��� �� ��������� ���������";
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
            message = "���� '�����' �������� ��� �� ��������� ���������";
            Assert.IsFalse(pageMain.FieldEmail_FormFeedback.GetAttribute("class").Contains(pageMain.ClassError_Fields_FormFeedback), message);

            // [ ���� 4 ]
            // ��������� �������� ������ �������� �����
            Utilites.DoAdditionalWait();
            message = "������ '���� ��������� ��������' �� �����";
            Assert.IsTrue(pageMain.IconSuccess_FormFeedback.Displayed, message);
        }
    }
}