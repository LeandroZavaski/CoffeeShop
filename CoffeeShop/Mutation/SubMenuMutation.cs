using CoffeeShop.Interfaces;
using CoffeeShop.Models;
using CoffeeShop.Type;
using CoffeeShop.Type.Input;
using GraphQL;
using GraphQL.Types;

namespace CoffeeShop.Mutation
{
    public class SubMenuMutation : ObjectGraphType
    {
        public SubMenuMutation(ISubMenu subMenuService)
        {
            Field<SubMenuType>("createSubMenu",
                arguments: new QueryArguments(new QueryArgument<SubMenuInputType> { Name = "subMenu" }),
                resolve: context =>
                {
                    var subMenuObject = context.GetArgument<SubMenu>("subMenu");

                    return subMenuService.AddSubMenu(subMenuObject);
                });
        }
    }
}
