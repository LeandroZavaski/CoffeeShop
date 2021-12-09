using CoffeeShop.Models;
using GraphQL.Types;

namespace CoffeeShop.Type
{
    public class ReservationType : ObjectGraphType<Reservation>
    {
        public ReservationType()
        {
            Field(f => f.Id);
            Field(f => f.Name);
            Field(f => f.Phone);
            Field(f => f.TotalPeople);
            Field(f => f.Email);
            Field(f => f.Date);
            Field(f => f.Time);
        }
    }
}
