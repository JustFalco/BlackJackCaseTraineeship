using BlackJackCaseTraineeship.Utils;

namespace BlackJackCaseTraineeship.Models
{
	public class CardDeck
	{
		private List<Card> deck;
		

		public CardDeck()
		{
			deck = new List<Card>();
			CardColor color = CardColor.BLACK;
			for (int i = 0; i < 2; i++)
			{
				for (int k = 0; k < 2; k++)
				{
					for (int j = 1; j <= 13; j++)
					{
						int value = j;
						if (value > 10)
						{
							value = 10;
						}
						Card card = new Card
						{
							Value = value,
							Color = color
						};
						deck.Add(card);
					}
				}
				color = CardColor.RED;
			}
			setCardTypes();
			ShuffleDeck();
		}

		public Card getCard(int index)
		{
			return deck[index];
		}

		public List<Card> getCards
		{
			get { return deck; }
		}

		private void setCardTypes()
		{
			int count = 0;
			foreach (Card card in deck)
			{
				if (count < 13)
				{
					card.Type = CardType.CLUBS;
				}
				else if (count < 26)
				{
					card.Type = CardType.SPADES;
				}
				else if (count < 39)
				{
					card.Type = CardType.HEART;
				}
				else if (count >= 39)
				{
					card.Type = CardType.DIAMONDS;
				}

				count++;
			}
		}

		public void PrintDeck()
		{
			foreach (Card card in deck)
			{
				Console.WriteLine(card);
			}
		}

		public void ShuffleDeck()
		{
			var rnd = new Random();
			deck = deck.OrderBy(item => rnd.Next()).ToList();
		}

		public CardDeck StackAllCardDecks(List<CardDeck> cardsInGame)
		{
			CardDeck allCardsStacked = new CardDeck();
			foreach (CardDeck cardDeck in cardsInGame)
			{
				foreach (Card card in cardDeck.getCards)
				{
					allCardsStacked.deck.Add(card);
				}
			}

			allCardsStacked.ShuffleDeck();

			return allCardsStacked;
		}

		public Card? GetFirstActiveCardOnDeck()
		{
			Card card = this.deck.Where(card => card.IsActiveCard == true).First();
			card.IsActiveCard = false;
			return card;
		}
	}
}
