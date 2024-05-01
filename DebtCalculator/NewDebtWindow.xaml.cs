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
                    Debt temp = new Debt(name, amount, apr, debtType);
                    manager.AddDebt(temp);

                    ClearInputs();
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
        }
    }
}
