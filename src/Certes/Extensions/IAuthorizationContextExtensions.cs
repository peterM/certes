using System.Linq;
using System.Threading.Tasks;
using Certes.Acme;
using Certes.Acme.Resource;

namespace Certes
{
    /// <summary>
    /// Extension methods for <see cref="IAuthorizationContext"/>.
    /// </summary>
    public static class IAuthorizationContextExtensions
    {
        /// <summary>
        /// Gets the HTTP challenge.
        /// </summary>
        /// <param name="authorizationContext">The authorization context.</param>
        /// <returns>The HTTP challenge, <c>null</c> if no HTTP challenge available.</returns>
        public static Task<IChallengeContext> HttpAsync(this IAuthorizationContext authorizationContext) =>
            authorizationContext.AllChallengesAsync(ChallengeTypes.Http01);

        /// <summary>
        /// Gets the DNS challenge.
        /// </summary>
        /// <param name="authorizationContext">The authorization context.</param>
        /// <returns>The DNS challenge, <c>null</c> if no DNS challenge available.</returns>
        public static Task<IChallengeContext> DnsAsync(this IAuthorizationContext authorizationContext) =>
            authorizationContext.AllChallengesAsync(ChallengeTypes.Dns01);

        /// <summary>
        /// Gets the TLS ALPN challenge.
        /// </summary>
        /// <param name="authorizationContext">The authorization context.</param>
        /// <returns>The TLS ALPN challenge, <c>null</c> if no TLS ALPN challenge available.</returns>
        public static Task<IChallengeContext> TlsAlpnAsync(this IAuthorizationContext authorizationContext) =>
            authorizationContext.AllChallengesAsync(ChallengeTypes.TlsAlpn01);

        /// <summary>
        /// Gets a challenge by type.
        /// </summary>
        /// <param name="authorizationContext">The authorization context.</param>
        /// <param name="type">The challenge type.</param>
        /// <returns>The challenge, <c>null</c> if no challenge found.</returns>
        public static async Task<IChallengeContext> AllChallengesAsync(this IAuthorizationContext authorizationContext, string type)
        {
            var challenges = await authorizationContext.GetChallengesAsync();
            return challenges.FirstOrDefault(c => c.Type == type);
        }
    }
}
