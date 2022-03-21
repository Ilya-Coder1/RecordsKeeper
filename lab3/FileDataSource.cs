using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace lab3
{
    internal class FileDataSource : IDataSource
    {
        private UTF8Encoding utf8 = new UTF8Encoding(); 

        private string signature = "aleksand";

        private const int stringLength = 100;

        private const int recordLength = 222;

        private string path;

        private int lastId = 0;

        public FileDataSource(string fileName)
        {
            path = fileName;

            using (FileStream file = new FileStream(path, FileMode.OpenOrCreate))
            {
                if(file.Length == 0)
                {
                    using (BinaryWriter writer = new BinaryWriter(file))
                    {
                        writer.Write(utf8.GetBytes(signature));
                    }
                }
                else
                {
                    using (BinaryReader reader = new BinaryReader(file))
                    {
                        if (!utf8.GetString(reader.ReadBytes(signature.Length)).Equals(signature))
                            throw new Exception("Выбран неправильный файл");
                        lastId = (int)file.Length / recordLength;
                    }
                } 
            }
        }

        private byte[] StringToArray(string str)
        {
            byte[] arr = new byte[stringLength];
            utf8.GetBytes(str, arr);
            return arr;
        }

        private bool TryFind(int id, out int position)
        {
            position = -1;

            using (FileStream file = new FileStream(path,FileMode.Open, FileAccess.Read))
            using(BinaryReader reader = new BinaryReader(file))
            {
                int left = 0;
                int right = ((int)file.Length - signature.Length) / recordLength;

                while (left <= right)
                {
                    var mid = (left + right) / 2;
                    file.Seek(signature.Length + mid * recordLength, SeekOrigin.Begin);
                    bool isDeleted = reader.ReadBoolean();
                    int currentId = reader.ReadInt32();
                    if (id == currentId)
                    {
                        if(!isDeleted)
                        {
                            position = mid * recordLength + signature.Length;
                            return true;
                        }
                        else return false;
                    }
                    else if(id < currentId)
                        right = mid - 1;
                    else
                        left = mid + 1;
                }
            }
            return false;
        }

        public bool Delete(int id)
        {
            if (!TryFind(id, out int position))
                return false;


            using (FileStream file = new FileStream(path, FileMode.Open, FileAccess.ReadWrite))
            using (BinaryWriter writer = new BinaryWriter(file))
            using (BinaryReader reader = new BinaryReader(file))
            {
                file.Seek(position, SeekOrigin.Begin);
                if (reader.ReadBoolean())
                    return false;

                file.Seek(-1, SeekOrigin.Current);
                writer.Write(true);
            }
            return true;
        }

        public DeliveryOrder Get(int id)
        {
            DeliveryOrder order = null;

            if (!TryFind(id, out int position))
                return null;

            using (FileStream file = new FileStream(path, FileMode.Open, FileAccess.Read))
            using (BinaryReader reader = new BinaryReader(file))
            {
                file.Seek(position, SeekOrigin.Begin);
                
                var isDeleted = reader.ReadBoolean();
                if (isDeleted)
                    return null;

                reader.ReadInt32();

                string clientName = utf8.GetString(reader.ReadBytes(stringLength)).Replace("\0", "");
                long encDate = reader.ReadInt64();
                DateTime date = DateTime.FromBinary(encDate);
                int count = reader.ReadInt32();
                byte type = reader.ReadByte();

                if (type == 1)
                {
                    string pizzaType = utf8.GetString(reader.ReadBytes(stringLength)).Replace("\0", "");
                    int size = reader.ReadInt32();
                    order =  new PizzaOrder(clientName, date, count, pizzaType, size);
                }
                else if (type == 2)
                {
                    string drinkType = utf8.GetString(reader.ReadBytes(stringLength)).Replace("\0", "");
                    float volume = reader.ReadSingle();
                    order =  new DrinkOrder(clientName, date, count, drinkType, volume);
                }
            }
            order.id = id;
            return order;
        }

        public List<DeliveryOrder> GetAll()
        {
            var list = new List<DeliveryOrder>();
            
            using (FileStream file = new FileStream(path, FileMode.Open, FileAccess.Read))
            using (BinaryReader reader = new BinaryReader(file))
            {
                file.Seek(signature.Length, SeekOrigin.Begin);

                while (reader.PeekChar() != -1)
                {
                    var isDeleted = reader.ReadBoolean();
                    if (isDeleted)
                    {
                        file.Seek(recordLength - 1, SeekOrigin.Current);
                        continue;
                    }

                    DeliveryOrder order = null;
                    int id = reader.ReadInt32();
                    string clientName = utf8.GetString(reader.ReadBytes(stringLength)).Replace("\0", "");
                    long encDate = reader.ReadInt64();
                    DateTime date = DateTime.FromBinary(encDate);
                    int count = reader.ReadInt32();
                    byte type = reader.ReadByte();

                    if (type == 1)
                    {
                        string pizzaType = utf8.GetString(reader.ReadBytes(stringLength)).Replace("\0", "");
                        int size = reader.ReadInt32();
                        order = new PizzaOrder(clientName, date, count, pizzaType, size);
                    }
                    else if (type == 2)
                    {
                        string drinkType = utf8.GetString(reader.ReadBytes(stringLength)).Replace("\0", "");
                        float volume = reader.ReadSingle();
                        order = new DrinkOrder(clientName, date, count, drinkType, volume);
                    }
                    order.id = id;
                    list.Add(order);
                }

                return list;
            }
        }
        
        public DeliveryOrder Save(DeliveryOrder order)
        {
            bool isExist = false;
            int position = 0;

            if (order.id == 0)
            {
                order.id = ++lastId;
            }
            else
            {
                if (!TryFind(order.id, out position))
                    throw new Exception("Записи не существует");
                isExist = true;
            }

            using (FileStream file = new FileStream(path, FileMode.Open))
            using (BinaryWriter writer = new BinaryWriter(file))
            {
                if (!isExist)
                    position = (int)file.Length;

                writer.Seek(position, SeekOrigin.Begin);

                writer.Write(false);
                writer.Write(order.id);
                writer.Write(StringToArray(order.ClientName));
                writer.Write(order.Date.ToBinary());
                writer.Write(order.Count);

                if (order is PizzaOrder)
                {
                    writer.Write((byte)1);
                    writer.Write(StringToArray(((PizzaOrder)order).PizzaType));
                    writer.Write(((PizzaOrder)order).Size);
                }
                else if(order is DrinkOrder)
                {
                    writer.Write((byte)2);
                    writer.Write(StringToArray(((DrinkOrder)order).DrinkType));
                    writer.Write(((DrinkOrder)order).Volume);
                }

                
            }
            return order;
        }
    }
}
