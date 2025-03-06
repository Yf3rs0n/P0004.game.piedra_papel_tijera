using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Game.Application.Common
{
    public class ApiResponse<T>
    {
        public string Message { get; set; }
        public bool Success { get; set; }
        public T Data { get; set; }

        public ApiResponse(string message, bool success, T data)
        {
            Message = message;
            Success = success;
            Data = data;
        }
    }
}
