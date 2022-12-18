using System;
using System.Collections.Generic;
using Newtonsoft.Json;
namespace AppointmentSystem.Business
{
    [Serializable]
    public class ServiceResponse<T>
    {
        public bool HasExceptionError { get; set; }

        [JsonProperty(NullValueHandling = NullValueHandling.Ignore)]
        public string ExceptionMessage { get; set; }

        public IList<T> List { get; set; }

        [JsonProperty]
        public T Entity { get; set; }

        public int Count { get; set; }

        public bool IsSuccessful { get; set; }

        public ServiceResponse()
        {
            List = new List<T>();
        }
    }
    public class PaginedResponse<T> : ServiceResponse<T>
    {
        public int CurrentPage { get; set; }
        public int TotalPages { get; set; }
        public int TotalCount { get; set; }
    }
}

