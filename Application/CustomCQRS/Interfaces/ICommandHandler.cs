using Application.CustomCQRS.Models;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Application.CustomCQRS.Interfaces
{
  public  interface ICommandHandler<TCommand> where TCommand : ICommand
    {

        Task<Result> Handle(TCommand command);
    }
    
}
