using System;
using System.IO;
using System.Timers;

namespace TopshelfServiceSample
{
    public class SystemChecker
    {
        private readonly Timer _timer;

        public SystemChecker()
        {
            _timer = new Timer(2000) { AutoReset = true };
            _timer.Elapsed += TimerElapsed;
            WriteLine(DateTime.Now.Ticks + " Started...");
        }

        private void TimerElapsed(object sender, ElapsedEventArgs e)
        {
            /*
            more here...
            */

            WriteLine(DateTime.Now.Ticks + " OK");
        }

        public void OnStart()
        {
            _timer.Start();
        }

        public void OnStop()
        {
            _timer.Stop();
            WriteLine(DateTime.Now.Ticks + " Stopped...");
        }

        private void WriteLine(string text)
        {
            var status = new string[] { text };
            File.AppendAllLines(@"C:\test\Monitor.txt", status);
        }
    }
}
