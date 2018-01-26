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
using System.Windows.Shapes;
using System.Data.SqlClient;
using System.Data;
using System.Threading;
using System.ComponentModel;
using System.Globalization;

namespace WpfApplication1
{
    /// <summary>
    /// Logika interakcji dla klasy History_List.xaml
    /// </summary>
    public partial class History_List : Window
    {
        public History_List()
        {
            WindowStartupLocation = System.Windows.WindowStartupLocation.CenterScreen;
            InitializeComponent();
            CzytajWyniki();
        }

        private void Download_Click(object sender, RoutedEventArgs e)
        {
            WyborWyniku();
            History h = new History();
            h.Show();
            
        }
        #region dane
        List<string> daty = new List<string>();
        public static string send_date;


        #endregion 

        void CzytajWyniki()
        {
            string connectionString = @"Data Source=localhost\SQLEXPRESS; Initial Catalog=LoginDB; Integrated Security=True;";

            SqlConnection sqlConnection = new SqlConnection(connectionString);
            sqlConnection.Open();
            SqlCommand cmd = new SqlCommand("SELECT Date FROM Pomiary WHERE idPacjenta = @idPacjenta",sqlConnection);
            cmd.Parameters.AddWithValue("@idPacjenta", LoginWindow.send_Id);
            cmd.ExecuteNonQuery();

            SqlDataReader czytnik = cmd.ExecuteReader();
            if (czytnik.HasRows)
            {
                while (czytnik.Read())
                {
                    string data = czytnik["Date"].ToString().Trim();
                    daty.Add(data.Trim());
                }
            }
            czytnik.Close();
            sqlConnection.Close();
            foreach (var i in daty)
            {
                listbox_history.Items.Add(i);
            }

            
        }

        void WyborWyniku()
        {
            try
            {

                send_date = listbox_history.SelectedItem.ToString();
            }
            catch
            {

                MessageBox.Show("Nie wybrałeś pomiaru!", "Błąd", MessageBoxButton.OK, MessageBoxImage.Error);
            }
            
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }
    }
}
