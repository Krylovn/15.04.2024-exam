using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Controls.Primitives;
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
    /// Логика взаимодействия для addalbom.xaml
    /// </summary>
    public partial class addalbom : Page
    {
        private Album _currenttour = new Album();
        private int SelectedExecuor;
      

        public addalbom(Album selected)
        {
            InitializeComponent();
            if (selected != null)
                _currenttour = selected;
            DataContext = _currenttour;
            Cmb.ItemsSource = Studiya_zvukozapisiEntities.GetContext().Execuor.ToList();

        }

        private void Cmb_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (Cmb.SelectedItem is Execuor FIO)
            {
                SelectedExecuor = FIO.ExecutorID;
            }
        }

        private void BtnSave_Click(object sender, RoutedEventArgs e)
        {
            StringBuilder errors = new StringBuilder();
            if (string.IsNullOrWhiteSpace(Convert.ToString(_currenttour.Releasedate)))
                errors.AppendLine("Укажите место");
            if (string.IsNullOrWhiteSpace(Convert.ToString(_currenttour.ExecutorID)))
                errors.AppendLine("Укажите статус");
            if (string.IsNullOrWhiteSpace(Convert.ToString(_currenttour.AlbumTitle)))
                errors.AppendLine("Укажите отель");
            if (string.IsNullOrWhiteSpace(Convert.ToString(_currenttour.Price)))
                errors.AppendLine("Укажите программу");
            if (string.IsNullOrWhiteSpace(Convert.ToString(_currenttour.Tirage)))
                errors.AppendLine("Укажите дату прибытия");
           





            if (errors.Length > 0)
            {
                MessageBox.Show(errors.ToString());
                return;
            }
            if (_currenttour.ExecutorID == 0)
            { Studiya_zvukozapisiEntities.GetContext().Album.Add(_currenttour); }
            _currenttour.ExecutorID = SelectedExecuor;
           


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
