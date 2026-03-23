namespace APBD_Tut2_Example.Models;

public class ComputerLab(string name, int capacity, bool hasProjector, string operatingSystem) : Room(name, capacity)
{
    public bool HasProjector { get; set; } = hasProjector;
    public string OperatingSystem { get; set; } = operatingSystem;
}