using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cars.classes
{
    public class Car
    {
        public string Model { set; get; }

        public Driver Driver { set; get; }

        public int Speed { set; get; }

        public Car(string model , int speed  )
        {
            Model = model;
            Speed = speed;
           
        }
        public void SetDriver(Driver driver)
        {
            Driver = driver;
        }

        public int CalculateSpeed()
        {
            return Speed * Driver.Skill;
        }

    }
}
