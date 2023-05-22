// See https://aka.ms/new-console-template for more information

using Iyo.Controller;
using Iyo.Repository;
using Iyo.service;

ParkingRepository parkingRepository = new ParkingRepository();
ParkingService parkingService = new ParkingService(parkingRepository);
Controller controller = new Controller(parkingService);
controller.Run();
