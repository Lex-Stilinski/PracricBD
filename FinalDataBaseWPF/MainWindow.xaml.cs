using FinalDataBaseWPF.music_albumDataSetTableAdapters;
using System;
using System.Collections.Generic;
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
    /// Логика взаимодействия для MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        data_detailTableAdapter adapter = new data_detailTableAdapter();
        public MainWindow()
        {
            InitializeComponent();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            var allLogins = adapter.GetData().Rows;

            for (int i = 0; i < allLogins.Count; i++)
            {
                if (allLogins[i][1].ToString() == LoginTbx.Text && allLogins[i][2].ToString() == PasswordTbx.Password)
                {
                    int roleId = (int)allLogins[i][3];
                    switch (roleId)
                    {
                        case 1:
                            AdminWindow admin = new AdminWindow();
                            admin.Show();
                            Close();
                            break;
                        case 2:
                            ClientWindow client = new ClientWindow();
                            client.Show();
                            Close();
                            break;
                    }
                }
            }
        }
    }
}
