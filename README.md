# Garage-manager
Garage Management System
This project implements a Garage Management System, comprising both the backend logic (GarageLogic namespace) and a user-friendly frontend UI (GarageUI namespace).

GarageLogic
The GarageLogic namespace contains the core logic and data structures for managing vehicles and their owners within a garage.

Vehicle Class
Description: Represents a vehicle with common properties and methods.
Properties:
ModelName: The model name of the vehicle.
LicenseNumber: The license number of the vehicle.
RemainingEnergyPercentage: The remaining energy percentage of the vehicle.
WheelsList: The list of wheels attached to the vehicle.
EnergySource: The energy source (fuel-based or electric-based) of the vehicle.
Methods:
UpadateEnergyPercent(): Abstract method to update the remaining energy percentage of the vehicle.
AddAndCreateWheels(string i_ManufacturerName, float i_CurrentAirPressure): Abstract method to add and create wheels for the vehicle.
InitializeEnergySource(eFuelOrElectric i_FuelOrElectric, float i_CurrentAmountOfEnergyInVehicle): Abstract method to initialize the energy source of the vehicle.
VehicleOwner Class
Description: Represents an owner of a vehicle in the garage.
Properties:
Vehicle: The vehicle owned by the owner.
VehicleStatus: The status of the vehicle (InRepair, Repaired, PayedFor).
Wheel Class
Description: Represents a wheel of a vehicle.
Properties:
ManufacturerName: The manufacturer name of the wheel.
CurrentAirPressure: The current air pressure of the wheel.
RecommendedMaxAirPressure: The recommended maximum air pressure of the wheel.
Methods:
InflateAction(float i_AirToAdd): Method to inflate the wheel to the recommended maximum air pressure.
EnergySource Class
Description: Represents an abstract energy source for vehicles.
Properties:
FuelOrElectric: The type of energy source (Fuel or Electric).
CurrentAmountOfEnergyInVehicle: The current amount of energy in the vehicle.
MaxAmountOfEnergyInVehicle: The maximum amount of energy the vehicle can hold.
Methods:
Energyfilling(float i_AmountOfEnergyToAdd): Method to fill or recharge the energy source.
Garage Class
Description: Manages the vehicles and their owners in the garage.
Properties:
VehicleOwnersList: Dictionary of vehicle owners stored in the garage.
Methods:
InsertNewVehicleOwner(VehicleOwner i_NewVehicleOwner): Method to insert a new vehicle owner into the garage.
CheckIfVehicleExistInGarage(string i_LicenseNumber): Method to check if a vehicle exists in the garage.
UpdateVehicleStatus(string i_LicenseNumber, eVehicleStatus i_VehicleStatus): Method to update the status of a vehicle.
PrintAllLicenseNumbers(): Method to print all license numbers of vehicles in the garage.
PrintLicenseNumbersByStatus(eVehicleStatus i_VehicleStatus): Method to print license numbers of vehicles with a specific status.
InflateTiresToMaximumAfterCheck(string i_LicenseNumber): Method to inflate tires to the maximum recommended pressure.
RefuelAFuelBasedVehicleAfterCheck(string i_LicenseNumber, eFuelType i_FuelType, float i_AmountToFill): Method to refuel a fuel-based vehicle.
ChargeAnElectricBasedVehicleAfterCheck(string i_LicenseNumber, float i_AmountToFill): Method to charge an electric-based vehicle.
PrintVehicleOwnerInfoAfterCheck(string i_LicenseNumber): Method to print vehicle owner information.
GarageUI
The GarageUI namespace contains the user interface components for interacting with the garage management system.

GarageConsoleUI Class
Description: Provides a console-based user interface for interacting with the garage management system.
Features:
Add new vehicles to the garage.
Display all vehicles in the garage.
Filter vehicles by status.
Update vehicle status.
Perform maintenance tasks such as inflating tires, refueling, and recharging.
