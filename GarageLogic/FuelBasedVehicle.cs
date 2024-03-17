using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static Ex03.GarageLogic.EnumsProcedures;

namespace Ex03.GarageLogic
{
    public class FuelBasedVehicle: EnergySource
    {
        private readonly eFuelType r_FuelType;

        public FuelBasedVehicle(eFuelType i_FuelType, float i_MaxAmountOfFuelInLiter, float i_CurrentAmountOfFuelInLiter)
            :base(i_CurrentAmountOfFuelInLiter, i_MaxAmountOfFuelInLiter)
        {
            r_FuelType = i_FuelType;
        }

        public eFuelType FuelType
        {
            get
            {
                return r_FuelType;
            }
        }

        public void RefuelingOperation(eFuelType i_FuelType, float i_AmountOfFuelToAdd)
        {
            if (r_FuelType == i_FuelType)
            {
                Energyfilling(i_AmountOfFuelToAdd);
            }
            else
            {
                throw new FormatException(string.Format(
@"Wrong fuel type:
fuel type is {0}, and it cannot be filled with {1}", r_FuelType, i_FuelType));
            }
        }

        public override string ToString()
        {
            return string.Format(
@"Energy type: Fuel
Current amount of fuel: {0} liters
Max amount of fuel: {1} liters
Fuel type: {2}"
, CurrentAmountOfEnergyInVehicle, MaxAmountOfEnergyInVehicle, r_FuelType);
        }

 
    }
}
