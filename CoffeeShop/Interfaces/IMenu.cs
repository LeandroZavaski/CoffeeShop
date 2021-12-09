using CoffeeShop.Models;
using System.Collections.Generic;

namespace CoffeeShop.Interfaces
{
    public interface IMenu
    {
        List<Menu> GetMenus();
        Menu AddMenu(Menu menu);
    }
}
