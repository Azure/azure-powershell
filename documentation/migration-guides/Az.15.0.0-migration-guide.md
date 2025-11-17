# Migration Guide for Az 15.0.0

## Az.Batch

### `New-AzBatchCertificate`

Azure Batch account certificates feature has been retired and all certificate related commands have been removed from Batch. See https://learn.microsoft.com/en-us/azure/batch/batch-certificate-migration-guide

#### Before
```powershell
New-AzBatchCertificate -FilePath "E:\Certificates\MyCert.cer" -BatchContext $Context
```

#### After

### `Remove-AzBatchCertificate`

Azure Batch account certificates feature has been retired and all certificate related commands have been removed from Batch. See https://learn.microsoft.com/en-us/azure/batch/batch-certificate-migration-guide

#### Before
```powershell
Remove-AzBatchCertificate -ThumbprintAlgorithm "sha1" -Thumbprint "c1e494a415149c5f211c4778b52f2e834a07247c"
```

#### After

### `Stop-AzBatchCertificateDeletion`

Azure Batch account certificates feature has been retired and all certificate related commands have been removed from Batch. See https://learn.microsoft.com/en-us/azure/batch/batch-certificate-migration-guide

#### Before
```powershell
Stop-AzBatchCertificateDeletion -ThumbprintAlgorithm "sha1" -Thumbprint "c1e494a415149c5f211c4778b52f2e834a07247c" -BatchContext $Context
```

#### After


### `Get-AzBatchCertificate`

Azure Batch account certificates feature has been retired and all certificate related commands have been removed from Batch. See https://learn.microsoft.com/en-us/azure/batch/batch-certificate-migration-guide

#### Before
```powershell
Get-AzBatchCertificate -ThumbprintAlgorithm "sha1" -Thumbprint "C1******7C" -BatchContext $Context
```

#### After

### `New-AzBatchPool`

The following parameters have been removed: `ResourceTag`, `CloudServiceConfiguration`, `CertificateReferences`, `ApplicationLicenses`, `CurrentNodeCommunicationMode`, and `TargetNodeCommunicationMode`.  For `CloudServiceConfiguration` use `VirtualMachineConfiguration` instead, all other removed parameters don't have a replacement.

#### Before
```powershell

$resourceTags = @{
"Tag1" = "value1"
"Tag2" = "Value2"
}

$certificate =  -Object -TypeName "Microsoft.Azure.Commands.Batch.Models.PSCertificate"
$certificatesRef =  -Object -TypeName "Microsoft.Azure.Commands.Batch.Models.PSCertificateReferenceNew" -ArgumentList @($certificate)
$configuration = New-Object -TypeName "Microsoft.Azure.Commands.Batch.Models.PSCloudServiceConfiguration" -ArgumentList @(4,"*")

New-AzBatchPool -Id "MyPool" -VirtualMachineSize "STANDARD_D1_V2" -CloudServiceConfiguration $configuration  -TargetDedicatedComputeNodes 3 -CertificateReferences $certificatesRef -ApplicationLicenses @('licenses1', 'licenses2') -CurrentNodeCommunicationMode Default -TargetNodeCommunicationMode Classic -ResourceTags @resourceTags -BatchContext $Context
```

#### After
```powershell
$imageReference = New-Object -TypeName "Microsoft.Azure.Commands.Batch.Models.PSImageReference" -ArgumentList @("WindowsServer", "MicrosoftWindowsServer", "2016-Datacenter", "*")
$configuration = New-Object -TypeName "Microsoft.Azure.Commands.Batch.Models.PSVirtualMachineConfiguration" -ArgumentList @($imageReference, "batch.node.windows amd64")
New-AzBatchPool -Id "MyPool" -VirtualMachineSize "STANDARD_D1_V2" -VirtualMachineConfiguration $configuration -TargetDedicatedComputeNodes 3 -BatchContext $Context
```

### `Set-AzBatchPool`

The following properties have been removed from the `PSCloudPool` parameter: `ResourceTag`, `CloudServiceConfiguration`, `CertificateReferences`, `ApplicationLicenses`, `CurrentNodeCommunicationMode`, and `TargetNodeCommunicationMode`.  

#### Before
```powershell

$Pool = Get-AzBatchPool "ContosoPool" -BatchContext $Context

$resourceTags = @{
"Tag1" = "value1"
"Tag2" = "Value2"
}

$certificate =  -Object -TypeName "Microsoft.Azure.Commands.Batch.Models.PSCertificate"
$certificatesRef =  -Object -TypeName "Microsoft.Azure.Commands.Batch.Models.PSCertificateReferenceNew" -ArgumentList @($certificate)

$StartTask = New-Object Microsoft.Azure.Commands.Batch.Models.PSStartTask
$StartTask.CommandLine = "cmd /c echo example"

$Pool.CertificateReferences = $certificatesRef
$Pool.ApplicationLicenses = @('licenses1', 'licenses2')
$Pool.ResourceTag = $resourceTags
$Pool.TargetNodeCommunicationMode = Classic
$Pool.StartTask = $StartTask
Set-AzBatchPool -Pool $Pool -BatchContext $Context
```

#### After
```powershell
$Pool = Get-AzBatchPool "ContosoPool" -BatchContext $Context

$StartTask = New-Object Microsoft.Azure.Commands.Batch.Models.PSStartTask
$StartTask.CommandLine = "cmd /c echo example"

$Pool.StartTask = $StartTask
Set-AzBatchPool -Pool $Pool -BatchContext $Context
```


### `Get-AzBatchPool`

The following properties have been removed from the return type `PSCloudPool`: `ResourceTag`, `CloudServiceConfiguration`, `CertificateReferences`, `ApplicationLicenses`, `CurrentNodeCommunicationMode`, and `TargetNodeCommunicationMode`.  

#### Before
```powershell
$psCloudPool = Get-AzBatchPool -Id "MyPool" -BatchContext $Context

$var1 = $psCloudPool.Id
$var2 = $psCloudPool.ResourceTag
$var3 = $psCloudPool.CloudServiceConfiguration
$var4 = $psCloudPool.CertificateReferences
$var5 = $psCloudPool.ApplicationLicenses
$var6 = $psCloudPool.CurrentNodeCommunicationMode
$var7 = $psCloudPool.TargetNodeCommunicationMode
```

#### After
```powershell
Get-AzBatchPool -Id "MyPool" -BatchContext $Context

$var1 = $psCloudPool.Id
```

### `Get-AzBatchRemoteDesktopProtocolFile`

The command `Get-AzBatchRemoteDesktopProtocolFile` has been deprecated, use `Get-AzBatchRemoteLoginSettings` instead.

#### Before
```powershell

Get-AzBatchRemoteDesktopProtocolFile -PoolId "Pool06" -ComputeNodeId "ComputeNode01" -DestinationPath "C:\PowerShell\ComputeNode01.rdp" -BatchContext $Context
```

#### After
```powershell
Get-AzBatchRemoteLoginSetting -PoolId "Pool06" -ComputeNodeId "ComputeNode01" -BatchContext $Context
```

### `Get-AzBatchJob`

The property `PoolInformation` of the return type `PSCloudJob` has the following properties removed in its sub object: `ResourceTag`, `CloudServiceConfiguration`, `CertificateReferences`, `ApplicationLicenses`, `CurrentNodeCommunicationMode`, and `TargetNodeCommunicationMode`.

#### Before
```powershell
$psCloudJob =  Get-AzBatchJob -Id "Job01" -BatchContext $Context

$var1 = $psCloudJob.PoolInformation.AutoPoolSpecification.PoolSpecification.PoolId
$var2 = $psCloudJob.PoolInformation.AutoPoolSpecification.PoolSpecification.ResourceTag
$var3 = $psCloudJob.PoolInformation.AutoPoolSpecification.PoolSpecification.CloudServiceConfiguration
$var4 = $psCloudJob.PoolInformation.AutoPoolSpecification.PoolSpecification.CertificateReferences
$var5 = $psCloudJob.PoolInformation.AutoPoolSpecification.PoolSpecification.ApplicationLicenses
$var6 = $psCloudJob.PoolInformation.AutoPoolSpecification.PoolSpecification.CurrentNodeCommunicationMode
$var7 = $psCloudJob.PoolInformation.AutoPoolSpecification.PoolSpecification.TargetNodeCommunicationMode
```

#### After
```powershell
$psCloudJob =  Get-AzBatchJob -Id "Job01" -BatchContext $Context

$var1 = $psCloudJob.PoolInformation.AutoPoolSpecification.PoolSpecification.PoolId
```

### `Get-AzBatchComputeNode`

The property `CertificateReferences` has been removed from return type `PSComputeNode`

#### Before
```powershell
$computeNode = Get-AzBatchComputeNode -PoolId "Pool06" -Id "tvm-2316545714_1-20150725t213220z" -BatchContext $Context

var1 = $computeNode.Id
var2 = $computeNode.CertificateReferences
```

#### After
```powershell
$computeNode = Get-AzBatchComputeNode -PoolId "Pool06" -Id "tvm-2316545714_1-20150725t213220z" -BatchContext $Context

var1 = $computeNode.Id
```

## Az.DevCenter

### `Connect-AzDevCenterAdminCatalog`

The properties 'PlanName' and 'MemberName' have been removed from the 'Microsoft.Azure.PowerShell.Cmdlets.DevCenter.Models.IDevCenterIdentity' type. These properties were associated with unreleased features and were never available in production. **No action required** - this change does not affect any released functionality or existing usage of this cmdlet.

