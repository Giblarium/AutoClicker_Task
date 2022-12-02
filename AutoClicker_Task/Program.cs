using AutoClicker_Task;
using Newtonsoft.Json;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Edge;
using OpenQA.Selenium.Firefox;
using System.Net;
using System.Net.Http;
using System.Reflection;
using static AutoClicker_Task.Enums;



PrintLog.Print($"Версия программы: {Assembly.GetExecutingAssembly().GetName().Version}");
Settings settings = Settings.GetSettings();
PrintLog.Print($"Поиск сообщений на линии поддержки от {settings.currentMonth}");
List<Account> accounts = new List<Account>();   
bool[] browsers = AutoClicker_Task.Browsers.CheckVersion();
FileWork.WriteInfo();

if (settings.useAPI)
{
    PrintLog.Print($"Используется API!");
    ServiceAvalibleAsync();
}
else
{
    PrintLog.Print($"Используется файлы данных!");
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
}






Thread EdgeWorker = new Thread(RunEdge);
Thread ChromeWorker = new Thread(RunChrome);
Thread FirefoxWorker = new Thread(RunFirefox);

if (browsers[1])
{
    EdgeWorker.Start();
}
if (browsers[2])
{
    ChromeWorker.Start();
}
if (browsers[3])
{
    FirefoxWorker.Start();
}


do
{
    Thread.Sleep(300000);
} while (EdgeWorker.IsAlive || ChromeWorker.IsAlive || FirefoxWorker.IsAlive);

BeforeColse();




#region Методы
async void ServiceAvalibleAsync()
{
    HttpClient httpClient = new()
    {
        BaseAddress = new Uri("http://1c.giblarium.ru/")
    };
    StringContent jsonContentGet = new StringContent("");
    HttpResponseMessage responseGet = await httpClient.GetAsync("Account/Avalible");
    if (responseGet.StatusCode != HttpStatusCode.OK)
    {
        PrintLog.Print($"Сервис недоступен!", "", responseGet.StatusCode.ToString(), LevelEvent.Error);
        BeforeColse();
    }
}
async void RunChrome()
{
    while (true)
    {
        Account account = new Account();
        if (settings.useAPI)
        {
            account = await GetNewAccountAsync();
            if (account == null)
            {
                PrintLog.Print($"Не получен аккаунт", "", "", LevelEvent.Error);
                break;
            }
        }
        else
        {
            if (accounts.Count == 0)
            {
                break;
            }
            PrintLog.Print($"Осталось аккаунтов: {accounts.Count} ", "", "", LevelEvent.Info);
            account = GetAccount(accounts);
        }

        IWebDriver driverChrome = new ChromeDriver();
        Enums.AccountStatus accountStatus = BrowserDriver.Run(driverChrome, account, settings, Enums.Browsers.Chrome);
        UpdateAccountAsync(account.Login, (int)accountStatus);
        driverChrome.Dispose();
    }
}



async void RunEdge()
{
    while (true)
    {
        Account account = new Account();
        if (settings.useAPI)
        {
            account = await GetNewAccountAsync();
            if (account == null)
            {
                PrintLog.Print($"Не получен аккаунт", "", "", LevelEvent.Error);
                break;
            }
        }
        else
        {
            if (accounts.Count == 0)
            {
                break;
            }
            PrintLog.Print($"Осталось аккаунтов: {accounts.Count} ", "", "", LevelEvent.Info);
            account = GetAccount(accounts);
        }
        IWebDriver driverEdge = new EdgeDriver();
        Enums.AccountStatus accountStatus = BrowserDriver.Run(driverEdge, account, settings, Enums.Browsers.Edge);
        UpdateAccountAsync(account.Login, (int)accountStatus);
        driverEdge.Dispose();
    }
}
async void RunFirefox()
{
    while (true)
    {
        Account account = new Account();
        if (settings.useAPI)
        {
            account = await GetNewAccountAsync();
            if (account == null)
            {
                PrintLog.Print($"Не получен аккаунт", "", "", LevelEvent.Error);
                break;
            }
        }
        else
        {
            if (accounts.Count == 0)
            {
                break;
            }
            PrintLog.Print($"Осталось аккаунтов: {accounts.Count} ", "", "", LevelEvent.Info);
            account = GetAccount(accounts);
        }
        FirefoxOptions firefoxOptions = new FirefoxOptions();
        firefoxOptions.BrowserExecutableLocation = ("C:\\Program Files\\Mozilla Firefox\\firefox.exe");
        IWebDriver driverFirefox = new FirefoxDriver(firefoxOptions);
        Enums.AccountStatus accountStatus = BrowserDriver.Run(driverFirefox, account, settings, Enums.Browsers.Firefox);
        UpdateAccountAsync(account.Login, (int)accountStatus);
        driverFirefox.Dispose();
    }
}
static Account GetAccount(List<Account> accounts) // не используется.
{
    accounts[0].Status = AccountStatus.InWork;
    Account account = accounts[0];
    accounts.RemoveAt(0);
    FileWork.WriteDataFile(accounts);
    return account;
}
static async Task<Account> GetNewAccountAsync()
{
    HttpClient httpClient = new()
    {
        BaseAddress = new Uri("http://1c.giblarium.ru/")
    };
    StringContent jsonContentGet = new StringContent("");
    HttpResponseMessage responseGet = await httpClient.GetAsync("Account/Get");
    responseGet.EnsureSuccessStatusCode();
    var jsonResponse = await responseGet.Content.ReadAsStringAsync();
    if (jsonResponse == "")
    {
        return null;
    }
    Account account = JsonConvert.DeserializeObject<Account>(jsonResponse);
    return account;
}

async void UpdateAccountAsync(string login, int accountStatus)
{
    HttpClient httpClient = new()
    {
        BaseAddress = new Uri("http://1c.giblarium.ru/")
    };
    using StringContent jsonContentPost = new("");

    using HttpResponseMessage responsePost = await httpClient.PostAsync(
        string.Format($"/Account/Update/{login}/{accountStatus}/"),
        jsonContentPost);
}

void BeforeColse()
{
    PrintLog.Print("Программа завершена.", "", "", LevelEvent.Ok);
    Console.ReadLine();
    Environment.Exit(0);
}
#endregion