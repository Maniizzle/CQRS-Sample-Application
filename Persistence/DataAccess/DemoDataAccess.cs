using Application.Domain.Entities;
using Application.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Persistence.DataAccess
{
    public class DemoDataAccess : IDataAccess<Product>
    {
        public List<Product> Products { get; set; }

        public DemoDataAccess()
        {
            Products = new List<Product> {
            new Product { Id=1, Name="Garri", Price=300},
            new Product { Id=2, Name="Bag", Price=5000},
            new Product { Id=3, Name="Shoe", Price=15000}
            };
        }
            
        public Task<Product> Add(Product product)
        {
            var newProduct = new Product { Price = product.Price, Name = product.Name, Id = new Random().Next(10,455) };
            Products.Add(newProduct);
            return Task.FromResult(newProduct);
        }

        public Task<Product> Get(int id)
        {
          var product=  Products.FirstOrDefault(c => c.Id == id);
            return Task.FromResult(product);
        }

        public Task<List<Product>> GetAll()
        {
            return Task.FromResult(Products);
        }

       
    }
}
