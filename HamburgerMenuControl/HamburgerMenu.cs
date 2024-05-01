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

namespace HamburgerMenuControl
{
    /// <summary>
    /// </summary>
    public class HamburgerMenu : Control
    {
        public static readonly DependencyProperty IsOpenProperty = DependencyProperty.Register("IsOpen", typeof(bool), typeof(HamburgerMenu), new PropertyMetadata(true)); // (1)  

        public static readonly DependencyProperty ContentProperty = DependencyProperty.Register("Content", typeof(FrameworkElement), typeof(HamburgerMenu), new PropertyMetadata(null)); //(1)

        public bool IsOpen
        {
            get { return (bool)GetValue(IsOpenProperty);}
            set 
            { 
                SetValue(IsOpenProperty, value); 
            }
        }

        public FrameworkElement Content
        {
            get { return (FrameworkElement)GetValue(ContentProperty); }
            set { SetValue(ContentProperty, value); }
        }

        static HamburgerMenu()
        {
            DefaultStyleKeyProperty.OverrideMetadata(typeof(HamburgerMenu), new FrameworkPropertyMetadata(typeof(HamburgerMenu)));
        }
    }
}
