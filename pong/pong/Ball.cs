namespace pong
{
    //this class will consist of the ball and all the methods that are necissary for it
    internal class Ball
    {
        private readonly string _ball = "0";
        //positive is moving to the right and negative is moving to the left
        private int _direction = 1;
        private double _yDirection = 1;
        private double _ypartial = 0;
        //is the y coördinate where the playingfield starts
        private readonly int[] _ballPosition;
        private Configuration _config = new();


        public Ball()
        { 
            _ballPosition = [Configuration.FieldWidth / 2, (Configuration.FieldHeight + Configuration.YStart) / 2];
        }

        public string RollBall(int currentTopLeft, int currentTopRight, int batSize)
        {
            _config.currentTime = DateTime.Now;
            TimeSpan deltaTime = _config.currentTime - _config.lastTime;
            if (_direction < 0)
            {
                _direction = ((int)deltaTime.TotalMilliseconds / 100) * -1;
            }
            _config.lastTime = DateTime.Now;
            Console.SetCursorPosition(_ballPosition[0], _ballPosition[1]);
            Console.Write(" ");
            if ((_ballPosition[1] >= Configuration.YStart + Configuration.FieldHeight - 2 && _yDirection > 0) || (_ballPosition[1] <= Configuration.YStart + 2 && _yDirection < 0))
            {
                _yDirection *= -1.0;
            }
           
            //check if the ball is at the same x position as the bat
            if (_ballPosition[0] <= 3)
            {
                // check if the ball hits the bat, if so the direction will be reversed and the game will continue
                // else the game will be stopped
                if (_ballPosition[1] >= currentTopLeft && _ballPosition[1] <= currentTopLeft + batSize) 
                {
                    //_yDirection *= -1;
                    _direction *= -1;
                } else
                {
                    return "Player02";
                }
            }
            //bouncing off the second bat
            else if (_ballPosition[0] > Configuration.FieldWidth - 4)
            {
                if (_ballPosition[1] >= currentTopRight && _ballPosition[1] <= currentTopRight + batSize)
                {
                    _direction = -1;
                }
                else 
                {
                    return "Player01";
                }
            }
            //here we check if the ball is ready to move an entire step in the Y direction or if it is still a partial
            if (_ypartial % 1 == 0)
            {
                _ballPosition[1] += Convert.ToInt16(_ypartial);
                _ypartial = 0;
            }
            _ballPosition[0] += _direction;
            _ypartial += _yDirection;
            
            Console.SetCursorPosition(_ballPosition[0], _ballPosition[1]);
            Console.Write(_ball);
            return "No one";


        }


    }
}
