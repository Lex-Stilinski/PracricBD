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
    /// Логика взаимодействия для LabelPage.xaml
    /// </summary>
    public partial class LabelPage : Page
    {
        labelTableAdapter labels = new labelTableAdapter();
        public LabelPage()
        {
            InitializeComponent();
            labelList.ItemsSource = labels.GetData();
        }

        private void labelList_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (labelList.SelectedItem != null)
            {
                labelTbx.Text = (labelList.SelectedItem as DataRowView).Row[1].ToString();
            }
            else
            {
                labelTbx.Text = "";
            }
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            if (labelTbx.Text.Length == 0)
            {
                MessageBox.Show("Не указан лейбл");
            }
            else
            {
                labels.InsertQuery(labelTbx.Text);
                labelList.ItemsSource = labels.GetData();
            }
        }

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            object id = (labelList.SelectedItem as DataRowView).Row[0];
            labels.DeleteQuery(Convert.ToInt32(id));
            labelList.ItemsSource = labels.GetData();
        }

        private void Button_Click_2(object sender, RoutedEventArgs e)
        {
            if (labelTbx.Text.Length == 0)
            {
                MessageBox.Show("Не указан лейбл");
            }
            else
            {
                object id = (labelList.SelectedItem as DataRowView).Row[0];
                labels.UpdateQuery(labelTbx.Text, Convert.ToInt32(id));
                labelList.ItemsSource = labels.GetData();
            }
        }
    }
}
