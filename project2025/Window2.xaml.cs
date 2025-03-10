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
         void createuser()
        {
            button1.Click += async (s, e) =>
            {
                string username = textbox1.Text;
                string password = textbox2.Text;
                HttpClient client = new HttpClient();
                string url = "http://localhost:5555/register";

                try
                {
                    var jsonObject = new
                    {
                        username = textbox1.Text,
                        password = textbox2.Text
                    };
                    if (textbox1.Text != "" && textbox2.Text != "")
                    {
                        string jsonData = JsonConvert.SerializeObject(jsonObject);
                        StringContent data = new StringContent(jsonData, Encoding.UTF8, "application/json");
                        HttpResponseMessage response = await client.PostAsync(url, data);
                        string stringResponse = await response.Content.ReadAsStringAsync();
                        dynamic jsonResponse = JsonConvert.DeserializeObject<dynamic>(stringResponse);
                        if (response.IsSuccessStatusCode && jsonResponse.message == "sikeres regisztráció")
                        {
                            MessageBox.Show("Sikeres regisztrácio");
                        }
                    }
                    else
                    {
                        MessageBox.Show("Felhasználó n év vagy jelszó hiányos");
                    }

                    
                }
                catch (Exception error)
                {

                    MessageBox.Show(error.Message);
                }
            };
        }
        
    }
}
