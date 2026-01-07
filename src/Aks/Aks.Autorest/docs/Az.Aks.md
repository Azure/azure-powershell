---
Module Name: Az.Aks
Module Guid: 57b3133d-0bb4-4706-9f5b-371bbb17b1de
Download Help Link: https://learn.microsoft.com/powershell/module/az.aks
Help Version: 1.0.0.0
Locale: en-US
---

# Az.Aks Module
## Description
Microsoft Azure PowerShell: Aks cmdlets

## Az.Aks Cmdlets
### [Get-AzAksMachine](Get-AzAksMachine.md)
Get a specific machine in the specified agent pool.

### [Get-AzAksMaintenanceConfiguration](Get-AzAksMaintenanceConfiguration.md)
Gets the specified maintenance configuration of a managed cluster.

### [Get-AzAksManagedClusterCommandResult](Get-AzAksManagedClusterCommandResult.md)
Gets the results of a command which has been run on the Managed Cluster.

### [Get-AzAksManagedClusterKuberneteVersion](Get-AzAksManagedClusterKuberneteVersion.md)
Contains extra metadata on the version, including supported patch versions, capabilities, available upgrades, and details on preview status of the version

### [Get-AzAksManagedClusterMeshRevisionProfile](Get-AzAksManagedClusterMeshRevisionProfile.md)
Contains extra metadata on the revision, including supported revisions, cluster compatibility and available upgrades

### [Get-AzAksManagedClusterMeshUpgradeProfile](Get-AzAksManagedClusterMeshUpgradeProfile.md)
Gets available upgrades for a service mesh in a cluster.

### [Get-AzAksManagedClusterOutboundNetworkDependencyEndpoint](Get-AzAksManagedClusterOutboundNetworkDependencyEndpoint.md)
Gets a list of egress endpoints (network endpoints of all outbound dependencies) in the specified managed cluster.
The operation returns properties of each egress endpoint.

### [Get-AzAksNodePoolUpgradeProfile](Get-AzAksNodePoolUpgradeProfile.md)
Gets the upgrade profile for an agent pool.

### [Get-AzAksSnapshot](Get-AzAksSnapshot.md)
Gets a snapshot.

### [Get-AzAksTrustedAccessRole](Get-AzAksTrustedAccessRole.md)
List supported trusted access roles.

### [Get-AzAksTrustedAccessRoleBinding](Get-AzAksTrustedAccessRoleBinding.md)
Get a trusted access role binding.

### [Get-AzAksUpgradeProfile](Get-AzAksUpgradeProfile.md)
Gets the upgrade profile of a managed cluster.

### [Get-AzAksVersion](Get-AzAksVersion.md)
List available version for creating managed Kubernetes cluster.
The operation returns properties of each orchestrator including version, available upgrades and whether that version or upgrades are in preview.

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

### [New-AzAksMaintenanceConfiguration](New-AzAksMaintenanceConfiguration.md)
Create a maintenance configuration in the specified managed cluster.

### [New-AzAksSnapshot](New-AzAksSnapshot.md)
Create a snapshot.

### [New-AzAksTimeInWeekObject](New-AzAksTimeInWeekObject.md)
Create an in-memory object for TimeInWeek.

### [New-AzAksTimeSpanObject](New-AzAksTimeSpanObject.md)
Create an in-memory object for TimeSpan.

### [New-AzAksTrustedAccessRoleBinding](New-AzAksTrustedAccessRoleBinding.md)
Create a trusted access role binding

### [Remove-AzAksAgentPoolMachine](Remove-AzAksAgentPoolMachine.md)
Deletes specific machines in an agent pool.

### [Remove-AzAksMaintenanceConfiguration](Remove-AzAksMaintenanceConfiguration.md)
Deletes a maintenance configuration.

### [Remove-AzAksSnapshot](Remove-AzAksSnapshot.md)
Deletes a snapshot.

### [Remove-AzAksTrustedAccessRoleBinding](Remove-AzAksTrustedAccessRoleBinding.md)
Delete a trusted access role binding.

### [Start-AzAksCluster](Start-AzAksCluster.md)
See [starting a cluster](https://docs.microsoft.com/azure/aks/start-stop-cluster) for more details about starting a cluster.

### [Start-AzAksManagedClusterCommand](Start-AzAksManagedClusterCommand.md)
AKS will run a pod to run the command.
This is primarily useful for private clusters.
For more information see [AKS Run Command](https://docs.microsoft.com/azure/aks/private-clusters#aks-run-command-preview).

### [Stop-AzAksCluster](Stop-AzAksCluster.md)
This can only be performed on Azure Virtual Machine Scale set backed clusters.
Stopping a cluster stops the control plane and agent nodes entirely, while maintaining all object and cluster state.
A cluster does not accrue charges while it is stopped.
See [stopping a cluster](https://docs.microsoft.com/azure/aks/start-stop-cluster) for more details about stopping a cluster.

### [Update-AzAksMaintenanceConfiguration](Update-AzAksMaintenanceConfiguration.md)
Update a maintenance configuration in the specified managed cluster.

### [Update-AzAksTrustedAccessRoleBinding](Update-AzAksTrustedAccessRoleBinding.md)
Update a trusted access role binding

