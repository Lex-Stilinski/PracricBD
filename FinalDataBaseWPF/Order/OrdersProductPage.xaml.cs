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

namespace FinalDataBaseWPF.Order
{
    /// <summary>
    /// Логика взаимодействия для OrdersProductPage.xaml
    /// </summary>
    public partial class OrdersProductPage : Page
    {
        ordersTableAdapter orders = new ordersTableAdapter();
        statusTableAdapter stat = new statusTableAdapter();
        employeeTableAdapter employee = new employeeTableAdapter();
        clientTableAdapter client = new clientTableAdapter();
        int s;
        int c;
        string d;
        public OrdersProductPage()
        {
            InitializeComponent();
            orderList.ItemsSource = orders.GetData();
            statusBox.ItemsSource = stat.GetData();
            statusBox.SelectedValuePath = "status_id";
            statusBox.DisplayMemberPath = "status_name";
            emplBox.ItemsSource = employee.GetData();
            emplBox.SelectedValuePath = "empoyee_id";
            emplBox.DisplayMemberPath = "firstname_employee";
            clientBox.ItemsSource = client.GetData();
            clientBox.SelectedValuePath = "client_id";
            clientBox.DisplayMemberPath = "firstname_client";
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            if (statusBox.Text.Length == 0)
            {
                MessageBox.Show("Не указан статус заказа");
            }
            else if (emplBox.Text.Length == 0)
            {
                MessageBox.Show("Не указан сотрудник");
            }
            else if (clientBox.Text.Length == 0)
            {
                MessageBox.Show("Не указан клиент");
            }
            else
            {
                orders.InsertQuery(s, (int)(emplBox.SelectedItem as DataRowView).Row[0], c, d);
                orderList.ItemsSource = orders.GetData();
            }
        }

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            object id = (orderList.SelectedItem as DataRowView).Row[0];
            orders.DeleteQuery(Convert.ToInt32(id));
            orderList.ItemsSource = orders.GetData();
        }

        private void Button_Click_2(object sender, RoutedEventArgs e)
        {
            if (statusBox.Text.Length == 0)
            {
                MessageBox.Show("Не указан статус заказа");
            }
            else if (emplBox.Text.Length == 0)
            {
                MessageBox.Show("Не указан сотрудник");
            }
            else if (clientBox.Text.Length == 0)
            {
                MessageBox.Show("Не указан клиент");
            }
            else
            {
                object id = (orderList.SelectedItem as DataRowView).Row[0];
                orders.UpdateQuery(s, (int)(emplBox.SelectedItem as DataRowView).Row[0], c, d, Convert.ToInt32(id));
                orderList.ItemsSource = orders.GetData();
            }
        }

        private void statusBox_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            s = (int)(statusBox.SelectedItem as DataRowView).Row[0];
        }

        private void clientBox_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            c = (int)(clientBox.SelectedItem as DataRowView).Row[0];
        }

        private void orderList_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (orderList.SelectedItem != null)
            {
                statusBox.SelectedValue = (orderList.SelectedItem as DataRowView).Row[1];
                emplBox.SelectedValue = (orderList.SelectedItem as DataRowView).Row[2];
                clientBox.SelectedValue = (orderList.SelectedItem as DataRowView).Row[3].ToString();
                datePicker.SelectedDate = (DateTime?)(orderList.SelectedItem as DataRowView).Row[4];
            }
            else
            {
                statusBox.SelectedValue = "";
                emplBox.SelectedValue = "";
                clientBox.SelectedValue = "";
                datePicker.SelectedDate = datePicker.DisplayDate;
            }
        }

        private void datePicker_SelectedDateChanged(object sender, SelectionChangedEventArgs e)
        {
            d = datePicker.SelectedDate.ToString();
        }
    }
}
