using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Ex03.GarageLogic.eCarColor;
using Ex03.GarageLogic.eNumberOfDoors;

namespace Ex03.GarageLogic
{
    public class Car : Vehicle
    {
        private CarColor? color;
        private NumberOfDoors? doors;
        public CarColor? Color { get => color; set => color = value; }
        public NumberOfDoors? Doors { get => doors; set => doors = value; }

        public Car(string model, string licensePlate, string ownerName, string ownerPhone, CarColor? color, NumberOfDoors? doors, string[]? manufacturer, float[]? currentAirPressure) //in the UI, ask user 5 manufacturer and currentAirPressure
           : base(model, licensePlate, ownerName, ownerPhone)
        {
            this.color = color;
            this.doors = doors;

            this.Wheels = new Wheel[5];
            for (int i = 0; i < 5; i++)
            {
                this.Wheels[i] = new Wheel(manufacturer[i], currentAirPressure[i], 30);
            }
        }
    }
}
