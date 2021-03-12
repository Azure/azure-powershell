﻿using Microsoft.Azure.Management.Synapse.Models;
using System.Collections.Generic;
using System.Linq;

namespace Microsoft.Azure.Commands.Synapse.Models
{
    public class PSSynapseWorkspace : PSSynapseTrackedResource
    {
        public PSSynapseWorkspace(Workspace workspace)
            : base(workspace?.Location, workspace?.Id, workspace?.Name, workspace?.Type, workspace?.Tags)
        {
            this.DefaultDataLakeStorage = workspace?.DefaultDataLakeStorage != null ? new PSDataLakeStorageAccountDetails(workspace?.DefaultDataLakeStorage) : null;
            this.SqlAdministratorLogin = workspace?.SqlAdministratorLogin;
            this.ManagedResourceGroupName = workspace?.ManagedResourceGroupName;
            this.ProvisioningState = workspace?.ProvisioningState;
            this.VirtualNetworkProfile = workspace?.VirtualNetworkProfile != null ? new PSVirtualNetworkProfile(workspace?.VirtualNetworkProfile) : null;
            this.Identity = workspace?.Identity != null ? new PSManagedIdentity(workspace?.Identity) : null;
            this.ConnectivityEndpoints = workspace?.ConnectivityEndpoints;
            this.ManagedVirtualNetwork = workspace?.ManagedVirtualNetwork;
            this.PrivateEndpointConnections = workspace?.PrivateEndpointConnections != null
                ? workspace.PrivateEndpointConnections.Select(e => new PSPrivateEndpointConnection(e)).ToList()
                : null;
            this.WorkspaceUID = workspace?.WorkspaceUID != null ? workspace.WorkspaceUID.Value.ToString() : null;
            this.ExtraProperties = workspace.ExtraProperties;
            this.ManagedVirtualNetworkSettings = workspace?.ManagedVirtualNetworkSettings != null ? new PSManagedVirtualNetworkSettings(workspace?.ManagedVirtualNetworkSettings) : null;
            this.Encryption = workspace?.Encryption != null ? new PSEncryptionDetails(workspace?.Encryption) : null;
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

        /// <summary>
        /// Gets workspace managed virtual network
        /// </summary>
        public string ManagedVirtualNetwork { get; set; }

        /// <summary>
        /// Gets the private endpoint connections to the workspace
        /// </summary>
        public IList<PSPrivateEndpointConnection> PrivateEndpointConnections { get; set; }

        /// <summary>
        /// Gets the workspace unique identifier
        /// </summary>
        public string WorkspaceUID { get; set; }

        /// <summary>
        /// Gets workspace level configs and feature flags
        /// </summary>
        public IDictionary<string, object> ExtraProperties { get; set; }

        /// Gets or sets managed Virtual Network Settings
        /// </summary>
        public PSManagedVirtualNetworkSettings ManagedVirtualNetworkSettings { get; set; }

        /// <summary>
        /// Gets or sets the encryption details of the workspace
        /// </summary>
        public PSEncryptionDetails Encryption { get; set; }
    }
}
