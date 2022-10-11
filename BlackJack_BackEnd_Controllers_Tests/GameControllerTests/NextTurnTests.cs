using Xunit;
using BlackJack_BackEnd_Controllers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BlackJack_BackEnd_Models;
using Utils;
using BlackJackCaseTraineeship.Utils;

namespace BlackJack_BackEnd_Controllers.Tests
{
	public class NextTurnTests
	{
		[Fact()]
		public void NextTurn_NormalGameWithNewPlayer_ShouldReturnTurntypeDEALALLTURN()
		{
			//Arrange
			GameController _sut = new GameController();
			Game testGame = new Game();
			TurnTypes expectedTurnType = TurnTypes.DEALALLTURN;

			//Act
			TurnTypes? actualTurnType = _sut.NextTurn(testGame);

			//Assert
			Assert.Equal(expectedTurnType, actualTurnType);
		}

		[Fact()]
		public void NextTurn_NormalGameWithPlayerBusted_ShouldReturnTurntypeDEALERTURN()
		{
			//Arrange
			GameController _sut = new GameController();
			Game testGame = new Game();
			testGame.Player.IsBusted = true;
			TurnTypes expectedTurnType = TurnTypes.DEALERTURN;

			//Act
			TurnTypes? actualTurnType = _sut.NextTurn(testGame);

			//Assert
			Assert.Equal(expectedTurnType, actualTurnType);
		}

		[Fact()]
		public void NextTurn_NormalGameWithPlayerBustedAndDealerHasScoreOf20_ShouldReturnTurntypeFINALTURN()
		{
			//Arrange
			GameController _sut = new GameController();
			Game testGame = new Game();
			testGame.Player.IsBusted = true;


			Card tenCard = new Card
			{
				Value = 10,
				Color = CardColor.BLACK,
				Type = CardType.CLUBS
			};


			testGame.Dealer.Hand.Add(tenCard);
			testGame.Dealer.Hand.Add(tenCard);
			TurnTypes expectedTurnType = TurnTypes.FINALTURNS;

			//Act
			TurnTypes? actualTurnType = _sut.NextTurn(testGame);

			//Assert
			Assert.Equal(expectedTurnType, actualTurnType);
		}

		[Fact()]
		public void NextTurn_GameWithNullPlayer_ShouldThrowError()
		{
			//Arrange
			GameController _sut = new GameController();
			Game testGame = new Game();

			testGame.Player = null;

			//Assert
			Assert.Throws<ArgumentNullException>(() => _sut.NextTurn(testGame));
		}

		[Fact()]
		public void NextTurn_GameWithNullDealer_ShouldThrowError()
		{
			//Arrange
			GameController _sut = new GameController();
			Game testGame = new Game();

			testGame.Dealer = null;

			//Assert
			Assert.Throws<ArgumentNullException>(() => _sut.NextTurn(testGame));
		}

		[Fact()]
		public void NextTurn_NullGame_ShouldThrowError()
		{
			//Arrange
			GameController _sut = new GameController();
			Game testGame = null;


			//Assert
			Assert.Throws<ArgumentNullException>(() => _sut.NextTurn(testGame));
		}
	}
}