using Microsoft.Azure.Commands.StorageSync.Interop.Enums;
using Microsoft.Azure.Commands.StorageSync.Interop.Exceptions;
using Microsoft.Azure.Commands.StorageSync.Properties;
using Newtonsoft.Json;
using System;
using System.Text;

namespace Microsoft.Azure.Commands.StorageSync.Interop.ManagedIdentity
{

    public static class ServerManagedIdentityTokenHelper
    {
        private const string UserAssignedManagedIdentityResourceType = "Microsoft.ManagedIdentity/userAssignedIdentities";

        /// <summary>
        /// Gets the oid claim from the token payload
        /// </summary>
        /// <param name="token"> the access token </param>
        /// <returns> true, oid if successfully parsed, else return false, guid.empty </returns>
        public static Guid GetTokenOid(string token)
        {
            // try to deserialize the json string to aadtoken object
            var aadToken = TryGetAadTokenFromAccessTokenString(token);

            // parse the oid string to guid object
            return Guid.Parse(aadToken?.Oid);
        }

        /// <summary>
        /// Try to get the Managed Identity type based on the given token response.
        /// </summary>
        /// <param name="accessToken">access token</param>
        /// <returns>ManagedIdentityType enum, either SystemAssigned or UserAssigned</returns>
        /// <exception cref="ServerManagedIdentityTokenException"></exception>
        public static ManagedIdentityType GetTokenManagedIdentityType(string accessToken)
        {
            // if there is no resource id present, the error will bubble up from here
            string managedIdentityResourceID = TryParseMIResourceIDFromToken(accessToken);

            if (!string.IsNullOrEmpty(managedIdentityResourceID) &&
                managedIdentityResourceID.IndexOf(UserAssignedManagedIdentityResourceType, StringComparison.OrdinalIgnoreCase) >= 0)
            {
                return ManagedIdentityType.UserAssigned;
            }
            return ManagedIdentityType.SystemAssigned;
        }

        /// <summary>
        /// Checks fields of the MI token to ensure that there is a system-assigned identity.
        /// Throws errors if token does not contain a system-assigned identity, or is lacking an MI resource ID field.
        /// </summary>
        /// <param name="accessToken">access token as string</param>
        /// <exception cref="ServerManagedIdentityTokenException"></exception>
        public static void ValidateMIToken(string accessToken)
        {
            var managedIdentityType = ServerManagedIdentityTokenHelper.GetTokenManagedIdentityType(accessToken);

            if (managedIdentityType != ManagedIdentityType.SystemAssigned)
            {
                throw new ServerManagedIdentityTokenException(
                    ManagedIdentityErrorCodes.ServerManagedIdentitySystemIdentityNotFound,
                    StorageSyncResources.AgentMI_MissingSystemAssignedIdentityError,
                    null);
            }
        }

        /// <summary>
        /// Try to get the AadToken from an encoded JWT token string.
        /// </summary>
        /// <param name="accessToken">JWT token in string format</param>
        /// <returns>String of resource ID for the managed identity asociated with the token</returns>
        private static AadToken TryGetAadTokenFromAccessTokenString(string accessToken)
        {
            var payload = accessToken.Split('.')[1].Replace('-', '+').Replace('_', '/');

            // pad the payload to be base64 string
            while (payload.Length % 4 != 0)
            {
                payload += "=";
            }

            // convert the payload to a byte array
            var byteArr = Convert.FromBase64String(payload);

            // decodes bytes to utf8 string
            var jsonStr = Encoding.UTF8.GetString(byteArr);

            // try to deserialize the json string to aadtoken object
            var aadToken = JsonConvert.DeserializeObject<AadToken>(jsonStr);

            return aadToken;
        }

        /// <summary>
        /// Try to get the Managed Identity ResourceID from the "xms_mirid" claim in a token.
        /// </summary>
        /// <param name="accessToken">JWT token in string format</param>
        /// <returns>String of resource ID for the managed identity asociated with the token</returns>
        private static string TryParseMIResourceIDFromToken(string accessToken) => TryGetAadTokenFromAccessTokenString(accessToken)?.MIResourceId;
    }

    public class AadToken
    {
        [JsonProperty(PropertyName = ManagedIdentityClaimNames.Oid)]
        public string Oid { get; set; }

        [JsonProperty(PropertyName = ManagedIdentityClaimNames.ManagedIdentityResourceId)]
        public string MIResourceId { get; set; }
    }

    public static class ManagedIdentityClaimNames
    {
        public const string Oid = "oid";

        public const string ManagedIdentityResourceId = "xms_mirid";
    }
}
