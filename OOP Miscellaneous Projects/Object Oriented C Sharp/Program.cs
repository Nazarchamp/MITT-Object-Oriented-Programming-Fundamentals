using static System.Console;
using static Object_Oriented_C_Sharp.Location;
using Object_Oriented_C_Sharp;

namespace Object_Oriented_C_Sharp {
    internal static class Program
    {
        static void Main(string[] args)
        {
            //TestPolygons();
            //TestLocation();
            //TestBankAccount();
        }
        static void TestPolygons()
        {
            RegularPolygon rp1 = new RegularPolygon(6, 4);
            WriteLine($"{rp1.N} sided polygon, of lengths {rp1.Side} at ({rp1.X}, {rp1.Y}) has a perimeter of {rp1.GetPerimeter()} units and an area of {rp1.GetArea()} units squared");
            RegularPolygon rp2 = new RegularPolygon(10, 4, 5.6, 7.8);
            WriteLine($"{rp2.N} sided polygon, of lengths {rp2.Side} at ({rp2.X}, {rp2.Y}) has a perimeter of {rp2.GetPerimeter()} units and an area of {rp2.GetArea()} units squared");

        }
        static void TestLocation()
        {
            WriteLine("Enter rows of matrix, with elements sperated by ', ' use 'end' on a blank line to end the input");
            string inp = ReadLine();
            List<int[]> arrayList = new List<int[]>();

            while (inp != "end")
            {
                string[] inpArr = inp.Split(", ");
                int[] intInpArr = new int[inpArr.Length];

                for (int i = 0; i < inpArr.Length; i++)
                {
                    intInpArr[i] = int.Parse(inpArr[i]);
                }

                arrayList.Add(intInpArr.ToArray());

                inp = ReadLine();
            }

            int[,] matrix = new int[arrayList.Count, arrayList[0].Length];

            for (int i = 0; i < arrayList.Count; i++)
            {
                for (int j = 0; j < arrayList[i].Length; j++)
                {
                    matrix[i, j] = arrayList[i][j];
                }
            }

            LocateLargest(matrix);

            WriteLine($"The maximum value in your array is {MaxValue} located at [{Row},{Col}]");

        }

        static void TestBankAccount()
        {
            BankAccount acc = new BankAccount(1122, 20000);
            acc.Withdraw(2500);
            acc.Deposit(3000);
            WriteLine($"Account {acc.ID}, created on {acc.DateCreated.ToShortDateString()} has a balance of ${acc.Balance} with monthly interest of ${acc.GetMonthlyInterest()}");
        }
    }
}
