using APBD_Tut2_Example.Models;

namespace APBD_Tut2_Example.Services.Penalties;

public class PenaltyService : IPenaltyService
{
    public void CreatePenalty(Reservation reservation, DateTime returnOn)
    {
        reservation.Return(returnOn);
        reservation.User.Penalties.Add(new Penalty(reservation, returnOn));
    }
}