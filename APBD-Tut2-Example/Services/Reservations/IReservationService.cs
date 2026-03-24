using APBD_Tut2_Example.Models;

namespace APBD_Tut2_Example.Services.Reservations;

public interface IReservationService
{
    public void CreateReservation(User user, Equipment equipment, DateTime from, DateTime to);
    public void CancelReservation(int reservationId);
    public void ReturnReservation(int reservationId, DateTime returnDate);
    public List<Reservation> GetUserReservations(User user);
    public List<Reservation> GetAll();
    public List<Reservation> GetPastDue();
    public string GetStatus();
}