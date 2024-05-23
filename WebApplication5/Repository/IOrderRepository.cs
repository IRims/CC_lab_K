using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WebApplication5.Models;

namespace WebApplication5.Repository
{
    public interface IOrderRepository
    {
        IEnumerable<Order> GetAll();
        Order Get(int id);
        Order Add(Order item);
        void Remove(int id);
        bool Update(Order item);
    }

}
