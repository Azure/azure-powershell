---
Module Name: Az.ServiceFabric
Module Guid: 60f3ba88-443f-46ff-88a3-318cfd11c1da
Download Help Link: https://docs.microsoft.com/powershell/module/az.servicefabric
Help Version: 0.3.4.0
Locale: en-US
---

# Az.ServiceFabric Module
## Description
Azure Service Fabric Module that you can use to automate the end-2-end operations like creating a secure cluster, rolling over cluster certificates, adding or removed nodes from the cluster, etc. The complete list of all operations are listed below.

## Az.ServiceFabric Cmdlets
### [Add-AzServiceFabricClientCertificate](Add-AzServiceFabricClientCertificate.md)
Add common name or thumbprint to the cluster for client authentication purposes.

### [Add-AzServiceFabricClusterCertificate](Add-AzServiceFabricClusterCertificate.md)
Add a secondary cluster certificate to the cluster.

### [Add-AzServiceFabricManagedClusterClientCertificate](Add-AzServiceFabricManagedClusterClientCertificate.md)
Add certificate common name or thumbprint to the cluster. This will register the certificate agains the cluster for client authentication purposes.

### [Add-AzServiceFabricManagedNodeTypeVMExtension](Add-AzServiceFabricManagedNodeTypeVMExtension.md)
Add vm extension to the node type.

### [Add-AzServiceFabricManagedNodeTypeVMSecret](Add-AzServiceFabricManagedNodeTypeVMSecret.md)
Add certificate secret to the node type.

### [Add-AzServiceFabricNode](Add-AzServiceFabricNode.md)
Add nodes to the specific node type in the cluster.

### [Add-AzServiceFabricNodeType](Add-AzServiceFabricNodeType.md)
Add a new node type to the existing cluster.

### [Get-AzServiceFabricApplication](Get-AzServiceFabricApplication.md)
Get Service Fabric application details.

### [Get-AzServiceFabricApplicationType](Get-AzServiceFabricApplicationType.md)
Get Service Fabric application type details.

### [Get-AzServiceFabricApplicationTypeVersion](Get-AzServiceFabricApplicationTypeVersion.md)
Get Service Fabric application type version details.

### [Get-AzServiceFabricCluster](Get-AzServiceFabricCluster.md)
Get the cluster resource details.

### [Get-AzServiceFabricManagedCluster](Get-AzServiceFabricManagedCluster.md)
Get the managed cluster resource details.

### [Get-AzServiceFabricManagedNodeType](Get-AzServiceFabricManagedNodeType.md)
Get the managed node type resource details.

### [Get-AzServiceFabricService](Get-AzServiceFabricService.md)
Get Service Fabric service details under the specified application and cluster.

### [New-AzServiceFabricApplication](New-AzServiceFabricApplication.md)
Create new service fabric application under the specified resource group and cluster.

### [New-AzServiceFabricApplicationType](New-AzServiceFabricApplicationType.md)
Create new service fabric application type under the specified resource group and cluster.

### [New-AzServiceFabricApplicationTypeVersion](New-AzServiceFabricApplicationTypeVersion.md)
Create new application type version under the specified resource group and cluster.

### [New-AzServiceFabricCluster](New-AzServiceFabricCluster.md)
This command uses certificates that you provide or system generated self-signed certificates to set up a new service fabric cluster. It can use a default template or a custom template that you provide. You have the option of specifying a folder to export the self-signed certificates to or fetching them later from the key vault.

### [New-AzServiceFabricManagedCluster](New-AzServiceFabricManagedCluster.md)
Create new managed cluster.

### [New-AzServiceFabricManagedNodeType](New-AzServiceFabricManagedNodeType.md)
Create new node type resource.

### [New-AzServiceFabricService](New-AzServiceFabricService.md)
Create new service fabric service under the specified application and cluster.

### [Remove-AzServiceFabricApplication](Remove-AzServiceFabricApplication.md)
Remove an application from the cluster. This will remove all the services under the application.

### [Remove-AzServiceFabricApplicationType](Remove-AzServiceFabricApplicationType.md)
Remove Service fabric an application type from the cluster. This will remove all type versions under this resource.

### [Remove-AzServiceFabricApplicationTypeVersion](Remove-AzServiceFabricApplicationTypeVersion.md)
Remove Service fabric an application type version from the cluster.

### [Remove-AzServiceFabricClientCertificate](Remove-AzServiceFabricClientCertificate.md)
Remove a client certificate(s) or certificate subject(s) name(s) from being used for client authentication to the cluster.

### [Remove-AzServiceFabricClusterCertificate](Remove-AzServiceFabricClusterCertificate.md)
Remove a cluster certificate from being used for cluster security.

### [Remove-AzServiceFabricManagedCluster](Remove-AzServiceFabricManagedCluster.md)
Remove cluster resource.

### [Remove-AzServiceFabricManagedClusterClientCertificate](Remove-AzServiceFabricManagedClusterClientCertificate.md)
Remvoe client certificate by thumbprint or common name.

### [Remove-AzServiceFabricManagedNodeType](Remove-AzServiceFabricManagedNodeType.md)
Remove the node type or specific nodes within the node type.

### [Remove-AzServiceFabricManagedNodeTypeVMExtension](Remove-AzServiceFabricManagedNodeTypeVMExtension.md)
Remove vm extension from the node type.

### [Remove-AzServiceFabricNode](Remove-AzServiceFabricNode.md)
Remove nodes from the specific node type from a cluster.

### [Remove-AzServiceFabricNodeType](Remove-AzServiceFabricNodeType.md)
Remove a complete node type from a cluster.

### [Remove-AzServiceFabricService](Remove-AzServiceFabricService.md)
Remove a service from the cluster.

### [Remove-AzServiceFabricSetting](Remove-AzServiceFabricSetting.md)
Remove one or multiple Service Fabric setting from the cluster.

### [Restart-AzServiceFabricManagedNodeType](Restart-AzServiceFabricManagedNodeType.md)
Restart specific nodes from the node type.

### [Set-AzServiceFabricManagedCluster](Set-AzServiceFabricManagedCluster.md)
Set cluster resource properties.

### [Set-AzServiceFabricManagedNodeType](Set-AzServiceFabricManagedNodeType.md)
Sets node type resource properties or run reimage actions on specific ndes of the node type with -Reimage parameter.

### [Set-AzServiceFabricSetting](Set-AzServiceFabricSetting.md)
Add or update one or multiple Service Fabric settings to the cluster.

### [Set-AzServiceFabricUpgradeType](Set-AzServiceFabricUpgradeType.md)
Change the Service Fabric upgrade type of the cluster.

### [Update-AzServiceFabricApplication](Update-AzServiceFabricApplication.md)
Update a service fabric application. This allows to update the application parameters and/or upgrade the application type version which will trigger an application upgrade.

### [Update-AzServiceFabricDurability](Update-AzServiceFabricDurability.md)
Update the durability tier or VmSku of a node type in the cluster.

### [Update-AzServiceFabricReliability](Update-AzServiceFabricReliability.md)
Update the reliability tier of the primary node type in a cluster.

