namespace APBD_Tut2_Example.Models;

public class LectureHall(string name, int capacity, bool hasWhiteboard) : Room(name, capacity)
{
    public bool HasWhiteboard { get; set; } = hasWhiteboard;
}