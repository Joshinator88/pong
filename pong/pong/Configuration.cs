

namespace pong
{
    public class Configuration
    {
        public static int FieldHeight = 20;
        public static int FieldWidth = 80;
        public static int XPostitionBatOne = 2;
        public static int XPostitionBatTwo = 78;
        //the lower the number the faster the ball will move
        public static int Velocity = 100;
        public DateTime currentTime = DateTime.Now;
        public DateTime lastTime = DateTime.Now;
        public static int YStart = 3;
        public static int xStart = 0;
        public int score01 = 0;
        public int score02 = 0;
        public static int Batsize = FieldHeight / 4;

       // public static int FieldHeight = 20;
       // public static int FieldWidth = 80;
       // //the lower the number the faster the ball will move
       // public static int Velocity = 100;
       // public DateTime currentTime = DateTime.Now;
       // public DateTime lastTime = DateTime.Now;
       // public static int YStart = 3;
       // public static int xStart = 0;
       // public int score01 = 0;
       // public int score02 = 0;
       // public static int batsize = FieldHeight / 4;
    }
}
