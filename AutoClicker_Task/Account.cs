﻿namespace AutoClicker_Task
{
    internal class Account
    {
        public string Login { get; set; }
        public string Password { get; set; }
        public Enums.AccountStatus Status { get; set; }
        public Account(string login, string password, Enums.AccountStatus status)
        {
            Login = login;
            Password = password;
            Status = status;
        }

        public Account()
        {
        }
    }
}
