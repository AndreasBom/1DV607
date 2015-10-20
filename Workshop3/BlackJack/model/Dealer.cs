using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using BlackJack.model.mock;

namespace BlackJack.model
{
    class Dealer : Player
    {
        private IDeck m_deck = null;
        private const int g_maxScore = 21;

        private rules.INewGameStrategy m_newGameRule;
        private rules.IHitStrategy m_hitRule;
        private rules.IWhoIsWinnerStrategy m_winnerRule;
        private DeckFactory m_deckFactory;
      


        public Dealer(rules.RulesFactory a_rulesFactory)
        {
            m_newGameRule = a_rulesFactory.GetNewGameRule();
            m_hitRule = a_rulesFactory.GetHitRule();
            m_winnerRule = a_rulesFactory.GetWinnerRule();
            m_deckFactory = new DeckFactory();
            
        }

        

        public bool NewGame(Player a_player)
        {
            if (m_deck == null || IsGameOver())
            {
                //Get a 'normal' deck of cards or get a 'fake' deck, that can be manipulated
                m_deck = m_deckFactory.GetDeck();

                ClearHand();
                a_player.ClearHand();
                return m_newGameRule.NewGame(m_deck, this, a_player);   
            }
            return false;
        }

        private bool DealCard()
        {
            //Refactoring, inherits from BaseGameStrategy
            GetCardAndDeal(m_deck, this, true);
            
            //Card c;
            //c = m_deck.GetCard();
            //c.Show(true);
            //this.DealCard(c);

            return true;
        }

        public bool Hit(Player a_player)
        {
            if (m_deck != null && a_player.CalcScore() < g_maxScore && !IsGameOver())
            {
                Card c;
                c = m_deck.GetCard();
                c.Show(true);
                a_player.DealCard(c);

                return true;

                
            }
            return false;
        }

        /******* Game::Stand *********/
        public bool Stand()
        {
            if(m_deck != null)
            {
                ShowHand();
                
                foreach(Card card in GetHand())
                {
                    card.Show(true);
                }

                while(m_hitRule.DoHit(this))
                {
                    m_hitRule.DoHit(this);
                    var c = m_deck.GetCard();
                    c.Show(true);
                    DealCard(c); 
                }
                return true;
            }

            return false;
        }

        /*******/

        public bool IsDealerWinner(Player a_player)
        {
            //if (a_player.CalcScore() > g_maxScore)
            //{
            //    return true;
            //}
            //else if (CalcScore() > g_maxScore)
            //{
            //    return false;
            //}
            //return CalcScore() >= a_player.CalcScore();

            //Strategy pattern is used
            int a_dealerScore = CalcScore();
            int a_playerScore = a_player.CalcScore();
            return m_winnerRule.IsDealerWinner(a_playerScore, a_dealerScore, g_maxScore);

        }

        
        public bool IsGameOver()
        {
            if (m_deck != null && /*CalcScore() >= g_hitLimit*/ m_hitRule.DoHit(this) != true)
            {
                return true;
            }
            return false;
        }
    }
}
