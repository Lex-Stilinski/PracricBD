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
    /// Логика взаимодействия для RolePage.xaml
    /// </summary>
    public partial class RolePage : Page
    {
        roleTableAdapter roles = new roleTableAdapter();
        public RolePage()
        {
            InitializeComponent();
            roleList.ItemsSource = roles.GetData();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            if (roleTbx.Text.Length == 0)
            {
                MessageBox.Show("Не указана роль");
            }
            else
            {
                roles.InsertQuery(roleTbx.Text);
                roleList.ItemsSource = roles.GetData();
            }
        }

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            object id = (roleList.SelectedItem as DataRowView).Row[0];
            roles.DeleteQuery(Convert.ToInt32(id));
            roleList.ItemsSource = roles.GetData();
        }

        private void Button_Click_2(object sender, RoutedEventArgs e)
        {
            if (roleTbx.Text.Length == 0)
            {
                MessageBox.Show("Не указана роль");
            }
            else
            {
                object id = (roleList.SelectedItem as DataRowView).Row[0];
                roles.UpdateQuery(roleTbx.Text, Convert.ToInt32(id));
                roleList.ItemsSource = roles.GetData();
            }
        }

        private void roleList_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (roleList.SelectedItem != null)
            {
                roleTbx.Text = (roleList.SelectedItem as DataRowView).Row[1].ToString();
            }
            else
            {
                roleTbx.Text = "";
            }
        }
    }
}
