using System;
using System.Text;

namespace Ex03.GarageLogic
{
    public abstract class ElectricVehicle : Vehicle
    {
        protected float m_BatteryLifeRemaining;
        protected float m_MaximalBatteryLife;

        public ElectricVehicle(string i_ModelName,
            string i_LicensePlate,
            float i_BatteryLifeRemaining)
            : base(i_ModelName, i_LicensePlate)
        {
            m_BatteryLifeRemaining = i_BatteryLifeRemaining;
        }

        protected void CalcEnergyPrecentage()
        {
            m_RemainingEnergyPrecentage = m_BatteryLifeRemaining / m_MaximalBatteryLife;
        }

        internal void ChargeBattery(float hoursToAdd)
        {
            if (hoursToAdd + m_BatteryLifeRemaining <= m_MaximalBatteryLife)
            {
                m_BatteryLifeRemaining += hoursToAdd;
                CalcEnergyPrecentage();
            }
            else
            {
                throw new ValueOutOfRangeException(0, m_MaximalBatteryLife - m_BatteryLifeRemaining);
            }
        }

        public override string ToString()
        {
            StringBuilder description = new StringBuilder();

            description.Append(base.ToString());
            description.Append(string.Format(
@"Remaining Battery Life: {0}
Maximal Battery Life: {1}",
               m_BatteryLifeRemaining,
               m_MaximalBatteryLife));
            description.Append(Environment.NewLine);
            return description.ToString();
        }
    }
}
