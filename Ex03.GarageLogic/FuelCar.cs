using System;
using System.Text;
using Ex03.GarageLogic.Enums;

namespace Ex03.GarageLogic
{
    public class FuelCar : FuelVehicle
    {
        private readonly eColor m_Color;
        private readonly eDoorsNum m_Doors;
        private const float k_MaximalAirPressure = 29;
        private const int k_NumOfWheels = 4;

        public FuelCar(string i_ModelName,
            string i_LicensePlate,
            float i_CurrentFuelCapacity,
            eColor i_Color,
            eDoorsNum i_Doors,
            string i_WheelsManufacturer,
            float i_CurrentAirPressure)
            : base(i_ModelName, i_LicensePlate, i_CurrentFuelCapacity)
        {
            m_Color = i_Color;
            m_Doors = i_Doors;
            m_MaximumFuelCapacity = 38;
            m_FuelType = eFuelType.Octan95;
            addWheelToFuelCar(i_WheelsManufacturer, i_CurrentAirPressure);
            CalcEnergyPrecentage();
        }

        private void addWheelToFuelCar(string i_WheelsManufacturer, float i_CurrentAirPressure)
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
@"Color: {0}
Number of doors: {1}",
                m_Color,
                m_Doors));
            return description.ToString();
        }

    }
}
