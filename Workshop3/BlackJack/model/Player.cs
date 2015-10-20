using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using BlackJack.model.rules;
using BlackJack.model;

namespace BlackJack.model
{
    class Player : BaseGameStrategy, IPublisher
    {
        private List<Card> m_hand = new List<Card>();
        private List<ISubscriber> _subscribers = new List<ISubscriber>();

        public void Subscribe(ISubscriber subscriber)
        {
            if(_subscribers.Contains(subscriber) == false)
            {
                _subscribers.Add(subscriber);
            }
            
        }

        public void Notify(Card card)
        {
            _subscribers.ForEach(s=>s.DealerDealsNewCard(card));
        }

        public void DealCard(Card a_card)
        {   
            Notify(a_card);
            m_hand.Add(a_card);
        }

        public IEnumerable<Card> GetHand()
        {
            return m_hand.Cast<Card>();
        }

        public void ClearHand()
        {
            m_hand.Clear();
        }

        public void ShowHand()
        {
            foreach (Card c in GetHand())
            {
                c.Show(true);
            }
        }

        public int CalcScore()
        {
            int[] cardScores = new int[(int)model.Card.Value.Count] { 2, 3, 4, 5, 6, 7, 8, 9, 10, 10, 10, 10, 11 };

            int score = 0;

            foreach(Card c in GetHand()) {
                if (c.GetValue() != Card.Value.Hidden)
                {
                    score += cardScores[(int)c.GetValue()];
                }
            }

            if (score > 21)
            {
                foreach (Card c in GetHand())
                {
                    if (c.GetValue() == Card.Value.Ace && score > 21)
                    {
                        score -= 10;
                    }
                }
            }

            return score;
        }
    }
}
