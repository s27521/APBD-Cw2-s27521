using APBD_Tut2_Example.Models;

namespace APBD_Tut2_Example.Services.Rooms;

public interface IEquipmentService
{
    public void AddRoom(Equipment equipment);
    public Equipment GetRoomById(int roomId);
    public List<Equipment> GetAll();
    public List<Equipment> GetAvailable();
    public void SetAvailable(int roomId);
    public void SetUnavailable(int roomId);
}