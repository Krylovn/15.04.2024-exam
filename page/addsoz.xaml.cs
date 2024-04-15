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
using zvuk.Class;
using zvuk.Entity;

namespace zvuk.page
{
    /// <summary>
    /// Логика взаимодействия для addsoz.xaml
    /// </summary>
    public partial class addsoz : Page
    {
        private Execuor _currentFourthPage = new Execuor();

        public addsoz(Execuor selected)
        {
            InitializeComponent();
            if (selected != null)
                _currentFourthPage = selected;
            DataContext = _currentFourthPage;
        }

        private void BtnSave_Click(object sender, RoutedEventArgs e)
        {
            StringBuilder errors = new StringBuilder();
            if (string.IsNullOrWhiteSpace(Convert.ToString(_currentFourthPage.FIO)))
                errors.AppendLine("Укажите ФИО");
            if (string.IsNullOrWhiteSpace(Convert.ToString(_currentFourthPage.Birthday)))
                errors.AppendLine("Укажите дату рождения");
            if (string.IsNullOrWhiteSpace(Convert.ToString(_currentFourthPage.Dateofdeath)))
                errors.AppendLine("Укажите дату смерти");
            if (string.IsNullOrWhiteSpace(Convert.ToString(_currentFourthPage.Adress)))
                errors.AppendLine("Укажите адрес");
            if (errors.Length > 0)
            {
                MessageBox.Show(errors.ToString());
                return;
            }
            if (_currentFourthPage.ExecutorID == 0)
                Studiya_zvukozapisiEntities.GetContext().Execuor.Add(_currentFourthPage);
            try
            {
                Studiya_zvukozapisiEntities.GetContext().SaveChanges();
                Manager.MainFrame.GoBack();
                MessageBox.Show("Успешно!");
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message.ToString());
            }
        }

        private void BtnBack_Click(object sender, RoutedEventArgs e)
        {
            Manager.MainFrame.GoBack();

        }
    }
}
