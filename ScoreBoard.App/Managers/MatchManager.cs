using ScoreBoard.App.Concrete;
using ScoreBoard.Domain.Entity;

namespace ScoreBoard.App.Managers
{
    public class MatchManager
    {
        private readonly MenuActionService _actionService;
        private MatchService _matchService;

        public MatchManager(MenuActionService actionService, MatchService matchService)
        {
            _matchService = matchService;
            _actionService = actionService;
        }
        public int AddNewMatch()
        {
            Console.WriteLine("\nPlease type home team name:\n");
            var homeTeam = Console.ReadLine();
            Console.WriteLine("\nPlease type away team name:\n");
            var awayTeam = Console.ReadLine();
            var lastId = _matchService.GetLastId();
            Match match = new Match(lastId + 1, homeTeam, awayTeam); //sprawdzić czy nazwy są okej?
            _matchService.AddItem(match);
            return match.Id;
        }
        public void RemoveMatch()
        {
            int matchId = 0;

            Console.WriteLine("\nPlease select match to remove:\n");
            _matchService.ShowAllMatches();
            var matchToDelete = Console.ReadLine();
            Int32.TryParse(matchToDelete, out matchId);
            _matchService.DeleteMatchById(matchId);

        }

        public void FinishMatch()
        {
            int matchId = 0;

            Console.WriteLine("\nPlease select match that came to an end:\n");
            _matchService.ShowAllMatchesInProgress();
            var matchFinished = Console.ReadLine();
            Int32.TryParse(matchFinished, out matchId);
            _matchService.MarkMatchAsFinished(matchId);

        }

        public void SummaryOfMatchesInProgress()
        {
            Console.WriteLine("\nSummary of games in progress\n");
            _matchService.ShowAllMatchesInProgress();
            Console.WriteLine("\nPress any key to continue...\n");
            Console.ReadKey();

        }

    }
}
