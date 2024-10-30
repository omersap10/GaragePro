using System;
using System.Collections.Generic;
using Ex03.GarageLogic;
using Ex03.GarageLogic.eCarColor;
using Ex03.GarageLogic.eFuelType;
using Ex03.GarageLogic.eLicenseType;
using Ex03.GarageLogic.eNumberOfDoors;
using Ex03.GarageLogic.eVehicleStatus;

namespace Ex03.ConsoleUI
{
    public class AddVehicle
    {
        public static Vehicle? AddVehicleToGarage(AllVehicles garage)
        {
            Console.WriteLine("Enter the vehicle's license plate number:");
            string licensePlate = Console.ReadLine();
            Vehicle? existingVehicle = CheckForVehicleByLicensePlate(licensePlate, garage);
            if (existingVehicle != null)
            {
                return existingVehicle;
            }
            else
            {
                string vehicleType;
                while (true)
                {
                    try
                    {
                        Console.WriteLine("Enter the vehicle type (ElectricCar, FuelCar, ElectricMotorcycle, FuelMotorcycle, Truck):");
                        vehicleType = Console.ReadLine();
                        if (vehicleType == "ElectricCar" || vehicleType == "FuelCar" || vehicleType == "ElectricMotorcycle" || vehicleType == "FuelMotorcycle" || vehicleType == "Truck")
                        {
                            break;
                        }
                        else
                        {
                            throw new ArgumentException($"Invalid vehicle type entered: {vehicleType}");
                        }
                    }
                    catch (ArgumentException ex)
                    {
                        Console.WriteLine(ex.Message);
                    }
                }

                Console.WriteLine("Please enter model:");
                string model = Console.ReadLine();
                Console.WriteLine("Please enter owner name:");
                string ownerName = Console.ReadLine();
                Console.WriteLine("Please enter owner phone:");
                string ownerPhone = Console.ReadLine();

                switch (vehicleType)
                {
                    case "ElectricCar":
                        {
                            CarColor? color = ChooseColor();
                            NumberOfDoors? doors = numDoors();
                            float? remainingBatteryHours = RemainingBatteryHours();
                            String[]? manufacturer = Manufacturer(5);
                            float[]? currentAirPressure = CurrentAirPressure(5);
                            garage.AddVehicle(vehicleType, model, licensePlate, ownerName, ownerPhone, color, doors, null, null, null, null, null, remainingBatteryHours, manufacturer, currentAirPressure, null);
                            Console.WriteLine();
                            break;
                        }
                    case "FuelCar":
                        {
                            CarColor? color = ChooseColor();
                            NumberOfDoors? doors = numDoors();
                            FuelType? currentFuelType = FuelType.Octan95;
                            float? currentFuelAmount = CurrentFuelAmount();
                            String[]? manufacturer = Manufacturer(5);
                            float[]? currentAirPressure = CurrentAirPressure(5);
                            garage.AddVehicle(vehicleType, model, licensePlate, ownerName, ownerPhone, color, doors, null, null, null, currentFuelType, currentFuelAmount, null, manufacturer, currentAirPressure, null);
                            Console.WriteLine();
                            break;
                        }
                    case "ElectricMotorcycle":
                        {
                            LicenseType? licenseType = LicenseType();
                            int? engineVolume = EngineVolume();
                            float? remainingBatteryHours = RemainingBatteryHours();
                            String[]? manufacturer = Manufacturer(2);
                            float[]? currentAirPressure = CurrentAirPressure(2);
                            garage.AddVehicle(vehicleType, model, licensePlate, ownerName, ownerPhone, null, null, licenseType, engineVolume, null, null, null, remainingBatteryHours, manufacturer, currentAirPressure, null);
                            Console.WriteLine();
                            break;
                        }
                    case "FuelMotorcycle":
                        {
                            LicenseType? licenseType = LicenseType();
                            int? engineVolume = EngineVolume();
                            FuelType? currentFuelType = FuelType.Octan98;
                            float? currentFuelAmount = CurrentFuelAmount();
                            String[]? manufacturer = Manufacturer(2);
                            float[]? currentAirPressure = CurrentAirPressure(2);
                            garage.AddVehicle(vehicleType, model, licensePlate, ownerName, ownerPhone, null, null, licenseType, engineVolume, null, currentFuelType, currentFuelAmount, null, manufacturer, currentAirPressure, null);
                            Console.WriteLine();
                            break;
                        }
                    case "Truck":
                        {
                            FuelType? currentFuelType = FuelType.Soler;
                            float? currentFuelAmount = CurrentFuelAmount();
                            bool? carriesHazardousMaterials = CarriesHazardousMaterials();
                            float? cargoVolume = CargoVolume();
                            String[]? manufacturer = Manufacturer(12);
                            float[]? currentAirPressure = CurrentAirPressure(12);
                            garage.AddVehicle(vehicleType, model, licensePlate, ownerName, ownerPhone, null, null, null, null, carriesHazardousMaterials, currentFuelType, currentFuelAmount, null, manufacturer, currentAirPressure, cargoVolume);
                            Console.WriteLine();
                            break;
                        }
                    default:
                        throw new ArgumentException("Invalid vehicle type");
                }

                return garage.VehiclesInGarage[garage.VehiclesInGarage.Count - 1];
            }
        }


