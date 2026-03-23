namespace APBD_Tut2_Example.Models;

public class Camera(string name, string model, string matrixType, string mpx) : Equipment(name, model)
{
    public string MatrixType { get; set; } = matrixType;
    public string Mpx { get; set; } = mpx;
}