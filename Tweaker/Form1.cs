using Newtonsoft.Json;

namespace Tweaker
{
    public partial class Form1 : Form
    {
        Settings settings = new Settings();
        public Form1()
        {
            InitializeComponent();
            UpdateForm(ReadFileSettings());
        }

        private void open_Click(object sender, EventArgs e)
        {
            UpdateForm(ReadFileSettings());
        }

        private void UpdateForm(Settings settings)
        {
            loadAppPause.Text = settings.loadAppPause.ToString();
            loginPause.Text = settings.loginPause.ToString();
            openMenuPause.Text = settings.openMenuPause.ToString();
            openServicePause.Text = settings.openServicePause.ToString();
            loadServicePause.Text = settings.loadServicePause.ToString();
            sendMessagePause.Text = settings.sendMessagePause.ToString();
            waitTreatmentPause.Text = settings.waitTreatmentPause.ToString();
            sendMessage.Checked = settings.sendMessage;
            authOnly.Checked = settings.authOnly;
            currentMonth.Text = settings.currentMonth.ToString();
            deleteData.Checked = settings.deleteData;
            countTry.Text = settings.countTry.ToString();
            useAPI.Checked = settings.useAPI;
        }

        private Settings ReadFileSettings()
        {
            string settingFile = Path.Combine(Environment.CurrentDirectory, "settings.json");
            string settingsStr = File.ReadAllText(settingFile);
            settings = JsonConvert.DeserializeObject<Settings>(settingsStr);
            return settings;
        }

        private void save_Click(object sender, EventArgs e)
        {
            Int32.TryParse(loadAppPause.Text, out settings.loadAppPause);
            Int32.TryParse(loadAppPause.Text, out settings.loadAppPause);
            Int32.TryParse(loginPause.Text, out settings.loginPause);
            Int32.TryParse(openMenuPause.Text, out settings.openMenuPause);
            Int32.TryParse(openServicePause.Text, out settings.openServicePause);
            Int32.TryParse(loadServicePause.Text, out settings.loadServicePause);
            Int32.TryParse(sendMessagePause.Text, out settings.sendMessagePause);
            Int32.TryParse(waitTreatmentPause.Text, out settings.waitTreatmentPause);
            Int32.TryParse(countTry.Text, out settings.countTry);
            settings.sendMessage = sendMessage.Checked;
            settings.authOnly = authOnly.Checked;
            settings.currentMonth = currentMonth.Text;
            settings.deleteData = deleteData.Checked;
            settings.useAPI = useAPI.Checked;
            string settinsStr = JsonConvert.SerializeObject(settings);
            File.WriteAllText(Path.Combine(Environment.CurrentDirectory, "settings.json"), settinsStr);
        }

        private void loadAppPause_KeyPress(object sender, KeyPressEventArgs e)
        {
            CheckTextBox(e);
        }

        private void CheckTextBox(KeyPressEventArgs e)
        {
            char ch = e.KeyChar;
            if (!Char.IsDigit(ch) && ch != 8)
            {
                e.Handled = true;
            }
        }
    }
}