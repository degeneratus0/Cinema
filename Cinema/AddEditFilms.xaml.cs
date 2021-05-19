using Microsoft.Win32;
using System;
using System.IO;
using System.Windows;
using System.Windows.Controls;

namespace Cinema
{
    /// <summary>
    /// Логика взаимодействия для AddEditFilms.xaml
    /// </summary>
    public partial class AddEditFilms : Window
    {
        Cinema01Entities entities;
        public AddEditFilms(Cinema01Entities entities, Films curRow)
        {
            InitializeComponent();
            this.entities = entities;
            this.DataContext = curRow;
        }

        private void ViewPoster_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                Button BtnViewPoster = (Button)sender;
                var curFilmPoster = ((Films)BtnViewPoster.DataContext).Poster;
                ViewImage view = new ViewImage(curFilmPoster);
                view.ShowDialog();
            }
            catch (Exception)
            {
                MessageBox.Show("No poster there");
            }
        }

        private void BtnImage_Click(object sender, RoutedEventArgs e)
        {
            OpenFileDialog openFile = new OpenFileDialog();
            openFile.Filter = "Image files: *.jpg, *.png|*.jpg; *.png";
            openFile.ShowDialog();
            string fileName = openFile.FileName;
            if (fileName != "")
            {
                byte[] img = File.ReadAllBytes(fileName);
                var addFilm = (Films)this.DataContext;
                addFilm.Poster = img;
            }
        }

        private void BtnSave_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                entities.SaveChanges();
                this.Close();
            }
            catch (Exception)
            {
                throw;
            }
        }

        private void BtnCancel_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }
    }
}
