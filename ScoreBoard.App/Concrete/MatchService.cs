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
            int viewId = 0;

            foreach (var match in Items.OrderByDescending(p => (p.HomeTeamScore + p.AwayTeamScore)).ThenByDescending(p => p.Id))
            {
                if (!(match.Finished))
                {
                    viewId++;
                    UpdateTmpId(match, viewId);
                    Console.WriteLine($"{match.TmpId}. {match.HomeTeam} {match.HomeTeamScore} - {match.AwayTeam} {match.AwayTeamScore}");
                }
            }
        }

        public int CountAllMatchesInProgress()
        {
            int count = Items.Count(p => p.Finished == false);
            return count;
        }

        public void DeleteMatch(Match match)
        {
            RemoveItem(match);
        }

        public void MarkMatchAsFinished(Match match)
        {
            match.Finished = true;
        }
        public Match GetMatchById(int matchId)
        {
            foreach (var match in Items)
            {
                if (match.Id == matchId)
                {
                    return match;
                }
            }
            return null;
        }

        public void UpdateTmpId(Match match, int tmpId)
        {
            match.TmpId = tmpId;
        }

        public int GetMatchIdByTmpId(int TmpId)
        {
            foreach (var match in Items)
            {
                if (match.TmpId == TmpId && match.Finished == false)
                {
                    return match.Id;
                }
            }
            return 0;
        }
    }
}
