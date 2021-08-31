using System;

namespace Tetris
{
    class GameTimer
    {
        private System.Timers.Timer _timer = new System.Timers.Timer();
        private volatile bool _requestStop = false;
        private Action _CheckAction;

        public GameTimer(Action action)
        {
            _CheckAction = action;
            _timer.Interval = 50;
            _timer.Elapsed += OnTimerElapsed;
            _timer.AutoReset = false;
            _timer.Start();
        }

        private void OnTimerElapsed(object sender, System.Timers.ElapsedEventArgs e)
        {

            _CheckAction();
            if (!_requestStop)
            {
                _timer.Start();//restart the timer
            }
        }

        public void Stop()
        {
            _requestStop = true;
            _timer.Stop();
        }

        public void Start()
        {
            _requestStop = false;
            _timer.Start();
        }
    }
}
