using BlackJackCaseTraineeship.Models;
using BlackJackCaseTraineeship.Utils;

namespace BlackJackCaseTraineeship.Controllers
{
	public static class GameController
	{
		public static void DealPlayer(Player player, CardDeck cardDeck)
		{
			player.AddCard(cardDeck.GetFirstActiveCardOnDeck());
		}

		public static void DealDealer(Dealer dealer, CardDeck cardDeck)
		{
			Card dealerCard = cardDeck.GetFirstActiveCardOnDeck();
			if (dealer.Cards.Count == 2)
			{
				dealerCard.IsHidden = true;
			}
			dealer.AddCard(dealerCard);
		}

		public static void ClearHands(List<Player> playersInRound)
		{
			foreach (Player player in playersInRound)
			{
				player.IsBusted = false;
				player.ClearHand();
			}
		}
	}
}
