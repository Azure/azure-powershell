// --------------------------------------------------------------------------------------------------------------------
// <copyright file="ServerManagedIdentityUtils.cs" company="Microsoft Corporation.">
//   All rights reserved.
// </copyright>
// <summary>
//   Utility Class for Server Managed Identity
// </summary>
// --------------------------------------------------------------------------------------------------------------------

namespace Microsoft.Azure.Commands.StorageSync.Interop.ManagedIdentity
{
    using System.Text;
    using System.Threading.Tasks;
    using System.Web;
    using System;
    using System.Net.Http;
    using Newtonsoft.Json;
    using System.Threading;
    using System.Collections.Generic;
    using System.IO;
    using System.Net;
    using System.Linq;
    using System.Net.Sockets;
    using Microsoft.Win32;
    using Microsoft.Azure.Commands.StorageSync.Common;
    using Microsoft.Azure.Commands.StorageSync.Interop.Enums;
    using Microsoft.Azure.Commands.StorageSync.Interop.Exceptions;
    using Microsoft.Azure.Commands.StorageSync.Properties;
    using Microsoft.Rest.TransientFaultHandling;

    public class ServerManagedIdentityUtils
    {
        // Azure IMDS Documentation: https://learn.microsoft.com/en-us/azure/virtual-machines/instance-metadata-service
        // Hybrid IMDS Documentation: https://learn.microsoft.com/en-us/azure/azure-arc/servers/managed-identity-authentication
        public const string AzureTokenUri = "http://169.254.169.254/metadata/identity/oauth2/token";
        public const string HybridTokenUri = "http://localhost:40342/metadata/identity/oauth2/token";

        public const string AzureTokenApiVersion = "2021-12-13";
        public const string HybridTokenApiVersion = "2020-06-01";

        /// <summary>
        /// The directory where the Secret File for the Challenge request (used to acquire Hybrid MI token) is stored
        /// </summary>
        public const string HybridSecretFileDirectory = @"\AzureConnectedMachineAgent\Tokens\";

        /// <summary>
        /// Retry get token up to 5 times
        /// </summary>
        private const int RequestRetryCount = 5;

        private static readonly HttpClient DefaultHttpClient = new HttpClient();

        private static readonly string AzureVmTokenEndpoint = $"{AzureTokenUri}?api-version={AzureTokenApiVersion}";
        private static readonly string HybridServerTokenEndpoint = $"{HybridTokenUri}?api-version={HybridTokenApiVersion}";

