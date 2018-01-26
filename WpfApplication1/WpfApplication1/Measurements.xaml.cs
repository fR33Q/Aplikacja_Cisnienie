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
    /// Logika interakcji dla klasy Measurements.xaml
    /// </summary>
    public partial class Measurements : Window
    {
        string connectionString = @"Data Source=localhost\SQLEXPRESS; Initial Catalog=LoginDB; Integrated Security=True;";

        public Measurements()
        {
            InitializeComponent();
            WindowStartupLocation = System.Windows.WindowStartupLocation.CenterScreen;
        }

        string GenerujDate()
        {
            string data = "";
            DateTime dat = DateTime.Now;
            var culture = new CultureInfo("de-DE");
            data = dat.ToString(culture);
            return data;

        }

        private void Dodaj_Click(object sender, RoutedEventArgs e)
        {
            using (SqlConnection sqlConnection = new SqlConnection(connectionString))
            {   if (txt_diastolic.Text != "" && txt_systolic.Text != "" && txt_pulse.Text != "")
                {
                sqlConnection.Open();
                try
                {
                        SqlCommand cmd = new SqlCommand();
                        cmd.CommandText = "INSERT into [Pomiary](idPacjenta,Systolic,Diastolic, Pulse,Date) values (@idPacjenta, @Systolic , @Diastolic, @Pulse,@Date)";
                        cmd.Parameters.AddWithValue("@idPacjenta", LoginWindow.send_Id);
                        cmd.Parameters.AddWithValue("@Date", GenerujDate());
                        cmd.Parameters.AddWithValue("@Systolic", txt_systolic.Text);
                        cmd.Parameters.AddWithValue("@Diastolic", txt_diastolic.Text);
                        cmd.Parameters.AddWithValue("@Pulse", txt_pulse.Text);
                        cmd.Connection = sqlConnection;
                        int a = cmd.ExecuteNonQuery();

                        if (a == 1)
                        {

                            MessageBox.Show("Pomiar dodany!","Gratulacje",MessageBoxButton.OK,MessageBoxImage.Information);
                        }
                    
                }
                catch
                {
                    MessageBox.Show("Coś jest nie tak!", "Błąd", MessageBoxButton.OK, MessageBoxImage.Error);


                }
                 }
                else
                {
                        MessageBox.Show("Wypełnij wszystkie pola!", "Ostrzeżenie", MessageBoxButton.OK, MessageBoxImage.Warning);

                }
            }
        }

        private void Exit_bt_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }
    }
}
