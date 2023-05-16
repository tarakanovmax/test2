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
    /// Логика взаимодействия для RolePage.xaml
    /// </summary>
    public partial class RolePage : Page
    {
        public RolePage()
        {
            InitializeComponent();
            DGridRole.ItemsSource = DataBase.GetContext().Role.ToList();
        }

        private void RedRole_click(object sender, RoutedEventArgs e)
        {
            Manager.MainFrame.Navigate(new AddRolePage((sender as Button).DataContext as Role));
        }

        private void AddRole_click(object sender, RoutedEventArgs e)
        {
            Manager.MainFrame.Navigate(new AddRolePage(null));
        }

        private void DelRole_click(object sender, RoutedEventArgs e)
        {
            var RoleForremoving = DGridRole.SelectedItems.Cast<Role>().ToList();

            if(MessageBox.Show($"Вы действительно хотите удалить следующие {RoleForremoving.Count()} элементов?", "Внимание",
                MessageBoxButton.YesNo, MessageBoxImage.Question) == MessageBoxResult.Yes)
            {
                try
                {
                    DataBase.GetContext().Role.RemoveRange(RoleForremoving);
                    DataBase.GetContext().SaveChanges();
                    MessageBox.Show("Успешно удалено");
                    DGridRole.ItemsSource = DataBase.GetContext().Role.ToList();
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message.ToString());
                }
            }
        }

        private void RoleIsvisiblity(object sender, DependencyPropertyChangedEventArgs e)
        {
            if (Visibility == Visibility.Visible)
            {
                DataBase.GetContext().ChangeTracker.Entries().ToList().ForEach(p => p.Reload());
                DGridRole.ItemsSource = DataBase.GetContext().Role.ToList();
            }
        }

        private void Search_text(object sender, TextChangedEventArgs e)
        {
            DGridRole.ItemsSource = DataBase.GetContext().Role.Where(p => p.RoleName == TBoxSerch.Text || p.RoleName.Contains(TBoxSerch.Text)).ToList();
        }
    }
}
