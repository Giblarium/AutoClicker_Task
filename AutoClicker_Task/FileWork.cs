using Newtonsoft.Json;
using static AutoClicker_Task.Enums;
using Excel = Microsoft.Office.Interop.Excel;


namespace AutoClicker_Task
{
    internal static class FileWork
    {
        static string pathLog = "log.txt";
        static string pathDataFile = "Data.json";
        static string pathBadDataFile = "BadData.json";
        /// <summary>
        /// Чтение книги с паролями
        /// </summary>
        /// <param name="path">Путь к книге Excel</param>
        /// <returns>Возвращает список аккаунтов</returns>
        public static List<Account> ReadExcelBook(string path)
        {
            Excel.Application ObjWorkExcel = new Excel.Application(); //открыть эксель
            Excel.Workbook ObjWorkBook;
            Excel.Worksheet ObjWorkSheet;
            PrintLog.Print($"Открытие книги " + path, "", "", LevelEvent.Info);
            List<Account> loginList = new List<Account>();
            try
            {
                ObjWorkBook = ObjWorkExcel.Workbooks.Open(path, Type.Missing, Type.Missing, Type.Missing, Type.Missing, Type.Missing, Type.Missing, Type.Missing, Type.Missing, Type.Missing, Type.Missing, Type.Missing, Type.Missing, Type.Missing, Type.Missing); //открыть файл
                ObjWorkSheet = (Excel.Worksheet)ObjWorkBook.Sheets[1];
                var lastCell = ObjWorkSheet.Cells.SpecialCells(Excel.XlCellType.xlCellTypeLastCell);
                PrintLog.Print($"Книга открыта.", "", "", LevelEvent.Info);
                for (int i = 0; i < lastCell.Row; i++)
                {
                    string login = ObjWorkSheet.Cells[i + 1, 1].Text.ToString();
                    string pass = ObjWorkSheet.Cells[i + 1, 2].Text.ToString();
                    loginList.Add(new Account(login, pass, AccountStatus.Free));
                }

                ObjWorkBook.Close(false, Type.Missing, Type.Missing); //закрыть не сохраняя

                WriteDataFile(loginList);
                PrintLog.Print($"Получено {loginList.Count} аккаунтов из книги {path}", "", "", LevelEvent.Info);
            }
            catch (Exception e)
            {
                PrintLog.Print("Ошибка открытия файла", "", e.Message, LevelEvent.Error);
                return new List<Account>();
            }
            finally
            {
                ObjWorkExcel.Quit(); // выйти из экселя
                GC.Collect(); // убрать за собой
            }
            return loginList;
        }
        /// <summary>
        /// Запись Data.json
        /// </summary>
        /// <param name="data">Список аккаунтов</param>
        public static void WriteDataFile(List<Account> data)
        {
            string _accounts = JsonConvert.SerializeObject(data);
            while (true)
            {
                try
                {
                    File.WriteAllText(pathDataFile, _accounts);
                    break;
                }
                catch (Exception)
                {
                    Thread.Sleep(500);
                }
            }
        }
        /// <summary>
        /// Чтение Data.json
        /// </summary>
        /// <returns>Возвращает список аккаунтов</returns>
        public static List<Account> ReadDataFile()
        {
            string _accounts = File.ReadAllText(pathDataFile);
            List<Account> accounts = JsonConvert.DeserializeObject<List<Account>>(_accounts);
            return accounts;
        }
        /// <summary>
        /// Запись аккаунтов, по которым не удалось отправить сообщение
        /// </summary>
        /// <param name="account">Аккаунт</param>
        /// <param name="status">Статус ошибки</param>
        internal static void WriteBadData(Account account, AccountStatus status)
        {
            List<Account> accounts = new List<Account>();
            if (File.Exists(pathBadDataFile))
            {
                string _baddata = File.ReadAllText(pathBadDataFile);
                accounts = JsonConvert.DeserializeObject<List<Account>>(_baddata);
                accounts.Add(new Account(account.Login, account.Password, status));
                _baddata = JsonConvert.SerializeObject(accounts);
                File.WriteAllText(pathBadDataFile, _baddata);
            }
            else
            {
                accounts.Add(new Account(account.Login, account.Password, status));
                string _baddata = JsonConvert.SerializeObject(accounts);
                File.WriteAllText(pathBadDataFile, _baddata);
            }
            
        }
        /// <summary>
        /// Запись лога в файл
        /// </summary>
        public static void WriteLog(string message, string login = "", string errorMessage = "", Enums.LevelEvent levelEvent = Enums.LevelEvent.Info, Enums.Browsers browsers = Enums.Browsers.Console, bool printInFile = true)
        {
            if (!File.Exists(pathLog))
            {
                //в новом файле добавить заголовки
                File.AppendAllText(pathLog, "Пользователь;Дата;Результат;Логин;Описание;ТекстОшибки\n");
            }
            while (true)
            {
                //т.к. в файл пишут 3 потока ждем 500 мс после неудачной попытке.
                try
                {
                    File.AppendAllText(pathLog, Environment.UserName.ToString() + ";" + DateTime.Now.ToString() + ";" + levelEvent + ";" + login + ";" + message + ";" + errorMessage + "\n");
                    break;
                }
                catch (Exception)
                {
                    Thread.Sleep(500);
                }
            }
        }
        public static void WriteInfo()
        {
            string info = Enums.GetInfoAccountStatus();
            File.WriteAllText("readme.txt", info);
        }
    }
}
