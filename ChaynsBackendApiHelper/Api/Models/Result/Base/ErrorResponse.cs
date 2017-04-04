using System;

namespace Chayns.Backend.Api.Models.Result.Base
{
    /// <summary>
    /// Used to serialize error response from BackendApi
    /// </summary>
    public class ErrorResponse
    {
        public string Message { get; set; }
        public Guid ErrorGuid { get; set; }
    }
}
