using Microsoft.Azure.Commands.StorageSync.Interop.Enums;
using System;
using System.Security.Cryptography;
using System.Collections.Generic;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Net.Http;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using System.Threading;
using System.Web;
using System.Diagnostics.Tracing;
using Microsoft.Azure.Commands.StorageSync.Interop.Exceptions;
using Microsoft.Azure.Commands.Common.Authentication;
using Newtonsoft.Json;
using Microsoft.Azure.Commands.StorageSync.Interop.Interfaces;
using Microsoft.Rest.TransientFaultHandling;
using Microsoft.Azure.Commands.StorageSync.Properties;

namespace Microsoft.Azure.Commands.StorageSync.Interop.ManagedIdentity
{
    public class ServerManagedIdentityTokenProvider : IServerManagedIdentityTokenProvider
    {
        // Azure IMDS Documentation: https://learn.microsoft.com/en-us/azure/virtual-machines/instance-metadata-service
        // Hybrid IMDS Documentation: https://learn.microsoft.com/en-us/azure/azure-arc/servers/managed-identity-authentication
        public const string AzureTokenUri = "http://169.254.169.254/metadata/identity/oauth2/token";
        public const string HybridTokenUri = "http://localhost:40342/metadata/identity/oauth2/token";

        public const string AzureTokenApiVersion = "2021-12-13";
        public const string HybridTokenApiVersion = "2020-06-01";
        private readonly TimeSpan SemaphoreTimeoutTime = TimeSpan.FromSeconds(70);

        /// <summary>
        /// The directory where the Secret File for the Challenge request (used to acquire Hybrid MI token) is stored
        /// </summary>
        public const string HybridSecretFileDirectory = @"\AzureConnectedMachineAgent\Tokens\";

        /// <summary>
        /// Retry get token up to 5 times
        /// </summary>
        private const int RequestRetryCount = 5;

        /// <summary>
        /// We do not return a token that is expiring in the next 30 minutes
        /// In case it is expiring in the next 30 minutes, we will fetch a new one from Azure IMDS/HIMDS, even if we have one in our cache
        /// Azure IMDS/HIMDS itself currently refreshes it's token when &lt; 90 minutes remain in the token expiry. 
        /// Our threshold of 30 minutes ensures we are not making multiple calls in a short time to Azure IMDS/HIMDS, which can lead to throttling
        /// </summary>
        private static readonly TimeSpan MaxTimeBeforeTokenExpires = TimeSpan.FromMinutes(30);

        /// <summary>
        /// Initialize with 1 thread, max 1 thread
        /// </summary>
        private readonly SemaphoreSlim semaphoreSlim = new SemaphoreSlim(1, 1);

        /// <summary>
        /// The cache is for storing MI access tokens: resource => string expiryTime, byte[] protectedTokenResponse.
        /// </summary>
        private readonly Dictionary<string, Tuple<string, byte[]>> serverMITokenCache;

        private readonly byte[] aesKey;

        private readonly byte[] aesIv;

        /// <summary>
        /// The endpoint to be used for getting the Managed Identity Token (IMDS/HIMDS).
        /// </summary>
        private readonly string managedIdentityTokenEndpoint;

        private readonly LocalServerType serverType;

        private readonly HttpClient httpClient;

        private readonly Action<string, EventLevel> TraceLog;

        /// <summary>
        /// Provider class to generate the managed identity token from Azure IMDS/HIMDS endpoint
        /// </summary>
        public ServerManagedIdentityTokenProvider(
            LocalServerType inputServerType,
            HttpClient client = default,
            Action<string, EventLevel> traceLog = default)
        {
            serverMITokenCache = new Dictionary<string, Tuple<string, byte[]>>();
            serverType = inputServerType;

            aesKey = GenerateRandomBytes(16);
            aesIv = GenerateRandomBytes(16);

            if (client == default)
            {
                httpClient = new HttpClient();
            }
            else
            {
                httpClient = client;
            }

            if (serverType == LocalServerType.ArcEnabledHybridServer)
            {
                managedIdentityTokenEndpoint = $"{HybridTokenUri}?api-version={HybridTokenApiVersion}";
            }
            else if (serverType == LocalServerType.AzureVirtualMachineServer)
            {
                managedIdentityTokenEndpoint = $"{AzureTokenUri}?api-version={AzureTokenApiVersion}";
            }
            else
            {
                throw new ArgumentException("Failed to set MI Token Endpoint. ServerType should be Hybrid or Azure", nameof(serverType));
            }

            this.TraceLog = new Action<string, EventLevel>((message, e) =>
            {
                if (traceLog != null)
                {
                    traceLog(message, e);
                }
            });
        }

