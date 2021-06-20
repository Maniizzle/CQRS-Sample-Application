using Application.CustomCQRS.Commands.Products;
using Application.CustomCQRS.Interfaces;
using Application.CustomCQRS.Models;
using Application.Domain.Entities;
using Application.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Application.CustomCQRS.Handlers.Products
{
   public sealed class CreateNewProductCommandHandler: ICommandHandler<CreateNewProductCommand>
    {
        private readonly IDataAccess<Product> dataAccess;

        public CreateNewProductCommandHandler(IDataAccess<Product> dataAccess)
        {
            this.dataAccess= dataAccess;
        }
        public async Task<Result> Handle(CreateNewProductCommand command)
        {
          var ans= await dataAccess.Add(new Product { Name = command.Name, Price = command.Price });
            return Result.Ok(ans);
        }

    }
}
