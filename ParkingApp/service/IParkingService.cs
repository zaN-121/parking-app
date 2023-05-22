using Iyo.Model;

namespace Iyo.service;

public interface IParkingService
{
    public void addVehicle();
    public void releaseVehicle();
    public void getVehicles();
    public void getVehiclesByColor();
    public void getVehiclesByOddRegistrationNumber();
    public void getVehiclesByEventRegistratinNumber();
}