### `Connect-AzDevCenterAdminProjectCatalog`

The properties 'PlanName' and 'MemberName' have been removed from the 'Microsoft.Azure.PowerShell.Cmdlets.DevCenter.Models.IDevCenterIdentity' type. These properties were associated with unreleased features and were never available in production. **No action required** - this change does not affect any released functionality or existing usage of this cmdlet.

### `Get-AzDevCenterAdminAttachedNetwork`

The properties 'PlanName' and 'MemberName' have been removed from the 'Microsoft.Azure.PowerShell.Cmdlets.DevCenter.Models.IDevCenterIdentity' type. These properties were associated with unreleased features and were never available in production. **No action required** - this change does not affect any released functionality or existing usage of this cmdlet.

### `Get-AzDevCenterAdminCatalog`

The properties 'PlanName' and 'MemberName' have been removed from the 'Microsoft.Azure.PowerShell.Cmdlets.DevCenter.Models.IDevCenterIdentity' type. These properties were associated with unreleased features and were never available in production. **No action required** - this change does not affect any released functionality or existing usage of this cmdlet.

### `Get-AzDevCenterAdminCatalogSyncErrorDetail`

The properties 'PlanName' and 'MemberName' have been removed from the 'Microsoft.Azure.PowerShell.Cmdlets.DevCenter.Models.IDevCenterIdentity' type. These properties were associated with unreleased features and were never available in production. **No action required** - this change does not affect any released functionality or existing usage of this cmdlet.

### `Get-AzDevCenterAdminCustomizationTask`

The properties 'PlanName' and 'MemberName' have been removed from the 'Microsoft.Azure.PowerShell.Cmdlets.DevCenter.Models.IDevCenterIdentity' type. These properties were associated with unreleased features and were never available in production. **No action required** - this change does not affect any released functionality or existing usage of this cmdlet.

### `Get-AzDevCenterAdminCustomizationTaskErrorDetail`

The properties 'PlanName' and 'MemberName' have been removed from the 'Microsoft.Azure.PowerShell.Cmdlets.DevCenter.Models.IDevCenterIdentity' type. These properties were associated with unreleased features and were never available in production. **No action required** - this change does not affect any released functionality or existing usage of this cmdlet.

### `Get-AzDevCenterAdminDevBoxDefinition`

The properties 'PlanName' and 'MemberName' have been removed from the 'Microsoft.Azure.PowerShell.Cmdlets.DevCenter.Models.IDevCenterIdentity' type. These properties were associated with unreleased features and were never available in production. **No action required** - this change does not affect any released functionality or existing usage of this cmdlet.

### `Get-AzDevCenterAdminDevCenter`

The properties 'PlanName' and 'MemberName' have been removed from the 'Microsoft.Azure.PowerShell.Cmdlets.DevCenter.Models.IDevCenterIdentity' type. The 'PlanId' property has been removed from the output type 'Microsoft.Azure.PowerShell.Cmdlets.DevCenter.Models.Api20240501Preview.IDevCenter'. These properties were associated with unreleased features and were never available in production. **No action required** - this change does not affect any released functionality or existing usage of this cmdlet.

### `Get-AzDevCenterAdminEnvironmentDefinition`

The properties 'PlanName' and 'MemberName' have been removed from the 'Microsoft.Azure.PowerShell.Cmdlets.DevCenter.Models.IDevCenterIdentity' type. These properties were associated with unreleased features and were never available in production. **No action required** - this change does not affect any released functionality or existing usage of this cmdlet.

### `Get-AzDevCenterAdminEnvironmentDefinitionErrorDetail`

The properties 'PlanName' and 'MemberName' have been removed from the 'Microsoft.Azure.PowerShell.Cmdlets.DevCenter.Models.IDevCenterIdentity' type. These properties were associated with unreleased features and were never available in production. **No action required** - this change does not affect any released functionality or existing usage of this cmdlet.

### `Get-AzDevCenterAdminEnvironmentType`

The properties 'PlanName' and 'MemberName' have been removed from the 'Microsoft.Azure.PowerShell.Cmdlets.DevCenter.Models.IDevCenterIdentity' type. These properties were associated with unreleased features and were never available in production. **No action required** - this change does not affect any released functionality or existing usage of this cmdlet.

### `Get-AzDevCenterAdminGallery`

The properties 'PlanName' and 'MemberName' have been removed from the 'Microsoft.Azure.PowerShell.Cmdlets.DevCenter.Models.IDevCenterIdentity' type. These properties were associated with unreleased features and were never available in production. **No action required** - this change does not affect any released functionality or existing usage of this cmdlet.

### `Get-AzDevCenterAdminImage`

The properties 'PlanName' and 'MemberName' have been removed from the 'Microsoft.Azure.PowerShell.Cmdlets.DevCenter.Models.IDevCenterIdentity' type. These properties were associated with unreleased features and were never available in production. **No action required** - this change does not affect any released functionality or existing usage of this cmdlet.

### `Get-AzDevCenterAdminImageVersion`

The properties 'PlanName' and 'MemberName' have been removed from the 'Microsoft.Azure.PowerShell.Cmdlets.DevCenter.Models.IDevCenterIdentity' type. These properties were associated with unreleased features and were never available in production. **No action required** - this change does not affect any released functionality or existing usage of this cmdlet.

### `Get-AzDevCenterAdminNetworkConnection`

The properties 'PlanName' and 'MemberName' have been removed from the 'Microsoft.Azure.PowerShell.Cmdlets.DevCenter.Models.IDevCenterIdentity' type. These properties were associated with unreleased features and were never available in production. **No action required** - this change does not affect any released functionality or existing usage of this cmdlet.

### `Get-AzDevCenterAdminNetworkConnectionHealthDetail`

The properties 'PlanName' and 'MemberName' have been removed from the 'Microsoft.Azure.PowerShell.Cmdlets.DevCenter.Models.IDevCenterIdentity' type. These properties were associated with unreleased features and were never available in production. **No action required** - this change does not affect any released functionality or existing usage of this cmdlet.

### `Get-AzDevCenterAdminOperationStatus`

The properties 'PlanName' and 'MemberName' have been removed from the 'Microsoft.Azure.PowerShell.Cmdlets.DevCenter.Models.IDevCenterIdentity' type. These properties were associated with unreleased features and were never available in production. **No action required** - this change does not affect any released functionality or existing usage of this cmdlet.

### `Get-AzDevCenterAdminPlan`

This cmdlet is being removed. The "Plan" resource was never released to production and was not available for use. **No action required** - this removal does not affect any existing functionality.

### `Get-AzDevCenterAdminPlanMember`

This cmdlet is being removed. The "PlanMember" resource was never released to production and was not available for use. **No action required** - this removal does not affect any existing functionality.

### `Get-AzDevCenterAdminPool`

The properties 'PlanName' and 'MemberName' have been removed from the 'Microsoft.Azure.PowerShell.Cmdlets.DevCenter.Models.IDevCenterIdentity' type. These properties were associated with unreleased features and were never available in production. **No action required** - this change does not affect any released functionality or existing usage of this cmdlet.

### `Get-AzDevCenterAdminProject`

The properties 'PlanName' and 'MemberName' have been removed from the 'Microsoft.Azure.PowerShell.Cmdlets.DevCenter.Models.IDevCenterIdentity' type. These properties were associated with unreleased features and were never available in production. **No action required** - this change does not affect any released functionality or existing usage of this cmdlet.

### `Get-AzDevCenterAdminProjectAllowedEnvironmentType`

The properties 'PlanName' and 'MemberName' have been removed from the 'Microsoft.Azure.PowerShell.Cmdlets.DevCenter.Models.IDevCenterIdentity' type. These properties were associated with unreleased features and were never available in production. **No action required** - this change does not affect any released functionality or existing usage of this cmdlet.

### `Get-AzDevCenterAdminProjectCatalog`

The properties 'PlanName' and 'MemberName' have been removed from the 'Microsoft.Azure.PowerShell.Cmdlets.DevCenter.Models.IDevCenterIdentity' type. These properties were associated with unreleased features and were never available in production. **No action required** - this change does not affect any released functionality or existing usage of this cmdlet.

### `Get-AzDevCenterAdminProjectCatalogSyncErrorDetail`

The properties 'PlanName' and 'MemberName' have been removed from the 'Microsoft.Azure.PowerShell.Cmdlets.DevCenter.Models.IDevCenterIdentity' type. These properties were associated with unreleased features and were never available in production. **No action required** - this change does not affect any released functionality or existing usage of this cmdlet.

### `Get-AzDevCenterAdminProjectEnvironmentDefinition`

The properties 'PlanName' and 'MemberName' have been removed from the 'Microsoft.Azure.PowerShell.Cmdlets.DevCenter.Models.IDevCenterIdentity' type. These properties were associated with unreleased features and were never available in production. **No action required** - this change does not affect any released functionality or existing usage of this cmdlet.

### `Get-AzDevCenterAdminProjectEnvironmentDefinitionErrorDetail`

The properties 'PlanName' and 'MemberName' have been removed from the 'Microsoft.Azure.PowerShell.Cmdlets.DevCenter.Models.IDevCenterIdentity' type. These properties were associated with unreleased features and were never available in production. **No action required** - this change does not affect any released functionality or existing usage of this cmdlet.

### `Get-AzDevCenterAdminProjectEnvironmentType`

