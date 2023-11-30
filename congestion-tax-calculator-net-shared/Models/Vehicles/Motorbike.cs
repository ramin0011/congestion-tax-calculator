using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace congestion.calculator.Models.Vehicles
{
    public class Motorbike : Vehicle
    {
        protected override VehiclesTypes GetVehicleType()
        {
            return VehiclesTypes.Motorcycle;
        }
    }
}