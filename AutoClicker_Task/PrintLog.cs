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
        public static void Print(string message, string login = "", string errorMessage = "", Enums.LevelEvent levelEvent = Enums.LevelEvent.Info, Enums.Browsers browsers = Enums.Browsers.Console)
        {
            //if (printInFile)
            //{
            //    if (!File.Exists(logPath))
            //    {
            //        File.AppendAllText(logPath, "Пользователь;Дата;Результат;Логин;Описание;ТекстОшибки\n");
            //    }
            //    File.AppendAllText(logPath, Environment.UserName.ToString() + ";" + DateTime.Now.ToString() + ";" + levelEvent + ";" + login + ";" + message + ";" + errorMessage + "\n");
            //}
            errorMessage = errorMessage.Replace('\n', ' ');
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
            Console.WriteLine(@"{0, 20} {1, 8} {2, 8} {3, 8} {4} {5}", DateTime.Now.ToString(), levelEvent, login, browsers, message, errorMessage);
            Console.ResetColor();
        }
    }
}
