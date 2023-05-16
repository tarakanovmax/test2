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

namespace podgotovka
{
    /// <summary>
    /// Логика взаимодействия для Window1.xaml
    /// </summary>
    public partial class Window1 : Window
    {
        public Window1()
        {
            InitializeComponent();
            Manager.MainFrame = MainFrame;
           
            
            
        }

        private void Usr_click(object sender, RoutedEventArgs e)
        {
            MainFrame.Navigate(new UserPage());
        }

        private void Order_click(object sender, RoutedEventArgs e)
        {
            MainFrame.Navigate(new OrderPage());
        }

        private void Role_click(object sender, RoutedEventArgs e)
        {
            MainFrame.Navigate(new RolePage());
        }
    }
}
