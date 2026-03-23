namespace APBD_Tut2_Example.Models;

public class Projector(string name, string model, bool hasRemote, string matrixType) : Equipment(name, model)
{
    public bool HasRemote { get; set; } = hasRemote;
    public string MatrixType { get; set; } = matrixType;
}