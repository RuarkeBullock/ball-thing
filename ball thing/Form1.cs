using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ball_thing
{
    public partial class Form1 : Form
    {
        //Global variables
        Rectangle player1 = new Rectangle(50, 270, 20, 20);
        Rectangle player2 = new Rectangle(700, 270, 20, 20);
        Rectangle ball = new Rectangle(295, 195, 10, 10);
        Rectangle ball2 = new Rectangle(300, 195, 10, 10);




        int player1Score = 0;
        int player2Score = 0;

        int playerSpeed = 4;
        int ballXSpeed = 8;
        int ballYSpeed = 8;


        bool wPressed = false;
        bool sPressed = false;
        bool aPressed = false;
        bool dPressed = false;
        bool rightPressed = false;
        bool leftPressed = false;
        bool upPressed = false;
        bool downPressed = false;

        SolidBrush blueBrush = new SolidBrush(Color.DodgerBlue);
        SolidBrush whiteBrush = new SolidBrush(Color.White);
        SolidBrush yellowbrush = new SolidBrush(Color.Yellow);
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_KeyDown(object sender, KeyEventArgs e)
        {
            switch (e.KeyCode)
            {
                case Keys.W:
                    wPressed = true;
                    break;
                case Keys.S:
                    sPressed = true;
                    break;
                case Keys.Up:
                    upPressed = true;
                    break;
                case Keys.Down:
                    downPressed = true;
                    break;
                case Keys.D:
                    dPressed = true;
                    break;
                case Keys.A:
                    aPressed = true;
                    break;
                case Keys.Right:
                    rightPressed = true;
                    break;
                case Keys.Left:
                    leftPressed = true;
                    break;
            }
        }

        private void Form1_KeyUp(object sender, KeyEventArgs e)
        {
            switch (e.KeyCode)
            {
                case Keys.W:
                    wPressed = false;
                    break;
                case Keys.S:
                    sPressed = false;
                    break;
                case Keys.Up:
                    upPressed = false;
                    break;
                case Keys.Down:
                    downPressed = false;
                    break;
                case Keys.A:
                    aPressed = false;
                    break;
                case Keys.D:
                    dPressed = false;
                    break;
                case Keys.Right:
                    rightPressed = false;
                    break;
                case Keys.Left:
                    leftPressed = false;
                    break;
            }
        }

        private void Form1_Paint(object sender, PaintEventArgs e)
        {
            {
                
                e.Graphics.FillRectangle(blueBrush, player1);
                e.Graphics.FillRectangle(blueBrush, player2);
                e.Graphics.FillRectangle(whiteBrush, ball);
                e.Graphics.FillRectangle(yellowbrush, ball2);
            }
        }

        private void timer_Tick(object sender, EventArgs e)
        {
            //ball.X += ballXSpeed;
            //ball.Y += ballYSpeed;
            // move players
            if (wPressed == true && player1.Y > 0)
            {
                player1.Y -= playerSpeed;
            }



            if (sPressed == true && player1.Y < this.Height - player1.Height)
            {
                player1.Y += playerSpeed;
            }

            if (upPressed == true && player2.Y > 0)
            {
                player2.Y -= playerSpeed;
            }

            if (downPressed == true && player2.Y < this.Height - player2.Height)
            {
                player2.Y += playerSpeed;
            }
            if (aPressed == true && player1.X > 0)
            {
                player1.X -= playerSpeed;
            }
            if (dPressed == true && player1.X < this.Width - player1.Width)
            {
                player1.X += playerSpeed;
            }

            if (rightPressed == true && player1.X < this.Width - player2.Width)
            {
                player2.X += playerSpeed;
            }

            if (leftPressed == true && player2.X > 0)
            {
                player2.X -= playerSpeed;
            }

            // check if ball hit wall
            if (ball.Y < 0 || ball.Y > this.Height - ball.Height)
            {
                ballYSpeed *= -1;  or: ballYSpeed = -ballYSpeed;
            }
            if (ball.X < 0 || ball.X > this.Width - ball.Width)
            {
                ballXSpeed *= -1; // or: ballXSpeed = -ballXSpeed
            }
            // change if ball hits either player. If it does change the direction
            // and place the ball in front of the player it hit
            //if (player1.IntersectsWith(ball))
            //{
            //    collision.Play();

            //    player1Score++;
            //}

            if (player2.IntersectsWith(ball))
            {
                ballXSpeed *= -1;
                ball.X = player2.X - player2.Width;
                player2Score++;
            }





            // check if the game is over and show a winner
            if (player1Score == 5)
            {
                timer.Stop();

            }
            if (player2Score == 5)
            {
                timer.Stop();
            }
            Refresh();
        }
    }
    
}
