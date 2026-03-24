namespace APBD_Tut2_Example.Models;

public class Penalty(Reservation reservation, DateTime date)
{
    public Reservation Reservation { get; set; } = reservation;

    public int PenaltyClass { get; set; } = (date - reservation.To).Days switch
    {
        < 3 => 1,
        <=7 => 2,
        > 7 => 3
    };
}