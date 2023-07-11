using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using System;
using System.IO;

namespace AutoTests
{
    class Program
    {
        static void Main(string[] args)
        {
            ChromeOptions options = new ChromeOptions();
            options.AddArgument("--start-maximized");
            IWebDriver driver = new ChromeDriver(options);

            driver.Navigate().GoToUrl("file:///D:/%23-VS/AutoTests/index.html");
            Console.Clear();

            TestLogin(driver, "1", "2", true, "тест 1");
            TestLogin(driver, "", "zxcv", false, "тест 2");
            TestLogin(driver, "2", "", false, "тест 2");
            TestLogin(driver, "", "", false, "тест 3");
            TestLogin(driver, "", "*?*№;№%/*", false, "тест 3");
            writeFile("");

            driver.Quit();
            Environment.Exit(0);
        }
        static void TestLogin(IWebDriver driver, string username, string password, bool expectedResult, string testName)
        {
            IWebElement username_input = driver.FindElement(By.Id("username"));
            IWebElement password_input = driver.FindElement(By.Id("password"));
            username_input.Clear();
            password_input.Clear();
            username_input.SendKeys(username);
            password_input.SendKeys(password);
            driver.FindElement(By.Id("submit")).Click();
            string errorMes = driver.FindElement(By.Id("result")).Text;
            bool result = errorMes == "Авторизація успішна" ? true : false;
            if (result == expectedResult)
            {
                writeFile($"Введенi данi:");
                writeFile($"username: '{username}'; password: '{password}'");
                writeFile($"'{testName}' пройдений успiшно!\n");
                //Console.WriteLine($"Введенi данi username: '{username}' password: '{password}' | '{testName}' пройдений успiшно!");
            }
            else
            {
                writeFile($"Введенi данi:");
                writeFile($"username: '{username}'; password: '{password}'");
                writeFile($"'{testName}' провалено!\n");
                //Console.WriteLine($"Введенi данi username: '{username}' password: '{password}' | '{testName}' провалено!");
            }
        }

        static void writeFile(string data = "помилка тесту")
        {
            string filePath = "D:\\#-VS\\AutoTests\\file.txt";
            using (StreamWriter writer = new StreamWriter(filePath, append: true))
            {
                writer.WriteLine(data);
            }
        }
    }
}
