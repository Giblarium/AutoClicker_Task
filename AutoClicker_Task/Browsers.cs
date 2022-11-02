using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static AutoClicker_Task.Enums;

namespace AutoClicker_Task
{
    internal class Browsers
    {
        private static string driverEdge = "msedgedriver.exe";
        private static string driverChrome = "chromedriver.exe";
        private static string driverFirefox = "geckodriver.exe";
        private static string browserEdge = "C:\\Program Files\\Microsoft\\Edge\\Application";
        private static string browserEdgex86 = "C:\\Program Files (x86)\\Microsoft\\Edge\\Application";
        private static string browserChrome = "C:\\Program Files\\Google\\Chrome\\Application";
        private static string browserChromex86 = "C:\\Program Files (x86)\\Google\\Chrome\\Application";
        private static string browserFirefox = "C:\\Program Files\\Mozilla Firefox\\";
        private static string browserFirefoxx86 = "C:\\Program Files (x86)\\Mozilla Firefox\\";

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
            return status;
        }

        private static bool CheckVersionChrome()
        {
            bool status = true;
            if (!File.Exists(Path.Combine(Environment.CurrentDirectory, driverChrome)))
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
            return status;
        }
    }
}
