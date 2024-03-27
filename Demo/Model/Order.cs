using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Collections.Generic;

namespace Demo
{
    public class Order
    {
        public int OrderId { get; }
        public DateTime OrderTime { get; }
        public List<string> Items { get; } // Список блюд в заказе
        public OrderStatus Status { get; set; }

        public Order(int orderId, DateTime orderTime, List<string> items)
        {
            OrderId = orderId;
            OrderTime = orderTime;
            Items = items;
            Status = OrderStatus.Pending; // Изначально статус заказа - ожидание
        }

        // Метод для добавления блюда в заказ
        public void AddItem(string item)
        {
            Items.Add(item);
        }

        // Метод для изменения статуса заказа
        public void UpdateStatus(OrderStatus newStatus)
        {
            Status = newStatus;
        }
    }

    // Перечисление для статусов заказа
    public enum OrderStatus
    {
        Pending, // Ожидание
        InProgress, // В процессе приготовления
        Ready, // Готов
        Completed // Завершен
    }
}

