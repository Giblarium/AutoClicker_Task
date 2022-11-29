using Newtonsoft.Json;

namespace AutoClicker_Task
{
    internal class Settings
    {
        private static string settingsPath = "settings.json"; //расположение файла настроек
        public int loadAppPause = 4000; //ожидание загрузки веб-приложения
        public int loginPause = 5000; //ожидание авторизации
        public int openMenuPause = 1000; //пауза между нажатиями на кнопки меню
        public int openServicePause = 4000; //ожидание загрузки списка ЛП
        public int loadServicePause = 4000; //ождание загрузки ЛП
        public int sendMessagePause = 200; //пауза между вводом текста и нажатием на кнопку
        public int waitTreatmentPause = 8500; //ожидание назначения специалиста
        public int exitPause = 500; //пауза между нажатием на кнопки меню для выхода из ЛК
        public int closePause = 1000; //пауза перед закрытием веб-драйвера
        public bool sendMessage = true; //режим отправки сообщения
        public bool authOnly = false; //режим "Только авторизация"
        public string currentMonth; //строка с текущим месяцев
        public bool deleteData = false; //Не помню.
        public int countTry = 3; //количество попыток, перед
        public bool useAPI = true; //обращение к API

        public Settings(string currentMonth)
        {
            this.currentMonth = currentMonth;
        }

        internal static Settings GetSettings()
        {
            //если файл настроек существует, то читаем
            Settings settings;
            if (File.Exists(settingsPath))
            {
                string _settings = File.ReadAllText(settingsPath);
                settings = JsonConvert.DeserializeObject<Settings>(_settings);
                PrintLog.Print("Настройки загружены!");
            }
            //иначе создаем новый и записываем
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
            //обработка DateTime.Now для вида "Ноябрь 2020"
            DateTime dateTime = DateTime.Now;
            string monthYear = dateTime.ToString("Y");
            monthYear = monthYear.Replace(" г.", "");
            monthYear = monthYear.Substring(0, 1).ToUpper() + monthYear.Substring(1);
            return monthYear;
        }
    }
}
