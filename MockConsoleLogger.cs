using System;

namespace BatteryManagementSystem
{
    public class MockConsoleLogger : ILogger
    {
        public void Log(string message)
        {
            Console.WriteLine(message);
        }
    }
}
