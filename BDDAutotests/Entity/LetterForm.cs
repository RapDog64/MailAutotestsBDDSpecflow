using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BDDAutotests.Entity
{
    public class LetterForm
    {
        private string username;
        private string noMessagesFolder;
        private string enterMessage;

        public LetterForm(string username, string noMessagesFolder, string enterMessage)
        {
            this.Username = username;
            this.NoMessagesFolder = noMessagesFolder;
            this.EnterMessage = enterMessage;
        }

        public string Username { get => username; set => username = value; }
        public string NoMessagesFolder { get => noMessagesFolder; set => noMessagesFolder = value; }
        public string EnterMessage { get => enterMessage; set => enterMessage = value; }
    }
}
