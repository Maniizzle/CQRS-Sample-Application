using Application.CustomCQRS.Interfaces;
using Application.CustomCQRS.Models;
using Application.CustomCQRS.Queries.Products;
using Application.Domain.Entities;
using Application.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Application.CustomCQRS.Handlers.Products
{
  public  class GetProductListCustomQueryHandler : IQueryHandler<GetProductListCustomQuery, Result<List<Product>>>
    {
        private readonly IDataAccess<Product> dataAccess;

        public GetProductListCustomQueryHandler(IDataAccess<Product> dataAccess)
        {
            this.dataAccess = dataAccess;
        }
        

        async Task<Result<List<Product>>> IQueryHandler<GetProductListCustomQuery, Result<List<Product>>>.Handle(GetProductListCustomQuery query)
        {
          var ans=  await dataAccess.GetAll();
            return Result.Ok(ans);
        }
    }
}
