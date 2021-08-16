using System;
using System.Collections.Generic;
using Commander.Data.Interface;
using Commander.Models;

namespace Commander.Data.Implementation
{
    public class MockReservationRepo : IReservationRepo // call the name of the interface to implement
    {
        public void CheckTimeRange(Reservation booking)
        {
            throw new NotImplementedException();
        }

        public void CreateReservation(Reservation cmd)
        {
            throw new NotImplementedException();
        }

        public bool CreateTableNumber(Reservation booking)
        {
            throw new NotImplementedException();
        }

        public void DeleteReservation(Reservation cmd)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<Reservation> GetAllReservation()
        {
            var bookings = new List<Reservation>
            {
                new Reservation {Id =0, BookingName= "Prabesh Pokharel", Mobile= "0451109809", Email = "praveas@gmail.com", AddComments ="For special Day" },
                new Reservation {Id =1, BookingName= "XYZ Gamer", Mobile= "0451109809", Email = "praveas1@gmail.com", AddComments ="For special Day" },
                new Reservation {Id =2, BookingName= "Samsung", Mobile= "0451109809", Email = "prave2as@gmail.com", AddComments ="For special Day" }
            };

            return bookings;
        }

        public IEnumerable<Reservation> GetAllReservationByDate(DateTime date)
        {
            throw new NotImplementedException();
        }

        public Reservation GetReservationById(int id)
        {
            return new Reservation { Id = 0, BookingName = "Prabesh Pokharel", Mobile = "0451109809", Email = "praveas@gmail.com", AddComments = "For special Day" };
        }

        public Reservation GetReservationByMobile(Reservation cmd)
        {
            throw new NotImplementedException();
        }

        public Reservation GetReservationByMobile(string mobile)
        {
            throw new NotImplementedException();
        }

        public bool IsBookingExist(Reservation booking)
        {
            throw new NotImplementedException();
        }

        public bool SaveChanges()
        {
            throw new NotImplementedException();
        }

        public void UpdateReservation(Reservation cmd)
        {
            throw new NotImplementedException();
        }
    }

}

/*
 * var commands = new List<Command>
            {
                new Command { Id = 0, HowTo = "Boil an egg", Line = "Boil water", Platform = "Kettle & Pan" },
                new Command { Id = 1, HowTo = "Cut Bread", Line = "Get a Knife", Platform = "Knife & Chopping Board" },
                new Command { Id = 2, HowTo = "Make a cup of tea", Line = "Place teabag to cup", Platform = "Cup & Kettle" }
            };

return commands;

*/