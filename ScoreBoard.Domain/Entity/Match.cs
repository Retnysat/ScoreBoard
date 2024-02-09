using ScoreBoard.Domain.Common;

namespace ScoreBoard.Domain.Entity
{
    public class Match : BaseEntity
    {
        public string HomeTeam { get; set; }
        public int HomeTeamScore { get; set; }
        public string AwayTeam { get; set; }
        public int AwayTeamScore { get; set; }
        public Boolean Finished { get; set; } = false;

        public Match(int id, string homeTeam, int homeTeamScore, string awayTeam, int awayTeamScore)
        {
            Id = id;
            HomeTeam = homeTeam;
            HomeTeamScore = homeTeamScore;
            AwayTeam = awayTeam;
            AwayTeamScore = awayTeamScore;
        }

        public Match(int id, string homeTeam, string awayTeam)
        {
            Id = id;
            HomeTeam = homeTeam;
            HomeTeamScore = 0;
            AwayTeam = awayTeam;
            AwayTeamScore = 0;
        }


    }
}
