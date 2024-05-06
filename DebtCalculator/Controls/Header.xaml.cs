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
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace DebtCalculator.Controls
{
    /// <summary>
    /// Interaction logic for Header.xaml
    /// </summary>
    public partial class Header : UserControl
    {
        public Header()
        {
            InitializeComponent();
        }

        private void BurgerMenu_Click(object sender, RoutedEventArgs e)
        {
            MenuControl.IsOpen = BurgerMenuBox.IsChecked ?? true; //IsOpen and IsChecked are linked here, default to shown
        }

        private void Home_Click(object sender, RoutedEventArgs e)
        {
            MainWindow temp = new();
            temp.Show();
            CloseAllOtherWindows(temp);
        }

        private void NewDebt_Click(object sender, RoutedEventArgs e)
        {
            NewDebtWindow temp = new();
            temp.Show();
            CloseAllOtherWindows(temp);
        }

        private void ManageAccounts_Click(object sender, RoutedEventArgs e)
        {
            AccountWindow temp = new();
            temp.Show();
            CloseAllOtherWindows(temp);
        }

        private void Repayment_Click(object sender, RoutedEventArgs e)
        {
            RepaymentWindow temp = new();
            temp.Show();
            CloseAllOtherWindows(temp);
        }

        private void CloseAllOtherWindows(Window temp) //closes any window that is not "temp" (The active window)
        {
            foreach (Window window in Application.Current.Windows)
            {
                if (window != temp)
                    window.Close();
            }
        }

        //Diagnostic Functions
        public void SetMenuVisibility(bool isVisible)
        {
            MenuControl.IsOpen = isVisible;  // Directly setting the IsOpen property of the HamburgerMenu
        }
    }
}