        /// <summary>
        /// Returns the MI access token generated from Azure IMDS/HIMDS endpoint
        /// </summary>
        /// <param name="resource"> resource for which token is generated </param>
        /// <returns> Access Token </returns>
        public async Task<string> GetManagedIdentityAccessToken(string resource)
        {
           ServerManagedIdentityTokenResponse tokenResponse = await GetManagedIdentityTokenResponse(resource).ConfigureAwait(false);
            return tokenResponse.AccessToken;
        }

        /// <summary>
        /// Returns the MI token response generated from Azure IMDS/HIMDS endpoint (from cache if present)
        /// </summary>
        /// <param name="resource"> resource for which token is generated </param>
        /// <returns> MI Token response object </returns>
        public async Task<ServerManagedIdentityTokenResponse> GetManagedIdentityTokenResponse(string resource)
        {
            ServerManagedIdentityTokenResponse tokenResponse = null;

            // Check if token is present in cache and not expiring before max cache duration
            if (serverMITokenCache.TryGetValue(resource, out Tuple<string, byte[]> value))
            {
                tokenResponse = GetTokenResponseFromCachedValue(value);

                if (tokenResponse != null)
                {
                    return tokenResponse;
                }
            }

            TraceLog($"Token not found in cache for resource: {resource}, or expires before max cache duration", EventLevel.Informational);

            try
            {
                await semaphoreSlim.WaitAsync(SemaphoreTimeoutTime).ConfigureAwait(false);

                // Checking again if a new token with longer lifetime was updated in cache before generating it 
                if (serverMITokenCache.TryGetValue(resource, out value))
                {
                    tokenResponse = GetTokenResponseFromCachedValue(value);

                    if (tokenResponse != null)
                    {
                        TraceLog($"Token was updated by another thread in cache for resource: {resource}. Ignoring re-generation of token.", EventLevel.Informational);

                        return tokenResponse;
                    }
                }

                tokenResponse = await GetManagedIdentityTokenResponseInternal(resource).ConfigureAwait(false);

                if (tokenResponse == null)
                {
                    throw new ServerManagedIdentityTokenException(
                        ManagedIdentityErrorCodes.ServerManagedIdentityTokenGenerationFailed,
                        StorageSyncResources.AgentMI_TokenResponseNullError,
                        null);
                }

                DateTimeOffset dateTimeOffsetTokenExpiresOn = FromUnixTimeSeconds(long.Parse(tokenResponse.ExpiresOn, NumberStyles.Number, CultureInfo.InvariantCulture));
                TraceLog($"Populating the cache for resource: {resource} with Token with expiry: {dateTimeOffsetTokenExpiresOn}", EventLevel.Informational);

                // Convert response to byte array and add PKCS7 padding
                var byteArrayForCache = ConvertFromTokenResponseToPaddedByteArr(tokenResponse);

                // Protect token response that gets stored in the cache
                //TODO: Uncomment
                // ProtectedMemory.Protect(byteArrayForCache, MemoryProtectionScope.SameProcess);

                serverMITokenCache[resource] = new Tuple<string, byte[]>(tokenResponse.ExpiresOn, byteArrayForCache);

                TraceLog($"Token updated in cache with expiration {dateTimeOffsetTokenExpiresOn}", EventLevel.Informational);
            }
            catch (Exception ex)
            {
                throw new ServerManagedIdentityTokenException(
                    ManagedIdentityErrorCodes.ServerManagedIdentityTokenGenerationFailed,
                    ex.Message,
                    ex.InnerException);
            }
            finally
            {
                semaphoreSlim?.Release();
            }

            return tokenResponse;
        }

