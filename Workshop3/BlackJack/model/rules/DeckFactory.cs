using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlackJack.model.mock
{
    class DeckFactory
    {

        public IDeck GetDeck()
        {
            return new Deck();
            //return new FakeDeck();
        }
    }
}
