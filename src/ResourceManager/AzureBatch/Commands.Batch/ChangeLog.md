<!--
    Please leave this section at the top of the change log.

    Changes for the current release should go under the section titled "Current Release", and should adhere to the following format:

    ## Current Release
    * Overview of change #1
        - Additional information about change #1
    * Overview of change #2
        - Additional information about change #2
        - Additional information about change #2
    * Overview of change #3
    * Overview of change #4
        - Additional information about change #4

    ## YYYY.MM.DD - Version X.Y.Z (Previous Release)
    * Overview of change #1
        - Additional information about change #1
-->
## Current Release

## Version 4.1.6
* This module is outdated and will go out of support on 29 February 2024.
* The Az.AzureBatch module has all the capabilities of AzureRM.AzureBatch and provides the following improvements:
    - Greater security with token cache encryption and improved authentication.
    - Availability in Azure Cloud Shell and on Linux and macOS.
    - Support for all Azure services.
    - Allows use of Azure access tokens.
* We encourage you to start using the Az module as soon as possible to take advantage of these improvements.
* [Update your scripts](https://docs.microsoft.com/powershell/azure/migrate-from-azurerm-to-az) that use AzureRM PowerShell modules to use Az PowerShell modules by 29 February 2024.
* To automatically update your scripts, follow the [quickstart guide](https://docs.microsoft.com/powershell/azure/quickstart-migrate-azurerm-to-az-automatically).

## Version 4.1.5
* Fixed issue with default resource groups not being set.
* Updated common runtime assemblies

## Version 4.1.4
* Fixed issue with default resource groups not being set.

## Version 4.1.3
* Updated to the latest version of the Azure ClientRuntime.

## Version 4.1.2
* Updated all help files to include full parameter types and correct input/output types.

## Version 4.1.1
* Fixed formatting of OutputType in help files

## Version 4.1.0
* Release new cmdlet Get-AzureBatchPoolNodeCounts
* Release new cmdlet Start-AzureBatchComputeNodeServiceLogUpload

## Version 4.0.7
* Set minimum dependency of module to PowerShell 5.0
* Updated New-AzureBatchPool documentation to remove deprecated example

## Version 4.0.6
* Updated to the latest version of the Azure ClientRuntime

## Version 4.0.5
* Fix issue with Default Resource Group in CloudShell

## Version 4.0.4
* Added Location Completer to -Location parameters allowing tab completion through valid Locations
* Added ResourceGroup Completer to -ResourceGroup parameters allowing tab completion through resource groups in current subscription

## Version 4.0.3
* Fixed a bug where account operations without a resource group failed to auto-detect the resource group.

## Version 4.0.1
* Fixed assembly loading issue that caused some cmdlets to fail when executing

## Version 4.0.0
* NOTE: This is a breaking change release. Please see the migration guide (https://aka.ms/azps-migration-guide) for a full list of breaking changes introduced.
* Added new parameters to `New-AzureRmBatchAccount`.
    - `PoolAllocationMode`: The allocation mode to use for creating pools in the Batch account. To create a Batch account which allocates pool nodes in the user's subscription, set this to `UserSubscription`.
    - `KeyVaultId`: The resource ID of the Azure key vault associated with the Batch account.
    - `KeyVaultUrl`: The URL of the Azure key vault associated with the Batch account.
* Updated parameters to `New-AzureBatchTask`.
    - Removed the `RunElevated` switch. The `UserIdentity` parameter has been added to replace `RunElevated`, and the equivalent behavior can be achieved by constructing a `PSUserIdentity` as shown below:
        - $autoUser = New-Object Microsoft.Azure.Commands.Batch.Models.PSAutoUserSpecification -ArgumentList @("Task", "Admin")
        - $userIdentity = New-Object Microsoft.Azure.Commands.Batch.Models.PSUserIdentity $autoUser
    - Added the `AuthenticationTokenSettings` parameter. This parameter allows you to request the Batch service provide an authentication token to the task when it runs, avoiding the need to pass Batch account keys to the task in order to issue requests to the Batch service.
    - Added the `ContainerSettings` parameter.
        - This parameter allows you to request the Batch service run the task inside a container.
    - Added the `OutputFiles` parameter.
        - This parameter allows you to configure the task to upload files to Azure Storage after it has finished.
* Updated parameters to `New-AzureBatchPool`.
    - Added the `UserAccounts` parameter.
        - This parameter defines user accounts created on each node in the pool.
    - Added `TargetLowPriorityComputeNodes` and renamed `TargetDedicated` to `TargetDedicatedComputeNodes`.
        - A `TargetDedicated` alias was created for the `TargetDedicatedComputeNodes` parameter.
    - Added the `NetworkConfiguration` parameter.
        - This parameter allows you to configure the pools network settings.
* Updated parameters to `New-AzureBatchCertificate`.
    - The `Password` parameter is now a `SecureString`.
* Updated parameters to `New-AzureBatchComputeNodeUser`.
    - The `Password` parameter is now a `SecureString`.
* Updated parameters to `Set-AzureBatchComputeNodeUser`.
    - The `Password` parameter is now a `SecureString`.
* Renamed the `Name` parameter to `Path` on `Get-AzureBatchNodeFile`, `Get-AzureBatchNodeFileContent`, and `Remove-AzureBatchNodeFile`.
    - A `Name` alias was created for the `Path` parameter.
* Changes to objects:
    - Removed the `RunElevated` property on `PSCloudTask`, `PSStartTask`, `PSJobManagerTask`, `PSJobPreparationTask`, and `PSJobReleaseTask`. The `UserIdentity` property has been added to replace `RunElevated`. Equivalent behavior to `RunElevated = $true` can be achieved by constructing a `PSUserIdentity` as shown below:
        - $autoUser = New-Object Microsoft.Azure.Commands.Batch.Models.PSAutoUserSpecification -ArgumentList @("Task", "Admin")
        - $userIdentity = New-Object Microsoft.Azure.Commands.Batch.Models.PSUserIdentity $autoUser
    - Added the `AuthenticationTokenSettings` property to `PSCloudTask` and `PSJobManagerTask`.
    - Added the `OutputFiles` property to `PSCloudTask`, and `PSJobManagerTask`.
    - Added the `ContainerSettings` property to `PSCloudTask`, `PSStartTask`, `PSJobManagerTask`, `PSJobPreparationTask`, and `PSJobReleaseTask`.
    - Added the `AllowLowPriorityNode` property to `PSJobManagerTask`.
    - Renamed the `SchedulingError` property on `PSJobPreparationTaskExecutionInformation`, `PSJobReleaseTaskExecutionInformation`, `PSStartTaskInformation`, `PSSubtaskInformation`, and `PSTaskExecutionInformation` to `FailureInformation`.
        - `FailureInformation` is returned any time there is a task failure. This includes all previous scheduling error cases, as well as nonzero task exit codes, and file upload failures from the new output files feature.
    - Renamed `PSTaskSchedulingError` to `PSTaskFailureInformation`.
    - Added the `ContainerInformation` and `Result` properties to `PSJobPreparationTaskExecutionInformation`, `PSJobReleaseTaskExecutionInformation`, `PSStartTaskInformation`, `PSSubtaskInformation`, and `PSTaskExecutionInformation`.
    - Added the `UserAccounts` property to `PSCloudPool` and `PSPoolSpecification`.
    - Added the `TargetLowPriorityComputeNodes` property to `PSCloudPool` and `PSPoolSpecification`, and renamed `TargetDedicated` to `TargetDedicatedComputeNodes`.
    - Renamed the `Name` property on `PSNodeFile` to `Path`.
    - Added the `EndpointConfiguration` and `IsDedicated` property to `PSComputeNode`.
    - Renamed the `SchedulingError` property on `PSExitConditions` to `PreProcessingError`.
    - Added the `FileUploadError` to `PSExitConditions`.
    - Added the `DependencyAction` property to `PSExitOptions`.
    - Added the `OSDisk`, `ContainerConfiguration`, `DataDisks`, and `LicenseType` properties to `PSVirtualMachineConfiguration`.
    - Added the `VirtualMachineImageId` property to `PSImageReference`. Note that in order to allow deploying nodes using custom VHDs, the `BatchAccountContext` must be using Azure Active Directory authentication.
    - Added the `OnAllTasksComplete` and `OnTaskFailure` properties to `PSJobSpecification`.
    - Added the `EndpointConfiguration` property to `PSNetworkConfiguration`.
    - Renamed `ResizeError` to `ResizeErrors` on `PSCloudPool`, and it is now a collection.
    - `PSMultiInstanceSettings` constructor no longer takes a required `numberOfInstances` parameter, instead it takes a required `coordinationCommandLine` parameter.
* Added support for Azure Active Directory based authentication.
    - To use Azure Active Directory authentication, retrieve a `BatchAccountContext` object using the `Get-AzureRmBatchAccount` cmdlet, and supply this `BatchAccountContext` to the `-BatchContext` parameter of a Batch service cmdlet. Azure Active Directory authentication is mandatory for accounts with `PoolAllocationMode = UserSubscription`.
    - For existing accounts or for new accounts created with `PoolAllocationMode = BatchService`, you may continue to use shared key authentication by retrieving a `BatchAccountContext` object using the `Get-AzureRmBatchAccoutKeys` cmdlet.
* Add support for online help
    - Run Get-Help with the -Online parameter to open the online help in your default Internet browser

## Version 3.4.1
 - Marked cmdlet parameters and type properties obsolete in
   preparation for upcoming breaking change release (Version 4.0.0)

## Version 3.4.0

## Version 3.3.1

## Version 3.3.0

## Version 3.2.1

## Version 3.2.0
- Added new Get-AzureBatchJobPreparationAndReleaseTaskStatus cmdlet.
- Added byte range start and end to Get-AzureBatchNodeFileContent parameters.

## Version 3.1.0

## Version 3.0.1

## Version 3.0.0

## Version 2.8.0

## Version 2.7.0

## Version 2.6.0

## Version 2.5.0

## Version 2.4.0

## Version 2.3.0
* Rename cmdlet Get-AzureRmBatchSubscriptionQuotas to Get-AzureRmBatchLocationsQuotas (an alias for the old command was created)
    - Rename return type PSBatchSubscriptionQuotas to PSBatchLocationQuotas (no property changes)
