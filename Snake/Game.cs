using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Snake
{
    public partial class Game : Form
    {
        int speed = 1000;
        Timer loop;
        Cave cave;
        Snake snake;
        Food food;
        public Game()
        {

            InitializeComponent();
            this.Width = Const.Game_Width * Const.Unit_Game;
            this.Height = Const.Gmae_Height * Const.Unit_Game;
            newGame();

        }
       

        private void Loop_Tick(object sender, EventArgs e)
        {
            
            snake.Update();
            update();
        }
        void update()
        {
            EndGame();
            for (int i = 0; i < snake.snake.Count; i++)
            {
                snake.snake[i].Location = new Point(snake.snake[i].Posx * Const.Unit_Game, snake.snake[i].Posy * Const.Unit_Game);
            }
            if(snake.snake[0].Posx==food.Posx && snake.snake[0].Posy==food.Posy)
            {
                snake.eaten(cave);
                cave.Controls.Remove(food);
                
                loop.Interval = this.speed;
                food = new Food(cave);
            }
            
        }
        
        private void Game_Load(object sender, EventArgs e)
        {

        }
        void EndGame()
        {
            if(snake.snake[0].Posx <0 || snake.snake[0].Posx > Const.Game_Width-1 || snake.snake[0].Posy < 0 || snake.snake[0].Posy > Const.Game_Width - 1 || eatself()==true)
            {
                loop.Enabled = false;
                if (MessageBox.Show("Thua, " + (snake.snake.Count-3) + " DIEM ", "THUA ROI", MessageBoxButtons.YesNo) == DialogResult.Yes)
                {
                    newGame();
                }
                else this.Close();
            }
            
        }
        void newGame()
        {
            this.Controls.Clear();
            cave = new Cave(this);
            food = new Food(cave);
            snake = new Snake(cave);
            loop = new Timer();
            loop.Tick += Loop_Tick;
            loop.Interval = speed;
            loop.Enabled = true;
        }
        bool eatself()
        {
            for (int i = 1; i < snake.snake.Count; i++)
            {
                if (snake.snake[0].Posx == snake.snake[i].Posx && snake.snake[0].Posy == snake.snake[i].Posy)
                    return true;
            }
            return false;
        }

        private void Game_KeyDown(object sender, KeyEventArgs e)
        {
            if(e.KeyCode==Keys.Up && snake.Atribute!=Const.Snake_Atribute_Down)
            {
                snake.Atribute = Const.Snake_Atribute_Up;
            }
            else if (e.KeyCode == Keys.Right && snake.Atribute != Const.Snake_Atribute_Left)
            {
                snake.Atribute = Const.Snake_Atribute_Right;
            }
            else if (e.KeyCode == Keys.Down && snake.Atribute != Const.Snake_Atribute_Up)
            {
                snake.Atribute = Const.Snake_Atribute_Down;

            }
            else if (e.KeyCode == Keys.Left && snake.Atribute != Const.Snake_Atribute_Right)
            {
                snake.Atribute = Const.Snake_Atribute_Left;
            }

        }

        private void Game_KeyPress(object sender, KeyPressEventArgs e)
        {
           
        }
    }
}
