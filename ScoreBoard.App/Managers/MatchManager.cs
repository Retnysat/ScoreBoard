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
        public int StartNewMatch()
        {
            Console.WriteLine("\nPlease type home team name:\n");
            var homeTeam = Console.ReadLine();
            Console.WriteLine("\nPlease type away team name:\n");
            var awayTeam = Console.ReadLine();
            return AddNewMatch(homeTeam, awayTeam);
        }

        public int AddNewMatch(string homeTeam, string awayTeam)
        {
            var lastId = _matchService.GetLastId();
            Match match = new Match(lastId + 1, homeTeam, awayTeam);
            _matchService.AddItem(match);
            return match.Id;
        }

        public void RemoveMatch()
        {
            if (_matchService.CountAllMatchesInProgress() <= 0)
            {
                Console.WriteLine("\nThere is no match in progress!\n");
                Console.WriteLine("Press any key to continue...\n");
                Console.ReadKey();
                return;
            }

            Console.WriteLine("\nDeleting match!\n");

            Match matchToDelete = ChooseMatchFromList();
            if (matchToDelete == null)
                return;
            DeleteMatch(matchToDelete);

        }

        public void DeleteMatch(Match match)
        {
            _matchService.DeleteMatch(match);
        }

        public void MarkMatchAsFinished(Match match)
        {
            _matchService.MarkMatchAsFinished(match);
        }

        public void FinishMatch()
        {
            if (_matchService.CountAllMatchesInProgress()<=0)
            {
                Console.WriteLine("\nThere is no match in progress!\n");
                Console.WriteLine("Press any key to continue...\n");
                Console.ReadKey();
                return;
            }

            Console.WriteLine("\nFinishing match!\n");

            Match matchFinished = ChooseMatchFromList();
            if (matchFinished == null)
                return;

            MarkMatchAsFinished(matchFinished);
        }

        public void SummaryOfMatchesInProgress()
        {
            if (_matchService.CountAllMatchesInProgress()<=0)
            {
                Console.WriteLine("\nThere is no match in progress!\n");
                Console.WriteLine("Press any key to continue...\n");
                Console.ReadKey();
                return;
            }

            Console.WriteLine("\nSummary of games in progress\n");
            _matchService.ShowAllMatchesInProgress();
            Console.WriteLine("\nPress any key to continue...\n");
            Console.ReadKey();
        }

        public Match GetMatchByStringId(string id)
        {
            int matchId = 0;

            if (!Int32.TryParse(id, out matchId))
            {
                Console.WriteLine("\nCould not find proper match. Match should be chosen by a identify number.\n");
                return null;
            }
            else
            {
                var match = _matchService.GetMatchById(matchId);
                return match;
            }
        }

        public Match GetMatchByStringTmpId(string id)
        {
            int matchId = 0;
            int tmpId = 0;

            if (!Int32.TryParse(id, out tmpId))
                return null;

            matchId = _matchService.GetMatchIdByTmpId(tmpId);
            var match = _matchService.GetMatchById(matchId);
            return match;

        }

        public Match ChooseMatchFromList()
        {
            Console.WriteLine("\nPlease select a match:\n");
            Console.WriteLine("\n0. Go back to main menu");
            _matchService.ShowAllMatchesInProgress();

            string matchToUpdate = Console.ReadLine();
            if (matchToUpdate.Trim() == "0")
                return null;
            Match match = GetMatchByStringTmpId(matchToUpdate);

            while (match == null)
            {
                Console.WriteLine("\nMatch do not exist! Make sure that you are typing a number and specific number exists on the list!");
                Console.WriteLine("Please try to choose proper match again (or type 0 to go back to main menu)...\n");
                matchToUpdate = Console.ReadLine();
                if (matchToUpdate.Trim() == "0")
                    return null;
                match = GetMatchByStringTmpId(matchToUpdate);
            }

            return match;
        }

        public void ChangeMatchScore()
        {
            if (_matchService.CountAllMatchesInProgress()<=0)
            {
                Console.WriteLine("\nThere is no match in progress!\n");
                Console.WriteLine("Press any key to continue...\n");
                Console.ReadKey();
                return;
            }

            Console.WriteLine("\nUpdating match!\n");

            Match match = ChooseMatchFromList();
            if (match == null)
                return;

            Console.WriteLine("\nPlease type new score in HomeTeam-AwayTeam format:\n");
            string NewScore = Console.ReadLine();

            UpdateMatch(match, NewScore);
        }

        public void UpdateMatch (Match match, string NewScore)
        {
            int HomeTeamScore = 0;
            int AwayTeamScore = 0;

            int DivLocation = NewScore.IndexOf("-");
            if (DivLocation < 0)
            {
                Console.WriteLine("\nScore should be in format: Home Team Score-Away Team Score and both scores should be positive numbers");
                Console.WriteLine("Please try to type a valid score again...\n");
                string NewScore2 = Console.ReadLine();
                UpdateMatch(match, NewScore2);
            }
            else
            {
                String HomeTeamScoreStr = NewScore.Substring(0, DivLocation).Trim();
                String AwayTeamScoreStr = NewScore.Substring(DivLocation + 1).Trim(); //zmienic

                if (!Int32.TryParse(HomeTeamScoreStr, out HomeTeamScore) ||
                    !Int32.TryParse(AwayTeamScoreStr, out AwayTeamScore))
                {
                    Console.WriteLine("\nHome Team Score and Away Team Score should be a positive numbers");
                    Console.WriteLine("Please try to type a valid score again...\n");
                    string NewScore2 = Console.ReadLine();
                    UpdateMatch(match, NewScore2);
                }
                else
                {
                    if (HomeTeamScore < 0 || AwayTeamScore <0)
                    {
                        Console.WriteLine("\nScore should be in format: Home Team Score-Away Team Score and both scores should be positive numbers");
                        Console.WriteLine("Please try to type a valid score again...\n");
                        string NewScore2 = Console.ReadLine();
                        UpdateMatch(match, NewScore2);
                    }
                    else
                    {
                        match.HomeTeamScore = HomeTeamScore;
                        match.AwayTeamScore = AwayTeamScore;
                    }

                }
            }
        }
    }
}
