using BDDAutotests.Entity;

namespace BDDAutotests.Utility
{
    public class DataProvider
    {

        private readonly User user = new User("", "");
        private readonly Message message = new Message("", "", "messsage to test", "Hello this is a test message.");
        private readonly LetterForm form = new LetterForm("", "Перейти в папку «Входящие»", "Войти в почту");

        public User User => user;

        public Message Message => message;

        public LetterForm Form => form;
    }
}
