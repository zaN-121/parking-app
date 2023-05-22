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
        
        var validStringInput = "";
        
        while (validStringInput.Equals(""))
        {
            validStringInput = showFormSlot();
        }
        Console.WriteLine($"Created a parking lot with {validStringInput} slots\n\n");
        while (true)
        {
            validStringInput = "";
            while (validStringInput.Equals(""))
            {
                validStringInput = showMenu();
            }
            
            excecuteChoosedMenu(validStringInput);
        }
    }

    public string showFormSlot()
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
            return "";
        }

        return input;
    }

    public void showBanner()
    {
        Console.WriteLine("=========================================");
        Console.WriteLine("------------- PARKING APP ---------------");
        Console.WriteLine("=========================================");
    }

    public string showMenu()
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
        var input = Console.In.ReadLine();
        Console.WriteLine("\n\n");
        
        try
        {
            var res = int.Parse(input);

            if (res > 7)
            {
                throw new ArgumentException("Warning: There are only 7 choices!\n\n");
            }
        }
        catch (ArgumentException e)
        {
            Console.WriteLine(e.Message);
            return "";
        }
        catch (FormatException e)
        {
            Console.WriteLine("Warning: input has to be integer!\n\n");
            return "";
        }
        catch (Exception e)
        {
            Console.WriteLine("Warning: input has to be integer!\n\n");
            return "";
        }

        return input;
    }

    public void excecuteChoosedMenu(string input)
    {
        switch (int.Parse(input)) 
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