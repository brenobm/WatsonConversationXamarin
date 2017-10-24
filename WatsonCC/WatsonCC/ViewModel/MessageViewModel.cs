using System;
using System.Collections.Generic;
using System.Text;

namespace WatsonCC.ViewModel
{
    public class MessageViewModel : BaseViewModel
    {
        private string message;
        private bool fromUser;

        public string Message
        {
            get { return message; }
            set { SetPropery(ref message, value); }
        }

        public bool FromUser
        {
            get { return fromUser; }
            set { SetPropery(ref fromUser, value); }
        }

        public string FromWho
        {
            get
            {
                return fromUser ? "User" : "Watson";
            }
        }

    }
}
