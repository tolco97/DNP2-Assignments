using System;
using System.Collections.Generic;
using System.Linq;
using DNP2.Assignment1.CarModel;
using DNP2.Helpers.Common;

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
                    Cylinders = 6
                },
                new Car
                {
                    Model = "BMW",
                    ManufacturingCountry = "Germany",
                    HorsePower = 230.5,
                    MaxSpeed = 210,
                    RoundsPerMinute = 6100,
                    EngineSize = 310,
                    Acceleration = 12.0,
                    Cylinders = 6
                },
                new Car
                {
                    Model = "Subaru Forester",
                    ManufacturingCountry = "Japan",
                    HorsePower = 240.5,
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

        private static void SortByMaxSpeedAndPrint(IEnumerable<Car> cars)
        {
            Console.WriteLine(nameof(SortByMaxSpeedAndPrint));
            var sortedCars = cars.ToList();
            sortedCars.Sort(); // sortedCars.OrderBy(car => car.MaxSpeed)
            cars = sortedCars;
            cars.PrintAll();
        }

        private static void TestCompareToByHorsePower(IEnumerable<Car> cars)
        {
            Console.WriteLine(nameof(TestCompareToByHorsePower));
            PlayGame(cars.ElementAt(0), cars.ElementAt(1), (car, other) => car.CompareToByHorsePower(other));
        }

        private static void TestCompareToByRoundsPerMinute(IEnumerable<Car> cars)
        {
            Console.WriteLine(nameof(TestCompareToByRoundsPerMinute));
            PlayGame(cars.ElementAt(0), cars.ElementAt(1), (car, other) => car.CompareToByRoundsPerMinute(other));
        }

        private static void TestCompareToByEngineSize(IEnumerable<Car> cars)
        {
            Console.WriteLine(nameof(TestCompareToByEngineSize));
            PlayGame(cars.ElementAt(0), cars.ElementAt(1), (car, other) => car.CompareToByEngineSize(other));
        }

        private static void TestCompareToByAcceleration(IEnumerable<Car> cars)
        {
            Console.WriteLine(nameof(TestCompareToByHorsePower));
            PlayGame(cars.ElementAt(0), cars.ElementAt(1), (car, other) => car.CompareToByAcceleration(other));
        }

        private static void TestCompareToByCylinders(IEnumerable<Car> cars)
        {
            Console.WriteLine(nameof(TestCompareToByCylinders));
            PlayGame(cars.ElementAt(0), cars.ElementAt(1), (car, other) => car.CompareToByCylinders(other));
        }

        private static void TestFindCarsByMaxSpeed(IEnumerable<Car> cars)
        {
            var hand = new Hand
            {
                Cars = cars
            };
            Console.WriteLine($"{nameof(TestFindCarsByMaxSpeed)} above 201 km/h");
            IEnumerable<Car> matchingCars = hand.FindCarsByMaxSpeed(201);
            matchingCars.PrintAll();

            Console.WriteLine($"{nameof(TestFindCarsByMaxSpeed)} above 250 km/h");
            matchingCars = hand.FindCarsByMaxSpeed(250);
            matchingCars.PrintAll();
        }

        private static void PlayGame(Car c1, Car c2, Func<Car, Car, int> compareCars)
        {
            int comparisonResult = compareCars(c1, c2);
            if (comparisonResult == -1)
            {
                Console.WriteLine($"{c2.Model} beats {c1.Model}\n");
            }
            else if (comparisonResult == 1)
            {
                Console.WriteLine($"{c1.Model} beats {c2.Model}\n");
            }
            else
            {
                Console.WriteLine($"Draw between {c1.Model} and {c2.Model}\n");
            }
        }

    }
}