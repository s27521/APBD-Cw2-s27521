using APBD_Tut2_Example.Models;

namespace APBD_Tut2_Example.Services.Rooms;

public interface IRoomService
{
    public void AddRoom(Room room);
    public Room GetRoomById(int roomId);
    public List<Room> GetAll();
    public List<Room> GetAvailable();
    public void SetAvailable(int roomId);
    public void SetUnavailable(int roomId);
}