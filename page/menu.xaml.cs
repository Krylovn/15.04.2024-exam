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

namespace zvuk.page
{
    /// <summary>
    /// Логика взаимодействия для menu.xaml
    /// </summary>
    public partial class menu : Page
    {
        public menu()
        {
            InitializeComponent();
        }

        private void BtnMoveFirst_OnClick(object sender, RoutedEventArgs e)
        {
            Manager.MainFrame.Navigate(new albom());
        }

        private void BtnMoveSecond_OnClick(object sender, RoutedEventArgs e)
        {
            Manager.MainFrame.Navigate(new soz());
        }

        private void BtnMoveFourth_OnClick(object sender, RoutedEventArgs e)
        {
            Manager.MainFrame.Navigate(new prik());
        }

        private void BtnMoveFourt_OnClick(object sender, RoutedEventArgs e)
        {
            Manager.MainFrame.Navigate(new status());

        }

        private void BtnMoveThird_OnClick(object sender, RoutedEventArgs e)
        {
            Manager.MainFrame.Navigate(new music());

        }
    }
}
