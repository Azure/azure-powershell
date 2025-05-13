using Commands.StorageSync.Interop.DataObjects;
using Commands.StorageSync.Interop.Interfaces;
using Hyak.Common;
using Microsoft.Azure.Commands.StorageSync.Interop.Enums;
using System;
using System.Diagnostics.Tracing;
using System.Threading.Tasks;

namespace Microsoft.Azure.Commands.StorageSync.Interop.ManagedIdentity
{
    /// <summary>
    /// ServerManagedIdentityProvider provides info about the Server -- the type/if server MI is enabled
    /// </summary>
    public class ServerManagedIdentityProvider : IServerManagedIdentityProvider
    {
        public bool EnableMIChecking { get; set; }

        public Action<string, EventLevel> TraceLog { get; private set; }

        public ServerManagedIdentityProvider(Action<string, EventLevel> traceLog = null)
        {
            EnableMIChecking = true;
            this.TraceLog = new Action<string, EventLevel>((message, e) => {
                if (traceLog != null)
                {
                    traceLog(message, e);
                }
                // TODO: Check information is too verbose. Should be changed to Error
                TracingAdapter.Information($"{DateTime.Now:T} [{e}] - {message}");
            });
        }

        /// <summary>
        /// Gets the server's VM Type using a COM interface which queries the Azure and Arc IMDS endpoints and checking resourceId
        /// </summary>
        /// <param name="ecsManagement"></param>
        /// <returns>Server's VmType: Azure, Hybrid, or Unknown</returns>
        public LocalServerType GetServerType(IEcsManagement ecsManagement)
        {
            TraceLog($"{nameof(EnableMIChecking)} is {EnableMIChecking}.", EventLevel.Informational);
            ManagedIdentityConfigurationInfo serverInfo = GetManagedIdentityConfigurationStatus(ecsManagement);
            return serverInfo.ServerType;
        }

        /// <summary>
        /// Gets the server's application id by trying to get a token from the Arc/Azure IMDS endpoint and parsing for the oid
        /// </summary>
        /// <param name="localServerType">ServerType: Hybrid or Azure</param>
        /// <param name="throwIfNotFound">Whether to throw an exception if an Application ID is not available</param>
        /// <param name="validateSAMI">Whether to validate that the Application Id belongs to a System-Assigned Managed Identity</param>
        /// <returns>Server's applicationId if it's available, Guid.Empty otherwise</returns>
        public Guid GetServerApplicationId(LocalServerType localServerType, bool throwIfNotFound = true, bool validateSAMI = true)
        {
            var applicationId = Guid.Empty;

            if (EnableMIChecking)
            {
                try
                {
                    if (localServerType == LocalServerType.HybridServer)
                    {
                        return applicationId;
                    }

                    // We need to use the https://storage.azure.com resource, as this provides us the x-ms-rid header to use for validation.
                    // Application id should be from real time token getting from the IMDS endpoint instead of cached token. Also we noticed 
                    // an issue that PowerShell Core(5+) doesn't work with ProtectedMemory: https://github.com/PSKeePass/PoShKeePass/issues/170
                    // When we cache token in ServerManagedIdentityTokenProvider, it will use ProtectedMemory to encrypt/decrypt the token,
                    // and this GetServerApplicationId can be triggered from server registration using PowerShell Core which causes that issue.
                    // So this is another reason we need to get the token from IMDS endpoint directly via ServerManagedIdentityUtils, not ServerManagedIdentityTokenProvider.
                    ServerManagedIdentityTokenResponse tokenResponse;

                    tokenResponse = ServerManagedIdentityUtils.GetManagedIdentityTokenResponseAsync(resource: "https://storage.azure.com/").GetAwaiter().GetResult();


                    var token = tokenResponse.AccessToken;

                    applicationId = ServerManagedIdentityTokenHelper.GetTokenOid(token);
                }
                catch (Exception)
                {
                    if (throwIfNotFound)
                    {
                        throw;
                    }
                }
            }
            else
            {
                TraceLog($"{nameof(EnableMIChecking)} is off.", EventLevel.Informational);
            }

            return applicationId;
        }

        /// <summary>
        /// Checks the server type using the GetMIConfigurationStatus COM interface
        /// </summary>
        /// <returns>ManagedIdentityConfigurationInfo object containing server type and server auth type</returns>
        private ManagedIdentityConfigurationInfo GetManagedIdentityConfigurationStatus(IEcsManagement ecsManagement)
        {
            ManagedIdentityConfigurationInfo serverInfo = null;
            try
            {

                int hresult = ecsManagement.GetMIConfigurationStatus(out uint serverTypeUint, out uint serverAuthTypeUint);
                if (HResult.Succeeded(hresult))
                {
                    serverInfo = new ManagedIdentityConfigurationInfo((LocalServerType)serverTypeUint, (RegisteredServerAuthType)serverAuthTypeUint);
                }
                else
                {
                    throw new System.Runtime.InteropServices.COMException("GetManagedIdentityConfigurationStatus", hresult);
                }
            }
            catch (Exception ex)
            {
                TraceLog(ex.ToString(), EventLevel.Error);
                //throw;
                serverInfo = new ManagedIdentityConfigurationInfo(LocalServerType.HybridServer, RegisteredServerAuthType.Certificate);
            }

            return serverInfo;
        }
    }
}
