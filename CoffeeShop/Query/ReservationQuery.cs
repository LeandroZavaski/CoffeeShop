using CoffeeShop.Interfaces;
using CoffeeShop.Type;
using GraphQL.Types;

namespace CoffeeShop.Query
{
    public class ReservationQuery : ObjectGraphType
    {
        public ReservationQuery(IReservation reservationService)
        {
            Field<ListGraphType<ReservationType>>("reservations", resolve: context => { return reservationService.GetReservations(); });
        }
    }
}
