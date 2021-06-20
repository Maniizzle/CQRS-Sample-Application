using Application.CustomCQRS;
using Application.CustomCQRS.Commands.Products;
using Application.CustomCQRS.Queries.Products;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace API.Controllers
{
    public class CustomCQRSProductController:ControllerBase
    {
        private readonly Messages messages;

        public CustomCQRSProductController(Messages messages)
        {
            this.messages = messages;
        }
        [HttpGet]
        public async Task<IActionResult> GetProducts()
        {
            var result = await messages.Send(new GetProductListCustomQuery());
            return result.IsSuccess ? Ok(result.Data) : BadRequest(result.Error);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetProduct(int id)
        {
            var result = await messages.Send(new GetProductByIdCustomQuery(id));
            return result.IsSuccess ? Ok(result.Data) : BadRequest(result.Error);
        }

        [HttpPost]
        public async Task<IActionResult> CreateProduct([FromBody] CreateNewProductCommand value)
        {
            var result = await messages.Send(new CreateNewProductCommand(value.Name, value.Price));
            return result.IsSuccess ? Ok(result) : BadRequest(result.Error);

        }

    }
}
