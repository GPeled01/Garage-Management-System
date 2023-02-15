using System;
namespace Ex03.GarageLogic
{
    public static class VehicleState
    {
        public static string ToString(eVehicleState i_State)
        {
            switch (i_State)
            {
                case eVehicleState.InRepair:
                    return "In Repair";
                case eVehicleState.Repaired:
                    return "Repaired";
                case eVehicleState.Payed:
                    return "Payed";
                default:
                    throw new FormatException("Vehicle state is invalid");
            }
        }

        public enum eVehicleState
        {
            InRepair = 1,
            Repaired = 2,
            Payed = 3,
        }
    }
}
