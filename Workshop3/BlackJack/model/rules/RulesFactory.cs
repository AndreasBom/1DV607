﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace BlackJack.model.rules
{
    class RulesFactory
    {
        public IHitStrategy GetHitRule()
        {
            //return new SoftSeventeenHitStrategy();
            return new BasicHitStrategy();
        }

        public INewGameStrategy GetNewGameRule()
        {
            return new AmericanNewGameStrategy();
        }

        public IWhoIsWinnerStrategy GetWinnerRule()
        {
            //return new EqualScorePlayerWinnsStrategy();
            return new EqualScoreDealerWinnsStrategy();
        }
    }
}
