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
using System.Net.Http;
using Newtonsoft.Json;

namespace project2025
{
    /// <summary>
    /// Interaction logic for Window2.xaml
    /// </summary>
    public partial class Window2 : Window
    {
        public Window2()
        {
            InitializeComponent();
            createuser();
        }
        async void createuser()
        {
            HttpClient client = new HttpClient();
            string url = "http://127.0.0.1:5555/registerRequest";
            try
            {
                HttpResponseMessage response = await client.GetAsync(url);
                string stringResponse = await response.Content.ReadAsStringAsync();
                
            }
            catch (Exception)
            {

                throw;
            }
        }
        async void Adduser(object s, EventArgs e)
        {
            HttpClient client = new HttpClient();
            string url = "http://127.1.1.1:4444/alma";
            try
            {
                var jsonObject = new
                {
                    username = textbox1.Text,
                    password = textbox2.Text,
                    email = textbox3.Text
                };

                string jsonData = JsonConvert.SerializeObject(jsonObject);
                StringContent data = new StringContent(jsonData, Encoding.UTF8, "application/json");

                HttpResponseMessage response = await client.PostAsync(url, data);
                response.EnsureSuccessStatusCode();
                createuser();
            }
            catch (Exception error)
            {

                MessageBox.Show(error.Message);
            }
            //MessageBox.Show($"Alma neve: {nev.Text} , Alma ára: {ar.Text}");
        }
    }
}
