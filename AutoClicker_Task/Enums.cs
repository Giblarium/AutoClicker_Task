using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AutoClicker_Task
{
    internal class Enums
    {
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
        public enum Browsers
        {
            Console,
            Edge,
            Chrome,
            Firefox
        }
        public enum LevelEvent
        {
            Ok,
            Warning,
            Error,
            Info
        }
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
