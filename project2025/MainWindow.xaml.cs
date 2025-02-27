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
            button1.Click += (s, e) =>
            {
                if (textbox1.Text == "levi" && textbox2.Text == "cigany")
                {
                    MessageBox.Show("Sikeres bejelentkezés");
                    Window1 win1 = new Window1();
                    win1.Show();
                    
                    
                    
                }
                else if (textbox1.Text != "levi" || textbox1.Text != "levi")
                {
                    MessageBox.Show("Felhasznalónév vagy jelszó  helytelen ");
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
