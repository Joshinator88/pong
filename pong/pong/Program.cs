
namespace pong
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Configuration variables = new();
            Bat bat = new Bat();
            
            int currenttop = bat.GenerateBats(Configuration.FieldHeight, Configuration.FieldWidth, Configuration.yStart, Configuration.batsize);

            //calling the methods to create a dynamic playing field and score board
            Field field = new(Configuration.xStart, Configuration.yStart, Configuration.FieldWidth, Configuration.FieldHeight);
            field.PlayingField();
            field.scoreboard(variables.score01, variables.score02);
            string hasScored = "No one";

            //ScoreBoard(fieldwidth, score1, score2);

            //create a new instance of the ball class
            Ball playBall = new(Configuration.FieldWidth, Configuration.FieldHeight, Configuration.yStart);
           
            //loop that will continue as long as the game continues
            while (hasScored == "No one")
            {
                //check if "w" or "s" is pressed, if not than we will move on to ball method so no threads are necissary
                hasScored = playBall.RollBall(currenttop, Configuration.batsize);
                if (Console.KeyAvailable)
                {
                    currenttop = bat.Moving(currenttop, Configuration.batsize, Configuration.FieldHeight, Configuration.yStart);
                }
                Thread.Sleep(Configuration.velocity);
            }
            //we need to clear the screen and show who lost
            field.Score(hasScored);
            Console.ReadKey();
        }
    }
}
