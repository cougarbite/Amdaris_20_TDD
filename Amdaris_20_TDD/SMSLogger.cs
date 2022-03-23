using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Amdaris_20_TDD
{
    public class SMSLogger : ILogger
    {
        public void Log(string message)
        {
            Console.WriteLine($"{message} on {DateTime.Now}");
        }
    }
}
