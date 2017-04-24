using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SnakeGame
{
    
    public partial class Form1 : Form
    {
        private List<Circle> snake = new List<Circle>();
        private Circle food = new Circle();
           public Form1()
        {
            InitializeComponent();
        }

        void StartGame()
        {
            new Settings();
            Circle Head = new Circle() { x = 10, y = 5 };

            snake.Clear();
            snake.Add(Head);
            snake.Add(new Circle() { x = 10 + Settings.width, y = 5 + Settings.height });

            

            foodexpire = new Timer()
            { Interval = 5000 };
            foodexpire.Tick += Foodexpire_Tick;
            GenerateFood();
        }
        Timer foodexpire;
        void GenerateFood()
        {
            foodexpire.Stop();
            int maxXPos = pbboard.Size.Width / Settings.width;
            int maxYPos = pbboard.Size.Height / Settings.height;

            Random rand = new Random();

            foodexpire.Start();
            food = new Circle();
Loop:
                food.x = rand.Next(0, maxXPos);
                food.y = rand.Next(0, maxYPos);
            //check the position of food
                for (int i = 0; i < snake.Count; i++)
                {
                    if (food.x >= snake[i].x && food.x <= (snake[i].x + Settings.width) && food.y >= snake[i].y && food.y <= (snake[i].y + Settings.height))
                    {
                    goto Loop;
                    }
                }
        }

        private void Foodexpire_Tick(object sender, EventArgs e)
        {
            // after some ticks we should move the position of food
            foodexpire.Stop();
            if (Settings.gameover == false)
            {
                GenerateFood();
                pbboard.Invalidate();
            }
        }

        void UpdateScreen(object sender, EventArgs e)
        {
            //check for gameover
            if (Settings.gameover == true)
            {
                //check if enter pressed
                if (Input.KeyPressed(Keys.Enter))
                    StartGame();
            }
            else
            {
                if (Input.KeyPressed(Keys.Right) && Settings.direction != Direction.left)
                    Settings.direction = Direction.right;
                else if (Input.KeyPressed(Keys.Left) && Settings.direction != Direction.right)
                    Settings.direction = Direction.left;
                else if (Input.KeyPressed(Keys.Up) && Settings.direction != Direction.down)
                    Settings.direction = Direction.up;
                else if (Input.KeyPressed(Keys.Down) && Settings.direction != Direction.up)
                    Settings.direction = Direction.down;

                MovePlayer();
            }

            pbboard.Invalidate();
        }

        private void MovePlayer()
        {
            for (int i = snake.Count-1; i>=0;i--)
            {
                if (i==0)
                {
                    switch (Settings.direction)
                    {
                        case Direction.right:
                            snake[i].x++;
                            break;
                            case Direction.left:
                            snake[i].x--;
                            break;
                        case Direction.up:
                            snake[i].y--;
                            break;
                        case Direction.down:
                            snake[i].y++;
                            break;

                    }

                    //get maximum x and y pos
                    int maxXPos = pbboard.Size.Width / Settings.width;
                    int maxYPos = pbboard.Size.Height / Settings.height;

                    // detect collision with gameboarders.
                    if (snake[0].x < 0 || snake[0].y < 0 || snake[0].x >= maxXPos || snake[0].y >= maxYPos)
                        Die();

                    for( int j=1;j<snake.Count;j++)
                    {
                        if (snake[0].x == snake[j].x && snake[0].y == snake[j].y)
                            Die();

                    }

                    //detect collision with food
                    if (snake[0].x == food.x && snake[0].y == food.y)
                        Eat();
                }
                else
                {
                    snake[i].x = snake[i - 1].x;
                    snake[i].y = snake[i - 1].y;

                }
            }
        }

        private void pbboard_Paint(object sender, PaintEventArgs e)
        {
            Graphics gra = e.Graphics;
            if (Settings.gameover!=true)
            {
                Brush snakeColor;

                //draw snake
                for (int i=0;i<snake.Count;i++)
                {
                    //draw head
                    if (i == 0)
                    {
                        snakeColor = Brushes.Black;
                    }
                    else
                        snakeColor = Brushes.Gray;
                    gra.FillEllipse(snakeColor,
                                       new Rectangle(snake[i].x * Settings.width,
                                               snake[i].y * Settings.height,
                                               Settings.width,
                                               Settings.height));
                    //draw food
                    gra.FillEllipse(Brushes.Red,
                                    new Rectangle(food.x * Settings.width, food.y * Settings.height , Settings.width,Settings.height));

                }

            }
            else
            {
                
            }
        }
        void Eat()
        {
            Circle body = new Circle();
            body.x = snake[snake.Count - 1].x + Settings.width;
            body.y = snake[snake.Count - 1].y + Settings.height;

            snake.Add(body);

            Settings.score++;
            foodexpire.Stop();
            GenerateFood();
        }
        void Die()
        {
            Settings.gameover = true;
            Graphics gra = pbboard.CreateGraphics();
            gra.DrawString("GameOver!", DefaultFont, Brushes.Blue, new Point(10, 10));
            gra.DrawString("Your Score:"+ Settings.score.ToString(), DefaultFont, Brushes.Blue, new Point(10, 30));
        }
        private void Form1_KeyDown(object sender, KeyEventArgs e)
        {
            Input.ChangeState(e.KeyCode, true);
        }

        private void Form1_KeyUp(object sender, KeyEventArgs e)
        {
            Input.ChangeState(e.KeyCode, false);
        }

        private void Form1_Shown(object sender, EventArgs e)
        {
            new Settings();

            timer1.Interval = 1000 / Settings.speed;
            timer1.Tick += UpdateScreen;
            timer1.Start();
            StartGame();
        }
    }
}
