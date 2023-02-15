using System;
using System.Text;

namespace Ex03.GarageLogic
{
    public abstract class FuelVehicle : Vehicle
    {
        protected eFuelType m_FuelType;
        protected float m_CurrentFuelCapacity;
        protected float m_MaximumFuelCapacity;

        public FuelVehicle(string i_ModelName,
            string i_LicensePlate,
            float i_CurrentFuelCapacity)
            : base(i_ModelName, i_LicensePlate)
        {
            m_CurrentFuelCapacity = i_CurrentFuelCapacity;
        }

        protected void CalcEnergyPrecentage()
        {
            m_RemainingEnergyPrecentage = m_CurrentFuelCapacity / m_MaximumFuelCapacity;
        }

        public void Refuel(float i_FuelToAdd, eFuelType i_FuelType)
        {
            if (m_FuelType != i_FuelType)
            {
                throw new ArgumentException("Given fuel type mismatched to vehicle fuel type!", i_FuelType.ToString());
            }
                
            if (i_FuelToAdd + m_CurrentFuelCapacity <= m_MaximumFuelCapacity)
            {
                m_CurrentFuelCapacity += i_FuelToAdd;
                CalcEnergyPrecentage();
            }
            else
            {
                throw new ValueOutOfRangeException(0, m_MaximumFuelCapacity - m_CurrentFuelCapacity);
            }
        }

        public override string ToString()
        {
            StringBuilder description = new StringBuilder();

            description.Append(base.ToString());
            description.Append(string.Format(
@"Fuel type: {0}
Current fuel capacity: {1}
Maximum fuel capacity: {2}",
               m_FuelType,
               m_CurrentFuelCapacity,
               m_MaximumFuelCapacity));
            return description.ToString();
        }

        public enum eFuelType
        {
            Soler = 1,
            Octan95 = 2,
            Octan96 = 3,
            Octan98 = 4,
        }
    }
}
