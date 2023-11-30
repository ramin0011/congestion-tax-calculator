using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using congestion_tax_calculator_net_shared.Enums;

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