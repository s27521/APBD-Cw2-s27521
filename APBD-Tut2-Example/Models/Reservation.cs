namespace APBD_Tut2_Example.Models;

public class Reservation(Equipment equipment, User user, DateTime from, DateTime to)
{
    private static int _nextId = 1;
    
    public int Id { get; set; } = _nextId++;
    public Equipment Equipment { get; set; } = equipment;
    public User User { get; set; } = user;
    public DateTime From { get; set; } = from >= to ? throw new ArgumentException("Invalid time range") : from;
    public DateTime To { get; set; } = to;
    public bool IsCancelled { get; private set; } = false;
    public DateTime ? ReturnDate { get; private set; } = null;
    
    public void Cancel()
    {
        IsCancelled = true;
    }

    public void Return(DateTime returnDate)
    {
        ReturnDate = returnDate;
        IsCancelled = true;
    }

    public bool Overlaps(DateTime from, DateTime to)
    {
        return !(From > to || from > To);
    }

    public bool GoodReturn()
    {
        return ReturnDate <= To && ReturnDate is not null && IsCancelled;
    }

    public bool IsPastDue()
    {
        return To < DateTime.Now &&  !IsCancelled;
    }

    public int Length()
    {
        return (To - From).Days;
    }
}