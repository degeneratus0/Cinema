using Cinema.Pages;
using System.Windows;

namespace Cinema
{
    /// <summary>
    /// Логика взаимодействия для MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
            FrameManager.mainFrame = MainFrame;
            FrameManager.mainFrame.Navigate(new AuthPage());
        }

        private void MainFrame_ContentRendered(object sender, System.EventArgs e)
        {

        }
    }
}
