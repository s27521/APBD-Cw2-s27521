
using APBD_Tut2_Example.Models;
using APBD_Tut2_Example.Services.Reservations;
using APBD_Tut2_Example.Services.Rooms;

var user1 = new Employee("Jan", "Kowalski");
var user2 = new Student("Michael", "Doe");

var room1 = new Laptop("112B","Asus", true, "Ubuntu");
var room2 = new Laptop("112C", "Lenovo", true, "Windows");
var room3 = new Projector("112","Samsung", true, "Laser");

IEquipmentService equipmentService = new EquipmentService();

equipmentService.AddEquipment(room1);
equipmentService.AddEquipment(room2);
equipmentService.AddEquipment(room3);

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
        equipmentService.GetEquipmentById(1),
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
    var room = equipmentService.GetEquipmentById(10);
}
catch(Exception e)
{
    Console.WriteLine(e.Message);
}
