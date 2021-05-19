using System.Linq;
using System.Windows;
using System.Windows.Controls;

namespace Cinema.Pages
{
    /// <summary>
    /// Логика взаимодействия для AuthPage.xaml
    /// </summary>
    public partial class AuthPage : Page
    {
        Cinema01Entities entities;
        public AuthPage()
        {
            InitializeComponent();
            entities = new Cinema01Entities();
        }

        private void BtnConfirm_Click(object sender, RoutedEventArgs e)
        {
            string login = TBLogin.Text;
            string pass = TBPassword.Text;
            Users user = entities.Users.FirstOrDefault(p => p.Login == login && p.Password == pass);
            if (user != null)
            {
                switch (user.Roles.Name)
                {
                    case "Manager":
                        FrameManager.mainFrame.Navigate(new ManagerPage());
                        break;
                    case "Admin":
                        FrameManager.mainFrame.Navigate(new AdminPage());
                        break;
                    default:
                        break;
                }
            }
        }

        private void BtnAdmin_Click(object sender, RoutedEventArgs e)
        {
            FrameManager.mainFrame.Navigate(new AdminPage());
        }

        private void BtnManager_Click(object sender, RoutedEventArgs e)
        {
            FrameManager.mainFrame.Navigate(new ManagerPage());
        }
    }
}
