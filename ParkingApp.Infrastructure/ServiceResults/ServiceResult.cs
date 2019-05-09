using System;
using System.Collections.Generic;
using System.Text;

namespace ParkingApp.Infrastructure.ServicesResults
{
    public class ServiceResult
    {
        public bool IsSuccessful { get; set; }
        public string Message { get; set; }
    }

    public class ServiceResult<T> : ServiceResult
    {
        public T Object { get; set; }
    }
}
