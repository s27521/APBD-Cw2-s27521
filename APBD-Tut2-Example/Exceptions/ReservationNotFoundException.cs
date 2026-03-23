namespace APBD_Tut2_Example.Exceptions;

public class ReservationNotFoundException(int reservationId) 
    : Exception($"Reservation with id {reservationId} not found");