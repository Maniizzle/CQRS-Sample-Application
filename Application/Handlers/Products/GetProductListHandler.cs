using Application.Domain.Entities;
using Application.Interfaces;
using Application.Queries;
using MediatR;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Application.Handlers.Products
{
   public class GetProductListHandler : IRequestHandler<GetProductListQuery,List<Product>>
    {
        private readonly Interfaces.IDataAccess<Product> dataAccess;

        public GetProductListHandler(IDataAccess<Product> dataAccess)
        {
            this.dataAccess = dataAccess;
        }

       async Task<List<Product>> IRequestHandler<GetProductListQuery, List<Product>>.Handle(GetProductListQuery request, CancellationToken cancellationToken)
        {
          return  await dataAccess.GetAll();
        }
    }
}
