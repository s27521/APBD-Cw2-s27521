using APBD_Tut2_Example.Enums;

namespace APBD_Tut2_Example.Models;

public abstract class Equipment(string name, string model)
{
    private static int _nextId = 1;

    public int Id { get; } = _nextId++;
    public string Name { get; set; } = name;
    public string Model { get; set; } = model;
    public EquipmentStatus Status { get; set; } = EquipmentStatus.Available;
}