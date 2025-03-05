using System;
using System.Collections.Generic;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using Newtonsoft.Json;
using System.Net.Http;

namespace project2025
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
            start();
        }

        void start()
        {
            button1.Click += async (s, e) =>
            {
                string username = textbox1.Text;
                string password = textbox2.Text;
                HttpClient client = new HttpClient();
                string url = "http://localhost:3000/login"; 

                try
                {
                    var jsonObject = new
                    {
                        name = textbox1.Text,
                        password = textbox2.Text
                    };

                    string jsonData = JsonConvert.SerializeObject(jsonObject);
                    StringContent data = new StringContent(jsonData, Encoding.UTF8, "application/json");
                    HttpResponseMessage response = await client.PostAsync(url, data);
                    string stringResponse = await response.Content.ReadAsStringAsync();

                    
                    dynamic jsonResponse = JsonConvert.DeserializeObject<dynamic>(stringResponse);

                    
                    if (jsonResponse.message == "sikeres bejelentkezés")
                    
                    {
                        MessageBox.Show("Sikeres bejelentkezés!");
                        Window1 win1 = new Window1();
                        win1.Title = textbox1.Text;
                        win1.Show();
                    }
                    else
                    {
                        MessageBox.Show("Felhasználó vagy jelszó helytelen");
                    }
                }
                catch (Exception error)
                {
                    MessageBox.Show(error.Message);
                    
                }
            };
            button2.Click += (s, e) =>
            {
                Window2 win2 = new Window2();
                win2.Show();
            };
        }
    }

    
    
}
