using System;
using System.Text;

namespace Model
{
    public class Log
    {
        public DateTime DateTime { get; set; }
        public LogLevel LogLevel { get; set; }
        public string Message { get; set; }

        public override string ToString()
        {
            string separator = "\t-\t";

            string[] name = new[]
            {
                this.DateTime.ToString("dd/MM/yyyy HH:mm"),
                separator,
                this.LogLevel.ToString(),
                separator,
                this.Message
            };

            return string.Join(string.Empty, name);
        }
    }
}
