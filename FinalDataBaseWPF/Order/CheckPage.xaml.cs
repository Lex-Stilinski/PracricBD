using FinalDataBaseWPF.music_albumDataSetTableAdapters;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Controls.Primitives;
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
    /// Логика взаимодействия для CheckPage.xaml
    /// </summary>
    public partial class CheckPage : Page
    {
        checksTableAdapter checks = new checksTableAdapter();
        ordersTableAdapter orders = new ordersTableAdapter();
        int o;
        string d;
        public CheckPage()
        {
            InitializeComponent();
            checkList.ItemsSource = checks.GetData();
            orderBox.ItemsSource = orders.GetData();
            orderBox.SelectedValuePath = "orders_id";
            orderBox.DisplayMemberPath = "orders_id";
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            MessageBox.Show("Сегодня без покупoк :(");
        }

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            bool result_q = int.TryParse(contrTbx.Text, out int c);
            bool result_p = int.TryParse(OddTbx.Text, out int odd);
            if (orderBox.Text.Length == 0)
            {
                MessageBox.Show("Не указан номер заказа");
            }
            else if ((contrTbx.Text.Length == 0) || (result_q == false))
            {
                MessageBox.Show("Не указана сумма, которая была внесена или указана некорректно");
            }
            else if ((OddTbx.Text.Length == 0) || (result_p == false))
            {
                MessageBox.Show("Не указана сдача или указана некорректно");
            }
            else
            {
                orders.InsertQuery(o, c, odd, d);
                checkList.ItemsSource = checks.GetData();
            }
        }

        private void Button_Click_2(object sender, RoutedEventArgs e)
        {
            object id = (checkList.SelectedItem as DataRowView).Row[0];
            orders.DeleteQuery(Convert.ToInt32(id));
            checkList.ItemsSource = checks.GetData();
        }

        private void Button_Click_3(object sender, RoutedEventArgs e)
        {
            bool result_q = int.TryParse(contrTbx.Text, out int c);
            bool result_p = int.TryParse(OddTbx.Text, out int odd);
            if (orderBox.Text.Length == 0)
            {
                MessageBox.Show("Не указан номер заказа");
            }
            else if ((contrTbx.Text.Length == 0) || (result_q == false))
            {
                MessageBox.Show("Не указана сумма, которая была внесена или указана некорректно");
            }
            else if ((OddTbx.Text.Length == 0) || (result_p == false))
            {
                MessageBox.Show("Не указана сдача или указана некорректно");
            }
            else
            {
                object id = (checkList.SelectedItem as DataRowView).Row[0];
                orders.UpdateQuery(o,c, odd, d, Convert.ToInt32(id));
                checkList.ItemsSource = checks.GetData();
            }
        }

        private void orderBox_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            o = (int)(orderBox.SelectedItem as DataRowView).Row[0];
        }

        private void datePicker_SelectedDateChanged(object sender, SelectionChangedEventArgs e)
        {
            d = datePicker.SelectedDate.ToString();
        }

        private void checkList_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (checkList.SelectedItem != null)
            {
                orderBox.SelectedValue = (checkList.SelectedItem as DataRowView).Row[1];
                sum.Content = (checkList.SelectedItem as DataRowView).Row[2];
                contrTbx.Text = (string)(checkList.SelectedItem as DataRowView).Row[3];
                OddTbx.Text = (string)(checkList.SelectedItem as DataRowView).Row[4];
                datePicker.SelectedDate = (DateTime?)(checkList.SelectedItem as DataRowView).Row[5];
            }
            else
            {
                orderBox.SelectedValue = "";
                sum.Content = "";
                contrTbx.Text = "";
                OddTbx.Text = "";
                datePicker.SelectedDate = datePicker.DisplayDate;
            }
        }
    }
}
