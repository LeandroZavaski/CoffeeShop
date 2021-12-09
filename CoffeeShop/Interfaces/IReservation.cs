using CoffeeShop.Models;
using System.Collections.Generic;

namespace CoffeeShop.Interfaces
{
    public interface IReservation
    {
        List<Reservation> GetReservations();
        Reservation AddReservation(Reservation reservation);
    }
}
