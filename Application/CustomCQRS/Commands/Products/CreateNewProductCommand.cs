using Application.CustomCQRS.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;

namespace Application.CustomCQRS.Commands.Products
{
   public class CreateNewProductCommand:ICommand
    {
        public string Name { get; set; }
        public decimal Price { get; set; }

        public CreateNewProductCommand(string name, decimal price)
        {
            Name = name;
            Price = price;
        }
    }
}
