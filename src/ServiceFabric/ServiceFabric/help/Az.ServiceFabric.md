---
Module Name: Az.ServiceFabric
Module Guid: 60f3ba88-443f-46ff-88a3-318cfd11c1da
Download Help Link: https://learn.microsoft.com/powershell/module/az.servicefabric
Help Version: 0.3.4.0
Locale: en-US
---

# Az.ServiceFabric Module
## Description
Azure Service Fabric Module that you can use to automate the end-2-end operations like creating a secure cluster, rolling over cluster certificates, adding or removed nodes from the cluster, etc. The complete list of all operations are listed below.

## Az.ServiceFabric Cmdlets
### [Add-AzServiceFabricClientCertificate](Add-AzServiceFabricClientCertificate.md)
Add common name or thumbprint to the cluster for client authentication purposes.

### [Add-AzServiceFabricManagedClusterClientCertificate](Add-AzServiceFabricManagedClusterClientCertificate.md)
Add certificate common name or thumbprint to the cluster. This will register the certificate against the cluster for client authentication purposes.

### [Add-AzServiceFabricManagedClusterNetworkSecurityRule](Add-AzServiceFabricManagedClusterNetworkSecurityRule.md)
Add network security rule to cluster resource.

### [Add-AzServiceFabricManagedNodeTypeVMExtension](Add-AzServiceFabricManagedNodeTypeVMExtension.md)
Add vm extension to the node type.

### [Add-AzServiceFabricManagedNodeTypeVMSecret](Add-AzServiceFabricManagedNodeTypeVMSecret.md)
Add certificate secret to the node type.

### [Add-AzServiceFabricNode](Add-AzServiceFabricNode.md)
Add nodes to the specific node type in the cluster.

### [Add-AzServiceFabricNodeType](Add-AzServiceFabricNodeType.md)
Add a new node type to the existing cluster.

### [Get-AzServiceFabricApplication](Get-AzServiceFabricApplication.md)
Get Service Fabric application details. Only supports ARM deployed applications.

### [Get-AzServiceFabricApplicationType](Get-AzServiceFabricApplicationType.md)
Get Service Fabric application type details. Only supports ARM deployed application types.

### [Get-AzServiceFabricApplicationTypeVersion](Get-AzServiceFabricApplicationTypeVersion.md)
Get Service Fabric application type version details. Only supports ARM deployed application type versions.

### [Get-AzServiceFabricCluster](Get-AzServiceFabricCluster.md)
Get the cluster resource details.

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

### [Get-AzServiceFabricService](Get-AzServiceFabricService.md)
Get Service Fabric service details under the specified application and cluster. Only supports ARM deployed services.

### [Invoke-AzServiceFabricDeallocateManagedNodeType](Invoke-AzServiceFabricDeallocateManagedNodeType.md)
Deallocates one or more nodes on the node type.
It will disable the fabric nodes, trigger a shutdown on the VMs and release them from the cluster.

### [Invoke-AzServiceFabricManagedApplyMaintenanceWindow](Invoke-AzServiceFabricManagedApplyMaintenanceWindow.md)
Action to Apply Maintenance window on the Service Fabric Managed Clusters, right now.
Any pending post will be applied.

### [Invoke-AzServiceFabricRedeployManagedNodeType](Invoke-AzServiceFabricRedeployManagedNodeType.md)
Redeploys one or more nodes on the node type.
It will disable the fabric nodes, trigger a shut down on the VMs, move them to a new node, and power them back on.

### [New-AzServiceFabricApplication](New-AzServiceFabricApplication.md)
Create new service fabric application under the specified resource group and cluster.

### [New-AzServiceFabricApplicationType](New-AzServiceFabricApplicationType.md)
Create new service fabric application type under the specified resource group and cluster.

### [New-AzServiceFabricApplicationTypeVersion](New-AzServiceFabricApplicationTypeVersion.md)
Create new application type version under the specified resource group and cluster.

### [New-AzServiceFabricCluster](New-AzServiceFabricCluster.md)
This command uses certificates that you provide or system generated self-signed certificates to set up a new service fabric cluster. It can use a default template or a custom template that you provide. You have the option of specifying a folder to export the self-signed certificates to or fetching them later from the key vault.

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

### [New-AzServiceFabricService](New-AzServiceFabricService.md)
Create new service fabric service under the specified application and cluster.

### [Read-AzServiceFabricManagedClusterApplicationUpgrade](Read-AzServiceFabricManagedClusterApplicationUpgrade.md)
Get the status of the latest application upgrade.
It will query the cluster to find the status of the latest application upgrade.

### [Remove-AzServiceFabricApplication](Remove-AzServiceFabricApplication.md)
Remove an application from the cluster. This will remove all the services under the application. Only supports ARM deployed applications.

### [Remove-AzServiceFabricApplicationType](Remove-AzServiceFabricApplicationType.md)
Remove Service fabric an application type from the cluster. This will remove all type versions under this resource. Only supports ARM deployed application types.

### [Remove-AzServiceFabricApplicationTypeVersion](Remove-AzServiceFabricApplicationTypeVersion.md)
Remove Service fabric an application type version from the cluster. Only supports ARM deployed application type versions.

