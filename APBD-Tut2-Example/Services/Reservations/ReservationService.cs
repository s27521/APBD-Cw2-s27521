using APBD_Tut2_Example.Enums;
using APBD_Tut2_Example.Exceptions;
using APBD_Tut2_Example.Models;

namespace APBD_Tut2_Example.Services.Reservations;

public class ReservationService : IReservationService
{
    private readonly List<Reservation> _reservations = [];
    
    public void CreateReservation(User user, Room room, DateTime from, DateTime to)
    {
        if (room.Status != RoomStatus.Available)
        {
            throw new RoomUnavailableException(room.Id);
        }

        int activeUserReservations = _reservations.Count(reservation => 
                                        !reservation.IsCancelled 
                                        && reservation.User == user);

        if (activeUserReservations >= user.GetMaxReservations())
        {
            throw new TooManyReservationsException(activeUserReservations);
        }

        bool reservationConflict = _reservations.Any(reservation =>
                                        !reservation.IsCancelled
                                        && reservation.Room == room
                                        && reservation.Overlaps(from, to));

        if (reservationConflict)
        {
            throw new ReservationConflictException(room.Id, from, to);
        }
        
        var newReservation = new Reservation(room, user, from, to);
        _reservations.Add(newReservation);
    }

    public void CancelReservation(int reservationId)
    {
        var reservation = _reservations.FirstOrDefault(reservation => reservation.Id == reservationId);
        
        if (reservation is null)
        {
            throw new ReservationNotFoundException(reservationId);
        }
        
        reservation.Cancel();
    }

    public List<Reservation> GetUserReservations(User user)
    {
        return _reservations.Where(reservation => reservation.User == user && !reservation.IsCancelled).ToList();
    }

    public List<Reservation> GetAll()
    {
        return _reservations;
    }
}