---
Module Name: AzureRM.ServiceFabric
Module Guid: 60f3ba88-443f-46ff-88a3-318cfd11c1da
Download Help Link: {{Please enter FwLink manually}}
Help Version: {{Please enter version of help manually (X.X.X.X) format}}
Locale: en-US
---

# AzureRM.ServiceFabric Module
## Description
Azure Service Fabric Module that you can use to automate the end-2-end operations like creating a secure cluster, rolling over cluster certificates, adding or removed nodes from the cluster etc. the complete list of all operations are listed below.

## AzureRM.ServiceFabric Cmdlets
### [Add-AzureRmServiceFabricApplicationCertificate](Add-AzureRmServiceFabricApplicationCertificate.md)
Add an certificate which will be used as application certificate

### [Add-AzureRmServiceFabricClientCertificate](Add-AzureRmServiceFabricClientCertificate.md)
Add common name or thumbprint to the cluster settings for client authentication

### [Add-AzureRmServiceFabricClusterCertificate](Add-AzureRmServiceFabricClusterCertificate.md)
Add a secondary cluster certificate to the cluster for rolling over the existing certificate 

### [Add-AzureRmServiceFabricNode](Add-AzureRmServiceFabricNode.md)
Add nodes/VMs to a specific node type to a cluster

### [Add-AzureRmServiceFabricNodeType](Add-AzureRmServiceFabricNodeType.md)
Add a node type/VMs to an existing cluster

### [Get-AzureRmServiceFabricCluster](Get-AzureRmServiceFabricCluster.md)
Get the details of the cluster resource 

### [New-AzureRmServiceFabricCluster](New-AzureRmServiceFabricCluster.md)
Create an new ServiceFabric cluster. This command has many overloads to cover various scenarios

### [Remove-AzureRmServiceFabricClientCertificate](Remove-AzureRmServiceFabricClientCertificate.md)
Remove client certificate from being used to access the cluster

### [Remove-AzureRmServiceFabricClusterCertificate](Remove-AzureRmServiceFabricClusterCertificate.md)
Remove cluster certificate from being used for cluster security

### [Remove-AzureRmServiceFabricNode](Remove-AzureRmServiceFabricNode.md)
Remove nodes from the specific node type from a cluster

### [Remove-AzureRmServiceFabricNodeType](Remove-AzureRmServiceFabricNodeType.md)
Remove a node type from a cluster

### [Remove-AzureRmServiceFabricSetting](Remove-AzureRmServiceFabricSetting.md)
Remove one or more ServiceFabric settings from the cluster

### [Set-AzureRmServiceFabricSetting](Set-AzureRmServiceFabricSetting.md)
Add or update one or more ServiceFabric settings to the cluster

### [Set-AzureRmServiceFabricUpgradeType](Set-AzureRmServiceFabricUpgradeType.md)
Change the ServiceFabric upgrade type of a cluster

### [Update-AzureRmServiceFabricDurability](Update-AzureRmServiceFabricDurability.md)
Change the durability tier of a cluster

### [Update-AzureRmServiceFabricReliability](Update-AzureRmServiceFabricReliability.md)
Change the reliability tier of a cluster