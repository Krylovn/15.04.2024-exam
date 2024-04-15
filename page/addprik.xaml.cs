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
    /// Логика взаимодействия для addprik.xaml
    /// </summary>
    public partial class addprik : Page
    {
        private Order _currenttour = new Order();
        private int SelectedAlbum;
        private int SelectedStatus;
      
        public addprik(Order selected)
        {
            InitializeComponent();
            if (selected != null)
                _currenttour = selected;
            DataContext = _currenttour;
            CmbTitl.ItemsSource = Studiya_zvukozapisiEntities.GetContext().Status.ToList();
            CmbTitle.ItemsSource = Studiya_zvukozapisiEntities.GetContext().Album.ToList();

        }

        private void CmbTitle_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (CmbTitle.SelectedItem is Album AlbumTitle)
            {
                SelectedAlbum = AlbumTitle.AlbumID;
            }
        }

        private void CmbTitl_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (CmbTitl.SelectedItem is Status Name)
            {
                SelectedStatus = Name.StatusID;
            }
        }

        private void BtnBack_Click(object sender, RoutedEventArgs e)
        {
            Manager.MainFrame.GoBack();

        }

        private void BtnSave_Click(object sender, RoutedEventArgs e)
        {
            StringBuilder errors = new StringBuilder();
            if (string.IsNullOrWhiteSpace(Convert.ToString(_currenttour.AlbumID)))
                errors.AppendLine("Укажите Альбом");
            if (string.IsNullOrWhiteSpace(Convert.ToString(_currenttour.StatusID)))
                errors.AppendLine("Укажите статус");
            if (string.IsNullOrWhiteSpace(Convert.ToString(_currenttour.Dateoffeeding)))
                errors.AppendLine("Укажите Дату");
           


            if (errors.Length > 0)
            {
                MessageBox.Show(errors.ToString());
                return;
            } 
            _currenttour.AlbumID = SelectedAlbum;
            _currenttour.StatusID = SelectedStatus;
            if (_currenttour.OrderID == 0)
            { Studiya_zvukozapisiEntities.GetContext().Order.Add(_currenttour); }
           
         


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
    }
}
