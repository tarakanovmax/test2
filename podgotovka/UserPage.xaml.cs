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
    /// Логика взаимодействия для UserPage.xaml
    /// </summary>
    public partial class UserPage : Page
    {
        public UserPage()
        {
            InitializeComponent();

            
                

            DGridUSer.ItemsSource = DataBase.GetContext().User.ToList();
        }

        private void reduser_click(object sender, RoutedEventArgs e)
        {
            Manager.MainFrame.Navigate(new AddUserPage((sender as Button).DataContext as User));

        }

        private void addUser_click(object sender, RoutedEventArgs e)
        {
            Manager.MainFrame.Navigate(new AddUserPage(null));
        }

        private void delUser_click(object sender, RoutedEventArgs e)
        {
            var UserforRemoving = DGridUSer.SelectedItems.Cast<User>().ToList();

            if(MessageBox.Show($"Вы действительно хотите удалить следующие {UserforRemoving.Count()} элементов", "Внимание",
                MessageBoxButton.YesNo,MessageBoxImage.Question) == MessageBoxResult.Yes)
            {
                try
                {
                    DataBase.GetContext().User.RemoveRange(UserforRemoving);
                    DataBase.GetContext().SaveChanges();
                    MessageBox.Show("Успешное удаление данных");
                    DGridUSer.ItemsSource = DataBase.GetContext().User.ToList();
                }
                catch(Exception ex)
                {
                    MessageBox.Show(ex.Message.ToString());
                }
            }
        }

        private void UserIsvisiblity(object sender, DependencyPropertyChangedEventArgs e)
        {
            if (Visibility == Visibility.Visible)
                DataBase.GetContext().ChangeTracker.Entries().ToList().ForEach(p => p.Reload());
            DGridUSer.ItemsSource = DataBase.GetContext().User.ToList();
        }

        private void Search_TBox_Canged(object sender, TextChangedEventArgs e)
        {
            try
            {
                DGridUSer.ItemsSource = DataBase.GetContext().User.Where(p => p.UserName == TBoxSearch.Text || p.UserName.Contains(TBoxSearch.Text)).ToList();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message.ToString());
            }
        }
    }
}
