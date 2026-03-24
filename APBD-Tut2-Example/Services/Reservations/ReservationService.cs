using APBD_Tut2_Example.Enums;
using APBD_Tut2_Example.Exceptions;
using APBD_Tut2_Example.Models;

namespace APBD_Tut2_Example.Services.Reservations;

public class ReservationService : IReservationService
{
    private readonly List<Reservation> _reservations = [];
    
    public void CreateReservation(User user, Equipment equipment, DateTime from, DateTime to)
    {
        if (equipment.Status != EquipmentStatus.Available)
        {
            throw new EquipmentUnavailableException(equipment.Id);
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
                                        && reservation.Equipment == equipment
                                        && reservation.Overlaps(from, to));

        if (reservationConflict)
        {
            throw new ReservationConflictException(equipment.Id, from, to);
        }
        
        var newReservation = new Reservation(equipment, user, from, to);
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

    public void ReturnReservation(int reservationId, DateTime returnDate)
    {
        var reservation = _reservations.FirstOrDefault(reservation => reservation.Id == reservationId);
        
        if (reservation is null)
        {
            throw new ReservationNotFoundException(reservationId);
        }
        
        reservation.Return(returnDate);
    }

    public List<Reservation> GetUserReservations(User user)
    {
        return _reservations.Where(reservation => reservation.User == user && !reservation.IsCancelled).ToList();
    }

    public List<Reservation> GetAll()
    {
        return _reservations;
    }

    public List<Reservation> GetPastDue()
    {
        throw new NotImplementedException();
    }
}