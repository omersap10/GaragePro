using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Ex03.GarageLogic.eFuelType;
using Ex03.GarageLogic.eLicenseType;

namespace Ex03.GarageLogic
{
    public class FuelMotorcycle : Motorcycle
    {
        private FuelType currentFuelType;
        private float? currentFuelAmountLiters;
        private float maxFuelCapacityLiters;

        public FuelType CurrentFuelType { get => currentFuelType; set => currentFuelType = value; }
        public float? CurrentFuelAmountLiters { get => currentFuelAmountLiters; set => currentFuelAmountLiters = value; }
        public float MaxFuelCapacityLiters { get => maxFuelCapacityLiters; set => maxFuelCapacityLiters = value; }

        public FuelMotorcycle(string model, string licensePlate, string ownerName, string ownerPhone, LicenseType? licenseType, int? engineVolume, string[]? manufacturer, float[]? currentAirPressure, float? currentFuelAmountLiters)
            :base(model, licensePlate, ownerName, ownerPhone,licenseType, engineVolume, manufacturer, currentAirPressure)
        {
            this.currentFuelType = FuelType.Octan98;
            this.currentFuelAmountLiters = currentFuelAmountLiters;
            this.maxFuelCapacityLiters = (float)5.8;
            this.EnergyRemainingPercentage = (this.CurrentFuelAmountLiters.HasValue && this.MaxFuelCapacityLiters!=0 ) ? (this.CurrentFuelAmountLiters.Value / this.MaxFuelCapacityLiters) * 100 : 0;
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
