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
    /// Логика взаимодействия для music.xaml
    /// </summary>
    public partial class music : Page
    {
        public music()
        {
            InitializeComponent();
            DGridgorod.ItemsSource = Studiya_zvukozapisiEntities.GetContext().Music.ToList();

        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            Manager.MainFrame.Navigate(new menu());

        }

        private void del_Click(object sender, RoutedEventArgs e)
        {
            var elementsForRemoving = DGridgorod.SelectedItems.Cast<Music>().ToList();

            if (MessageBox.Show($"Вы точно хотите удалить следующие {elementsForRemoving.Count()}  записи?", "ВНИМАНИЕ!",
                MessageBoxButton.YesNo, MessageBoxImage.Question) == MessageBoxResult.Yes)
            {
                try
                {
                    Studiya_zvukozapisiEntities.GetContext().Music.RemoveRange(elementsForRemoving);
                    Studiya_zvukozapisiEntities.GetContext().SaveChanges();
                    MessageBox.Show("Вы успешно удалили записи!");
                    DGridgorod.ItemsSource = Studiya_zvukozapisiEntities.GetContext().Music.ToList();
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message.ToString());
                }
            }
        }

        private void dob_Click(object sender, RoutedEventArgs e)
        {
            Manager.MainFrame.Navigate(new addmusic(null));
        }
        private void BtnEdit_Click(Object sender, RoutedEventArgs e)
        {
            Manager.MainFrame.Navigate(new addmusic((sender as Button).DataContext as Music));
        }

        private void Page_IsEnabledChanged(object sender, DependencyPropertyChangedEventArgs e)
        {
           
                if (Visibility == Visibility.Visible)
                {
                    Studiya_zvukozapisiEntities.GetContext().ChangeTracker.Entries().ToList().ForEach(p => p.Reload());
                    DGridgorod.ItemsSource = Studiya_zvukozapisiEntities.GetContext().Music.ToList();
                }
            }
    }
}
