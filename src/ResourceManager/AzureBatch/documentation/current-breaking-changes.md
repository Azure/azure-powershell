<!--
    Please leave this section at the top of the breaking change documentation.

    New breaking changes should go under the section titled "Current Breaking Changes", and should adhere to the following format:

    ## Current Breaking Changes

    The following cmdlets were affected this release:

    **Cmdlet 1**
    - Description of what has changed

    ```powershell
    # Old
    # Sample of how the cmdlet was previously called

    # New
    # Sample of how the cmdlet should now be called
    ```

    ## Release X.0.0

    The following cmdlets were affected this release:

    **Cmdlet 1**
    - Description of what has changed

    ```powershell
    # Old
    # Sample of how the cmdlet was previously called

    # New
    # Sample of how the cmdlet should now be called
    ```

    Note: the above sections follow the template found in the link below: 

    https://github.com/Azure/azure-powershell/blob/dev/documentation/breaking-changes/breaking-change-template.md
-->

## Current Breaking Changes
## Release 5.0.0 - November 2017

### Changes to objects
- Renamed `ResizeError` to `ResizeErrors` on `PSCloudPool`, and it is now a collection.
- Renamed the `Name` property on `PSNodeFile` to `Path`.
- Renamed `PSTaskSchedulingError` to `PSTaskFailureInformation`.
- Renamed the `SchedulingError` property on `PSJobPreparationTaskExecutionInformation`, `PSJobReleaseTaskExecutionInformation`, `PSStartTaskInformation`, `PSSubtaskInformation`, and `PSTaskExecutionInformation` to `FailureInformation`.
  - `FailureInformation` is returned any time there is a task failure. This includes all previous scheduling error cases, as well as nonzero task exit codes, and file upload failures from the new output files feature.
- Renamed the `SchedulingError` property on `PSExitConditions` to `PreProcessingError`.
- `PSMultiInstanceSettings` constructor no longer takes a required `numberOfInstances` parameter, instead it takes a required `coordinationCommandLine` parameter.

The following cmdlets were affected this release:

**New-AzureBatchCertificate**
- Parameter `Password` being replaced in favor of a Secure string

```powershell

# Old
# New-AzureBatchCertificate [other required parameters] -Password "plain-text string"

# New
# New-AzureBatchCertificate [other required parameters] -Password $SecureStringVariable
```

**New-AzureBatchComputeNodeUser**
- Parameter `Password` being replaced in favor of a Secure string

```powershell

# Old
# New-AzureBatchComputeNodeUser [other required parameters] -Password "plain-text string"

# New
# New-AzureBatchComputeNodeUser [other required parameters] -Password $SecureStringVariable
```

**Set-AzureRmBatchComputeNodeUser**
- Parameter `Password` being replaced in favor of a Secure string

```powershell

# Old
# Set-AzureRmBatchComputeNodeUser [other required parameters] -Password "plain-text string"

# New
# Set-AzureRmBatchComputeNodeUser [other required parameters] -Password $SecureStringVariable
```

**New-AzureBatchTask**
 - Removed the `RunElevated` switch and replaced it with `UserIdentity`.

```powershell
# Old
New-AzureBatchTask -Id $taskId1 -JobId $jobId -CommandLine "cmd /c echo hello" -RunElevated $TRUE

# New
$autoUser = New-Object Microsoft.Azure.Commands.Batch.Models.PSAutoUserSpecification -ArgumentList @("Task", "Admin")
$userIdentity = New-Object Microsoft.Azure.Commands.Batch.Models.PSUserIdentity $autoUser
New-AzureBatchTask -Id $taskId1 -JobId $jobId -CommandLine "cmd /c echo hello" -UserIdentity $userIdentity
```

This additionally impacts the `RunElevated` property on `PSCloudTask`, `PSStartTask`, `PSJobManagerTask`, `PSJobPreparationTask`, and `PSJobReleaseTask`.

**New-AzureBatchPool**
 - Removed `TargetDedicated` and replaced it with `TargetDedicatedComputeNodes` and `TargetLowPriorityComputeNodes`.
 - `TargetDedicatedComputeNodes` has an alias `TargetDedicated`.

```powershell
# Old
New-AzureBatchPool [other parameters] [-TargetDedicated <Int32>]

# New
New-AzureBatchPool [other parameters] [-TargetDedicatedComputeNodes <Int32>] [-TargetLowPriorityComputeNodes <Int32>]
```

This also impacts: Start-AzureBatchPoolResize

**Get-AzureBatchNodeFile**
 - Removed `Name` and replaced it with `Path`.
 - `Path` has an alias `Name`.

```powershell
# Old
Get-AzureBatchNodeFile [other parameters] [[-Name] <String>]

# New
Get-AzureBatchNodeFile [other parameters] [[-Path] <String>]
```

This also impacts: Get-AzureBatchNodeFileContent, Remove-AzureBatchNodeFile