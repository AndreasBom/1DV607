using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using BlackJack.model.mock;

namespace BlackJack.model.rules
{
    interface INewGameStrategy
    {
        bool NewGame(IDeck a_deck, Dealer a_dealer, Player a_player);
    }
}
