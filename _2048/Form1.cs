using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;
using _2048.Properties;

namespace _2048
{
    public partial class Form1 : Form
    {
        private static string formColor;
        private static string cubeColor;
        private Color c;

        private static Form1 instanse;

        public static Form1 Instanse => instanse;

        Game game = new Game();

        public Thread thread;

        public Form1()
        {
            instanse = this;
            InitializeComponent();
            game.StartGame();
            thread = new Thread(game.IsGameOver);
            thread.IsBackground = true;
            //Thread.CurrentThread.IsBackground = true;
            thread.Start();
        }


        public PictureBox GetPictureBoxByName(string name)
        {
            foreach (object p in this.Controls)
            {
                if (p.GetType() == typeof(PictureBox))
                    if (((PictureBox)p).Name == name)
                        return (PictureBox)p;
            }
            return null;
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            this.MaximumSize = new Size(this.Width, this.Height);
            this.MinimumSize = new Size(this.Width, this.Height);
            Up.Visible = false;
            Down.Visible = false;
            Left.Visible = false;
            Rigth.Visible = false;
        }

        private void Up_Click(object sender, EventArgs e)
        {
            game.MoveUp();
            game.NewNumber();
        }

        private void Down_Click(object sender, EventArgs e)
        {
            game.MoveDown();
            game.NewNumber();
        }

        private void Left_Click(object sender, EventArgs e)
        {
            game.MoveLeft();
            game.NewNumber();
        }

        private void Rigth_Click(object sender, EventArgs e)
        {
            game.MoveRigth();
            game.NewNumber();
        }

        private void Form1_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Up)
            {
                game.MoveUp();
                game.NewNumber();
            }
            if (e.KeyCode == Keys.Down)
            {
                game.MoveDown();
                game.NewNumber();
            }
            if (e.KeyCode == Keys.Left)
            {
                game.MoveLeft();
                game.NewNumber();
            }
            if (e.KeyCode == Keys.Right)
            {
                game.MoveRigth();
                game.NewNumber();
            }
        }



        private void newGameToolStripMenuItem_Click(object sender, EventArgs e)
        {
            game.GameControl("Play a new game?", "Current game will be lost");
        }

        private void exitToolStripMenuItem_Click(object sender, EventArgs e)
        {
            game.GameControl("Are you sure want to quit the game, maybe we'll play again?", "Current game will be lost");
        }

        private void transparecyToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }

        private void greenToolStripMenuItem_Click(object sender, EventArgs e)
        {
            PaintForm("ForestGreen");
        }

        private void yellowToolStripMenuItem_Click(object sender, EventArgs e)
        {
            PaintForm("Yellow");
        }

        private void blackToolStripMenuItem_Click(object sender, EventArgs e)
        {
            PaintForm("Aqua");
        }

        private void whiteToolStripMenuItem_Click(object sender, EventArgs e)
        {
            PaintForm("Coral");
        }

        private void pinkToolStripMenuItem_Click(object sender, EventArgs e)
        {
            PaintForm("LightGray");
        }

        private void redToolStripMenuItem_Click(object sender, EventArgs e)
        {
            PaintForm("PaleGreen");
        }

        private void greenToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            PaintCube("LimeGreen");
        }

        private void yellowToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            PaintCube("Yellow");
        }






        private void pinkToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            PaintCube("Pink");
        }

        private void onToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.BackColor = Color.Black;
        }

        private void offToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.BackColor = Color.AliceBlue;
        }

        private void onToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            PaintCube("Black");
        }

        private void offToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            PaintCube(cubeColor);
        }



        private void PaintForm(string colorName)
        {
            c = Color.FromName(colorName);
            this.BackColor = c;
        }


        private void PaintCube(string colorName)
        {
            cubeColor = colorName;
            for (int i = 0; i < game.NumbersArray.GetLength(0); i++)
            {
                for (int j = 0; j < game.NumbersArray.GetLength(1); j++)
                {
                    c = Color.FromName(colorName);
                    //c.ToKnownColor();
                    GetPictureBoxByName($"_{i}{j}").BackColor = c;
                }
            }
        }

        private void aboutToolStripMenuItem_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Desktop Game For Windows\n 2048 Trial Version", "2048", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private void toolStripMenuItem2_Click(object sender, EventArgs e)
        {
            game.maxScore = 512;
        }

        private void toolStripMenuItem3_Click(object sender, EventArgs e)
        {
            game.maxScore = 1024;
        }

        private void toolStripMenuItem4_Click(object sender, EventArgs e)
        {
            game.maxScore = 1024;
        }
    }
}
