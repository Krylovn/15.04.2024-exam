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
using zvuk.Entity;

namespace zvuk.page
{
    /// <summary>
    /// Логика взаимодействия для auth.xaml
    /// </summary>
    public partial class auth : Page
    {
        public Users _currentUser = new Users();
        public string user_fio;
        public auth()
        {
            InitializeComponent();
        }
        private void BtnAutn1_Click(object sender, RoutedEventArgs e)
        {
            if (string.IsNullOrWhiteSpace(TbLogin.Text) || string.IsNullOrWhiteSpace(TbPassword.Password))
            {
                MessageBox.Show("Введите все данные!");
                return;
            }
            if (Studiya_zvukozapisiEntities.GetContext().Users.Any(x => x.Email == TbLogin.Text && x.Password == TbPassword.Password))
            {
                _currentUser = Studiya_zvukozapisiEntities.GetContext().Users.Where(b => b.Email == TbLogin.Text && b.Password == TbPassword.Password).FirstOrDefault();
                App.Current.Resources["UserInfo"] = user_fio;
                NavigationService.GetNavigationService(this).Navigate(new menu());
            }
        }
    }
}
