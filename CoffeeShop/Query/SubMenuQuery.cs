using CoffeeShop.Interfaces;
using CoffeeShop.Type;
using GraphQL;
using GraphQL.Types;

namespace CoffeeShop.Query
{
    public class SubMenuQuery : ObjectGraphType
    {
        public SubMenuQuery(ISubMenu subMenuService)
        {
            Field<ListGraphType<SubMenuType>>("subMenus", resolve: context => { return subMenuService.GetSubMenus(); });

            Field<SubMenuType>("subMenusById",
                arguments: new QueryArguments(new QueryArgument<IntGraphType> { Name = "id" }),
                resolve: context =>
                {
                    return subMenuService.GetSubMenus(context.GetArgument<int>("id"));
                });
        }
    }
}
