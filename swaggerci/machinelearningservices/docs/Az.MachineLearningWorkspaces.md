---
Module Name: Az.MachineLearningWorkspaces
Module Guid: de6f0bb1-4329-4515-9334-da214c66c970
Download Help Link: https://docs.microsoft.com/en-us/powershell/module/az.machinelearningworkspaces
Help Version: 1.0.0.0
Locale: en-US
---

# Az.MachineLearningWorkspaces Module
## Description
Microsoft Azure PowerShell: MachineLearningWorkspaces cmdlets

## Az.MachineLearningWorkspaces Cmdlets
### [Get-AzMachineLearningWorkspacesCompute](Get-AzMachineLearningWorkspacesCompute.md)
Gets compute definition by its name.
Any secrets (storage keys, service credentials, etc) are not returned - use 'keys' nested resource to get them.

### [Get-AzMachineLearningWorkspacesComputeKey](Get-AzMachineLearningWorkspacesComputeKey.md)
Gets secrets related to Machine Learning compute (storage keys, service credentials, etc).

### [Get-AzMachineLearningWorkspacesComputeNode](Get-AzMachineLearningWorkspacesComputeNode.md)
Get the details (e.g IP address, port etc) of all the compute nodes in the compute.

### [Get-AzMachineLearningWorkspacesPrivateEndpointConnection](Get-AzMachineLearningWorkspacesPrivateEndpointConnection.md)
Gets the specified private endpoint connection associated with the workspace.

### [Get-AzMachineLearningWorkspacesPrivateLinkResource](Get-AzMachineLearningWorkspacesPrivateLinkResource.md)
Gets the private link resources that need to be created for a workspace.

### [Get-AzMachineLearningWorkspacesQuota](Get-AzMachineLearningWorkspacesQuota.md)
Gets the currently assigned Workspace Quotas based on VMFamily.

### [Get-AzMachineLearningWorkspacesUsage](Get-AzMachineLearningWorkspacesUsage.md)
Gets the current usage information as well as limits for AML resources for given subscription and location.

### [Get-AzMachineLearningWorkspacesVirtualMachineSize](Get-AzMachineLearningWorkspacesVirtualMachineSize.md)
Returns supported VM Sizes in a location

### [Get-AzMachineLearningWorkspacesWorkspace](Get-AzMachineLearningWorkspacesWorkspace.md)
Gets the properties of the specified machine learning workspace.

### [Get-AzMachineLearningWorkspacesWorkspaceConnection](Get-AzMachineLearningWorkspacesWorkspaceConnection.md)
Get the detail of a workspace connection.

### [Get-AzMachineLearningWorkspacesWorkspaceFeature](Get-AzMachineLearningWorkspacesWorkspaceFeature.md)
Lists all enabled features for a workspace

### [Get-AzMachineLearningWorkspacesWorkspaceKey](Get-AzMachineLearningWorkspacesWorkspaceKey.md)
Lists all the keys associated with this workspace.
This includes keys for the storage account, app insights and password for container registry

### [Get-AzMachineLearningWorkspacesWorkspaceNotebookAccessToken](Get-AzMachineLearningWorkspacesWorkspaceNotebookAccessToken.md)
return notebook access token and refresh token

### [Get-AzMachineLearningWorkspacesWorkspaceNotebookKey](Get-AzMachineLearningWorkspacesWorkspaceNotebookKey.md)
List keys of a notebook.

### [Get-AzMachineLearningWorkspacesWorkspaceOutboundNetworkDependencyEndpoint](Get-AzMachineLearningWorkspacesWorkspaceOutboundNetworkDependencyEndpoint.md)
Called by Client (Portal, CLI, etc) to get a list of all external outbound dependencies (FQDNs) programmatically.

### [Get-AzMachineLearningWorkspacesWorkspaceSku](Get-AzMachineLearningWorkspacesWorkspaceSku.md)
Lists all skus with associated features

### [Get-AzMachineLearningWorkspacesWorkspaceStorageAccountKey](Get-AzMachineLearningWorkspacesWorkspaceStorageAccountKey.md)
List storage account keys of a workspace.

### [Invoke-AzMachineLearningWorkspacesDiagnoseWorkspace](Invoke-AzMachineLearningWorkspacesDiagnoseWorkspace.md)
Diagnose workspace setup issue.

### [Invoke-AzMachineLearningWorkspacesPrepareWorkspaceNotebook](Invoke-AzMachineLearningWorkspacesPrepareWorkspaceNotebook.md)
Prepare a notebook.

### [Invoke-AzMachineLearningWorkspacesResyncWorkspaceKey](Invoke-AzMachineLearningWorkspacesResyncWorkspaceKey.md)
Resync all the keys associated with this workspace.
This includes keys for the storage account, app insights and password for container registry

### [New-AzMachineLearningWorkspacesCompute](New-AzMachineLearningWorkspacesCompute.md)
Creates or updates compute.
This call will overwrite a compute if it exists.
This is a nonrecoverable operation.
If your intent is to create a new compute, do a GET first to verify that it does not exist yet.

### [New-AzMachineLearningWorkspacesPrivateEndpointConnection](New-AzMachineLearningWorkspacesPrivateEndpointConnection.md)
Update the state of specified private endpoint connection associated with the workspace.

### [New-AzMachineLearningWorkspacesWorkspace](New-AzMachineLearningWorkspacesWorkspace.md)
Creates or updates a workspace with the specified parameters.

### [New-AzMachineLearningWorkspacesWorkspaceConnection](New-AzMachineLearningWorkspacesWorkspaceConnection.md)
Add a new workspace connection.

### [Remove-AzMachineLearningWorkspacesCompute](Remove-AzMachineLearningWorkspacesCompute.md)
Deletes specified Machine Learning compute.

### [Remove-AzMachineLearningWorkspacesPrivateEndpointConnection](Remove-AzMachineLearningWorkspacesPrivateEndpointConnection.md)
Deletes the specified private endpoint connection associated with the workspace.

### [Remove-AzMachineLearningWorkspacesWorkspace](Remove-AzMachineLearningWorkspacesWorkspace.md)
Deletes a machine learning workspace.

### [Remove-AzMachineLearningWorkspacesWorkspaceConnection](Remove-AzMachineLearningWorkspacesWorkspaceConnection.md)
Delete a workspace connection.

### [Restart-AzMachineLearningWorkspacesCompute](Restart-AzMachineLearningWorkspacesCompute.md)
Posts a restart action to a compute instance

### [Start-AzMachineLearningWorkspacesCompute](Start-AzMachineLearningWorkspacesCompute.md)
Posts a start action to a compute instance

### [Stop-AzMachineLearningWorkspacesCompute](Stop-AzMachineLearningWorkspacesCompute.md)
Posts a stop action to a compute instance

### [Update-AzMachineLearningWorkspacesCompute](Update-AzMachineLearningWorkspacesCompute.md)
Updates properties of a compute.
This call will overwrite a compute if it exists.
This is a nonrecoverable operation.

### [Update-AzMachineLearningWorkspacesQuota](Update-AzMachineLearningWorkspacesQuota.md)
Update quota for each VM family in workspace.

### [Update-AzMachineLearningWorkspacesWorkspace](Update-AzMachineLearningWorkspacesWorkspace.md)
Updates a machine learning workspace with the specified parameters.

