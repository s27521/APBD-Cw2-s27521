namespace APBD_Tut2_Example.Models;

public class Projector(string name, int capacity, bool hasWhiteboard) : Equipment(name, capacity)
{
    public bool HasWhiteboard { get; set; } = hasWhiteboard;
}