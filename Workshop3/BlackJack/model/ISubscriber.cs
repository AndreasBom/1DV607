using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlackJack.model
{
    interface ISubscriber
    {
        void DealerDealsNewCard(Card card);
    }
}