        public void Dispose()
        {
            semaphoreSlim?.Dispose();
            httpClient?.Dispose();
        }

        /// <summary>
        /// Returns the MI token response generated from Azure IMDS/HIMDS endpoint
        /// This is called when token in cache is either not present or expired
        /// </summary>
        /// <param name="resource"> resource for which token is generated </param>
        /// <returns> MI Token Response object </returns>
        /// <exception cref="ServerManagedIdentityTokenException"></exception>
        protected virtual async Task<ServerManagedIdentityTokenResponse> GetManagedIdentityTokenResponseInternal(string resource)
        {
            string challengeToken;
            ServerManagedIdentityTokenResponse tokenResponse = null;

            var encodedResource = HttpUtility.UrlEncode(resource, Encoding.UTF8);
            var requestUri = $"{managedIdentityTokenEndpoint}&resource={encodedResource}";

            // Exponential retry policy as per MI team recommendation (Retry in 1, 2, 4, 8, 16 ... 60 secs) 
            // MinBackoff: 0s, MaxBackoff: 60s, DeltaBackoff: 2s
            // Retry guidance: https://learn.microsoft.com/en-us/azure/active-directory/managed-identities-azure-resources/how-to-use-vm-token#retry-guidance
            var retryStrategy = new ExponentialBackoffRetryStrategy(RequestRetryCount, TimeSpan.FromSeconds(0), TimeSpan.FromSeconds(60), TimeSpan.FromSeconds(2));
            var defaultRetryPolicy = new RetryPolicy<ServerManagedIdentityErrorDetectionStrategy>(retryStrategy);
            int retryCount = 0;

            await defaultRetryPolicy.ExecuteAsync(
                async () =>
                {
                    retryCount++;

                    using (var requestMessage = new HttpRequestMessage(HttpMethod.Get, requestUri))
                    {
                        // IMDS requires Metadata: true 
                        //    https://learn.microsoft.com/en-us/azure/virtual-machines/windows/instance-metadata-service?tabs=windows#security-and-authentication
                        requestMessage.Headers.Add(HeaderConstants.Metadata, "true");

                        if (serverType == LocalServerType.ArcEnabledHybridServer)
                        {
                            challengeToken = await GetChallengeToken(requestUri).ConfigureAwait(false);

                            if (string.IsNullOrEmpty(challengeToken))
                            {
                                throw new ServerManagedIdentityTokenException(
                                    ManagedIdentityErrorCodes.ServerManagedIdentityTokenGenerationFailed,
                                    StorageSyncResources.AgentMI_ChallengeTokenNullError,
                                    null);
                            }

                            requestMessage.Headers.Add(HeaderConstants.HttpHeaderAuthorization, $"{HeaderConstants.BasicAuthScheme} {challengeToken}");
                        }

                        TraceLog($"MI Token Request Uri: {requestUri}", EventLevel.Informational);

                        try
                        {
                            using (var response = await httpClient.SendAsync(requestMessage, CancellationToken.None).ConfigureAwait(false))
                            {
                                TraceLog($"Token response retrieved. Status code: {response?.StatusCode}", EventLevel.Informational);

                                if (response.IsSuccessStatusCode)
                                {
                                    var responseContent = await response.Content.ReadAsStringAsync().ConfigureAwait(false);
                                    tokenResponse = JsonConvert.DeserializeObject<ServerManagedIdentityTokenResponse>(responseContent);
 
                                    TraceLog($"Token response retrieved. Num tries: {retryCount - 1} Type: {tokenResponse.TokenType} Resource: {tokenResponse.Resource} ExpiresOn: {tokenResponse.ExpiresOn}", EventLevel.Informational);
                                }
                                // We must check for 401 response with a specific error description for servers with multiple User Assigned Identities
                                // https://learn.microsoft.com/en-us/azure/active-directory/managed-identities-azure-resources/how-to-use-vm-token
                                else if (response.StatusCode == HttpStatusCode.Unauthorized)
                                {
                                    // all errors should have a response content with error and error_description fields
                                    var responseContent = await response.Content.ReadAsStringAsync().ConfigureAwait(false);

                                    var errorResponse = JsonConvert.DeserializeObject<ServerManagedIdentityErrorResponse>(responseContent);

                                    TraceLog($@"Http error response received while getting token. Status code: {HttpStatusCode.Unauthorized} Error: {errorResponse.Error} ErrorDescription: {errorResponse.ErrorDescription}", EventLevel.Warning);

                                    // if the error is due to multiple user assigned identities, we need to throw a more specific error
                                    if (errorResponse.Error.Equals("invalid_request", StringComparison.OrdinalIgnoreCase))
                                    {
                                        throw new ServerManagedIdentityTokenException(
                                            ManagedIdentityErrorCodes.ServerManagedIdentitySystemIdentityNotFound,
                                            StorageSyncResources.AgentMI_MissingSystemIdentityWithMultipleUserAssignedError,
                                            new NotSupportedException(errorResponse.ErrorDescription));
                                    }
                                    else
                                    {
                                        var errorMessage = $"Request with uri: {requestUri} to IMDS/HIMDS endpoint returned status code: {response.StatusCode}";
                                        TraceLog(errorMessage, EventLevel.Error);
                                        throw new HttpRequestWithStatusException($"Response failed with status code {response.StatusCode}");
                                    }
                                }
                                else
                                {
                                    var errorMessage = $"Request with uri: {requestUri} to IMDS/HIMDS endpoint returned status code: {response.StatusCode}";
                                    TraceLog(errorMessage, EventLevel.Error);

                                    response.EnsureSuccessStatusCode();
                                }
                            }
                        }
                        catch (TaskCanceledException ex)
                        {
                            var errorMessage = $"Request with uri: {requestUri} to IMDS/HIMDS endpoint failed due to a timeout. Message: {ex.Message}";
                            TraceLog(errorMessage, EventLevel.Error);

                            if (ex.InnerException != null)
                            {
                                TraceLog(ex.InnerException.ToString(), EventLevel.Error);
                            }

                            // throwing new exception so as to trigger retries keeping the inner exception intact
                            throw new ServerManagedIdentityTokenException(
                                ManagedIdentityErrorCodes.ServerManagedIdentityTokenGenerationFailed,
                                errorMessage,
                                ex);
                        }
                        catch (Exception ex)
                        {
                            var errorMessage = $"Request with uri: {requestUri} to IMDS/HIMDS endpoint failed with: {ex.Message}";
                            TraceLog(errorMessage, EventLevel.Error);
                            TraceLog(ex.ToString(), EventLevel.Error);
                            throw new ServerManagedIdentityTokenException(
                                ManagedIdentityErrorCodes.ServerManagedIdentityTokenGenerationFailed,
                                errorMessage,
                                ex);
                        }
                    }
                }).ConfigureAwait(false);

            return tokenResponse;
        }

