

namespace pong
{
    internal class Bat
    {
        public int GenerateBats(int heightfield, int widthfield, int y_start, int batsize)
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
                Console.SetCursorPosition(widthfield - 2, startingpoint);
                Console.Write("\u2502");
                startingpoint++;
            }
            return heightfield / 8 * 3 + y_start;
        }

        //letting the bat be able to move up
        private int MoveUp(int current_top, int batsize, int y_start, int xPositionBat)
        {
            if (current_top > y_start + 1)
            {
                Console.SetCursorPosition(xPositionBat, current_top - 1);
                Console.Write("\u2502");
                //set the curesor to the stripe at the bottom of the bat and remove it
                Console.SetCursorPosition(xPositionBat, current_top + batsize);
                Console.Write(" ");
                return current_top - 1;
            }
            else
            {
                return current_top;
            }
        }



        private int MoveDown(int current_top, int batsize, int fieldheight, int y_start, int xPositionBat)
        {
            if (current_top + batsize + 1 < fieldheight + y_start)
            {
                Console.SetCursorPosition(xPositionBat, current_top);
                Console.Write(" ");
                //set the curesor to the stripe at the bottom of the bat and remove it
                Console.SetCursorPosition(xPositionBat, current_top + batsize + 1);
                Console.Write("\u2502");
                return current_top + 1;
            }
            else
            {
                return current_top;
            }

        }

        public int MovingLeftBat(ConsoleKey input, int current_top, int batsize, int fieldheight, int y_start)
        {
            // Moving the left bat when the "w" or "s" keys are pressed
            if (input == ConsoleKey.W)
            {
                current_top = this.MoveUp(current_top, batsize, y_start, Configuration.XPostitionBatOne);
            }
            else if (input == ConsoleKey.S)
            {
                current_top = this.MoveDown(current_top, batsize, fieldheight, y_start, Configuration.XPostitionBatOne);
            }
           
            return current_top;
        }

        public int MovingRightBat(ConsoleKey input, int current_top, int batsize, int fieldheight, int y_start)
        {
            // Moving the right bat when the "UpArrow" or "DownArrow" keys are pressed
            if (input == ConsoleKey.UpArrow)
            {
                current_top = this.MoveUp(current_top, batsize, y_start, Configuration.XPostitionBatTwo);
            }
            else if (input == ConsoleKey.DownArrow)
            {
                current_top = this.MoveDown(current_top, batsize, fieldheight, y_start, Configuration.XPostitionBatTwo);
            }
            return current_top;
        }


    }
}
