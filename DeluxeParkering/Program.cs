using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DeluxeParkering
{
    class Program
    {
        static void Main(string[] args)
        {
            bool badWeather = true;
            var vehicles = new List<vehicle>();
            int numberOfVehicles = 0;
            var random = new Random();
            var randVehicles = new List<vehicle>();
            var carBrands = new List<string>() {"Volvo ", "Saab ", "Mercedes ", "BMW ", "Audi ", "Peugeot " };
            var colors = new List<string>() {"blå ", "röd ", "grön ", "rosa ", "svart ","gul ",  };
            var busBrands = new List<string>() { "Volvo ", "Scania ", "Mercedes ", "MAN ", "VDL ", "Iveco " };
            var motorcycleBrands = new List<string>() { "Harley Davidsson ", "BMW ", "Yamaha ", "Honda ", "Ducati ", "Suzuki " };

            vehicles.Add(new car { brand = carBrands[random.Next(0, 6)], color = colors[random.Next(0, 6)], numberOfWheels = 4, waterResistant = true });
            vehicles.Add(new bus { brand = busBrands[random.Next(0, 6)], numberOfWheels = 6, seats = random.Next(40, 80), waterResistant = true });
            vehicles.Add(new motorcycle { brand = motorcycleBrands[random.Next(0, 6)], horsepower = random.Next(100, 500), numberOfWheels = 2, waterResistant = false});
            while (true)
            {
                if (badWeather == true)
                {
                    Console.WriteLine("Det regnar");
                }
                else
                {
                    Console.WriteLine("Idag är det sol");
                }
                foreach(var vehicle in vehicles)
                {
                    string description = "";
                    string wet = "";
                    numberOfVehicles++;
                    if(vehicle is car)
                    {
                        description = "En bil som är " + ((car)vehicle).color;
                        wet = "är torr";
                    }
                    if(vehicle is bus)
                    {
                        description = "En buss som har " + ((bus)vehicle).seats + " platser ";
                        wet = "är torr";
                    }
                    if(vehicle is motorcycle)
                    {
                        description = "En motorcykel som har " + ((motorcycle)vehicle).horsepower + " hästkrafter ";
                        if (vehicle.waterResistant == false && badWeather == true)
                        {
                            wet = "är fuktskadad";
                        }
                        else
                        {
                            wet = "är torr";
                        }
                    }
                    Console.WriteLine(description + "och är av märket " + vehicle.brand + "med " + vehicle.numberOfWheels + " hjul " + wet);  
                }
                Console.WriteLine(numberOfVehicles +" fordon på parkeringen");
                ConsoleKeyInfo letter = Console.ReadKey();
                if(letter.KeyChar == 'r')
                {
                    badWeather = true;
                }
                if(letter.KeyChar == 's')
                {
                    badWeather = false;
                }
                if(letter.KeyChar == 'n')
                {
                    randVehicles.Add(new car { brand = carBrands[random.Next(0, 6)], color = colors[random.Next(0, 6)], numberOfWheels = 4, waterResistant = true });
                    randVehicles.Add(new bus { brand = busBrands[random.Next(0, 6)], numberOfWheels = 6, seats = random.Next(40, 80), waterResistant = true });
                    randVehicles.Add(new motorcycle { brand = motorcycleBrands[random.Next(0, 6)], horsepower = random.Next(100, 500), numberOfWheels = 2, waterResistant = false });
                    var randVehicle = randVehicles[random.Next(0, numberOfVehicles)];
                    randVehicles.Add(randVehicle);
                    vehicles.Add(randVehicle);
                    randVehicles.Remove(randVehicle);
                }
                numberOfVehicles = 0;
                Console.Clear();
            }
        }
    }
    class vehicle
    {
        public string brand { get; set; } = "hej";
        public int numberOfWheels { get; set; }
        public bool waterResistant { get; set; }

    }
    class car : vehicle
    {
        public string color { get; set; }

    }
    class bus : vehicle
    {
        public int seats { get; set; }
    }
    class motorcycle : vehicle
    {
        public int horsepower { get; set; } 
    }
} 
