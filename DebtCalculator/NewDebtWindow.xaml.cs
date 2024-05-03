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
    /// TODO:
    /// </summary>


    public partial class NewDebtWindow : Window
    {
        DebtManager manager = ((App)Application.Current).Manager;

        public NewDebtWindow()
        {
            InitializeComponent();
        }

        private void addDebtButton_Click(object sender, RoutedEventArgs e)
        {
            string name = nameTextBox.Text;
            int debtType = debtTypeComboBox.SelectedIndex;
            
            if (double.TryParse(amountTextBox.Text, out double amount) && amount > 0) 
            {
                if (float.TryParse(APRTextBox.Text, out float apr) && apr > 0)
                {
                    if (debtTypeComboBox.SelectedIndex > 2) 
                    { 
                        if (int.TryParse(LoanLengthTextBox.Text, out int length) && length > 0) //above index 3 is mortgages and other "loans" with payment terms
                        {
                            Debt temp = new(name, amount, apr, debtType, length);
                            manager.AddDebt(temp);
                            ClearInputs();
                            MessageBox.Show("Your debt has been successfully added");
                        }
                        else
                        {
                            MessageBox.Show("Loan Length is Required for this Account Type. \nPlease fill in the corresponding field");
                        }
                    } 
                    else if (debtTypeComboBox.SelectedIndex >= 0 && debtTypeComboBox.SelectedIndex < 3)
                    {
                        Debt temp = new(name, amount, apr, debtType, 0);
                        manager.AddDebt(temp);
                        ClearInputs();
                        MessageBox.Show("Your debt has been successfully added");
                    } else
                    {
                        MessageBox.Show("Please select an account type from the dropdown menu");
                    }
                }
                else
                {
                    MessageBox.Show("Please enter a valid APR (Greater than 0, less than 100)." +
                                    "\nShould be in the form of X.XX");
                }
            } else
            {
                MessageBox.Show("Please enter a non-zero, positive number." +
                                "\nShould be in the format of XXXX.XX");
            }

        }

        private void ClearInputs()
        {
            nameTextBox.Text = string.Empty;
            amountTextBox.Text = string.Empty;
            APRTextBox.Text = string.Empty;
            debtTypeComboBox.SelectedIndex = -1;  
            LoanLengthTextBox.Text = string.Empty;
        }

        private void amountTextBox_TextChanged(object sender, TextChangedEventArgs e)
        {

        }
    }
}
