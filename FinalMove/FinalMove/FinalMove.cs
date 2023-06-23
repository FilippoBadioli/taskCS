using System;
using System.Timers;

namespace Project
{
    public class FinalMove
    {
        private static int _delay = 1000;
        private bool _isActive = false;
        private System.Timers.Timer _aTimer = new Timer(_delay);

        public FinalMove()
        {
            _aTimer.AutoReset = false;
            _aTimer.Elapsed += OnTimedEvent;
        }

        public bool IsActive()
        {
            return _isActive;
        }

        public void Trigger()
        {
            TowerSingleton.GetInstance().RemoveMoney(10);
            _isActive = true;
            _aTimer.Start();
        }

        private void OnTimedEvent(Object source, System.Timers.ElapsedEventArgs e)
        {
            _isActive = false;
        }
    }

    class TowerSingleton
    {
        private static TowerSingleton instance = null;
        public int Money { get; private set; } = 200;

        public static TowerSingleton GetInstance()
        {
            if (instance == null)
            {
                instance = new TowerSingleton();
            }

            return instance;
        }

        public void RemoveMoney(int _amount)
        {
            Money -= _amount;
        }
    }

    public class Test
    {
        FinalMove _finalMove = new FinalMove();



        public static void Main()
        {
            FinalMove _finalMove = new FinalMove();
            var test = new Test();
            Console.WriteLine(TowerSingleton.GetInstance().Money + ", " + System.DateTime.Now + ", " + _finalMove.IsActive());
            _finalMove.Trigger();
            Console.WriteLine(TowerSingleton.GetInstance().Money + ", " + System.DateTime.Now + ", " + _finalMove.IsActive());
            Console.ReadKey();
            Console.WriteLine(TowerSingleton.GetInstance().Money + ", " + System.DateTime.Now + ", " + _finalMove.IsActive());
        }
    }
    

} 
