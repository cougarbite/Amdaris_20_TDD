using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Amdaris_20_TDD
{
    public class EmailLogger : ILogger
    {
        public void Log(string message)
        {
            Console.WriteLine($"Emailing: {message} on {DateTime.Now}");
        }
    }
}
