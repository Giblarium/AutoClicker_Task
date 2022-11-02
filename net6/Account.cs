using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace net6
{
    internal class Account
    {
        public Account(string name, string password, Status status)
        {
            Name = name;
            Password = password;
            Status = status;
        }

        public string Name { get; set; }
        public string Password { get; set; }
        public Status Status { get; set; }

        static List<Account> GetData(string path)
        {
            List<Account> accounts = new List<Account>();


            return accounts;
        }
    }
    public enum Status
    {
        OK,
        WrongPass,
        BadConnection,
        HaveMessage,
        NoService,
        LongLoadApp,
        InWork
    }
}
