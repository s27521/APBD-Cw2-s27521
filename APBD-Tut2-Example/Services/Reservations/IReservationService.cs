using APBD_Tut2_Example.Models;

namespace APBD_Tut2_Example.Services.Reservations;

public interface IReservationService
{
    public void CreateReservation(User user, Room room, DateTime from, DateTime to);
    public void CancelReservation(int reservationId);
    public List<Reservation> GetUserReservations(User user);
    public List<Reservation> GetAll();
}