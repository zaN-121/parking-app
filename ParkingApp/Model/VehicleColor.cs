namespace Iyo.Model;

public enum VehicleColor
{
    RED, HIJAU, BIRU, KUNING, PUTIH, HITAM, ORANGE, JINGGA, TOSKA, ABU, UNGU, MERAH, SILVER, EMAS
}

public static class VehicleColorExtention
{
    public static VehicleColor convertVehicleColor(string color)
    {
        try
        {
            Enum.Parse(typeof(VehicleColor), color.ToUpper());
        }
        catch (Exception e)
        {
            throw new Exception("The Valid Color Vehicle are  RED, HIJAU, BIRU, KUNING, PUTIH, HITAM, ORANGE, JINGGA, TOSKA, ABU, UNGU, MERAH, SILVER, EMAS");
        }

        return (VehicleColor)Enum.Parse(typeof(VehicleColor), color.ToUpper());
    }
}