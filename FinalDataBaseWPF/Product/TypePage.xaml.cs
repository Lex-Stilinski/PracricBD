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
    /// Логика взаимодействия для TypePage.xaml
    /// </summary>
    public partial class TypePage : Page
    {
        typeTableAdapter types = new typeTableAdapter();
        public TypePage()
        {
            InitializeComponent();
            typeList.ItemsSource = types.GetData();
        }

        private void typeList_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (typeList.SelectedItem != null)
            {
                typeTbx.Text = (typeList.SelectedItem as DataRowView).Row[1].ToString();
            }
            else
            {
                typeTbx.Text = "";
            }
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            if (typeTbx.Text.Length == 0)
            {
                MessageBox.Show("Не указан тип товара");
            }
            else
            {
                types.InsertQuery(typeTbx.Text);
                typeList.ItemsSource = types.GetData();
            }
        }

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            object id = (typeList.SelectedItem as DataRowView).Row[0];
            types.DeleteQuery(Convert.ToInt32(id));
            typeList.ItemsSource = types.GetData();
        }

        private void Button_Click_2(object sender, RoutedEventArgs e)
        {
            if (typeTbx.Text.Length == 0)
            {
                MessageBox.Show("Не указан тип товара");
            }
            else
            {
                object id = (typeList.SelectedItem as DataRowView).Row[0];
                types.UpdateQuery(typeTbx.Text, Convert.ToInt32(id));
                typeList.ItemsSource = types.GetData();
            }
        }
    }
}
