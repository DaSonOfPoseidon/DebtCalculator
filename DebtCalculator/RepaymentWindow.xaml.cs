using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;

namespace DebtCalculator
{
    /// <summary>
    /// Interaction logic for RepaymentWindow.xaml
    /// </summary>
    public partial class RepaymentWindow : Window
    {
        DebtManager manager = ((App)Application.Current).Manager;
        public RepaymentWindow()
        {
            InitializeComponent();
            LoadPage();
        }

        void LoadPage()
        {
            foreach (Debt temp in manager.DebtList)
            {
                AccountComboBox.Items.Add(temp.Name);
            }
        }

        private void AccountComboBox_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            int indexS = AccountComboBox.SelectedIndex;

            if (indexS != -1)
            {
                FillData(indexS);
            }
            else
            {
                MessageBox.Show("Combo Box got called at -1");
            }
        }

        void FillData(int index)
        {
            Debt temp = manager.DebtList[index];

            NameLabel.Content = "Name: " + temp.Name;
            AmountLabel.Content = "Balance: " + temp.Amount.ToString("C");
            aprLabel.Content = "Interest Rate: " + temp.APR.ToString();
            interestLabel.Content = "Monthly Interest: " + temp.MonthlyInterest.ToString("C");
            MaxPayoffLabel.Content = "Latest Payoff Date:\n" + PayOff(temp.MinimumMonthlyPayment, index).ToString("mm/dd/yyyy");
            MinimumPaymentLabel.Content = "Min. Monthly Payment:\n" + temp.MinimumMonthlyPayment.ToString("C");
        }

        public DateTime PayOff(double monthlyPayment, int index)
        {
            Debt temp = manager.DebtList[index];
            if (monthlyPayment >= 0)
            {
                double monthlyInterestRate = temp.APR / 1200;
                int months = 0;
                double remainingDebt = temp.Amount;

                while (remainingDebt > 0)
                {
                    remainingDebt = remainingDebt * (1 + monthlyInterestRate) - monthlyPayment;
                    months++;
                    if (monthlyPayment <= remainingDebt * monthlyInterestRate)
                    {
                        MessageBox.Show("Monthly payment is too low to cover the interest. Debt will never be paid off.");
                        return DateTime.MinValue;
                    }
                }

                return DateTime.Now.AddMonths(months);
            }
            else
            {
                MessageBox.Show("Monthly payment must be greater than zero.");
                return DateTime.MinValue;
            }
        }

        public double MonthlyPayments(DateTime endDate, int index) //returns 0 when an exception occurs
        {
            Debt temp = manager.DebtList[index];
            DateTime now = DateTime.Now;
            double monthlyPayment = 0;

            if (endDate >= DateTime.Now)
            {
                int totalMonths = (endDate.Year - now.Year) * 12 + endDate.Month - now.Month;

                if (totalMonths >= 0)
                {
                    double monthlyInterestRate = temp.APR / 1200;
                    double divisor = Math.Pow(1 + monthlyInterestRate, totalMonths) - 1;

                    if (divisor != 0)
                    {
                        monthlyPayment = temp.Amount * (monthlyInterestRate + (monthlyInterestRate / divisor));
                    }
                    else
                    {
                        MessageBox.Show("Interest rate too low and duration too short to compute a valid monthly payment.");
                    }
                }
                else
                {
                    MessageBox.Show("The time period must be greater than zero months.");
                }
            }
            else
            {
                MessageBox.Show("End date must be later than start date.");
            }

            return Math.Ceiling(monthlyPayment);

        }

        private void paymentsButton_Click(object sender, RoutedEventArgs e)
        {
            if (double.TryParse(paymentTextBox.Text, out double amount))
            {
                if (AccountComboBox.SelectedIndex != -1) 
                {
                    DateTime timeDone = PayOff(amount, AccountComboBox.SelectedIndex);
                    if (timeDone != DateTime.MinValue) 
                    {
                        dtCalendar.SelectedDate = timeDone;
                        dtCalendar.DisplayDate = timeDone;      
                        monthsTextBox.Text = timeDone.ToString("MM/dd/yyyy");
                    }
                }
            } 
        }

        private void monthsButton_Click(object sender, RoutedEventArgs e)
        {
            if (AccountComboBox.SelectedIndex > -1)
            {
                int index = AccountComboBox.SelectedIndex;
                if (DateTime.TryParse(monthsTextBox.Text, out DateTime temp))
                {
                    double payment = MonthlyPayments(temp, index);
                    if (payment != 0)
                    {
                        paymentTextBox.Text = payment.ToString("C");
                    }
                }
                else if (DateTime.TryParse(datePicker.Text, out temp))
                {
                    double payment = MonthlyPayments(temp, index);
                    dtCalendar.SelectedDate = datePicker.SelectedDate;
                    dtCalendar.DisplayDate = datePicker.DisplayDate;

                    if (payment != 0)
                    {
                        paymentTextBox.Text = payment.ToString("C");
                        monthsTextBox.Text = temp.ToString("MM /dd/yyyy");
                    }
                }
                else
                {
                    MessageBox.Show("Either Select a date on the calender or enter a date into the months TextBox");
                }
            }
            else
            {
                MessageBox.Show("Please select an account before entering any information");
            }
            
        }

        private void Header_Loaded(object sender, RoutedEventArgs e)
        {
 
        }
    }
}
