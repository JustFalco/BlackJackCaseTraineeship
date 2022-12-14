using BlackJackCaseTraineeship.Utils;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlackJackCaseTraineeship.Models
{
	public class Card
	{
		private int _value;
		private CardColor _color;
		private CardType _type;
		private bool hidden;

		public bool IsHidden
		{
			get { return hidden; }
			set { hidden = value; }
		}

		public int Value
		{
			get
			{
				return _value;
			}
			set
			{
				_value = value;
			}
		}
		public CardType Type 
		{ 
			get 
			{ 
				return _type; 
			}
			set
			{
				_type = value;
			}
		}

		public CardColor Color
		{
			get
			{
				return _color;
			}
			set
			{
				_color = value;
			}
		}

		public override string? ToString()
		{
			if (hidden)
			{
				return "Hidden card";
			}
			return $"{_color} {_type} met waarde {_value}";
		}
	}
}