The properties 'PlanName' and 'MemberName' have been removed from the 'Microsoft.Azure.PowerShell.Cmdlets.DevCenter.Models.IDevCenterIdentity' type. These properties were associated with unreleased features and were never available in production. **No action required** - this change does not affect any released functionality or existing usage of this cmdlet.

### `Get-AzDevCenterAdminProjectInheritedSetting`

The properties 'PlanName' and 'MemberName' have been removed from the 'Microsoft.Azure.PowerShell.Cmdlets.DevCenter.Models.IDevCenterIdentity' type. These properties were associated with unreleased features and were never available in production. **No action required** - this change does not affect any released functionality or existing usage of this cmdlet.

### `Get-AzDevCenterAdminSchedule`

The properties 'PlanName' and 'MemberName' have been removed from the 'Microsoft.Azure.PowerShell.Cmdlets.DevCenter.Models.IDevCenterIdentity' type. These properties were associated with unreleased features and were never available in production. **No action required** - this change does not affect any released functionality or existing usage of this cmdlet.

### `Invoke-AzDevCenterAdminExecuteCheckNameAvailability`

The properties 'PlanName' and 'MemberName' have been removed from the 'Microsoft.Azure.PowerShell.Cmdlets.DevCenter.Models.IDevCenterIdentity' type. These properties were associated with unreleased features and were never available in production. **No action required** - this change does not affect any released functionality or existing usage of this cmdlet.

### `Invoke-AzDevCenterAdminExecuteCheckScopedNameAvailability`

The properties 'PlanName' and 'MemberName' have been removed from the 'Microsoft.Azure.PowerShell.Cmdlets.DevCenter.Models.IDevCenterIdentity' type. These properties were associated with unreleased features and were never available in production. **No action required** - this change does not affect any released functionality or existing usage of this cmdlet.

### `New-AzDevCenterAdminAttachedNetwork`

The properties 'PlanName' and 'MemberName' have been removed from the 'Microsoft.Azure.PowerShell.Cmdlets.DevCenter.Models.IDevCenterIdentity' type. These properties were associated with unreleased features and were never available in production. **No action required** - this change does not affect any released functionality or existing usage of this cmdlet.

### `New-AzDevCenterAdminCatalog`

The properties 'PlanName' and 'MemberName' have been removed from the 'Microsoft.Azure.PowerShell.Cmdlets.DevCenter.Models.IDevCenterIdentity' type. These properties were associated with unreleased features and were never available in production. **No action required** - this change does not affect any released functionality or existing usage of this cmdlet.

### `New-AzDevCenterAdminDevBoxDefinition`

The properties 'PlanName' and 'MemberName' have been removed from the 'Microsoft.Azure.PowerShell.Cmdlets.DevCenter.Models.IDevCenterIdentity' type. These properties were associated with unreleased features and were never available in production. **No action required** - this change does not affect any released functionality or existing usage of this cmdlet.

### `New-AzDevCenterAdminDevCenter`

The properties 'PlanName' and 'MemberName' have been removed from the 'Microsoft.Azure.PowerShell.Cmdlets.DevCenter.Models.IDevCenterIdentity' type. Additionally, the 'PlanId' parameter has been removed from this cmdlet, and the 'PlanId' property has been removed from the output type 'Microsoft.Azure.PowerShell.Cmdlets.DevCenter.Models.Api20240501Preview.IDevCenter'. These properties and parameters were associated with unreleased features and were never available in production. **No action required** - this change does not affect any released functionality or existing usage of this cmdlet.

### `New-AzDevCenterAdminEnvironmentType`

The properties 'PlanName' and 'MemberName' have been removed from the 'Microsoft.Azure.PowerShell.Cmdlets.DevCenter.Models.IDevCenterIdentity' type. These properties were associated with unreleased features and were never available in production. **No action required** - this change does not affect any released functionality or existing usage of this cmdlet.

### `New-AzDevCenterAdminGallery`

The properties 'PlanName' and 'MemberName' have been removed from the 'Microsoft.Azure.PowerShell.Cmdlets.DevCenter.Models.IDevCenterIdentity' type. These properties were associated with unreleased features and were never available in production. **No action required** - this change does not affect any released functionality or existing usage of this cmdlet.

### `New-AzDevCenterAdminNetworkConnection`

The properties 'PlanName' and 'MemberName' have been removed from the 'Microsoft.Azure.PowerShell.Cmdlets.DevCenter.Models.IDevCenterIdentity' type. These properties were associated with unreleased features and were never available in production. **No action required** - this change does not affect any released functionality or existing usage of this cmdlet.

### `New-AzDevCenterAdminPlan`

This cmdlet is being removed. The "Plan" resource was never released to production and was not available for use. **No action required** - this removal does not affect any existing functionality.

### `New-AzDevCenterAdminPlanMember`

This cmdlet is being removed. The "PlanMember" resource was never released to production and was not available for use. **No action required** - this removal does not affect any existing functionality.

### `New-AzDevCenterAdminPool`

The properties 'PlanName' and 'MemberName' have been removed from the 'Microsoft.Azure.PowerShell.Cmdlets.DevCenter.Models.IDevCenterIdentity' type. These properties were associated with unreleased features and were never available in production. **No action required** - this change does not affect any released functionality or existing usage of this cmdlet.

### `New-AzDevCenterAdminProject`

The properties 'PlanName' and 'MemberName' have been removed from the 'Microsoft.Azure.PowerShell.Cmdlets.DevCenter.Models.IDevCenterIdentity' type. These properties were associated with unreleased features and were never available in production. **No action required** - this change does not affect any released functionality or existing usage of this cmdlet.

### `New-AzDevCenterAdminProjectCatalog`

The properties 'PlanName' and 'MemberName' have been removed from the 'Microsoft.Azure.PowerShell.Cmdlets.DevCenter.Models.IDevCenterIdentity' type. These properties were associated with unreleased features and were never available in production. **No action required** - this change does not affect any released functionality or existing usage of this cmdlet.

### `New-AzDevCenterAdminProjectEnvironmentType`

The properties 'PlanName' and 'MemberName' have been removed from the 'Microsoft.Azure.PowerShell.Cmdlets.DevCenter.Models.IDevCenterIdentity' type. These properties were associated with unreleased features and were never available in production. **No action required** - this change does not affect any released functionality or existing usage of this cmdlet.

### `New-AzDevCenterAdminSchedule`

The properties 'PlanName' and 'MemberName' have been removed from the 'Microsoft.Azure.PowerShell.Cmdlets.DevCenter.Models.IDevCenterIdentity' type. These properties were associated with unreleased features and were never available in production. **No action required** - this change does not affect any released functionality or existing usage of this cmdlet.

### `Remove-AzDevCenterAdminAttachedNetwork`

The properties 'PlanName' and 'MemberName' have been removed from the 'Microsoft.Azure.PowerShell.Cmdlets.DevCenter.Models.IDevCenterIdentity' type. These properties were associated with unreleased features and were never available in production. **No action required** - this change does not affect any released functionality or existing usage of this cmdlet.

### `Remove-AzDevCenterAdminCatalog`

The properties 'PlanName' and 'MemberName' have been removed from the 'Microsoft.Azure.PowerShell.Cmdlets.DevCenter.Models.IDevCenterIdentity' type. These properties were associated with unreleased features and were never available in production. **No action required** - this change does not affect any released functionality or existing usage of this cmdlet.

### `Remove-AzDevCenterAdminDevBoxDefinition`

The properties 'PlanName' and 'MemberName' have been removed from the 'Microsoft.Azure.PowerShell.Cmdlets.DevCenter.Models.IDevCenterIdentity' type. These properties were associated with unreleased features and were never available in production. **No action required** - this change does not affect any released functionality or existing usage of this cmdlet.

### `Remove-AzDevCenterAdminDevCenter`

The properties 'PlanName' and 'MemberName' have been removed from the 'Microsoft.Azure.PowerShell.Cmdlets.DevCenter.Models.IDevCenterIdentity' type. These properties were associated with unreleased features and were never available in production. **No action required** - this change does not affect any released functionality or existing usage of this cmdlet.

### `Remove-AzDevCenterAdminEnvironmentType`

The properties 'PlanName' and 'MemberName' have been removed from the 'Microsoft.Azure.PowerShell.Cmdlets.DevCenter.Models.IDevCenterIdentity' type. These properties were associated with unreleased features and were never available in production. **No action required** - this change does not affect any released functionality or existing usage of this cmdlet.

### `Remove-AzDevCenterAdminGallery`

The properties 'PlanName' and 'MemberName' have been removed from the 'Microsoft.Azure.PowerShell.Cmdlets.DevCenter.Models.IDevCenterIdentity' type. These properties were associated with unreleased features and were never available in production. **No action required** - this change does not affect any released functionality or existing usage of this cmdlet.

### `Remove-AzDevCenterAdminNetworkConnection`

The properties 'PlanName' and 'MemberName' have been removed from the 'Microsoft.Azure.PowerShell.Cmdlets.DevCenter.Models.IDevCenterIdentity' type. These properties were associated with unreleased features and were never available in production. **No action required** - this change does not affect any released functionality or existing usage of this cmdlet.

### `Remove-AzDevCenterAdminPlan`

This cmdlet is being removed. The "Plan" resource was never released to production and was not available for use. **No action required** - this removal does not affect any existing functionality.

### `Remove-AzDevCenterAdminPlanMember`

