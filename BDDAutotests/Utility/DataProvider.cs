using BDDAutotests.Entity;

namespace BDDAutotests.Utility
{
    public class DataProvider
    {

        private readonly User user = new User("ivanvasya9681@yandex.ru", "ivanqwerty2");
        private readonly Message message = new Message("denis152324@mail.ru", "denis152324", "messsage to test", "Hello this is a test message.");
        private readonly LetterForm form = new LetterForm("IvanVasya9681", "Перейти в папку «Входящие»", "Войти в почту");

        public User User => user;

        public Message Message => message;

        public LetterForm Form => form;
    }
}
