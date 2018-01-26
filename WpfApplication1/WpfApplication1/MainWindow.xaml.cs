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
using System.Data.SqlClient;
using System.Data;
using System.Threading;
using System.ComponentModel;

namespace WpfApplication1
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        #region Zmienne
        int Puls;
        int Diastolic;
        int Systolic;


        #endregion

        string Login = LoginWindow.send_Username;
       
        public MainWindow()
        {
            InitializeComponent();
            WindowStartupLocation = System.Windows.WindowStartupLocation.CenterScreen;
            label.Content = Login;
        }

       
        private void Dodaj_Pomiar_Click(object sender, RoutedEventArgs e)
        {
            Measurements mn = new Measurements();
            mn.Show();

        }

        private void button_wyloguj_Click(object sender, RoutedEventArgs e)
        {
            LoginWindow lw = new LoginWindow();
            lw.Show();
            this.Close();
            label.Content = "";
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            History_List hl = new History_List();
            hl.Show();
        }

        private void Exit_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }

      
        #region Metody do sprawdzania
        private void SprawdzaniePuls()
        {
            if (this.Puls < 70)
            {
                txt_opis_wynikow.Text += "Zbyt niski puls!" + Environment.NewLine + "Bradykardia to zbyt wolna praca serca. O ile u sportowców takie tętno nie budzi podejrzeń, to u innych osób może być objawem chorób serca, niedoczynności tarczycy, hiperkaliemii albo schorzeń układu nerwowego." + Environment.NewLine  + Environment.NewLine;
                PULS.Foreground = new System.Windows.Media.SolidColorBrush(System.Windows.Media.Color.FromRgb(0, 255, 0));
            }

            if(( this.Puls >= 70) && (this.Puls <= 100))
            {
                txt_opis_wynikow.Text += "Puls w normie!" + Environment.NewLine +  Environment.NewLine;
                PULS.Foreground = new System.Windows.Media.SolidColorBrush(System.Windows.Media.Color.FromRgb(0, 255, 0));
            }

            if (this.Puls > 100)
            {

                txt_opis_wynikow.Text += "Zbyt wysoki puls!" + Environment.NewLine +  Environment.NewLine + "Mamy do czynienia z tachykardią (czyli częstoskurczem). Wiele czynników wpływa na ilość uderzeń serca, dlatego przyczyny wysokiego pulsu mogą być różne. Serce bije szybciej przez stres, gorączkę, alkohol, papierosy, a nawet odwodnienie." + Environment.NewLine  + Environment.NewLine;
                PULS.Foreground = new System.Windows.Media.SolidColorBrush(System.Windows.Media.Color.FromRgb(255, 0, 0));

            }


        }

        private void SprawdzanieCisnienie()
        {
            if ((this.Systolic < 120) && (this.Diastolic < 80))
            {
                txt_opis_wynikow.Text += "Ciśnienie tętnicze optymalne!" + Environment.NewLine  + Environment.NewLine; 
                SKURCZOWE.Foreground = new System.Windows.Media.SolidColorBrush(System.Windows.Media.Color.FromRgb(0, 255, 0));
                ROZKURCZOWE.Foreground = new System.Windows.Media.SolidColorBrush(System.Windows.Media.Color.FromRgb(0, 255, 0));

            }
            if ((this.Systolic >= 120) &&  (this.Systolic <= 130) | (this.Diastolic >= 80) && (this.Diastolic <= 85))
            {

                txt_opis_wynikow.Text += "Ciśnienie tętnicze prawidłowe!" + Environment.NewLine  + Environment.NewLine;
                SKURCZOWE.Foreground = new System.Windows.Media.SolidColorBrush(System.Windows.Media.Color.FromRgb(0, 255, 0));
                ROZKURCZOWE.Foreground = new System.Windows.Media.SolidColorBrush(System.Windows.Media.Color.FromRgb(0, 255, 0));
            }

            if ((this.Systolic > 130) && (this.Systolic <= 139) | (this.Diastolic >= 86) && (this.Diastolic <= 89))
            {

                txt_opis_wynikow.Text += "Ciśnienie tętnicze wysokie prawidłowe!" + Environment.NewLine  + Environment.NewLine;
                SKURCZOWE.Foreground = new System.Windows.Media.SolidColorBrush(System.Windows.Media.Color.FromRgb(0, 255, 0));
                ROZKURCZOWE.Foreground = new System.Windows.Media.SolidColorBrush(System.Windows.Media.Color.FromRgb(0, 255, 0));
            }

            if ((this.Systolic >= 140) && (this.Systolic <= 159) | (this.Diastolic >= 90) && (this.Diastolic <= 99))
            {

                txt_opis_wynikow.Text += "Nadciśnienie tętnicze 1. stopnia!" + Environment.NewLine + "Nadciśnienie stopnia pierwszego można opanować zmianą stylu życia, jeśli okazuje się to nieskuteczne w krótkim czasie lekarz przepisze leki, które trzeba dostosować do organizmu." + Environment.NewLine + Environment.NewLine + "ZAPAMIĘTAJ! Nadciśnienie tętnicze jest chorobą postępującą z upływem czasu. Im dłużej trwa, tym powoduje więcej niekorzystnych zmian w narządach." + Environment.NewLine + Environment.NewLine;
                SKURCZOWE.Foreground = new System.Windows.Media.SolidColorBrush(System.Windows.Media.Color.FromRgb(255, 0, 0));
                ROZKURCZOWE.Foreground = new System.Windows.Media.SolidColorBrush(System.Windows.Media.Color.FromRgb(255, 0, 0));
            }

            if ((this.Systolic >= 160) && (this.Systolic <= 179) | (this.Diastolic >= 100) && (this.Diastolic <= 109))
            {

                txt_opis_wynikow.Text += "Nadciśnienie tętnicze 2. stopnia!" + Environment.NewLine + "Występuje, jeżeli z powodu nadciśnienia tętniczego wystąpił przerost lewej komory serca lub retinopatia cukrzycowa. Konieczny jest jak najszybszy kontakt z lekarzem." + Environment.NewLine + Environment.NewLine + "ZAPAMIĘTAJ! Nadciśnienie tętnicze jest chorobą postępującą z upływem czasu. Im dłużej trwa, tym powoduje więcej niekorzystnych zmian w narządach." + Environment.NewLine + Environment.NewLine;
                SKURCZOWE.Foreground = new System.Windows.Media.SolidColorBrush(System.Windows.Media.Color.FromRgb(255, 0, 0));
                ROZKURCZOWE.Foreground = new System.Windows.Media.SolidColorBrush(System.Windows.Media.Color.FromRgb(255, 0, 0));
            }

            if ((this.Systolic >= 180) && (this.Diastolic >= 110))
            {

                txt_opis_wynikow.Text += "Nadciśnienie tętnicze 3. stopnia!" + Environment.NewLine + "Występuje przy spowodowanej nadciśnieniem tętniczym lewokomorowej niewydolności serca, nerek lub spowodowanym uszkodzeniu mózgu czy siatkówki oka. Konieczny jest jak najszybszy kontakt z lekarzem." + Environment.NewLine + Environment.NewLine + "ZAPAMIĘTAJ! Nadciśnienie tętnicze jest chorobą postępującą z upływem czasu. Im dłużej trwa, tym powoduje więcej niekorzystnych zmian w narządach." + Environment.NewLine + Environment.NewLine;
                SKURCZOWE.Foreground = new System.Windows.Media.SolidColorBrush(System.Windows.Media.Color.FromRgb(255, 0, 0));
                ROZKURCZOWE.Foreground = new System.Windows.Media.SolidColorBrush(System.Windows.Media.Color.FromRgb(255, 0, 0));
            }





        }
        #endregion

        private void SprawdzWyniki()
        {
            try
            {
                this.Puls = int.Parse(txt_Pulse.Text);
                this.Diastolic = int.Parse(txt_Diastolic.Text);
                this.Systolic = int.Parse(txt_Systolic.Text);
                SprawdzanieCisnienie();
                SprawdzaniePuls();
                
            }
            catch
            {
                MessageBox.Show("Wypełnij wszystkie pola!", "Błąd", MessageBoxButton.OK, MessageBoxImage.Warning);

            }
        }

        private void Check_button_Click(object sender, RoutedEventArgs e)
        {
            SprawdzWyniki();
        }
    }
}
