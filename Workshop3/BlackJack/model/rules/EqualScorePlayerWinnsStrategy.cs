using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlackJack.model.rules
{
    class EqualScorePlayerWinnsStrategy : IWhoIsWinnerStrategy
    {
        public bool IsDealerWinner(int a_playerScore, int a_dealerScore, int g_maxScore)
        {
            if (a_playerScore > g_maxScore)
            {
                return true;
            }
            else if (a_dealerScore > g_maxScore)
            {
                return false;
            }
            return a_dealerScore > a_playerScore;
        }
    }
}
