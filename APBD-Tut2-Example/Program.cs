
using APBD_Tut2_Example.Models;
using APBD_Tut2_Example.Services.Reservations;
using APBD_Tut2_Example.Services.Rooms;

var user1 = new Employee("Jan", "Kowalski");
var user2 = new Student("Michael", "Doe");

var room1 = new Laptop("112B", 20, true, "Ubuntu");
var room2 = new Laptop("112C", 20, true, "Windows");
var room3 = new Projector("112", 20, true);

IEquipmentService equipmentService = new EquipmentService();

equipmentService.AddRoom(room1);
equipmentService.AddRoom(room2);
equipmentService.AddRoom(room3);

equipmentService.SetUnavailable(room2.Id);

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
        equipmentService.GetRoomById(1),
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
    var room = equipmentService.GetRoomById(10);
}
catch(Exception e)
{
    Console.WriteLine(e.Message);
}
