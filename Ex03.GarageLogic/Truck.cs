using System;
using System.Text;

namespace Ex03.GarageLogic
{
    public class Truck : FuelVehicle
    {
        private readonly bool m_HasRefrigerateContents;
        private readonly float m_TrunkVolume;
        private const float k_MaximalAirPressure = 24;
        private const int k_NumOfWheels = 16;

        public Truck(string i_ModelName,
            string i_LicensePlate,
            float i_CurrentFuelCapacity,
            bool i_HasRefrigerateContents,
            float i_TrunkVolume,
            string i_WheelsManufacturer,
            float i_CurrentAirPressure)
            : base(i_ModelName, i_LicensePlate, i_CurrentFuelCapacity)
        {
            m_HasRefrigerateContents = i_HasRefrigerateContents;
            m_TrunkVolume = i_TrunkVolume;
            m_MaximumFuelCapacity = 120;
            m_FuelType = eFuelType.Soler;
            addWheelToTruck(i_WheelsManufacturer, i_CurrentAirPressure);
        }

        private void addWheelToTruck(string i_WheelsManufacturer, float i_CurrentAirPressure)
        {
            for (int i = 0; i < k_NumOfWheels; i++)
            {
                AddWheel(new Wheel(i_WheelsManufacturer, i_CurrentAirPressure, k_MaximalAirPressure));
            }
        }

        public override string ToString()
        {
            StringBuilder description = new StringBuilder();

            description.Append(base.ToString());
            description.Append(string.Format(
@"Trunk volume: {0}
Has refrigirated content?: {1}",
                m_TrunkVolume,
                m_HasRefrigerateContents));
            return description.ToString();
        }
    }
}
