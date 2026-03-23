namespace APBD_Tut2_Example.Exceptions;

public class EquipmentNotFoundException(int roomId) : Exception($"Room with id {roomId} not found.");