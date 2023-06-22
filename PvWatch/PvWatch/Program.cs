using PvWatch;
using System.Reflection.Metadata;

Console.WriteLine("======================================");
Console.WriteLine("Daily photovoltaic production observer");
Console.WriteLine("======================================");
Console.WriteLine();
Console.WriteLine($"Right quantity of energy per hour is between:\n" +
    $"{PvObserverBase.minEnergyPerHour} kWh and {PvObserverBase.maxEnergyPerHour} kWh;\n");

bool CloseApp = false;

while (!CloseApp)
{
    Console.WriteLine(
        "1 - add energy to programm memory\n" +
        "2 - add energy to text file\n" +
        "x - close application\n");

    Console.WriteLine("");
    Console.WriteLine("What do yoy want to do?\n" +
        "Press 1, 2 or x");

    var choice = Console.ReadLine();

    
    switch (choice)
    {
        case "1":
            AddEnergyToMemory();
            break;

        case "2":
            AddEnergyToFile();
            break;

        case "x":
            CloseApp = true;
            break;

        default:
            Console.WriteLine($"Invalid argument: {choice}. Only 1, 2 or x are allowed");
            continue;
    }
}
Console.WriteLine("Press any key to leave.");
Console.ReadKey();

static void AddEnergyToMemory()
{
    var pvObserverInMemory = new PvObserverInMemory();
    EnterData(pvObserverInMemory);
    pvObserverInMemory.ShowStatistics();
}

static void AddEnergyToFile()
{
    var pvObserverInFile = new PvObserverInFile();
    EnterData(pvObserverInFile);
    pvObserverInFile.ShowStatistics();
}


static void EnterData(IObserver observer)
{
    while (true)
    {
        Console.WriteLine($"Get energy per hour; q: quit");

        var input = Console.ReadLine();
        if (input != "q" && input is not null)
        {
            Console.WriteLine($"You gave: {input} kWh");
            try
            {
                observer.AddEnergyPerHour(input);
            }
            catch (Exception e)
            {
                new Exception($"Exception catched: {e.Message}");
            }
        }
        else
        {
            break;
        }
    }
}
