using System.IO;
using System.Windows;
using System.Windows.Media.Imaging;

namespace Cinema
{
    /// <summary>
    /// Логика взаимодействия для ViewImage.xaml
    /// </summary>
    public partial class ViewImage : Window
    {
        public ViewImage(byte[] image)
        {
            InitializeComponent();
            MemoryStream byteStream = new MemoryStream(image);
            BitmapImage img = new BitmapImage();
            img.BeginInit();
            img.StreamSource = byteStream;
            img.EndInit();
            ImgPoster.Source = img;
        }

        private void BtnBack_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }
    }
}