        /// <summary>
        /// Returns the MI token response generated from Azure IMDS/HIMDS endpoint
        /// This is called when token in cache is either not present or expired
        /// </summary>
        /// <param name="resource"> resource for which token is generated </param>
        /// <param name="client"> HttpClient used to request token if provided </param>
        /// <returns> MI Token Response object </returns>
        /// <exception cref="ServerManagedIdentityTokenException"></exception>
        public static async Task<ServerManagedIdentityTokenResponse> GetManagedIdentityTokenResponseAsync(
            string resource,
            HttpClient client = null)
        {
            LocalServerType serverTypeFromRegistry = GetLocalServerTypeFromRegistry();

            // Explicitly specifying server types for forward compatibility in case of ServerType enum modifications
            if (serverTypeFromRegistry == LocalServerType.HybridServer)
            {
                throw new ServerManagedIdentityTokenException(
                    ManagedIdentityErrorCodes.ArcServerNotEnabled,
                    StorageSyncResources.AgentMI_ArcServerNotEnabled,
                    null);
            }

            string challengeToken;
            ServerManagedIdentityTokenResponse tokenResponse = null;
            HttpClient httpClient = client ?? DefaultHttpClient;

            string managedIdentityTokenEndpoint = serverTypeFromRegistry == LocalServerType.ArcEnabledHybridServer ? HybridServerTokenEndpoint : AzureVmTokenEndpoint;

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

                        if (serverTypeFromRegistry == LocalServerType.ArcEnabledHybridServer)
                        {
                            challengeToken = await GetChallengeToken(requestUri, httpClient).ConfigureAwait(false);

                            if (string.IsNullOrEmpty(challengeToken))
                            {
                                throw new ServerManagedIdentityTokenException(
                                    ManagedIdentityErrorCodes.ServerManagedIdentityTokenGenerationFailed,
                                    StorageSyncResources.AgentMI_ChallengeTokenNullError,
                                    null);
                            }

                            requestMessage.Headers.Add(HeaderConstants.HttpHeaderAuthorization, $"{HeaderConstants.BasicAuthScheme} {challengeToken}");
                        }

                        try
                        {
                            using (var response = await httpClient.SendAsync(requestMessage, CancellationToken.None).ConfigureAwait(false))
                            {
                                if (response.IsSuccessStatusCode)
                                {
                                    var responseContent = await response.Content.ReadAsStringAsync().ConfigureAwait(false);

                                    tokenResponse = JsonConvert.DeserializeObject<ServerManagedIdentityTokenResponse>(responseContent);

                                    // Validate the token if it is a System Assigned Managed Identity. This is to ensure that the token is not a User Assigned Managed Identity token.
                                    ServerManagedIdentityTokenHelper.ValidateMIToken(tokenResponse.AccessToken);
                                }
                                // We must check for 401 response with a specific error description for servers with multiple User Assigned Identities
                                // https://learn.microsoft.com/en-us/azure/active-directory/managed-identities-azure-resources/how-to-use-vm-token
                                else if (response.StatusCode == HttpStatusCode.Unauthorized)
                                {
                                    // all errors should have a response content with error and error_description fields
                                    var responseContent = await response.Content.ReadAsStringAsync().ConfigureAwait(false);

                                    var errorResponse = JsonConvert.DeserializeObject<ServerManagedIdentityErrorResponse>(responseContent);

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

                                        throw new ServerManagedIdentityTokenException(
                                            ManagedIdentityErrorCodes.ServerManagedIdentityTokenGenerationFailed,
                                            errorMessage,
                                            new NotSupportedException(errorResponse.ErrorDescription));
                                    }
                                }
                                else
                                {
                                    // all errors should have a response content with error and error_description fields
                                    var responseContent = await response.Content.ReadAsStringAsync().ConfigureAwait(false);

                                    var errorResponse = JsonConvert.DeserializeObject<ServerManagedIdentityErrorResponse>(responseContent);

                                    var errorMessage = $"Request with uri: {requestUri} to IMDS/HIMDS endpoint returned status code: {response.StatusCode}";

                                    throw new ServerManagedIdentityTokenException(
                                            ManagedIdentityErrorCodes.ServerManagedIdentityTokenGenerationFailed,
                                            errorMessage,
                                            new NotSupportedException(errorResponse.ErrorDescription));
                                }
                            }
                        }
                        catch (TaskCanceledException ex)
                        {
                            var errorMessage = $"Request with uri: {requestUri} to IMDS/HIMDS endpoint failed due to a timeout. Message: {ex.Message}";

                            // throwing new exception so as to trigger retries keeping the inner exception intact
                            throw new ServerManagedIdentityTokenException(
                                ManagedIdentityErrorCodes.ServerManagedIdentityTokenGenerationFailed,
                                errorMessage,
                                ex);
                        }
                        catch (HttpRequestException ex)
                        {
                            // try to drill down to find socket exception, if it exists
                            Exception innerException = ex.InnerException;

                            while (innerException != null)
                            {
                                if (innerException is SocketException)
                                {
                                    throw new ServerManagedIdentityTokenException(
                                        ManagedIdentityErrorCodes.ServerManagedIdentityTokenGenerationSocketException,
                                        StorageSyncResources.AgentMI_IMDSSocketExceptionError,
                                        ex);
                                }

                                innerException = innerException.InnerException;
                            }

                            var errorMessage = $"Request with uri: {requestUri} to IMDS/HIMDS endpoint failed with: {ex.Message}";

                            throw new ServerManagedIdentityTokenException(
                                ManagedIdentityErrorCodes.ServerManagedIdentityTokenGenerationFailed,
                                errorMessage,
                                ex);
                        }
                        catch (ServerManagedIdentityTokenException)
                        {
                            throw;
                        }
                        catch (Exception ex)
                        {
                            var errorMessage = $"Request with uri: {requestUri} to IMDS/HIMDS endpoint failed with: {ex.Message}";

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
        /// To enforce this, there is an additional challenge/response check when requesting a token. 
        /// </summary>
        /// <param name="requestUri"> himds uri to request token from </param>
        /// <param name="client"> HttpClient used to request token if provided </param>
        /// <returns> challenge token </returns>
        /// <exception cref="ServerManagedIdentityTokenException"></exception>
        public static async Task<string> GetChallengeToken(string requestUri, HttpClient client = null)
        {
            string challengeToken = null;
            HttpClient httpClient = client ?? DefaultHttpClient;

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

                    var wwwHeader = authenticateHeaderValues.FirstOrDefault();

                    if (string.IsNullOrEmpty(wwwHeader) || !wwwHeader.Contains('='))
                    {
                        throw new ServerManagedIdentityTokenException(
                            ManagedIdentityErrorCodes.ServerManagedIdentityTokenChallengeFailed,
                            StorageSyncResources.AgentMI_MissingWWWAuthenticateValueError,
                            null);
                    }

                    // Value in the header is: "Basic realm=<secret file path>"
                    var secretFilePath = wwwHeader.Split(new char[] { '=' }, StringSplitOptions.RemoveEmptyEntries).LastOrDefault();

                    if (IsSecretFilePathValid(secretFilePath))
                    {
                        challengeToken = File.ReadAllText(secretFilePath);
                    }
                    else
                    {
                        throw new ServerManagedIdentityTokenException(
                            ManagedIdentityErrorCodes.ServerManagedIdentityTokenChallengeFailed,
                            StorageSyncResources.AgentMI_InvalidSecretFileError,
                            null);
                    }
                }
                catch (HttpRequestException ex)
                {
                    // try to drill down to find socket exception, if it exists
                    Exception innerException = ex.InnerException;

                    while (innerException != null)
                    {
                        if (innerException is SocketException)
                        {
                            throw new ServerManagedIdentityTokenException(
                                ManagedIdentityErrorCodes.ServerManagedIdentityTokenGenerationSocketException,
                                StorageSyncResources.AgentMI_HIMDSSocketExceptionError,
                                ex);
                        }

                        innerException = innerException.InnerException;
                    }

                    var errorMessage = $"Request with uri: {requestUri} to HIMDS endpoint failed with: {ex.Message}";

                    throw new ServerManagedIdentityTokenException(
                        ManagedIdentityErrorCodes.ServerManagedIdentityTokenChallengeFailed,
                        errorMessage,
                        ex);
                }
                catch (Exception)
                {
                    throw;
                }
                finally
                {
                    response?.Dispose();
                }
            }

