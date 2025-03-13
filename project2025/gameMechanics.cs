using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Net.Http;
using Newtonsoft.Json;

namespace project2025
{
    public class gameMechanics
    {
        Form1 data;
        private static readonly HttpClient client = new HttpClient(); 
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
        public  void moveRight()
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
        public async Task MoveLeft2Async()
        {
            if (!collision2())
            {
                move(0);
            }
            else
            {
                MessageBox.Show("Akció");
                string name = data.Text;
                int mone = data.scoree;

                string url = "http://localhost:5555/updateM";
                var jsonObject = new
                {
                    username = name,
                    money = mone
                };

                await UpdateMoneyAsync(url, jsonObject); // Frissítjük a pénzt
            }
        }

        public async Task MoveRight2Async()
        {
            if (!collision2())
            {
                move(-0);
            }
            else
            {
                MessageBox.Show("Akció");

                string name = "user1"; // Ha nem változik, érdemes itt beállítani az értéket.
                int mone = 1000;

                string url = "http://localhost:5555/updateM";
                var jsonObject = new
                {
                    username = name,
                    money = mone
                };

                // Kérést küldünk a pénz frissítéséhez
                await UpdateMoneyAsync(url, jsonObject);
            }
        }

        // Aszinkron metódus, ami végrehajtja a pénz frissítését
        private async Task UpdateMoneyAsync(string url, object jsonObject)
        {
            try
            {
                string jsonData = JsonConvert.SerializeObject(jsonObject);
                StringContent content = new StringContent(jsonData, Encoding.UTF8, "application/json");

                HttpResponseMessage response = await client.PutAsync(url, content);

                if (response.IsSuccessStatusCode)
                {
                    string stringResponse = await response.Content.ReadAsStringAsync();
                    Console.WriteLine(stringResponse);
                    // A válasz kezelése
                    dynamic jsonResponse = JsonConvert.DeserializeObject<dynamic>(stringResponse);
                }
                else
                {
                    MessageBox.Show($"Hiba történt: {response.ReasonPhrase}");
                }
            }
            catch (Exception error)
            {
                MessageBox.Show($"Hiba történt: {error.Message}");
                Console.WriteLine(error.Message);
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
