using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlackJack.model
{
    interface IPublisher
    {
        void Subscribe(ISubscriber subscriber);
        void Notify(Card card);
    }
}
