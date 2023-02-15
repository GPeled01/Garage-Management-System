using System;
using System.Collections.Generic;
using static Ex03.GarageLogic.FuelVehicle;
using static Ex03.GarageLogic.VehicleState;

namespace Ex03.GarageLogic
{
    public class Garage
    {
        private readonly Dictionary<Vehicle, Client> m_GarageDict;

        public Garage()
        {
           m_GarageDict = new Dictionary<Vehicle, Client>();
        }

        // $G$ CSS-013 (-3) Bad parameter name (should be in the form of i_PascalCase).
        public void InsertNewVehicle(Vehicle i_vehicle, Client i_ClientToAdd)
        {
            i_ClientToAdd.VehicleState = eVehicleState.InRepair;
            m_GarageDict.Add(i_vehicle, i_ClientToAdd);
        }

        // $G$ CSS-013 (-3) Bad parameter name (should be in the form of i_PascalCase).
        public List<string> FilterVehiclesLicesnsePlate(bool filterFlag, eVehicleState i_StateToFilter)
        {
            List<string> filteredLicensePlates = new List<string>();

            foreach (KeyValuePair<Vehicle, Client> pair in m_GarageDict)
            {
                if (!filterFlag || pair.Value.VehicleState == i_StateToFilter)
                {
                    filteredLicensePlates.Add(pair.Key.LicensePlate);
                }
            }

            return filteredLicensePlates;
        }

        public void ChangeVehicleState(string i_LicensePlate, eVehicleState i_NewState)
        {
            Vehicle vehicle = FindVehicle(i_LicensePlate);
            Client client;
            try
            {
                m_GarageDict.TryGetValue(vehicle, out client);
            }
            catch (ArgumentNullException)
            {
                throw new ArgumentException(string.Format("Vehicle not found{0}",
                    Environment.NewLine));
            }
            client.VehicleState = i_NewState;
        }

        public void InflateWheelsToFull(string i_LicensePlate)
        {
            Vehicle vehicleToInflate = FindVehicle(i_LicensePlate);
            float airToAdd;

            foreach (Wheel wheel in vehicleToInflate.Wheels)
            {
                airToAdd = wheel.MaximalAirPressure - wheel.CurrentAirPressure;
                wheel.Inflate(airToAdd);
            }
        }

        // $G$ CSS-013 (-3) Bad parameter name (should be in the form of i_PascalCase).
        public void Refuel(string i_LicensePlate, eFuelType i_FuelType, float i_fuelToAdd)
        {
            Vehicle vehicleToRefuel = FindVehicle(i_LicensePlate);
            if (!(vehicleToRefuel is FuelVehicle))
            {
                throw new ArgumentException("Can't fuel a non-fuel-based vehicle!");
            }

            (vehicleToRefuel as FuelVehicle).Refuel(i_fuelToAdd, i_FuelType);
        }

        public void ChargeBattery(string i_LicensePlate, float i_MinutesToAdd)
        {
            Vehicle vehicleToCharge = FindVehicle(i_LicensePlate);
            if (!(vehicleToCharge is ElectricVehicle))
            {
                throw new ArgumentException("Can't charge battery for a non-electric vehicle!");
            }
            float hoursToAdd = i_MinutesToAdd / 60;
            (vehicleToCharge as ElectricVehicle).ChargeBattery(hoursToAdd);
        }

        public Vehicle FindVehicle(string i_LicenseNumber)
        {
            Vehicle foundVehicle = null;

            foreach (Vehicle vehicleKey in m_GarageDict.Keys)
            {
                if (vehicleKey.LicensePlate == i_LicenseNumber)
                {
                    foundVehicle = vehicleKey;
                    break;
                }
            }

            if (foundVehicle == null)
            {
                throw new ArgumentException(string.Format("Vehicle not found{0}",
                    Environment.NewLine));
            }

            return foundVehicle;
        }

        public string GetDescription(string i_LicenseNumber)
        {
            Client client;
            Vehicle vehicle = FindVehicle(i_LicenseNumber);
            List<Wheel> wheels = vehicle.Wheels;

            m_GarageDict.TryGetValue(vehicle, out client);
            string description = string.Format(
@"{0}
{1}",
                client.ToString(),
                vehicle.ToString());

            return description;
        }
    }
}

