namespace pong
{
    internal class Field
    {
        private int _xStart;
        private int _yStart;
        private int _width;
        private int _height;
        
        public Field(int xStart, int yStart, int width, int height) 
        { 
        _xStart = xStart;
        _yStart = yStart;
        _width = width;
        _height = height;
        }

        public void scoreboard(int score01, int score02)
        {
            int position1 = _width / 4;
            Console.SetCursorPosition(position1, 1);
            Console.Write(score01.ToString());
            Console.SetCursorPosition(position1 * 2, 1);
            Console.Write('-');
            Console.SetCursorPosition(position1 * 3, 1);
            Console.Write(score02.ToString());
        }

        public void PlayingField()
        {
            Console.SetCursorPosition(0 + _xStart, 0 + _yStart);
            Console.Write("\u250c");
            Console.SetCursorPosition(_width + _xStart, 0 + _yStart);
            Console.Write("\u2510");

            Console.SetCursorPosition(0 + _xStart, _height + _yStart);
            Console.Write("\u2514");
            Console.SetCursorPosition(_width + _xStart, _height + _yStart);
            Console.Write("\u2518");
            // string
            for (int x = 1 + _xStart; x < _width + _xStart; x++)
            {

                Console.SetCursorPosition(x, _yStart);
                Console.Write("\u2500");
                Console.SetCursorPosition(x, _height + _yStart);
                Console.Write("\u2500");

                if (x == 1 + _xStart || x + _xStart == 30)
                {
                    for (int y = 1 + _yStart; y < _height + _yStart; y++)
                    {
                        Console.SetCursorPosition(0 + _xStart, y);
                        Console.Write("\u2502");
                        Console.SetCursorPosition(_width + _xStart, y);
                        Console.Write("\u2502");
                    }
                }

            }
            Console.WriteLine();

        }
        
        public void Score(string name)
        {
            string message = name + " scored!!!";
            Console.Clear();
            PlayingField();
            int xSentanceStart = (_width - _xStart) / 2 - message.Count() / 2;
            Console.SetCursorPosition(xSentanceStart, (_height - _yStart) / 2);
            Console.Write(message);
        }
    }
}
