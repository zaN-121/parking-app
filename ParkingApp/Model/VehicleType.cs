namespace Iyo.Model;

public enum VehicleType
{
    MOTOR, MOBIL
    
}

public static class VehicleTypeExtention
{
    public static VehicleType convertVehicleType(string  type)
    {
        try
        {
            Enum.Parse(typeof(VehicleType), type.ToUpper());
        }
        catch (Exception e)
        {
            throw new Exception("Warning: Vehicle has to be a Motor or Mobil!");
        }

        return (VehicleType)Enum.Parse(typeof(VehicleType), type.ToUpper());
    }
}