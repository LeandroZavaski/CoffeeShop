using CoffeeShop.Mutation;
using CoffeeShop.Query;
using Microsoft.Extensions.DependencyInjection;
using System;

namespace CoffeeShop.Schema
{
    public class RootSchema : GraphQL.Types.Schema
    {
        public RootSchema(IServiceProvider serviceProvider) : base(serviceProvider)
        {
            Query = serviceProvider.GetRequiredService<RootQuery>();
            Mutation = serviceProvider.GetRequiredService<RootMutation>();
        }
    }
}
