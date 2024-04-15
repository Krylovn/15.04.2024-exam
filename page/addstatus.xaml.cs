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
    /// Логика взаимодействия для addstatus.xaml
    /// </summary>
    public partial class addstatus : Page
    {
        private Status _currentFourthPage = new Status();

        public addstatus(Status selected)
        {
            InitializeComponent();
            InitializeComponent();
            if (selected != null)
                _currentFourthPage = selected;
            DataContext = _currentFourthPage;
        }

        private void BtnSave_Click(object sender, RoutedEventArgs e)
        {
            StringBuilder errors = new StringBuilder();
            if (string.IsNullOrWhiteSpace(Convert.ToString(_currentFourthPage.Name)))
                errors.AppendLine("Укажите название");
            if (errors.Length > 0)
            {
                MessageBox.Show(errors.ToString());
                return;
            }
            if (_currentFourthPage.StatusID == 0)
                Studiya_zvukozapisiEntities.GetContext().Status.Add(_currentFourthPage);
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
