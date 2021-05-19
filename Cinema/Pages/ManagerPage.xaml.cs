using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows;
using System.Windows.Controls;

namespace Cinema.Pages
{
    /// <summary>
    /// Логика взаимодействия для ManagerPage.xaml
    /// </summary>
    public partial class ManagerPage : Page
    {
        Cinema01Entities entities;
        static List<Bill> bills = new List<Bill>();
        int recPerPage = 3;
        int pageIndex = 1;
        private void Navigate(int mode)
        {
            int pageCount = bills.Count() / recPerPage;
            if (bills.Count() % recPerPage > 0) { pageCount++; }
            switch (mode)
            {
                case 1:
                    pageIndex = 1;
                    break;
                case 2:
                    if (PagesCount.Text == "All") { goto case 1; } 
                    else if (pageIndex > 1) { pageIndex--; }
                    break;
                case 3:
                    if (PagesCount.Text == "All") { goto case 4; } 
                    else if (pageIndex < pageCount) { pageIndex++; }
                    break;
                case 4:
                    pageIndex = pageCount;
                    break;
            }
            DGBill.ItemsSource = bills.OrderBy(x => x.ID).Skip((pageIndex - 1) * recPerPage).Take(recPerPage).ToList();
            int records = pageIndex * (recPerPage) - (recPerPage - 1);
            PagesCount.Text = $"Page {pageIndex} of {pageCount}";
            RecordsCount.Text = $"Records {records} to {records + DGBill.Items.Count - 1}";
        }
        private void ShowTable() //PASHET)) tvar blя)
        {
            Halls selectedHall = new Halls();
            selectedHall = (Halls)cmbHall.SelectedItem;
            if (selectedHall.Name != "All")
            {
                entities = new Cinema01Entities();
                bills = entities.Bill.Where(x => x.HallId == selectedHall.ID).ToList();
            }
            else
            {
                bills = entities.Bill.ToList();
            }
            string seekText = seekFilm.Text.ToLower();
            if (seekText != null)
            {
                bills = bills.Where(x => x.Films.Title.ToLower().StartsWith(seekText)).ToList();
            }
            DGBill.ItemsSource = bills;
        }
        public ManagerPage()
        {
            InitializeComponent();
            entities = new Cinema01Entities();
            bills = entities.Bill.ToList();

            List<Halls> cmbHallItems = new List<Halls>();
            Halls allHalls = new Halls { Name = "All" };
            cmbHallItems.Add(allHalls);
            cmbHallItems.AddRange(entities.Halls.ToList());
            cmbHall.ItemsSource = cmbHallItems;
            cmbHall.SelectedItem = allHalls;

            List<int> cmbRecPerPageItems = new List<int> { 3, 5, 10 };
            cmbRecPerPage.ItemsSource = cmbRecPerPageItems;
            cmbRecPerPage.SelectedItem = cmbRecPerPage.Items[0];

            PagesCount.Text = "All";
            RecordsCount.Text = "";

            ShowTable();
        }

        private void BtnViewPoster_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                Button BtnViewPoster = (Button)sender;
                var curFilmPoster = ((Bill)BtnViewPoster.DataContext).Films.Poster;
                ViewImage view = new ViewImage(curFilmPoster);
                view.ShowDialog();
            }
            catch (Exception)
            {
                MessageBox.Show("No poster there");
            }
        }

        private void First_Click(object sender, RoutedEventArgs e)
        {
            Navigate(1);
        }

        private void Prev_Click(object sender, RoutedEventArgs e)
        {
            Navigate(2);
        }

        private void Next_Click(object sender, RoutedEventArgs e)
        {
            Navigate(3);
        }

        private void Last_Click(object sender, RoutedEventArgs e)
        {
            Navigate(4);
        }

        private void All_Click(object sender, RoutedEventArgs e)
        {
            PagesCount.Text = "All";
            RecordsCount.Text = "";
            ShowTable();
        }

        private void cmbHall_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            PagesCount.Text = "All";
            RecordsCount.Text = "";
            ShowTable();
        }

        private void seekFilm_TextChanged(object sender, TextChangedEventArgs e)
        {
            ShowTable();
        }

        private void cmbRecPerPage_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            recPerPage = (int)cmbRecPerPage.SelectedItem;
            Navigate(1);
        }
    }
}
