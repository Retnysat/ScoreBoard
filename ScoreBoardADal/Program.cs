using ScoreBoard.App.Abstract;
using ScoreBoard.App.Concrete;
using ScoreBoard.App.Managers;
using ScoreBoard.Domain.Entity;

namespace ScoreBoardADal
{
    class Program
    {
        static void Main(string[] args)
        {
            
            MenuActionService actionService = new MenuActionService();
            MatchService matchService = new MatchService();
            MatchManager matchManager = new MatchManager(actionService, matchService);

            Console.WriteLine("=========================================");
            Console.WriteLine("=  Live Football World Cup Score Board  =");
            Console.WriteLine("=========================================");
            Console.WriteLine("====     by Arkadiusz Dalanek        ====");
            Console.WriteLine("=========================================");
            Console.WriteLine();
            
            var mainMenu = actionService.GetMenuActionsByMenuName("Main");

            while (true)
            {

                for (int i = 0; i < mainMenu.Count; i++)
                {
                    Console.WriteLine($"{mainMenu[i].Id}. {mainMenu[i].Name}");
                }

                var operatnion = Console.ReadKey();
                Console.WriteLine();
                Console.Clear();
                switch (operatnion.KeyChar)
                {
                    case '1':
                        var newId = matchManager.StartNewMatch();
                        break;
                    case '2':
                        matchManager.ChangeMatchScore();
                        break;
                    case '3':
                        matchManager.FinishMatch();
                        break;
                    case '4':
                        matchManager.SummaryOfMatchesInProgress();
                        break;
                    case '5':
                        Console.WriteLine("Thank you for using our app. Hope to see you again soon!");
                        return;
                    default:
                        Console.WriteLine("Chosen action do not exist. Please try again...");
                        break;

                }
                Console.Clear();
            }
        }
    }
}
