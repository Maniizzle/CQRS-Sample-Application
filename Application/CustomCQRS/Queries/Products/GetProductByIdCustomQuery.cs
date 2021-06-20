using Application.CustomCQRS.Interfaces;
using Application.CustomCQRS.Models;
using Application.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace Application.CustomCQRS.Queries.Products
{
   public class GetProductByIdCustomQuery:IQuery<Result<Product>>
    {
        public GetProductByIdCustomQuery(int id)
        {
            Id = id;
        }

        public int Id { get; }
    }
}
