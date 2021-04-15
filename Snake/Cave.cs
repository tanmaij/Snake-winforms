using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Snake
{
    class Cave:Panel
    {
        
        public Cave(Form game)
        {
            
            this.Width = Const.Game_Width * Const.Unit_Game;
            this.Height= Const.Gmae_Height * Const.Unit_Game;
            this.BackgroundImage = Image.FromFile("background.png");
            game.Controls.Add(this);
        }
        
    }
}
