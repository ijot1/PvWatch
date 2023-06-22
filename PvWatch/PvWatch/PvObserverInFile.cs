using System.IO.Enumeration;
using System.Text;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace PvWatch
{
    public class PvObserverInFile : PvObserverBase
    {
        public List<float> energyHourComponents = new();

        private string fullFileName = new FileFullName().FullName;

        public PvObserverInFile() : base() { }
        

        public override void AddEnergyPerHour(float energyPerHour)
        {
            if (energyPerHour >= minEnergyPerHour && energyPerHour <= maxEnergyPerHour)
            {
                if (fullFileName is not null)
                {
                    using (var writer = File.AppendText(fullFileName))
                    {
                        writer.WriteLine(energyPerHour);
                    }
                }
                else
                {
                    throw new Exception($"The file name {fullFileName} is not proper");
                }
            }
            else
            {
                throw new Exception($"hour energy value out of scope: {energyPerHour:F2}");
            }
        }

        public override Statistics GetStatistics()
        {
            Statistics statistics = new();

            if (fullFileName is not null)
            {
                CompleteComponentsList();
            }
            else
            {
                Console.WriteLine("The file name is not proper");
            }          

            foreach (var component in this.energyHourComponents)
            {
                if (component != 0)
                {
                    statistics.AddEnergyPerHour(component);
                }
            }

            return statistics;
        }

        private void CompleteComponentsList()
        {
            string ? line = "";

            if (File.Exists(fullFileName))
            {
                using (var reader = File.OpenText(fullFileName))
                {
                    line = reader.ReadLine();
                    while (line is not null)
                    {
                        energyHourComponents.Add(float.Parse(line));
                        if (line.Trim() != "")
                        {
                            line = reader.ReadLine();
                        }
                    }
                }
            }
        }

        private class FileFullName
        {
            private const string partialName = "_dayProduction.txt";
            public string FullName
            {
                get
                {
                    string dateMark = DateTime.Now.ToShortDateString();
                    return $"{dateMark} {FileFullName.partialName}";
                }
            }
        }
    } 
}
