using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using BlackJack.model;

namespace BlackJack.view
{
    class SimpleView : View, IView
    {
        

       
        public void DisplayWelcomeMessage()
        {
            System.Console.Clear();
            System.Console.WriteLine("Hello Black Jack World");
            System.Console.WriteLine("Type 'p' to Play, 'h' to Hit, 's' to Stand or 'q' to Quit\n");
        }


        //Implemented in abstract class 'View'
        /*
        public Menu.MenuItems GetInput()
        {
            var input = System.Console.In.Read();

            switch (input)
            {
                case 'p':
                    return Menu.MenuItems.Play;
                case 'h':
                    return Menu.MenuItems.Hit;
                case 's':
                    return Menu.MenuItems.Stand;
                case 'q':
                    return Menu.MenuItems.Quit;
                default:
                    return Menu.MenuItems.NoAction;

            }
        }*/



        public void DisplayCard(model.Card a_card)
        {
            System.Console.WriteLine("{0} of {1}", a_card.GetValue(), a_card.GetColor());
        }

        public void DisplayPlayerHand(IEnumerable<model.Card> a_hand, int a_score)
        {
            
            DisplayHand("Player", a_hand, a_score);
        }

        public void DisplayDealerHand(IEnumerable<model.Card> a_hand, int a_score)
        {
            DisplayHand("Dealer", a_hand, a_score);
            
        }

        public void PauseGame()
        {
            int timeToPause = 1500;
            int sleepInterval = 300;

            Console.Write("Dealing.");

            for (int i = 0; i <= timeToPause; i += sleepInterval)
            {
                System.Threading.Thread.Sleep(sleepInterval);
                Console.Write(".");
            }   
        }
        

        private void DisplayHand(String a_name, IEnumerable<model.Card> a_hand, int a_score)
        {
            
            System.Console.WriteLine("{0} Has: ", a_name);
            foreach (model.Card c in a_hand)
            {
                DisplayCard(c);
            }
            System.Console.WriteLine("Score: {0}", a_score);
            System.Console.WriteLine("");
            
        }

        public void DisplayGameOver(bool a_dealerIsWinner)
        {
            System.Console.Write("GameOver: ");
            if (a_dealerIsWinner)
            {
                System.Console.WriteLine("Dealer Won!");
            }
            else
            {
                System.Console.WriteLine("You Won!");
            }
            
        }

        
    }
}
