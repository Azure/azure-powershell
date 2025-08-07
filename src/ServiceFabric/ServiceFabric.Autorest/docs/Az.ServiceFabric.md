---
Module Name: Az.ServiceFabric
Module Guid: 9fa4154d-f588-4584-bc19-2cbb1b33861b
Download Help Link: https://learn.microsoft.com/powershell/module/az.servicefabric
Help Version: 1.0.0.0
Locale: en-US
---

# Az.ServiceFabric Module
## Description
Microsoft Azure PowerShell: ServiceFabric cmdlets

## Az.ServiceFabric Cmdlets
### [Get-AzServiceFabricManagedAzResiliencyStatus](Get-AzServiceFabricManagedAzResiliencyStatus.md)
Action to get Az Resiliency Status of all the Base resources constituting Service Fabric Managed Clusters.

### [Get-AzServiceFabricManagedCluster](Get-AzServiceFabricManagedCluster.md)
Get a Service Fabric managed cluster resource created or in the process of being created in the specified resource group.

### [Get-AzServiceFabricManagedClusterApplication](Get-AzServiceFabricManagedClusterApplication.md)
Get a Service Fabric managed application resource created or in the process of being created in the Service Fabric cluster resource.

### [Get-AzServiceFabricManagedClusterApplicationType](Get-AzServiceFabricManagedClusterApplicationType.md)
Get a Service Fabric application type name resource created or in the process of being created in the Service Fabric managed cluster resource.

### [Get-AzServiceFabricManagedClusterApplicationTypeVersion](Get-AzServiceFabricManagedClusterApplicationTypeVersion.md)
Get a Service Fabric managed application type version resource created or in the process of being created in the Service Fabric managed application type name resource.

### [Get-AzServiceFabricManagedClusterFaultSimulation](Get-AzServiceFabricManagedClusterFaultSimulation.md)
Gets a fault simulation by the simulationId.

### [Get-AzServiceFabricManagedClusterService](Get-AzServiceFabricManagedClusterService.md)
Get a Service Fabric service resource created or in the process of being created in the Service Fabric managed application resource.

### [Get-AzServiceFabricManagedClusterVersion](Get-AzServiceFabricManagedClusterVersion.md)
Gets information about an available Service Fabric cluster code version by environment.

### [Get-AzServiceFabricManagedMaintenanceWindowStatus](Get-AzServiceFabricManagedMaintenanceWindowStatus.md)
Action to get Maintenance Window Status of the Service Fabric Managed Clusters.

### [Get-AzServiceFabricManagedNodeType](Get-AzServiceFabricManagedNodeType.md)
Get a Service Fabric node type of a given managed cluster.

### [Get-AzServiceFabricManagedNodeTypeFaultSimulation](Get-AzServiceFabricManagedNodeTypeFaultSimulation.md)
Gets a fault simulation by the simulationId.

### [Get-AzServiceFabricManagedNodeTypeSku](Get-AzServiceFabricManagedNodeTypeSku.md)
Get a Service Fabric node type supported SKUs.

### [Get-AzServiceFabricManagedUnsupportedVMSize](Get-AzServiceFabricManagedUnsupportedVMSize.md)
Get unsupported vm size for Service Fabric Managed Clusters.

### [Get-AzServiceFabricOperationResult](Get-AzServiceFabricOperationResult.md)
Get long running operation result.

### [Get-AzServiceFabricOperationStatus](Get-AzServiceFabricOperationStatus.md)
Get long running operation status.

### [Invoke-AzServiceFabricDeallocateManagedNodeType](Invoke-AzServiceFabricDeallocateManagedNodeType.md)
Deallocates one or more nodes on the node type.
It will disable the fabric nodes, trigger a shutdown on the VMs and release them from the cluster.

### [Invoke-AzServiceFabricManagedApplyMaintenanceWindow](Invoke-AzServiceFabricManagedApplyMaintenanceWindow.md)
Action to Apply Maintenance window on the Service Fabric Managed Clusters, right now.
Any pending post will be applied.

### [Invoke-AzServiceFabricRedeployManagedNodeType](Invoke-AzServiceFabricRedeployManagedNodeType.md)
Redeploys one or more nodes on the node type.
It will disable the fabric nodes, trigger a shut down on the VMs, move them to a new node, and power them back on.

### [New-AzServiceFabricManagedCluster](New-AzServiceFabricManagedCluster.md)
Create a Service Fabric managed cluster resource with the specified name.

### [New-AzServiceFabricManagedClusterApplication](New-AzServiceFabricManagedClusterApplication.md)
Create a Service Fabric managed application resource with the specified name.

### [New-AzServiceFabricManagedClusterApplicationType](New-AzServiceFabricManagedClusterApplicationType.md)
Create a Service Fabric managed application type name resource with the specified name.

