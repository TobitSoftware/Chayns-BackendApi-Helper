using System;

namespace Chayns.Backend.Api.Models.Result
{
    /// <summary>
    /// Decribes wheter the controller call was successfull or not
    /// </summary>
    public class Status
    {
        /// <summary>
        /// Creates object with given status code from call
        /// </summary>
        /// <param name="statusCode">Status code from call (200 = OK)</param>
        public Status(int statusCode) : this(statusCode, Guid.Empty, "") { }

        /// <summary>
        /// Creates object with given status code from call
        /// </summary>
        /// <param name="statusCode">Status code from call (200 = OK)</param>
        /// <param name="errorGuid">Error guid from call if not successfull</param>
        /// <param name="message">Error message from call if not successfull</param>
        public Status(int statusCode, Guid errorGuid, string message)
        {
            Success = statusCode >= 200 && statusCode < 300;
            StatusCode = statusCode;
            Message = message;
            ErrorGuid = errorGuid;
        }

        public bool Success { get; }
        /// <summary>
        /// Status given from the controller call (HttpStatusCode; 200 = OK)
        /// </summary>
        public int StatusCode { get; }
        /// <summary>
        /// >Error message from call if not successfull
        /// </summary>
        public string Message { get; }
        /// <summary>
        /// Error guid from call if not successfull
        /// </summary>
        public Guid ErrorGuid { get; }
    }
}
