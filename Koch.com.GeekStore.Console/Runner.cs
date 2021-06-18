using Koch.com.GeekStore.Console.Logic;
using Microsoft.Extensions.Logging;

namespace Koch.com.GeekStore.Console
{
    using System;

    public class Runner : IRunner
    {
        private readonly IGeekStoreService _geekService;

        private ILogger<Runner> _logger;

        public Runner(
            IGeekStoreService geekService,
            ILoggerFactory loggerFactory)
        {
            _geekService = geekService;

            _logger = loggerFactory.CreateLogger<Runner>();
        }

        public void Run()
        {
            _logger.LogInformation("Service started!");

            var command = string.Empty;
            do
            {
                Console.Write("Please enter input to test ToSafeInt, to quit type exit : ");
                command = Console.ReadLine();
                if(command == "exit")
                {
                    Environment.Exit(0);
                }

                int output = _geekService.ToSafeInt(command);
                if (output == 0 && command != "0")
                {
                    Console.WriteLine("Invalid input");
                }
                else
                {
                    Console.WriteLine("ToSafeInt() Result: {0} ", output);
                }
                Console.Write("Please enter input to test ToSafeIntArbitrary : ");
                var arbitraryCommand = Console.ReadLine();
                Console.Write("Specify optional return value else press enter : ");
                var optionalValue = Console.ReadLine();
                int number = 0;
                Int32.TryParse(optionalValue, out number);

                var arbitraryCommandOutput = _geekService.ToSafeIntArbitrary(arbitraryCommand, number);

                if(arbitraryCommandOutput.Item2)
                {
                    Console.WriteLine("ToSafeIntArbitrary() Result : {0} ", arbitraryCommandOutput.Item1);
                }
                else
                {
                    Console.WriteLine("Invalid input, default value: {0} ", arbitraryCommandOutput.Item1);
                }
                
                Console.WriteLine("=======================================");
            }
            while (!command.Equals("exit", StringComparison.InvariantCultureIgnoreCase));

            Console.ReadKey();
        }
    }
}