### [New-AzServiceFabricManagedClusterApplicationTypeVersion](New-AzServiceFabricManagedClusterApplicationTypeVersion.md)
Create a Service Fabric managed application type version resource with the specified name.

### [New-AzServiceFabricManagedClusterService](New-AzServiceFabricManagedClusterService.md)
Create a Service Fabric managed service resource with the specified name.

### [New-AzServiceFabricManagedNodeType](New-AzServiceFabricManagedNodeType.md)
Create a Service Fabric node type of a given managed cluster.

### [Read-AzServiceFabricManagedClusterApplicationUpgrade](Read-AzServiceFabricManagedClusterApplicationUpgrade.md)
Get the status of the latest application upgrade.
It will query the cluster to find the status of the latest application upgrade.

### [Remove-AzServiceFabricManagedCluster](Remove-AzServiceFabricManagedCluster.md)
Delete a Service Fabric managed cluster resource with the specified name.

### [Remove-AzServiceFabricManagedClusterApplication](Remove-AzServiceFabricManagedClusterApplication.md)
Delete a Service Fabric managed application resource with the specified name.

### [Remove-AzServiceFabricManagedClusterApplicationType](Remove-AzServiceFabricManagedClusterApplicationType.md)
Delete a Service Fabric managed application type name resource with the specified name.

### [Remove-AzServiceFabricManagedClusterApplicationTypeVersion](Remove-AzServiceFabricManagedClusterApplicationTypeVersion.md)
Delete a Service Fabric managed application type version resource with the specified name.

### [Remove-AzServiceFabricManagedClusterService](Remove-AzServiceFabricManagedClusterService.md)
Delete a Service Fabric managed service resource with the specified name.

### [Remove-AzServiceFabricManagedNodeType](Remove-AzServiceFabricManagedNodeType.md)
Delete a Service Fabric node type of a given managed cluster.

### [Remove-AzServiceFabricManagedNodeTypeNode](Remove-AzServiceFabricManagedNodeTypeNode.md)
Deletes one or more nodes on the node type.
It will disable the fabric nodes, trigger a delete on the VMs and removes the state from the cluster.

### [Restart-AzServiceFabricManagedNodeType](Restart-AzServiceFabricManagedNodeType.md)
Restarts one or more nodes on the node type.
It will disable the fabric nodes, trigger a restart on the VMs and activate the nodes back again.

### [Resume-AzServiceFabricManagedClusterApplicationUpgrade](Resume-AzServiceFabricManagedClusterApplicationUpgrade.md)
Send a request to resume the current application upgrade.
This will resume the application upgrade from where it was paused.

### [Start-AzServiceFabricManagedClusterApplicationRollback](Start-AzServiceFabricManagedClusterApplicationRollback.md)
Send a request to start a rollback of the current application upgrade.
This will start rolling back the application to the previous version.

### [Start-AzServiceFabricManagedClusterFaultSimulation](Start-AzServiceFabricManagedClusterFaultSimulation.md)
Starts a fault simulation on the cluster.

### [Start-AzServiceFabricManagedNodeType](Start-AzServiceFabricManagedNodeType.md)
Starts one or more nodes on the node type.
It will trigger an allocation of the fabric node if needed and activate them.

### [Start-AzServiceFabricManagedNodeTypeFaultSimulation](Start-AzServiceFabricManagedNodeTypeFaultSimulation.md)
Starts a fault simulation on the node type.

### [Stop-AzServiceFabricManagedClusterFaultSimulation](Stop-AzServiceFabricManagedClusterFaultSimulation.md)
Stops a fault simulation on the cluster.

### [Stop-AzServiceFabricManagedNodeTypeFaultSimulation](Stop-AzServiceFabricManagedNodeTypeFaultSimulation.md)
Stops a fault simulation on the node type.

### [Update-AzServiceFabricManagedCluster](Update-AzServiceFabricManagedCluster.md)
Update the tags of of a Service Fabric managed cluster resource with the specified name.

### [Update-AzServiceFabricManagedClusterApplication](Update-AzServiceFabricManagedClusterApplication.md)
Update the tags of an application resource of a given managed cluster.

### [Update-AzServiceFabricManagedClusterApplicationType](Update-AzServiceFabricManagedClusterApplicationType.md)
Update the tags of an application type resource of a given managed cluster.

### [Update-AzServiceFabricManagedClusterApplicationTypeVersion](Update-AzServiceFabricManagedClusterApplicationTypeVersion.md)
Update the tags of an application type version resource of a given managed cluster.

### [Update-AzServiceFabricManagedClusterService](Update-AzServiceFabricManagedClusterService.md)
Update the tags of a service resource of a given managed cluster.

### [Update-AzServiceFabricManagedNodeType](Update-AzServiceFabricManagedNodeType.md)
Reimages one or more nodes on the node type.
It will disable the fabric nodes, trigger a reimage on the VMs and activate the nodes back again.

