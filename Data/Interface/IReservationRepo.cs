using System;
using System.Collections.Generic;
using Commander.Models;

namespace Commander.Data.Interface
{
    public interface IReservationRepo
    {
        bool SaveChanges();

        IEnumerable<Reservation> GetAllReservation();
        

        Reservation GetReservationById(int id);
        Reservation GetReservationByMobile(string mobile);
        IEnumerable<Reservation> GetAllReservationByDate(DateTime date);
        void CreateReservation(Reservation booking);
        void UpdateReservation(Reservation booking);
        void DeleteReservation(Reservation booking);
        public bool IsBookingExist(Reservation booking);

        void CheckTimeRange(Reservation booking);

    }
}


