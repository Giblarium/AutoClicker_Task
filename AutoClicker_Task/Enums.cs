using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AutoClicker_Task
{
    internal class Enums
    {
        internal static string GetInfoAccountStatus()
        {
            StringBuilder stringBuilder = new StringBuilder();
            stringBuilder.AppendLine("0 - Не использовался");
            stringBuilder.AppendLine("1 - В работе");
            stringBuilder.AppendLine("2 - Успешная авторизация");
            stringBuilder.AppendLine("3 - Неправильный логин или пароль");
            stringBuilder.AppendLine("4 - Долгая загрузка сообщения");
            stringBuilder.AppendLine("5 - В текущем месяце уже есть сообщения");
            stringBuilder.AppendLine("6 - Другое");
            return stringBuilder.ToString();
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
        /// <summary>
        /// список браузеров
        /// </summary>
        public enum Browsers
        {
            Console, //"браузер" для инфы, которая поступает из программы
            Edge,
            Chrome,
            Firefox
        }
        /// <summary>
        /// Уровни событий программы
        /// </summary>
        public enum LevelEvent
        {
            Ok,
            Warning,
            Error,
            Info
        }
        /// <summary>
        /// Не используется
        /// </summary>
        public enum BrowserStatus
        {
            Ok,
            BrowserNotFound,
            DriverNotFound,
            BrowserAndDriverNotFound,
            WrongVersion
        }
    }
}
