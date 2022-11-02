using System;
using System.Collections.Generic;
using System.IO;
using System.Threading;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using Excel = Microsoft.Office.Interop.Excel;
using Newtonsoft.Json;
using static System.Net.Mime.MediaTypeNames;
using System.Reflection;
using System.Diagnostics;
using static AutoClicker.Program;
using OpenQA.Selenium.DevTools.V85.Browser;
using OpenQA.Selenium.Firefox;
using OpenQA.Selenium.Edge;

namespace AutoClicker
{
    internal class Program
    {
        static string logPath = "log.txt";
        static string dataPath = "data.json";
        static string badDataPath = "baddata.json";
        static string settingsPath = "settings.json";
        static Settings settings;
        public class LogPrint
        {
            private Success isSuccess = Success.Info;
            private string errorMessage;

            private string description;
            private string login;

            public LogPrint()
            {
            }

            public void Paste (string description, Success isSuccess, string errorMessage = "", string login = "")
            {
                IsSuccess = isSuccess;
                ErrorMessage = errorMessage;
                Description = description;
                Login = login;
            }

            public Success IsSuccess { get => isSuccess; set => isSuccess = value; }
            public string ErrorMessage { get => errorMessage; set => errorMessage = value; }
            public string Description { get => description; set => description = value; }
            public string Login { get => login; set => login = value; }
        }
        public enum Success
        {
            OK,
            Warning,
            Info,
            Error
        }
        public enum Status
        {
            OK,
            WrongPass,
            BadConnection,
            HaveMessage,
            NoService,
            LongLoadApp
        }
        public class LoginData
        {
            public LoginData(string login, string pass, Status status = Status.OK)
            {
                Login = login;
                Pass = pass;
                StatusLogin = status;
            }


            public string Login { get; set; }
            public string Pass { get; set; }
            public Status StatusLogin { get; set; }
        }
        public class Settings
        {
            private int loadAppPause = 4000;
            private int loginPause = 5000;
            private int openMenuPause = 1000;
            private int openServicePause = 4000;
            private int loadServicePause = 4000;
            private int sendMessagePause = 200;
            private int waitTreatmentPause = 8500;
            private int exitPause = 500;
            private int closePause = 1000;
            private bool sendMessage = true;
            private bool authOnly = false;
            private string currentMonth;
            private bool deleteData = false;

            public int LoadAppPause { get => loadAppPause; set => loadAppPause = value; }
            public int LoginPause { get => loginPause; set => loginPause = value; }
            public int OpenMenuPause { get => openMenuPause; set => openMenuPause = value; }
            public int OpenServicePause { get => openServicePause; set => openServicePause = value; }
            public int LoadServicePause { get => loadServicePause; set => loadServicePause = value; }
            public int SendMessagePause { get => sendMessagePause; set => sendMessagePause = value; }
            public int ClosePause { get => closePause; set => closePause = value; }
            public int ExitPause { get => exitPause; set => exitPause = value; }
            public int WaitTreatmentPause { get => waitTreatmentPause; set => waitTreatmentPause = value; }
            public bool SendMessage { get => sendMessage; set => sendMessage = value; }
            public bool AuthOnly { get => authOnly; set => authOnly = value; }
            public string CurrentMonth { get => currentMonth; set => currentMonth = value; }
            public bool DeleteData { get => deleteData; set => deleteData = value; }

        }
        static LogPrint logPrint = new LogPrint();
        static List<LoginData> loginList = new List<LoginData>();

