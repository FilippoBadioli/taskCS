using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Project
{
    public class WaveManagerSingleton
    {
        private long _start;
        private GameLogicImpl _gameLogicImpl = new GameLogicImpl();
        private int _waveSize;
        private Random _random = new Random();
        private int _type;
        private int _counter;
        private float _timerWaves;
        private static WaveManagerSingleton _instance = null;
        private int _waveCounter = 2;
        private float _timeMultiplier = 1.2f;

        private WaveManagerSingleton()
        {
            _start = DateTime.Now.Ticks / TimeSpan.TicksPerMillisecond;
            _waveSize = _random.Next(2, 4);
            for (int i = 0; i < _waveSize; i++)
            {
                _gameLogicImpl.summonEnemy();
            }
            _counter = 0;
            _timerWaves = 1000;
        }

        public static WaveManagerSingleton getInstance()
        {
            if (_instance == null)
            {
                _instance = new WaveManagerSingleton();
            }
            return _instance;
        }

        public void spawnWave()
        {
            long _now = DateTime.Now.Ticks / TimeSpan.TicksPerMillisecond;
            if ((_now - _start) >= _timerWaves)
            {
                for (int i = 0; i < _waveSize; i++)
                {
                    _gameLogicImpl.summonEnemy();
                    _start = _now;
                }

                if (_counter > _waveCounter)
                {
                    _waveSize++;
                    _timerWaves *= _timeMultiplier;
                    _counter = 0;
                }

                else
                {
                    _counter++;

                }
            }
        }

    }

    public class GameLogicImpl
    {
        public void summonEnemy()
        {
            int _type;
            Random _random = new Random();

            if (_random.Next(0, 100) < 70)
            {
                _type = 0;
            }
            else
            {
                _type = 1;
            }

            if (_type == 0)
            {
                Console.WriteLine("Goblin Spawned");
            }

            if (_type == 1)
            {
                Console.WriteLine("Wizard Spawned");
            }

        }
    }

    class TestSpawn
    {
        public static void Main()
        {
            WaveManagerSingleton _waveManagerSingleton = WaveManagerSingleton.getInstance();
            while (true)
            {
                char a = Console.ReadKey().KeyChar;
                if (a == 'e')
                {
                    System.Environment.Exit(0);
                }
                else
                {
                    _waveManagerSingleton.spawnWave();
                }
            }
        }
    }
}
