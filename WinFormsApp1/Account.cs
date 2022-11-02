using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WinFormsApp1
{
    internal class Account
    {
        public string Name { get; set; }
        public string Password { get; set; }
        public StatusAccount StatusAccount { get; set; }
        public Program.Browser Browser { get; set; }

        public Account(string name, string password)
        {
            Name = name;
            Password = password;
            StatusAccount = StatusAccount.NotAuthorizedYet;
        }
    }
    [Flags]
    enum StatusAccount
    {
        OK,
        NotAuthorizedYet,
        InWork,
        WrongPass,
        AlreadyHaveMessages,
        NotFoundLineSupport
    }

}
