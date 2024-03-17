using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using static Ex03.GarageLogic.EnumsProcedures;

namespace Ex03.GarageLogic
{
    public class ElectricBasedVehicle: EnergySource
    {
        public ElectricBasedVehicle(float i_MaxTimeOfEngineOperationInHours, float i_RemainingTimeOfEngineOperationInHours)
            :base(i_RemainingTimeOfEngineOperationInHours, i_MaxTimeOfEngineOperationInHours)
        {
        }

        public void RechargeOperation(float i_AmountOfHoursToAdd)
        {
            Energyfilling(i_AmountOfHoursToAdd);
        }

        public override string ToString()
        {
            return string.Format(
@"Energy type: Electric
Remaining time of engine in hour: {0} hours
Max time of engine in hour: {1} hours"
, CurrentAmountOfEnergyInVehicle, MaxAmountOfEnergyInVehicle);
        }

    }
}
