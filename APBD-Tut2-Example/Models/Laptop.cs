namespace APBD_Tut2_Example.Models;

public class Laptop(string name, string model, bool hasCamera, string operatingSystem) : Equipment(name, model)
{
    public bool HasCamera { get; set; } = hasCamera;
    public string OperatingSystem { get; set; } = operatingSystem;
}