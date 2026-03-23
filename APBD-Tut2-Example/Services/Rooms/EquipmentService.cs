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

    public Equipment GetEquipmentById(int roomId)
    {
        return _equipments.FirstOrDefault(room => room.Id == roomId) 
               ?? throw new EquipmentNotFoundException(roomId);
    }

    public List<Equipment> GetAll()
    {
        return _equipments;
    }

    public List<Equipment> GetAvailable()
    {
        return _equipments.Where(room => room.Status == EquipmentStatus.Available).ToList();
    }

    public void SetAvailable(int roomId)
    {
        GetEquipmentById(roomId).Status = EquipmentStatus.Available;
    }

    public void SetUnavailable(int roomId)
    {
        GetEquipmentById(roomId).Status = EquipmentStatus.Unavailable;
    }
}