        /// <summary>
        /// Obtaining tokens on an Arc server is restricted to privileged applications or processes. 
        /// To enforce this, there is an additional chellenge/response check when requesting a token. 
        /// </summary>
        /// <param name="requestUri"> himds uri to request token from </param>
        /// <returns> challenge token </returns>
        private async Task<string> GetChallengeToken(string requestUri)
        {
            string challengeToken = null;

            using (var requestMessage = new HttpRequestMessage(HttpMethod.Get, requestUri))
            {
                // IMDS requires Metadata: true 
                //    https://learn.microsoft.com/en-us/azure/virtual-machines/windows/instance-metadata-service?tabs=windows#security-and-authentication
                requestMessage.Headers.Add(HeaderConstants.Metadata, "true");

                HttpResponseMessage response = null;

                try
                {
                    response = await httpClient.SendAsync(requestMessage, CancellationToken.None).ConfigureAwait(false);

                    // we expect an unauthorized response when making the challenge request
                    if (response.StatusCode != HttpStatusCode.Unauthorized)
                    {
                        throw new ServerManagedIdentityTokenException(
                            ManagedIdentityErrorCodes.ServerManagedIdentityTokenChallengeFailed,
                            StorageSyncResources.AgentMI_UnexpectedArcChallengeResponseError,
                            null);
                    }

                    // parse out the WWW-Authenticate Header from the response
                    if (!response.Headers.TryGetValues(HeaderConstants.WWWAuthenticate, out IEnumerable<string> authenticateHeaderValues) ||
                        !authenticateHeaderValues.Any())
                    {
                        throw new ServerManagedIdentityTokenException(
                            ManagedIdentityErrorCodes.ServerManagedIdentityTokenChallengeFailed,
                            StorageSyncResources.AgentMI_MissingWWWAuthenticateHeaderError,
                            null);
                    }

                    var headerValue = authenticateHeaderValues.FirstOrDefault();

                    if (string.IsNullOrEmpty(headerValue) || !headerValue.Contains('='))
                    {
                        throw new ServerManagedIdentityTokenException(
                            ManagedIdentityErrorCodes.ServerManagedIdentityTokenChallengeFailed,
                            StorageSyncResources.AgentMI_MissingWWWAuthenticateValueError,
                            null);
                    }

                    // Value in the header is: "Basic realm=<secret file path>"
                    var secretFilePath = headerValue.Split('=')[1];

                    string expectedSecretFileLocation;

                        expectedSecretFileLocation = Environment.GetEnvironmentVariable("ProgramData") + HybridSecretFileDirectory;

                    // Validate the secret file path received is from the expected predefined directory and is of expected .key file extension.
                    // This ensures we are not redirected by some malicious process listening on localhost:40342 into a bad secret file.
                    if (string.IsNullOrEmpty(secretFilePath) ||
                        !secretFilePath.Contains(expectedSecretFileLocation) ||
                        !secretFilePath.Contains(".key"))
                    {
                        throw new ServerManagedIdentityTokenException(
                            ManagedIdentityErrorCodes.ServerManagedIdentityTokenChallengeFailed,
                            StorageSyncResources.AgentMI_InvalidSecretFileError,
                            null);
                    }

                    if (File.Exists(secretFilePath))
                    {
                        challengeToken = File.ReadAllText(secretFilePath);
                    }
                    else
                    {
                        throw new ServerManagedIdentityTokenException(
                            ManagedIdentityErrorCodes.ServerManagedIdentityTokenChallengeFailed,
                            StorageSyncResources.AgentMI_MissingSecretFilePathOnServerError,
                            null);
                    }
                }
                finally
                {
                    response?.Dispose();
                }
            }

            return challengeToken;
        }

