---
Module Name: Az.ContainerInstance
Module Guid: 8b44fa86-5aaa-4158-b61f-8a9eee32a1b5
Download Help Link: https://docs.microsoft.com/en-us/powershell/module/az.containerinstance
Help Version: 1.0.0.0
Locale: en-US
---

# Az.ContainerInstance Module
## Description
Microsoft Azure PowerShell: ContainerInstance cmdlets

## Az.ContainerInstance Cmdlets
### [Add-AzContainerInstanceContainer](Add-AzContainerInstanceContainer.md)
Attach to the output stream of a specific container instance in a specified resource group and container group.

### [Get-AzContainerInstanceContainerGroup](Get-AzContainerInstanceContainerGroup.md)
Gets the properties of the specified container group in the specified subscription and resource group.
The operation returns the properties of each container group including containers, image registry credentials, restart policy, IP address type, OS type, state, and volumes.

### [Get-AzContainerInstanceContainerGroupOutboundNetworkDependencyEndpoint](Get-AzContainerInstanceContainerGroupOutboundNetworkDependencyEndpoint.md)
Gets all the network dependencies for this container group to allow complete control of network setting and configuration.
For container groups, this will always be an empty list.

### [Get-AzContainerInstanceContainerLog](Get-AzContainerInstanceContainerLog.md)
Get the logs for a specified container instance in a specified resource group and container group.

### [Get-AzContainerInstanceLocationCachedImage](Get-AzContainerInstanceLocationCachedImage.md)
Get the list of cached images on specific OS type for a subscription in a region.

### [Get-AzContainerInstanceLocationCapability](Get-AzContainerInstanceLocationCapability.md)
Get the list of CPU/memory/GPU capabilities of a region.

### [Get-AzContainerInstanceLocationUsage](Get-AzContainerInstanceLocationUsage.md)
Get the usage for a subscription

### [Invoke-AzContainerInstanceExecuteContainerCommand](Invoke-AzContainerInstanceExecuteContainerCommand.md)
Executes a command for a specific container instance in a specified resource group and container group.

### [New-AzContainerInstanceContainerGroup](New-AzContainerInstanceContainerGroup.md)
Create or update container groups with specified configurations.

### [Remove-AzContainerInstanceContainerGroup](Remove-AzContainerInstanceContainerGroup.md)
Delete the specified container group in the specified subscription and resource group.
The operation does not delete other resources provided by the user, such as volumes.

### [Restart-AzContainerInstanceContainerGroup](Restart-AzContainerInstanceContainerGroup.md)
Restarts all containers in a container group in place.
If container image has updates, new image will be downloaded.

### [Start-AzContainerInstanceContainerGroup](Start-AzContainerInstanceContainerGroup.md)
Starts all containers in a container group.
Compute resources will be allocated and billing will start.

### [Stop-AzContainerInstanceContainerGroup](Stop-AzContainerInstanceContainerGroup.md)
Stops all containers in a container group.
Compute resources will be deallocated and billing will stop.

### [Update-AzContainerInstanceContainerGroup](Update-AzContainerInstanceContainerGroup.md)
Updates container group tags with specified values.

