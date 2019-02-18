using System;
using System.Collections.Generic;
using DNP2.Assignment1.CarModel;

namespace DNP2.Assignment1.CarTest
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var cars = new List<Car>
            {
                new Car
                {
                    Model = "Porsche 911",
                    ManufacturingCountry = "Germany",
                    HorsePower = 220.5,
                    MaxSpeed = 265,
                    RoundsPerMinute = 5900,
                    EngineSize = 2994,
                    Acceleration = 6.0,
                    Cylinders = 10
                },
                new Car
                {
                    Model = "BMW",
                    ManufacturingCountry = "Germany",
                    HorsePower = 220.5,
                    MaxSpeed = 210,
                    RoundsPerMinute = 6100,
                    EngineSize = 310,
                    Acceleration = 12.0,
                    Cylinders = 8
                },
                new Car
                {
                    Model = "Subaru Forester",
                    ManufacturingCountry = "Japan",
                    HorsePower = 220.5,
                    MaxSpeed = 200,
                    RoundsPerMinute = 6000,
                    EngineSize = 3000,
                    Acceleration = 10.0,
                    Cylinders = 6
                }
            };

            // 1) 2)
            SortByMaxSpeedAndPrint(cars);

            // 3)
            TestCompareToByHorsePower(cars);
            TestCompareToByRoundsPerMinute(cars);
            TestCompareToByEngineSize(cars);
            TestCompareToByAcceleration(cars);
            TestCompareToByCylinders(cars);

            // 4) 5) 6)
            TestFindCarsByMaxSpeed(cars);
        }

        private static void SortByMaxSpeedAndPrint(List<Car> cars)
        {
            Console.WriteLine("SortByMaxSpeedAndPrint:");
            cars.Sort();
            Console.WriteLine(string.Join("\n", cars));
            Console.WriteLine();
        }

        private static void TestCompareToByHorsePower(List<Car> cars)
        {
            Console.WriteLine("TestCompareToByHorsePower:");
            cars.Sort((car, otherCar) => car.CompareToByHorsePower(otherCar));
            Console.WriteLine(string.Join("\n", cars));
            Console.WriteLine();
        }

        private static void TestCompareToByRoundsPerMinute(List<Car> cars)
        {
            Console.WriteLine("TestCompareToByRoundsPerMinute:");
            cars.Sort((car, otherCar) => car.CompareToByRoundsPerMinute(otherCar));
            Console.WriteLine(string.Join("\n", cars));
            Console.WriteLine();
        }

        private static void TestCompareToByEngineSize(List<Car> cars)
        {
            Console.WriteLine("TestCompareToByEngineSize:");
            cars.Sort((car, otherCar) => car.CompareToByEngineSize(otherCar));
            Console.WriteLine(string.Join("\n", cars));
            Console.WriteLine();
        }

        private static void TestCompareToByAcceleration(List<Car> cars)
        {
            Console.WriteLine("TestCompareToByAcceleration:");
            cars.Sort((car, otherCar) => car.CompareToByAcceleration(otherCar));
            Console.WriteLine(string.Join("\n", cars));
            Console.WriteLine();
        }

        private static void TestCompareToByCylinders(List<Car> cars)
        {
            Console.WriteLine("TestCompareToByCylinders:");
            cars.Sort((car, otherCar) => car.CompareToByCylinders(otherCar));
            Console.WriteLine(string.Join("\n", cars));
            Console.WriteLine();
        }

        private static void TestFindCarsByMaxSpeed(List<Car> cars)
        {
            var hand = new Hand
            {
                Cars = cars
            };
            Console.WriteLine("TestFindCarsByMaxSpeed above 201 km/h");
            var matchingCars = hand.FindCarsByMaxSpeed(201);
            Console.WriteLine(string.Join("\n", matchingCars));
            Console.WriteLine();

            Console.WriteLine("TestFindCarsByMaxSpeed above 250 km/h");
            matchingCars = hand.FindCarsByMaxSpeed(250);
            Console.WriteLine(string.Join("\n", matchingCars));
            Console.WriteLine();
        }
    }
}