using Iyo.Model;
using Iyo.Repository;
using Iyo.util;
using Type = System.Type;

namespace Iyo.service;

public class ParkingService: IParkingService
{
    public ParkingRepository parkingRepository;

    public ParkingService(ParkingRepository parkingRepository)
    {
        this.parkingRepository = parkingRepository;
    }
    
    public void addVehicle()
    {
        Console.WriteLine("ADD VEHICLE ---------------------->");
        Console.Write("Park > ");
        var stringVehicle = Console.In.ReadLine();
        var vehicleData = stringVehicle.Split(" ");
        string registrationNumber = vehicleData[0];
        VehicleColor color;
        VehicleType vehicleType;
        

        try
        {
            color = VehicleColorExtention.convertVehicleColor(vehicleData[1]);
            vehicleType = VehicleTypeExtention.convertVehicleType(vehicleData[2]);

        }
        catch (Exception e)
        {
            Console.WriteLine(e.Message + "\n\n");
            return;
        }

        Vehicle vehicle = new Vehicle();
        vehicle.color = color;
        vehicle.type = vehicleType;
        vehicle.registrationNumber = registrationNumber;

        var allocatedSlot = parkingRepository.addVehicle(vehicle);
        
        Console.WriteLine($"Allocated slot number: {allocatedSlot}\n\n");
    }

    public void releaseVehicle()
    {
        Console.WriteLine("RELEASE VEHICLE ------------------->");
        getVehicles();
        Console.Write("Leave > ");
        var input = Console.In.ReadLine();
        InputValidator.validateIntInput(input);

        var result = parkingRepository.reduceVehicle(int.Parse(input));
        Console.WriteLine(result + "\n\n");
    }

    public void getVehicles()
    {
        Console.WriteLine("LIST OF VEHICLE ------------------->");
        var vehicles = parkingRepository.getAllVehicles();
        Console.WriteLine("Available vehicles in parking slot: \n");
        Console.WriteLine("Slot\t\tNo.\t\t\tType\t\tColour");
        
        for (var i = 0; i < vehicles.Count; i++)
        {
            if (vehicles[i].registrationNumber == null)
            {   
                continue;
            }
            Console.WriteLine($"{i+1}\t\t{vehicles[i].registrationNumber}\t\t{vehicles[i].type}\t\t{vehicles[i].color}");
        }
        
        Console.WriteLine("\n\n");
    }

    public void getVehiclesByColor()
    {
        Console.WriteLine("REGISTRATION NUMBER FOR VEHICLES WITH COLOR ------>");
        Console.Write("Enter color > ");
        var input = Console.In.ReadLine();
        VehicleColor color;
        try
        {
            color = VehicleColorExtention.convertVehicleColor(input);

        }
        catch (Exception e)
        {
            Console.WriteLine(e.Message + "\n\n");
            return;
        }
        var vehicles = parkingRepository.getVehiclesByColor(color);
        
        if (vehicles.Count == 0)
        {
            Console.WriteLine($"No vehicle with color {color}\n\n");
            return;
        }
        
        for (var i = 0; i < vehicles.Count; i++)
        {
            Console.Write($"{vehicles[i].registrationNumber},");
        }
        Console.WriteLine("\n\n");
    }

    public void getVehiclesByOddRegistrationNumber()
    {
        Console.WriteLine("REGISTRATION NUMBER FOR VEHICLES WITH ODD PLATE --------->");
        var vehicles = parkingRepository.getVehiclesByOddRegistrationNumber();

        if (vehicles.Count == 0)
        {
            Console.WriteLine("No vehicle with event plate\n\n");
            return;
        }
        for (var i = 0; i < vehicles.Count; i++)
        {
            Console.Write($"{vehicles[i].registrationNumber},");
        }
        Console.WriteLine("\n\n");
    }

    public void getVehiclesByEventRegistratinNumber()
    {
        Console.WriteLine("REGISTRATION NUMBER FOR VEHICLE WITH EVENT PLATE --------->");
        var vehicles = parkingRepository.getVehiclesByEventRegistrationNumber();
        if (vehicles.Count == 0)
        {
            Console.WriteLine("No vehicle with odd plate \n\n");
            return;
        }
        for (var i = 0; i < vehicles.Count; i++)
        {
            Console.Write($"{vehicles[i].registrationNumber},");
        }
        Console.WriteLine("\n\n");
        
    }
    
}