using FluentAssertions;
using ScoreBoard.App.Concrete;
using ScoreBoard.App.Managers;
using ScoreBoard.Domain.Entity;
using Xunit;


namespace ScoreBoard.Tests
{
    public class Tests
    {
        [Fact]
        public void AddingNewMatch()
        {
            //Arange
            var mock = new Moq.Mock<MatchService>();
            var manager = new MatchManager(new MenuActionService(), mock.Object);

            //Act
            var matchId = manager.AddNewMatch("Wisla Plock", "Industria Kielce");
            Match match = manager.GetMatchByStringId(matchId.ToString());

            //Assert
            matchId.Should().BeGreaterThan(0);
            match.Should().NotBeNull();
        }

        [Fact]
        public void FinishingMatch()
        {
            //Arange
            var mock = new Moq.Mock<MatchService>();
            var manager = new MatchManager(new MenuActionService(), mock.Object);
            var matchId = manager.AddNewMatch("Wisla Plock", "Industria Kielce");
            Match match = manager.GetMatchByStringId(matchId.ToString());

            //Act
            manager.MarkMatchAsFinished(match);

            //Assert
            match.Should().NotBeNull();
            match.Finished.Should().BeTrue();
        }

        [Fact]
        public void RemovingMatch()
        {
            //Arange
            var mock = new Moq.Mock<MatchService>();
            var manager = new MatchManager(new MenuActionService(), mock.Object);
            var matchId = manager.AddNewMatch("Wisla Plock", "Industria Kielce");
            Match match = manager.GetMatchByStringId(matchId.ToString());

            //Act
            manager.DeleteMatch(match);
            match = manager.GetMatchByStringId(matchId.ToString());

            //Assert
            match.Should().BeNull();
        }

        [Fact]
        public void UpdatingMatch()
        {
            //Arange
            var mock = new Moq.Mock<MatchService>();
            var manager = new MatchManager(new MenuActionService(), mock.Object);
            var matchId1 = manager.AddNewMatch("Wisla Plock", "Industria Kielce");
            Match match1 = manager.GetMatchByStringId(matchId1.ToString());
            var matchId2 = manager.AddNewMatch("Legia Warszawa", "Lech Poznan");
            Match match2 = manager.GetMatchByStringId(matchId2.ToString());

            //Act
            manager.UpdateMatch(match1, "3-5");
            manager.UpdateMatch(match2, " 2 - 1 ");

            //Assert
            match1.Should().NotBeNull();
            match1.HomeTeamScore.Should().Be(3);
            match1.AwayTeamScore.Should().Be(5);
            match2.Should().NotBeNull();
            match2.HomeTeamScore.Should().Be(2);
            match2.AwayTeamScore.Should().Be(1);
        }

    }
}