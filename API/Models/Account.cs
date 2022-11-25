namespace API.Models
{
    public class Account
    {
        public string Login { get; set; }
        public string Password { get; set; }
        public AccountStatus Status { get; set; }
        public Account(string login, string password, string status)
        {
            Login = login;
            Password = password;
            int statusInt = 6;
            if (Int32.TryParse(status, out statusInt))
            {
                if (statusInt > -1 && statusInt < 7)
                {
                    Status = (AccountStatus)statusInt;
                }
                else
                {
                    Status = AccountStatus.Other;
                }
            }
        }
        public Account() { }
    }
    /// <summary>
    /// Статусы аккаунта
    /// </summary>
    public enum AccountStatus
    {
        Free,
        InWork,
        Ok,
        WrongPass,
        LongLoadApp,
        AlreadyMessage,
        Other
    }
}