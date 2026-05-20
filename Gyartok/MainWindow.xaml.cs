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

namespace Gyartok
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        private void exit_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }

        public string connectionString = "server=localhost;user=root;password=;database=vizsga;";

        public void LoadData()
        {
            var conn = new MySqlConnection(connectionString);

            conn.Open();

            string sql = "SELECT * FROM gyartok";

            var cmd = new MySqlCommand(sql, conn);

            var adapter = new MySqlAdapter(cmd);

            var dt = new DateTable();

            adapter.Fill(dt);

            dataG.ItemsSource = dt.Defaultview;

            conn.Close();
        }
    }
}
