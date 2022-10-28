---
Module Name: Az.MachineLearningCompute
Module Guid: dce6a891-c8a6-4dfb-9031-cdd687883173
Download Help Link: https://docs.microsoft.com/en-us/powershell/module/az.machinelearningcompute
Help Version: 1.0.0.0
Locale: en-US
---

# Az.MachineLearningCompute Module
## Description
Microsoft Azure PowerShell: MachineLearningCompute cmdlets

## Az.MachineLearningCompute Cmdlets
### [Get-AzMachineLearningComputeMachineLearningComputeAvailableOperation](Get-AzMachineLearningComputeMachineLearningComputeAvailableOperation.md)
Gets all available operations.

### [Get-AzMachineLearningComputeOperationalizationCluster](Get-AzMachineLearningComputeOperationalizationCluster.md)
Gets the operationalization cluster resource view.
Note that the credentials are not returned by this call.
Call ListKeys to get them.

### [Get-AzMachineLearningComputeOperationalizationClusterKey](Get-AzMachineLearningComputeOperationalizationClusterKey.md)
Gets the credentials for the specified cluster such as Storage, ACR and ACS credentials.
This is a long running operation because it fetches keys from dependencies.

### [New-AzMachineLearningComputeOperationalizationCluster](New-AzMachineLearningComputeOperationalizationCluster.md)
Create or update an operationalization cluster.

### [Remove-AzMachineLearningComputeOperationalizationCluster](Remove-AzMachineLearningComputeOperationalizationCluster.md)
Deletes the specified cluster.

### [Test-AzMachineLearningComputeOperationalizationClusterSystemServiceUpdateAvailable](Test-AzMachineLearningComputeOperationalizationClusterSystemServiceUpdateAvailable.md)
Checks if updates are available for system services in the cluster.

### [Update-AzMachineLearningComputeOperationalizationCluster](Update-AzMachineLearningComputeOperationalizationCluster.md)
The PATCH operation can be used to update only the tags for a cluster.
Use PUT operation to update other properties.

