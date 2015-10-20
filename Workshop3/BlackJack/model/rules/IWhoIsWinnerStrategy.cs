using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlackJack.model.rules
{
    interface IWhoIsWinnerStrategy
    {
        bool IsDealerWinner(int a_playerScore, int a_dealerScore, int g_maxScore);
    }
}
