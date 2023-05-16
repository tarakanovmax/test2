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

namespace podgotovka
{
    /// <summary>
    /// Логика взаимодействия для AddOrderPage.xaml
    /// </summary>
    public partial class AddOrderPage : Page
    {
        private Order _currentOrder = new Order();
        public AddOrderPage(Order SelectedOrder)
        {
            InitializeComponent();
            if(SelectedOrder != null)
                _currentOrder = SelectedOrder;
            DataContext = _currentOrder;
        }

        private void SaveOrder_Click(object sender, RoutedEventArgs e)
        {
            StringBuilder error = new StringBuilder();

            if (string.IsNullOrWhiteSpace(_currentOrder.OrderStatus))
                error.AppendLine("Введите статус заказа");
            if (string.IsNullOrWhiteSpace(_currentOrder.OrderPickupPoint))
                error.AppendLine("Введите пункт выдачи");

            if(error.Length > 0)
            {
                MessageBox.Show(error.ToString());
                return;
            }

            if (_currentOrder.OrderID == 0)
                DataBase.GetContext().Order.Add(_currentOrder);
            try
            {
                DataBase.GetContext().SaveChanges();
                MessageBox.Show("Добавление прошло успешно");
                Manager.MainFrame.GoBack();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message.ToString());
            }
        }

        private void Back_Click(object sender, RoutedEventArgs e)
        {
            Manager.MainFrame.GoBack();
        }
    }
}
