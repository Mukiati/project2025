using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace project2025
{
    public class gameMechanics
    {
        Form1 data;
        void gravity()
        {
            Timer fall = new Timer();
            fall.Interval = 10;
            fall.Tick += (s, e) => {
                speed -= 2;
                data.ch.Top -= speed / 10;
                if (floor())
                {
                    falling = false;
                    fall.Stop();
                }
            };
            if (!floor())
            {
                speed = 0;
                fall.Start();
            }
        }
        public gameMechanics(Form1 data)
        {
            this.data = data;
            speed = 0;
            
            
            data.makeBlock();

        }
        int speed;     
        bool falling = false;
        public void jump()
        {
            Timer fall = new Timer();
            fall.Interval = 10;
            fall.Tick += (s, e) => {
                speed -= 2;
                data.ch.Top -= speed / 10;
                ceiling();
                if (floor())
                {
                    falling = false;
                    fall.Stop();
                }
            };       
            if (floor())
            {
                fall.Start();              
                falling = true;
                speed = 100;
            }
        }
        public void moveLeft()
        {
            if (!collision())
            {
                move(10);
            }
            else
            {
                MessageBox.Show("Meghaltál!");
            }
        }
        public void moveRight()
        {
            if (!collision())
            {
                move(-10);
            }

            else
            {
                MessageBox.Show("Meghaltál!");
            }
        }
        public void moveLeft2()
        {
            if (!collision2())
            {
                move(0);
            }
            else
            {
                MessageBox.Show("akció");
            }
        }
        public void moveRight2()
        {
            if (!collision2())
            {
                move(-0);
            }

            else
            {
                MessageBox.Show("akció");
            }
        }
        void getScore()
        {
            int allScore = 0;
            foreach (PictureBox item in data.blocks)
            {
                if (item.Left < data.ch.Left)
                {
                    allScore++;
                }
            }
            data.updateScore(allScore);
        }
        void move(int step)
        {
            getScore();         
            foreach (PictureBox item in data.blocks)
            {
                item.Left += step;
            }          
            if (!falling)
            {
                gravity();
            }         
            if (data.blocks.Last().Left < data.Width / 2)
            {
                data.makeBlock();
            }


            foreach (PictureBox item in data.blocks2)
            {
                item.Left += step;
            }
            if (!falling)
            {
                gravity();
            }
            if (data.blocks2.Last().Left < data.Width / 2)
            {
                data.makeBlock();
            }
        }
        bool floor()
        {
            {
               
                if (data.ground.Top < data.ch.Bottom)
                {
                    data.ch.Top = data.ground.Top - data.ch.Height;
                }
                if (data.ground.Top == data.ch.Bottom)
                {
                    return true;
                }             
                foreach (PictureBox item in data.blocks)
                { 
                    if (overBlock(item))
                    {  
                        if (data.ch.Bottom > item.Top)
                        {
                            data.ch.Top = item.Top - data.ch.Height;
                        }
                        if (data.ch.Bottom == item.Top)
                        {
                            return true;
                        }
                    }
                }
            }
            return false;



            {

                if (data.ground.Top < data.ch.Bottom)
                {
                    data.ch.Top = data.ground.Top - data.ch.Height;
                }
                if (data.ground.Top == data.ch.Bottom)
                {
                    return true;
                }
                foreach (PictureBox item in data.blocks2)
                {
                    if (overBlock(item))
                    {
                        if (data.ch.Bottom > item.Top)
                        {
                            data.ch.Top = item.Top - data.ch.Height;
                        }
                        if (data.ch.Bottom == item.Top)
                        {
                            return true;
                        }
                    }
                }
            }
            return false;
        }
        bool overBlock(PictureBox item)
        {
            if (data.ch.Top >= item.Bottom)
            {
                return false;
            }
            if (data.ch.Left == item.Left)
            {
                return true;
            }       
            if (data.ch.Left < item.Left
                && (data.ch.Right > item.Left))
            {
                return true;
            }          
            if (data.ch.Left < item.Right
               && (data.ch.Right > item.Right))
            {
                return true;
            }
            return false;
        }      
        bool underBlock(PictureBox item)
        {
          
            if (data.ch.Top < item.Bottom && data.ch.Top > item.Top)
            {
                if (data.ch.Left == item.Left)
                {
                    return true;
                }             
                if (data.ch.Left < item.Left
                    && (data.ch.Right > item.Left))
                {
                    return true;
                }              
                if (data.ch.Left < item.Right
                   && (data.ch.Right > item.Right))
                {
                    return true;
                }
            }
            return false;
        }       
        void ceiling()
        {
            if (isCeiling())
            {
                speed = 0;
            }
            else if (isCeiling2())
            {
                speed = 0;
            }
        }      
        bool isCeiling()
        {        
            foreach (PictureBox item in data.blocks)
            {
                
                if (underBlock(item))
                {
                    data.ch.Top = item.Bottom;
                    return true;
                }
            }
            return false;
        }
        bool isCeiling2()
        {
            foreach (PictureBox item in data.blocks2)
            {

                if (underBlock(item))
                {
                    data.ch.Top = item.Bottom;
                    return true;
                }
            }
            return false;
        }
        bool collision()
        {
            foreach (PictureBox item in data.blocks)
            {
                if (data.ch.Bounds.IntersectsWith(item.Bounds))
                {
                    return true;
                }
            }
            return false;
        }
        bool collision2()
        {
            foreach (PictureBox item in data.blocks2)
            {
                if (data.ch.Bounds.IntersectsWith(item.Bounds))
                {
                    return true;
                }
            }
            return false;
        }
        
    }
}
