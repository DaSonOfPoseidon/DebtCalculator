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
    /// Add "Delete all info" Button
    /// </summary>
    public partial class ProfileWindow : Window
    {
        DebtManager manager = ((App)Application.Current).Manager;
        public ProfileWindow()
        {
            InitializeComponent();
        }

        private void backButton_Click(object sender, RoutedEventArgs e)
        {
            MainWindow temp = new();

            foreach (Window window in Application.Current.Windows)
            {
                if (window != temp)
                    window.Close();
            }
   
            temp.Show();

        }
    }
}
