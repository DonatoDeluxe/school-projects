using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Timers;

namespace Simulation_eines_Wärmerückgewinnungsgerätes
{
    class HeatRecoveryDevice
    {
        private static int[,] levelsStats = new int[4, 2] { {0, 0}, {30, 15}, {60, 45}, {90, 60} };
        private static int[] currentSteps = new int[2] {0, 0};

        private static Timer secTimer = new Timer(1000);

        private int currentLevel;
        public int CurrentLevel { get { return currentLevel; } private set {
                currentLevel = value;
                ContentChanged();
                //OnContentChanged();
            } }
        public int SelectedLevel { get; private set; }
        public int EngineSpeed { get; private set; }
        public int Current { get; private set; }
        public int Voltage { get; private set; }
        public int Power { get; private set; }

        //public event EventHandler ContentChanged;
        //public void OnContentChanged()
        //{
        //    ContentChanged?.Invoke(this, EventArgs.Empty);
        //}

        public HeatRecoveryDevice() {
            EngineSpeed = 0;
            CurrentLevel = 0;
            SelectedLevel = 0;
            Current = 0;
            Voltage = 0;
            Power = 0;

            secTimer.Elapsed += OnSecondElapsed;
        }

        public void ContentChanged()
        {
            var diffLevels = SelectedLevel - CurrentLevel;
        }

        public void OnSecondElapsed(Object source, ElapsedEventArgs e)
        {
            if(EngineSpeed != levelsStats[SelectedLevel, 0])
            {
                var diffLevels = SelectedLevel - CurrentLevel;
                
            }

            Console.WriteLine("The Elapsed event was raised at {0:HH:mm:ss.fff}",
                              e.SignalTime);
        }

        public void ChangeSelectedLevel(int newSelectedLevel)
        {
            SelectedLevel = newSelectedLevel;
            var diffLevels = SelectedLevel - CurrentLevel;
            if (diffLevels != 0)
            {

            }
        }
    }
}
