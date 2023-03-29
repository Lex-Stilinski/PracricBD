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
using System.Windows.Shapes;
using FinalDataBaseWPF.music_albumDataSetTableAdapters;
using static FinalDataBaseWPF.music_albumDataSet;

namespace FinalDataBaseWPF
{
    /// <summary>
    /// Логика взаимодействия для ClientWindow.xaml
    /// </summary>
    public partial class ClientWindow : Window
    {
        genreTableAdapter genres = new genreTableAdapter();
        labelTableAdapter labels = new labelTableAdapter();
        typeTableAdapter types = new typeTableAdapter();
        groupeTableAdapter groupes = new groupeTableAdapter();
        release_yearTableAdapter years = new release_yearTableAdapter();
        productTableAdapter products = new productTableAdapter();
        order_assemblyTableAdapter or_as = new order_assemblyTableAdapter();
        public ClientWindow()
        {
            InitializeComponent();
            ComboGenre.ItemsSource = genres.GetData();
            ComboGenre.DisplayMemberPath = "genre_name";

            ComboLabel.ItemsSource = labels.GetData();
            ComboLabel.DisplayMemberPath = "label_name";

            ComboType.ItemsSource = types.GetData();
            ComboType.DisplayMemberPath = "type_name";

            ComboGroupe.ItemsSource = groupes.GetData();
            ComboGroupe.DisplayMemberPath = "groupe_name";

            ComboYear.ItemsSource = years.GetData();
            ComboYear.DisplayMemberPath = "release_year_name";

            DataProduct.ItemsSource = products.GetData();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            MainWindow main = new MainWindow();
            main.Show();
            Close();
        }

        private void ComboGenre_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            DataProduct.ItemsSource = products.GetDataBy_Genre(Convert.ToInt32((ComboGenre.SelectedItem as DataRowView).Row[0]));
        }

        private void ComboLabel_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            DataProduct.ItemsSource = products.GetDataBy_Label(Convert.ToInt32((ComboLabel.SelectedItem as DataRowView).Row[0]));
        }

        private void ComboType_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            DataProduct.ItemsSource = products.GetDataBy_Type(Convert.ToInt32((ComboType.SelectedItem as DataRowView).Row[0]));
        }

        private void ComboGroupe_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            DataProduct.ItemsSource = products.GetDataBy_Groupe(Convert.ToInt32((ComboGroupe.SelectedItem as DataRowView).Row[0]));
        }

        private void ComboYear_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            DataProduct.ItemsSource = products.GetDataBy_Year(Convert.ToInt32((ComboYear.SelectedItem as DataRowView).Row[0]));
        }

        private void Button_Click_2(object sender, RoutedEventArgs e)
        {
            DataProduct.ItemsSource = products.GetData();
        }
    }
}
