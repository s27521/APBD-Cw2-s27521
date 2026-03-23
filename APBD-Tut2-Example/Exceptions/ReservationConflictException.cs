namespace APBD_Tut2_Example.Exceptions;

public class ReservationConflictException(int roomId, DateTime from, DateTime to) 
    : Exception($"Room {roomId} is already reserved for the period from {from} to {to}.");