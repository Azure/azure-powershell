using Commands.StorageSync.Interop.Interfaces;
using Microsoft.Azure.Commands.StorageSync.Interop.Enums;
using System;

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
        /// Gets the server's application id by trying to get a token and parsing for the oid
        /// We choose to get the applicationId from the token rather than making a Get call on the resource
        /// because we don't know the permissions the user has on the resource
        /// </summary>
        /// <param name="serverType">ServerType: Hybrid or Azure</param>
        /// <param name="throwIfNotFound">Whether to throw an exception if an Application ID is not available</param>
        /// <param name="validateSystemAssignedManagedIdentity">Whether to validate that the Application Id belongs to a System-Assigned Managed Identity</param>
        /// <returns>Server's applicationId if it's available, Guid.Empty otherwise</returns>
        Guid GetServerApplicationId(LocalServerType serverType, bool throwIfNotFound = true, bool validateSystemAssignedManagedIdentity = true);
    }
}
