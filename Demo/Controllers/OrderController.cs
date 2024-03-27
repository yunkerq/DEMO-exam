using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Demo
{
    public class OrderController
    {
        private List<Order> orders;
        public OrderController()
        {
            // Инициализируем список заказов
            orders = new List<Order>();
        }

        // Метод для создания нового заказа
        public void CreateOrder(List<string> items)
        {
            int orderId = orders.Count + 1; // Генерируем новый идентификатор заказа
            DateTime orderTime = DateTime.Now; // Получаем текущее время

            Order newOrder = new Order(orderId, orderTime, items);
            orders.Add(newOrder);
        }

        // Метод для получения списка всех заказов
        public List<Order> GetAllOrders()
        {
            return orders;
        }

        // Метод для получения списка заказов определенного статуса
        public List<Order> GetOrdersByStatus(OrderStatus status)
        {
            return orders.Where(order => order.Status == status).ToList();
        }

        // Метод для обновления статуса заказа
        public void UpdateOrderStatus(int orderId, OrderStatus newStatus)
        {
            Order orderToUpdate = orders.FirstOrDefault(order => order.OrderId == orderId);

            if (orderToUpdate != null)
            {
                orderToUpdate.UpdateStatus(newStatus);
            }
            else
            {
                throw new InvalidOperationException("Заказ с указанным идентификатором не найден");
            }
        }
    }
}
