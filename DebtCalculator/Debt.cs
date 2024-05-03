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
        private int loanLength;
        public int debtType;
        /*
         * 0 Credit Card
         * 1 Student Debt
         * 2 Medical Debt
         * 3 Mortgage
         * 4 Personal Loan
         * 5 Car Loan
         * 6 Payment Plan
         * 7 
         * 8
         * 9
        */

        public Debt(string name, double debtAmt, float apr, int debtType, int length) 
        {
            Name = name;
            Amount = debtAmt;
            APR = apr;
            this.debtType = debtType;
            LoanLength = length;
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

        public float APR
        {
            get { return apr; }
            set
            {
                apr = value;
            }
        }//APR is X.XX%

        public double MonthlyInterest //read-only
        {
            get { return ((apr / 1200) * Amount); }
        }

        public double MinimumMonthlyPayment //read-only
        {
            get 
            {
                if (debtType < 3) { return MonthlyInterest + (Amount * 0.02); }
                else { return GetMinPayment(); }
            } //CC, not loans, update accordingly
        }

        public override string ToString()
        {
            return $"{Name}: {Amount.ToString("C")} * {APR.ToString()} = {MonthlyInterest.ToString("C")}";
        }

        public string ToCSVFormat()
        {
            return Name + "," + Amount.ToString() + "," + APR.ToString() + "," + debtType.ToString() + "," + LoanLength.ToString();
        }

        public int LoanLength
        {
            get
            {
                if (debtType > 2)
                {
                    return loanLength;
                } 
                else 
                {
                    return PayoffTime();
                }
            }
            set 
            {
                loanLength = value;
            }
        }

        private int PayoffTime()
        {
            int count = 0;
            double tempAmt = Amount;
            while (tempAmt > 0)
            {
                count++;
                tempAmt -= MinimumMonthlyPayment;
            }

            return count;
        }

        private double GetMinPayment()
        {
            double monthlyIR = apr / 1200;

            double num = (monthlyIR * Amount) / (1 - Math.Pow(1 + monthlyIR, (double)loanLength * -1));

            return num;
        }
    }

}