### [Remove-AzServiceFabricClientCertificate](Remove-AzServiceFabricClientCertificate.md)
Remove a client certificate(s) or certificate subject(s) name(s) from being used for client authentication to the cluster.

### [Remove-AzServiceFabricManagedCluster](Remove-AzServiceFabricManagedCluster.md)
Delete a Service Fabric managed cluster resource with the specified name.

### [Remove-AzServiceFabricManagedClusterApplication](Remove-AzServiceFabricManagedClusterApplication.md)
Delete a Service Fabric managed application resource with the specified name.

### [Remove-AzServiceFabricManagedClusterApplicationType](Remove-AzServiceFabricManagedClusterApplicationType.md)
Delete a Service Fabric managed application type name resource with the specified name.

### [Remove-AzServiceFabricManagedClusterApplicationTypeVersion](Remove-AzServiceFabricManagedClusterApplicationTypeVersion.md)
Delete a Service Fabric managed application type version resource with the specified name.

### [Remove-AzServiceFabricManagedClusterClientCertificate](Remove-AzServiceFabricManagedClusterClientCertificate.md)
Remove client certificate by thumbprint or common name.

### [Remove-AzServiceFabricManagedClusterService](Remove-AzServiceFabricManagedClusterService.md)
Delete a Service Fabric managed service resource with the specified name.

### [Remove-AzServiceFabricManagedNodeType](Remove-AzServiceFabricManagedNodeType.md)
Delete a Service Fabric node type of a given managed cluster.

### [Remove-AzServiceFabricManagedNodeTypeNode](Remove-AzServiceFabricManagedNodeTypeNode.md)
Deletes one or more nodes on the node type.
It will disable the fabric nodes, trigger a delete on the VMs and removes the state from the cluster.

### [Remove-AzServiceFabricManagedNodeTypeVMExtension](Remove-AzServiceFabricManagedNodeTypeVMExtension.md)
Remove vm extension from the node type.

### [Remove-AzServiceFabricNode](Remove-AzServiceFabricNode.md)
Remove nodes from the specific node type from a cluster.

### [Remove-AzServiceFabricNodeType](Remove-AzServiceFabricNodeType.md)
Remove a complete node type from a cluster.

### [Remove-AzServiceFabricService](Remove-AzServiceFabricService.md)
Remove a service from the cluster. Only supports ARM deployed services.

### [Remove-AzServiceFabricSetting](Remove-AzServiceFabricSetting.md)
Remove one or multiple Service Fabric setting from the cluster.

### [Restart-AzServiceFabricManagedNodeType](Restart-AzServiceFabricManagedNodeType.md)
Restarts one or more nodes on the node type.
It will disable the fabric nodes, trigger a restart on the VMs and activate the nodes back again.

### [Resume-AzServiceFabricManagedClusterApplicationUpgrade](Resume-AzServiceFabricManagedClusterApplicationUpgrade.md)
Send a request to resume the current application upgrade.
This will resume the application upgrade from where it was paused.

### [Set-AzServiceFabricManagedCluster](Set-AzServiceFabricManagedCluster.md)
Set cluster resource properties.

### [Set-AzServiceFabricManagedClusterApplication](Set-AzServiceFabricManagedClusterApplication.md)
Update a service fabric managed application. This allows to update the application parameters and/or upgrade the application type version which will trigger an application upgrade or other configuration only updates. Only supports ARM deployed applications.

### [Set-AzServiceFabricManagedClusterApplicationType](Set-AzServiceFabricManagedClusterApplicationType.md)
Update a service fabric managed application type. This allows you to update the tags. Only supports ARM deployed application types.

### [Set-AzServiceFabricManagedClusterApplicationTypeVersion](Set-AzServiceFabricManagedClusterApplicationTypeVersion.md)
Update a service fabric managed application type version. This allows you to update the tags and package Url. Only supports ARM deployed application type versions.

### [Set-AzServiceFabricManagedClusterService](Set-AzServiceFabricManagedClusterService.md)
Update a managed service from the cluster. Only supports ARM deployed services.

### [Set-AzServiceFabricManagedNodeType](Set-AzServiceFabricManagedNodeType.md)
Sets node type resource properties or run reimage actions on specific nodes of the node type with -Reimage parameter.

### [Set-AzServiceFabricSetting](Set-AzServiceFabricSetting.md)
Add or update one or multiple Service Fabric settings to the cluster.

### [Set-AzServiceFabricUpgradeType](Set-AzServiceFabricUpgradeType.md)
Change the Service Fabric upgrade type of the cluster.

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

### [Update-AzServiceFabricApplication](Update-AzServiceFabricApplication.md)
Update a service fabric application. This allows to update the application parameters and/or upgrade the application type version which will trigger an application upgrade. Only supports ARM deployed applications.

### [Update-AzServiceFabricDurability](Update-AzServiceFabricDurability.md)
Update the durability tier or VmSku of a node type in the cluster.

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

### [Update-AzServiceFabricNodeType](Update-AzServiceFabricNodeType.md)
Update a node type within the cluster.

### [Update-AzServiceFabricReliability](Update-AzServiceFabricReliability.md)
Update the reliability tier of the primary node type in a cluster.

### [Update-AzServiceFabricVmImage](Update-AzServiceFabricVmImage.md)
Update the cluster resource vmImage setting which maps the appropriate runtime package to be delivered based on the target operating system.

