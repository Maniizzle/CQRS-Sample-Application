using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Application.CustomCQRS.Interfaces
{
   public interface IQueryHandler<TQuery,TResult> where TQuery:IQuery<TResult>
    {
        Task<TResult> Handle(TQuery query);
    }
}
