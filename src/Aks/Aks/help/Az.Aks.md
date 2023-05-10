---
Module Name: Az.Aks
Module Guid: a97e0c3e-e389-46a6-b73d-2b9bd6909bdb
Download Help Link: https://learn.microsoft.com/powershell/module/az.aks
Help Version: 0.0.1.0
Locale: en-US
---

# Az.Aks Module
## Description
Commands to interact with Azure managed Kubernetes clusters.

## Az.Aks Cmdlets
### [Disable-AzAksAddOn](Disable-AzAksAddOn.md)
Disable the addons for aks.

### [Enable-AzAksAddOn](Enable-AzAksAddOn.md)
Enable the addons for aks.

### [Get-AzAksCluster](Get-AzAksCluster.md)
List Kubernetes managed clusters.

### [Get-AzAksMaintenanceConfiguration](Get-AzAksMaintenanceConfiguration.md)
Gets the specified maintenance configuration of a managed cluster.

### [Get-AzAksManagedClusterCommandResult](Get-AzAksManagedClusterCommandResult.md)
Gets the results of a command which has been run on the Managed Cluster.

### [Get-AzAksManagedClusterOSOption](Get-AzAksManagedClusterOSOption.md)
Gets supported OS options in the specified subscription.

### [Get-AzAksManagedClusterOutboundNetworkDependencyEndpoint](Get-AzAksManagedClusterOutboundNetworkDependencyEndpoint.md)
Gets a list of egress endpoints (network endpoints of all outbound dependencies) in the specified managed cluster.
The operation returns properties of each egress endpoint.

### [Get-AzAksNodePool](Get-AzAksNodePool.md)
List node pools in specified cluster.

### [Get-AzAksNodePoolUpgradeProfile](Get-AzAksNodePoolUpgradeProfile.md)
Gets the upgrade profile for an agent pool.

### [Get-AzAksSnapshot](Get-AzAksSnapshot.md)
Gets a snapshot.

### [Get-AzAksUpgradeProfile](Get-AzAksUpgradeProfile.md)
Gets the upgrade profile of a managed cluster.

### [Get-AzAksVersion](Get-AzAksVersion.md)
List available version for creating managed Kubernetes cluster.
The operation returns properties of each orchestrator including version, available upgrades and whether that version or upgrades are in preview.

### [Import-AzAksCredential](Import-AzAksCredential.md)
Import and merge Kubectl config for a managed Kubernetes Cluster.

### [Install-AzAksCliTool](Install-AzAksCliTool.md)
Download and install kubectl and kubelogin.

### [Invoke-AzAksAbortAgentPoolLatestOperation](Invoke-AzAksAbortAgentPoolLatestOperation.md)
Aborts the currently running operation on the agent pool.
The Agent Pool will be moved to a Canceling state and eventually to a Canceled state when cancellation finishes.
If the operation completes before cancellation can take place, a 409 error code is returned.

### [Invoke-AzAksAbortManagedClusterLatestOperation](Invoke-AzAksAbortManagedClusterLatestOperation.md)
Aborts the currently running operation on the managed cluster.
The Managed Cluster will be moved to a Canceling state and eventually to a Canceled state when cancellation finishes.
If the operation completes before cancellation can take place, a 409 error code is returned.

### [Invoke-AzAksRotateManagedClusterServiceAccountSigningKey](Invoke-AzAksRotateManagedClusterServiceAccountSigningKey.md)
Rotates the service account signing keys of a managed cluster.

### [Invoke-AzAksRunCommand](Invoke-AzAksRunCommand.md)
Run a shell command (with kubectl, helm) on your aks cluster, support attaching files as well.

### [New-AzAksCluster](New-AzAksCluster.md)
Create a new managed Kubernetes cluster.

The cmdlet may call below Microsoft Graph API according to input parameters:

- POST /servicePrincipals

### [New-AzAksMaintenanceConfiguration](New-AzAksMaintenanceConfiguration.md)
Creates or updates a maintenance configuration in the specified managed cluster.

### [New-AzAksNodePool](New-AzAksNodePool.md)
Create a new node pool in specified cluster.

### [New-AzAksSnapshot](New-AzAksSnapshot.md)
Creates or updates a snapshot.

### [New-AzAksTimeInWeekObject](New-AzAksTimeInWeekObject.md)
Create an in-memory object for TimeInWeek.

### [New-AzAksTimeSpanObject](New-AzAksTimeSpanObject.md)
Create an in-memory object for TimeSpan.

### [Remove-AzAksCluster](Remove-AzAksCluster.md)
Delete a managed Kubernetes cluster.

### [Remove-AzAksMaintenanceConfiguration](Remove-AzAksMaintenanceConfiguration.md)
Deletes a maintenance configuration.

### [Remove-AzAksNodePool](Remove-AzAksNodePool.md)
Delete node pool from managed cluster.

### [Remove-AzAksSnapshot](Remove-AzAksSnapshot.md)
Deletes a snapshot.

### [Set-AzAksCluster](Set-AzAksCluster.md)
Update or create a managed Kubernetes cluster.

### [Set-AzAksClusterCredential](Set-AzAksClusterCredential.md)
Reset the ServicePrincipal of an existing AKS cluster.

### [Start-AzAksCluster](Start-AzAksCluster.md)
See [starting a cluster](https://docs.microsoft.com/azure/aks/start-stop-cluster) for more details about starting a cluster.

### [Start-AzAksDashboard](Start-AzAksDashboard.md)
Create a Kubectl SSH tunnel to the managed cluster's dashboard.

### [Start-AzAksManagedClusterCommand](Start-AzAksManagedClusterCommand.md)
AKS will create a pod to run the command.
This is primarily useful for private clusters.
For more information see [AKS Run Command](https://docs.microsoft.com/azure/aks/private-clusters#aks-run-command-preview).

### [Stop-AzAksCluster](Stop-AzAksCluster.md)
This can only be performed on Azure Virtual Machine Scale set backed clusters.
Stopping a cluster stops the control plane and agent nodes entirely, while maintaining all object and cluster state.
A cluster does not accrue charges while it is stopped.
See [stopping a cluster](https://docs.microsoft.com/azure/aks/start-stop-cluster) for more details about stopping a cluster.

### [Stop-AzAksDashboard](Stop-AzAksDashboard.md)
Stop the Kubectl SSH tunnel created in Start-AzKubernetesDashboard.

### [Update-AzAksNodePool](Update-AzAksNodePool.md)
Update node pool in a managed cluster.

