using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BlackJack.model.mock;

namespace BlackJack.model.rules
{
    abstract class BaseGameStrategy
    {
        protected void GetCardAndDeal(IDeck a_deck, Player a_player, bool showCard)
        {
            Card c;

            c = a_deck.GetCard();
            c.Show(showCard);
            a_player.DealCard(c);
        }

    }
}
