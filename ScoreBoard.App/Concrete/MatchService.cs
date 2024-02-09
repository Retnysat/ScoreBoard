using ScoreBoard.App.Common;
using ScoreBoard.Domain.Entity;

namespace ScoreBoard.App.Concrete
{
    public class MatchService : BaseService<Match>
    {

        public void ShowAllMatches()
        {
            foreach (var match in Items.OrderBy(p => p.Id))
            {
                Console.WriteLine($"{match.Id}. {match.HomeTeam} {match.HomeTeamScore} - {match.AwayTeam} {match.AwayTeamScore}");
            }
        }

        public void ShowAllMatchesInProgress()
        {
            foreach (var match in Items.OrderBy(p => p.Id))
            {
                if (!(match.Finished)) Console.WriteLine($"{match.Id}. {match.HomeTeam} {match.HomeTeamScore} - {match.AwayTeam} {match.AwayTeamScore}");
            }
        }

        public void DeleteMatchById(int matchId)
        {
            foreach (var match in Items)
            {
                if (match.Id == matchId)
                {
                    RemoveItem(match);
                    break;
                }
            }
        }

        public void MarkMatchAsFinished(int matchId)
        {
            foreach (var match in Items)
            {
                if (match.Id == matchId)
                {
                    match.Finished = true;
                }
            }
        }
    }
}
