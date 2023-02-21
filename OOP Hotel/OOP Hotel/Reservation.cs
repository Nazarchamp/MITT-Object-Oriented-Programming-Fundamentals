using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OOP_Hotel
{
    internal class Reservation
    {
        public DateTime Date { get; set; }
        public uint Occupants { get; set; }
        public bool IsCurrent { get; set; }
        public Room Room { get; set; }
        public Client Client { get; set; }

        public Reservation(DateTime date, uint occupants, bool isCurrent, Room room, Client client)
        {
            Date = date;
            Occupants = occupants;
            IsCurrent = isCurrent;
            Room = room;
            Client = client;
        }
    }
}
