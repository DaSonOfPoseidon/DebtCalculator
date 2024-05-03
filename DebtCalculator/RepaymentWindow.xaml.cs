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
            LoadData();
        }

        void LoadData()
        {
            MinimumPaymentLabel.Content = manager.MinimumPayment.ToString("C");
            TotalDebtLabel.Content = manager.TotalDebt.ToString("C");
            //
        }
    }
}
