using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BlackJack_BackEnd_Models;
using Utils;

namespace BlackJack_BackEnd_Controllers
{
	public class UserController
	{
		public Player GetPlayer(string email)
		{
			return new Player
			{
				Email = email
			};
		}

		public Game PlayTurn(Decision decision, Game game)
		{
			//TODO make for multiple players
			foreach (Hand hand in game.Player.Hands)
			{
				if (!hand.IsBustedHand)
				{
					switch (decision)
					{
						case Decision.HIT:
							game.Player.Hit(hand, game.Cards.GetFirstActiveCardOnDeck());
							break;
						case Decision.STAND:
							game.Player.Stand();
							break;
						case Decision.SPLIT:
							game.Player.Split(hand, game.Cards);
							break;
						case Decision.DOUBLE:
							game.Player.Double(hand, game.Cards.GetFirstActiveCardOnDeck());
							break;
					}
				}
				
			}

			return game;
		}

		public Game PlayerDrawHand(Game game)
		{
			game.Player.DrawCard(game.Player.Hands.First(), game.Cards, true);
			game.Player.DrawCard(game.Player.Hands.First(), game.Cards, true);
			return game;
		}

		public Game DealerDrawHand(Game game)
		{
			game.Dealer.DrawCard(game.Dealer.Hand, game.Cards, true);
			game.Dealer.DrawCard(game.Dealer.Hand, game.Cards, false);
			return game;
		}

		public bool CheckIfPlayerHandWonFromDealerHand(Hand playerHand, Dealer dealer)
		{
			//TODO uitbereiden
			if (playerHand.IsBustedHand)
			{
				return false;
			}
			else if (dealer.IsBusted || dealer.Hand.IsBustedHand)
			{
				return true;
			}
			else if (playerHand.TotalCardAmount > dealer.Hand.HighestTotalAmound)
			{
				return true;
			}
			else
			{
				return false;
			}
		}
	}
}
