﻿using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.DevTools.V119.DOMSnapshot;

namespace SeleniumInitialize_Builder
{
    public class SeleniumBuilder : IDisposable
    {
        private IWebDriver WebDriver { get; set; }
        public int Port { get; private set; }
        public bool IsDisposed { get; private set; }
        public List<string> ChangedArguments { get; private set; }
        public Dictionary<string, object> ChangedUserOptions { get; private set; }
        public TimeSpan Timeout { get; private set; }
        public string StartingURL { get; private set; }

        public bool IsHeadless { get; private set; } = false;

        /*
         ### Примечание: Задание 4 можно реализовать с помощью манипулирования объектами Options и DefaultService или же с помощью изменения процесса инициализации в методе Build().
        ### Выбирайте способ, который вам более предпочтителен, на подумать: почему вы считаете этот способ более верным? Для интереса можно попробовать оба способа.

        ## Задача № 4: Запустить с заданным таймаутом.
        Реализовать метод WithTimeout класса SeleniumBuilder с целью запускать браузер с заданным параметром ожидания элементов.
        Изменение таймаута отслеживать в свойстве Timeout.
        Пройти тест - TimeoutTest*/
        public IWebDriver Build()
        {
            //Создать экземпляр драйвера, присвоить получившийся результат переменной WebDriver, вернуть в качестве результата данного метода.

            var options = new ChromeOptions();

            if (IsHeadless)
            {
                options.AddArgument("--headless=new");
            }

            var service = ChromeDriverService.CreateDefaultService();

            WebDriver = new ChromeDriver(service, options);

            WebDriver.Manage().Timeouts().ImplicitWait = Timeout;

            return WebDriver;
            //throw new NotImplementedException();
        }

        public void Dispose()
        {
            WebDriver.Quit();
            GC.SuppressFinalize(this);
            IsDisposed = true;
            //Закрыть браузер, очистить использованные ресурсы, по завершении переключить IsDisposed на состояние true
            //throw new NotImplementedException();
        }

        public SeleniumBuilder ChangePort(int port)
        {
            //Реализовать смену порта, на котором развёрнут IWebDriver для этого необходимо ознакомиться с классом DriverService соответствующего драйвера (ChromeDriverService для хрома)
            //Изменить свойство Port на тот порт, на который поменяли.
            //Builder в данном методе должен возвращать сам себя
            throw new NotImplementedException();
        }

        public SeleniumBuilder SetArgument(string argument)
        {
            //Реализовать добавление аргумента. При решении данной задаче ознакомитесь с классом Options соответствующего драйвера (ChromeOptions для браузера Chrome)
            //Все изменённые/добавленные аргументы необходимо отразить в свойстве СhangedArguments, которое перед этим нужно где-то будет проинициализировать.
            //Builder в данном методе должен возвращать сам себя
            throw new NotImplementedException();
        }

        public SeleniumBuilder SetUserOption(string option, object value)
        {
            //Реализовать добавление пользовательской настройки.
            //Все изменения сохранить в свойстве ChangedUserOptions
            //Builder в данном методе должен возвращать сам себя
            throw new NotImplementedException();
        }


        
        public SeleniumBuilder WithTimeout(TimeSpan timeout)
        {
            //Реализовать изменение изначального таймаута запускаемого браузера
            //Отслеживать изменения в свойстве Timeout
            //Builder возвращает себя
            //throw new NotImplementedException();
            Timeout = timeout;
            return this;  
        }

        public SeleniumBuilder WithURL(string url)
        {
            //Реализовать изменения изначального URL запускаемого браузера
            //Отслеживать изменения в строке StartingURL
            //Builder возвращает себя
            throw new NotImplementedException();
        }

        public SeleniumBuilder WithHeadless(bool headless)
        {
            IsHeadless = headless;
            return this;
        }
    }
}