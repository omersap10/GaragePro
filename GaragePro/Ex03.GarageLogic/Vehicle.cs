using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Ex03.GarageLogic.eFuelType;
using Ex03.GarageLogic.eVehicleStatus;

namespace Ex03.GarageLogic
{
    public abstract class Vehicle
    {
        private string model;
        private string licensePlate;
        private float energyRemainingPercentage;
        private VehicleStatus status;
        private Wheel[] wheels;
        private string ownerName;
        private string ownerPhone;
        
        public string Model { get => model; set => this.model = value; }
        public string LicensePlate { get => licensePlate; set => this.licensePlate = value; }
        public float EnergyRemainingPercentage { get => energyRemainingPercentage; set => this.energyRemainingPercentage = value; } 
        public VehicleStatus Status { get => status; set => this.status = value; }
        public Wheel[] Wheels { get => wheels; set => this.wheels = value; } 
        public string OwnerName { get => ownerName; set => this.ownerName = value; }
        public string OwnerPhone { get => ownerPhone; set => this.ownerPhone = value; }

        public Vehicle(string model, string licensePlate, string ownerName, string ownerPhone)
        {
            this.model = model;
            this.licensePlate = licensePlate;
            this.status = VehicleStatus.InRepair;
            this.wheels = new Wheel[0];
            this.ownerName = ownerName;
            this.ownerPhone = ownerPhone;
        }
    }
 }


