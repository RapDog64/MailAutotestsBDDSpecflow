using BDDAutotests.Settings;
using log4net;
using OpenQA.Selenium;
using OpenQA.Selenium.Interactions;
using System;

namespace BDDAutotests.Page
{
    public class MailProfilePage : BasePage
    {
        private By userNickname = By.XPath("//span[@class='user-account__name']");
        private By addressee = By.XPath("//span[@title='denis152324@mail.ru']");
        private By MessageInSpamFolder = By.XPath("//span[@title='ivanvasya9681@yandex.ru']");
        private By createAletter = By.CssSelector(".mail-ComposeButton-Text");
        private By toField = By.XPath("//div[@name='to']");
        private By subjectField = By.XPath("//input[@name='subj-c52f3063fbb78ed2f426ccc1242311c34b0516fe']");
        private By bodyField = By.XPath("//div[@role='textbox']");
        private By goToDraftFolderButton = By.XPath("//span[contains(text(),'Черновики')]");
        private By goToSpamFolderButton = By.XPath("//span[contains(text(), 'Спам')]");
        private By sendButton = By.XPath("//span[contains(text(), 'Отправить')]");
        private By goToSentFolder = By.XPath("//span[contains(text(), 'Отправленные')]");
        private By emptyDraftMessage = By.CssSelector(".b-messages__placeholder-item__link");
        private By logoutButton = By.XPath("//span[contains(text(), 'Выйти из сервисов Яндекса')]");
        private By refreshButton = By.XPath("//span[@title='Проверить, есть ли новые письма (F9)']");

        private static readonly ILog logger = LogManager.GetLogger(typeof(MailProfilePage));

        public string GetUserNickname()
        {
            var nickname = "";
           
            try
            {
                IsElementVisible(userNickname);
                nickname = Browser.GetDriver().FindElement(userNickname).Text;
                logger.Debug("Returning user nickname: " + nickname);

            }
            catch (Exception)
            {
                logger.Error("Not found " + nickname);
            }

            return nickname;
        }

        public MailProfilePage PressWriteButton()
        {
            logger.Debug("Pressing Comppose button.");
            base.ClickButton(createAletter);

            return this;
        }

        public MailProfilePage WriteToField(string emailAddreass)
        {
            IsElementVisible(toField);
            Browser.GetDriver().FindElement(toField).Clear();
            Browser.GetDriver().FindElement(toField).Click();

            logger.Debug("Writing email addreass.");
            Browser.GetDriver().FindElement(toField).SendKeys(emailAddreass);
            Browser.GetDriver().FindElement(toField).SendKeys(Keys.Enter);
            logger.Debug("Accepted the suggestion form");

            return this;
        }

        public MailProfilePage WriteSubjectField(string subjectMessage)
        {
            IsElementVisible(subjectField);
            Browser.GetDriver().FindElement(subjectField).Click();
            Browser.GetDriver().FindElement(subjectField).Clear();
            
            logger.Debug("Writing subject message.");
            Browser.GetDriver().FindElement(subjectField).SendKeys(subjectMessage);

            return this;
        }

        public MailProfilePage WriteBodyField(string bodyMessage)
        {
            IsElementVisible(bodyField);
            Browser.GetDriver().FindElement(bodyField).Click();
            Browser.GetDriver().FindElement(bodyField).Clear();

            logger.Debug("Writing body message .");
            Browser.GetDriver().FindElement(bodyField).SendKeys(bodyMessage);

            return this;
        }

        public MailProfilePage SaveMessageAsDraft()
        {
            base.ClickButton(goToDraftFolderButton);
            Browser.GetDriver().SwitchTo().ActiveElement().Click();

            System.Threading.Thread.Sleep(2000);
            base.ClickButton(refreshButton);
            logger.Debug("Saved the message .");

            return this;
        }

        public string VerifyMessageInDraftFolder()
        {
            IsElementVisible(addressee);
            return Browser.GetDriver().FindElement(addressee).GetAttribute("title");
        }

        public MailProfilePage ClickOnMessageInDraftFolder()
        {
            base.ClickButton(addressee);
            return this;
        }

        public bool VerifyMessageInToField(string addressee)
        {
            bool IsAddressee = false;

            try
            {
                IsElementVisible(toField);
                IsAddressee = Browser.GetDriver().FindElement(toField).Text.Contains(addressee);
            }
            catch (Exception)
            {
                logger.Error("Nothing found");
            }

            return IsAddressee;
        }

        public bool VerifyMessageInSubjectField(string subjectMessage)
        {
            bool IsSubjectMessage = false; 

            try 
            {
                IsElementVisible(subjectField);
                IsSubjectMessage = Browser.GetDriver().FindElement(subjectField).GetAttribute("value").Contains(subjectMessage);

            }
            catch(Exception)
            {
                logger.Error("Not found" + IsSubjectMessage);
            }

            return IsSubjectMessage;
        }

        public string VerifyMessageInBodyField()
        {
            string bodyMessage = "";

            try
            {
                IsElementVisible(bodyField);
                bodyMessage = Browser.GetDriver().FindElement(bodyField).Text;
            }
            catch (Exception)
            {
                logger.Error("Not found");
            }

            return bodyMessage;
           
        }

        public MailProfilePage SendTheMessage()
        {
            logger.Debug("Clicking on the send button");
            base.ClickButton(sendButton);
            System.Threading.Thread.Sleep(5000);
            
            return this;
        }

        public string VerifyTheMessageWasDisapeared()
        {
            base.ClickButton(goToDraftFolderButton);
            IsElementVisible(emptyDraftMessage);

            return Browser.GetDriver().FindElement(emptyDraftMessage).Text;
        }

        public MailProfilePage GoToSentMessagesFolder()
        {
            base.ClickButton(goToSentFolder);
            return this;
        }

        public bool CheckMessageInSpamFolder(string newAddressee)
        {
            IsElementVisible(MessageInSpamFolder);
            return Browser.GetDriver().FindElement(MessageInSpamFolder).GetAttribute("title").Contains(newAddressee);
        }


        public MailProfilePage DragAndDropLetter()
        {
            IsElementVisible(addressee);
            IWebElement fromSentFolder = Browser.GetDriver().FindElement(addressee);
            IWebElement toSpamFolder = Browser.GetDriver().FindElement(goToSpamFolderButton);

            Actions builder = new Actions(Browser.GetDriver());
            builder.DragAndDrop(fromSentFolder, toSpamFolder)
                .Build().Perform();

            logger.Debug("The message has been move to the spam folder.");
            return this;
        }

        public MailProfilePage GoToSpamFolder()
        {
            logger.Debug("Go to the spam folder.");
            Browser.GetDriver().FindElement(goToSpamFolderButton).Click();

            return this;
        }

        public MailProfilePage ClickOnUserProfileField()
        {
            logger.Warn("Click on user profile menu.");
            base.ClickButton(userNickname);
            return this;
        }

        public MailProfilePage WaitForDropDownMenu()
        {
            Browser.GetDriver().Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(10);
            return this;
        }

        public LoginPage LogOff()
        {
            IsElementVisible(logoutButton);
            Browser.GetDriver().FindElement(logoutButton).Click();
            logger.Info("Exit from mail.");

            return new LoginPage();
        }
    }
}
