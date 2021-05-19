using Cinema.Pages.AdminTablesPages;
using System.Windows;
using System.Windows.Controls;

namespace Cinema.Pages
{
    /// <summary>
    /// Логика взаимодействия для AdminPage.xaml
    /// </summary>
    public partial class AdminPage : Page
    {
        public AdminPage()
        {
            InitializeComponent();
        }

        private void BtnFilms_Click(object sender, RoutedEventArgs e)
        {
            FrameManager.mainFrame.Navigate(new FilmsPage());
        }

        private void BtnBill_Click(object sender, RoutedEventArgs e)
        {
            FrameManager.mainFrame.Navigate(new BillPage());
        }

        private void BtnHalls_Click(object sender, RoutedEventArgs e)
        {
            FrameManager.mainFrame.Navigate(new HallsPage());
        }
    }
}
