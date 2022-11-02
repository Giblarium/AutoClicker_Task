using OpenQA.Selenium.Chrome;
using OpenQA.Selenium;
using System.Diagnostics;
using static AutoClicker_Task.Enums;
using OpenQA.Selenium.Edge;
using OpenQA.Selenium.Firefox;

namespace AutoClicker_Task
{
    internal class Browsers
    {
        //пути к веб-драйверам и браузерам
        private static string driverEdge = "msedgedriver.exe";
        private static string driverChrome = "chromedriver.exe";
        private static string driverFirefox = "geckodriver.exe";
        private static string browserEdge = "C:\\Program Files\\Microsoft\\Edge\\Application";
        private static string browserEdgex86 = "C:\\Program Files (x86)\\Microsoft\\Edge\\Application";
        private static string browserChrome = "C:\\Program Files\\Google\\Chrome\\Application";
        private static string browserChromex86 = "C:\\Program Files (x86)\\Google\\Chrome\\Application";
        private static string browserFirefox = "C:\\Program Files\\Mozilla Firefox\\";
        private static string browserFirefoxx86 = "C:\\Program Files (x86)\\Mozilla Firefox\\";

        //проверка наличия вебдрайверов и браузеров.
        internal static bool[] CheckVersion()
        {
            bool[] version = new bool[4];
            version[(int)Enums.Browsers.Edge]       = CheckVersionEdge();
            version[(int)Enums.Browsers.Chrome]     = CheckVersionChrome();
            version[(int)Enums.Browsers.Firefox]    = CheckVersionFirefox();
            return version;
        }

        private static bool CheckVersionFirefox()
        {
            bool status = true;
            if (!File.Exists(driverFirefox))
            {
                PrintLog.Print("Geckodriver не найден. Скачайте последнюю версию geckodriver в папку с программой.", "", "", LevelEvent.Error);
                Process.Start(new ProcessStartInfo("cmd", $"/c start https://github.com/mozilla/geckodriver/releases"));
                status = false;
            }
            if (!(Directory.Exists(browserFirefox) || Directory.Exists(browserFirefoxx86)))
            {
                PrintLog.Print("Firefox не найден. Скачайте и установите последнюю версию.", "", "", LevelEvent.Error);
                Process.Start(new ProcessStartInfo("cmd", $"/c start https://www.mozilla.org/ru/firefox/download/thanks/"));
                status = false;
            }
            try
            { //пробный запуск драйвера
                FirefoxOptions firefoxOptions = new FirefoxOptions();
                firefoxOptions.BrowserExecutableLocation = ("C:\\Program Files\\Mozilla Firefox\\firefox.exe");
                IWebDriver driver = new FirefoxDriver(firefoxOptions);
                driver.Dispose();
            }
            catch (Exception)
            {
                status = false;
            }
            return status;
        }

        private static bool CheckVersionChrome()
        {
            bool status = true;
            if (!File.Exists(driverChrome))
            {
                PrintLog.Print("Chromedriver не найден. Скачайте и установите последнюю версию.", "", "", LevelEvent.Error);
                Process.Start(new ProcessStartInfo("cmd", $"/c start https://chromedriver.chromium.org/downloads"));
                status = false;
            }
            if (!(Directory.Exists(browserChrome) || Directory.Exists(browserChromex86)))
            {
                PrintLog.Print("Chrome не найден. Скачайте и установите последнюю версию.", "", "", LevelEvent.Error);
                Process.Start(new ProcessStartInfo("cmd", $"/c start https://www.google.com/intl/ru_ru/chrome/"));
                status = false;
            }
            try
            { //пробный запуск драйвера
                IWebDriver driver = new ChromeDriver();
                driver.Dispose();
            }
            catch (Exception)
            {
                status = false;
            }
            return status;

        }

        private static bool CheckVersionEdge()
        {
            bool status = true;
            if (!File.Exists(driverEdge))
            {
                PrintLog.Print("MicrosoftWebDriver не найден. Скачайте и установите последнюю версию.", "", "", LevelEvent.Error);
                Process.Start(new ProcessStartInfo("cmd", $"/c start https://developer.microsoft.com/ru-ru/microsoft-edge/tools/webdriver/"));
                status = false;
            }
            if (!(Directory.Exists(browserEdge) || Directory.Exists(browserEdgex86)))
            {
                PrintLog.Print("Edge не найден. Скачайте и установите последнюю версию.", "", "", LevelEvent.Error);
                Process.Start(new ProcessStartInfo("cmd", $"/c start https://www.microsoft.com/ru-ru/edge"));
                status = false;
            }
            try
            { //пробный запуск драйвера
                IWebDriver driver = new EdgeDriver();
                driver.Dispose();
            }
            catch (Exception)
            {
                status = false;
            }
            return status;
        }
    }
}
