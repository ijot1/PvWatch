namespace PvWatch
{
    public abstract class PvObserverBase : IObserver
    {
        public const float minEnergyPerHour = 0.01F;

        public const float maxEnergyPerHour = 11.40F;

        public PvObserverBase() : base() { }

        public abstract void AddEnergyPerHour(float energyPerHour);

        public void AddEnergyPerHour(double energyPerHour)
        {
            float doubleEnergyPerHourAsFloat = (float)energyPerHour;
            AddEnergyPerHour(doubleEnergyPerHourAsFloat);
        }

        public void AddEnergyPerHour(int energyPerHour)
        {
            float intEnergyPerHourAsFloat = (float)energyPerHour;
            AddEnergyPerHour(intEnergyPerHourAsFloat);
        }

        public void AddEnergyPerHour(string energyPerHour)
        {
            if (float.TryParse(energyPerHour, out float stringEnergyPerHourAsFloat))
            {
                AddEnergyPerHour(stringEnergyPerHourAsFloat);
            }
            else
            {
                throw new Exception($"entered data is not of float type: {energyPerHour}");
            }
        }
        public abstract Statistics GetStatistics();

        public void ShowStatistics()
        {
            var statistics = GetStatistics();
            statistics.LevelEvaluation += LevelEvaluation;

            if (statistics.Count != 0)
            {
                Console.WriteLine("--------------------------------");
                Console.WriteLine($"Production period in hours:   {statistics.Count}");
                Console.WriteLine("--------------------------------");
                Console.WriteLine($"Production of a day: {statistics.Sum,0:F2} [kWh]");
                Console.WriteLine($"Production level:    {statistics.EnergyPerDayLevel}");
                Console.WriteLine("----------------------");
                Console.WriteLine("Production statistics:\n");
                Console.WriteLine($"average {statistics.Average,6:F2} [kWh]");
                Console.WriteLine($"maximal {statistics.Max,6:F2} [kWh]");
                Console.WriteLine($"minimal {statistics.Min,6:F2} [kWh]");
                Console.WriteLine("--------------------\n");
            }
            else
            {
                Console.WriteLine("Couldn't get statistics due the lack of data\n");
            }

            static void LevelEvaluation(object sender, EventArgs args)
            {
                Console.WriteLine("\n===============================");
                Console.WriteLine("Not sufficient production today");
                Console.WriteLine("===============================\n");
            }
        }
    }
    
}
