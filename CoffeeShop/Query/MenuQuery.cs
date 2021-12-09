using CoffeeShop.Interfaces;
using CoffeeShop.Type;
using GraphQL.Types;

namespace CoffeeShop.Query
{
    public class MenuQuery : ObjectGraphType
    {
        public MenuQuery(IMenu menuService)
        {
            Field<ListGraphType<MenuType>>("menus", resolve: context => { return menuService.GetMenus(); });
        }
    }
}
