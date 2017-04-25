using System;

namespace Chayns.Backend.Extensions.Models
{
    public class Error
    {
        public Error()
        {
            Guid = Guid.NewGuid();
        }

        public string Message { get; set; }
        public int Code { get; set; }
        public Guid Guid { get; set; }
        public object Details { get; set; }
    }
}
