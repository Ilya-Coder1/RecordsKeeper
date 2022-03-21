using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace lab3
{
    /// <summary>
    /// Интерфейс для реализации хранилища записей.
    /// </summary>
    public interface IDataSource
    {
        /// <summary>
        /// Сохранение записи в хранилище.
        /// </summary>
        /// <param name="order">Добавляемая или обновляемая запись</param>
        /// <returns>Запись из хранилища с id</returns>
        DeliveryOrder Save(DeliveryOrder order);

        /// <summary>
        /// Возвращает одну запись из хранилища по id
        /// </summary>
        /// <param name="id">id записи</param>
        /// <returns>Найденная запись или null</returns>
        DeliveryOrder Get(int id);

        /// <summary>
        /// Удаляет запись из хранилища по id.
        /// </summary>
        /// <param name="id">id записи</param>
        /// <returns>true, если запись успешно удалена</returns>
        bool Delete(int id);

        /// <summary>
        /// Возвращает все записи из хранилища.
        /// </summary>
        /// <returns>Список всех записей</returns>
        List<DeliveryOrder> GetAll();
    }
}
