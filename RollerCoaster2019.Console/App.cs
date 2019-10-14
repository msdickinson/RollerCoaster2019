using Newtonsoft.Json;
using RollerCoaster2019.Logic;
using RollerCoaster2019.Logic.Builder.DataTypes;
using RollerCoaster2019.Logic.DataTypes;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace RollerCoaster2019.Console
{
    public class App : IApp
    {
        private readonly IUserActions _userActions;

        public App(IUserActions userActions)
        {
            _userActions = userActions;
        }

        public async Task Run()
        {
            var coaster = _userActions.CreateCoaster();
            var buildActions = new List<userActionType>
            {
                BuildActionType.Stright,
                BuildActionType.Back,
                BuildActionType.Stright
            };

            ProcessBuildActions(coaster, buildActions);

            string input = "";
            while (input != "E")
            {
                DisplayCoasterConsole();
                input = ProcessCoasterInput(coaster);
            }

            await Task.CompletedTask;
        }


        internal void ProcessBuildActions(Coaster coaster, List<UserActionType> userActionTypes)
        {
            foreach(var userActionType in userActionTypes)
            {
                var result = _userActions.Build(coaster, userActionType);
                System.Console.WriteLine($"{userActionType.ToString()}");

                System.Console.WriteLine(
                    JsonConvert.SerializeObject(result, 
                                                Formatting.Indented,
                                                new Newtonsoft.Json.Converters.StringEnumConverter()));
                                                
                System.Console.WriteLine("");
            }
        }
        internal string ProcessCoasterInput(Coaster coaster)
        {
            var input = System.Console.ReadLine();
            UserActionType userActionType;
            switch(input)
            {
                case "1":
                    userActionType = UserActionType.Stright;
                    break;
                default:
                      return input;
            }

            var result = _userActions.Build(coaster, userActionType);
            System.Console.WriteLine($"{userActionType.ToString()}");
            System.Console.WriteLine(
                JsonConvert.SerializeObject(result,
                                            Formatting.Indented,
                                            new Newtonsoft.Json.Converters.StringEnumConverter()));

            return input;
        }

        internal void DisplayCoasterConsole()
        {
            System.Console.WriteLine("");
            System.Console.WriteLine("");
            System.Console.WriteLine("");
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
