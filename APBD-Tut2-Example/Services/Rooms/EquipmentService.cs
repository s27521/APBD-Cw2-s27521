using APBD_Tut2_Example.Enums;
using APBD_Tut2_Example.Exceptions;
using APBD_Tut2_Example.Models;

namespace APBD_Tut2_Example.Services.Rooms;

public class EquipmentService : IEquipmentService
{
    private readonly List<Equipment> _equipments = [];

    public void AddEquipment(Equipment equipment)
    {
        _equipments.Add(equipment);
    }

    public Equipment GetEquipmentById(int equipmentId)
    {
        return _equipments.FirstOrDefault(room => room.Id == equipmentId) 
               ?? throw new EquipmentNotFoundException(equipmentId);
    }

    public List<Equipment> GetAll()
    {
        return _equipments;
    }

    public List<Equipment> GetAvailable()
    {
        return _equipments.Where(equipment => equipment.Status == EquipmentStatus.Available).ToList();
    }

    public void SetAvailable(int equipmentId)
    {
        GetEquipmentById(equipmentId).Status = EquipmentStatus.Available;
    }

    public void SetUnavailable(int equipmentId)
    {
        GetEquipmentById(equipmentId).Status = EquipmentStatus.Unavailable;
    }

    public string GetStatus()
    {
        int available = GetAvailable().Count;
        int unavailable = GetAll().Count - available;
        return $"Number of available equipment: {available}, unavailable: {unavailable}";
    }
}