        public static CarColor? ChooseColor()
        {
            Console.WriteLine("Please enter car color (Blue, White, Red, Yellow):");
            while (true)
            {
                try
                {
                    string carColor = Console.ReadLine();
                    if (Enum.TryParse(carColor, true, out CarColor parsedColor))
                    {
                        return parsedColor;
                    }
                    else
                    {
                        throw new FormatException("Invalid color format");
                    }
                }
                catch (FormatException ex)
                {
                    Console.WriteLine(ex.Message);
                    Console.WriteLine("Please enter a valid car color:");
                }
            }
        }

        public static NumberOfDoors? numDoors()
        {
            Console.WriteLine("Please enter number of doors (Two, Three, Four, Five):");
            while (true)
            {
                try
                {
                    string doorsNum = Console.ReadLine();
                    if (Enum.TryParse(doorsNum, true, out NumberOfDoors parsedDoors))
                    {
                        return parsedDoors;
                    }
                    else
                    {
                        throw new FormatException("Invalid number of doors format");
                    }
                }
                catch (FormatException ex)
                {
                    Console.WriteLine(ex.Message);
                    Console.WriteLine("Please enter a valid number of doors:");
                }
            }
        }

        public static float? RemainingBatteryHours()
        {
            Console.WriteLine("Please enter remaining Battery (Hours):");
            while (true)
            {
                try
                {
                    float remainingBatteryHours = float.Parse(Console.ReadLine());
                    if (remainingBatteryHours < 0 || remainingBatteryHours > 4.8f)
                    {
                        throw new ValueOutOfRangeException(0, 4.8f);
                    }
                    return remainingBatteryHours;
                }
                catch (FormatException)
                {
                    Console.WriteLine("Invalid input. Please enter a valid number for remaining battery hours:");
                }
                catch (ValueOutOfRangeException ex)
                {
                    Console.WriteLine(ex.Message);
                    Console.WriteLine("Please enter a valid number for remaining battery hours:");
                }
            }
        }

        public static string[]? Manufacturer(int numOfWheels)
        {
            string[] manufacturers = new string[numOfWheels];

            while (true)
            {
                try
                {
                    Console.WriteLine("Would you like to set all wheels manufacturers the same? (Y/N)");
                    string answer = Console.ReadLine();
                    if (answer.Equals("Y") || answer.Equals("y"))
                    {
                        Console.WriteLine("Please enter wheels manufacturer:");
                        string manufacturer = Console.ReadLine();
                        for (int i = 0; i < numOfWheels; i++)
                        {
                            manufacturers[i] = manufacturer;
                        }
                        break;
                    }
                    else if (answer.Equals("N") || answer.Equals("n"))
                    {
                        for (int i = 0; i < numOfWheels; i++)
                        {
                            Console.WriteLine("Please enter wheel manufacturer:");
                            manufacturers[i] = Console.ReadLine();
                        }
                        break; 
                    }
                    else
                    {
                        Console.WriteLine("Invalid input. Please enter 'Y' or 'N'.");
                    }
                }
                catch (Exception ex)
                {
                    Console.WriteLine($"An error occurred: {ex.Message}");
                    Console.WriteLine("Please try again.");
                }
            }

            return manufacturers;
        }

