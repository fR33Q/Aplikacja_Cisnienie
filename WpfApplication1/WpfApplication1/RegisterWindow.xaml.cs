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
    /// Interaction logic for RegisterWindow.xaml
    /// </summary>
    public partial class RegisterWindow : Window
    {
        

        string connectionString = @"Data Source=localhost\SQLEXPRESS; Initial Catalog=LoginDB; Integrated Security=True;";

        public RegisterWindow()
        {
            InitializeComponent();
            WindowStartupLocation = System.Windows.WindowStartupLocation.CenterScreen;

        }

        private void btnRegisterv2_Click(object sender, RoutedEventArgs e)
        {

            using (SqlConnection sqlConnection = new SqlConnection(connectionString))
            {
                sqlConnection.Open();
                if (txtnazwa_uzytkownika.Text != "" && txthaslo.Password != "")
                {
                    SqlCommand cmd = new SqlCommand();
                    cmd.CommandText = "INSERT into [Pacjenci](Username, Password) values (@Username , @Password)";
                    cmd.Parameters.AddWithValue("@Username", txtnazwa_uzytkownika.Text);
                    cmd.Parameters.AddWithValue("@Password", txthaslo.Password);
                    cmd.Connection = sqlConnection;
                    int a = cmd.ExecuteNonQuery();
                    if (a == 1)
                    {
                        MessageBox.Show("Rejestracja powiodła się!");

                    }


                    Clear();
                    LoginWindow lw = new LoginWindow();
                    lw.Show();
                    this.Close();

                }
                else
                {

                    MessageBox.Show("Wypełnij wszystkie pola!", "Ostrzeżenie", MessageBoxButton.OK, MessageBoxImage.Warning);

                }
            }
        }
                void Clear()
                {
                txtnazwa_uzytkownika.Text = txthaslo.Password = "";
                
                }

        private void Exit_bt_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            LoginWindow lg = new LoginWindow();
            this.Close();
            lg.Show();
        }
    }
    }

