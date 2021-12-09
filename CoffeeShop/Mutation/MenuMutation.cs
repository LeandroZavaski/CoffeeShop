using CoffeeShop.Interfaces;
using CoffeeShop.Models;
using CoffeeShop.Type;
using CoffeeShop.Type.Input;
using GraphQL;
using GraphQL.Types;

namespace CoffeeShop.Mutation
{
    public class MenuMutation : ObjectGraphType
    {
        public MenuMutation(IMenu menuService)
        {
            Field<MenuType>("createMenu",
                arguments: new QueryArguments(new QueryArgument<MenuInputType> { Name = "menu" }),
                resolve: context =>
                {
                    var menuObject = context.GetArgument<Menu>("menu");

                    return menuService.AddMenu(menuObject);
                });
        }
    }
}
