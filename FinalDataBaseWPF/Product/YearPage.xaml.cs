using FinalDataBaseWPF.music_albumDataSetTableAdapters;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using static FinalDataBaseWPF.music_albumDataSet;

namespace FinalDataBaseWPF.Product
{
    /// <summary>
    /// Логика взаимодействия для YearPage.xaml
    /// </summary>
    public partial class YearPage : Page
    {
        release_yearTableAdapter years = new release_yearTableAdapter();
        public YearPage()
        {
            InitializeComponent();
            yearList.ItemsSource = years.GetData();
        }

        private void yearList_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (yearList.SelectedItem != null)
            {
                yearTbx.Text = (yearList.SelectedItem as DataRowView).Row[1].ToString();
            }
            else
            {
                yearTbx.Text = "";
            }
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            bool result = int.TryParse(yearTbx.Text, out _);
            if ((yearTbx.Text.Length == 0) || (result == false))
            {
                MessageBox.Show("Не указан год релиза или указн неверный формат");
            }
            else
            {
                years.InsertQuery(yearTbx.Text);
                yearList.ItemsSource = years.GetData();
            }
        }

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            bool result = int.TryParse(yearTbx.Text, out _);
            if ((yearTbx.Text.Length == 0) || (result == false))
            {
                MessageBox.Show("Не указан год релиза или указн неверный формат");
            }
            else
            {
                object id = (yearList.SelectedItem as DataRowView).Row[0];
                years.UpdateQuery(yearTbx.Text, Convert.ToInt32(id));
                yearList.ItemsSource = years.GetData();
            }
        }

        private void Button_Click_2(object sender, RoutedEventArgs e)
        {
            object id = (yearList.SelectedItem as DataRowView).Row[0];
            years.DeleteQuery(Convert.ToInt32(id));
            yearList.ItemsSource = years.GetData();
        }

        private void Button_Click_3(object sender, RoutedEventArgs e)
        {
            List<YearClass> importgenre = ConverteClass.DeserializeObject<List<YearClass>>();
            foreach (var genre in importgenre)
            {
                years.InsertQuery(genre.release_year_name);
            }
            yearList.ItemsSource = years.GetData();
        }
    }
}
