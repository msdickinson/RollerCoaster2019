using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;
using RollerCoaster2019.Contracts;
using RollerCoaster2019.Logic;
using RollerCoaster2019.Services.ManageCoaster;
using System;
using System.Threading.Tasks;

namespace RollerCoaster2019.Console
{
    public class App : IApp
    {
        private readonly ILogger<App> _logger;
        private readonly IUserActions _userActions;
        internal readonly IManageCoasterService _manageCoasterService;
        private readonly IOptions<DBConnection> _config;

        public App(ILogger<App> logger,
                   IUserActions userActions,
                   IManageCoasterService manageCoasterService,
                   IOptions<DBConnection> config)
        {
            _logger = logger;
            _userActions = userActions;
            _manageCoasterService = manageCoasterService;
            _config = config;
        }

        public async Task Run()
        {
            var coaster = _userActions.CreateCoaster();
            _userActions.Build(coaster, Contracts.BuildActionType.Stright);
            _userActions.Build(coaster, Contracts.BuildActionType.Back);
            _userActions.Build(coaster, Contracts.BuildActionType.Stright);
            string input = "";
            while (input != "E")
            {
                DisplayCoasterConsole();
                input = ProcessCoasterInput(coaster);
            }

            await Task.CompletedTask;
        }

        internal string ProcessCoasterInput(Coaster coaster)
        {
            var input = System.Console.ReadLine();
            try
            {
                if (input == "1")
                {
                    _userActions.Build(coaster, Contracts.BuildActionType.Stright);
                }

            }
            catch(Exception ex)
            {
                _logger.LogError($"Input: {input}", ex);
            }
          
            return input;
        }

        internal void DisplayCoasterConsole()
        {
            System.Console.Clear();
            System.Console.WriteLine("RC User Actions");
            System.Console.WriteLine("1: Build Left");
            System.Console.WriteLine("2: Build Right");
            System.Console.WriteLine("3: Build Stright");
            System.Console.WriteLine("4. Build Up");
            System.Console.WriteLine("5. Build Down");
            System.Console.WriteLine("6. Back");
            System.Console.WriteLine("D. Delete Coaster");
            System.Console.WriteLine("E. Exit");
            System.Console.WriteLine("");
            System.Console.Write("Command: ");
        }
    }
}
