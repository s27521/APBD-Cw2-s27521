namespace APBD_Tut2_Example.Exceptions;

public class EquipmentUnavailableException(int roomId) : Exception($"Room with id {roomId} is not available.");