This cmdlet is being removed. The "PlanMember" resource was never released to production and was not available for use. **No action required** - this removal does not affect any existing functionality.

### `Remove-AzDevCenterAdminPool`

The properties 'PlanName' and 'MemberName' have been removed from the 'Microsoft.Azure.PowerShell.Cmdlets.DevCenter.Models.IDevCenterIdentity' type. These properties were associated with unreleased features and were never available in production. **No action required** - this change does not affect any released functionality or existing usage of this cmdlet.

### `Remove-AzDevCenterAdminProject`

The properties 'PlanName' and 'MemberName' have been removed from the 'Microsoft.Azure.PowerShell.Cmdlets.DevCenter.Models.IDevCenterIdentity' type. These properties were associated with unreleased features and were never available in production. **No action required** - this change does not affect any released functionality or existing usage of this cmdlet.

### `Remove-AzDevCenterAdminProjectCatalog`

The properties 'PlanName' and 'MemberName' have been removed from the 'Microsoft.Azure.PowerShell.Cmdlets.DevCenter.Models.IDevCenterIdentity' type. These properties were associated with unreleased features and were never available in production. **No action required** - this change does not affect any released functionality or existing usage of this cmdlet.

### `Remove-AzDevCenterAdminProjectEnvironmentType`

The properties 'PlanName' and 'MemberName' have been removed from the 'Microsoft.Azure.PowerShell.Cmdlets.DevCenter.Models.IDevCenterIdentity' type. These properties were associated with unreleased features and were never available in production. **No action required** - this change does not affect any released functionality or existing usage of this cmdlet.

### `Remove-AzDevCenterAdminSchedule`

The properties 'PlanName' and 'MemberName' have been removed from the 'Microsoft.Azure.PowerShell.Cmdlets.DevCenter.Models.IDevCenterIdentity' type. These properties were associated with unreleased features and were never available in production. **No action required** - this change does not affect any released functionality or existing usage of this cmdlet.

### `Start-AzDevCenterAdminNetworkConnectionHealthCheck`

The properties 'PlanName' and 'MemberName' have been removed from the 'Microsoft.Azure.PowerShell.Cmdlets.DevCenter.Models.IDevCenterIdentity' type. These properties were associated with unreleased features and were never available in production. **No action required** - this change does not affect any released functionality or existing usage of this cmdlet.

### `Start-AzDevCenterAdminPoolHealthCheck`

The properties 'PlanName' and 'MemberName' have been removed from the 'Microsoft.Azure.PowerShell.Cmdlets.DevCenter.Models.IDevCenterIdentity' type. These properties were associated with unreleased features and were never available in production. **No action required** - this change does not affect any released functionality or existing usage of this cmdlet.

### `Sync-AzDevCenterAdminCatalog`

The properties 'PlanName' and 'MemberName' have been removed from the 'Microsoft.Azure.PowerShell.Cmdlets.DevCenter.Models.IDevCenterIdentity' type. These properties were associated with unreleased features and were never available in production. **No action required** - this change does not affect any released functionality or existing usage of this cmdlet.

### `Sync-AzDevCenterAdminProjectCatalog`

The properties 'PlanName' and 'MemberName' have been removed from the 'Microsoft.Azure.PowerShell.Cmdlets.DevCenter.Models.IDevCenterIdentity' type. These properties were associated with unreleased features and were never available in production. **No action required** - this change does not affect any released functionality or existing usage of this cmdlet.

### `Update-AzDevCenterAdminCatalog`

The properties 'PlanName' and 'MemberName' have been removed from the 'Microsoft.Azure.PowerShell.Cmdlets.DevCenter.Models.IDevCenterIdentity' type. These properties were associated with unreleased features and were never available in production. **No action required** - this change does not affect any released functionality or existing usage of this cmdlet.

### `Update-AzDevCenterAdminDevBoxDefinition`

The properties 'PlanName' and 'MemberName' have been removed from the 'Microsoft.Azure.PowerShell.Cmdlets.DevCenter.Models.IDevCenterIdentity' type. These properties were associated with unreleased features and were never available in production. **No action required** - this change does not affect any released functionality or existing usage of this cmdlet.

### `Update-AzDevCenterAdminDevCenter`

The properties 'PlanName' and 'MemberName' have been removed from the 'Microsoft.Azure.PowerShell.Cmdlets.DevCenter.Models.IDevCenterIdentity' type. Additionally, the 'PlanId' parameter has been removed from this cmdlet, and the 'PlanId' property has been removed from the output type 'Microsoft.Azure.PowerShell.Cmdlets.DevCenter.Models.Api20240501Preview.IDevCenter'. These properties and parameters were associated with unreleased features and were never available in production. **No action required** - this change does not affect any released functionality or existing usage of this cmdlet.

### `Update-AzDevCenterAdminEnvironmentType`

The properties 'PlanName' and 'MemberName' have been removed from the 'Microsoft.Azure.PowerShell.Cmdlets.DevCenter.Models.IDevCenterIdentity' type. These properties were associated with unreleased features and were never available in production. **No action required** - this change does not affect any released functionality or existing usage of this cmdlet.

### `Update-AzDevCenterAdminNetworkConnection`

The properties 'PlanName' and 'MemberName' have been removed from the 'Microsoft.Azure.PowerShell.Cmdlets.DevCenter.Models.IDevCenterIdentity' type. These properties were associated with unreleased features and were never available in production. **No action required** - this change does not affect any released functionality or existing usage of this cmdlet.

### `Update-AzDevCenterAdminPlan`

This cmdlet is being removed. The "Plan" resource was never released to production and was not available for use. **No action required** - this removal does not affect any existing functionality.

### `Update-AzDevCenterAdminPlanMember`

This cmdlet is being removed. The "PlanMember" resource was never released to production and was not available for use. **No action required** - this removal does not affect any existing functionality.

### `Update-AzDevCenterAdminPool`

The properties 'PlanName' and 'MemberName' have been removed from the 'Microsoft.Azure.PowerShell.Cmdlets.DevCenter.Models.IDevCenterIdentity' type. These properties were associated with unreleased features and were never available in production. **No action required** - this change does not affect any released functionality or existing usage of this cmdlet.

### `Update-AzDevCenterAdminProject`

The properties 'PlanName' and 'MemberName' have been removed from the 'Microsoft.Azure.PowerShell.Cmdlets.DevCenter.Models.IDevCenterIdentity' type. These properties were associated with unreleased features and were never available in production. **No action required** - this change does not affect any released functionality or existing usage of this cmdlet.

### `Update-AzDevCenterAdminProjectCatalog`

The properties 'PlanName' and 'MemberName' have been removed from the 'Microsoft.Azure.PowerShell.Cmdlets.DevCenter.Models.IDevCenterIdentity' type. These properties were associated with unreleased features and were never available in production. **No action required** - this change does not affect any released functionality or existing usage of this cmdlet.

### `Update-AzDevCenterAdminProjectEnvironmentType`

The properties 'PlanName' and 'MemberName' have been removed from the 'Microsoft.Azure.PowerShell.Cmdlets.DevCenter.Models.IDevCenterIdentity' type. These properties were associated with unreleased features and were never available in production. **No action required** - this change does not affect any released functionality or existing usage of this cmdlet.

### `Update-AzDevCenterAdminSchedule`

The properties 'PlanName' and 'MemberName' have been removed from the 'Microsoft.Azure.PowerShell.Cmdlets.DevCenter.Models.IDevCenterIdentity' type. These properties were associated with unreleased features and were never available in production. **No action required** - this change does not affect any released functionality or existing usage of this cmdlet.

### `New-AzDevCenterUserDevBox`

The parameter 'LocalAdministrator' has been removed from this cmdlet. This parameter was non-functional and had no effect when used. **No action required** - removing this parameter does not affect any existing functionality.

### `Remove-AzDevCenterUserDevBox`

The internal type of the `Property` field has changed from `Microsoft.Azure.PowerShell.Cmdlets.DevCenterdata.Models.IAny` to `Microsoft.Azure.PowerShell.Cmdlets.DevCenterdata.Models.IOperationStatusProperties`. This is an internal type improvement that does not affect the properties returned or how they are accessed. **No action required** - the way custom operation properties are accessed remains unchanged. Both types function as dictionaries with identical access patterns.

### `Remove-AzDevCenterUserEnvironment`

The internal type of the `Property` field has changed from `Microsoft.Azure.PowerShell.Cmdlets.DevCenterdata.Models.IAny` to `Microsoft.Azure.PowerShell.Cmdlets.DevCenterdata.Models.IOperationStatusProperties`. This is an internal type improvement that does not affect the properties returned or how they are accessed. **No action required** - the way custom operation properties are accessed remains unchanged. Both types function as dictionaries with identical access patterns.

### `Repair-AzDevCenterUserDevBox`

The internal type of the `Property` field has changed from `Microsoft.Azure.PowerShell.Cmdlets.DevCenterdata.Models.IAny` to `Microsoft.Azure.PowerShell.Cmdlets.DevCenterdata.Models.IOperationStatusProperties`. This is an internal type improvement that does not affect the properties returned or how they are accessed. **No action required** - the way custom operation properties are accessed remains unchanged. Both types function as dictionaries with identical access patterns.

### `Restart-AzDevCenterUserDevBox`

