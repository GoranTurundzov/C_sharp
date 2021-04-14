using System;

namespace Models
{
    public class Character
    {

        public string CharName { get; set; }

        private double Health { get; set; }

        private int Strength { get; set; }

        private int Agility { get; set; }

        private Class Class { get; set; }

        public string Race { get; set; }
        public Character()
        {

        }

        public Character(string charName , double health , int strength , int agility , Class charClass , string race)
        {
            CharName = charName;
            Health = health;
            Strength = strength;
            Agility = agility;
            Class = charClass;
            Race = race;
            switch (charClass)
            {
                case Class.Warrior:
                    Health += 20;
                    Agility -= 1;
                    break;
                case Class.Rogue:
                    Health -= 20;
                    Agility += 1;
                    break;
                case Class.Mage:
                    Health += 20;
                    Strength -= 1;
                    break;  
            }
           
        }
        public string GetInfo()
        {
            return $"{CharName} ({Race}) the {Class} \n Health: {Health}  \n Strength: {Strength}  \n  Agility: {Agility}";
        }

        public int GetStrenght()
        {
            return Strength;
        }

        public int GetAgility()
        {
            return Agility;
        }
        public void SetHealth(int num)
        {
            Health += num;
        }
        public double GetHealth()
        {
            return Health;
        }
    }
}
