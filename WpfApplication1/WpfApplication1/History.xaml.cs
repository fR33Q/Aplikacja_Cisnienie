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

namespace WpfApplication1
{
    /// <summary>
    /// Logika interakcji dla klasy History.xaml
    /// </summary>
    public partial class History : Window
    {
        string connectionString = @"Data Source=localhost\SQLEXPRESS; Initial Catalog=LoginDB; Integrated Security=True;";

        public History()
        {
            InitializeComponent();
            WindowStartupLocation = System.Windows.WindowStartupLocation.CenterScreen;
            label_date.Content = History_List.send_date;
            Wypelnij();

        }

        private void Exit_bt_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
            
        }

        #region
       
        string Pulse_zmiana;
        int Pulse;

        string Diastolic_zmiana;
        int Diastolic;

        string Systolic_zmiana;
        int Systolic;

        string data = History_List.send_date;
        #endregion

        
        private void Wypelnij()
        {
            Resetuj();
            using (SqlConnection sqlConnection = new SqlConnection(connectionString))
            {
                
                    sqlConnection.Open();
                try
                {
                    String zapytanie = "SELECT Pulse,Systolic,Diastolic,Date FROM [Pomiary] Where idPacjenta = @id AND Date = @date";
                    SqlCommand cmd = new SqlCommand(zapytanie, sqlConnection);
                    cmd.Parameters.AddWithValue("@id", LoginWindow.send_Id);
                    cmd.Parameters.AddWithValue("@date", History_List.send_date);
                    SqlDataReader czytnik = cmd.ExecuteReader();
                    if (czytnik.HasRows)
                    {
                        while (czytnik.Read())
                        {
                            Pulse_zmiana = czytnik["Pulse"].ToString().Trim();
                            Pulse = int.Parse(Pulse_zmiana);
                            Systolic_zmiana = czytnik["Systolic"].ToString().Trim();
                            Systolic = int.Parse(Systolic_zmiana);
                            Diastolic_zmiana = czytnik["Diastolic"].ToString().Trim();
                            Diastolic = int.Parse(Diastolic_zmiana);


                            txt_pulse.Text = Pulse.ToString();
                            txt_systolic.Text = Systolic.ToString();
                            txt_diastolic.Text = Diastolic.ToString();


                        }
                    }
                    czytnik.Close();
                }
                catch(Exception e)
                {

                }
                
                sqlConnection.Close();

               
            }
                                                        

        }
        void Resetuj()
        {
            Pulse_zmiana = null;
            Systolic_zmiana = null;
            Diastolic_zmiana = null;
            Pulse = 0;
            Diastolic = 0;
            Systolic = 0;


        }

        


    }
}