        static void Main(string[] args)
        {
            

            if (!File.Exists(logPath))
            {
                File.AppendAllText(logPath, "Пользователь;Дата;Результат;Логин;Описание;ТекстОшибки\n");
            }
            logPrint.Paste("Версия программы: " + Assembly.GetExecutingAssembly().GetName().Version.ToString(), Success.Info);
            PrintLog(logPrint);
            settings = new Settings();

            //загрузка настроек
            if (File.Exists(settingsPath))
            {
                string settingStr = File.ReadAllText(settingsPath);
                settings = JsonConvert.DeserializeObject<Settings>(settingStr);
                //settings.CurrentMonth = GetMonthYear();
                logPrint.Paste("Настройки загружены!", Success.Info);
                PrintLog(logPrint);
            }
            else
            {
                settings.CurrentMonth = GetMonthYear();
                string settingStr = JsonConvert.SerializeObject(settings);
                File.WriteAllText(settingsPath, settingStr);
                logPrint.Paste("Настройки сохранены!", Success.Info);
                PrintLog(logPrint);
            }

            if (File.Exists("chromedriver.exe"))
            {
                logPrint.Paste("ChromeDriver найден!", Success.Info);
                PrintLog(logPrint);
            }
            else
            {
                logPrint.Paste("ChromeDriver не найден! Скачайте по ссылке http://chromedriver.storage.googleapis.com/index.html", Success.Error);
                PrintLog(logPrint);
            }



            logPrint.Paste($"Поиск сообщений от {settings.CurrentMonth}", Success.Warning);
            PrintLog(logPrint);


            //если в параметре есть путь к файлу книги
            if (args.Length > 0)
            {
                if (settings.DeleteData)
                {
                    File.Delete(dataPath);
                }
                if (File.Exists(dataPath))
                {
                    logPrint.Paste("Файл данных существует! Удалите его перед созданием нового.", Success.Error);
                    PrintLog(logPrint);
                    Console.ReadLine();
                    return;
                }
                Excel.Application ObjWorkExcel = new Excel.Application(); //открыть эксель
                Excel.Workbook ObjWorkBook;
                Excel.Worksheet ObjWorkSheet;
                logPrint.Paste($"Открытие книги " + args[0], Success.Info);
                PrintLog(logPrint);
                try
                {

                    ObjWorkBook = ObjWorkExcel.Workbooks.Open(args[0], Type.Missing, Type.Missing, Type.Missing, Type.Missing, Type.Missing, Type.Missing, Type.Missing, Type.Missing, Type.Missing, Type.Missing, Type.Missing, Type.Missing, Type.Missing, Type.Missing); //открыть файл
                    ObjWorkSheet = (Excel.Worksheet)ObjWorkBook.Sheets[1];
                    var lastCell = ObjWorkSheet.Cells.SpecialCells(Excel.XlCellType.xlCellTypeLastCell);
                    logPrint.Paste($"Книга открыта.", Success.Info);
                    PrintLog(logPrint);
                    for (int i = 0; i < lastCell.Row; i++)
                    {
                        string login = ObjWorkSheet.Cells[i + 1, 1].Text.ToString();
                        string pass = ObjWorkSheet.Cells[i + 1, 2].Text.ToString();
                        loginList.Add(new LoginData(login, pass));
                    }

                    ObjWorkBook.Close(false, Type.Missing, Type.Missing); //закрыть не сохраняя

                    SaveLoginData(loginList, dataPath);
                    logPrint.Paste($"Получено {loginList.Count} аккаунтов из книги {args[0]}", Success.Info);
                    PrintLog(logPrint);
                }
                catch (Exception e)
                {
                    logPrint.Paste("Ошибка открытия файла", Success.Error, e.Message, "");
                    PrintLog(logPrint);
                    return;
                }
                finally
                {
                    ObjWorkExcel.Quit(); // выйти из экселя
                    GC.Collect(); // убрать за собой
                }

            }

            //чтение из файла, если не указана книга
            if (loginList.Count == 0)
            {
                if (File.Exists(dataPath))
                {
                    foreach (string line in File.ReadLines(dataPath))
                    {
                        LoginData temp = JsonConvert.DeserializeObject<LoginData>(line);
                        loginList.Add(temp);
                    }
                    logPrint.Paste($"Получено {loginList.Count} аккаунтов из файла", Success.Info);
                    PrintLog(logPrint);
                }
                else
                {
                    logPrint.Paste($"Файл данных {dataPath} не найден! Перетащите книгу Excel на exe программы.", Success.Error);
                    PrintLog(logPrint);
                }
            }
            IWebDriver driverChrome;
            IWebDriver driverFirefox;
            IWebDriver driverEdge;

            //перебор списка логинов и паролей
            for (int i = 0; i < loginList.Count; i++)
            {
                driverChrome = new ChromeDriver();
                BrowserDrive(driverChrome);
                driverFirefox = new FirefoxDriver();
                BrowserDrive(driverFirefox);
                driverEdge = new EdgeDriver();
                BrowserDrive(driverEdge);
            }




            //конец программы
            logPrint.Paste($"Программа завершена!", Success.OK);
            PrintLog(logPrint);
            Console.ReadLine();
        }

        private static string GetChromeVersion()
        {
            string[] allFolder = Directory.GetDirectories(@"C:\Program Files\Google\Chrome\Application");
            for (int j = 0; j < allFolder.Length; j++)
            {
                int index = 0;
                for (int i = allFolder[j].Length - 1; i >= 0; i--)
                {
                    if (allFolder[j][i] == '\\')
                    {
                        index = i;
                        break;
                    }
                }
                allFolder[j] = allFolder[j].Substring(index + 1, allFolder[j].Length - index - 1);
            }
            return allFolder[0];
        }

        private static string GetMonthYear()
        {
            DateTime dateTime = DateTime.Now;
            string monthYear = dateTime.ToString("Y");
            if (Environment.Is64BitOperatingSystem)
            {
                monthYear = monthYear.Substring(0, monthYear.Length - 3);
            }
            monthYear = monthYear.Substring(0, 1).ToUpper() + monthYear.Substring(1);
            return monthYear;
        }

