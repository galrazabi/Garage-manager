using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static Ex03.GarageLogic.EnergySource;
using static Ex03.GarageLogic.FuelBasedVehicle;
using static Ex03.GarageLogic.VehicleOwner;
using static Ex03.GarageLogic.Vehicle;

namespace Ex03.GarageLogic
{
    public class EnumsProcedures
    {
        public enum eColor
        {
            White = 1,
            Black,
            Yellow,
            Red,            
        }

        public enum eNumberOfDoors
        {
            Two = 1,
            Three,
            Four,
            Five,
        }

        public enum eFuelOrElectric
        {
            Fuel = 1,
            Electric,
        }

        public enum eFuelType
        {
            Soler = 1,
            Octane95,
            Octane96,
            Octane98,            
        }

        public enum eLicenseType
        {
            A1 = 1,
            A2,
            AA,
            B1,
        }

        public enum eVehicleType
        {
            Motorcycle = 1,
            Car,
            Truck,
        }
        public enum eVehicleStatus
        {
            InRepair = 1,
            Repaired,
            PayedFor,
        }

        public enum eStrOrNum
        {
            Str = 1,
            Num,
        }

        public static string[] GetListOfVehicleType()
        {
            return Enum.GetNames(typeof(eVehicleType));
        }

        public static string[] GetListOfEnergyType()
        {
            return Enum.GetNames(typeof(eFuelOrElectric));
        }

        public static string[] GetListOfStatus()
        {
            return Enum.GetNames(typeof(eVehicleStatus));
        }

        public static string[] GetListOfFuelType()
        {
            return Enum.GetNames(typeof(eFuelType));
        }

        public static string[] GetListOfCarColor()
        {
            return Enum.GetNames(typeof(eColor));
        }

        public static string[] GetListOfNumOfDoors()
        {
            return Enum.GetNames(typeof(eNumberOfDoors));
        }

        public static string[] GetListOfLicenseType()
        {
            return Enum.GetNames(typeof(eLicenseType));
        }
    }
}
