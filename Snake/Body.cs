using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Snake
{
    class Body:Panel
    {
        private int posx;
        private int posy;
        public Point OldPos;
        public Body(int posx,int posy)
        {
            this.posx = posx;
            this.posy = posy;
            this.Width = Const.Unit_Game;
            this.Height = Const.Unit_Game;
            this.BackColor = Color.Yellow;
            this.Location = new Point(Posx * Const.Unit_Game, Posy * Const.Unit_Game);
        }
        public void move (int posx, int posy)
        {
            this.OldPos.X = this.posx;
            this.OldPos.Y = this.posy;
            //  this.Location = new Point(posx * Const.Unit_Game, posy * Const.Unit_Game);
            this.posx = posx;
            this.posy = posy;
        }
        public int Posx { get => posx; set => posx = value; }
        public int Posy { get => posy; set => posy = value; }
    }
}
