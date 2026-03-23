namespace APBD_Tut2_Example.Models;

public class Employee(string fName, string lName) : User(fName, lName)
{
    public override int GetMaxReservations() => 5;
}