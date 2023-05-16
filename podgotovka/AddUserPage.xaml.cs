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
    /// Логика взаимодействия для AddUserPage.xaml
    /// </summary>
    public partial class AddUserPage : Page
    {
        private User _currentUser = new User();
        public AddUserPage(User selectedUser)
        {
            InitializeComponent();
            if(selectedUser != null)
                _currentUser = selectedUser;
            DataContext = _currentUser;
        }

        private void saveuser_click(object sender, RoutedEventArgs e)
        {
            StringBuilder errors = new StringBuilder();

            if (string.IsNullOrWhiteSpace(_currentUser.UserSurname))
                errors.AppendLine("Введите фамили польщователя");
            if (string.IsNullOrWhiteSpace(_currentUser.UserName))
                errors.AppendLine("Введите фамили польщователя");
            if (string.IsNullOrWhiteSpace(_currentUser.UserPatronymic))
                errors.AppendLine("Введите фамили польщователя");
            if (string.IsNullOrWhiteSpace(_currentUser.UserLogin))
                errors.AppendLine("Введите фамили польщователя");
            if (string.IsNullOrWhiteSpace(_currentUser.UserPassword))
                errors.AppendLine("Введите фамили польщователя");

            if(errors.Length > 0)
            {
                MessageBox.Show(errors.ToString());
                return;
            }

            if (_currentUser.UserID == 0)
                DataBase.GetContext().User.Add(_currentUser);
            try
            {
                DataBase.GetContext().SaveChanges();
                MessageBox.Show("Успешно");
                Manager.MainFrame.GoBack();
            }
            catch(Exception ex)
            {
                MessageBox.Show(ex.Message.ToString());

            }
        }

        private void backuser_click(object sender, RoutedEventArgs e)
        {
            Manager.MainFrame.GoBack();
        }
    }
}
