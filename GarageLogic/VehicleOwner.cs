using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static Ex03.GarageLogic.EnumsProcedures;

namespace Ex03.GarageLogic
{
    public class VehicleOwner
    {
        private string m_OwnerName;
        private string m_PhoneNumber;
        private eVehicleStatus m_VehicleStatus;
        private Vehicle m_Vehicle;

        public VehicleOwner(string i_OwnerName, string i_PhoneNumber, Vehicle i_Vehicle)
        {
            m_OwnerName = i_OwnerName;
            m_PhoneNumber = i_PhoneNumber;
            m_VehicleStatus = eVehicleStatus.InRepair;
            m_Vehicle = i_Vehicle;
        }

        public Vehicle Vehicle
        {
            get
            {
                return m_Vehicle;
            }
        }

        public eVehicleStatus VehicleStatus
        {
            get
            {
                return m_VehicleStatus;
            }
            set
            {
                m_VehicleStatus = value;
            }
        }

        public override string ToString()
        {
            return string.Format(
@"Vehicle owner info:
Name: {0}
Phone number: {1} 
Vehicle status: {2}

Vehicle info:
{3}",
m_OwnerName, m_PhoneNumber, m_VehicleStatus, m_Vehicle.ToString());
        }


    }
}
