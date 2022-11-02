using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AutoClicker_Task
{
    internal static class PrintLog
    {
        static string logPath = "log.txt";
        public static void Print(string message, string login = "", string errorMessage = "", Enums.LevelEvent levelEvent = Enums.LevelEvent.Info, Enums.Browsers browsers = Enums.Browsers.Console, bool printInFile = true)
        {
            if (printInFile)
            {
                //Запись в файл лога
                FileWork.WriteLog(message, login, errorMessage, levelEvent, browsers);
            }
            //удаление переноса сток из e.Message
            errorMessage = errorMessage.Replace('\n', ' ');
            //красивости
            switch (levelEvent)
            {
                case Enums.LevelEvent.Ok:
                    Console.ForegroundColor = ConsoleColor.Green;
                    break;
                case Enums.LevelEvent.Warning:
                    Console.ForegroundColor = ConsoleColor.DarkYellow;
                    break;
                case Enums.LevelEvent.Info:
                    Console.ForegroundColor = ConsoleColor.DarkCyan;
                    break;
                case Enums.LevelEvent.Error:
                    Console.ForegroundColor = ConsoleColor.Red;
                    break;
                default:
                    break;
            }
            //вывод консоли
            Console.WriteLine(@"{0, 20} {1, -8} {2, -8} {3, -8} {4} {5}", DateTime.Now.ToString(), levelEvent, login, browsers, message, errorMessage);
            Console.ResetColor();
        }
    }
}
