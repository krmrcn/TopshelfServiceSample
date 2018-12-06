using System;
using Topshelf;

namespace TopshelfServiceSample
{
    class Program
    {
        static void Main(string[] args)
        {
            var exitCode = HostFactory.Run(d =>
            {
                d.Service<SystemChecker>(s =>
                {
                    s.ConstructUsing(checker => new SystemChecker());
                    s.WhenStarted(checker => checker.OnStart());
                    s.WhenStopped(checker => checker.OnStop());
                });

                d.RunAsLocalSystem();

                d.SetServiceName("SysChecker");
                d.SetDisplayName("System Checker");
                d.SetDescription("Topshelf Sample");
            });

            int exitCodeValue = (int)Convert.ChangeType(exitCode, exitCode.GetTypeCode());
            Environment.ExitCode = exitCodeValue;
        }
    }
}
