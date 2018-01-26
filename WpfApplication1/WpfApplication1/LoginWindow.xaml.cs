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
    /// Interaction logic for LoginWindow.xaml
    /// </summary>
    public partial class LoginWindow : Window
    {
        #region Dane do wyslania

        string Username;
        
        int Id;

        public static string send_Username;
        public static int send_Id;
        #endregion


        void Wyslij()
        {
            send_Username = this.Username;
            send_Id = this.Id;

        }

        void CzytajId()
        {
            string connectionString = @"Data Source=localhost\SQLEXPRESS; Initial Catalog=LoginDB; Integrated Security=True;";

            SqlConnection sqlcon = new SqlConnection(connectionString);
            sqlcon.Open();
            SqlCommand cmd = new SqlCommand("SELECT idPacjenta, Username FROM Pacjenci WHERE Username = @Username", sqlcon);
            cmd.Parameters.AddWithValue("@Username", this.txtnazwa_uzytkownika.Text);
            cmd.ExecuteNonQuery();

            SqlDataReader czytaj = cmd.ExecuteReader();
            while (czytaj.Read())
            {
                string idZmiana = czytaj["idPacjenta"].ToString().Trim();
                this.Id = int.Parse(idZmiana);
                this.Username = czytaj["Username"].ToString().Trim();


            }
            czytaj.Close();
            sqlcon.Close();
            Wyslij();


        }

        public LoginWindow()
        {
            InitializeComponent();
            WindowStartupLocation = System.Windows.WindowStartupLocation.CenterScreen;


        }

        private void btnSubmit_Click(object sender, RoutedEventArgs e)
        {
            Loguj();
            
        }

        void Loguj()
        {
            SqlConnection sqlConnection = new SqlConnection(@"Data Source=localhost\SQLEXPRESS; Initial Catalog=LoginDB; Integrated Security=True;");

            try
            {

                sqlConnection.Open();
                String query = "SELECT COUNT(1) FROM Pacjenci WHERE Username=@Username AND Password=@Password";
                SqlCommand sqlCmd = new SqlCommand(query, sqlConnection);
                sqlCmd.CommandType = CommandType.Text;
                sqlCmd.Parameters.AddWithValue("@Username", txtnazwa_uzytkownika.Text);
                sqlCmd.Parameters.AddWithValue("@Password", txthaslo.Password);

                int count = Convert.ToInt32(sqlCmd.ExecuteScalar());
                if (count == 1)
                {
                    CzytajId();
                    MainWindow dashboard = new MainWindow();
                    dashboard.Show();
                    this.Close();
                }
                else
                {
                    
                    MessageBox.Show("Nazwa użytkownika lub hasło są nieprawidłowe!");
                }
                sqlConnection.Close();


            }
            catch
            {
                
                MessageBox.Show("Mamy problem z bazą!");

            }
                
            

        }

        private void btnRegister_Click(object sender, RoutedEventArgs e)
        {
            RegisterWindow rg = new RegisterWindow();
            rg.Show();
            this.Close();
        }

        private void Exit_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }

       
    }

    


}

