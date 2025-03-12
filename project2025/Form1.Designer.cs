using System.Windows.Forms;
using System.Drawing;
using System.Collections.Generic;
using System;
namespace project2025
{
    partial class Form1
    {
        Random r = new Random();
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        /// 
        public List<PictureBox> blocks = new List<PictureBox>();
        public List<PictureBox> blocks2 = new List<PictureBox>();



        private void InitializeComponent()
        {
            this.score = new System.Windows.Forms.TextBox();
            this.ground = new System.Windows.Forms.PictureBox();
            this.ch = new System.Windows.Forms.PictureBox();
            ((System.ComponentModel.ISupportInitialize)(this.ground)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.ch)).BeginInit();
            this.SuspendLayout();
            // 
            // score
            // 
            this.score.Enabled = false;
            this.score.Location = new System.Drawing.Point(12, 12);
            this.score.Name = "score";
            this.score.Size = new System.Drawing.Size(100, 20);
            this.score.TabIndex = 0;
            // 
            // ground
            // 
            this.ground.BackColor = System.Drawing.Color.Lime;
            this.ground.Location = new System.Drawing.Point(1, 386);
            this.ground.Name = "ground";
            this.ground.Size = new System.Drawing.Size(800, 65);
            this.ground.TabIndex = 2;
            this.ground.TabStop = false;
            // 
            // ch
            // 
            this.ch.BackColor = System.Drawing.Color.Cyan;
            this.ch.Location = new System.Drawing.Point(82, 300);
            this.ch.Name = "ch";
            this.ch.Size = new System.Drawing.Size(49, 80);
            this.ch.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.ch.TabIndex = 4;
            this.ch.TabStop = false;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.ch);
            this.Controls.Add(this.ground);
            this.Controls.Add(this.score);
            this.Name = "Form1";
            this.Text = "Form1";
            ((System.ComponentModel.ISupportInitialize)(this.ground)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.ch)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }
        public void updateScore(int score)
        {
            this.score.Text = "SCORE: " + score.ToString();
        }
        public void makeBlock()
        {
            PictureBox block = new PictureBox();
            Controls.Add(block);
            block.BackColor = Color.Red;
            block.Width = 50;
            block.Height = 50;

            int left = this.Width + block.Width;
            int[] heights = new int[3];
            heights[0] = this.Height - 100 - block.Height;
            heights[1] = this.Height - 150 - block.Height;
            heights[2] = this.Height - 250 - block.Height;
            block.Location = new Point(left, heights[r.Next(0, 3)]);
           
            Image img = Image.FromFile("alap.png");
            block.BackgroundImage = img;
            block.BackgroundImageLayout = ImageLayout.Center;

            blocks.Add(block);
            

           

            PictureBox blockc = new PictureBox();
            Controls.Add(blockc);
            //blockc.BackColor = Color.Red;
            blockc.Width = 50;
            blockc.Height = 50;

            int leftt = this.Width + blockc.Width;
            int[] heightss = new int[3];
            heightss[0] = this.Height - 200 - blockc.Height;
            heightss[1] = this.Height - 250 - blockc.Height;
            heightss[2] = this.Height - 350 - blockc.Height;
            blockc.Location = new Point(leftt, heightss[r.Next(0, 3)]); 


            Image imgg = Image.FromFile("asd3.png");
            blockc.BackgroundImage = imgg;
            blockc.BackgroundImageLayout = ImageLayout.Center;
            blockc.Size = blockc.BackgroundImage.Size;
           
            blocks2.Add(blockc);
        }
        #endregion

        public System.Windows.Forms.TextBox score;
        public System.Windows.Forms.PictureBox ground;
        public System.Windows.Forms.PictureBox ch;
    }
}