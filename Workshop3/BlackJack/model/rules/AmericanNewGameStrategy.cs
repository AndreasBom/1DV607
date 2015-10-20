using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using BlackJack.model.mock;

namespace BlackJack.model.rules
{
    class AmericanNewGameStrategy : BaseGameStrategy, INewGameStrategy
    {



        public bool NewGame(IDeck a_deck, Dealer a_dealer, Player a_player)
        {
            //Refactoring. Inherit method from BaseGameStrategy
            GetCardAndDeal(a_deck, a_player, true);
            GetCardAndDeal(a_deck, a_dealer, true);
            GetCardAndDeal(a_deck, a_player, true);
            GetCardAndDeal(a_deck, a_dealer, false);



            //Card c;

            //c = a_deck.GetCard();
            //c.Show(true);
            //a_player.DealCard(c);

            //c = a_deck.GetCard();
            //c.Show(true);
            //a_dealer.DealCard(c);

            //c = a_deck.GetCard();
            //c.Show(true);
            //a_player.DealCard(c);

            //c = a_deck.GetCard();
            //c.Show(false);
            //a_dealer.DealCard(c);

            return true;
        }
    }
}
