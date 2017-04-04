using Chayns.Backend.Api.Models.Result.Base;

namespace Chayns.Backend.Api.Models.Result
{
    /// <summary>
    /// Standard result if the controller function can only return one value
    /// </summary>
    /// <typeparam name="TEntity">Entitytype of the result</typeparam>
    public class SingleResult<TEntity> where TEntity : IApiResult
    {
        /// <summary>
        /// Result for the called controller function
        /// </summary>
        public TEntity Data { get; set; }
        /// <summary>
        /// Status wheter the call was successfull or not
        /// </summary>
        public Status Status { get; set; }

        /// <summary>
        /// Converter to cast a result object to a single result
        /// </summary>
        /// <param name="result"></param>
        public static implicit operator SingleResult<TEntity>(Result<TEntity> result) 
        {
            return new SingleResult<TEntity>
            {
                Data = (result?.Data == null || result.Data.Count == 0) ? default(TEntity) : result.Data[0],
                Status = result?.Status
            };
        }
    }
}
