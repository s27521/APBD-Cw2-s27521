using APBD_Tut2_Example.Enums;

namespace APBD_Tut2_Example.Models;

public abstract class Room(string name, int capacity)
{
    private static int _nextId = 1;

    public int Id { get; } = _nextId++;
    public string Name { get; set; } = name;
    public int Capacity { get; set; } = capacity;
    public RoomStatus Status { get; set; } = RoomStatus.Available;
}