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
    /// Логика взаимодействия для EmplPage.xaml
    /// </summary>
    public partial class EmplPage : Page
    {
        roleTableAdapter roles = new roleTableAdapter();
        data_detailTableAdapter datas = new data_detailTableAdapter();
        employeeTableAdapter employees = new employeeTableAdapter();
        int d;
        int r;
        public EmplPage()
        {
            InitializeComponent();
            emplList.ItemsSource = employees.GetData();
            dataBox.ItemsSource = datas.GetData();
            dataBox.DisplayMemberPath = "data_detail_login";
            dataBox.SelectedValuePath = "data_detail_id";
            roleBox.ItemsSource = roles.GetData();
            roleBox.DisplayMemberPath = "role_name";
            roleBox.SelectedValuePath = "role_id";
        }

        private void emplList_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (emplList.SelectedItem != null)
            {
                firstnameTBx.Text = (emplList.SelectedItem as DataRowView).Row[1].ToString();
                nameTBx.Text = (emplList.SelectedItem as DataRowView).Row[2].ToString(); 
                roleBox.SelectedValue = (emplList.SelectedItem as DataRowView).Row[3]; 
                dataBox.SelectedValue = (emplList.SelectedItem as DataRowView).Row[4]; 
            }
            else
            {
                ClearList();
            }
        }

        private void ClearList()
        {
            firstnameTBx.Text = "";
            nameTBx.Text = "";
            roleBox.SelectedItem = "";
            dataBox.SelectedItem = "";
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
                employees.InsertQuery(firstnameTBx.Text, nameTBx.Text, r, d);
                emplList.ItemsSource = employees.GetData();
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
            object id = (emplList.SelectedItem as DataRowView).Row[0];
            employees.DeleteQuery(Convert.ToInt32(id));
            emplList.ItemsSource = employees.GetData();
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
                object id = (emplList.SelectedItem as DataRowView).Row[0];
                employees.UpdateQuery(firstnameTBx.Text, nameTBx.Text, r, d, Convert.ToInt32(id));
                emplList.ItemsSource = datas.GetData();
            }
        }
    }
}
