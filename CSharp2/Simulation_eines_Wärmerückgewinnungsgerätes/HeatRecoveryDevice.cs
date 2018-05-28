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
        private static Timer secTimer = new Timer(500);
        private static readonly double[,] levelsStats = new double[4, 2] { {0, 0}, {30, 15}, {60, 45}, {90, 60} };

        private int currentLevel;
        public int CurrentLevel
        {
            get { return currentLevel; }
            private set
            {
                if (currentLevel == value)
                    return;
                currentLevel = value;
                CurrentLevelHasChanged();
                OnCurrentLevelChanged();
            }
        }

        private int selectedLevel;
        public int SelectedLevel
        {
            get { return selectedLevel; }
            set
            {
                if (selectedLevel == value)
                    return;
                selectedLevel = value;
                OnSelectedLevelChanged();
                SelectedLevelHasChanged();
            }
        }

        public double EngineSpeed { get; private set; }
        public double Current { get; private set; }
        public double Voltage { get; private set; }
        public double Power { get; private set; }
        public double[] CurrentSteps = new double[levelsStats.GetLength(1)];

        public event EventHandler CurrentLevelChanged;
        public event EventHandler SelectedLevelChanged;

        public void OnCurrentLevelChanged() => CurrentLevelChanged?.Invoke(this, EventArgs.Empty);
        public void OnSelectedLevelChanged() => SelectedLevelChanged?.Invoke(this, EventArgs.Empty);

        public HeatRecoveryDevice() {
            EngineSpeed = 0;
            CurrentLevel = 0;
            SelectedLevel = 0;
            Current = 0;
            Voltage = 0;
            Power = 0;

            secTimer.Elapsed += OnSecondElapsed;
        }

        public override string ToString()
        {
            return String.Format($"EngineSpeed: {EngineSpeed}\tCurrent: {Current}\tVoltage: {Voltage}\tPower: {Power}\t");
        }

        public void CurrentLevelHasChanged()
        {
            SetStepsValues();
        }

        public void SelectedLevelHasChanged()
        {
            if (Voltage < 230 && SelectedLevel > 0)
                Voltage = 230;
            SetStepsValues();
        }

        private void SetStepsValues()
        {
            var diffLevels = SelectedLevel - CurrentLevel;

            if (diffLevels == 0)
            {
                if(EngineSpeed == levelsStats[SelectedLevel, 0])
                {
                    secTimer.Enabled = false;
                    Array.Clear(CurrentSteps, 0, CurrentSteps.Length);
                    return;
                }

                if (EngineSpeed < levelsStats[SelectedLevel, 0])
                    currentLevel = SelectedLevel - 1;
                else
                    currentLevel = SelectedLevel + 1;

                diffLevels = SelectedLevel - CurrentLevel;
            }

            int timeToGoal = 5; //in seconds
            var levelUpOrDown = diffLevels / Math.Abs(diffLevels);
            var nextLevel = CurrentLevel + levelUpOrDown;

            if (diffLevels < 0)
                timeToGoal = ((CurrentLevel * CurrentLevel) - (nextLevel * nextLevel)) * 10;

            Console.WriteLine("current level: " + currentLevel);
            Console.WriteLine("selected level: " + selectedLevel);
            Console.WriteLine("level up or down: " + levelUpOrDown);
            Console.WriteLine("next level: " + nextLevel);
            Console.WriteLine("max steps(seconds) to goal: " + timeToGoal);

            for (int i = 0; i < levelsStats.GetLength(1); i++)
                CurrentSteps[i] = (levelsStats[nextLevel, i] - levelsStats[CurrentLevel, i]) / timeToGoal;

            if (secTimer.Enabled != true)
                secTimer.Enabled = true;
        }

        public void OnSecondElapsed(Object source, ElapsedEventArgs e)
        {
            DoDeviceStatsStep();
            Console.WriteLine(this.ToString());
        }

        private void DoDeviceStatsStep()
        {
            if (CurrentSteps[0] == 0)
                return;

            EngineSpeed += CurrentSteps[0];
            Power += CurrentSteps[1];

            var diffLevels = SelectedLevel - CurrentLevel;
            var levelUpOrDown = diffLevels / Math.Abs(diffLevels);
            var nextLevel = CurrentLevel + levelUpOrDown;

            if ((CurrentSteps[0] < 0 && EngineSpeed <= levelsStats[nextLevel, 0]) || (CurrentSteps[0] > 0 && EngineSpeed >= levelsStats[nextLevel, 0]))
            {
                EngineSpeed = levelsStats[nextLevel, 0];
                Power = levelsStats[nextLevel, 1];
                CurrentLevel = nextLevel;

                if (CurrentLevel + SelectedLevel == 0)
                    Voltage = 0;
            }

            if (Voltage != 0)
                Current = Power / Voltage;
            else
                Current = 0;
        }
    }
}
