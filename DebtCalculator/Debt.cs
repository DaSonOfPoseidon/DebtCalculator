using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.IO;

namespace DebtCalculator
{
    public class Debt
    {
        private string name;
        private double debtAmount;
        private float apr;
        public int debtType;
        /*
         * 0
         * 1
         * 2
         * 3
         * 4
         * 5
         * 6
         * 7
         * 8
         * 9
        */

        public Debt(string name, double debtAmt, float apr, int debtType) 
        {
            Name = name;
            Amount = debtAmt;
            APR = apr;
            this.debtType = debtType;
        }

        public string Name 
        {
            get { return name; }
            set
            {
                if (value != null)
                {
                    name = value;
                }
            }
        }

        public double Amount
        {
            get { return debtAmount; }
            set
            {
                if (value > 0)
                {
                    debtAmount = value;
                }
                else
                {
                    MessageBox.Show("Debt amount cannot be less than zero or null");
                }
            }
        }

        public float APR //stores as APR / 100 (ie. APR = 3.97% would be stored as 0.0397). Returns as a percentage (ie 3.97%)
        {
            get { return apr * 100; }
            set
            {
                if (value > 0.0)
                {
                    apr = value / 100;
                }
            }
        }

        public double MonthlyInterest //read-only
        {
            get { return ((apr / 12) * Amount); }
        }

        public double MinimumMonthlyPayment //read-only
        {
            get { return MonthlyInterest + (Amount * 0.02); }
        }

        public override string ToString()
        {
            return $"{Name}: {Amount.ToString()} * {APR.ToString()} = {MonthlyInterest.ToString("F2")}";
        }

        public string ToCSVFormat()
        {
            return Name + "," + Amount.ToString() + "," + APR.ToString() + "," + debtType.ToString() ?? "0";
        }
    }

}
