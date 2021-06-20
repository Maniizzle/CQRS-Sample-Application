using System;
using System.Collections.Generic;
using System.Text;

namespace Application.CustomCQRS.Models
{
   public class Result<T>:Result
    {
         public T Data { get; set; }
    }

    public class Result
    {
        public bool IsSuccess { get; set; }
        public string Error { get; set; }
    
    public static Result Fail(string message)
        {
            return new Result { IsSuccess = false, Error = message };
        }

        public static Result<T> Ok<T>(T value)
        {
            return new Result<T> { IsSuccess = true, Data=value };
        }
    }
}
