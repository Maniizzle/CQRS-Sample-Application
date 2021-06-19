using Application.Domain.Entities;
using MediatR;
using System;
using System.Collections.Generic;
using System.Text;

namespace Application.Queries
{
  public  class GetProductByIdQuery:IRequest<Product>
    {
        public GetProductByIdQuery(int id)
        {
            Id = id;
        }

        public int Id { get; }
    }
}
