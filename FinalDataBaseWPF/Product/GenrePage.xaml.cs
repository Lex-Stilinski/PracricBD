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

namespace FinalDataBaseWPF.Product
{
    /// <summary>
    /// Логика взаимодействия для GenrePage.xaml
    /// </summary>
    public partial class GenrePage : Page
    {
        genreTableAdapter genres = new genreTableAdapter();
        public GenrePage()
        {
            InitializeComponent();
            genreList.ItemsSource = genres.GetData();
        }

        private void genreList_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (genreList.SelectedItem != null)
            {
                genreTbx.Text = (genreList.SelectedItem as DataRowView).Row[1].ToString();
            }
            else
            {
                genreTbx.Text = "";
            }
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            if (genreTbx.Text.Length == 0)
            {
                MessageBox.Show("Не указан жанр");
            }
            else
            {
                genres.InsertQuery(genreTbx.Text);
                genreList.ItemsSource = genres.GetData();
            }
        }

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            object id = (genreList.SelectedItem as DataRowView).Row[0];
            genres.DeleteQuery(Convert.ToInt32(id));
            genreList.ItemsSource = genres.GetData();
        }

        private void Button_Click_2(object sender, RoutedEventArgs e)
        {
            if (genreTbx.Text.Length == 0)
            {
                MessageBox.Show("Не указан жанр");
            }
            else
            {
                object id = (genreList.SelectedItem as DataRowView).Row[0];
                genres.UpdateQuery(genreTbx.Text, Convert.ToInt32(id));
                genreList.ItemsSource = genres.GetData();
            }
        }

        private void Button_Click_3(object sender, RoutedEventArgs e)
        {
            List<GenreClass> importgenre = ConverteClass.DeserializeObject<List<GenreClass>>();
            foreach (var genre in importgenre)
            {
                genres.InsertQuery(genre.genre_name);
            }
            genreList.ItemsSource = genres.GetData();
        }
    }
}
