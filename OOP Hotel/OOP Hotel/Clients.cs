using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OOP_Hotel
{
    internal class Client
    {
        public uint ID { get; set; }
        public string Name { get; set; }
        public string Email { get; set; }
        public string CreditCard { get; set; } // Int or UInt is too small to contain all 16 Characters of a credit card
        public bool IsVIP { get; set; }
        public List<Reservation> Reservations { get; set; }

        public Client(uint id, string name, string email, string creditCard, bool isVIP = false)
        {
            ID = id;
            Name = name;
            Email = email;
            CreditCard = creditCard;
            IsVIP = isVIP;
            Reservations = new List<Reservation>();
        }

        public void PrintReservations()
        {
            int topRange = Reservations.Count;
            if (Reservations[0].IsCurrent)
            {
                Console.WriteLine($"{Name} is currently staying in room {Reservations[0].Room.Number}");
                topRange--;
            }
            else
                Console.WriteLine($"{Name} is not currently staying in a room");

            Console.WriteLine("Previous appointemnts booked are:");

            foreach(Reservation reservation in Reservations.GetRange(0, topRange))
            {
                Console.WriteLine($"On {reservation.Date.ToString()} {Name} booked room {reservation.Room.Number}");
            }
        }
    }

    internal class VIPClient : Client
    {
        public uint VIPNumber { get; set; }
        public int VIPPoints { get; set; }

        public VIPClient(uint id, string name, string email, string creditCard, uint VIPNumber, int baseVIPPoints) : base(id, name, email, creditCard, true)
        {
            VIPPoints = baseVIPPoints;
            VIPNumber = this.VIPNumber;
        }
    }
}
