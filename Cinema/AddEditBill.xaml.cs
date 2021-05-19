using System;
using System.Linq;
using System.Windows;

namespace Cinema
{
    /// <summary>
    /// Логика взаимодействия для AddEditBill.xaml
    /// </summary>
    public partial class AddEditBill : Window
    {
        Cinema01Entities entities;
        public AddEditBill(Cinema01Entities entities, Bill curBill)
        {
            InitializeComponent();
            this.entities = entities;
            this.DataContext = curBill;
            cmbFilm.ItemsSource = entities.Films.ToList();
            cmbHall.ItemsSource = entities.Halls.ToList();
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
