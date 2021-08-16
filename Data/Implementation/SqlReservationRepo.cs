using System;
using System.Collections.Generic;
using System.Linq;
using Commander.Data.DB;
using Commander.Data.Interface;
using Commander.Models;

namespace Commander.Data.Implementation
{
    public class SqlReservationRepo : IReservationRepo
    {
        private readonly CommanderContext _context;

        public SqlReservationRepo(CommanderContext context)
        {
            _context = context;
        }

        public void CreateReservation(Reservation booking)
        {

            TimeSpan openFrom = new TimeSpan(17, 0, 0);
            TimeSpan openTo = new TimeSpan(23, 0, 0);
            TimeSpan minimumStay = booking.ReservedTime + TimeSpan.FromMinutes(60);
            TimeSpan bookedFor = booking.ReservedTime;
            if (bookedFor >= openFrom || bookedFor <= openTo)
            {
                booking.ReservedTime = bookedFor;
                booking.BookingEnds = minimumStay;

                //Console.WriteLine(ts);

                foreach (int tableNumber in Enumerable.Range(1, 10))
                {
                    if (_context.Reservation.Any(x => x.TableId == tableNumber && x.ReservedTime == booking.ReservedTime && x.BookingDate == booking.BookingDate))
                    {
                        continue;

                    }
                    booking.TableId = tableNumber;
                }



                // check booking date, then check timeslot, then check table number, then check mobile number at last
                var currentBooking = _context.Reservation.Where(x =>
                    x.Mobile == booking.Mobile
                    && x.BookingDate == booking.BookingDate
                    && x.ReservedTime == booking.ReservedTime
                    && x.TableId == x.TableId).FirstOrDefault();

                if (currentBooking != null)
                {
                    throw new ApplicationException("Data Already Exists");
                }




                //    throw new ApplicationException($"{booking.Mobile} is already taken.");
                _context.Reservation.Add(booking);

            }
            else throw new ArgumentNullException("The Range should be 17:00 - 23:00");






            
        }

        public void DeleteReservation(Reservation booking)
        {
            if (booking == null)
            {
                throw new ArgumentNullException(nameof(booking));
            }
            _context.Reservation.Remove(booking);
        }

        public IEnumerable<Reservation> GetAllReservation()
        {
            return _context.Reservation.ToList();
        }

        public IEnumerable<Reservation> GetAllReservationByDate(DateTime date)
        {
            if (date != null)
            {
                // string currentDate = date.ToString("d-m-y");
                // var db = DateTime.Parse(currentDate);
                return _context.Reservation.ToList().Where(p => p.BookingDate == date);
            }
            throw new ArgumentNullException(nameof(date));
        }

        public Reservation GetReservationById(int id)
        {
            return _context.Reservation.FirstOrDefault(p => p.Id == id);
        }

        public Reservation GetReservationByMobile(string mobile)
        {
            return _context.Reservation.FirstOrDefault(p => p.Mobile == mobile);
        }

        public bool SaveChanges()
        {
            return (_context.SaveChanges() >= 0);
        }

        public void UpdateReservation(Reservation booking)
        {
            // throw new NotImplementedException();
        }

        public bool IsBookingExist(Reservation booking)
        {

            var currentBooking = _context.Reservation.Where(x =>
                x.Mobile == booking.Mobile
                && x.BookingDate == booking.BookingDate
                && x.ReservedTime == booking.ReservedTime
                && x.TableId == x.TableId).FirstOrDefault();
            if(currentBooking == null)
            {
                return false;
            }
            return true;
        }

        

        public void CheckTimeRange(Reservation booking)
        {
            try
            {
                TimeSpan openFrom = new TimeSpan(17, 0, 0);
                TimeSpan openTo = new TimeSpan(23, 0, 0);
                TimeSpan minimumStay = booking.ReservedTime + TimeSpan.FromMinutes(360);
                TimeSpan bookedFor = booking.ReservedTime;
                if (bookedFor >= openFrom || bookedFor <= openTo)
                {
                    booking.ReservedTime = bookedFor;
                    booking.BookingEnds = minimumStay;

                }
            }
            catch (Exception)
            {
                throw new ApplicationException("Our fine dinning starts from 17:00 to 23:00");
            }
        }
    }
}
