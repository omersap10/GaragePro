using Ex03.GarageLogic.eCarColor;
using Ex03.GarageLogic.eFuelType;
using Ex03.GarageLogic.eLicenseType;
using Ex03.GarageLogic.eNumberOfDoors;
using Ex03.GarageLogic.eVehicleStatus;
using Ex03.GarageLogic;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ex03.GarageLogic
{
    public class AllVehicles
    {
        public List<Vehicle> VehiclesInGarage;

        public AllVehicles()
        {
            this.VehiclesInGarage = new List<Vehicle>();
        }

        public void AddVehicle(string type, string model, string licensePlate, string ownerName, string ownerPhone, CarColor? color, NumberOfDoors? doors, LicenseType? licenseType, int? engineVolume, bool? carriesHazardousMaterials, FuelType? currentFuelType, float? currentFuelAmountLiters, float? remainingBatteryHours, string[]? manufacturer, float[]? currentAirPressure, float? cargoVolume)
        {
            Vehicle vehicle;
            
            switch (type)
            {
                case "ElectricCar":
                    vehicle = new ElectricCar(model, licensePlate, ownerName, ownerPhone, color, doors, manufacturer, currentAirPressure, remainingBatteryHours);
                    break;
                case "FuelCar":
                    vehicle = new FuelCar(model, licensePlate, ownerName, ownerPhone, color, doors, manufacturer, currentAirPressure, currentFuelAmountLiters);
                    break;
                case "ElectricMotorcycle":
                    vehicle = new ElectricMotorcycle(model, licensePlate, ownerName, ownerPhone, licenseType, engineVolume, manufacturer, currentAirPressure, remainingBatteryHours);
                    break;
                case "FuelMotorcycle":
                    vehicle = new FuelMotorcycle(model, licensePlate, ownerName, ownerPhone, licenseType, engineVolume, manufacturer, currentAirPressure, currentFuelAmountLiters);
                    break;
                case "Truck":
                    vehicle = new Truck(model, licensePlate, ownerName, ownerPhone, carriesHazardousMaterials, cargoVolume, manufacturer, currentAirPressure, currentFuelAmountLiters);
                    break;
                default:
                    throw new ArgumentException("Invalid vehicle type");
            }

            VehiclesInGarage.Add(vehicle);
        }
    }
}
    
