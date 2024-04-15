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
    /// Логика взаимодействия для addmusic.xaml
    /// </summary>
    public partial class addmusic : Page
    {
        private Music _currenttour = new Music();
        private int SelectedAlbum;
        private int SelectedExecuor;
        public addmusic(Music selected)
        {
            InitializeComponent();
            if (selected != null)
                _currenttour = selected;
            DataContext = _currenttour;
            cmb.ItemsSource = Studiya_zvukozapisiEntities.GetContext().Execuor.ToList();
            cmbb.ItemsSource = Studiya_zvukozapisiEntities.GetContext().Album.ToList();
        }

        private void cmb_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (cmb.SelectedItem is Execuor FIO)
            {
                SelectedExecuor = FIO.ExecutorID;
            }
        }

        private void cmbb_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (cmbb.SelectedItem is Album AlbumTitle)
            {
                SelectedAlbum = AlbumTitle.AlbumID;
            }
        }

        private void BtnSave_Click(object sender, RoutedEventArgs e)
        {
            StringBuilder errors = new StringBuilder();
            if (string.IsNullOrWhiteSpace(Convert.ToString(_currenttour.ExecuorID)))
                errors.AppendLine("Укажите Альбом");
            if (string.IsNullOrWhiteSpace(Convert.ToString(_currenttour.AlbumID)))
                errors.AppendLine("Укажите статус");
            if (string.IsNullOrWhiteSpace(Convert.ToString(_currenttour.Author)))
                errors.AppendLine("Укажите Дату");
            if (string.IsNullOrWhiteSpace(Convert.ToString(_currenttour.Genre)))
                errors.AppendLine("Укажите Дату");



            if (errors.Length > 0)
            {
                MessageBox.Show(errors.ToString());
                return;
            }
            _currenttour.AlbumID = SelectedAlbum;
            _currenttour.ExecuorID = SelectedExecuor;
            if (_currenttour.MusicID == 0)
            { Studiya_zvukozapisiEntities.GetContext().Music.Add(_currenttour); }




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
