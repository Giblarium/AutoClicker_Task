using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace WinFormsApp1.DriverWorker
{
    static internal class BrowserDriverWorker
    {
        internal static StatusAccount GetRekt(IWebDriver driver, Account account, bool authOnly, bool dontSend)
        {
            //IWebDriver driver;

            //открыть окно хрома
            //driver = new ChromeDriver();
            driver.Url = "http://web.1c-connect.com";

            Thread.Sleep(3000);

            //ожидание загрузки приложения
            for (int i = 0; i < 5; i++)
            {
                Thread.Sleep(i * 1000);
                try
                {
                    IWebElement loginTextBox = driver.FindElement(By.XPath("/html/body/div/div[1]/div/div/div[2]/div/form/input[1]"));
                    IWebElement passTextBox = driver.FindElement(By.XPath("/html/body/div/div[1]/div/div/div[2]/div/form/input[2]"));
                    IWebElement submitTextBox = driver.FindElement(By.XPath("/html/body/div/div[1]/div/div/div[2]/div/form/input[3]"));
                    //заполнение логина и пароля
                    loginTextBox.SendKeys(account.Name);
                    passTextBox.SendKeys(account.Password);
                    submitTextBox.Click();
                    break;
                }
                catch (Exception)
                {
                    Logger.Write(account.Name, "Приложение не загрузилось. Попытка " + i.ToString());
                    continue;
                }
            }

            //попытка открытия бокового меню
            bool openMenu = false;
            for (int i = 0; i < 5; i++)
            {
                Thread.Sleep(i * 1000);
                try
                {
                    IWebElement menu = driver.FindElement(By.XPath("/html/body/div/div[1]/div[2]/div[1]/button"));
                    menu.Click();
                    Logger.Write(account.Name, "Авторизация успешна");
                    openMenu = true;
                    break;
                }
                catch (Exception e)
                {
                    Logger.Write(account.Name, $"Авторизация {i.ToString()} не удалась!");
                    try
                    {
                        IWebElement authErr = driver.FindElement(By.XPath("//*[contains(text(), 'Ошибка авторизации')]"));
                        if (authErr.Text == "Ошибка авторизации")
                        {
                            Logger.Write(account.Name, "Неверный логин или пароль!");
                            CloseWorker(driver);
                            return StatusAccount.WrongPass;
                        }
                        if (authErr.Text == "Сбой авторизации")
                        {
                            Logger.Write(account.Name, "Сбой соединения!");
                            CloseWorker(driver);
                            return StatusAccount.NotAuthorizedYet;
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
                return StatusAccount.NotAuthorizedYet;
            }

            //если нужны только авторизации
            if (authOnly)
            {
                Logger.Write(account.Name, "Только авторизации");
                CloseWorker(driver);
            }

            //открытие списка линий поддержки
            Thread.Sleep(500);
            IWebElement services = driver.FindElement(By.XPath("/html/body/div/div[6]/ul[2]/li[2]"));
            services.Click();

            //попытка открыть линию поддержки Первый Бит Воронеж Центральный офис
            try
            {
                Thread.Sleep(1500);
                IWebElement service = driver.FindElement(By.XPath("//*[contains(text(), 'Первый Бит Воронеж Центральный офис')]"));
                service.Click();
                Logger.Write(account.Name, "Открыта линия поддержки! \"Первый Бит Воронеж Центральный офис\"");
            }
            catch (Exception e)
            {
                // если не удалось, поиск ЛП Первый Бит Воронеж Северный
                try
                {
                    IWebElement service = driver.FindElement(By.XPath("//*[contains(text(), 'Первый БИТ: Поддержка клиентов 1С 24\\7')]"));
                    service.Click();
                    Logger.Write(account.Name, "Открыта линия поддержки! \"Первый БИТ: Поддержка клиентов 1С 24\\7\"");
                }
                catch (Exception ex)
                {
                    // если не удалось
                    Logger.Write(account.Name, "Не удалось найти линии поддержки!");
                    CloseWorker(driver);
                    return StatusAccount.NotFoundLineSupport;
                }
            }

            Thread.Sleep(2000);
            //поиск предыдущих сообщений
            try
            {
                string currentMonth = Logger.GetCurrentMonth();
                IWebElement previousMessage = driver.FindElement(By.XPath($"//*[contains(text(), '{currentMonth}')]"));
                Logger.Write(account.Name, $"В {currentMonth} уже есть обращения!");
                CloseWorker(driver);
                return StatusAccount.AlreadyHaveMessages;
            }
            catch (Exception)
            {
                //если сообщение не найдено, то ничего не делать
            }

            //написание сообщения
            IWebElement textMessage = driver.FindElement(By.XPath("/html/body/div/div[2]/div[1]/div[2]/div/div/textarea"));
            textMessage.SendKeys("тест");

            //отправка сообщения
            Thread.Sleep(800);
            IWebElement sendMessage = driver.FindElement(By.XPath("/html/body/div/div[2]/div[1]/div[2]/div/button"));
            if (!dontSend)
            {
                sendMessage.Click();
                Logger.Write(account.Name, "Сообщение отправлено!");
            }
            else
            {
                Logger.Write(account.Name, "Отправка сообщений отключена!");

            }
            Thread.Sleep(8000);

            //выход из ЛК
            try
            {
                Thread.Sleep(500);
                IWebElement backButton = driver.FindElement(By.XPath("/html/body/div[1]/div[2]/div[2]/div[1]/button"));
                backButton.Click();

                Thread.Sleep(500);
                IWebElement menu = driver.FindElement(By.XPath("/html/body/div[1]/div[1]/div[2]/div[1]/button"));
                menu.Click();

                Thread.Sleep(500);
                IWebElement exit = driver.FindElement(By.XPath("/html/body/div[1]/div[6]/ul[3]/li[2]"));
                exit.Click();
                Logger.Write(account.Name, "Успешный выход из ЛК!");
            }
            catch (Exception)
            {
            }

            //закрытие окна
            Thread.Sleep(500);
            CloseWorker(driver);
            return StatusAccount.OK;
        }

        private static void CloseWorker(IWebDriver driver)
        {
            driver.Close();
            driver.Dispose();
        }
    }
}
