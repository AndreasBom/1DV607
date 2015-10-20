using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlackJack.model.mock
{
    class FakeDeck : IDeck
    {

        /*
         * returns a fake deck, so cards and score can be manipulated for testing purpouse. Change deck in mock/DeckFactory::GetDeck()
         */

        List<Card> m_cards;

        public FakeDeck()
        {
            m_cards = new List<Card>();

            SoftSeventeenFakeDeck();
            //StandOnEqual();
        }

        private void StandOnEqual()
        {
            //Fake deck that gets equal score
            
            //Dealer
            
            Card d1 = new Card(Card.Color.Hearts, Card.Value.King);
            Card d2 = new Card(Card.Color.Hearts, Card.Value.Five);
            Card d3 = new Card(Card.Color.Spades, Card.Value.Three);
            

            //Player
            Card p1 = new Card(Card.Color.Hearts, Card.Value.Ace);
            Card p2 = new Card(Card.Color.Diamonds, Card.Value.Four);
            Card p3 = new Card(Card.Color.Spades, Card.Value.Three);

            AddCard(p1);
            AddCard(d1);
            AddCard(p2);
            AddCard(d2);
            AddCard(p3);
            AddCard(d3);
        }

        private void SoftSeventeenFakeDeck()
        {
            //Fake deck gives dealer ace, three, three and two if player stands after 2 cards
           
            //Dealer
            Card d1 = new Card(Card.Color.Hearts, Card.Value.Ace);
            Card d2 = new Card(Card.Color.Hearts, Card.Value.Two);
            Card d3 = new Card(Card.Color.Hearts, Card.Value.Two);
            Card d4 = new Card(Card.Color.Hearts, Card.Value.Two);
            Card d5 = new Card(Card.Color.Spades, Card.Value.Three);

            //Player
            Card p1 = new Card(Card.Color.Hearts, Card.Value.Queen);
            Card p2 = new Card(Card.Color.Diamonds, Card.Value.Seven);

            AddCard(p1);
            AddCard(d1);
            AddCard(p2);
            AddCard(d2);
            AddCard(d3);
            AddCard(d4);
            AddCard(d5);
        }

        public Card GetCard()
        {
            Card c = m_cards.First();
            m_cards.RemoveAt(0);
            return c;

        }

        public void AddCard(Card a_c)
        {
            m_cards.Add(a_c);
        }

        public IEnumerable<Card> GetCards()
        {
            return m_cards.Cast<Card>();
        }

        private void Shuffle()
        {
            Random rnd = new Random();

            for (int i = 0; i < 1017; i++)
            {
                int index = rnd.Next() % m_cards.Count;
                Card c = m_cards.ElementAt(index);
                m_cards.RemoveAt(index);
                m_cards.Add(c);
            }
        }
    }
}
