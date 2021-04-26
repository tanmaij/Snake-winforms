using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Snake
{
    class Snake
    {
        private int atribute=Const.Snake_Atribute_Right;
        public List<Body> snake=new List<Body>();
        public Snake(Cave cave)
        {
            Body Head = new Body(2, 0);
            Body body = new Body(1, 0);
            Body body1 = new Body(0, 0);
            snake.Add(Head);
            snake.Add(body);
            snake.Add(body1);
            this.snake[0].BackgroundImageLayout = ImageLayout.Stretch;
            this.snake[0].BackgroundImage = Image.FromFile("HEADright.png");
            foreach(Body bod in this.snake)
            {
                cave.Controls.Add(bod);
            }
        }

        public void Update()
        {
            
            if(this.atribute== Const.Snake_Atribute_Up)
            {
                snake[0].move(snake[0].Posx, snake[0].Posy-1);
            }
            else if (this.atribute == Const.Snake_Atribute_Right)
            {
                snake[0].move(snake[0].Posx+1, snake[0].Posy);
            }
            else if (this.atribute == Const.Snake_Atribute_Down)
            {
                snake[0].move(snake[0].Posx, snake[0].Posy + 1);
            }
            else if (this.atribute == Const.Snake_Atribute_Left)
            {
                snake[0].move(snake[0].Posx-1, snake[0].Posy);
            }
            move();
            setImageHead(this.atribute);
        }
        public void move()
        {

            for (int i = 1; i < snake.Count ; i++)
            {
                snake[i].move(snake[i - 1].OldPos.X, snake[i - 1].OldPos.Y);
            }
        }
        void setImageHead(int atribute)
        {
            if (this.atribute == Const.Snake_Atribute_Up)
            {
                this.snake[0].BackgroundImage = Image.FromFile("HEAD.png");
            }
            else if (this.atribute == Const.Snake_Atribute_Right)
            {
                this.snake[0].BackgroundImage = Image.FromFile("HEADRight.png");
            }
            else if (this.atribute == Const.Snake_Atribute_Down)
            {
                this.snake[0].BackgroundImage = Image.FromFile("HEADBottom.png");
            }
            else if (this.atribute == Const.Snake_Atribute_Left)
            {
                this.snake[0].BackgroundImage = Image.FromFile("HEADleft.png");
            }
        }
        public void eaten(Cave cave)
        {
            Body body = new Body(this.snake[this.snake.Count - 1].OldPos.X, this.snake[this.snake.Count - 1].OldPos.Y);
            this.snake.Add(body);
            cave.Controls.Add(body);
        }
        public int Atribute { get => atribute; set => atribute = value; }
    }
}
