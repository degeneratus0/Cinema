using System.Linq;
using System.Windows;
using System.Windows.Controls;

namespace Cinema.Pages.AdminTablesPages
{
    /// <summary>
    /// Логика взаимодействия для HallsPage.xaml
    /// </summary>
    public partial class HallsPage : Page
    {
        Cinema01Entities entities;
        public HallsPage()
        {
            InitializeComponent();
            entities = new Cinema01Entities();
            DGHalls.ItemsSource = entities.Halls.ToList();
        }

        private void BtnBack_Click(object sender, RoutedEventArgs e)
        {
            FrameManager.mainFrame.GoBack();
        }
    }
}
