using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace project2025
{
    public partial class Form1 : Form
    {
        int scoree;
        public Form1()
        {
            InitializeComponent();
            pointwrite();
        }
        void pointwrite()
        {
            score.Text = "Pontok: " + scoree;
        }
    }
}
