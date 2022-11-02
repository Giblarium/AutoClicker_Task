using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AutoClicker_Task
{
    internal static class BrowserDriver
    {
        public static Enums.AccountStatus Run()
        {
            throw new NotImplementedException();
        }

        internal static void Run(IWebDriver driver, Account account, Settings settings, Enums.Browsers browsers)
        {
            //создание нового окна
            driver.Url = "http://web.1c-connect.com";
            for (int i = 0; i <= settings.countTry; i++)
            {

                try
                {
                    //ожидание загрузки приложения
                    Thread.Sleep(settings.loadAppPause);
                    IWebElement loginTextBox = driver.FindElement(By.XPath("/html/body/div/div[1]/div/div/div[2]/div/form/input[1]"));
                    IWebElement passTextBox = driver.FindElement(By.XPath("/html/body/div/div[1]/div/div/div[2]/div/form/input[2]"));
                    IWebElement submitTextBox = driver.FindElement(By.XPath("/html/body/div/div[1]/div/div/div[2]/div/form/input[3]"));

                    //заполнение логина и пароля
                    loginTextBox.SendKeys(account.Login);
                    passTextBox.SendKeys(account.Password);
                    submitTextBox.Click();
                    break;
                }
                catch (Exception e)
                {
                    PrintLog.Print($"Web-приложение не загрузилось!", account.Login, e.Message, Enums.LevelEvent.Error, browsers);
                    continue;
                }
            }

            //попытка открытия бокового меню
            bool openMenu = false;
            for (int i = 0; i <= settings.countTry; i++)
            {
                Thread.Sleep(settings.loginPause);
                try
                {
                    IWebElement menu = driver.FindElement(By.XPath("/html/body/div/div[1]/div[2]/div[1]/button"));
                    menu.Click();
                    PrintLog.Print($"Авторизация успешна!", account.Login, "", Enums.LevelEvent.Ok, browsers);
                    openMenu = true;
                    break;
                }
                catch (Exception e)
                {
                    PrintLog.Print($"Попытка авторизации {i + 1} не удалась!", account.Login, "", Enums.LevelEvent.Error, browsers);
                    try
                    {
                        IWebElement authErr = driver.FindElement(By.XPath("//*[contains(text(), 'Ошибка авторизации')]"));
                        if (authErr.Text == "Ошибка авторизации")
                        {
                            PrintLog.Print($"Авторизация не удалась! Неверный логин/пароль", account.Login, e.Message, Enums.LevelEvent.Error, browsers);
                            FileWork.WriteBadData(account, Enums.AccountStatus.WrongPass);
                            break;
                        }
                        if (authErr.Text == "Сбой авторизации")
                        {
                            PrintLog.Print($"Авторизация не удалась! Что-то пошло не так", account.Login, e.Message, Enums.LevelEvent.Error, browsers);
                            FileWork.WriteBadData(account, Enums.AccountStatus.Other);
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
            if (settings.authOnly)
            {
                PrintLog.Print($"Включен режим \"Только авторизация\"", account.Login, "", Enums.LevelEvent.Warning, browsers);
                return;
            }

            //открытие списка линий поддержки
            Thread.Sleep(settings.openMenuPause);
            IWebElement services = driver.FindElement(By.XPath("/html/body/div/div[6]/ul[2]/li[2]"));
            services.Click();

            //попытка открыть линию поддержки Первый Бит Воронеж Центральный офис
            try
            {
                Thread.Sleep(settings.openServicePause);
                IWebElement service = driver.FindElement(By.XPath("//*[contains(text(), 'Первый Бит Воронеж Центральный офис')]"));
                service.Click();
                PrintLog.Print($"Открыта линия поддержки! \"Первый Бит Воронеж Центральный офис\"", account.Login, "", Enums.LevelEvent.Ok, browsers);
            }
            catch 
            {
                // если не удалось, поиск ЛП Первый Бит Воронеж Северный
                try
                {
                    IWebElement service = driver.FindElement(By.XPath("//*[contains(text(), 'Первый БИТ: Поддержка клиентов 1С 24\\7')]"));
                    service.Click();
                    PrintLog.Print($"Открыта линия поддержки! \"Первый БИТ: Поддержка клиентов 1С 24\\7\"", account.Login, "", Enums.LevelEvent.Ok, browsers);
                }
                catch (Exception ex)
                {
                    PrintLog.Print($"Не удалось найти линии поддержки!", account.Login, ex.Message, Enums.LevelEvent.Ok, browsers);
                    FileWork.WriteBadData(account, Enums.AccountStatus.Other);
                    return;
                }
            }

            Thread.Sleep(settings.loadServicePause);
            //поиск предыдущих сообщений
            try
            {
                IWebElement previousMessage = driver.FindElement(By.XPath($"//*[contains(text(), '{settings.currentMonth}')]"));
                PrintLog.Print($"В {settings.currentMonth} уже есть обращения!", account.Login, "", Enums.LevelEvent.Warning, browsers);
                FileWork.WriteBadData(account, Enums.AccountStatus.AlreadyMessage);
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
            Thread.Sleep(settings.sendMessagePause);
            IWebElement sendMessage = driver.FindElement(By.XPath("/html/body/div/div[2]/div[1]/div[2]/div/button"));
            if (settings.sendMessage)
            {
                sendMessage.Click();
                PrintLog.Print($"Сообщение отправлено!", account.Login, "", Enums.LevelEvent.Ok, browsers);
            }
            else
            {
                PrintLog.Print($"Отправка сообщений отключена!", account.Login, "", Enums.LevelEvent.Warning, browsers);
            }
            Thread.Sleep(settings.waitTreatmentPause);

        }
    }
}