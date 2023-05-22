using Iyo.Model;

namespace Iyo.Repository;

public class ParkingRepository
{
    public List<Vehicle?> parkingSlot;
    public int totalSlot;

    public ParkingRepository()
    {
        this.parkingSlot = new List<Vehicle>();
    }

    public List<Vehicle> getVehiclesByColor(VehicleColor color)
    {
        var result = parkingSlot.FindAll(v => v.color.Equals(color));
        return result;
    }

    public List<Vehicle> getVehiclesByOddRegistrationNumber()
    {
        var result = parkingSlot.FindAll(v => int.Parse(v.registrationNumber.Split("-")[1]) % 2 == 1);
        return result;
    }
    
    public List<Vehicle> getVehiclesByEventRegistrationNumber()
    {
        var result = parkingSlot.FindAll(v => int.Parse(v.registrationNumber.Split("-")[1]) % 2 == 0);
        return result;
    }

    public List<Vehicle> getAllVehicles()
    {
        var result = parkingSlot.FindAll(v => v != null);
        return result;
    }

    public string addVehicle(Vehicle vehicle)
    {
        if (parkingSlot.Count == totalSlot)
        {
            return "Sorry, parking is full";
        }
        var result = parkingSlot.FindIndex(v => v.registrationNumber == null);
        if (result == -1)
        {
            parkingSlot.Add(vehicle);
            return (parkingSlot.Count).ToString();
        }
        else
        {
            parkingSlot[result] = vehicle;
            return (result + 1).ToString();
        }
    }

    public string reduceVehicle(int slot)
    {
        parkingSlot[slot - 1] = new Vehicle();
        return $"Slot number {slot} is free";
    }
}