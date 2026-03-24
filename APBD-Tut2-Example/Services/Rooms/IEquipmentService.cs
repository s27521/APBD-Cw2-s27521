using APBD_Tut2_Example.Models;

namespace APBD_Tut2_Example.Services.Rooms;

public interface IEquipmentService
{
    public void AddEquipment(Equipment equipment);
    public Equipment GetEquipmentById(int equipmentId);
    public List<Equipment> GetAll();
    public List<Equipment> GetAvailable();
    public void SetAvailable(int equipmentId);
    public void SetUnavailable(int equipmentId);
}