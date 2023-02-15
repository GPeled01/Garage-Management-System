using System;
using static Ex03.GarageLogic.VehicleState;

namespace Ex03.GarageLogic
{
    public class Client
    {
        private string m_Name;
        private string m_PhoneNumber;
        private eVehicleState m_VehicleState = eVehicleState.InRepair;

        public Client(string i_Name, string i_PhoneNumber)
        {
            m_Name = i_Name;
            m_PhoneNumber = i_PhoneNumber;
        }

        public string Name
        {
            get { return m_Name; }
        }

        public string PhoneNumber
        {
            get { return m_PhoneNumber; }
        }

        public eVehicleState VehicleState
        {
            get { return m_VehicleState; }

            set { m_VehicleState = value; }
        }

        public override string ToString()
        {
            string description = string.Format(
@"Client name: {0}
Client phone number: {1}
Owned vehicle state: {2}",
               m_Name,
               m_PhoneNumber,
               m_VehicleState);
            return description;
        }
    }
}
