using System;
using Ex03.GarageLogic;

namespace Ex03.ConsoleUI
{
    // $G$ CSS-999 (-3) The class must have an access modifier.
    class Program
    {
        // $G$ CSS-999 (-3) The method must have an access modifier.
        static void Main(string[] args)
        {
            Garage garage = new Garage();
            GarageManager ui = new GarageManager(garage);
            ui.StartGarage();
        }
    }
}