The internal type of the `Property` field has changed from `Microsoft.Azure.PowerShell.Cmdlets.DevCenterdata.Models.IAny` to `Microsoft.Azure.PowerShell.Cmdlets.DevCenterdata.Models.IOperationStatusProperties`. This is an internal type improvement that does not affect the properties returned or how they are accessed. **No action required** - the way custom operation properties are accessed remains unchanged. Both types function as dictionaries with identical access patterns.

### `Start-AzDevCenterUserDevBox`

The internal type of the `Property` field has changed from `Microsoft.Azure.PowerShell.Cmdlets.DevCenterdata.Models.IAny` to `Microsoft.Azure.PowerShell.Cmdlets.DevCenterdata.Models.IOperationStatusProperties`. This is an internal type improvement that does not affect the properties returned or how they are accessed. **No action required** - the way custom operation properties are accessed remains unchanged. Both types function as dictionaries with identical access patterns.

### `Stop-AzDevCenterUserDevBox`

The internal type of the `Property` field has changed from `Microsoft.Azure.PowerShell.Cmdlets.DevCenterdata.Models.IAny` to `Microsoft.Azure.PowerShell.Cmdlets.DevCenterdata.Models.IOperationStatusProperties`. This is an internal type improvement that does not affect the properties returned or how they are accessed. **No action required** - the way custom operation properties are accessed remains unchanged. Both types function as dictionaries with identical access patterns.

## Az.FrontDoor

### `Disable-AzFrontDoorCustomDomainHttps`

The return type changed from PSFrontendEndpoint to Boolean. Way to use this cmdlet is the same.

#### Before

``` powershell
Disable-AzFrontDoorCustomDomainHttps -ResourceGroupName "resourcegroup1" -FrontDoorName "frontdoor1" -FrontendEndpointName "frontendpointname1-custom-xyz"
```

#### After

``` powershell
Disable-AzFrontDoorCustomDomainHttps -ResourceGroupName "resourcegroup1" -FrontDoorName "frontdoor1" -FrontendEndpointName "frontendpointname1-custom-xyz"
```

### `Enable-AzFrontDoorCustomDomainHttps`

The return type changed from PSFrontendEndpoint to Boolean. Way to use this cmdlet is the same.

#### Before

``` powershell
Enable-AzFrontDoorCustomDomainHttps -ResourceGroupName "resourcegroup1" -FrontDoorName "frontdoor1" -FrontendEndpointName "frontendpointname1-custom-xyz" -MinimumTlsVersion "1.2"
```

#### After

``` powershell
Enable-AzFrontDoorCustomDomainHttps -ResourceGroupName "resourcegroup1" -FrontDoorName "frontdoor1" -FrontendEndpointName "frontendpointname1-custom-xyz" -MinimumTlsVersion "1.2"
```

### `Get-AzFrontDoor`

The return type field name changed from plural to singular

#### Before

``` powershell
Get-AzFrontDoor -ResourceGroupName "rg1" -Name "frontDoor1"
```

```output
FriendlyName          : frontdoor1
FrontDoorId           : {guid}
RoutingRules          : {routingrule1}
BackendPools          : {backendpool1}
HealthProbeSettings   : {healthProbeSetting1}
LoadBalancingSettings : {loadbalancingsetting1}
FrontendEndpoints     : {frontendendpoint1}
EnabledState          : Enabled
ResourceState         : Enabled
ProvisioningState     : Succeeded
Cname                 :
Tags                  : {tag1, tag2}
Id                    : /subscriptions/{guid}/resourcegroups/rg1/providers/M
                        icrosoft.Network/frontdoors/frontdoor1
Name                  : frontdoor1
Type                  : Microsoft.Network/frontdoor1
```

#### After

``` powershell
Enable-AzFrontDoorCustomDomainHttps -ResourceGroupName "resourcegroup1" -FrontDoorName "frontdoor1" -FrontendEndpointName "frontendpointname1-custom-xyz" -MinimumTlsVersion "1.2"
```

```
BackendPool          : {BackendPool0}
BackendPoolsSetting  : {
                         "enforceCertificateNameCheck": "Enabled",
                         "sendRecvTimeoutSeconds": 30
                       }
Cname                :
EnabledState         : Disabled
ExtendedProperty     : {
                         "MigratedTo": {link0}
                       }
FriendlyName         : frontDoor1
FrontdoorId          : {guid0}
FrontendEndpoint     : {Endpoint0}
HealthProbeSetting   : {HealthProbeSetting0}
Id                   : /subscriptions/{guid}/resourcegroups/rg1/providers/M
                        icrosoft.Network/frontdoors/frontdoor1
LoadBalancingSetting : {LoadBalancingSetting0}
Location             : Global
Name                 : frontDoor1
ProvisioningState    : Succeeded
ResourceGroupName    : {rg1}
ResourceState        : Migrated
RoutingRule          : {RoutingRule0,RoutingRule1}
RulesEngine          : {RulesEngine0,RulesEngine1}
Tag                  : {
                       }
Type                 : Microsoft.Network/frontdoors
```

### `Get-AzFrontDoorRulesEngine`

Return field "RulesEngineRules" changed to Rule

#### Before

```powershell
Get-AzFrontDoorRulesEngine -ResourceGroupName $resourceGroupName -FrontDoorName $frontDoorName -Name rulesengine3
```

```output
Name         RulesEngineRules
----         ----------------
rulesEngine3 {rules1}
```

#### After

```powershell
Get-AzFrontDoorRulesEngine -ResourceGroupName $resourceGroupName -FrontDoorName $frontDoorName -Name rulesengine3
```

```output
Id                : /subscriptions/{subId}/resourcegroups/{resourceGroupName}/providers/Microsoft.Network/frontdoors/{frontDoorName}/rulesengines/rulesengine3
Name              : rulesengine3
ResourceGroupName : {resourceGroupName}
ResourceState     : Enabled
Rule              : {{
                      "name": "rule111",
                      "priority": 0,
                      "action": {
                        "requestHeaderActions": [ ],
                        "responseHeaderActions": [
                          {
                            "headerActionType": "Overwrite",
                            "headerName": "ff",
                            "value": "ff"
                          }
                        ]
                      },
                      "matchConditions": [
                        {
                          "rulesEngineMatchVariable": "QueryString",
                          "rulesEngineOperator": "Contains",
                          "negateCondition": false,
                          "rulesEngineMatchValue": [ "fdfd" ],
                          "transforms": [ ]
                        }
                      ],
                      "matchProcessingBehavior": "Continue"
                    }}
Type              : Microsoft.Network/frontdoors/rulesengines
```

### `Get-AzFrontDoorWafPolicy`

The return value changes.

#### before
```powershell
Get-AzFrontDoorWafPolicy -Name $policyName -ResourceGroupName $resourceGroupName
```

```output
Name         PolicyMode PolicyEnabledState CustomBlockResponseStatusCode RedirectUrl
----         ---------- ------------------ ----------------------------- -----------
{policyName} Prevention            Enabled                           403 https://www.bing.com/
```

#### After

```powershell
Get-AzFrontDoorWafPolicy -Name $policyName -ResourceGroupName $resourceGroupName
```

```output
Customrule           : {customrule0, customrule01}
Etag                 :
FrontendEndpointLink : {}
Id                   : /subscriptions/{subid}/resourcegroups/{rg}/providers/Microsoft.Network/frontdoorwebapplicationfirewallpolicies/{policyName}
Location             : Global
ManagedRuleSet       : {{
                         "ruleSetType": "Microsoft_DefaultRuleSet",
                         "ruleSetVersion": "2.0",
                         "ruleSetAction": "Block",
                         "exclusions": [ ],
                         "ruleGroupOverrides": [ ]
                       }}
Name                 : {policyName}
PolicySetting        : {
                         "enabledState": "Enabled",
                         "mode": "Detection",
                         "customBlockResponseStatusCode": 403,
                         "requestBodyCheck": "Enabled"
                       }
ProvisioningState    : Succeeded
ResourceGroupName    : {rg}
ResourceState        : Enabled
RoutingRuleLink      :
SecurityPolicyLink   : {{
                         "id": "/subscriptions/{subid}/resourcegroups/{rg}/providers/Microsoft.Cdn/profiles/hdis-fe/securitypolicies/premium"
                       }}
SkuName              : Premium_AzureFrontDoor
Tag                  : {
                       }
Type                 : Microsoft.Network/frontdoorwebapplicationfirewallpolicies
```

### `New-AzFrontDoor`

The return type field names have been changed from plural to singular

#### Before

```powershell
New-AzFrontDoor -Name "frontDoor1" -ResourceGroupName "rg1" -RoutingRule $routingrule1 -BackendPool $backendpool1 -FrontendEndpoint $frontendEndpoint1 -LoadBalancingSetting $loadBalancingSetting1 -HealthProbeSetting $healthProbeSetting1 -BackendPoolsSetting $backendPoolsSetting1
```

```output
FriendlyName                : frontdoor1
RoutingRules                : {routingrule1}
BackendPools                : {backendpool1}
BackendPoolsSetting         : {backendPoolsSetting1}
EnforceCertificateNameCheck : {backendPoolsSetting1.EnforceCertificateNameCheck}
HealthProbeSettings         : {healthProbeSetting1}
LoadBalancingSettings       : {loadbalancingsetting1}
FrontendEndpoints           : {frontendendpoint1}
EnabledState                : Enabled
ResourceState               : Enabled
ProvisioningState           : Succeeded
Cname                       :
Tags                        : {tag1, tag2}
Id                          : /subscriptions/{guid}/resourcegroups/rg1/providers/Microsoft.Network/frontdoors/frontdoor1
Name                        : frontdoor1
Type                        : Microsoft.Network/frontdoors
```

