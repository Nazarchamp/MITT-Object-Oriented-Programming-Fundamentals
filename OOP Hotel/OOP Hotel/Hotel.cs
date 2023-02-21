using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OOP_Hotel
{
    internal class Hotel
    {
        public string Name { get; set; }
        public string Address { get; set; }
        public List<Room> Rooms { get; set; }
        public List<Client> Clients { get; set; }
        public List<Reservation> Reservations { get; set; }

        private uint runningId;
        private uint runningVIPId;

        public Hotel(string name, string address)
        {
            Name = name;
            Address = address;
            Rooms = new List<Room>();
            Clients = new List<Client>();
            Reservations = new List<Reservation>();
        }

        string StringifyRoomNumber(int number)
        {
            return Name.Substring(0, 3) + number.ToString(); 
        }

        public Client CreateClient(string name, string email, string creditCard)
        {
            Client tempClient = new Client(runningId++, name, email, creditCard);
            Clients.Add(tempClient);
            return tempClient;
        }

        public VIPClient CreateClient(string name, string email, string creditCard, int baseVIPPoints)
        {
            VIPClient tempClient = new VIPClient(runningId++, name, email, creditCard, runningVIPId++, baseVIPPoints);
            Clients.Add(tempClient);
            return tempClient;
        }

        public Room CreateRoom(int roomNumber, uint capacity)
        {
            Room tempRoom = new Room(StringifyRoomNumber(roomNumber), capacity);
            Rooms.Add(tempRoom);
            return tempRoom;
        }

        public PremiumRoom CreateRoom(int roomNumber, uint capacity, string additionalAmenities, uint VIPValue)
        {
            PremiumRoom tempRoom = new PremiumRoom(StringifyRoomNumber(roomNumber), capacity, additionalAmenities, VIPValue);
            Rooms.Add(tempRoom);
            return tempRoom;
        }

        public void ReserveRoom(Room room, Client client, uint occupants)
        {
            if (room.Occupied)
            {
                throw new ArgumentException("Room is currently occupied");
            }
            if(room.Capacity < occupants)
            {
                throw new ArgumentException("Too many occupants for room size");
            }

            room.Occupied = true;
            Reservation tempReservation = new Reservation(DateTime.Now, occupants, true, room, client);
            Reservations.Add(tempReservation);
            room.Reservations.Add(tempReservation);
            client.Reservations.Add(tempReservation);

            Console.WriteLine();

            if(client.IsVIP && room.IsPremium)
            {
                ((VIPClient)client).VIPPoints += (int)((PremiumRoom)room).VIPValue;
            }
        }

        public void CheckoutRoom(Client client)
        {
            client.Reservations[client.Reservations.Count - 1].IsCurrent = false;
            client.Reservations[client.Reservations.Count - 1].Room.Occupied = false;
        }

        public void CheckoutRoom(Room room)
        {
            room.Occupied = false;
            room.Reservations[room.Reservations.Count - 1].IsCurrent = false;
        }
    }
}
