using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace pong
{
    //this class will consist of the ball and all the methods that are necissary for it
    internal class Ball
    {
        private readonly string _ball = "0";
        //positive is moving to the right and negative is moving to the left
        private int _direction = 1;
        private double _yDirection = 0.5;
        private double _ypartial = 0;
        //is the y coördinate where the playingfield starts
        private readonly int _yStart;
        private readonly int _fieldWidth;
        private readonly int _fieldHeight;
        private readonly int[] _ballPosition;

        public Ball(int fieldWidth, int fieldHeight, int yStart) 
        { 
            _fieldWidth = fieldWidth;
            _fieldHeight = fieldHeight;
            _yStart = yStart;
            _ballPosition = [fieldWidth / 2, (fieldHeight + yStart) / 2];
        }

        public string RollBall(int currentTop, int batSize)
        {
            Console.SetCursorPosition(_ballPosition[0], _ballPosition[1]);
            Console.Write(" ");
            if ((_ballPosition[1] >= _yStart + _fieldHeight - 2 && _yDirection > 0) || (_ballPosition[1] <= _yStart + 2 && _yDirection < 0))
            {
                _yDirection *= -1.0;
            }
           
            //check if the ball is at the same x position as the bat
            if (_ballPosition[0] <= 3)
            {
                // check if the ball hits the bat, if so the direction will be reversed and the game will continue
                // else the game will be stopped
                if (_ballPosition[1] >= currentTop && _ballPosition[1] <= currentTop + batSize) 
                {
                    //_yDirection *= -1;
                    _direction = 1;
                } else
                {
                    return "Player02";
                }
            }
            //because the game is not yet multiplayable we won't check for the bat position
            else if (_ballPosition[0] >= _fieldWidth - 3)
            {
                //ssssss_yDirection *= -1;
                _direction = -1;
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