        private bool IsTokenExpiringBeforeMaxTime(string expiryTime)
        {
            DateTimeOffset dateTimeOffsetTokenExpiresOn = FromUnixTimeSeconds(long.Parse(expiryTime, NumberStyles.Number, CultureInfo.InvariantCulture));
            DateTimeOffset dateTimeOffsetMaxTokenExpiresOn = DateTimeOffset.UtcNow + MaxTimeBeforeTokenExpires;

            return dateTimeOffsetMaxTokenExpiresOn > dateTimeOffsetTokenExpiresOn;
        }

        /// <summary>
        /// This method converts the unix time in seconds to a DateTimeOffset object.
        /// This method is not implemented until .NET Framework 4.6, and the agent is currently on 4.5.2.
        /// </summary>
        /// <param name="seconds"></param>
        /// <returns> DateTimeOffset value for seconds elapsed from Jan. 1, 1970 </returns>
        private DateTimeOffset FromUnixTimeSeconds(long seconds)
        {
            var dateTimeOffset = new DateTimeOffset(new DateTime(1970, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc));
            dateTimeOffset = dateTimeOffset.AddSeconds(seconds);
            return dateTimeOffset;
        }

        /// <summary>
        /// Helper method to get the ServerManagedIdentityTokenResponse from the cached tuple. Returns null if expired.
        /// </summary>
        /// <param name="value">Tuple from serverMITokenCache containing expiryTime, tokenReponseByteArr></param>
        /// <returns>The ServerManagedIdentityTokenResponse converted from the cache</returns>
        private ServerManagedIdentityTokenResponse GetTokenResponseFromCachedValue(Tuple<string, byte[]> value)
        {
            if (!IsTokenExpiringBeforeMaxTime(value.Item1))
            {
                var paddedByteArr = value.Item2;

                // Deep copy array to avoid unprotecting the actual value in the cache
                var deepCopyByteArr = new byte[paddedByteArr.Length];
                Array.Copy(paddedByteArr, deepCopyByteArr, paddedByteArr.Length);

                // Unprotect token response
                // TODO: Uncomment
                //ProtectedMemory.Unprotect(deepCopyByteArr, MemoryProtectionScope.SameProcess);

                // Undo PKCS7 padding and convert to ServerManagedIdentityTokenResponse
                return ConvertFromPaddedByteArrToTokenResponse(deepCopyByteArr);
            }

            return null;
        }

