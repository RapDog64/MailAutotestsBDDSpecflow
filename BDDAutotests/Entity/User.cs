/// <summary>
/// 
/// The entity class describes a user.
/// 
/// </summary>
namespace BDDAutotests.Entity
{
    public class User
    {
        private string login;
        private string password;

        public User(string login, string password)
        {
            this.Login = login;
            this.Password = password;
        }

        public string Login { get => login; set => login = value; }

        public string Password { get => password; set => password = value; }
    }
}
