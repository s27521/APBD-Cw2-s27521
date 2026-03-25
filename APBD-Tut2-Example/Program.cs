
using APBD_Tut2_Example.Models;
using APBD_Tut2_Example.Services.Reservations;
using APBD_Tut2_Example.Services.Rooms;

var user1 = new Employee("Jan", "Kowalski");
var user2 = new Student("Michael", "Doe");

var item1 = new Laptop("112B","Asus", true, "Ubuntu");
var item2 = new Laptop("112C", "Lenovo", true, "Windows");
var item3 = new Projector("112","Samsung", true, "Laser");
var item4 = new Camera("asdjwad", "Canon", "CMOD", "20mpx");

IEquipmentService equipmentService = new EquipmentService();

equipmentService.AddEquipment(item1);
equipmentService.AddEquipment(item2);
equipmentService.AddEquipment(item3);
equipmentService.AddEquipment(item4);

equipmentService.SetUnavailable(item2.Id);

IReservationService reservationService = new ReservationService();

// Correct reservation making
try
{
    reservationService.CreateReservation(
        user2,
        item1,
        new DateTime(2026, 1, 1, 10, 0, 0),
        new DateTime(2026, 4, 1, 11, 30, 0));
    reservationService.CreateReservation(
        user2,
        item4,
        new DateTime(2026, 1, 1, 10, 0, 0),
        new DateTime(2026, 3, 1, 11, 30, 0));
}
catch (Exception e)
{
    Console.WriteLine(e.Message);
}

// Attempt to book a room that is not available
try
{
    Console.WriteLine("\n[Attempt to book a room that is not available]: ");
    reservationService.CreateReservation(
        user1,
        item2,
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
        item1,
        new DateTime(2026, 1, 1, 10, 0, 0),
        new DateTime(2026, 1, 1, 11, 30, 0));
}
catch (Exception e)
{
    Console.WriteLine(e.Message);
}

Console.WriteLine("\n" + equipmentService.GetStatus());
Console.WriteLine(reservationService.GetStatus());

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

reservationService.GetUserReservations(user2).ForEach(p => Console.WriteLine(p.Id));
// Correct return
try
{
    reservationService.ReturnReservation(1, DateTime.Now);
}
catch (Exception e)
{
    Console.WriteLine(e.Message);
}
reservationService.GetUserReservations(user2).ForEach(p => Console.WriteLine(p.Id));
Console.WriteLine("\nUser penalties: " + user2.Penalties.Count);

// Return past due
try
{
    reservationService.ReturnReservation(2, DateTime.Now);
}
catch (Exception e)
{
    Console.WriteLine(e.Message);
}
reservationService.GetUserReservations(user2).ForEach(p => Console.WriteLine(p.Id));
Console.WriteLine("\nUser penalties: " + user2.Penalties.Count);

Console.WriteLine("\n" + equipmentService.GetStatus());
Console.WriteLine(reservationService.GetStatus());