#### After

```powershell
New-AzFrontDoor -Name "frontDoor1" -ResourceGroupName "rg1" -RoutingRule $routingrule1 -BackendPool $backendpool1 -FrontendEndpoint $frontendEndpoint1 -LoadBalancingSetting $loadBalancingSetting1 -HealthProbeSetting $healthProbeSetting1 -BackendPoolsSetting $backendPoolsSetting1
```

```output
BackendPool          : {backendpool1}
BackendPoolsSetting  : {backendPoolsSetting1}
Cname                :
EnabledState         : Disabled
ExtendedProperty     : {
                         "MigratedTo": {link0}
                       }
FriendlyName         : frontDoor1
FrontdoorId          : {guid0}
FrontendEndpoint     : {frontendEndpoint1}
HealthProbeSetting   : {HealthProbeSetting1}
Id                   : /subscriptions/{guid}/resourcegroups/rg1/providers/M
                        icrosoft.Network/frontdoors/frontdoor1
LoadBalancingSetting : {LoadBalancingSetting1}
Location             : Global
Name                 : frontDoor1
ProvisioningState    : Succeeded
ResourceGroupName    : {rg1}
ResourceState        : Migrated
RoutingRule          : {RoutingRule1}
RulesEngine          : {RulesEngine0,RulesEngine1}
Tag                  : {
                       }
Type                 : Microsoft.Network/frontdoors
```

### `New-AzFrontDoorBackendPoolObject`

The return type field names have been changed from plural to singular

#### Before
```powershell
New-AzFrontDoorBackendPoolObject -Name "backendpool1" -FrontDoorName $Name -ResourceGroupName $resourceGroupName -Backend $backend1 -HealthProbeSettingsName "healthProbeSetting1" -LoadBalancingSettingsName "loadBalancingSetting1"
```

```output
Backends                : {Microsoft.Azure.Commands.FrontDoor.Models.PSBackend}
LoadBalancingSettingRef : /subscriptions/{subid}/resourceGroups/{resourceGroupName}/providers
                          /Microsoft.Network/frontDoors/frontdoor5/LoadBalancingSettings/loadBalancingSetting1
HealthProbeSettingRef   : /subscriptions/{subid}/resourceGroups/{resourceGroupName}/providers
                          /Microsoft.Network/frontDoors/frontdoor5/HealthProbeSettings/healthProbeSetting1
EnabledState            : Enabled
ResourceState           :
Id                      :
Name                    : backendpool1
Type                    :
```

#### After
```powershell
New-AzFrontDoorBackendPoolObject -Name "backendpool1" -FrontDoorName $Name -ResourceGroupName $resourceGroupName -Backend $backend1 -HealthProbeSettingsName "healthProbeSetting1" -LoadBalancingSettingsName "loadBalancingSetting1"
```

```output
Backend                :
HealthProbeSettingId   : /subscriptions/27cafca8-b9a4-4264-b399-45d0c9cca1ab/resourceGroups//providers/Microsoft.Network/frontDoors//HealthProbeSettings/healthProbeSetting1
Id                     :
LoadBalancingSettingId : /subscriptions/27cafca8-b9a4-4264-b399-45d0c9cca1ab/resourceGroups//providers/Microsoft.Network/frontDoors//LoadBalancingSettings/loadBalancingSetting1
Name                   : backendpool1
ResourceState          :
Type                   :
```

### `New-AzFrontDoorRoutingRuleObject`
The return type field names have been changed from plural to singular

#### Before
```powershell
New-AzFrontDoorRoutingRuleObject -Name $routingRuleName -FrontDoorName $frontDoorName -ResourceGroupName $rgname -FrontendEndpointName "frontendEndpoint1" -BackendPoolName "backendPool1"
```

```output
FrontendEndpointIds          : {/subscriptions/{subid}/resourceGroups/{rgname}/pro
                               viders/Microsoft.Network/frontDoors/{frontdoorname}/FrontendEndpoints/frontendEndpoint1}
AcceptedProtocols            : {Http, Https}
PatternsToMatch              : {/*}
HealthProbeSettings          :
RouteConfiguration           : Microsoft.Azure.Commands.FrontDoor.Models.PSForwardingConfiguration
EnabledState                 : Enabled
ResourceState                :
Id                           :
Name                         : {routingRuleName}
Type                         :
```

#### After
### Example 1: Create a PSRoutingRuleObject for Front Door creation with a forwarding rule
```powershell
New-AzFrontDoorRoutingRuleObject -Name $routingRuleName -FrontDoorName $frontDoorName -ResourceGroupName $rgname -FrontendEndpointName "frontendEndpoint1" -BackendPoolName "backendPool1"
```

```output
AcceptedProtocol                   : {Http, Https}
EnabledState                       : Enabled
FrontendEndpoint                   : {{
                                       "id": "/subscriptions/{subid}/resourceGroups/{rg}/providers/Microsoft.Network/frontDoors/{fname}/FrontendEndpoints/frontendEndpoint1"
                                     }}
Id                                 :
Name                               :
PatternsToMatch                    : {/*}
ResourceState                      :
RouteConfiguration                 : {
                                       "@odata.type": "#Microsoft.Azure.FrontDoor.Models.FrontdoorForwardingConfiguration",
                                       "backendPool": {
                                         "id": "/subscriptions/{subid}/resourceGroups/{rg}/providers/Microsoft.Network/frontDoors/{fname}/BackendPools/backendPool1"
                                       },
                                       "forwardingProtocol": "MatchRequest"
                                     }
RuleEngineId                       :
Type                               :
WebApplicationFirewallPolicyLinkId :
```

### `New-AzFrontDoorRulesEngine`

Return field "RulesEngineRules" has been changed to Rule

#### Before

```powershell
New-AzFrontDoorRulesEngine -ResourceGroupName $resourceGroupName -FrontDoorName $frontDoorName -Name myRulesEngine -Rule $rulesEngineRule1
```

```output
Name          RulesEngineRules
----          ----------------
myRulesEngine {rules1}
```

#### After

```powershell
New-AzFrontDoorRulesEngine -ResourceGroupName $resourceGroupName -FrontDoorName $frontDoorName -Name myRulesEngine -Rule $rulesEngineRule1
```

```output
Id                : /subscriptions/{subId}/resourcegroups/{resourceGroupName}/providers/Microsoft.Network/frontdoors/{frontDoorName}/rulesengines/rulesengine3
Name              : rulesengine3
ResourceGroupName : {resourceGroupName}
ResourceState     : Enabled
Rule              : {{
                      "name": "rule111",
                      "priority": 0,
                      "action": {
                        "requestHeaderActions": [ ],
                        "responseHeaderActions": [
                          {
                            "headerActionType": "Overwrite",
                            "headerName": "ff",
                            "value": "ff"
                          }
                        ]
                      },
                      "matchConditions": [
                        {
                          "rulesEngineMatchVariable": "QueryString",
                          "rulesEngineOperator": "Contains",
                          "negateCondition": false,
                          "rulesEngineMatchValue": [ "fdfd" ],
                          "transforms": [ ]
                        }
                      ],
                      "matchProcessingBehavior": "Continue"
                    }}
Type              : Microsoft.Network/frontdoors/rulesengines
```

### `New-AzFrontDoorRulesEngineMatchConditionObject`

Return field names have been changed


#### Before
```powershell
New-AzFrontDoorRulesEngineMatchConditionObject -MatchVariable RequestHeader -Operator Equal -MatchValue allowoverride -Transform "LowerCase", "UpperCase"-Selector Rules-Engine-Route-Forward -NegateCondition $false
```

```output
RulesEngineMatchVariable : RequestHeader
RulesEngineMatchValue    : {allowoverride}
Selector                 : Rules-Engine-Route-Forward
RulesEngineOperator      : Equal
NegateCondition          : False
Transform                : {Lowercase, Uppercase}
```
#### After
```powershell
New-AzFrontDoorRulesEngineMatchConditionObject -MatchVariable RequestHeader -Operator Equal -MatchValue allowoverride -Transform "LowerCase", "UpperCase"-Selector Rules-Engine-Route-Forward -NegateCondition $false
```

```output
MatchValue      : {allowoverride}
MatchVariable   : RequestHeader
NegateCondition : False
Operator        : Equal
Selector        : Rules-Engine-Route-Forward
Transform       : {LowerCase, UpperCase}
```

### `New-AzFrontDoorWafManagedRuleObject`

The return type field names have been changed from plural to singular

#### Before
```powershell
$ruleOverride1 = New-AzFrontDoorWafManagedRuleOverrideObject -RuleId "942250" -Action Log
$ruleOverride2 = New-AzFrontDoorWafManagedRuleOverrideObject -RuleId "942251" -Action Log
$override1 = New-AzFrontDoorWafRuleGroupOverrideObject -RuleGroupName SQLI -ManagedRuleOverride $ruleOverride1,$ruleOverride2

$ruleOverride3 = New-AzFrontDoorWafManagedRuleOverrideObject -RuleId "941280" -Action Log
$override2 = New-AzFrontDoorWafRuleGroupOverrideObject -RuleGroupName XSS -ManagedRuleOverride $ruleOverride3

New-AzFrontDoorWafManagedRuleObject -Type DefaultRuleSet -Version "preview-0.1" -RuleGroupOverride $override1,$override2
```

