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
                string name = textbox1.Text;
                string passw = textbox2.Text;
                HttpClient client = new HttpClient();
                string url = "http://localhost:5555/login";

                try
                {
                    
                    var jsonObject = new
                    {
                        username = name,
                        password = passw
                    };

                    string jsonData = JsonConvert.SerializeObject(jsonObject);
                    StringContent data = new StringContent(jsonData, Encoding.UTF8, "application/json");


                    HttpResponseMessage response = await client.PostAsync(url, data);
                    string stringResponse = await response.Content.ReadAsStringAsync();
                    

                    dynamic jsonResponse = JsonConvert.DeserializeObject<dynamic>(stringResponse);



                    if (response.IsSuccessStatusCode)
                    {
                        MessageBox.Show("Sikeres bejelentkezés!");
                        Form1 form1 = new Form1();
                        form1.Text = name;
                        form1.Show();
                    }
                    else
                    {
                        MessageBox.Show("Felhasználó vagy jelszó helytelen");
                    }
                }
                catch (Exception error)
                {
                    MessageBox.Show($"Hiba történt: {error.Message}");
                    
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