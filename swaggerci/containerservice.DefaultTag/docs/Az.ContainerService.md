---
Module Name: Az.ContainerService
Module Guid: c9183b03-e062-46f0-9987-9c46e5964225
Download Help Link: https://learn.microsoft.com/powershell/module/az.containerservice
Help Version: 1.0.0.0
Locale: en-US
---

# Az.ContainerService Module
## Description
Microsoft Azure PowerShell: ContainerService cmdlets

## Az.ContainerService Cmdlets
### [Get-AzContainerServiceAgentPool](Get-AzContainerServiceAgentPool.md)
Gets the specified managed cluster agent pool.

### [Get-AzContainerServiceAgentPoolAvailableAgentPoolVersion](Get-AzContainerServiceAgentPoolAvailableAgentPoolVersion.md)
See [supported Kubernetes versions](https://docs.microsoft.com/azure/aks/supported-kubernetes-versions) for more details about the version lifecycle.

### [Get-AzContainerServiceAgentPoolUpgradeProfile](Get-AzContainerServiceAgentPoolUpgradeProfile.md)
Gets the upgrade profile for an agent pool.

### [Get-AzContainerServiceMaintenanceConfiguration](Get-AzContainerServiceMaintenanceConfiguration.md)
Gets the specified maintenance configuration of a managed cluster.

### [Get-AzContainerServiceManagedCluster](Get-AzContainerServiceManagedCluster.md)
Gets a managed cluster.

### [Get-AzContainerServiceManagedClusterAccessProfile](Get-AzContainerServiceManagedClusterAccessProfile.md)
**WARNING**: This API will be deprecated.
Instead use [ListClusterUserCredentials](https://docs.microsoft.com/rest/api/aks/managedclusters/listclusterusercredentials) or [ListClusterAdminCredentials](https://docs.microsoft.com/rest/api/aks/managedclusters/listclusteradmincredentials) .

### [Get-AzContainerServiceManagedClusterAdminCredentials](Get-AzContainerServiceManagedClusterAdminCredentials.md)
Lists the admin credentials of a managed cluster.

### [Get-AzContainerServiceManagedClusterCommandResult](Get-AzContainerServiceManagedClusterCommandResult.md)
Gets the results of a command which has been run on the Managed Cluster.

### [Get-AzContainerServiceManagedClusterKuberneteVersion](Get-AzContainerServiceManagedClusterKuberneteVersion.md)
Contains extra metadata on the version, including supported patch versions, capabilities, available upgrades, and details on preview status of the version

### [Get-AzContainerServiceManagedClusterMonitoringUserCredentials](Get-AzContainerServiceManagedClusterMonitoringUserCredentials.md)
Lists the cluster monitoring user credentials of a managed cluster.

### [Get-AzContainerServiceManagedClusterOSOption](Get-AzContainerServiceManagedClusterOSOption.md)
Gets supported OS options in the specified subscription.

### [Get-AzContainerServiceManagedClusterOutboundNetworkDependencyEndpoint](Get-AzContainerServiceManagedClusterOutboundNetworkDependencyEndpoint.md)
Gets a list of egress endpoints (network endpoints of all outbound dependencies) in the specified managed cluster.
The operation returns properties of each egress endpoint.

### [Get-AzContainerServiceManagedClusterUpgradeProfile](Get-AzContainerServiceManagedClusterUpgradeProfile.md)
Gets the upgrade profile of a managed cluster.

### [Get-AzContainerServiceManagedClusterUserCredentials](Get-AzContainerServiceManagedClusterUserCredentials.md)
Lists the user credentials of a managed cluster.

### [Get-AzContainerServicePrivateEndpointConnection](Get-AzContainerServicePrivateEndpointConnection.md)
To learn more about private clusters, see: https://docs.microsoft.com/azure/aks/private-clusters

### [Get-AzContainerServicePrivateLinkResource](Get-AzContainerServicePrivateLinkResource.md)
To learn more about private clusters, see: https://docs.microsoft.com/azure/aks/private-clusters

### [Get-AzContainerServiceSnapshot](Get-AzContainerServiceSnapshot.md)
Gets a snapshot.

### [Invoke-AzContainerServiceAbortAgentPoolLatestOperation](Invoke-AzContainerServiceAbortAgentPoolLatestOperation.md)
Aborts the currently running operation on the agent pool.
The Agent Pool will be moved to a Canceling state and eventually to a Canceled state when cancellation finishes.
If the operation completes before cancellation can take place, a 409 error code is returned.

### [Invoke-AzContainerServiceAbortManagedClusterLatestOperation](Invoke-AzContainerServiceAbortManagedClusterLatestOperation.md)
Aborts the currently running operation on the managed cluster.
The Managed Cluster will be moved to a Canceling state and eventually to a Canceled state when cancellation finishes.
If the operation completes before cancellation can take place, a 409 error code is returned.

### [Invoke-AzContainerServiceResolvePrivateLinkServiceId](Invoke-AzContainerServiceResolvePrivateLinkServiceId.md)
Gets the private link service ID for the specified managed cluster.

### [Invoke-AzContainerServiceRotateManagedClusterCertificate](Invoke-AzContainerServiceRotateManagedClusterCertificate.md)
See [Certificate rotation](https://docs.microsoft.com/azure/aks/certificate-rotation) for more details about rotating managed cluster certificates.

### [Invoke-AzContainerServiceRotateManagedClusterServiceAccountSigningKey](Invoke-AzContainerServiceRotateManagedClusterServiceAccountSigningKey.md)
Rotates the service account signing keys of a managed cluster.

### [New-AzContainerServiceAgentPool](New-AzContainerServiceAgentPool.md)
Creates or updates an agent pool in the specified managed cluster.

### [New-AzContainerServiceMaintenanceConfiguration](New-AzContainerServiceMaintenanceConfiguration.md)
Creates or updates a maintenance configuration in the specified managed cluster.

### [New-AzContainerServiceManagedCluster](New-AzContainerServiceManagedCluster.md)
Creates or updates a managed cluster.

### [New-AzContainerServiceSnapshot](New-AzContainerServiceSnapshot.md)
Creates or updates a snapshot.

### [Remove-AzContainerServiceAgentPool](Remove-AzContainerServiceAgentPool.md)
Deletes an agent pool in the specified managed cluster.

### [Remove-AzContainerServiceMaintenanceConfiguration](Remove-AzContainerServiceMaintenanceConfiguration.md)
Deletes a maintenance configuration.

### [Remove-AzContainerServiceManagedCluster](Remove-AzContainerServiceManagedCluster.md)
Deletes a managed cluster.

### [Remove-AzContainerServicePrivateEndpointConnection](Remove-AzContainerServicePrivateEndpointConnection.md)
Deletes a private endpoint connection.

### [Remove-AzContainerServiceSnapshot](Remove-AzContainerServiceSnapshot.md)
Deletes a snapshot.

### [Reset-AzContainerServiceManagedClusterAadProfile](Reset-AzContainerServiceManagedClusterAadProfile.md)
**WARNING**: This API will be deprecated.
Please see [AKS-managed Azure Active Directory integration](https://aka.ms/aks-managed-aad) to update your cluster with AKS-managed Azure AD.

### [Reset-AzContainerServiceManagedClusterServicePrincipalProfile](Reset-AzContainerServiceManagedClusterServicePrincipalProfile.md)
This action cannot be performed on a cluster that is not using a service principal

### [Start-AzContainerServiceManagedCluster](Start-AzContainerServiceManagedCluster.md)
See [starting a cluster](https://docs.microsoft.com/azure/aks/start-stop-cluster) for more details about starting a cluster.

### [Start-AzContainerServiceManagedClusterCommand](Start-AzContainerServiceManagedClusterCommand.md)
AKS will create a pod to run the command.
This is primarily useful for private clusters.
For more information see [AKS Run Command](https://docs.microsoft.com/azure/aks/private-clusters#aks-run-command-preview).

### [Stop-AzContainerServiceManagedCluster](Stop-AzContainerServiceManagedCluster.md)
This can only be performed on Azure Virtual Machine Scale set backed clusters.
Stopping a cluster stops the control plane and agent nodes entirely, while maintaining all object and cluster state.
A cluster does not accrue charges while it is stopped.
See [stopping a cluster](https://docs.microsoft.com/azure/aks/start-stop-cluster) for more details about stopping a cluster.

### [Update-AzContainerServiceAgentPoolNodeImageVersion](Update-AzContainerServiceAgentPoolNodeImageVersion.md)
Upgrading the node image version of an agent pool applies the newest OS and runtime updates to the nodes.
AKS provides one new image per week with the latest updates.
For more details on node image versions, see: https://docs.microsoft.com/azure/aks/node-image-upgrade

### [Update-AzContainerServiceManagedClusterTag](Update-AzContainerServiceManagedClusterTag.md)
Updates tags on a managed cluster.

### [Update-AzContainerServiceSnapshotTag](Update-AzContainerServiceSnapshotTag.md)
Updates tags on a snapshot.

