using APBD_Tut2_Example.Enums;
using APBD_Tut2_Example.Exceptions;
using APBD_Tut2_Example.Models;

namespace APBD_Tut2_Example.Services.Rooms;

public class RoomService : IRoomService
{
    private readonly List<Room> _rooms = [];

    public void AddRoom(Room room)
    {
        _rooms.Add(room);
    }

    public Room GetRoomById(int roomId)
    {
        return _rooms.FirstOrDefault(room => room.Id == roomId) 
               ?? throw new RoomNotFoundException(roomId);
    }

    public List<Room> GetAll()
    {
        return _rooms;
    }

    public List<Room> GetAvailable()
    {
        return _rooms.Where(room => room.Status == RoomStatus.Available).ToList();
    }

    public void SetAvailable(int roomId)
    {
        GetRoomById(roomId).Status = RoomStatus.Available;
    }

    public void SetUnavailable(int roomId)
    {
        GetRoomById(roomId).Status = RoomStatus.Unavailable;
    }
}