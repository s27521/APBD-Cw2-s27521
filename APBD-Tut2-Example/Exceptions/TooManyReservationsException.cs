namespace APBD_Tut2_Example.Exceptions;

public class TooManyReservationsException(int userId) : Exception($"There is too many active reservations for user {userId}.");