        public static float[]? CurrentAirPressure(int numOfWheels)
        {
            float[] currentAirPressures = new float[numOfWheels];

            Console.WriteLine("Would you like to set all wheels current Air Pressure the same? (Y/N)");
            string answer = Console.ReadLine();
            bool setAllTogether = (answer.Equals("Y") || answer.Equals("y"));
            if (setAllTogether)
            {
                Console.WriteLine("Please enter wheels current Air Pressure:");
                while (true)
                {
                    try
                    {
                        float airPressure = float.Parse(Console.ReadLine());
                        if (airPressure < 0 || airPressure > 30)
                        {
                            throw new ValueOutOfRangeException(0, 30);
                        }
                        for (int i = 0; i < numOfWheels; i++)
                        {
                            currentAirPressures[i] = airPressure;
                        }
                        break;
                    }
                    catch (FormatException)
                    {
                        Console.WriteLine("Invalid input. Please enter a valid number for current air pressure:");
                    }
                    catch (ValueOutOfRangeException ex)
                    {
                        Console.WriteLine(ex.Message);
                        Console.WriteLine("Please enter a valid number for current air pressure:");
                    }
                }
            }
            else if (answer.Equals("N") || answer.Equals("n")) 
            {
                for (int i = 0; i < numOfWheels; i++)
                {
                    Console.WriteLine("Please enter wheel current Air Pressure:");
                    while (true)
                    {
                        try
                        {
                            float currentAirPressure = float.Parse(Console.ReadLine());
                            if (currentAirPressure < 0 || currentAirPressure > 30)
                            {
                                throw new ValueOutOfRangeException(0, 30);
                            }
                            currentAirPressures[i] = currentAirPressure;
                            break;
                        }
                        catch (FormatException)
                        {
                            Console.WriteLine("Invalid input. Please enter a valid number for current air pressure:");
                        }
                        catch (ValueOutOfRangeException ex)
                        {
                            Console.WriteLine(ex.Message);
                            Console.WriteLine("Please enter a valid number for current air pressure:");
                        }
                    }
                }
            }
            return currentAirPressures;
        }

        public static LicenseType? LicenseType()
        {
            Console.WriteLine("Please enter license type (A1, A2, AB, B2):");
            while (true)
            {
                try
                {
                    string license = Console.ReadLine();
                    if (Enum.TryParse(license, true, out LicenseType parsedLicense))
                    {
                        return parsedLicense;
                    }
                    else
                    {
                        throw new FormatException("Invalid license type format");
                    }
                }
                catch (FormatException ex)
                {
                    Console.WriteLine(ex.Message);
                    Console.WriteLine("Please enter a valid license type:");
                }
            }
        }

        public static int? EngineVolume()
        {
            Console.WriteLine("Please enter engine volume:");
            while (true)
            {
                try
                {
                    int volume = int.Parse(Console.ReadLine());
                    return volume;
                }
                catch (FormatException)
                {
                    Console.WriteLine("Invalid input. Please enter a valid number for engine volume:");
                }
            }
        }

        public static float? CurrentFuelAmount()
        {
            Console.WriteLine("Please enter current fuel amount:");
            while (true)
            {
                try
                {
                    float fuelAmount = float.Parse(Console.ReadLine());
                    if (fuelAmount < 0 || fuelAmount > 58)
                    {
                        throw new ValueOutOfRangeException(0, 58);
                    }
                    return fuelAmount;
                }
                catch (FormatException)
                {
                    Console.WriteLine("Invalid input. Please enter a valid number for fuel amount:");
                }
                catch (ValueOutOfRangeException ex)
                {
                    Console.WriteLine(ex.Message);
                    Console.WriteLine("Please enter a valid number for fuel amount:");
                }
            }
        }

        public static bool? CarriesHazardousMaterials()
        {
            Console.WriteLine("Does the vehicle carry hazardous materials? (Y/N)");
            while (true)
            {
                try
                {
                    string answer = Console.ReadLine();
                    if (answer.Equals("Y") || answer.Equals("y"))
                    {
                        return true;
                    }
                    else if (answer.Equals("N") || answer.Equals("n"))
                    {
                        return false;
                    }
                    else
                    {
                        throw new FormatException("Invalid hazardous materials format");
                    }
                }
                catch (FormatException ex)
                {
                    Console.WriteLine(ex.Message);
                    Console.WriteLine("Please enter Y or N:");
                }
            }
        }

        public static float? CargoVolume()
        {
            Console.WriteLine("Please enter cargo volume:");
            while (true)
            {
                try
                {
                    float volume = float.Parse(Console.ReadLine());
                    if (volume < 0)
                    {
                        throw new ValueOutOfRangeException(0, float.MaxValue);
                    }
                    return volume;
                }
                catch (FormatException)
                {
                    Console.WriteLine("Invalid input. Please enter a valid number for cargo volume:");
                }
                catch (ValueOutOfRangeException ex)
                {
                    Console.WriteLine(ex.Message);
                    Console.WriteLine("Please enter a valid number for cargo volume:");
                }
            }
        }

        public static Vehicle? CheckForVehicleByLicensePlate(string licensePlate, AllVehicles garage)
        {
            foreach (Vehicle vehicle in garage.VehiclesInGarage)
            {
                if (vehicle.LicensePlate == licensePlate)
                {
                    Console.WriteLine("This vehicle is already in the garage.");
                    Console.WriteLine("Moving vehicle to repair status.");
                    vehicle.Status = VehicleStatus.InRepair;
                    return vehicle;
                }
            }
            return null;
        }
    }
}