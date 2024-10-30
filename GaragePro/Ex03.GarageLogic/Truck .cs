using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Ex03.GarageLogic.eFuelType;

namespace Ex03.GarageLogic
{
    public class Truck : Vehicle
    {
        private bool? carriesHazardousMaterials;
        private float? cargoVolume;
        private FuelType currentFuelType;
        private float? currentFuelAmountLiters;
        private float maxFuelCapacityLiters;
        public bool? CarriesHazardousMaterials { get => carriesHazardousMaterials; set => carriesHazardousMaterials = value; }
        public float? CargoVolume { get => cargoVolume; set => cargoVolume = value; }
        public FuelType CurrentFuelType { get => currentFuelType; set => currentFuelType = value; }
        public float? CurrentFuelAmountLiters { get => currentFuelAmountLiters; set => currentFuelAmountLiters = value; }
        public float MaxFuelCapacityLiters { get => maxFuelCapacityLiters; set => maxFuelCapacityLiters = value; }

        public Truck(string model, string licensePlate, string ownerName, string ownerPhone, bool? carriesHazardousMaterials, float? cargoVolume, string[]? manufacturer, float[]? currentAirPressure, float? currentFuelAmountLiters) 
           : base(model, licensePlate, ownerName, ownerPhone)
        {
            this.carriesHazardousMaterials = carriesHazardousMaterials;
            this.cargoVolume = cargoVolume;
            this.currentFuelType = FuelType.Soler;
            this.currentFuelAmountLiters = currentFuelAmountLiters;
            this.maxFuelCapacityLiters = 110;
            this.EnergyRemainingPercentage = (this.CurrentFuelAmountLiters.HasValue && this.MaxFuelCapacityLiters!=0) ? (this.CurrentFuelAmountLiters.Value / this.MaxFuelCapacityLiters) * 100 : 0;

            this.Wheels = new Wheel[12];

            for (int i = 0; i < 12; i++)
            {
                this.Wheels[i] = new Wheel(manufacturer[i], currentAirPressure[i], 28);
            }
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
