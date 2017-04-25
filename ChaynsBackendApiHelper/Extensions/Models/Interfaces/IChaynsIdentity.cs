using System.Security.Principal;
using Chayns.Backend.Api.Models.Result;

namespace Chayns.Backend.Extensions.Models.Interfaces
{
    public interface IChaynsIdentity : IIdentity
    {
        UserAccessTokenInfoResult ChaynsLogin { get; }

        string AccessToken { get; }
    }
}
