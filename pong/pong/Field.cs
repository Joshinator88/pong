namespace pong
{
    internal class Field
    {
        private Configuration _config = new();
        
        

        public void Scoreboard()
        {
            int position1 = Configuration.FieldWidth / 4;
            Console.SetCursorPosition(position1, 1);
            Console.Write(_config.score01.ToString());
            Console.SetCursorPosition(position1 * 2, 1);
            Console.Write('-');
            Console.SetCursorPosition(position1 * 3, 1);
            Console.Write(_config.score02.ToString());
        }

        public void PlayingField()
        {
            Console.SetCursorPosition(0 + Configuration.xStart, 0 + Configuration.YStart);
            Console.Write("\u250c");
            Console.SetCursorPosition(Configuration.FieldWidth + Configuration.xStart, 0 + Configuration.YStart);
            Console.Write("\u2510");

            Console.SetCursorPosition(0 + Configuration.xStart, Configuration.FieldHeight + Configuration.YStart);
            Console.Write("\u2514");
            Console.SetCursorPosition(Configuration.FieldWidth + Configuration.xStart, Configuration.FieldHeight + Configuration.YStart);
            Console.Write("\u2518");
            // string
            for (int x = 1 + Configuration.xStart; x < Configuration.FieldWidth + Configuration.xStart; x++)
            {

                Console.SetCursorPosition(x, Configuration.YStart);
                Console.Write("\u2500");
                Console.SetCursorPosition(x, Configuration.FieldHeight + Configuration.YStart);
                Console.Write("\u2500");

                if (x == 1 + Configuration.xStart || x + Configuration.xStart == 30)
                {
                    for (int y = 1 + Configuration.YStart; y < Configuration.FieldHeight + Configuration.YStart; y++)
                    {
                        Console.SetCursorPosition(0 + Configuration.xStart, y);
                        Console.Write("\u2502");
                        Console.SetCursorPosition(Configuration.FieldWidth + Configuration.xStart, y);
                        Console.Write("\u2502");
                    }
                }

            }
            Console.WriteLine();

        }
        
        public void Score(string name)
        {
            string message = name + " scored!!!";
            if (name == "Player01")
            {
                _config.score01++;
            }
            else
            {
                _config.score02++;
            }
            Console.Clear();
            PlayingField();
            int xSentanceStart = (Configuration.FieldWidth - Configuration.xStart) / 2 - message.Count() / 2;
            Console.SetCursorPosition(xSentanceStart, (Configuration.FieldHeight - Configuration.YStart) / 2);
            Console.Write(message);
        }
    }
}
