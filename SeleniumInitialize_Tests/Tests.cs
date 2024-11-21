using OpenQA.Selenium;
using SeleniumInitialize_Builder;
using System.Diagnostics;

namespace SeleniumInitialize_Tests
{
    public class Tests
    {
        private SeleniumBuilder _builder;
        [SetUp]
        public void Setup()
        {
            _builder = new SeleniumBuilder();
        }

        [TearDown]
        public void Teardown()
        {
            _builder.Dispose();
        }

        [Test(Description = "Проверка корректной инициализации экземпляра IWebDriver")]
        public void BuildTest1()
        {
            IWebDriver driver = _builder.Build();
            Assert.IsNotNull(driver);
        }

        [Test(Description = "Проверка очистки ресурсов IWebDriver")]
        public void DisposeTest1()
        {
            IWebDriver driver = _builder.Build();
            Assert.IsFalse(_builder.IsDisposed);
            _builder.Dispose();
            Assert.IsTrue(_builder.IsDisposed);
            var processes = Process.GetProcessesByName("chromedriver");
            Assert.IsFalse(processes.Any(), "Процесс chromedriver все еще работает после ожидания.");
        }

        [Test(Description = "Проверка изменения таймаута")]
        public void TimeoutTest()
        {
            TimeSpan timeout = TimeSpan.FromSeconds(20);
            IWebDriver driver = _builder.WithTimeout(timeout).Build();
            Assert.That(driver.Manage().Timeouts().ImplicitWait, Is.EqualTo(timeout));
            Assert.That(_builder.Timeout, Is.EqualTo(timeout));
        }


    }
}