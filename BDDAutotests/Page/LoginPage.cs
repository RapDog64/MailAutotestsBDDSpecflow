using BDDAutotests.Settings;
using log4net;
using OpenQA.Selenium;
using System;

namespace BDDAutotests.Page
{
    public class LoginPage : BasePage
    {
        private const string URL = "https://passport.yandex.ru/auth/welcome?from=mail&origin=hostroot_homer_auth_L_ru&retpath=https%3A%2F%2Fmail.yandex.ru%2F&backpath=https%3A%2F%2Fmail.yandex.ru%3Fnoretpath%3D1";
        private By loginField = By.XPath("//input[@id='passp-field-login']");
        private By passwordField = By.XPath("//input[@id='passp-field-passwd']");
        private By submitButton = By.XPath("//button[@type='submit']");
        private By userLogin = By.CssSelector(".passp-current-account__login");
        private static readonly ILog logger = LogManager.GetLogger(typeof(LoginPage));

        public LoginPage NavigateToLoginForm()
        {
            logger.Debug("naviteting to " + URL);
            Browser.NavigateTo(URL);
            return this;
        }

        public string GetButtonMessage()
        {
            string username="";
            try
            {
                IsElementVisible(userLogin);
                username = Browser.GetDriver().FindElement(userLogin).Text;
                
            }
            catch(Exception)
            {
                logger.Debug("Returning username " + username);
            }
            

            return username;
        }

        public LoginPage EnterLogin(string login)
        {
            base.JSClick(loginField);
            Browser.GetDriver().FindElement(loginField).Clear();

            logger.Debug("typing loigin: " + login);
            Browser.GetDriver().FindElement(loginField).SendKeys(login);

            base.ClickButton(submitButton);
            

            return this;
        }

        public MailProfilePage ClickSubmit()
        {
            logger.Debug("Clicking the submit button");
            base.ClickButton(submitButton);
            logger.Debug("The button has been pressed");

            return new MailProfilePage();
        }

        public LoginPage EnterPassword(string password)
        {
            base.JSClick(passwordField);
            Browser.GetDriver().FindElement(passwordField).Clear();

            logger.Debug("typing loigin: " + password);
            Browser.GetDriver().FindElement(passwordField).SendKeys(password);

            return this;
        }
    }
}
