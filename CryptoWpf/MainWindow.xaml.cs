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
using System.Net.Http;


namespace CryptoWpf
{
    /// <summary>
    /// Логика взаимодействия для MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            
            InitializeComponent();
            LoadAllCryptos();
        }
        async void LoadAllCryptos()
        {
            using (HttpClient client = new HttpClient())
            { 
                  HttpResponseMessage response = await client.GetAsync("https://localhost:7254/api/Crypto");
                  if(response.IsSuccessStatusCode)
                {
                    List<CryptoDTO> ls = await response.Content.ReadAsAsync<List<CryptoDTO>>();
                    dgCryptos.ItemsSource = ls;
                    dgCryptos.DataContext = ls;
                } 
                  else
                {
                    MessageBox.Show("SERVER ERROR OR NOT RESPONDING");
                }
            }
        }
        private async void SaveCryptos(Crypto crypto)
        {
            using(HttpClient client = new HttpClient())
            {
                await client.PostAsJsonAsync("crypto",crypto);
            }
        }
        private async void UpdateStudents(Crypto crypto)
        {
            using(HttpClient client = new HttpClient())
            {
                await client.PutAsJsonAsync("crypto/" + crypto.Id, crypto);
            }
        }
        private async void DeleteCrypto(int id)
        {
            using (HttpClient client = new HttpClient())
            {
                await client.DeleteAsync("crypto/" + id);
            }
        }
        private void btnEdit(object sender, RoutedEventArgs e)
        {
            Crypto crypto = ((FrameworkElement)sender).DataContext as Crypto;
            txtFrom.Text = crypto.trFrom.ToString();
            txtTo.Text = crypto.trTo.ToString();
            txtAmount.Text = crypto.cryptoAmount.ToString();
            txtType.Text=crypto.currencyType.ToString();
            txtTransfer.Text=crypto.transferType.ToString();
            txtDate.Text = crypto.transferDate.ToString();
            txtBalance.Text=crypto.balance.ToString();
            
        }

        private void btnDelete(object sender, RoutedEventArgs e)
        {
            Crypto crypto = ((FrameworkElement)sender).DataContext as Crypto;
            this.DeleteCrypto(crypto.Id);

        }
    }
}