            return challengeToken;
        }

        /// <summary>
        /// Validate the secret file path received is from the expected predefined directory and is of expected .key file extension.
        /// This ensures we are not redirected by some malicious process listening on localhost:40342 into a bad secret file.
        /// </summary>
        /// <param name="secretFilePath"></param>
        /// <returns></returns>
        private static bool IsSecretFilePathValid(string secretFilePath)
        {
            // Check if the secret file path is null or empty
            if (string.IsNullOrEmpty(secretFilePath))
            {
                return false;
            }

            // Normalize the path to prevent path traversal attacks
            string normalizedTokenLocation = Path.GetFullPath(secretFilePath);

            string allowedFolder;

            // Expected form: %ProgramData%\AzureConnectedMachineAgent\Tokens\<guid>.key
            var programData = Environment.GetEnvironmentVariable("ProgramData");
            
            if (string.IsNullOrEmpty(programData))
            {
                // If ProgramData is not found, try to manually construct it using SystemDrive
                var systemDrive = Environment.GetEnvironmentVariable("SystemDrive");

                if (string.IsNullOrEmpty(systemDrive))
                {
                    throw new ServerManagedIdentityTokenException(
                        ManagedIdentityErrorCodes.ServerManagedIdentityTokenChallengeFailed,
                        StorageSyncResources.AgentMI_ProgramDataNotFoundError,
                        null);
                }
                else
                {
                    programData = Path.Combine(systemDrive, "ProgramData");
                }
            }

            allowedFolder = Path.GetFullPath(Path.Combine(programData, "AzureConnectedMachineAgent", "Tokens"));

            // Ensure the secret file is within the allowed tokens folder, exists, and ends with .key
            if (!normalizedTokenLocation.StartsWith(allowedFolder + Path.DirectorySeparatorChar, StringComparison.OrdinalIgnoreCase) ||
                !File.Exists(normalizedTokenLocation) ||
                !Path.GetFileName(normalizedTokenLocation).EndsWith(".key", StringComparison.OrdinalIgnoreCase))
            {
                return false;
            }

            return true;
        }

        /// <summary>
        /// Gets the Server Type from the the StorageSync registry path. Default to <see cref="LocalServerType.HybridServer"/>
        /// Not using ServerManagedIdentityProvider.GetServerType because it does not necessarily do a direct registry key read. 
        /// </summary>
        /// <returns>The server type</returns>
        private static LocalServerType GetLocalServerTypeFromRegistry()
        {
            RegistryUtility.TryGetValue(
                StorageSyncConstants.ServerTypeRegistryKeyName,
                StorageSyncConstants.AfsRegistryKey,
                out string serverTypeFromRegistry,
                RegistryValueKind.String,
                RegistryValueOptions.None);

            if (Enum.TryParse(serverTypeFromRegistry, out LocalServerType serverType))
            {
                return serverType;
            }

            return LocalServerType.HybridServer;
        }
    }
}
