
namespace pong
{
    internal class Program
    {
        static void Main(string[] args)
        {

            Configuration variables = new();
            Bat bat = new Bat();
            Field field = new();
            bool gameOn;

            //ScoreBoard(fieldwidth, score1, score2);

            //create a new instance of the ball class
            do
            {
                Ball playBall = new();
                int currenttopLeft = bat.GenerateBats(Configuration.FieldHeight, Configuration.FieldWidth, Configuration.YStart, Configuration.Batsize);
                int currenttopRight = bat.GenerateBats(Configuration.FieldHeight, Configuration.FieldWidth, Configuration.YStart, Configuration.Batsize);

                //calling the methods to create a dynamic playing field and score board
                field.PlayingField();
                field.Scoreboard();
                string hasScored = "No one";

                //loop that will continue as long as the game continues
                while (hasScored == "No one")
                {
                    //check if "w" or "s" is pressed, if not than we will move on to ball method so no threads are necissary
                    hasScored = playBall.RollBall(currenttopLeft, currenttopRight, Configuration.Batsize);
                    if (Console.KeyAvailable)
                    {
                        ConsoleKey pressedKey = Console.ReadKey(true).Key;
                        //moving the left bat by pressing the "w" and "s" keys
                        Task.Run(() =>
                        {
                            if (pressedKey == ConsoleKey.W || pressedKey == ConsoleKey.S)
                            {
                                currenttopLeft = bat.MovingLeftBat(pressedKey, currenttopLeft, Configuration.Batsize, Configuration.FieldHeight, Configuration.YStart);
                            }
                        });
                        Task.Run(() =>
                        {
                            if (pressedKey == ConsoleKey.UpArrow || pressedKey == ConsoleKey.DownArrow)
                            {
                                //moving the left bat by pressing the "UpArrow" and "DownArrow" keys
                                currenttopRight = bat.MovingRightBat(pressedKey, currenttopRight, Configuration.Batsize, Configuration.FieldHeight, Configuration.YStart);
                            }
                        });

                    }
                    Thread.Sleep(Configuration.Velocity);
                }
                //we need to clear the screen and show who lost
                field.Score(hasScored);
                Console.SetCursorPosition(5, (Configuration.FieldHeight - Configuration.YStart) / 2 + 1);
                Console.Write("Do you want to continue? press y if you do.");
                if (Console.ReadKey().Key == ConsoleKey.Y)
                {
                    gameOn = true;
                    Console.Clear();
                } else
                {
                    gameOn = false;
                }
            } while (gameOn);
           
        }
    }
}
