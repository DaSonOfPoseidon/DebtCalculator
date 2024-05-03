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
    /// Interaction logic for AccountWindow.xaml
    /// </summary>
    public partial class AccountWindow : Window
    {
        DebtManager manager = ((App)Application.Current).Manager;
        public AccountWindow()
        {
            InitializeComponent(); 
            FillInfo();
        }

        private void deleteButton_Click(object sender, RoutedEventArgs e)
        {
            int indexS = accountListBox.SelectedIndex;
            
            manager.DeleteDebt(indexS);

            FillInfo();
        }

        private void FillInfo() { 
            accountListBox.Items.Clear();
            totalInterestTextBox.Clear();


            double total = 0;
            foreach (var item in manager.DebtList)
            {
                accountListBox.Items.Add(item.ToString());
                total += item.MonthlyInterest;
            }

            totalInterestTextBox.Text = total.ToString("C");
            MinimumPaymentTextBox.Text = manager.MinimumPayment.ToString("C");
        }

        private void accountListBox_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            int indexS = accountListBox.SelectedIndex;
            Debt temp = manager.DebtList[indexS];

            AccountMonthlyInterestLabel.Content = $"{temp.Name}'s Interest";
            AccountMontlyPaymentLabel.Content = $"{temp.Name}'s Payment";

            AccountMonthlyInterestTextBox.Text = temp.MonthlyInterest.ToString("C");
            AccountMontlyPaymentTextBox.Text = temp.MinimumMonthlyPayment.ToString("C");
        }

    }
}
