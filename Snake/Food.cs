using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Snake
{
    class Food:Panel
    {
        private int posx;
        private int posy;
        public Food(Cave cave)
        {
            Random rand = new Random();
            this.Width = Const.Unit_Game;
            this.Height = Const.Unit_Game;
            this.BackColor = Color.Red;
            this.posx = rand.Next(0, Const.Game_Width-1);
            this.posy = rand.Next(0, Const.Gmae_Height-1);
            this.Location = new Point(this.posx * Const.Unit_Game, this.posy * Const.Unit_Game);
            cave.Controls.Add(this);
            
        }

        public int Posx { get => posx; set => posx = value; }
        public int Posy { get => posy; set => posy = value; }
    }
}
