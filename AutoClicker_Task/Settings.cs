using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AutoClicker_Task
{
    internal class Settings
    {
        private static string settingsPath = "settings.json";
        public int loadAppPause = 4000;
        public int loginPause = 5000;
        public int openMenuPause = 1000;
        public int openServicePause = 4000;
        public int loadServicePause = 4000;
        public int sendMessagePause = 200;
        public int waitTreatmentPause = 8500;
        public int exitPause = 500;
        public int closePause = 1000;
        public bool sendMessage = true;
        public bool authOnly = false;
        public string currentMonth;
        public bool deleteData = false;
        public int countTry = 3;

        public Settings(string currentMonth)
        {
            this.currentMonth = currentMonth;
        }

        internal static Settings GetSettings()
        {
            Settings settings;
            if (File.Exists(settingsPath))
            {
                string _settings = File.ReadAllText(settingsPath);
                settings = JsonConvert.DeserializeObject<Settings>(_settings);
                PrintLog.Print("Настройки загружены!");
            }
            else
            {
                settings = new Settings(GetCurrentMonth());
                string _settings = JsonConvert.SerializeObject(settings);
                File.WriteAllText(settingsPath, _settings);
                PrintLog.Print("Настройки сохранены!");
            }
            return settings;
        }
        static string GetCurrentMonth()
        {
            DateTime dateTime = DateTime.Now;
            string monthYear = dateTime.ToString("Y");
            monthYear = monthYear.Replace(" г.", "");
            monthYear = monthYear.Substring(0, 1).ToUpper() + monthYear.Substring(1);
            return monthYear;
        }
    }
}
