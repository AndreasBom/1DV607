using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlackJack.view
{
    abstract class View
    {

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
        }
    }
}
