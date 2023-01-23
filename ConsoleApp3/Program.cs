
using System;
using System.ServiceProcess; // нужно добавить ссылку в проект

namespace TestConsoleApp
{
    class Program
    {
        // Экспериментировать будем со службой центра обновления Windows
        static void Main(string[] args)
        {
            StopService("Центр обновления Windows");
            StartService("Центр обновления Windows");
            RestartService("Центр обновления Windows");
            Console.WriteLine("Нажмите клавишу для продолжения...");
            Console.ReadLine();
        }

        // Запуск службы
        public static void StartService(string serviceName)
        {
            ServiceController service = new ServiceController(serviceName);
            // Проверяем не запущена ли служба
            if (service.Status != ServiceControllerStatus.Running)
            {
                // Запускаем службу
                service.Start();
                // В течении минуты ждём статус от службы
                service.WaitForStatus(ServiceControllerStatus.Running, TimeSpan.FromMinutes(1));
                Console.WriteLine("Служба была успешно запущена!");
            }
            else
            {
                Console.WriteLine("Служба уже запущена!");
            }
        }

        // Останавливаем службу
        public static void StopService(string serviceName)
        {
            // Если служба не остановлена
            
        }

        // Перезапуск службы
        public static void RestartService(string serviceName)
        {
            ServiceController service = new ServiceController(serviceName);
            TimeSpan timeout = TimeSpan.FromMinutes(1);
            if (service.Status != ServiceControllerStatus.Stopped)
            {
                Console.WriteLine("Перезапуск службы. Останавливаем службу...");
                // Останавливаем службу
                service.Stop();
                service.WaitForStatus(ServiceControllerStatus.Stopped, timeout);
                Console.WriteLine("Служба была успешно остановлена!");
            }
            if (service.Status != ServiceControllerStatus.Running)
            {
                Console.WriteLine("Перезапуск службы. Запускаем службу...");
                // Запускаем службу
                service.Start();
                service.WaitForStatus(ServiceControllerStatus.Running, timeout);
                Console.WriteLine("Служба была успешно запущена!");
            }
        }
    }
}