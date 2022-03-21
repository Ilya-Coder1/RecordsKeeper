using System;
using System.Collections.Generic;
using System.Linq;
using System.IO;

namespace lab3
{
    public class BusinessLogic
    {
        private IDataSource dataSource;

        public BusinessLogic(IDataSource source)
        {
            dataSource = source;
        }

        public List<DeliveryOrder> GetList()
        {
            var list = dataSource.GetAll();

            return list.OrderByDescending(x => x.Date).ThenBy(x => x.ClientName).ToList();
        }

        public DeliveryOrder AddRecord(DeliveryOrder order)
        {
            return dataSource.Save(order);
        }

        public bool DeleteRecord(DeliveryOrder order)
        {
            return dataSource.Delete(order.id);
        }

        public DeliveryOrder? GetRecord(int id)
        {
            var record = dataSource.Get(id);
            if (record == null)
                throw new ArgumentException("Такой записи не существует");
            return record;
        }

        public void GenerateReport(DateTime startDate, DateTime endDate, string path)
        {

            var pizzaCount = 0;
            var drinksCout = 0;

            Dictionary<string, int> countOfPizzaKinds = new Dictionary<string, int>();
            Dictionary<string, int> countOfDrinkKinds = new Dictionary<string, int>();


            if(!File.Exists(path))
                File.Create(path).Dispose();

            var orders = GetList();

            foreach (var order in orders)
            {
                if (order.Date >= startDate && order.Date <= endDate)
                {
                    if (order is PizzaOrder)
                    {
                        pizzaCount += order.Count;
                        var pizzaOrder = (PizzaOrder)order;
                        if (!countOfPizzaKinds.TryAdd(pizzaOrder.PizzaType.ToLower(), order.Count))
                            countOfPizzaKinds[pizzaOrder.PizzaType.ToLower()] += order.Count;
                    }
                    else if (order is DrinkOrder)
                    {
                        drinksCout += order.Count;
                        var drinkOrder = (DrinkOrder)order;
                        if(!countOfDrinkKinds.TryAdd(drinkOrder.DrinkType.ToLower(), order.Count))
                            countOfDrinkKinds[drinkOrder.DrinkType.ToLower()] += order.Count;
                    }
                }
            }

            using (FileStream file = new FileStream(path, FileMode.Truncate, FileAccess.Write))
            using (StreamWriter writer = new StreamWriter(file))
            {
                writer.WriteLine("***Отчет***\n\n");
                writer.WriteLine($"Всего заказано товаров с {startDate.ToString("yy-MM-dd")} по {endDate.ToString("yy-MM-dd")}:");
                if (pizzaCount > 0)
                {
                    writer.WriteLine($"Пицца : {pizzaCount} шт.");
                    writer.WriteLine("Среди них:");
                    foreach (var kvp in countOfPizzaKinds)
                    {
                        writer.WriteLine($"{kvp.Key} : {kvp.Value} шт.");
                    }
                    writer.WriteLine();
                }

                if (drinksCout > 0)
                {
                    writer.WriteLine($"Напитки : {drinksCout} шт.");
                    writer.WriteLine("Среди них:");
                    foreach (var kvp in countOfDrinkKinds)
                    {
                        writer.WriteLine($"{kvp.Key} : {kvp.Value} шт.");
                    }
                    writer.WriteLine();
                }
            }
        }
    }
}
