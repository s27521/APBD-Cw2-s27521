namespace APBD_Tut2_Example.Models;

public class Student(string fName, string lName) : User(fName, lName)
{
    public override int GetMaxReservations() => 2;
}