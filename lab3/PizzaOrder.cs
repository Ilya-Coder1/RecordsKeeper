using System;

namespace lab3
{
    public class PizzaOrder : DeliveryOrder
    {
        private string pizzaType;
        public string PizzaType { get { return pizzaType; } }

        private int size;
        public int Size { get { return size; } }

        public PizzaOrder(string clientName, string date, int count, string pizzaType, int size)
            : base(clientName, date, "Пицца", count)
        {
            this.pizzaType = pizzaType;
            this.size = size;
        }

        public PizzaOrder(string clientName, DateTime date, int count, string pizzaType, int size)
            : base(clientName, date, "Пицца", count)
        {
            this.pizzaType = pizzaType;
            this.size = size;
        }


        public override string ToString()
        {
            return base.ToString() + $" Вид: {pizzaType} {size} см.";
        }

        override public object Clone()
        {
            return this.MemberwiseClone();
        }
    }
}
