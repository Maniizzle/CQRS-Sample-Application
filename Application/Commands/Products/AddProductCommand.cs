using Application.Domain.Entities;
using MediatR;
using System;
using System.Collections.Generic;
using System.Text;

namespace Application.Commands.Products
{
   public class AddProductCommand:IRequest<Product>
    {
        public string Name { get; set; }
        public decimal Price { get; set; }

        public AddProductCommand(string name,decimal price)
        {
            Name = name;
            Price = price;
        }
    }
}
