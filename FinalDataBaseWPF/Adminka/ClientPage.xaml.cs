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

namespace FinalDataBaseWPF
{
    /// <summary>
    /// Логика взаимодействия для ClientPage.xaml
    /// </summary>
    public partial class ClientPage : Page
    {
        roleTableAdapter roles = new roleTableAdapter();
        data_detailTableAdapter datas = new data_detailTableAdapter();
        clientTableAdapter clients = new clientTableAdapter();
        int r;
        int d;
        public ClientPage()
        {
            InitializeComponent();
            clientList.ItemsSource = clients.GetData();
            dataBox.ItemsSource = datas.GetData();
            dataBox.SelectedValuePath = "data_detail_id";
            dataBox.DisplayMemberPath = "data_detail_login";
            roleBox.ItemsSource = roles.GetData();
            roleBox.SelectedValuePath = "role_id";
            roleBox.DisplayMemberPath = "role_name";
        }

        private void ClearList()
        {
            firstnameTBx.Text = "";
            nameTBx.Text = "";
            roleBox.SelectedItem = "";
            dataBox.SelectedItem = "";
        }

        private void clientList_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (clientList.SelectedItem != null)
            {
                firstnameTBx.Text = (clientList.SelectedItem as DataRowView).Row[1].ToString();
                nameTBx.Text = (clientList.SelectedItem as DataRowView).Row[2].ToString(); ;
                roleBox.SelectedValue = (clientList.SelectedItem as DataRowView).Row[3];
                dataBox.SelectedValue = (clientList.SelectedItem as DataRowView).Row[4];
            }
            else
            {
                ClearList();
            }
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            if (firstnameTBx.Text.Length == 0)
            {
                MessageBox.Show("Не указана фамилия");
            }
            else if (nameTBx.Text.Length == 0)
            {
                MessageBox.Show("Не указано имя");
            }
            else if (roleBox.Text.Length == 0)
            {
                MessageBox.Show("Не указана роль");
            }
            else if (dataBox.Text.Length == 0)
            {
                MessageBox.Show("Не указан логин");
            }
            else
            {
                clients.InsertQuery(firstnameTBx.Text, nameTBx.Text, r, d);
                clientList.ItemsSource = clients.GetData();
            }
        }

        private void roleBox_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            r = (int)(roleBox.SelectedItem as DataRowView).Row[0];
        }

        private void dataBox_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            d = (int)(dataBox.SelectedItem as DataRowView).Row[0];
        }

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            object id = (clientList.SelectedItem as DataRowView).Row[0];
            clients.DeleteQuery(Convert.ToInt32(id));
            clientList.ItemsSource = clients.GetData();
        }

        private void Button_Click_2(object sender, RoutedEventArgs e)
        {
            if (firstnameTBx.Text.Length == 0)
            {
                MessageBox.Show("Не указана фамилия");
            }
            else if (nameTBx.Text.Length == 0)
            {
                MessageBox.Show("Не указано имя");
            }
            else if (roleBox.Text.Length == 0)
            {
                MessageBox.Show("Не указана роль");
            }
            else if (dataBox.Text.Length == 0)
            {
                MessageBox.Show("Не указан логин");
            }
            else
            {
                object id = (clientList.SelectedItem as DataRowView).Row[0];
                clients.UpdateQuery(firstnameTBx.Text, nameTBx.Text, r, d, Convert.ToInt32(id));
                clientList.ItemsSource = datas.GetData();
            }
        }
    }
}
