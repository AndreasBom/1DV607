using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlackJack.model.mock
{
    interface IDeck
    {
        Card GetCard();
        void AddCard(Card a_c);
        IEnumerable<Card> GetCards();
    }
}
