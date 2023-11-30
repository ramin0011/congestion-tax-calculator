using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using congestion_tax_calculator_net_shared.Enums;

namespace congestion.calculator.Models.Vehicles
{
    public class Car : Vehicle
    {
        private VehiclesTypes _type=VehiclesTypes.Car;

        protected override VehiclesTypes GetVehicleType()
        {
            return _type;
        }

        public void SetVehicleType(VehiclesTypes type)
        {
            this._type=type;
        }
    }
}