        /// <summary>
        /// Helper method to take a byte array, with PKCS7 padding added, and convert it to ServerManagedIdentityTokenResponse
        /// </summary>
        /// <param name="paddedByteArr">the byte array that is PKCS7 padded to be converted</param>
        /// <returns>ServerManagedIdentityTokenResponse object</returns>
        private ServerManagedIdentityTokenResponse ConvertFromPaddedByteArrToTokenResponse(byte[] paddedByteArr)
        {
            byte[] unpaddedByteArr;

            // Decrypt PKCS7 padding
            using (var aesAlg = Aes.Create())
            {
                aesAlg.Key = aesKey;
                aesAlg.IV = aesIv;
                aesAlg.Padding = PaddingMode.PKCS7;

                using (var ms = new MemoryStream())
                {
                    using (var decryptor = aesAlg.CreateDecryptor())
                    {
                        using (var cs = new CryptoStream(ms, decryptor, CryptoStreamMode.Write))
                        {
                            cs.Write(paddedByteArr, 0, paddedByteArr.Length);
                            cs.FlushFinalBlock();
                        }
                    }

                    unpaddedByteArr = ms.ToArray();
                }
            }

            // Deserialize as ServerManagedIdentityTokenResponse
            var data = Encoding.UTF8.GetString(unpaddedByteArr);
            return JsonConvert.DeserializeObject<ServerManagedIdentityTokenResponse>(data);
        }

        /// <summary>
        /// Helper method to take a ServerManagedIdentityTokenResponse and convert it to a byte array, with PKCS7 padding added
        /// </summary>
        /// <param name="miTokenResponse">the ServerManagedIdentityTokenResponse to be converted</param>
        /// <returns>PKCS7 padded byte array</returns>
        private byte[] ConvertFromTokenResponseToPaddedByteArr(ServerManagedIdentityTokenResponse miTokenResponse)
        {
            // Serialize to bytes
            var jsonString = JsonConvert.SerializeObject(miTokenResponse);
            var data = Encoding.UTF8.GetBytes(jsonString);

            // Encrypt with PKCS7 padding
            using (var aesAlg = Aes.Create())
            {
                aesAlg.Key = aesKey;
                aesAlg.IV = aesIv;
                aesAlg.Padding = PaddingMode.PKCS7;

                using (var ms = new MemoryStream())
                {
                    using (var encryptor = aesAlg.CreateEncryptor())
                    {
                        using (var cs = new CryptoStream(ms, encryptor, CryptoStreamMode.Write))
                        {
                            cs.Write(data, 0, data.Length);
                            cs.FlushFinalBlock();
                        }
                    }

                    return ms.ToArray();
                }
            }
        }

        private byte[] GenerateRandomBytes(int length)
        {
            using (RNGCryptoServiceProvider rng = new RNGCryptoServiceProvider())
            {
                byte[] randomBytes = new byte[length];
                rng.GetBytes(randomBytes);
                return randomBytes;
            }
        }
    }
}
