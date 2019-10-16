---
Module Name: Az.ContainerService
Module Guid: c085a869-b38e-4bd9-8804-4aac36a2c73d
Download Help Link: https://docs.microsoft.com/en-us/powershell/module/az.containerservice
Help Version: 1.0.0.0
Locale: en-US
---

# Az.ContainerService Module
## Description


## Az.ContainerService Cmdlets
### [Get-AzAgentPool](Get-AzAgentPool.md)
Gets the details of the agent pool by managed cluster and resource group.

### [Get-AzAgentPoolAvailableAgentPoolVersion](Get-AzAgentPoolAvailableAgentPoolVersion.md)
Gets a list of supported versions for the specified agent pool.

### [Get-AzAgentPoolUpgradeProfile](Get-AzAgentPoolUpgradeProfile.md)
Gets the details of the upgrade profile for an agent pool with a specified resource group and managed cluster name.

### [Get-AzContainerService](Get-AzContainerService.md)
Gets the properties of the specified container service in the specified subscription and resource group.
The operation returns the properties including state, orchestrator, number of masters and agents, and FQDNs of masters and agents.

### [Get-AzContainerServiceOrchestrator](Get-AzContainerServiceOrchestrator.md)
Gets a list of supported orchestrators in the specified subscription.
The operation returns properties of each orchestrator including version, available upgrades and whether that version or upgrades are in preview.

### [Get-AzManagedCluster](Get-AzManagedCluster.md)
Gets the details of the managed cluster with a specified resource group and name.

### [Get-AzManagedClusterAccessProfile](Get-AzManagedClusterAccessProfile.md)
Gets the accessProfile for the specified role name of the managed cluster with a specified resource group and name.

### [Get-AzManagedClusterAdminCredentials](Get-AzManagedClusterAdminCredentials.md)
Gets cluster admin credential of the managed cluster with a specified resource group and name.

### [Get-AzManagedClusterUpgradeProfile](Get-AzManagedClusterUpgradeProfile.md)
Gets the details of the upgrade profile for a managed cluster with a specified resource group and name.

### [Get-AzManagedClusterUserCredentials](Get-AzManagedClusterUserCredentials.md)
Gets cluster user credential of the managed cluster with a specified resource group and name.

### [New-AzAgentPool](New-AzAgentPool.md)
Creates or updates an agent pool in the specified managed cluster.

### [New-AzContainerService](New-AzContainerService.md)
Creates or updates a container service with the specified configuration of orchestrator, masters, and agents.

### [New-AzManagedCluster](New-AzManagedCluster.md)
Creates or updates a managed cluster with the specified configuration for agents and Kubernetes version.

### [Remove-AzAgentPool](Remove-AzAgentPool.md)
Deletes the agent pool in the specified managed cluster.

### [Remove-AzContainerService](Remove-AzContainerService.md)
Deletes the specified container service in the specified subscription and resource group.
The operation does not delete other resources created as part of creating a container service, including storage accounts, VMs, and availability sets.
All the other resources created with the container service are part of the same resource group and can be deleted individually.

### [Remove-AzManagedCluster](Remove-AzManagedCluster.md)
Deletes the managed cluster with a specified resource group and name.

### [Reset-AzManagedClusterAadProfile](Reset-AzManagedClusterAadProfile.md)
Update the AAD Profile for a managed cluster.

### [Reset-AzManagedClusterServicePrincipalProfile](Reset-AzManagedClusterServicePrincipalProfile.md)
Update the service principal Profile for a managed cluster.

### [Set-AzAgentPool](Set-AzAgentPool.md)
Creates or updates an agent pool in the specified managed cluster.

### [Set-AzContainerService](Set-AzContainerService.md)
Creates or updates a container service with the specified configuration of orchestrator, masters, and agents.

### [Set-AzManagedCluster](Set-AzManagedCluster.md)
Creates or updates a managed cluster with the specified configuration for agents and Kubernetes version.

### [Update-AzManagedClusterTag](Update-AzManagedClusterTag.md)
Updates a managed cluster with the specified tags.
