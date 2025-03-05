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
using System.Timers;
using System.Windows.Threading;

namespace project2025
{
    /// <summary>
    /// Interaction logic for Window1.xaml
    /// </summary>
    public partial class Window1 : Window
    {
        private DispatcherTimer _timer;
        int scoree;
        public Window1()
        {
            InitializeComponent();
            pointwrite();
            addscore();
        }
        void pointwrite()
        {
            score.Text = "Pontok: "+ scoree;
        }
        void addscore()
        {
            _timer = new DispatcherTimer();
            _timer.Interval = TimeSpan.FromSeconds(1); // Minden 1 másodpercben fog tickelni
            _timer.Tick += Timer_Tick; // A Tick eseményhez hozzárendelünk egy eseménykezelőt
            _timer.Start();
        }
        private void Timer_Tick(object sender, EventArgs e)
        {
            scoree++;
            score.Text = "Pontok: " + scoree;
        }
    }
}