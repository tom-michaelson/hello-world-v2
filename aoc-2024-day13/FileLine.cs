using System;
using System.Collections.Generic;
using System.Text;

namespace HelloWorldV2.aoc_2024_day13
{
    internal class FileLine
    {
        private long _maxA = long.MaxValue;
        private long _minB = 1;
        private long? _startingA = null;
        private long _currentA = 0;
        public Button A { get; set; }
        private long? _startingB = null;
        private long _currentB = 0;
        public Button B { get; set; }
        public Prize Prize { get; set; }
        public long CurrentCost()
        {
            return _currentB + (_currentA * 3);
        }

        /// <summary>
        /// Increment A presses
        /// </summary>
        public void IncreaseA()
        {
            _currentA++;
        }
        /// <summary>
        /// Decrement B presses and reset A presses
        /// </summary>
        public void DecreaseB()
        {
            _currentB--;
            _currentA = _startingA ?? throw new Exception("testing exception.  Did not seed A");
        }
        public bool Compare()
        {
            if (_currentA > _maxA){
                throw new Exception("current A greater than max presses");
            }
            if (_currentB < _minB)
            {
                throw new Exception("current B less than min presses");
            }
            var xResult = _currentA * A.X + _currentB * B.X;
            var yResult = _currentA * A.Y + _currentB * B.Y;
            if (xResult > Prize.X || yResult > Prize.Y)
            {
                DecreaseB();
                return false;
            }
            if (xResult == Prize.X && yResult == Prize.Y)
            {
                return true;
            }
            IncreaseA();
            return false;
        }

        public void Init()
        {
            SeedB();
            SeedA();
            Console.Write($"Starting B: {_startingB}, starting A: {_startingA}, max A: {_maxA}, min B {_minB} ");
        }

        public void initB()
        {
            var startingX = (Prize.X / B.X) - 1;
            var startingY = (Prize.Y / B.Y) - 1;
            if (startingX < startingY)
            {
                _startingB = startingY + 5;
                _currentB = startingY + 5;
                _minB = startingX - 5;
                return;
            }
            _startingB = startingX + 5;
            _currentB = startingX + 5;
            _minB = startingY - 5;
            return;
        }

        public void SeedB()
        {
            if (_startingB.HasValue)
            {
                return;
            }
            var startingX = (Prize.X / B.X) - 1;
            var startingY = (Prize.Y / B.Y) - 1;
            if (startingX < startingY)
            {
                _startingB = startingY + 5;
                _currentB = startingY + 5;
                _minB = startingX - 5;
                return;
            }
            _startingB = startingX + 5;
            _currentB = startingX + 5;
            _minB = startingY - 5;
            return;
            //for (var i = MAX_PRESSES; i >= 0; i--)
            //{
            //    if (B.X * i < Prize.X && B.Y * i < Prize.Y)
            //    {
            //        _startingB = i;
            //        _currentB = i;
            //        return;
            //    }
            //}
            //throw new Exception("No minimum B found");
        }

        public void SeedA()
        {
            if (!_startingB.HasValue)
            {
                throw new Exception("Test exception.  Need to seed B first.");
            }
            var startingX = (Prize.X - (B.X * _startingB.Value) / A.X) - 1;
            var startingY = (Prize.Y - (B.Y * _startingB.Value) / A.Y) - 1;
            if (startingX < startingY)
            {
                _startingA = startingX;
                _currentA = startingX;
                _maxA = startingY + 5;
                return;
            }
            _startingA = startingY;
            _currentA = startingY;
            _maxA = startingX + 5;
            return;
            //for(var i = 0L; i < MAX_PRESSES; i++)
            //{
            //    if((A.X * i) + (B.X * _startingB.Value) > Prize.X || (A.Y * i) + (B.Y * _startingB.Value) > Prize.Y)
            //    {
            //        _startingA = i - 1;
            //        _currentA = i - 1;
            //        return;
            //    }
            //}
            //throw new Exception("No minimum A found");
        }
    }
}