```output
RuleGroupOverrides RuleSetType    RuleSetVersion
------------------ -----------    --------------
{SQLI, XSS}        DefaultRuleSet preview-0.1
```

#### After

#### Before
```powershell
$ruleOverride1 = New-AzFrontDoorWafManagedRuleOverrideObject -RuleId "942250" -Action Log
$ruleOverride2 = New-AzFrontDoorWafManagedRuleOverrideObject -RuleId "942251" -Action Log
$override1 = New-AzFrontDoorWafRuleGroupOverrideObject -RuleGroupName SQLI -ManagedRuleOverride $ruleOverride1,$ruleOverride2

$ruleOverride3 = New-AzFrontDoorWafManagedRuleOverrideObject -RuleId "941280" -Action Log
$override2 = New-AzFrontDoorWafRuleGroupOverrideObject -RuleGroupName XSS -ManagedRuleOverride $ruleOverride3

New-AzFrontDoorWafManagedRuleObject -Type DefaultRuleSet -Version "preview-0.1" -RuleGroupOverride $override1,$override2
```

```output
Exclusion         :
RuleGroupOverride : {{
                      "ruleGroupName": "SQLI",
                      "rules": [
                        {
                          "ruleId": "942250",
                          "action": "Log"
                        },
                        {
                          "ruleId": "942251",
                          "action": "Log"
                        }
                      ]
                    }, {
                      "ruleGroupName": "XSS",
                      "rules": [
                        {
                          "ruleId": "941280",
                          "action": "Log"
                        }
                      ]
                    }}
RuleSetAction     :
Type              : DefaultRuleSet
Version           : preview-0.1
```

### `New-AzFrontDoorWafMatchConditionObject`

Return field names have been changed


#### Before
```powershell
New-AzFrontDoorWafMatchConditionObject -MatchVariable RequestHeader -OperatorProperty Contains -Selector "User-Agent" -MatchValue "Windows"
```

```output
MatchVariable OperatorProperty MatchValue Selector   NegateCondition Transform
------------- ---------------- ---------- --------   --------------- ---------
RequestHeader Contains         {Windows}  User-Agent           False

```

#### After
```powershell
New-AzFrontDoorWafMatchConditionObject -MatchVariable RequestHeader -OperatorProperty Contains -Selector "User-Agent" -MatchValue "Windows"
```

```output
MatchValue       : {Windows}
MatchVariable    : RequestHeader
NegateCondition  :
OperatorProperty : Contains
Selector         : User-Agent
Transform        :

```

### `New-AzFrontDoorWafPolicy`

The return value changes.

#### before
```powershell
New-AzFrontDoorWafPolicy -Name $policyName -ResourceGroupName $resourceGroupName -Customrule $customRule1,$customRule2 -ManagedRule $managedRule1 -EnabledState Enabled -Mode Prevention -RedirectUrl "https://www.bing.com/" -CustomBlockResponseStatusCode 405 -CustomBlockResponseBody "<html><head><title>You are blocked!</title></head><body></body></html>"
```

```output
Name         PolicyMode PolicyEnabledState RedirectUrl
----         ---------- ------------------ -----------
{policyName} Prevention            Enabled https://www.bing.com/
```

#### After

```powershell
New-AzFrontDoorWafPolicy -Name $policyName -ResourceGroupName $resourceGroupName -Customrule $customRule1,$customRule2 -ManagedRule $managedRule1 -EnabledState Enabled -Mode Prevention -RedirectUrl "https://www.bing.com/" -CustomBlockResponseStatusCode 405 -CustomBlockResponseBody "<html><head><title>You are blocked!</title></head><body></body></html>"
```

```output
Customrule           : {customrule0, customrule01}
Etag                 :
FrontendEndpointLink : {}
Id                   : /subscriptions/{subid}/resourcegroups/{rg}/providers/Microsoft.Network/frontdoorwebapplicationfirewallpolicies/{policyName}
Location             : Global
ManagedRuleSet       : {{
                         "ruleSetType": "Microsoft_DefaultRuleSet",
                         "ruleSetVersion": "2.0",
                         "ruleSetAction": "Block",
                         "exclusions": [ ],
                         "ruleGroupOverrides": [ ]
                       }}
Name                 : {policyName}
PolicySetting        : {
                         "enabledState": "Enabled",
                         "mode": "Detection",
                         "customBlockResponseStatusCode": 403,
                         "requestBodyCheck": "Enabled"
                       }
ProvisioningState    : Succeeded
ResourceGroupName    : {rg}
ResourceState        : Enabled
RoutingRuleLink      :
SecurityPolicyLink   : {{
                         "id": "/subscriptions/{subid}/resourcegroups/{rg}/providers/Microsoft.Cdn/profiles/hdis-fe/securitypolicies/premium"
                       }}
SkuName              : Premium_AzureFrontDoor
Tag                  : {
                       }
Type                 : Microsoft.Network/frontdoorwebapplicationfirewallpolicies
```

### `New-AzFrontDoorWafManagedRuleOverrideObject`

The return type field names have been changed from plural to singular

#### Before

```powershell
$ruleOverride1 = New-AzFrontDoorWafManagedRuleOverrideObject -RuleId "942250" -Action Log
$ruleOverride2 = New-AzFrontDoorWafManagedRuleOverrideObject -RuleId "942251" -Action Log

New-AzFrontDoorWafRuleGroupOverrideObject -RuleGroupName SQLI -ManagedRuleOverride $ruleOverride1,$ruleOverride2
```

```output
RuleGroupName ManagedRuleOverrides
------------- --------------------
SQLI          {942250, 942251}
```



### After
```powershell
$ruleOverride1 = New-AzFrontDoorWafManagedRuleOverrideObject -RuleId "942250" -Action Log
$ruleOverride2 = New-AzFrontDoorWafManagedRuleOverrideObject -RuleId "942251" -Action Log

New-AzFrontDoorWafRuleGroupOverrideObject -RuleGroupName SQLI -ManagedRuleOverride $ruleOverride1,$ruleOverride2
```

```output
Exclusion ManagedRuleOverride                                                                              RuleGroupName
--------- -------------------                                                                              -------------
          {{…                                                                                              SQLI
```

### `New-AzFrontDoor`

The return type field names have been changed from plural to singular

#### Before

```powershell
Set-AzFrontDoor -Name "frontDoor1" -ResourceGroupName "resourceGroup1" -RoutingRule $routingrule1 -BackendPool $backendpool1 -FrontendEndpoint $frontendEndpoint1 -LoadBalancingSetting $loadBalancingSetting1 -HealthProbeSetting $healthProbeSetting1 -BackendPoolsSetting $backendPoolsSetting1
```

```output
FriendlyName                : frontdoor1
RoutingRules                : {routingrule1}
BackendPools                : {backendpool1}
BackendPoolsSetting         : {backendPoolsSetting1}
EnforceCertificateNameCheck : {backendPoolsSetting1.EnforceCertificateNameCheck}
HealthProbeSettings         : {healthProbeSetting1}
LoadBalancingSettings       : {loadbalancingsetting1}
FrontendEndpoints           : {frontendendpoint1}
EnabledState                : Enabled
ResourceState               : Enabled
ProvisioningState           : Succeeded
Cname                       :
Tags                        : {tag1, tag2}
Id                          : /subscriptions/{guid}/resourcegroups/rg1/providers/Microsoft.Network/frontdoors/frontdoor1
Name                        : frontdoor1
Type                        : Microsoft.Network/frontdoors
```

#### After

```powershell
Set-AzFrontDoor -Name "frontDoor1" -ResourceGroupName "resourceGroup1" -RoutingRule $routingrule1 -BackendPool $backendpool1 -FrontendEndpoint $frontendEndpoint1 -LoadBalancingSetting $loadBalancingSetting1 -HealthProbeSetting $healthProbeSetting1 -BackendPoolsSetting $backendPoolsSetting1
```

```output
BackendPool          : {backendpool1}
BackendPoolsSetting  : {backendPoolsSetting1}
Cname                :
EnabledState         : Disabled
ExtendedProperty     : {
                         "MigratedTo": {link0}
                       }
FriendlyName         : frontDoor1
FrontdoorId          : {guid0}
FrontendEndpoint     : {frontendEndpoint1}
HealthProbeSetting   : {HealthProbeSetting1}
Id                   : /subscriptions/{guid}/resourcegroups/rg1/providers/M
                        icrosoft.Network/frontdoors/frontdoor1
LoadBalancingSetting : {LoadBalancingSetting1}
Location             : Global
Name                 : frontDoor1
ProvisioningState    : Succeeded
ResourceGroupName    : {rg1}
ResourceState        : Migrated
RoutingRule          : {RoutingRule1}
RulesEngine          : {RulesEngine0,RulesEngine1}
Tag                  : {
                       }
Type                 : Microsoft.Network/frontdoors
```

### `Set-AzFrontDoorRulesEngine`

Return field "RulesEngineRules" has been changed to Rule

#### Before

```powershell
Set-AzFrontDoorRulesEngine -ResourceGroupName $resourceGroupName -FrontDoorName $frontDoorName -Name myRulesEngine -Rule $rulesEngineRule1
```

```output
Name          RulesEngineRules
----          ----------------
myRulesEngine {rules1}
```

#### After

```powershell
Set-AzFrontDoorRulesEngine -ResourceGroupName $resourceGroupName -FrontDoorName $frontDoorName -Name myRulesEngine -Rule $rulesEngineRule1
```

