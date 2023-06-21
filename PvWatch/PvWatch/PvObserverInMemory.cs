namespace PvWatch
{
    public class PvObserverInMemory : PvObserverBase 
    {
        public List<float> energyHourComponents = new();

        public PvObserverInMemory() : base() { }

        public override void AddEnergyPerHour(float energyPerHour)
        {
            if (energyPerHour >= minEnergyPerHour && energyPerHour <= maxEnergyPerHour)
            {
                this.energyHourComponents.Add(energyPerHour);
            }
            
            else
            {
                Console.WriteLine($"Quantity of energy should be not less than: " +
                    $"{minEnergyPerHour} and not more than: {maxEnergyPerHour}");
            }
            
        }

        public override Statistics GetStatistics()
        {
            Statistics statistics = new ();

            foreach (var energy in this.energyHourComponents)
            {
                statistics.AddEnergyPerHour(energy);
            }

            return statistics;
        }
    }
}
