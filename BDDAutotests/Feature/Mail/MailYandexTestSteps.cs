using BDDAutotests.Entity;
using BDDAutotests.Page;
using BDDAutotests.Settings;
using BDDAutotests.Utility;
using NUnit.Framework;
using TechTalk.SpecFlow;


namespace BDDAutotests.Feature.Login
{
    [Binding]
    public class MailYandexTestSteps : BaseTest
    {

        private DataProvider dataProvider = new DataProvider();

        [Given(@"I open login page")]
        public void GivenIOpenLoginPage()
        {
            new LoginPage().NavigateToLoginForm();
        }

        [Given(@"I log in as a user")]
        public void ThenILogInAsAUser()
        {
            User user = dataProvider.User;
            LetterForm letterForm = dataProvider.Form;

            var nickname = new LoginPage().EnterLogin(user.Login).EnterPassword(user.Password)
                 .ClickSubmit().GetUserNickname();
            Assert.That(nickname, Is.EqualTo(letterForm.Username));
        }

        [When(@"I create a letter")]
        public void ThenICreateALetter()
        {
            Message message = dataProvider.Message;

            var form = new MailProfilePage().PressWriteButton()
                 .WriteToField(message.EmailAddreass)
                 .WriteSubjectField(message.SubjectMessage)
                 .WriteBodyField(message.BodyMessage);
        }

        [When(@"I save the letter as a draft")]
        public void ThenISaveTheLetterAsADraft()
        {
            Message message = dataProvider.Message;

            var addreass = new MailProfilePage().SaveMessageAsDraft().VerifyMessageInDraftFolder();
            Assert.That(addreass, Is.EqualTo(message.EmailAddreass));
        }

        [When(@"I open the draft folder")]
        public void ThenIOpenTheDraftFolder()
        {
            Message message = dataProvider.Message;

            var isAddressee = new MailProfilePage().ClickOnMessageInDraftFolder()
                 .VerifyMessageInToField(message.Addressee);
            Assert.True(isAddressee);

            var isSubjectText = new MailProfilePage()
                .VerifyMessageInSubjectField(message.SubjectMessage);
            Assert.True(isSubjectText);

            var bodyText = new MailProfilePage()
                .VerifyMessageInBodyField();
            Assert.That(bodyText, Is.EqualTo(message.BodyMessage));
        }

        [When(@"I send the letter")]
        public void ThenISendTheLetter()
        {
            LetterForm letterForm = dataProvider.Form;

            var emptyDraftFolder = new MailProfilePage().SendTheMessage()
                .VerifyTheMessageWasDisapeared();
            Assert.That(emptyDraftFolder, Is.EqualTo(letterForm.NoMessagesFolder));
        }

        [Then(@"The letter has been displayed in the sent folder")]
        public void ThenTheLetterHasBeenDisplayedInTheSentFolder()
        {
            User user = dataProvider.User;

            var isPresentMessage = new MailProfilePage().GoToSentMessagesFolder()
                 .DragAndDropLetter().GoToSpamFolder()
                 .CheckMessageInSpamFolder(user.Login);
            Assert.True(isPresentMessage) ;
        }

        [When(@"I log out")]
        public void WhenILogOut()
        {
            new MailProfilePage()
                  .ClickOnUserProfileField()
                  .LogOff();
        }

        [Then(@"I see the Enter to the mail button")]
        public void ThenISeeTheEnterToTheMailButton()
        {
            LetterForm letterForm = dataProvider.Form;

            var actualMessagee = new LoginPage().GetButtonMessage();
            Assert.True(actualMessagee.Contains(letterForm.Username));
        }
    }
}
