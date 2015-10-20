using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using BlackJack.view;
using BlackJack.model;

namespace BlackJack.controller
{
    class PlayGame : ISubscriber
    {

        private IView view;

        public void DealerDealsNewCard(Card card)
        {
            view.PauseGame();
            view.DisplayCard(card);
        }

        public bool Play(model.Game a_game, view.IView a_view)
        {

            view = a_view;

            a_view.DisplayWelcomeMessage();

            
            a_view.DisplayDealerHand(a_game.GetDealerHand(), a_game.GetDealerScore());
            a_view.DisplayPlayerHand(a_game.GetPlayerHand(), a_game.GetPlayerScore());

            if (a_game.IsGameOver())
            {
                a_view.DisplayGameOver(a_game.IsDealerWinner());
            }

            var input = a_view.GetInput();

            if (input == Menu.MenuItems.Play)
            {
                a_game.NewGame();
            }
            else if (input == Menu.MenuItems.Hit)
            {
                a_game.Hit();
            }
            else if (input == Menu.MenuItems.Stand)
            {
                a_game.Stand();
            }

            return input != Menu.MenuItems.Quit;
        }
    }
}
