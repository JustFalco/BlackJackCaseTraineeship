using BlackJackCaseTraineeship.Models;
using BlackJackCaseTraineeship.Utils;
using static BlackJackCaseTraineeship.Utils.TurnTypes;

namespace BlackJackCaseTraineeship.Controllers
{
	public class TurnController
	{
		private List<Player> playersInRound;
		private int turnCount;

		public int TurnCount
		{
			get { return turnCount; }
			set { turnCount = value; }
		}

		public List<Player> PlayersInRound
		{
			get
			{
				return playersInRound;
			}
			set
			{
				playersInRound = value;
			}
		}

		public void NextTurn(TurnTypes turnTypes)
		{
			switch (turnTypes)
			{
				case DEALALLTURN:
					throw new NotImplementedException();
					break;
				case PLAYERTURN:
					throw new NotImplementedException();
					break;
				case DEALERTURN:
					throw new NotImplementedException();
					break;
				case FINALTURNS:
					throw new NotImplementedException();
					break;
			}
			turnCount++;
		}

		private void DealToAll()
		{
			//All players including the dealer get a card
			throw new NotImplementedException();
		}

		private void PlayerTurn()
		{
			//player can choose to hit, stay, double, split
			throw new NotImplementedException();
		}

		private void DealerTurn()
		{
			//Dealer has to pick a card if total is below 17
			throw new NotImplementedException();
		}

		private void FinalTurn()
		{
			//Players that are not busted get their share of points, then all states get reset
			throw new NotImplementedException();
		}
	}
}
