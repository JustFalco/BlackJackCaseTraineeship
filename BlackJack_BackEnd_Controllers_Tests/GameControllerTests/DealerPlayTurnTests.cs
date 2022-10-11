using BlackJack_BackEnd_Controllers;
using BlackJack_BackEnd_Models;
using BlackJackCaseTraineeship.Utils;

namespace BlackJack_BackEnd_Controllers.Tests
{
    public class DealerPlayTurnTests
    {
	    public DealerPlayTurnTests()
	    {

	    }

        [Fact]
        public void DealerPlayTurn_GameInput_DealerShouldHaveABustedHand()
        {
            //Arrange
	        GameController _sut = new GameController();
	        Game testGame = new Game();

	        //Act
	        testGame = _sut.DealerPlayTurn(testGame);

	        //Assert
            Assert.True(testGame.Dealer.Hand.IsBustedHand);
        }

        [Fact]
		public void DealerPlayTurn_DealerWithBlackJack_DealerShouldHaveTotalOf21AfterTurn()
        {
	        //Arrange
	        GameController _sut = new GameController();
	        Game testGame = new Game();
	        int expectedTotal = 21;

	        Card tenCard = new Card
	        {
				Value = 10,
				Color = CardColor.BLACK,
				Type = CardType.CLUBS
	        };

	        Card aceCard = new Card
	        {
		        Value = 1,
		        Color = CardColor.BLACK,
		        Type = CardType.CLUBS
			};

			testGame.Dealer.Hand.Add(tenCard);
			testGame.Dealer.Hand.Add(aceCard);

	        //Act
	        testGame = _sut.DealerPlayTurn(testGame);

	        //Assert
	        Assert.Equal(expectedTotal, testGame.Dealer.Hand.TotalCardAmount);
		}
    }
}