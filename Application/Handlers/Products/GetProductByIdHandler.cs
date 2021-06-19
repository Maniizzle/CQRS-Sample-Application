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
    class GetProductByIdHandler : IRequestHandler<GetProductByIdQuery, Product>
    {

        private readonly Interfaces.IDataAccess<Product> dataAccess;

        public GetProductByIdHandler(IDataAccess<Product> dataAccess)
        {
            this.dataAccess = dataAccess;
        }

       
        public async Task<Product> Handle(GetProductByIdQuery request, CancellationToken cancellationToken)
        {
          return await  dataAccess.Get(request.Id);
        }
    }
}
