using FinalDataBaseWPF.music_albumDataSetTableAdapters;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Reflection.Emit;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Markup;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using static FinalDataBaseWPF.music_albumDataSet;

namespace FinalDataBaseWPF.Product
{
    /// <summary>
    /// Логика взаимодействия для GroupePage.xaml
    /// </summary>
    public partial class GroupePage : Page
    {
        groupeTableAdapter groupes = new groupeTableAdapter();
        labelTableAdapter labels = new labelTableAdapter();
        genreTableAdapter genres = new genreTableAdapter();
        int g;
        int l;
        public GroupePage()
        {
            InitializeComponent();
            groupeList.ItemsSource = groupes.GetData();
            labelBox.ItemsSource = labels.GetData();
            labelBox.SelectedValuePath = "label_id";
            labelBox.DisplayMemberPath = "label_name";
            genreBox.ItemsSource = genres.GetData();
            genreBox.SelectedValuePath = "genre_id";
            genreBox.DisplayMemberPath = "genre_name";
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            if (groupeTbx.Text.Length == 0)
            {
                MessageBox.Show("Не указано название группы");
            }
            else if (labelBox.Text.Length == 0)
            {
                MessageBox.Show("Не указан лейбл");
            }
            else if (genreBox.Text.Length == 0)
            {
                MessageBox.Show("Не указан жанр");
            }
            else
            {
                groupes.InsertQuery(groupeTbx.Text, l, g);
                groupeList.ItemsSource = groupes.GetData();
            }
        }

        private void groupeList_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (groupeList.SelectedItem != null)
            {
                groupeTbx.Text = (groupeList.SelectedItem as DataRowView).Row[1].ToString();
                labelBox.SelectedValue = (groupeList.SelectedItem as DataRowView).Row[2];
                genreBox.SelectedValue = (groupeList.SelectedItem as DataRowView).Row[3];
            }
            else
            {
                groupeTbx.Text = "";
                labelBox.SelectedItem = "";
                genreBox.SelectedItem = "";
            }
        }

        private void labelBox_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            l = (int)(labelBox.SelectedItem as DataRowView).Row[0];
        }

        private void genreBox_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            g = (int)(genreBox.SelectedItem as DataRowView).Row[0];
        }

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            object id = (groupeList.SelectedItem as DataRowView).Row[0];
            groupes.DeleteQuery(Convert.ToInt32(id));
            groupeList.ItemsSource = genres.GetData();
        }

        private void Button_Click_2(object sender, RoutedEventArgs e)
        {
            if (groupeTbx.Text.Length == 0)
            {
                MessageBox.Show("Не указано название группы");
            }
            else if (labelBox.Text.Length == 0)
            {
                MessageBox.Show("Не указан лейбл");
            }
            else if (genreBox.Text.Length == 0)
            {
                MessageBox.Show("Не указан жанр");
            }
            else
            {
                object id = (groupeList.SelectedItem as DataRowView).Row[0];
                groupes.UpdateQuery(groupeTbx.Text, l, g, Convert.ToInt32(id));
                groupeList.ItemsSource = genres.GetData();
            }
        }
    }
}
