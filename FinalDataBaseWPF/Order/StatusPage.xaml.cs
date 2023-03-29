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

namespace FinalDataBaseWPF.Order
{
    /// <summary>
    /// Логика взаимодействия для StatusPage.xaml
    /// </summary>
    public partial class StatusPage : Page
    {
        statusTableAdapter stat = new statusTableAdapter();
        public StatusPage()
        {
            InitializeComponent();
            statusList.ItemsSource = stat.GetData();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            if (statusTbx.Text.Length == 0)
            {
                MessageBox.Show("Пустое поле");
            }
            else
            {
                stat.InsertQuery(statusTbx.Text);
                statusList.ItemsSource = stat.GetData();
            }
        }

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            object id = (statusList.SelectedItem as DataRowView).Row[0];
            stat.DeleteQuery(Convert.ToInt32(id));
            statusList.ItemsSource = stat.GetData();
        }

        private void Button_Click_2(object sender, RoutedEventArgs e)
        {
            if (statusTbx.Text.Length == 0)
            {
                MessageBox.Show("Пустое поле");
            }
            else
            {
                object id = (statusList.SelectedItem as DataRowView).Row[0];
                stat.UpdateQuery(statusTbx.Text, Convert.ToInt32(id));
                statusList.ItemsSource = stat.GetData();
            }
        }

        private void statusList_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (statusList.SelectedItem != null)
            {
                statusTbx.Text = (statusList.SelectedItem as DataRowView).Row[1].ToString();
            }
            else
            {
                statusTbx.Text = "";
            }
        }
    }
}
