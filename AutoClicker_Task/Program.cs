using AutoClicker_Task;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Edge;
using OpenQA.Selenium.Firefox;
using System.Reflection;
using static AutoClicker_Task.Enums;

PrintLog.Print($"Версия программы: {Assembly.GetExecutingAssembly().GetName().Version}");
Settings settings = Settings.GetSettings();
PrintLog.Print($"Поиск сообщений на линии поддержки от {settings.currentMonth}");
AutoClicker_Task.Browsers.CheckVersion();
List<Account> accounts;
if (args.Length > 0)
{
    if (File.Exists("Data.json"))
    {
        PrintLog.Print($"Найден файл данных Data.json. Удалите его или запустите программу без книги Excel.", "", "", LevelEvent.Error);
        BeforeColse(); 
        return;
    }
    accounts = FileWork.ReadExcelBook(args[0]);
}
else
{
    if (!File.Exists("Data.json"))
    {
        PrintLog.Print($"Файл данных Data.json не найден. Запустите программу перетаскиванием книги Excel.", "", "", LevelEvent.Error);
        BeforeColse(); 
        return;
    }
    accounts = FileWork.ReadDataFile();
}

try
{
    IWebDriver driverEdge = new EdgeDriver();
    IWebDriver driverChrome = new ChromeDriver();
    FirefoxOptions firefoxOptions = new FirefoxOptions();
    firefoxOptions.BrowserExecutableLocation = ("C:\\Program Files\\Mozilla Firefox\\firefox.exe");
    IWebDriver driverFirefox = new FirefoxDriver(firefoxOptions);
    driverEdge.Dispose();
    driverChrome.Dispose();
    driverFirefox.Dispose();
}
catch (Exception e)
{
    PrintLog.Print("Программа завершена с ошибками. Не найдены WebDriver или браузеры.", "", e.Message, Enums.LevelEvent.Error);
    BeforeColse();
    return;
}

Thread EdgeWorker = new Thread(RunEdge);
Thread ChromeWorker = new Thread(RunChrome);
Thread FirefoxWorker = new Thread(RunFirefox);

EdgeWorker.Start();
ChromeWorker.Start();
FirefoxWorker.Start();
do
{
    Thread.Sleep(300000);
} while (EdgeWorker.IsAlive || ChromeWorker.IsAlive || FirefoxWorker.IsAlive);

        BeforeColse();

void RunChrome()
{
    while (accounts.Count > 0)
    {
        PrintLog.Print($"Осталось аккаунтов: {accounts.Count} ", "", "", LevelEvent.Info);
        Account account = GetAccount(accounts);
        IWebDriver driverChrome = new ChromeDriver();
        BrowserDriver.Run(driverChrome, account, settings, Enums.Browsers.Chrome);
        driverChrome.Dispose();
    }
}
void RunEdge()
{
    while (accounts.Count > 0)
    {
        PrintLog.Print($"Осталось аккаунтов: {accounts.Count} ", "", "", LevelEvent.Info);
        Account account = GetAccount(accounts);
        IWebDriver driverEdge = new EdgeDriver();
        BrowserDriver.Run(driverEdge, account, settings, Enums.Browsers.Edge);
        driverEdge.Dispose();
    }
}
void RunFirefox()
{
    while (accounts.Count > 0)
    {
        PrintLog.Print($"Осталось аккаунтов: {accounts.Count} ", "", "", LevelEvent.Info);
        Account account = GetAccount(accounts);
        FirefoxOptions firefoxOptions = new FirefoxOptions();
        firefoxOptions.BrowserExecutableLocation = ("C:\\Program Files\\Mozilla Firefox\\firefox.exe");
        IWebDriver driverFirefox = new FirefoxDriver(firefoxOptions);
        BrowserDriver.Run(driverFirefox, account, settings, Enums.Browsers.Firefox);
        driverFirefox.Dispose();
    }
}
static Account GetAccount(List<Account> accounts)
{
    accounts[0].Status = AccountStatus.InWork;
    Account account = accounts[0];
    accounts.RemoveAt(0);
    FileWork.WriteDataFile(accounts);
    return account;
}
void BeforeColse()
{
    PrintLog.Print("Программа завершена.", "", "", LevelEvent.Ok);
    Console.ReadLine();
}
