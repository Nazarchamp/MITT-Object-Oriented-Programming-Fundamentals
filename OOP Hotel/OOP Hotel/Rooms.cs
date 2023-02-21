using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OOP_Hotel
{
    internal class Room
    {
        public string Number { get; set; }
        public uint Capacity { get; set; }
        public bool Occupied { get; set; }
        public bool IsPremium { get; set; }
        public List<Reservation> Reservations { get; set; }

        public Room(string number, uint capacity, bool isPremium = false)
        {
            Number = number;
            Capacity = capacity;
            Occupied = false;
            Reservations = new List<Reservation>();
            IsPremium = isPremium;
        }

        public void PrintReservations()
        {
            int topRange = Reservations.Count;
            if (Occupied)
            {
                Console.WriteLine($"Room {Number} is currently occupied by {Reservations[0].Client.Name}");
                topRange--;
            }
            else
                Console.WriteLine($"Room {Number} is currently not occupied");

            Console.WriteLine("Previous bookings are:");

            foreach (Reservation reservation in Reservations.GetRange(0, topRange))
            {
                Console.WriteLine($"On {reservation.Date.ToString()} room {reservation.Room.Number} was booked by {reservation.Client.Name}");
            }
        }
    }

    internal class PremiumRoom : Room
    {
        public string AdditionalAmenities { get; set; }
        public uint VIPValue { get; set; }

        public PremiumRoom(string number, uint capacity, string additionalAmenities, uint VIPValue) : base(number, capacity, true)
        {
            AdditionalAmenities = additionalAmenities;
            this.VIPValue = VIPValue;
        }
    }
}
