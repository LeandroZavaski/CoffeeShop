using CoffeeShop.Models;
using GraphQL.Types;

namespace CoffeeShop.Type
{
    public class SubMenuType : ObjectGraphType<SubMenu>
    {
        public SubMenuType()
        {
            Field(f => f.Id);
            Field(f => f.Name);
            Field(f => f.Description);
            Field(f => f.ImageUrl);
            Field(f => f.Price);
            Field(f => f.MenuId);
        }
    }
}
