using CoffeeShop.Interfaces;
using CoffeeShop.Models;
using GraphQL.Types;

namespace CoffeeShop.Type
{
    public class MenuType : ObjectGraphType<Menu>
    {
        public MenuType(ISubMenu subMenuService)
        {
            Field(f => f.Id);
            Field(f => f.Name);
            Field(f => f.ImageUrl);
            Field<ListGraphType<SubMenuType>>("subMenus", resolve: context => { return subMenuService.GetSubMenus(context.Source.Id); });
        }
    }
}
