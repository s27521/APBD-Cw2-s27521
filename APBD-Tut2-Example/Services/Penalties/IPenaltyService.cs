using APBD_Tut2_Example.Models;

namespace APBD_Tut2_Example.Services.Penalties;

public interface IPenaltyService
{
    public void CreatePenalty(Reservation reservation, DateTime returnOn);
}