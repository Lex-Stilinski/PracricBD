using FinalDataBaseWPF.music_albumDataSetTableAdapters;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Reflection.Emit;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Markup;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using static FinalDataBaseWPF.music_albumDataSet;

namespace FinalDataBaseWPF.Product
{
    /// <summary>
    /// Логика взаимодействия для ProductsPage.xaml
    /// </summary>
    public partial class ProductsPage : Page
    {
        productTableAdapter products = new productTableAdapter();
        groupeTableAdapter groupes = new groupeTableAdapter();
        typeTableAdapter types = new typeTableAdapter();
        labelTableAdapter labeles = new labelTableAdapter();
        genreTableAdapter genres = new genreTableAdapter();
        release_yearTableAdapter years = new release_yearTableAdapter();
        int lab;
        int gen;
        int gro;
        int ty;
        int ye;
        public ProductsPage()
        {
            InitializeComponent();
            productsList.ItemsSource = products.GetData();
            labelBox.ItemsSource = labeles.GetData();
            labelBox.SelectedValuePath = "label_id";
            labelBox.DisplayMemberPath = "label_name";
            genreBox.ItemsSource = genres.GetData();
            genreBox.SelectedValuePath = "genre_id";
            genreBox.DisplayMemberPath = "genre_name";
            groupeBox.ItemsSource = groupes.GetData();
            groupeBox.SelectedValuePath = "groupe_id";
            groupeBox.DisplayMemberPath = "groupe_name";
            typeBox.ItemsSource = types.GetData();
            typeBox.SelectedValuePath = "type_id";
            typeBox.DisplayMemberPath = "type_name";
            yearBox.ItemsSource = years.GetData();
            yearBox.SelectedValuePath = "release_year_id";
            yearBox.DisplayMemberPath = "release_year_name";
        }

        private void ClearList()
        {
            nameTbx.Text = "";
            labelBox.SelectedItem = "";
            genreBox.SelectedItem = "";
            groupeBox.SelectedItem = "";
            yearBox.SelectedItem = "";
            typeBox.SelectedItem = "";
            quantTbx.Text = "";
            priceTbx.Text = "";
        }

        private void producrsList_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (productsList.SelectedItem != null)
            {
                nameTbx.Text = (productsList.SelectedItem as DataRowView).Row[1].ToString();
                groupeBox.SelectedItem = (productsList.SelectedItem as DataRowView).Row[2];
                typeBox.SelectedValue = (productsList.SelectedItem as DataRowView).Row[3];
                labelBox.SelectedValue = (productsList.SelectedItem as DataRowView).Row[4];
                genreBox.SelectedValue = (productsList.SelectedItem as DataRowView).Row[5];
                yearBox.SelectedValue = (productsList.SelectedItem as DataRowView).Row[6];
                quantTbx.Text = (productsList.SelectedItem as DataRowView).Row[7].ToString();
                priceTbx.Text = (productsList.SelectedItem as DataRowView).Row[8].ToString();
            }
            else
            {
                ClearList();
            }
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            bool result_q = int.TryParse(quantTbx.Text, out int q);
            bool result_p = double.TryParse(priceTbx.Text, out double p);
            if (nameTbx.Text.Length == 0)
            {
                MessageBox.Show("Не указано название товара");
            }
            else if (groupeBox.Text.Length == 0)
            {
                MessageBox.Show("Не указана группа");
            }
            else if (typeBox.Text.Length == 0)
            {
                MessageBox.Show("Не указан тип товара");
            }
            else if (labelBox.Text.Length == 0)
            {
                MessageBox.Show("Не указан лейбл");
            }
            else if (genreBox.Text.Length == 0)
            {
                MessageBox.Show("Не указан жанр");
            }
            else if (yearBox.Text.Length == 0)
            {
                MessageBox.Show("Не указан год релиза");
            }
            else if ((quantTbx.Text.Length == 0)||(result_q == false))
            {
                MessageBox.Show("Не указано количество товара или неверный формат");
            }
            else if ((priceTbx.Text.Length == 0) || (result_p == false))
            {
                MessageBox.Show("Не указана цена товара или неверный формат");
            }
            else
            {
                products.InsertQuery(nameTbx.Text, gro, ty, lab, gen, ye, q, p);
                productsList.ItemsSource = products.GetData();
            }
        }

        private void labelBox_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            lab = (int)(labelBox.SelectedItem as DataRowView).Row[0];
        }

        private void genreBox_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            gen = (int)(genreBox.SelectedItem as DataRowView).Row[0];
        }

        private void groupeBox_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            gro = (int)(groupeBox.SelectedItem as DataRowView).Row[0];
        }

        private void typeBox_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            ty = (int)(typeBox.SelectedItem as DataRowView).Row[0];
        }

        private void yearBox_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            ye = (int)(yearBox.SelectedItem as DataRowView).Row[0];
        }

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            object id = (productsList.SelectedItem as DataRowView).Row[0];
            products.DeleteQuery(Convert.ToInt32(id));
            productsList.ItemsSource = products.GetData();
        }

        private void Button_Click_2(object sender, RoutedEventArgs e)
        {
            bool result_q = int.TryParse(quantTbx.Text, out int q);
            bool result_p = double.TryParse(priceTbx.Text, out double p);
            if (nameTbx.Text.Length == 0)
            {
                MessageBox.Show("Не указано название товара");
            }
            else if (groupeBox.Text.Length == 0)
            {
                MessageBox.Show("Не указана группа");
            }
            else if (typeBox.Text.Length == 0)
            {
                MessageBox.Show("Не указан тип товара");
            }
            else if (labelBox.Text.Length == 0)
            {
                MessageBox.Show("Не указан лейбл");
            }
            else if (genreBox.Text.Length == 0)
            {
                MessageBox.Show("Не указан жанр");
            }
            else if (yearBox.Text.Length == 0)
            {
                MessageBox.Show("Не указан год релиза");
            }
            else if ((quantTbx.Text.Length == 0) || (result_q == false))
            {
                MessageBox.Show("Не указано количество товара или неверный формат");
            }
            else if ((priceTbx.Text.Length == 0) || (result_p == false))
            {
                MessageBox.Show("Не указана цена товара или неверный формат");
            }
            else
            {
                object id = (productsList.SelectedItem as DataRowView).Row[0];
                products.UpdateQuery(nameTbx.Text, gro, ty, lab, gen, ye, q, p, Convert.ToInt32(id));
                productsList.ItemsSource = products.GetData();
            }
        }
    }
}
