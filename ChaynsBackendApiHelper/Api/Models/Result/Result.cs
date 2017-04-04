using System.Collections.Generic;
using Chayns.Backend.Api.Models.Result.Base;

namespace Chayns.Backend.Api.Models.Result
{
    /// <summary>
    /// Standard result if the controller function can return more then one value
    /// </summary>
    /// <typeparam name="TEntity">Entitytype of the result</typeparam>
    public class Result<TEntity> where TEntity : IApiResult
    {
        /// <summary>
        /// List of results for the called controller function
        /// </summary>
        public List<TEntity> Data { get; set; }
        /// <summary>
        /// Status wheter the call was successfull or not
        /// </summary>
        public Status Status { get; set; }
    }
}
