using System;
using System.Collections.Generic;
using System.Threading;
using Ex03.GarageLogic;

namespace Ex03.ConsoleUI
{
    internal static class GarageFunctionality
    {
        internal static void InsertNewVehicleUI(Garage i_Garage)
        {
            Vehicle vehicle = null;
            Client client = null;
            VehicleInitalizer.eVehicleKind userInput;
            string licensePlate;

            string message =
@"Please enter the type of the vehicle you want to insert to the garage:
1. Electric car
2. Electric motorcycle
3. Fuel car
4. Fuel motorcycle
5. Fuel truck
";
            Console.WriteLine("Please enter vehicle license number:");
            licensePlate = Console.ReadLine();
            try
            {
                vehicle = i_Garage.FindVehicle(licensePlate);
                Console.WriteLine("This vehicle is already in the garage!");
                i_Garage.ChangeVehicleState(licensePlate, VehicleState.eVehicleState.InRepair);
            }
            catch (ArgumentException)
            {
                while (vehicle == null)
                {
                    Console.Clear();
                    userInput = (VehicleInitalizer.eVehicleKind)UserInputHelper.RecieveMenuInput(message, 1, 5);
                    Console.Clear();
                    vehicle = VehicleDataCollector.CollectVehicleData(userInput, licensePlate);
                    Console.Clear();
                }

                Console.Clear();
                client = VehicleDataCollector.CollectClientData();
                Console.Clear();
                i_Garage.InsertNewVehicle(vehicle, client);
                Console.Clear();
            }
        }

        internal static void FilterVehiclesLicesnsePlateUI(Garage i_Garage)
        {
            string message;
            bool shouldFilter = false;
            int userInput;
            VehicleState.eVehicleState filterBy = VehicleState.eVehicleState.InRepair;
            List<string> filteredLicensePlates = new List<string>();

            message = @"Provide a filter criteria:
1. In repair
2. Repaired
3. Payed
4. No filter";
            userInput = UserInputHelper.RecieveMenuInput(message, 1, 4);
            Console.Clear();
            shouldFilter = userInput != 4;
            if (userInput !=4)
            {
                shouldFilter = true;
                filterBy = (VehicleState.eVehicleState)(userInput);
            }
            filteredLicensePlates = i_Garage.FilterVehiclesLicesnsePlate(shouldFilter, filterBy);
            Console.WriteLine(string.Format("{0}License plate numbers:", Environment.NewLine));
            foreach (string licensePlate in filteredLicensePlates)
            {
                Console.WriteLine(licensePlate);
            }
        }

        internal static void ChangeVehicleStateUI(Garage i_Garage)
        {
            string message;
            VehicleState.eVehicleState userInput;
            Vehicle vehicle;

            vehicle = getVehicleByLicenseNumber(i_Garage);
            message = @"Please provide new state for this vehicle:
1. In repair
2. Repaired
3. Payed";
            userInput = (VehicleState.eVehicleState)UserInputHelper.RecieveMenuInput(message, 1, 3);
            i_Garage.ChangeVehicleState(vehicle.LicensePlate, userInput);
        }

        internal static void InflateWheelsToFullUI(Garage i_Garage)
        {
            bool isValidInput = false;
            Vehicle vehicle;

            while (!isValidInput)
            {
                try
                {
                    vehicle = getVehicleByLicenseNumber(i_Garage);
                    i_Garage.InflateWheelsToFull(vehicle.LicensePlate);
                }
                catch (ValueOutOfRangeException e)
                {
                    Console.WriteLine(e.ErrorMessage());
                    Thread.Sleep(800);
                }

                isValidInput = true;
            }
        }

        internal static void RefuelUI(Garage i_Garage)
        {
            bool isValidInput = false;
            float fuelToAdd;
            FuelVehicle.eFuelType fuelType;
            Vehicle vehicle;
            string amountOfFuelMessage;
            string fuelTypeMessage;


            fuelTypeMessage = @"Please provide fuel type:
1. Soler
2. Octan 95
3. Octan 96
4. Octan 98
";

            while (!isValidInput)
            {
                vehicle = getVehicleByLicenseNumber(i_Garage);
                amountOfFuelMessage = "Please enter fuel amount in liters:";
                fuelToAdd = UserInputHelper.RecieveInputAndConvertToFloat(amountOfFuelMessage);
                fuelType = (FuelVehicle.eFuelType)UserInputHelper.RecieveInputAndConvertToInt(fuelTypeMessage);
                try
                {
                    i_Garage.Refuel(vehicle.LicensePlate, fuelType, fuelToAdd);
                }
                catch (ArgumentException error)
                {
                    Console.WriteLine(error.Message);
                    Thread.Sleep(800);
                    continue;
                }
                catch (ValueOutOfRangeException error)
                {
                    Console.WriteLine(error.ErrorMessage());
                    Thread.Sleep(800);
                    continue;
                }

                isValidInput = true;
            }
        }

        internal static void ChargeBatteryUI(Garage i_Garage)
        {
            bool isValidInput = false;
            float minutesToAdd;
            Vehicle vehicle;
            string message;

            message = "Please enter amount of minutes you want to recharge:";
            while (!isValidInput)
            {
                Console.Clear();
                vehicle = getVehicleByLicenseNumber(i_Garage);
                minutesToAdd = UserInputHelper.RecieveInputAndConvertToFloat(message);
                try
                {
                    i_Garage.ChargeBattery(vehicle.LicensePlate, minutesToAdd);
                }
                catch (ArgumentException error)
                {
                    Console.WriteLine(error.Message);
                    Thread.Sleep(800);
                    continue;
                }
                catch (ValueOutOfRangeException e)
                {
                    Console.WriteLine(e.ErrorMessage());
                    continue;
                }

                isValidInput = true;
            }
        }

        internal static void GetDescriptionUI(Garage i_Garage)
        {
            Vehicle vehicle;
            string vehicleDetails;

            vehicle = getVehicleByLicenseNumber(i_Garage);
            vehicleDetails = i_Garage.GetDescription(vehicle.LicensePlate);
            Console.WriteLine(vehicleDetails);
        }

        private static Vehicle getVehicleByLicenseNumber(Garage i_Garage)
        {
            Vehicle vehicle = null;
            bool isInputValid = false;
            string licensePlate;

            while (!isInputValid)
            {
                Console.Clear();
                Console.WriteLine("Please provide license plate number:{0}", Environment.NewLine);
                licensePlate = Console.ReadLine();
                try
                {
                    vehicle = i_Garage.FindVehicle(licensePlate);
                    isInputValid = true;
                }
                catch (ArgumentException error)
                {
                    Console.WriteLine(error.Message);
                    Thread.Sleep(800);
                }
            }

            return vehicle;
        }
    }
}
