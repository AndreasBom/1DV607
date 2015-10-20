using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlackJack.model.rules
{
    class SoftSeventeenHitStrategy : IHitStrategy
    {
        private const int g_hitLimit = 17;

        //Hit if score is 17 or less 
        public bool DoHit(model.Player a_dealer)
        {
            var cards = a_dealer.GetHand();
            
            if(a_dealer.CalcScore() == g_hitLimit)
            {
                foreach(Card card in cards)
                {
                    if (card.GetValue() == Card.Value.Ace && a_dealer.CalcScore() - 11 == 6)
                    {
                        return true;
                    }
                }
            }
            
            return a_dealer.CalcScore() < g_hitLimit;
        }
    }
}
