using Application.Commands.Products;
using Application.Domain.Entities;
using Application.Interfaces;
using MediatR;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Application.Handlers.Products
{
   public class AddProductCommandHandler : IRequestHandler<AddProductCommand, Product>
    {
        private readonly Interfaces.IDataAccess<Product> dataAccess;

        public AddProductCommandHandler(IDataAccess<Product> dataAccess)
        {
            this.dataAccess = dataAccess;
        }

        public async Task<Product> Handle(AddProductCommand request, CancellationToken cancellationToken)
        {
           return await dataAccess.Add(new Product { Name = request.Name, Price = request.Price });
        }
    }
}
