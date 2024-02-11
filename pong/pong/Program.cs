
using System.Security.AccessControl;


namespace pong
{
    internal class Program
    {

        // this method will create a square on the screen as the playing field
        static void create_field(int x_start, int y_start, int width, int height)
        {
            Console.SetCursorPosition(0 + x_start, 0 + y_start);
            Console.Write("\u250c");
            Console.SetCursorPosition(width + x_start, 0 + y_start);
            Console.Write("\u2510");

            Console.SetCursorPosition(0 + x_start, height + y_start);
            Console.Write("\u2514");
            Console.SetCursorPosition(width + x_start, height + y_start);
            Console.Write("\u2518");

            for (int x = 1 + x_start; x < width + x_start; x++)
            {

                Console.SetCursorPosition(x, y_start);
                Console.Write("\u2500");
                Console.SetCursorPosition(x, height+y_start);
                Console.Write("\u2500");

                if (x == 1 + x_start || x + x_start == 30)
                {
                    for (int y = 1 + y_start; y < height + y_start; y++)
                    {
                        Console.SetCursorPosition(0 + x_start, y);
                        Console.Write("\u2502");
                        Console.SetCursorPosition(width + x_start, y);
                        Console.Write("\u2502");
                    }
                }

            }
            Console.WriteLine();

        }

        // thismethod will create the score board
        static void score_board(int widthfield, int score1, int score2)
        {
            int position1 = widthfield / 4;
            Console.SetCursorPosition(position1, 1);
            Console.Write(score1.ToString());
            Console.SetCursorPosition(position1 * 2, 1);
            Console.Write('-');
            Console.SetCursorPosition(position1 * 3, 1);
            Console.Write(score2.ToString());

        }

        static int bats(int heightfield, int widthfield, int y_start, int batsize)
        {
            int startingpoint = heightfield / 8 * 3 + y_start;

            //creating bat one
            for (int i = 0; i <= batsize; i++)
            {
                Console.SetCursorPosition(2, startingpoint);
                Console.Write("\u2502");
                startingpoint++;
            }
            startingpoint = heightfield / 8 * 3 + y_start;

            //creating bat 2
            for (int i = 0; i <= batsize; i++)
            {
                Console.SetCursorPosition(widthfield-2, startingpoint);
                Console.Write("\u2502");
                startingpoint++;
            }
            return heightfield / 8 * 3 + y_start;
        }

        //letting the bat be able to move up
        public static int move_up(int current_top, int batsize, int y_start)
        {
            if (current_top > y_start + 1)
            {
                Console.SetCursorPosition(2, current_top - 1);
                Console.Write("\u2502");
                //set the curesor to the stripe at the bottom of the bat and remove it
                Console.SetCursorPosition(2, current_top + batsize);
                Console.Write(" ");
                return current_top - 1;
            } else
            {
                return current_top;
            }
        }

        

        public static int move_down(int current_top, int batsize, int fieldheight, int y_start)
        {
            if (current_top + batsize + 1 < fieldheight + y_start)
            {
                Console.SetCursorPosition(2, current_top);
                Console.Write(" ");
                //set the curesor to the stripe at the bottom of the bat and remove it
                Console.SetCursorPosition(2, current_top + batsize + 1);
                Console.Write("\u2502");
                return current_top + 1;
            } else
            {
                return current_top;
            }
            
        }

        public static async Task<int> moving(int current_top, int batsize, int fieldheight, int y_start)
        {
            char input = Convert.ToChar(Console.ReadKey(true).Key);

            if (input == 'W')
            {
                //Console.WriteLine("hi");
                current_top = move_up(current_top, batsize, y_start);
            }
            else if (input == 'S')
            {
                current_top = move_down(current_top, batsize, fieldheight, y_start);
            }
            return current_top;
        }

        //y_start, fieldwidth, fieldheight
        public static int[] getballdata()
        {
            int y_start = 3;
            int fieldwidth = 80;
            int fieldheight = 20;
            return [y_start, fieldwidth, fieldheight];
        }


        public static void ball()
        {
            int[] data = getballdata();
            int velosity = 1;
            int y_start = data[0];
            int fieldwidth = data[1];
            int fieldheight = data[2];
            int[] ballPosition = [fieldwidth / 2, (fieldheight + y_start) / 2];


            while (true)
            {
                Console.SetCursorPosition(ballPosition[0], ballPosition[1]);
                Console.Write(" ");
                if (ballPosition[0] <= 3)
                {
                    velosity = 1;
                }
                else if (ballPosition[0] >=  fieldwidth - 3)
                {
                    velosity = -1;
                }

                ballPosition[0] += velosity;

                Console.SetCursorPosition(ballPosition[0], ballPosition[1]);
                Console.Write("O");
                Thread.Sleep(100);

            }
            
        }

        static void Main(string[] args)
        {
            //get y_start, fieldwidth, fieldheight
            int[] data = getballdata();
            int fieldheight = data[2];
            int fieldwidth = data[1];
            int y_start = data[0];
            int score1 = 0;
            int score2 = 0;
            int batsize = fieldheight / 4;
            int currenttop = bats(fieldheight, fieldwidth, y_start, batsize);
            //creating an array for the coordinates of the ball (these are the coordiantes off the middle of the field)
            int[] ballPosition = { fieldwidth / 2, (fieldheight + y_start) / 2 };
            object ball_data = new object();
            
            

            create_field(0, y_start, fieldwidth, fieldheight);
            score_board(fieldwidth, score1, score2);

            ThreadStart ballmove = new ThreadStart(ball);
            Thread ballthread = new Thread(ballmove);
            ballthread.Start();
            //ballthread.Start(ballPosition, y_start, fieldwidth, velosity);
                while (true)
            {
                currenttop = moving(currenttop, batsize, fieldheight, y_start).Result;
                
            }



            Console.ReadKey();
        }
    }
}
