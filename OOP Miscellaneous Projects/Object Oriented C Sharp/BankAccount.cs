using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Object_Oriented_C_Sharp
{
    internal class BankAccount
    {
        private const int MonthsInYear = 12;

        private readonly int _id;
        public int ID => _id;

        private double _balance;
        public double Balance => _balance;

        private static double _interestRate = 4.5;

        private readonly DateTime _dateCreated;
        public DateTime DateCreated => _dateCreated;

        public BankAccount()
        {
            _id = 0;
            _balance = 0;
            _dateCreated = DateTime.Now;
        }

        public BankAccount(int id, double _balance) 
            : this()
        {
            this._id = id;
            this._balance = _balance;
        }

        public static double GetMonthly_interestRate()
        {
            return _interestRate / MonthsInYear;
        }

        public double GetMonthlyInterest()
        {
            return Math.Round(_balance * (_interestRate / 100) / MonthsInYear, 2);
        }

        public void Deposit(double amount)
        {
            _balance += amount;
        }

        public void Withdraw(double amount)
        {
            if(_balance >= amount)
            {
                _balance -= amount;
            }
            else
            {
                throw new ArgumentException("Insufficent funds!");
            }
        }
    }
}
