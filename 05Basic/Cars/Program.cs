using System;
using Cars.classes;

namespace Cars
{
    class Program
    {
        static void Main(string[] args)
        {
            //Driver bob = new Driver("Bob", 7);
            //Driver jill = new Driver("Jill", 4);
            //Driver greg = new Driver("Greg", 9);
            //Driver anne = new Driver("Anne", 7);

            //Car hyundai = new Car("Hyundai", 75);
            //Car mazda = new Car("Mazda", 125);
            //Car ferrari = new Car("Ferrari", 450);
            //Car porche = new Car("Porche", 370);
            //hyundai.SetDriver(anne);
            //mazda.SetDriver(greg);
            Car[] cars = new Car[4]
            {
                new Car("Hyundai", 75),
                new Car("Mazda", 125),
                new Car("Ferrari", 450),
                new Car("Porche", 370)
        };
            Driver[] drivers = new Driver[4]
            {
                new Driver("Bob", 7),
                new Driver("Jill", 4),
                new Driver("Greg", 9),
                new Driver("Anne", 7)
        };

           
                Console.WriteLine("Pick First Car");
                int firstCarIndex = SelectCar(cars);
                Console.WriteLine("Pick Second Car");
                int secondCarIndex = SelectCar(cars);
                while(firstCarIndex == secondCarIndex)
                {
                    Console.WriteLine("You can't pick a same car twice");
                Console.WriteLine("Pick First Car");
                firstCarIndex = SelectCar(cars);
                Console.WriteLine("Pick Second Car");
                secondCarIndex = SelectCar(cars);

                }
                Console.WriteLine($"Pick Driver For the {cars[firstCarIndex].Model}");
                int firstDriverIndex = SelectDriver(drivers);

                Console.WriteLine($"Pick a Driver for the {cars[secondCarIndex].Model}");
                int secondDriverIndex = SelectDriver(drivers);

                while(firstDriverIndex == secondDriverIndex)
                {
                    Console.WriteLine("You cant pick the same driver twice");
                Console.WriteLine($"Pick Driver For the {cars[firstCarIndex]}");
                firstDriverIndex = SelectDriver(drivers);
                Console.WriteLine($"Pick a Driver for the {cars[secondCarIndex]}");
                secondDriverIndex = SelectDriver(drivers);

                }

                Car firstCar = cars[firstCarIndex];
                Driver firstDriver = drivers[firstDriverIndex];
                firstCar.SetDriver(firstDriver);

                Car secondCar = cars[secondCarIndex];
                Driver secondDriver = drivers[secondDriverIndex];
                secondCar.SetDriver(secondDriver);
                Console.WriteLine(RaceCars(firstCar, secondCar));
                
            
              

           

          

          

        }
        static string RaceCars(Car a, Car b)

        {
            Console.WriteLine($"Line 1:{a.Driver.Name} driving {a.Model}");
            Console.WriteLine($"Line 2:{b.Driver.Name} driving {b.Model}");
            if (a.CalculateSpeed() < b.CalculateSpeed())
            {
                return $"{b.Model} with driver {b.Driver.Name} is the faster car";
            }
            else if (a.CalculateSpeed() > b.CalculateSpeed())
            {
                return $"{a.Model} with driver {a.Driver.Name} is the faster car";
            }
            else
            {
                return $"The cars are equally fast";
            }
        }

        static int SelectCar(Car[] cars)
        {
            int selectedCar = 0;
            while (true)
            {
                for (int i = 0; i < cars.Length; i++)
                {
                    Console.WriteLine($"{i + 1}  {cars[i].Model}");
                }

                string selectedCarString = Console.ReadLine();
                bool success = int.TryParse(selectedCarString, out  selectedCar);
                if (!success || selectedCar > 4 || selectedCar < 1)
                {
                    Console.WriteLine("Wrong value selected");
                    continue;
                } else
                {
                    break;
                }

            } return selectedCar - 1;

        }

        static int SelectDriver(Driver[] drivers)
        {
            int selectedDriver = 0;
            while (true)
            {
                for (int i = 0; i < drivers.Length; i++)
                {
                    Console.WriteLine($"{i + 1}  {drivers[i].Name}");
                }

                string selectedCarString = Console.ReadLine();
                bool success = int.TryParse(selectedCarString, out selectedDriver);
                if (!success || selectedDriver > 4 || selectedDriver < 1)
                {
                    Console.WriteLine("Wrong value selected");
                    continue;
                }
                else { break; }

            }
            return selectedDriver - 1;
        }
    }
}