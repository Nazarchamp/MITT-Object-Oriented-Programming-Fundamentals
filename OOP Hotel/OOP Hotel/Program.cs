using static System.Console;

namespace OOP_Hotel
{
    internal static class Program
    {
        static void Main(string[] args)
        {
            Hotel hotel = new Hotel("Mille Collines", "2 KN 6 Ave, Kigali, Rwanda");

            Client n1 = hotel.CreateClient("Nazar Viznytsya", "viz.nazar@gmail.com", "1234 1234 1234 1234");
            VIPClient n2 = hotel.CreateClient("Nazar Viznytsya Jr", "viz.nazar.jr@gmail.com", "4321 1234 1234 1234", 0);

            Room r1 = hotel.CreateRoom(101, 1);
            Room r2 = hotel.CreateRoom(201, 1, "Room Service", 500);

            hotel.ReserveRoom(r1, n1, 1);
            hotel.ReserveRoom(r2, n2, 1);

            WriteLine(r1.Occupied);
            WriteLine(r2.Occupied);
            r1.PrintReservations();
            WriteLine();

            hotel.CheckoutRoom(n1);
            hotel.CheckoutRoom(r2);

            WriteLine(r1.Occupied);
            WriteLine(r2.Occupied);
            WriteLine(n2.VIPPoints);
            WriteLine();

            n1.PrintReservations();
            WriteLine();
            r1.PrintReservations();
        }
    }
}