        private static void SaveBadLogin(LoginData badLogin, Status status)
        {
            badLogin.StatusLogin = status;
            string badLoginStr = JsonConvert.SerializeObject(badLogin);
            File.AppendAllText(badDataPath, badLoginStr + "\n");
        }

        private static void DeleteLogin(List<LoginData> loginData)
        {
            loginData.RemoveAt(0);
            SaveLoginData(loginData, dataPath);
        }

        private static void SaveLoginData(List<LoginData> loginData, string file)
        {
            if (File.Exists(file))
            {
                File.Delete(file);
            }
            foreach (var item in loginData)
            {
                string foo = JsonConvert.SerializeObject(item);
                File.AppendAllText(file, foo + "\n");
            }

        }

        private static void PrintLog(LogPrint logPrint, bool PrintInFile = true)
        {
            logPrint.ErrorMessage = logPrint.ErrorMessage.Replace('\n', ' ');
            if (PrintInFile)
            {
                File.AppendAllText(logPath, Environment.UserName.ToString() + ";" + DateTime.Now.ToString() + ";" + logPrint.IsSuccess + ";" + logPrint.Login + ";" + logPrint.Description + ";" + logPrint.ErrorMessage + "\n");
            }

            switch (logPrint.IsSuccess)
            {
                case Success.OK:
                    Console.ForegroundColor = ConsoleColor.Green;
                    break;
                case Success.Warning:
                    Console.ForegroundColor = ConsoleColor.DarkYellow;
                    break;
                case Success.Info:
                    Console.ForegroundColor = ConsoleColor.DarkCyan;
                    break;
                case Success.Error:
                    Console.ForegroundColor = ConsoleColor.Red;
                    break;
                default:
                    break;
            }
            Console.WriteLine(DateTime.Now.ToString() + " " + logPrint.IsSuccess + " " + logPrint.Login + " " + logPrint.Description + " " + logPrint.ErrorMessage);
            Console.ResetColor();
        }
        public static void BrowserDrive(IWebDriver driver)
        {
            logPrint.Paste($"Осталось аккаунтов: {loginList.Count} ", Success.Warning);
            PrintLog(logPrint, false);
            //создание нового окна
            driver.Url = "http://web.1c-connect.com";

            try
            {
                //ожидание загрузки приложения
                Thread.Sleep(settings.LoadAppPause);
                IWebElement loginTextBox = driver.FindElement(By.XPath("/html/body/div/div[1]/div/div/div[2]/div/form/input[1]"));
                IWebElement passTextBox = driver.FindElement(By.XPath("/html/body/div/div[1]/div/div/div[2]/div/form/input[2]"));
                IWebElement submitTextBox = driver.FindElement(By.XPath("/html/body/div/div[1]/div/div/div[2]/div/form/input[3]"));

                //заполнение логина и пароля
                loginTextBox.SendKeys(loginList[0].Login);
                passTextBox.SendKeys(loginList[0].Pass);
                submitTextBox.Click();
            }
            catch (Exception e)
            {
                logPrint.Paste($"Web-приложение не загрузилось!", Success.Error, e.Message, loginList[0].Login);
                PrintLog(logPrint);
                SaveBadLogin(loginList[0], Status.LongLoadApp);
                DeleteLogin(loginList);
                driver.Close();
                driver.Dispose();
                return;
            }

            //попытка открытия бокового меню
            bool openMenu = false;
            for (int i = 0; i < 3; i++)
            {
                Thread.Sleep(settings.LoginPause);
                try
                {
                    IWebElement menu = driver.FindElement(By.XPath("/html/body/div/div[1]/div[2]/div[1]/button"));
                    menu.Click();
                    logPrint.Paste($"Авторизация успешна!", Success.OK, "", loginList[0].Login);
                    PrintLog(logPrint);
                    openMenu = true;
                    break;
                }
                catch (Exception e)
                {
                    logPrint.Paste($"Авторизация {i + 1} не удалась!", Success.Error, e.Message, loginList[0].Login);
                    PrintLog(logPrint);
                    try
                    {
                        IWebElement authErr = driver.FindElement(By.XPath("//*[contains(text(), 'Ошибка авторизации')]"));
                        if (authErr.Text == "Ошибка авторизации")
                        {
                            logPrint.Paste($"Авторизация не удалась! Неверный логин/пароль", Success.Error, "", loginList[0].Login);
                            PrintLog(logPrint);
                            SaveBadLogin(loginList[0], Status.WrongPass);
                            DeleteLogin(loginList);
                            driver.Close();
                            break;
                        }
                        if (authErr.Text == "Сбой авторизации")
                        {
                            logPrint.Paste($"Авторизация не удалась! Ошибка соединения", Success.Error, "", loginList[0].Login);
                            SaveBadLogin(loginList[0], Status.BadConnection);
                            DeleteLogin(loginList);
                            driver.Close();
                            PrintLog(logPrint);
                            break;
                        }
                    }
                    catch (Exception)
                    {
                        continue;
                    }

                }
            }

            //если меню не удалось открыть, то сл
            if (!openMenu)
            {
                return;
            }

            //если нужны только авторизации
            if (settings.AuthOnly)
            {
                logPrint.Paste($"Включен режим \"Только авторизация\"", Success.Warning, "", loginList[0].Login);
                DeleteLogin(loginList);
                driver.Close();
                PrintLog(logPrint);
                return;
            }

            //открытие списка линий поддержки
            Thread.Sleep(settings.OpenMenuPause);
            IWebElement services = driver.FindElement(By.XPath("/html/body/div/div[6]/ul[2]/li[2]"));
            services.Click();

            //попытка открыть линию поддержки Первый Бит Воронеж Центральный офис
            try
            {
                Thread.Sleep(settings.OpenServicePause);
                IWebElement service = driver.FindElement(By.XPath("//*[contains(text(), 'Первый Бит Воронеж Центральный офис')]"));
                service.Click();
                logPrint.Paste($"Открыта линия поддержки! \"Первый Бит Воронеж Центральный офис\"", Success.OK, "", loginList[0].Login);
                PrintLog(logPrint);
            }
            catch (Exception e)
            {
                // если не удалось, поиск ЛП Первый Бит Воронеж Северный
                try
                {
                    IWebElement service = driver.FindElement(By.XPath("//*[contains(text(), 'Первый БИТ: Поддержка клиентов 1С 24\\7')]"));
                    service.Click();
                    logPrint.Paste($"Открыта линия поддержки! \"Первый БИТ: Поддержка клиентов 1С 24\\7\"", Success.OK, "", loginList[0].Login);
                    PrintLog(logPrint);
                }
                catch (Exception ex)
                {
                    // если не удалось
                    logPrint.Paste($"Не удалось найти линии поддержки!", Success.Error, ex.Message + " " + e.Message, loginList[0].Login);
                    PrintLog(logPrint);
                    SaveBadLogin(loginList[0], Status.NoService);
                    DeleteLogin(loginList);
                    driver.Close();
                    return;
                }
            }

            Thread.Sleep(settings.LoadServicePause);
            //поиск предыдущих сообщений
            try
            {
                IWebElement previousMessage = driver.FindElement(By.XPath($"//*[contains(text(), '{settings.CurrentMonth}')]"));
                logPrint.Paste($"В {settings.CurrentMonth} уже есть обращения!", Success.Error, "", loginList[0].Login);
                PrintLog(logPrint);
                SaveBadLogin(loginList[0], Status.HaveMessage);
                DeleteLogin(loginList);
                driver.Close();
                return;
            }
            catch (Exception)
            {
                //если сообщение не найдено, то ничего не делать
            }

            //написание сообщения
            IWebElement textMessage = driver.FindElement(By.XPath("/html/body/div/div[2]/div[1]/div[2]/div/div/textarea"));
            textMessage.SendKeys("тест");

            //отправка сообщения
            Thread.Sleep(settings.SendMessagePause);
            IWebElement sendMessage = driver.FindElement(By.XPath("/html/body/div/div[2]/div[1]/div[2]/div/button"));
            if (settings.SendMessage)
            {
                sendMessage.Click();
                logPrint.Paste($"Сообщение отправлено!", Success.OK, "", loginList[0].Login);
                PrintLog(logPrint);
            }
            else
            {
                logPrint.Paste($"Отправка сообщений отключена!", Success.Info, "", loginList[0].Login); //тестовый прогон без отправки сообщений
                PrintLog(logPrint);
            }
            Thread.Sleep(settings.WaitTreatmentPause);

            //выход из ЛК
            try
            {
                Thread.Sleep(settings.ExitPause);
                IWebElement backButton = driver.FindElement(By.XPath("/html/body/div[1]/div[2]/div[2]/div[1]/button"));
                backButton.Click();

                Thread.Sleep(settings.ExitPause);
                IWebElement menu = driver.FindElement(By.XPath("/html/body/div[1]/div[1]/div[2]/div[1]/button"));
                menu.Click();

                Thread.Sleep(settings.ExitPause);
                IWebElement exit = driver.FindElement(By.XPath("/html/body/div[1]/div[6]/ul[3]/li[2]"));
                exit.Click();
                logPrint.Paste($"Успешный выход из ЛК!", Success.OK, "", loginList[0].Login);
                PrintLog(logPrint);
            }
            catch (Exception)
            {
            }

            //закрытие окна
            Thread.Sleep(settings.ClosePause);
            driver.Close();
            driver.Dispose();
            DeleteLogin(loginList);
        }

    }
}
