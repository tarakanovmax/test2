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
    /// Логика взаимодействия для OrderPage.xaml
    /// </summary>
    public partial class OrderPage : Page
    {
        
        public OrderPage()
        {
            InitializeComponent();
          

            
            DGridOrder.ItemsSource = DataBase.GetContext().Order.ToList();
        }

        private void redOrder_click(object sender, RoutedEventArgs e)
        {
            Manager.MainFrame.Navigate(new AddOrderPage((sender as Button).DataContext as Order));

        }
        private void TextBoxt_Search(object sender, TextChangedEventArgs e)

        {
            try
            {
                DGridOrder.ItemsSource = DataBase.GetContext().Order.Where(p => p.OrderStatus == TBoxSearch.Text || p.OrderStatus.Contains(TBoxSearch.Text)).ToList();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message.ToString());
            }
        }

        private void AddOrder_Click(object sender, RoutedEventArgs e)
        {
            Manager.MainFrame.Navigate(new AddOrderPage(null));
        }

        private void DelOrder_Click(object sender, RoutedEventArgs e)
        {
            var OrderForremoving = DGridOrder.SelectedItems.Cast<Order>().ToList();
            if(MessageBox.Show($"Вы Действительно хотите удалить следющие {OrderForremoving.Count} элементов?", "Внимание", 
                MessageBoxButton.YesNo, MessageBoxImage.Question) == MessageBoxResult.Yes)
            {
                try
                {

                    DataBase.GetContext().Order.RemoveRange(OrderForremoving);
                    DataBase.GetContext().SaveChanges();
                    MessageBox.Show("Успешно удалено");
                    DGridOrder.ItemsSource = DataBase.GetContext().Order.ToList();
                }
                catch(Exception ex)
                {
                    MessageBox.Show(ex.Message.ToString());
                }
            }
        }

        private void Order_Isvisiblity(object sender, DependencyPropertyChangedEventArgs e)
        {
            if (Visibility == Visibility.Visible)
            {
                DataBase.GetContext().ChangeTracker.Entries().ToList().ForEach(p=> p.Reload());
                DGridOrder.ItemsSource = DataBase.GetContext().Order.ToList();

            }
        }
    }
}
