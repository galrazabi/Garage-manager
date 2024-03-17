using System;
using Ex03.GarageLogic;



namespace Ex03.ConsoleUI
{
    public class UI
    {
        public static string AskForCarColorMsg()
        {
            return "Enter your car color. Press the number of the desired car color:";
        }

        public static string AskForVehicleTypeMsg()
        {
            return "Enter your vehicle type. Press the number of the desired vehicle:";
        }

        public static string AskForVehicleModelNameMsg()
        {
            return "Enter your vehicle model name:";
        }

        public static string AskForVehicleRemainingEnergyMsg()
        {
            return "Enter your vehicle remaining energy:";
        }

        public static string AskForOwnerPhoneNumberMsg()
        {
            return "Enter your phone number:";
        }

        public static string AskForOwnerNameMsg()
        {
            return "Enter your Name:";
        }

        public static string AskForWheelManufacturerNameMsg()
        {
            return "Enter your wheel manufacturer name:";
        }

        public static void AskForCurrentAirPressureMsg()
        {
            Console.WriteLine("Please enter your vehicle current air pressure:");

        }

        public static string AskForLicenseNumberMsg()
        {
            return "Enter your vehicle license number:";
        }

        public static string AskForCargoTankVolumeMsg()
        {
            return "Enter your truck cargo tank volume:";
        }

        public static string AskForAmountOfEnergyToFillMsg()
        {
            return "Enter the amount of energy you wish to fill:";
        }

        public static string AskForFuelOrElectricMsg()
        {
            return "Enter 'F' for fuel based vehicle or 'E' for electric based vehicle:";
        }

        public static void VehicleIsExistMsg()
        {
            Console.WriteLine(("Thank you for coming back, your vehicle is in repair."));
        }

        public static void AskForMotorcycleEngineVolumeMsg()
        {
            Console.WriteLine(("Enter your motorcycle engine volume:"));
        }


        public static string AskForMotorcycleLicenseTypeMsg()
        {
            return "Enter your motorcycle liecense type. Press the number of the desired license type:";
        }

        public static string AskForFuelTypeMsg()
        {
            return "Enter your vehicle fuel type. Press the number of the desired fuel type:";
        }

        public static void AskIfContainsDangerousMaterialsMsg()
        {
            Console.WriteLine("Enter your if you truck contains dangerous materials. Press 'Y' if contains or 'N' otherwise:");
        }

        public static string AskForCarNumberOfDoorsMsg()
        {
            return "Enter your car number of doors. Press the number of the desired number of doors:";
        }

        public static void InsertNewVehicleSucceededMsg()
        {
            Console.WriteLine(("Insert New Vehicle Succeeded."));
        }

        public static string AskIfWantToFilterByStatusMsg()
        {
            return "Press 'Y' to display All or 'S' to display by status:";
        }

        public static string AskForStatusMsg()
        {
            return "Choose a status. Press the number of your desired status:";
        }

        public static void AskToExitMsg()
        {
            Console.WriteLine("To exit press 'Q', for another action press any other key");
        }

        public static void UpdateDoneMsg()
        {
            Console.WriteLine("Update done successefuly");
        }

        public static void GarageIsEmptyMsg()
        {
            Console.WriteLine("Garage is empty");
        }
    }
}
