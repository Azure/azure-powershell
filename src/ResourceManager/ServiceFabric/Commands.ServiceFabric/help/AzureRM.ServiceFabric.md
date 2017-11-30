---
Module Name: AzureRM.ServiceFabric
Module Guid: 60f3ba88-443f-46ff-88a3-318cfd11c1da
Download Help Link: {{Please enter FwLink manually}}
Help Version: {{Please enter version of help manually (X.X.X.X) format}}
Locale: en-US
---

# AzureRM.ServiceFabric Module
## Description
Azure Service Fabric Module that you can use to automate the end-2-end operations like creating a secure cluster, rolling over cluster certificates, adding or removed nodes from the cluster, etc. The complete list of all operations are listed below.

## AzureRM.ServiceFabric Cmdlets
### [Add-AzureRmServiceFabricApplicationCertificate](Add-AzureRmServiceFabricApplicationCertificate.md)
Add a new certificate to the Virtual Machine Scale Set(s) that make up the cluster. The certificate is intended to be used as an application certificate.

### [Add-AzureRmServiceFabricClientCertificate](Add-AzureRmServiceFabricClientCertificate.md)
Add common name or thumbprint to the cluster for client authentication purposes.

### [Add-AzureRmServiceFabricClusterCertificate](Add-AzureRmServiceFabricClusterCertificate.md)
Add a secondary cluster certificate to the cluster.

### [Add-AzureRmServiceFabricNode](Add-AzureRmServiceFabricNode.md)
Add nodes to the specific node type in the cluster.

### [Add-AzureRmServiceFabricNodeType](Add-AzureRmServiceFabricNodeType.md)
Add a new node type to the existing cluster.

### [Get-AzureRmServiceFabricCluster](Get-AzureRmServiceFabricCluster.md)
Get the cluster resource details.

### [New-AzureRmServiceFabricCluster](New-AzureRmServiceFabricCluster.md)
This command uses certificates that you provide or system generated self-signed certificates to set up a new service fabric cluster. It can use a default template or a custom template that you provide. You have the option of specifying a folder to export the self-signed certificates to or fetching them later from the key vault. 

### [Remove-AzureRmServiceFabricClientCertificate](Remove-AzureRmServiceFabricClientCertificate.md)
Remove a client certificate(s) or certificate subject(s) name(s) from being used for client authentication to the cluster.

### [Remove-AzureRmServiceFabricClusterCertificate](Remove-AzureRmServiceFabricClusterCertificate.md)
Remove a cluster certificate from being used for cluster security.

### [Remove-AzureRmServiceFabricNode](Remove-AzureRmServiceFabricNode.md)
Remove nodes from the specific node type from a cluster.

### [Remove-AzureRmServiceFabricNodeType](Remove-AzureRmServiceFabricNodeType.md)
Remove a complete node type from a cluster.

### [Remove-AzureRmServiceFabricSetting](Remove-AzureRmServiceFabricSetting.md)
Remove one or multiple Service Fabric setting from the cluster.

### [Set-AzureRmServiceFabricSetting](Set-AzureRmServiceFabricSetting.md)
Add or update one or multiple Service Fabric settings to the cluster.

### [Set-AzureRmServiceFabricUpgradeType](Set-AzureRmServiceFabricUpgradeType.md)
Change the Service Fabric upgrade type of the cluster.

### [Update-AzureRmServiceFabricDurability](Update-AzureRmServiceFabricDurability.md)
Update the durability tier or VmSku of a node type in the cluster.

### [Update-AzureRmServiceFabricReliability](Update-AzureRmServiceFabricReliability.md)
Update the reliability tier of the primary node type in a cluster.

