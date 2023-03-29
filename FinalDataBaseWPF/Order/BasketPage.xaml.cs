using FinalDataBaseWPF.music_albumDataSetTableAdapters;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Reflection.Emit;
using System.Text;
using System.Text.RegularExpressions;
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

namespace FinalDataBaseWPF.Order
{
    /// <summary>
    /// Логика взаимодействия для BasketPage.xaml
    /// </summary>
    public partial class BasketPage : Page
    {
        order_assemblyTableAdapter basket = new order_assemblyTableAdapter();
        productTableAdapter products = new productTableAdapter();
        ordersTableAdapter orders = new ordersTableAdapter();
        int p;
        int o;
        public BasketPage()
        {
            InitializeComponent();
            basketList.ItemsSource = basket.GetData();
            productBox.ItemsSource = products.GetData();
            productBox.SelectedValuePath = "product_id";
            productBox.DisplayMemberPath = "product_name";
            orderBox.ItemsSource = orders.GetData();
            orderBox.SelectedValuePath = "orders_id";
            orderBox.DisplayMemberPath = "orders_id";
        }

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            object id = (basketList.SelectedItem as DataRowView).Row[0];
            basket.DeleteQuery(Convert.ToInt32(id));
            basketList.ItemsSource = basket.GetData();
        }

        private void Button_Click_2(object sender, RoutedEventArgs e)
        {
            if (productBox.Text.Length == 0)
            {
                MessageBox.Show("Не указан товар");
            }
            else if (orderBox.Text.Length == 0)
            {
                MessageBox.Show("Не указан номер заказа");
            }
            else
            {
                object id = (basketList.SelectedItem as DataRowView).Row[0];
                basket.UpdateQuery(p, o, Convert.ToInt32(id));
                basketList.ItemsSource = basket.GetData();
            }
        }

        private void basketList_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (basketList.SelectedItem != null)
            {
                productBox.SelectedItem = (basketList.SelectedItem as DataRowView).Row[1].ToString();
                orderBox.SelectedValue = (basketList.SelectedItem as DataRowView).Row[2];
            }
            else
            {
                productBox.SelectedItem = "";
                orderBox.SelectedValue = "";
            }
        }

        private void productBox_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            p = (int)(productBox.SelectedItem as DataRowView).Row[0];
        }

        private void orderBox_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            o = (int)(orderBox.SelectedItem as DataRowView).Row[0];
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            if (productBox.Text.Length == 0)
            {
                MessageBox.Show("Не указан товар");
            }
            else if (orderBox.Text.Length == 0)
            {
                MessageBox.Show("Не указан номер заказа");
            }
            else
            {
                basket.InsertQuery(p, o);
                basketList.ItemsSource = basket.GetData();
            }
        }
    }
}
