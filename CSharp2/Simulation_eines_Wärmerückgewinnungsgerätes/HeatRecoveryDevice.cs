using System;
using System.ComponentModel;
using System.Timers;

namespace HeatRecoveryApplication
{
    public class HeatRecoveryDevice : INotifyPropertyChanged
    {
        #region Properties
        private static readonly double[,] levelsStats = new double[4, 2] { {0, 0}, {30, 15}, {60, 45}, {90, 60} };
        public double[] CurrentSteps = new double[levelsStats.GetLength(1)];

        private Timer secTimer = new Timer(1000);
        private int currentLevel;
        private int selectedLevel;
        private double engineSpeed;
        private double current;
        private double voltage;
        private double power;

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

        public double EngineSpeed
        {
            get { return engineSpeed; }
            set
            {
                if (engineSpeed == value)
                    return;
                engineSpeed = value;
                OnPropertyChanged("EngineSpeed");
            }

        }

        public double Current
        {
            get { return current; }
            set
            {
                if (current == value)
                    return;
                current = value;
                OnPropertyChanged("Current");
            }
        }

        public double Voltage
        {
            get { return voltage; }
            set
            {
                if (voltage == value)
                    return;
                voltage = value;
                OnPropertyChanged("Voltage");
            }
        }

        public double Power
        {
            get { return power; }
            set
            {
                if (power == value)
                    return;
                power = value;
                OnPropertyChanged("Power");
            }
        }
        #endregion

        #region Event handlers
        public event EventHandler CurrentLevelChanged;
        public event EventHandler SelectedLevelChanged;
        public event PropertyChangedEventHandler PropertyChanged;

        private void OnCurrentLevelChanged() => CurrentLevelChanged?.Invoke(this, EventArgs.Empty);
        private void OnSelectedLevelChanged() => SelectedLevelChanged?.Invoke(this, EventArgs.Empty);
        private void OnPropertyChanged(string propertyName) => PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        #endregion

        public HeatRecoveryDevice() {
            EngineSpeed = 0;
            CurrentLevel = 0;
            SelectedLevel = 0;
            Current = 0;
            Voltage = 0;
            Power = 0;

            secTimer.Elapsed += OnSecondElapsed;
        }

        #region Methods
        public override string ToString()
        {
            return String.Format($"EngineSpeed: {EngineSpeed}\t\tCurrent: {Current}\t\tVoltage: {Voltage}\t\tPower: {Power}");
        }

        private void CurrentLevelHasChanged()
        {
            SetStepsValues();
        }

        private void SelectedLevelHasChanged()
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

            int timeToGoal = 5; //in steps (seconds)
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
                Current = 1000 * Power / Voltage;
            else
                Current = 0;
        }

        private void OnSecondElapsed(Object source, ElapsedEventArgs e)
        {
            DoDeviceStatsStep();
            Console.WriteLine(this.ToString());
        }
        #endregion
    }
}
