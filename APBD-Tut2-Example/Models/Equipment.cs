using APBD_Tut2_Example.Enums;

namespace APBD_Tut2_Example.Models;

public abstract class Equipment(string name, int capacity)
{
    private static int _nextId = 1;

    public int Id { get; } = _nextId++;
    public string Name { get; set; } = name;
    public int Capacity { get; set; } = capacity;
    public EquipmentStatus Status { get; set; } = EquipmentStatus.Available;
}