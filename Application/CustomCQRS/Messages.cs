using Application.CustomCQRS.Interfaces;
using Application.CustomCQRS.Models;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Application.CustomCQRS
{
   public class Messages
    {
        private readonly IServiceProvider provider;

        public Messages(IServiceProvider provider)
        {
            this.provider = provider;
        }

        public async Task<Result> Send(ICommand command)
        {
            Type type = typeof(IQueryHandler<>);
            Type[] typeArgs = { command.GetType() };
            Type handlerType = type.MakeGenericType(typeArgs);

            //dynamic instead using reflection to get the handler
            dynamic handler = provider.GetService(handlerType);
            Result result =await handler.Handle((dynamic)command);
            return result;

        }

        public async Task<T> Send<T>(IQuery<T> command)
        {
            Type type = typeof(IQueryHandler<,>);
            Type[] typeArgs = { command.GetType(),typeof(T) };
            Type handlerType = type.MakeGenericType(typeArgs);

            //dynamic instead of using reflection to get the handler
            dynamic handler = provider.GetService(handlerType);
            T result = await handler.Handle((dynamic)command);
            return result;

        }

    }
}
