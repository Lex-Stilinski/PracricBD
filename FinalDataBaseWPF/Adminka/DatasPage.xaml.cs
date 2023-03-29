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
    /// Логика взаимодействия для DatasPage.xaml
    /// </summary>
    public partial class DatasPage : Page
    {
        roleTableAdapter roles = new roleTableAdapter();
        data_detailTableAdapter datas = new data_detailTableAdapter();
        int cell;
        public DatasPage()
        {
            InitializeComponent();
            dataList.ItemsSource = datas.GetData();
            roleBox.ItemsSource = roles.GetData();
            roleBox.DisplayMemberPath = "role_name";
            roleBox.SelectedValuePath = "role_id";
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            if (loginTBx.Text.Length == 0)
            {
                MessageBox.Show("Не указан логин");
            }
            else if (passwordTBX.Password.Length == 0)
            {
                MessageBox.Show("Не указан пароль");
            }
            else if (roleBox.Text.Length == 0)
            {
                MessageBox.Show("Не указана роль");
            }
            else
            {
                datas.InsertQuery(loginTBx.Text, passwordTBX.Password, cell);
                dataList.ItemsSource = datas.GetData();
            }
        }

        private void roleBox_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            cell = (int)(roleBox.SelectedItem as DataRowView).Row[0];
            
        }

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            object id = (dataList.SelectedItem as DataRowView).Row[0];
            datas.DeleteQuery(Convert.ToInt32(id));
            dataList.ItemsSource = datas.GetData();
        }

        private void Button_Click_2(object sender, RoutedEventArgs e)
        {
            if (loginTBx.Text.Length == 0)
            {
                MessageBox.Show("Не указан логин");
            }
            else if (passwordTBX.Password.Length == 0)
            {
                MessageBox.Show("Не указан пароль");
            }
            else if (roleBox.Text.Length == 0)
            {
                MessageBox.Show("Не указана роль");
            }
            else
            {
                object id = (dataList.SelectedItem as DataRowView).Row[0];
                datas.UpdateQuery(loginTBx.Text, passwordTBX.Password, cell, Convert.ToInt32(id));
                dataList.ItemsSource = datas.GetData();
            }
        }

        private void dataList_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (dataList.SelectedItem != null)
            {
                loginTBx.Text = (dataList.SelectedItem as DataRowView).Row[1].ToString();
                passwordTBX.Password = (dataList.SelectedItem as DataRowView).Row[2].ToString();
                roleBox.SelectedValue = (dataList.SelectedItem as DataRowView).Row[3].ToString();
            }
            else
            {
                ClearList();
            }
        }

        private void ClearList()
        {
            loginTBx.Text = "";
            passwordTBX.Password = "";
            roleBox.SelectedItem = "";
        }
    }
}
