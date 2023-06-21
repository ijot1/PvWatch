using PvWatch;

namespace pVWatch.Tests
{
    public class Tests
    {
        [Test]
        public void CheckStatisticsForObserverInFile()
        {
            //arrange
            var observer = new PvObserverInFile();
            observer.AddEnergyPerHour(3);
            observer.AddEnergyPerHour(4);
            observer.AddEnergyPerHour(5);

            //act
            var result = observer.GetStatistics();

            //assert

            Assert.That(result.Average, Is.EqualTo(4).Within(0.01));
            Assert.That(result.Max, Is.EqualTo(5).Within(0.01));
            Assert.That(result.Min, Is.EqualTo(3).Within(0.01));
        }

        [Test]
        public void CheckStatisticsForObserverInMemory()
        {
            //arrange
            var observer = new PvObserverInMemory();
            observer.AddEnergyPerHour(0.01);
            observer.AddEnergyPerHour(3.45);
            observer.AddEnergyPerHour(6.55);
            observer.AddEnergyPerHour(5.75);
            observer.AddEnergyPerHour(4.24);

            //act
            var result = observer.GetStatistics();

            //assert

            Assert.That(result.Average, Is.EqualTo(4).Within(0.01));
            Assert.That(result.Max, Is.EqualTo(6.55).Within(0.01));
            Assert.That(result.Min, Is.EqualTo(0.01).Within(0.01));
        }

    }
}