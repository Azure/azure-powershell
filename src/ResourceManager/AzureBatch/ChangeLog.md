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
* Added new parameters to `New-AzureRmBatchAccount`.
    - `PoolAllocationMode`: The allocation mode to use for creating pools in the Batch account. To create a Batch account which allocates pool nodes in the user's subscription, set this to `UserSubscription`.
    - `KeyVaultId`: The resource ID of the Azure key vault associated with the Batch account.
    - `KeyVaultUrl`: The URL of the Azure key vault associated with the Batch account.
* Updated parameters to `New-AzureBatchTask`.
    - Removed the `RunElevated` switch. The `UserIdentity` parameter has been added to replace `RunElevated`, and the equivalent behavior can be achieved by constructing a `PSUserIdentity` as shown below:
        - $autoUser = New-Object Microsoft.Azure.Commands.Batch.Models.PSAutoUserSpecification -ArgumentList @("Task", "Admin")
        - $userIdentity = New-Object Microsoft.Azure.Commands.Batch.Models.PSUserIdentity $autoUser
    - Added the `AuthenticationTokenSettings` parameter. This parameter allows you to request the Batch service provide an authentication token to the task when it runs, avoiding the need to pass Batch account keys to the task in order to issue requests to the Batch service.
* Added the `UserAccounts` parameter to `New-AzureBatchPool`.
    - This parameter defines user accounts created on each node in the pool.
* Renamed the `Name` parameter to `Path` on `Get-AzureBatchNodeFile`, `Get-AzureBatchNodeFileContent`, and `Remove-AzureBatchNodeFile`.
    - A `Name` alias was created for the `Path` parameter.
* Changes to objects:
    - Removed the `RunElevated` property on `PSCloudTask`, `PSStartTask`, `PSJobManagerTask`, `PSJobPreparationTask`, and `PSJobReleaseTask`. The `UserIdentity` property has been added to replace `RunElevated`. Equivalent behavior to `RunElevated = $true` can be achieved by constructing a `PSUserIdentity` as shown below:
        - $autoUser = New-Object Microsoft.Azure.Commands.Batch.Models.PSAutoUserSpecification -ArgumentList @("Task", "Admin")
        - $userIdentity = New-Object Microsoft.Azure.Commands.Batch.Models.PSUserIdentity $autoUser
    - Added the `AuthenticationTokenSettings` property to `PSCloudTask` and `PSJobManagerTask`.
    - Added the `UserAccounts` property to `PSCloudPool` and `PSPoolSpecification`.
    - Renamed the `Name` property on `PSNodeFile` to `Path`.
    - Added the `DependencyAction` property to `PSExitOptions`.
    - Added the `OSDisk` property to `PSVirtualMachineConfiguration`. Note that in order to allow deploying nodes using custom VHDs, the Batch account being used must have been created with `PoolAllocationMode = UserSubscription`.
* Added support for Azure Active Directory based authentication.
    - To use Azure Active Directory authentication, retrieve a `BatchAccountContext` object using the `Get-AzureRmBatchAccount` cmdlet, and supply this `BatchAccountContext` to the `-BatchContext` parameter of a Batch service cmdlet. Azure Active Directory authentication is mandatory for accounts with `PoolAllocationMode = UserSubscription`.
    - For existing accounts or for new accounts created with `PoolAllocationMode = BatchService`, you may continue to use shared key authentication by retrieving a `BatchAccountContext` object using the `Get-AzureRmBatchAccoutKeys` cmdlet.

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