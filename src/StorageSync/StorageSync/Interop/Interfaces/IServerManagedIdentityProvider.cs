using Commands.StorageSync.Interop.Interfaces;
using Microsoft.Azure.Commands.StorageSync.Interop.Enums;
using System;
using System.Threading.Tasks;

namespace Microsoft.Azure.Commands.StorageSync.Interop.ManagedIdentity
{
    /// <summary>
    /// Provider for Server Managed Identity related information.
    /// </summary>
    public interface IServerManagedIdentityProvider
    {
        // temporary variable so that this feature can be enabled in tests
        bool EnableMIChecking { get; set; }

        /// <summary>
        /// Gets the server's VM Type by querying the Azure and Arc IMDS endpoints and checking resourceId
        /// </summary>
        /// <param name="ecsManagement"></param>
        /// <returns>ServerType: Azure, Hybrid, or Unknown</returns>
        LocalServerType GetServerType(IEcsManagement ecsManagement);

        /// <summary>
        /// Gets the server's application identity (application ID and tenant ID) asynchronously by trying to get a token from the Arc/Azure IMDS endpoint and parsing for the oid and tenant ID.
        /// </summary>
        /// <param name="serverType">ServerType: Hybrid or Azure</param>
        /// <param name="throwIfNotFound">Whether to throw an exception if an Application ID is not available</param>
        /// <param name="validateSystemAssignedManagedIdentity">Whether to validate that the Application Id belongs to a System-Assigned Managed Identity</param>
        Task<ServerApplicationIdentity> GetServerApplicationIdentityAsync(LocalServerType serverType, bool throwIfNotFound = true, bool validateSystemAssignedManagedIdentity = true);
    }
}
