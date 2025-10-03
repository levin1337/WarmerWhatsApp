using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UnbanWhatsApp.Util
{
    internal class def
    {
        public static void CreateDefaultConfig(string filePath)
        {
            var defaultConfig = @"
# количество сообщений
messages:
  count: 8000
# скорость сообщений 5000-12000
speed:
  speed: 12000
# false если хотите использовать значения из конфигурации
CustomConsole: true
# false если хотите чтобы отправлялось 2 сообщения (лучше включить)
DobleMessages: true
# Ваш ключ от программы
key:
  key: 1337
";
            File.WriteAllText(filePath, defaultConfig);
        }
    }
}
