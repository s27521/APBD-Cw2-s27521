
using APBD_Tut2_Example.Models;
using APBD_Tut2_Example.Services.Reservations;
using APBD_Tut2_Example.Services.Rooms;

var user1 = new Lecturer("Jan", "Kowalski");
var user2 = new TeachingAssistant("Michael", "Doe");

var room1 = new ComputerLab("112B", 20, true, "Ubuntu");
var room2 = new ComputerLab("112C", 20, true, "Windows");
var room3 = new LectureHall("112", 20, true);

IRoomService roomService = new RoomService();

roomService.AddRoom(room1);
roomService.AddRoom(room2);
roomService.AddRoom(room3);

roomService.SetUnavailable(room2.Id);

IReservationService reservationService = new ReservationService();

// Attempt to book a room that is not available
try
{
    Console.WriteLine("\n[Attempt to book a room that is not available]: ");
    reservationService.CreateReservation(
        user1,
        room2,
        new DateTime(2026, 1, 1, 10, 0, 0),
        new DateTime(2026, 1, 1, 11, 30, 0));
}
catch (Exception e)
{
    Console.WriteLine(e.Message);
}

// Attempt to create conflicting reservation
try
{
    Console.WriteLine("\n[Attempt to create conflicting reservation]: ");
    reservationService.CreateReservation(
        user1,
        roomService.GetRoomById(1),
        new DateTime(2026, 1, 1, 10, 0, 0),
        new DateTime(2026, 1, 1, 11, 30, 0));
    reservationService.CreateReservation(
        user1,
        room1,
        new DateTime(2026, 1, 1, 10, 0, 0),
        new DateTime(2026, 1, 1, 11, 30, 0));
}
catch (Exception e)
{
    Console.WriteLine(e.Message);
}

// Attempt to cancel not existing reservation
try
{
    Console.WriteLine("\n[Attempt to cancel not existing reservation]: ");
    reservationService.CancelReservation(10);
}
catch (Exception e)
{
    Console.WriteLine(e.Message);
}

// Attempt to get not existing room
try
{
    Console.WriteLine("\n[Attempt to get not existing room]: ");
    var room = roomService.GetRoomById(10);
}
catch(Exception e)
{
    Console.WriteLine(e.Message);
}
