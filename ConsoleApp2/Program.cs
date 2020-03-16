using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Logging.Console;
using System;

namespace ConsoleApp2
{
    class Program
    {
        static void Main(string[] args)
        {
            var serviceProvider = new ServiceCollection()
                .AddLogging(cfg=>cfg.AddConsole()).Configure<LoggerFilterOptions>(d=>d.MinLevel=LogLevel.Debug)
                .AddSingleton< TOUFileService>()
                .AddSingleton< LPFileService>()
                .BuildServiceProvider();


            var logger = serviceProvider.GetService<ILoggerFactory>().CreateLogger<Program>();
            if (args.Length < 1)
            {
                logger.LogError("Usage FindMedien path_to_file");
                return;
            }
            //var fileService = serviceProvider.GetService<IFileService>();
            if (args[0].StartsWith("TOU"))
            {
                var fileService = serviceProvider.GetService<TOUFileService>();
                var list=fileService.FindMedien(args[0]);
                foreach(var e in list.Item1 )
                {
                   var b=e as TOU;
                    logger.LogInformation($"File Name :{args[0]},Date Time : {b.DateTime},Value:{b.Energy},Median:{list.Item2}");
                }
            }
            else
            {
                var fileService = serviceProvider.GetService<LPFileService>();
                var list = fileService.FindMedien(args[0]);
                foreach (var e in list.Item1)
                {
                    var b = e as LP;
                    logger.LogInformation($"File Name :{args[0]},Date Time : {b.DateTime},Value:{b.DataValue},Median:{list.Item2}");
                }
            }
            

             

        }
    }
}
