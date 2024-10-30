using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Ex03.GarageLogic.eFuelType;
using Ex03.GarageLogic.eCarColor;
using Ex03.GarageLogic.eNumberOfDoors;

namespace Ex03.GarageLogic
{
    public class FuelCar : Car
    {
        private FuelType currentFuelType;
        private float? currentFuelAmountLiters;
        private float maxFuelCapacityLiters;

        public FuelType CurrenFuelType { get => currentFuelType; set => currentFuelType = value; }
        public float? CurrentFuelAmountLiters { get => currentFuelAmountLiters; set => currentFuelAmountLiters = value; }
        public float MaxFuelCapacityLiters { get => maxFuelCapacityLiters; set => maxFuelCapacityLiters = value; }

        public FuelCar(string model, string licensePlate, string ownerName, string ownerPhone, CarColor? color, NumberOfDoors? doors, string[]? manufacturer, float[]? currentAirPressure, float? currentFuelAmountLiters)
            : base(model, licensePlate, ownerName, ownerPhone, color, doors, manufacturer, currentAirPressure)
        {
            this.currentFuelType = FuelType.Octan95;
            this.currentFuelAmountLiters = currentFuelAmountLiters;
            this.maxFuelCapacityLiters = 58;
            this.EnergyRemainingPercentage = (this.CurrentFuelAmountLiters.HasValue && this.MaxFuelCapacityLiters !=0) ? (this.CurrentFuelAmountLiters.Value / this.MaxFuelCapacityLiters) * 100 : 0 ;
        }

        public bool Refuel(float liters, FuelType? fuelType)
        {
            if (fuelType == this.currentFuelType)
            {
                if (this.currentFuelAmountLiters + liters <= this.maxFuelCapacityLiters)
                {
                    this.currentFuelAmountLiters += liters;
                    return true;
                }
                else
                {
                    return false;
                }
            }
            else
            {
                return false;
            }
        }
    }

}

