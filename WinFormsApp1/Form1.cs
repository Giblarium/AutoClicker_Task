using Excel = Microsoft.Office.Interop.Excel;
using Newtonsoft.Json.Serialization;
using Newtonsoft.Json;
using System.Data;
using WinFormsApp1.DriverWorker;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium;
using OpenQA.Selenium.Firefox;
using OpenQA.Selenium.Edge;

namespace WinFormsApp1
{
    public partial class Form1 : Form
    {
        private bool InWork = true;
        public Form1()
        {
            InitializeComponent();
        }
        public DataTable dataTable;
        static List<Account> AccountList = new List<Account>();
        int index = 0;
        private Task runAllTask = new Task(RunAll);

        private static void RunAll()
        {
            while (true)
            {
                StartChrome();
                StartFirefox();
                StartEdge();
            }
        }



        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void button2_Click(object sender, EventArgs e)
        {
            OpenFile();
        }

        private void OpenFile()
        {
            OpenFileDialog OPF = new OpenFileDialog
            {
                Filter = "Книга Excel|*.xlsx"
            };
            if (OPF.ShowDialog() == DialogResult.OK)
            {
                pathToExcel_textBox.Text = OPF.FileName;

            }
        }

        private void readExcel_button_Click(object sender, EventArgs e)
        {
            ReadExcel();
            //int i1 = 0;
        }

        private void ReadExcel()
        {
            Excel.Application ObjWorkExcel = new Excel.Application(); //открыть эксель
            Excel.Workbook ObjWorkBook;
            Excel.Worksheet ObjWorkSheet;
            try
            {
                ObjWorkBook = ObjWorkExcel.Workbooks.Open(pathToExcel_textBox.Text, Type.Missing, Type.Missing, Type.Missing, Type.Missing, Type.Missing, Type.Missing, Type.Missing, Type.Missing, Type.Missing, Type.Missing, Type.Missing, Type.Missing, Type.Missing, Type.Missing); //открыть файл
                ObjWorkSheet = (Excel.Worksheet)ObjWorkBook.Sheets[1];
                var lastCell = ObjWorkSheet.Cells.SpecialCells(Excel.XlCellType.xlCellTypeLastCell);
                for (int i = 0; i < lastCell.Row; i++)
                {
                    string login = ObjWorkSheet.Cells[i + 1, 1].Text.ToString();
                    string pass = ObjWorkSheet.Cells[i + 1, 2].Text.ToString();
                    AccountList.Add(new Account(login, pass));
                }
                ObjWorkBook.Close(false, Type.Missing, Type.Missing); //закрыть не сохраняя
            }
            catch (Exception exc)
            {
                return;
            }
            finally
            {
                ObjWorkExcel.Quit(); // выйти из экселя
                GC.Collect(); // убрать за собой
            }

            SaveDataFile(AccountList);
            Account[] accounts = AccountList.ToArray();
            string accountsStr = JsonConvert.SerializeObject(accounts);
            dataTable = JsonConvert.DeserializeObject<DataTable>(accountsStr);
            UpdateDataGrid(dataTable);
            UpdateLabel(label_CountAccounts, $"В таблице {AccountList.Count} аккаунтов.");
        }

        private void UpdateLabel(Label label, string v)
        {
            label.Text = v;
        }

        private void UpdateDataGrid(DataTable? dataTable)
        {
            dataGridView1.DataSource = dataTable;
            //throw new NotImplementedException();
        }

        private void SaveDataFile(List<Account> accountList)
        {
            Account[] accounts = accountList.ToArray();
            string accountsStr = JsonConvert.SerializeObject(accounts);
            File.WriteAllText("data.json", accountsStr);
        }

        private void openExcelToolStripMenuItem_Click(object sender, EventArgs e)
        {
            OpenFile();
            ReadExcel();
        }

        private void picture_Chrome_Click(object sender, EventArgs e)
        {
            StartChrome();
        }

        private void picture_Firefox_Click(object sender, EventArgs e)
        {
            StartFirefox();
        }

        private void picture_Edge_Click(object sender, EventArgs e)
        {
            StartEdge();
        }
        private static void StartFirefox()
        {
            Thread firefoxThread = new Thread(FirefoxWork);
            firefoxThread.Start();
        }
        private static void StartEdge()
        {
            Thread edgeThread = new Thread(EdgeWork);
            edgeThread.Start();
        }
        private static void StartChrome()
        {
            Task chromeTask = new Task(ChromeWork);
            chromeTask.Start();
            chromeTask.Wait();
        }
        private void button_StartAll_Click(object sender, EventArgs e)
        {
            runAllTask.Start();
        }


        #region Workers
        private static void FirefoxWork()
        {
            Account account = GetAccount();
            if (account is null) return;
            IWebDriver driver;
            driver = new FirefoxDriver();
            StatusAccount statusAccount = BrowserDriverWorker.GetRekt(driver, account, true, false);
            account.StatusAccount = statusAccount;

        }
        private static void ChromeWork()
        {
            Account account = GetAccount();
            if (account is null) return;
            IWebDriver driver;
            driver = new ChromeDriver();
            StatusAccount statusAccount = BrowserDriverWorker.GetRekt(driver, account, true, false);
            account.StatusAccount = statusAccount;
        }

        private static void EdgeWork(object? obj)
        {
            Account account = GetAccount();
            if (account is null) return;
            IWebDriver driver;
            driver = new EdgeDriver();
            StatusAccount statusAccount = BrowserDriverWorker.GetRekt(driver, account, true, false);
            account.StatusAccount = statusAccount;
        }
        #endregion


        private static Account GetAccount()
        {
            try
            {
                foreach (var item in AccountList)
                {
                    if (item.StatusAccount == StatusAccount.NotAuthorizedYet)
                    {
                        item.StatusAccount = StatusAccount.InWork;
                        return item;
                    }
                }
            }
            catch (Exception e)
            {
            }
            return null;
        }

        private void button_PauseAll_Click(object sender, EventArgs e)
        {
            runAllTask.Dispose();
        }
    }
}