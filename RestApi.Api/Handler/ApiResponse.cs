using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Threading.Tasks;

namespace RestApi.Api.Handler
{
    public class ApiResponse<T>
    {
        public bool Success { get; set; }
        public HttpStatusCode Status { get; set; }
        public string Message { get; set; }
        public T Result { get; set; }

        public ApiResponse(bool success, HttpStatusCode status, string message, T result)
        {
            Success = success;
            Status = status;
            Message = message;
            Result = result;
        }
    }

    public class ApiResponseInsertData
    {
        public HttpStatusCode StatusCode {get; set;}
        public string Status { get; set; }
        public string SalesOrderNo { get; set; }
        public string Message { get; set; }
    }

    public class ApiResponseFailed
    {
        public string Status { get; set; }
        public string Message { get; set; }
    }
}