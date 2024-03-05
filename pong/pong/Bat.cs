using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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
        private int MoveUp(int current_top, int batsize, int y_start)
        {
            if (current_top > y_start + 1)
            {
                Console.SetCursorPosition(2, current_top - 1);
                Console.Write("\u2502");
                //set the curesor to the stripe at the bottom of the bat and remove it
                Console.SetCursorPosition(2, current_top + batsize);
                Console.Write(" ");
                return current_top - 1;
            }
            else
            {
                return current_top;
            }
        }



        private int MoveDown(int current_top, int batsize, int fieldheight, int y_start)
        {
            if (current_top + batsize + 1 < fieldheight + y_start)
            {
                Console.SetCursorPosition(2, current_top);
                Console.Write(" ");
                //set the curesor to the stripe at the bottom of the bat and remove it
                Console.SetCursorPosition(2, current_top + batsize + 1);
                Console.Write("\u2502");
                return current_top + 1;
            }
            else
            {
                return current_top;
            }

        }

        public int Moving(int current_top, int batsize, int fieldheight, int y_start)
        {
            char input = Convert.ToChar(Console.ReadKey(true).Key);

            if (input == 'W')
            {
                //Console.WriteLine("hi");
                current_top = this.MoveUp(current_top, batsize, y_start);
            }
            else if (input == 'S')
            {
                current_top = this.MoveDown(current_top, batsize, fieldheight, y_start);
            }
            return current_top;
        }


    }
}
