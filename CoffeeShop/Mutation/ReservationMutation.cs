using CoffeeShop.Interfaces;
using CoffeeShop.Models;
using CoffeeShop.Type;
using CoffeeShop.Type.Input;
using GraphQL;
using GraphQL.Types;

namespace CoffeeShop.Mutation
{
    public class ReservationMutation : ObjectGraphType
    {
        public ReservationMutation(IReservation reservationService)
        {
            Field<ReservationType>("createReservation",
                arguments: new QueryArguments(new QueryArgument<ReservationInputType> { Name = "reservation" }),
                resolve: context =>
                {
                    var reservationObject = context.GetArgument<Reservation>("reservation");

                    return reservationService.AddReservation(reservationObject);
                });
        }
    }
}
