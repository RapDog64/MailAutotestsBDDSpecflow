using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BDDAutotests.Entity
{
    public class Message
    {
        private string emailAddreass;
        private string addressee;
        private string subjectMessage;
        private string bodyMessage;

        public Message(string emailAddreass, string addressee, string subjectMessage, string bodyMessage)
        {
            this.emailAddreass = emailAddreass;
            this.addressee = addressee;
            this.subjectMessage = subjectMessage;
            this.bodyMessage = bodyMessage;
        }

        public string EmailAddreass { get => emailAddreass; set => emailAddreass = value; }
        public string SubjectMessage { get => subjectMessage; set => subjectMessage = value; }
        public string BodyMessage { get => bodyMessage; set => bodyMessage = value; }
        public string Addressee { get => addressee; set => addressee = value; }
    }
}
