using System;
using System.Linq;
using System.Windows;
using System.Windows.Controls;

namespace Cinema.Pages.AdminTablesPages
{
    /// <summary>
    /// Логика взаимодействия для BillPage.xaml
    /// </summary>
    public partial class BillPage : Page
    {
        Cinema01Entities entities;
        int recPerPage = 3;
        int pageIndex = 1;
        private void Navigate(int mode)
        {
            int pageCount = entities.Bill.Count() / recPerPage;
            if (entities.Bill.Count() % recPerPage > 0) { pageCount++; }
            switch (mode)
            {
                case 1:
                    pageIndex = 1;
                    break;
                case 2:
                    if (pageIndex > 1) { pageIndex--; }
                    break;
                case 3:
                    if (pageIndex < pageCount) { pageIndex++; }
                    break;
                case 4:
                    pageIndex = pageCount;
                    break;
            }
            DGBill.ItemsSource = entities.Bill.OrderBy(x => x.ID).Skip((pageIndex - 1) * recPerPage).Take(recPerPage).ToList();
            Info.Text = pageIndex + " of " + pageCount;
        }
        public BillPage()
        {
            InitializeComponent();
            entities = new Cinema01Entities();
            Navigate(1);
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

        private void BtnAdd_Click(object sender, RoutedEventArgs e)
        {
            var newBill = new Bill();
            entities.Bill.Add(newBill);
            AddEditBill addBill = new AddEditBill(entities, newBill);
            addBill.ShowDialog();
            Navigate(pageIndex);
        }

        private void BtnDelete_Click(object sender, RoutedEventArgs e)
        {
            var row = (Bill)DGBill.SelectedItem;
            if (row == null)
            {
                MessageBox.Show("Выберите строку для удаления", "Удаление");
                return;
            }
            MessageBoxResult result = MessageBox.Show("Подтвердите удаление", "Удаление", MessageBoxButton.YesNo, MessageBoxImage.Question);
            if (result == MessageBoxResult.Yes)
            {
                entities.Bill.Remove(row);
                entities.SaveChanges();
                Navigate(pageIndex);
            }
        }

        private void BtnEdit_Click(object sender, RoutedEventArgs e)
        {
            var curBill = (Bill)DGBill.SelectedItem;
            AddEditBill editBill = new AddEditBill(entities, curBill);
            editBill.ShowDialog();
            Navigate(pageIndex);
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
                var curFilmPoster = ((Bill)BtnViewPoster.DataContext).Films.Poster;
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
