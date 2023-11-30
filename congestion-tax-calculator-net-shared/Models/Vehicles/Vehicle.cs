using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace congestion.calculator.Models.Vehicles
{
    public abstract class Vehicle
    {
        protected abstract VehiclesTypes GetVehicleType();
    }
}