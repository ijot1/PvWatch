namespace PvWatch
{
    using static PvWatch.PvObserverBase;
    using static PvWatch.Statistics;

    public interface IObserver
    {
        void AddEnergyPerHour(float energyPerHour);

        void AddEnergyPerHour(double energyPerHour);

        void AddEnergyPerHour(int energyPerHour);

        void AddEnergyPerHour(string energyPerHour);

        Statistics GetStatistics();

        void ShowStatistics();
    }
}
