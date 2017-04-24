using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SnakeGame
{
    public enum Direction { up,down,left,right};

    class Settings
    {
        public static int width { get; set; }
        public static int height { get; set; }
        public static int speed { get; set; }
        public static int score { get; set; }
        public static int points { get; set; }
        public static bool gameover { get; set; }
        public static Direction direction { get; set; }

        public Settings()
        {
            width = 16;
            height = 16;
            speed = 12;
            score = 0;
            points = 0;
            gameover = false;
            direction = Direction.down;
        }
    }
}
