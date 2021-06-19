using Application.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Application.Interfaces
{
   public interface IDataAccess<T> where T : class
    {
       Task<List<T>> GetAll();
       Task<T> Get(int id);
       Task<T> Add(T value);
    }
}
