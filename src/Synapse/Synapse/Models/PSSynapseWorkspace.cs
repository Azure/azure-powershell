using Microsoft.Azure.Management.Synapse.Models;
using System.Collections.Generic;

namespace Microsoft.Azure.Commands.Synapse.Models
{
    public class PSSynapseWorkspace : PSSynapseTrackedResource
    {
        public PSSynapseWorkspace(Workspace workspace)
            : base(workspace.Location, workspace.Id, workspace.Name, workspace.Type, workspace.Tags)
        {
            this.DefaultDataLakeStorage = workspace?.DefaultDataLakeStorage != null ? new PSDataLakeStorageAccountDetails(workspace?.DefaultDataLakeStorage) : null;
            this.SqlAdministratorLogin = workspace?.SqlAdministratorLogin;
            this.ManagedResourceGroupName = workspace?.ManagedResourceGroupName;
            this.ProvisioningState = workspace?.ProvisioningState;
            this.VirtualNetworkProfile = workspace?.VirtualNetworkProfile != null ? new PSVirtualNetworkProfile(workspace?.VirtualNetworkProfile) : null;
            this.Identity = workspace?.Identity != null ? new PSManagedIdentity(workspace?.Identity) : null;
            this.ConnectivityEndpoints = workspace?.ConnectivityEndpoints;
        }

        /// <summary>
        /// Gets workspace default data lake storage account details
        /// </summary>
        public PSDataLakeStorageAccountDetails DefaultDataLakeStorage { get; set; }

        /// <summary>
        /// Gets workspace managed resource group
        /// </summary>
        public string ManagedResourceGroupName { get; set; }

        /// <summary>
        /// Gets resource provisioning state
        /// </summary>
        public string ProvisioningState { get; set; }

        /// <summary>
        /// Gets login for workspace SQL active directory administrator
        /// </summary>
        public string SqlAdministratorLogin { get; set; }

        /// <summary>
        /// Gets virtual Network profile
        /// </summary>
        public PSVirtualNetworkProfile VirtualNetworkProfile { get; set; }

        /// <summary>
        /// Gets identity of the workspace
        /// </summary>
        public PSManagedIdentity Identity { get; set; }

        /// <summary>
        /// Gets identity of the workspace connectivity endpoints
        /// </summary>
        public IDictionary<string, string> ConnectivityEndpoints { get; }
    }
}
