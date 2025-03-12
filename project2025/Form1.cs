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
        gameMechanics gms;
        int scoree;
        public Form1()
        {
            InitializeComponent();
            gms = new gameMechanics(this);
            StartGame();
        }
        void StartGame()
        {
            KeyPreview = true;
            this.KeyDown += (s, e) => {
                if (e.KeyCode == Keys.Space)
                {
                    gms.jump();

                }
                else if (e.KeyCode == Keys.A || e.KeyCode == Keys.Left)
                {
                    gms.moveLeft();
                    gms.moveLeft2();
                }
                else if (e.KeyCode == Keys.Right || e.KeyCode == Keys.D)
                {
                    gms.moveRight();
                    gms.moveRight2();
                }
            };
        }





    }
}
