using Application.Domain.Entities;
using MediatR;
using System;
using System.Collections.Generic;
using System.Text;

namespace Application.Queries
{
   public class GetProductListQuery:IRequest<List<Product>>
    {
    }
}
