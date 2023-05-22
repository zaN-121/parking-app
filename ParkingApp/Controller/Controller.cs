using Iyo.Repository;
using Iyo.service;
using Iyo.util;

namespace Iyo.Controller;

public class Controller
{
    public ParkingService parkingService;

    public Controller(ParkingService parkingService)
    {
        this.parkingService = parkingService;
    }

    public void Run()
    {
        showBanner();
        
        // Console.WriteLine("=------- CREATE PARKING SLOT ----------> ");
        // Console.Write("> ");
        // var input = Console.In.ReadLine();
        // InputValidator.validateIntInput(input);
        // try
        // {
        //     parkingService.parkingRepository.totalSlot = int.Parse(input);
        //
        // }
        // catch (Exception e)
        // {
        //     Console.WriteLine("");
        // }
        var indikator = true;
        while (indikator)
        {
            indikator = showFormSlot();
        }
        Console.WriteLine($"Created a parking lot with  slots\n\n");
        while (true)
        {
            showMenu();
        }
    }

    public bool showFormSlot()
    {
        Console.WriteLine("=------- CREATE PARKING SLOT ----------> ");
        Console.Write("> ");
        var input = Console.In.ReadLine();
        InputValidator.validateIntInput(input);
        try
        {
            parkingService.parkingRepository.totalSlot = int.Parse(input);

        }
        catch (Exception e)
        {
            Console.WriteLine("");
            return true;
        }

        return false;
    }

    public void showBanner()
    {
        Console.WriteLine("=========================================");
        Console.WriteLine("------------- PARKING APP ---------------");
        Console.WriteLine("=========================================");
    }
    

    public void showMenu()
    {
        Console.WriteLine("=---------- MENU --------=\n");
        Console.WriteLine("1.Add Vehicle");
        Console.WriteLine("2.Release Vehicle From Lot");
        Console.WriteLine("3.List Of Vehicle");
        Console.WriteLine("4.Registration Numbers For Vehicles With Ood Plate");
        Console.WriteLine("5.Registration Numbers For Vehicles With Event Plate");
        Console.WriteLine("6.Registration Numbers For Vehicles With Colour");
        Console.WriteLine("7.Exit");

        Console.Write("> ");
        var data = Console.In.ReadLine();
        Console.WriteLine("\n\n");

        try
        {
            var res = int.Parse(data);

            if (res > 7)
            {
                throw new ArgumentException("Warning: There are only 7 choices!\n\n");
            }
        }
        catch (ArgumentException e)
        {
            Console.WriteLine(e.Message);
        }
        catch (Exception e)
        {
            Console.WriteLine("Warning: input has to be integer!\n\n");

        }

        switch (int.Parse(data)) 
        {
            case 1:
                parkingService.addVehicle();
                break;
            case 2:
                parkingService.releaseVehicle();
                break;
            case 3:
                parkingService.getVehicles();
                break;
            case 4:
                parkingService.getVehiclesByOddRegistrationNumber();
                break;
            case 5:
                parkingService.getVehiclesByEventRegistratinNumber();
                break;
            case 6:
                parkingService.getVehiclesByColor();
                break;
            case 7:
                Environment.Exit(1);
                break;
                
        }
    }
}