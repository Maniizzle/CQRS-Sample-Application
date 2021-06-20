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
    public class GetProductByIdCustomQueryHandler : IQueryHandler<GetProductByIdCustomQuery, Result<Product>>
    {
        private readonly IDataAccess<Product> dataAccess;

        public GetProductByIdCustomQueryHandler(IDataAccess<Product> dataAccess)
        {
            this.dataAccess = dataAccess;
        }
        public async Task<Result<Product>> Handle(GetProductByIdCustomQuery query)
        {
          var ans= await  dataAccess.Get(query.Id);
           return Result.Ok(ans);
        }
    }
}
