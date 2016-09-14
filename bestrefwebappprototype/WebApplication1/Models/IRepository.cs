using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WebApplication1.Models
{
    interface IRepository
    {
        IEnumerable<Object> GetAll(string table_name);
        Object Get(int id, string table_name);
        Task<Object> Add(Object item);
        void Remove(int id, string table_name);
        Task<bool> Update(Object item, int id);
    }
}
