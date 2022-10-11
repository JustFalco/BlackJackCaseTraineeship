using Xunit;
using BlackJack_BackEnd_Controllers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BlackJack_BackEnd_Models;

namespace BlackJack_BackEnd_Controllers.Tests
{
	public class NewGameTests
	{
		[Fact()]
		public void NewGameTest_NoPlayerGiven_ShouldThrowError()
		{
			//Arrange
			GameController _sut = new GameController();
			Player p = null;

			//Assert

			Assert.Throws<ArgumentNullException>(() => _sut.NewGame(p));
		}

		[Fact()]
		public void NewGameTest_PlayerGiven_ShouldReturnGameWithPlayerDealerAndCardDeck()
		{
			//Arrange
			GameController _sut = new GameController();
			Player p = new Player
			{
				Email = "falco"
			};

			//Act
			Game resultGame = _sut.NewGame(p);

			//Assert
			Assert.Equal(p.Email, resultGame.Player.Email);
			Assert.NotNull(resultGame.Cards);
			Assert.NotNull(resultGame.Dealer);
		}
	}
}