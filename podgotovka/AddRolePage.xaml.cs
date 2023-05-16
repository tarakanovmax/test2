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
    /// Логика взаимодействия для AddRolePage.xaml
    /// </summary>
    public partial class AddRolePage : Page
    {
        private Role _currentRole = new Role();
        public AddRolePage( Role selectedRole)
        {
            InitializeComponent();
            if(selectedRole != null)
                _currentRole = selectedRole;

            DataContext = _currentRole;
        }

        private void SaveRole_click(object sender, RoutedEventArgs e)
        {
            StringBuilder error = new StringBuilder();

            if (string.IsNullOrWhiteSpace(_currentRole.RoleName))
                error.AppendLine("Введите навание роли");

            if(error.Length > 0)
            {
                MessageBox.Show(error.ToString());
                return;
            }

            if (_currentRole.RoleID == 0)
                DataBase.GetContext().Role.Add(_currentRole);
            try
            {
                DataBase.GetContext().SaveChanges();
                MessageBox.Show("Успешное добавление данных");
                Manager.MainFrame.GoBack();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message.ToString());
            }
        }

        private void BackRole_click(object sender, RoutedEventArgs e)
        {
            Manager.MainFrame.GoBack();
        }
    }
}
