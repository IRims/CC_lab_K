using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using WebApplication5.Models;

namespace WebApplication5.Repository
{
    public class OrderRepository : IOrderRepository
    {
        private List<Order> _orders = new List<Order>();
        private int _nextId = 1;

        public OrderRepository()
        {
            //initial data 
            Add(new Order { CusName = "Zain", Laptop = 1, LCD = 3, Phone = 1 });
            Add(new Order { CusName = "Hamza", Laptop = 2, LCD = 1, Phone = 2 });
        }

        public IEnumerable<Order> GetAll()
        {
            return _orders;
        }

        public Order Get(int id)
        {
            return _orders.Find(o => o.OrdId == id);
        }

        public Order Add(Order item)
        {
            if (item == null)
            {
                throw new ArgumentNullException("item");
            }
            item.OrdId = _nextId++;
            _orders.Add(item);
            return item;
        }

        public void Remove(int id)
        {
            _orders.RemoveAll(o => o.OrdId == id);
        }

        public bool Update(Order item)
        {
            if (item == null)
            {
                throw new ArgumentNullException("item");
            }
            int index = _orders.FindIndex(o => o.OrdId == item.OrdId);
            if (index == -1)
            {
                return false;
            }
            _orders.RemoveAt(index);
            _orders.Add(item);
            return true;
        }
    }



}

