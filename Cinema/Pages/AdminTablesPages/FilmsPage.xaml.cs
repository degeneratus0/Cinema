using System;
using System.Linq;
using System.Windows;
using System.Windows.Controls;

namespace Cinema.Pages.AdminTablesPages
{
    /// <summary>
    /// Логика взаимодействия для FilmsPage.xaml
    /// </summary>
    public partial class FilmsPage : Page
    {
        Cinema01Entities entities;
        private void ShowTable()
        {
            entities = new Cinema01Entities();
            DGFilms.ItemsSource = entities.Films.ToList();
        }
        public FilmsPage()
        {
            InitializeComponent();
            ShowTable();
        }

        private void BtnAdd_Click(object sender, RoutedEventArgs e)
        {
            var newFilm = new Films();
            entities.Films.Add(newFilm);
            AddEditFilms addFilm = new AddEditFilms(entities, newFilm);
            addFilm.ShowDialog();
            ShowTable();
        }

        private void BtnDelete_Click(object sender, RoutedEventArgs e)
        {
            var row = (Films)DGFilms.SelectedItem;
            if (row == null)
            {
                MessageBox.Show("Выберите строку для удаления", "Удаление");
                return;
            }
            MessageBoxResult result = MessageBox.Show("Подтвердите удаление", "Удаление", MessageBoxButton.YesNo, MessageBoxImage.Question);
            if (result == MessageBoxResult.Yes)
            {
                entities.Films.Remove(row);
                entities.SaveChanges();
                ShowTable();
            }
        }

        private void BtnEdit_Click(object sender, RoutedEventArgs e)
        {
            var curFilm = (Films)DGFilms.SelectedItem;
            AddEditFilms editFilm = new AddEditFilms(entities, curFilm);
            editFilm.ShowDialog();
            ShowTable();
        }

        private void BtnBack_Click(object sender, RoutedEventArgs e)
        {
            FrameManager.mainFrame.GoBack();
        }

        private void BtnViewPoster_Click(object sender, RoutedEventArgs e)
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
    }
}
