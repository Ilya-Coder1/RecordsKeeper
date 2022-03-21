using System;

namespace lab3
{
    public abstract class DeliveryOrder : ICloneable
    {
        public int id = 0;

        private string clientName;
        public string ClientName { get { return clientName; } } 

        private DateTime date;
        public DateTime Date { get { return date; } }

        private string productName;
        public string ProductName { get { return productName; } }

        private int count;
        public int Count { get { return count; } }

        public DeliveryOrder(string clientName, string date, string productName, int count)
        {
            this.clientName = clientName;
            this.productName = productName;
            this.count = count;

            if (!DateTime.TryParseExact(date, "yy-MM-dd",
                null, System.Globalization.DateTimeStyles.None, out this.date)
                ) throw new ArgumentException("Некорректный формат даты");
            if (count <= 0) throw new ArgumentException("Количество товаров должно быть больше 1");
        }

        public DeliveryOrder(string clientName, DateTime date, string productName, int count)
        {
            this.clientName = clientName;
            this.productName = productName;
            this.count = count;
            this.date = date;
        }

        public abstract object Clone();

        public override string ToString()
        {
            return $"{clientName} {date.ToString("yy-MM-dd")} {productName} кол-во: {count}";
        }
    }
}
