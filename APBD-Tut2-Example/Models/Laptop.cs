namespace APBD_Tut2_Example.Models;

public class Laptop(string name, int capacity, bool hasProjector, string operatingSystem) : Equipment(name, capacity)
{
    public bool HasProjector { get; set; } = hasProjector;
    public string OperatingSystem { get; set; } = operatingSystem;
}