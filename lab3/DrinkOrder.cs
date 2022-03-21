using System;

namespace lab3
{
    public class DrinkOrder : DeliveryOrder
    {
        private string drinkType;
        public string DrinkType { get { return drinkType; } }
        
        private float volume;
        public float Volume { get { return volume; } }

        public DrinkOrder(string clientName, string date, int count, string drinkType, float volume)
            : base(clientName, date, "Напиток", count)
        {
            this.drinkType = drinkType;
            this.volume = volume;
        }

        public DrinkOrder(string clientName, DateTime date, int count, string drinkType, float volume)
            : base(clientName, date, "Напиток", count)
        {
            this.drinkType = drinkType;
            this.volume = volume;
        }

        public override string ToString()
        {
            return base.ToString() + $" Вид: {drinkType} {volume} л.";
        }

        override public object Clone()
        {
            return this.MemberwiseClone();
        }
    }
}
