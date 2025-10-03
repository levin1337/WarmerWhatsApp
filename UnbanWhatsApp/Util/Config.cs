using System;

namespace UnbanWhatsApp.Util
{
    public class Config
    {
        public MessagesConfig messages { get; set; }
        public SpeedConfig speed { get; set; }

        public bool CustomConsole { get; set; }
        public bool DobleMessages { get; set; }
        public KeyConfig key { get; set; }
    }

    public class MessagesConfig
    {
        public int count { get; set; }
    }
    public class SpeedConfig
    {
        public int speed { get; set; }
    }
    public class KeyConfig
    {
        public string key { get; set; }
    }
}