```output
Id                : /subscriptions/{subId}/resourcegroups/{resourceGroupName}/providers/Microsoft.Network/frontdoors/{frontDoorName}/rulesengines/rulesengine3
Name              : rulesengine3
ResourceGroupName : {resourceGroupName}
ResourceState     : Enabled
Rule              : {{
                      "name": "rule111",
                      "priority": 0,
                      "action": {
                        "requestHeaderActions": [ ],
                        "responseHeaderActions": [
                          {
                            "headerActionType": "Overwrite",
                            "headerName": "ff",
                            "value": "ff"
                          }
                        ]
                      },
                      "matchConditions": [
                        {
                          "rulesEngineMatchVariable": "QueryString",
                          "rulesEngineOperator": "Contains",
                          "negateCondition": false,
                          "rulesEngineMatchValue": [ "fdfd" ],
                          "transforms": [ ]
                        }
                      ],
                      "matchProcessingBehavior": "Continue"
                    }}
Type              : Microsoft.Network/frontdoors/rulesengines
```


### `Update-AzFrontDoorWafPolicy`

The return value changes.

#### before
```powershell
Update-AzFrontDoorWafPolicy -Name $policyName -ResourceGroupName $resourceGroupName -Customrule $customRule1,$customRule2 -ManagedRule $managedRule1 -EnabledState Enabled -Mode Prevention -RedirectUrl "https://www.bing.com/" -CustomBlockResponseStatusCode 405 -CustomBlockResponseBody "<html><head><title>You are blocked!</title></head><body></body></html>"
```

```output
Name         PolicyMode PolicyEnabledState RedirectUrl
----         ---------- ------------------ -----------
{policyName} Prevention            Enabled https://www.bing.com/
```

#### After

```powershell
Update-AzFrontDoorWafPolicy -Name $policyName -ResourceGroupName $resourceGroupName -Customrule $customRule1,$customRule2 -ManagedRule $managedRule1 -EnabledState Enabled -Mode Prevention -RedirectUrl "https://www.bing.com/" -CustomBlockResponseStatusCode 405 -CustomBlockResponseBody "<html><head><title>You are blocked!</title></head><body></body></html>"
```

```output
Customrule           : {customrule0, customrule01}
Etag                 :
FrontendEndpointLink : {}
Id                   : /subscriptions/{subid}/resourcegroups/{rg}/providers/Microsoft.Network/frontdoorwebapplicationfirewallpolicies/{policyName}
Location             : Global
ManagedRuleSet       : {{
                         "ruleSetType": "Microsoft_DefaultRuleSet",
                         "ruleSetVersion": "2.0",
                         "ruleSetAction": "Block",
                         "exclusions": [ ],
                         "ruleGroupOverrides": [ ]
                       }}
Name                 : {policyName}
PolicySetting        : {
                         "enabledState": "Enabled",
                         "mode": "Detection",
                         "customBlockResponseStatusCode": 403,
                         "requestBodyCheck": "Enabled"
                       }
ProvisioningState    : Succeeded
ResourceGroupName    : {rg}
ResourceState        : Enabled
RoutingRuleLink      :
SecurityPolicyLink   : {{
                         "id": "/subscriptions/{subid}/resourcegroups/{rg}/providers/Microsoft.Cdn/profiles/hdis-fe/securitypolicies/premium"
                       }}
SkuName              : Premium_AzureFrontDoor
Tag                  : {
                       }
Type                 : Microsoft.Network/frontdoorwebapplicationfirewallpolicies
```

### Get-AzCdnProfile
The usage stays the same

#### Before
```
Get-AzCdnProfile -ResourceGroupName testps-rg-da16jm
```
#### After
```
Get-AzCdnProfile -ResourceGroupName testps-rg-da16jm
```

### Get-AzFrontDoorCdnProfile
The usage stays the same

#### Before
```
Get-AzFrontDoorCdnProfile -ResourceGroupName testps-rg-da16jm
```
#### After
```
Get-AzFrontDoorCdnProfile -ResourceGroupName testps-rg-da16jm
```

### New-AzCdnProfile
The usage stays the same

#### Before
```
New-AzCdnProfile -ResourceGroupName testps-rg-da16jm -Name cdn001 -SkuName Standard_Microsoft -Location Global
```
#### After
```
New-AzCdnProfile -ResourceGroupName testps-rg-da16jm -Name cdn001 -SkuName Standard_Microsoft -Location Global
```

### New-AzFrontDoorCdnProfile
The usage stays the same

#### Before
```
New-AzFrontDoorCdnProfile -ResourceGroupName testps-rg-da16jm -Name fdp-v542q6 -SkuName Standard_AzureFrontDoor -Location Global
```
#### After
```
New-AzFrontDoorCdnProfile -ResourceGroupName testps-rg-da16jm -Name fdp-v542q6 -SkuName Standard_AzureFrontDoor -Location Global
```

### Update-AzCdnProfile
The usage stays the same

#### Before
```
$tags = @{
    Tag1 = 11
    Tag2  = 22
}
Update-AzCdnProfile -ResourceGroupName testps-rg-da16jm -Name cdn001 -Tag $tags
```
#### After
```
$tags = @{
    Tag1 = 11
    Tag2  = 22
}
Update-AzCdnProfile -ResourceGroupName testps-rg-da16jm -Name cdn001 -Tag $tags
```

### Update-AzFrontDoorCdnProfile
The usage stays the same

#### Before
```
$tags = @{
    Tag1 = 11
    Tag2  = 22
}
Update-AzFrontDoorCdnProfile -ResourceGroupName testps-rg-da16jm -Name fdp-v542q6 -Tag $tags
```
#### After
```
$tags = @{
    Tag1 = 11
    Tag2  = 22
}
Update-AzFrontDoorCdnProfile -ResourceGroupName testps-rg-da16jm -Name fdp-v542q6 -Tag $tags
```

### Update-AzFrontDoorCdnProfileSku
The usage stays the same

#### Before
```
$nullUpgradePara = @{}
Update-AzFrontDoorCdnProfileSku -ProfileName profileName -ResourceGroupName rgName -ProfileUpgradeParameter $nullUpgradePara
```
#### After
```
$nullUpgradePara = @{}
Update-AzFrontDoorCdnProfileSku -ProfileName profileName -ResourceGroupName rgName -ProfileUpgradeParameter $nullUpgradePara
```

## Az.Oracle

### `New-AzOracleAutonomousDatabase` and `Update-AzOracleAutonomousDatabase`


Cmdlets exposed a parameter named -ScheduledOperations, however he functionality was not implemented. 
The parameter has been renamed to -ScheduledOperationsList and now requires a nested object for specifying the day of the week. This new parameter enables the previously blocked granular scheduling functionality via the updated API schema.

#### Before

```PowerShell
$db = New-AzOracleAutonomousDatabase -ResourceGroupName "rg000" -Name "databasedb1" `
    -AutonomousMaintenanceScheduleType "Regular" `
    -Location "eastus" -AdminPassword '********' -DataStorageSizeInTb 1
```

#### After

```PowerShell

# Define a specific daily schedule 
$schedule = @{
    DayOfWeek = @{ Name = "Monday" } 
    ScheduledStartTime = "04:00" 
    ScheduledStopTime = "10:00" 
}

$db = New-AzOracleAutonomousDatabase -ResourceGroupName "rg000" -Name "databasedb1" `
    -AutonomousMaintenanceScheduleType "Regular" `
    -ScheduledOperationsList @($schedule) ` # <-- New parameter name (now functional)
    -Location "eastus" -AdminPassword '********' -DataStorageSizeInTb 1

# The output object has changed to ScheduledOperationsList and has the new nested structure.
$db.ScheduledOperationsList
```

## Az.ServiceFabric

### `Set-AzServiceFabricManagedNodeType`

Removed `ReimageByName`, `ReimageById`, and `ReimageByObj` parameter sets from `Set-AzServiceFabricManagedNodeType`. Use `Invoke-AzServiceFabricReimageManagedNodeType` cmdlet instead.

#### Before
```powershell
$rgName = "testRG"
$clusterName = "testCluster"
$nodeTypeName= "nt1"
Set-AzServiceFabricManagedNodeType -ResourceGroupName $rgName -ClusterName $clusterName  -Name $nodeTypeName -Reimage -NodeName nt1_0, nt1_3
```

#### After
```powershell
$rgName = "testRG"
$clusterName = "testCluster"
$nodeTypeName = "nt1"
Invoke-AzServiceFabricReimageManagedNodeType -ResourceGroupName $rgName -ClusterName $clusterName  -Name $nodeTypeName -NodeName nt1_0, nt1_3
```

## Modules migrated from autorest v3 to autorest v4

To maintain behavioral consistency and introduce new features supported by AutoRest v4, we have upgraded many modules to use AutoRest v4.
This upgrade has introduced several breaking changes.
Details about potential breaking changes and their mitigation approaches can be found at the following [link](https://go.microsoft.com/fwlink/?linkid=2333486).

### Potentially affected modules

- Az.Advisor
- Az.ApplicationInsights
- Az.ArcResourceBridge
- Az.Attestation
- Az.Automanage
- Az.Compute
- Az.ConfidentialLedger
- Az.ContainerRegistry
- Az.Dns
- Az.HealthcareApis
- Az.Monitor
- Az.NetworkCloud
- Az.Nginx
- Az.Relay
- Az.StorageMover
- Az.StreamAnalytics
- Az.Workloads
