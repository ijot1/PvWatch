namespace PvWatch
{
    public class Statistics
    {
        public const float sufficientLevel = 25.0F;
        public const float excessiveLevel = 45.0F;

        public delegate void LevelEvaluationDelegate(object sender, EventArgs args);
        public event LevelEvaluationDelegate LevelEvaluation;

        public float Min { get; private set; }
        public float Max { get; private set; }
        public float Sum { get; private set; }
        public float Count { get; private set; }
        public float Average {
            get
            {
                return this.Sum / this.Count;
            }
        }
        public string EnergyPerDayLevel
        {
            get
            {
                switch (this.Sum)
                {
                    case var level when level >= excessiveLevel:
                        return "Excesive";
                    case var level when level >= sufficientLevel:
                        return "Sufficient";
                    default:
                        LevelEvaluation?.Invoke(this, new EventArgs());
                        return "Shortage";
                }
            }
        }

        public Statistics()
        {
            this.Count = 0;
            this.Sum = 0;
            this.Min = float.MaxValue;
            this.Max = float.MinValue;
        }

        public void AddEnergyPerHour(float energyPerHour)
        {
            this.Count++;
            
            this.Sum += energyPerHour;
            this.Min = Math.Min(this.Min, energyPerHour);
            this.Max = Math.Max(this.Max, energyPerHour);
        }
    }
}
