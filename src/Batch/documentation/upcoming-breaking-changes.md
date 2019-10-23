<!--
    Please leave this section at the top of the breaking change documentation.

    New breaking changes should go under the section titled "Upcoming Breaking Changes", and should adhere to the following format:

    # Upcoming Breaking Changes

    ## Release X.0.0 - January 2017

    The following cmdlets were affected this release:

    **Cmdlet 1**
    - Description of what has changed

    ```powershell
    # Old
    # Sample of how the cmdlet was previously called

    # New
    # Sample of how the cmdlet should now be called
    ```

    Note: the above section follows the template found in the link below: 

    https://github.com/Azure/azure-powershell/blob/dev/documentation/breaking-changes/breaking-change-template.md
-->

# Upcoming Breaking Changes

The following cmdlets were affected this release:

**New-AzBatchTask**
 - The `-ResourceFile` parameter now takes a collection of `PSResourceFile` objects, which can be constructed using the new **New-AzBatchResourceFile** cmdlet.
 - The `-CommandLine` parameter is now required in the `JobId_Single` and `JobObject_Single` parameter sets.
 - The `EnvironmentSettings` property of `PSCloudTask` was updated to `IDictionary` for easier use in PowerShell.

**Get-AzBatchTask**
 - Renamed `BlobSource` to `HttpUrl` on `PSResourceFile`.
 - The `EnvironmentSettings` property of `PSCloudTask` was updated to `IDictionary` for easier use in PowerShell.

**Get-AzBatchAccount**, **Get-AzBatchAccountKeys**, **New-AzBatchAccount**, **New-AzBatchAccountKey**, **Set-AzBatchAccount**
 - The `CoreQuota` property of `BatchAccountContext` is now called `DedicatedCoreQuota`.

**Get-AzBatchApplication**
 - Removed `ApplicationPackages` property of `PSApplication`.
 - The specific packages inside of an application now can be retrieved using **Get-AzBatchApplicationPackage**. For example: `Get-AzBatchApplication -AccountName myaccount -ResourceGroupName myresourcegroup -ApplicationId myapplication`.
 - Renamed `Id` to `Name` on `PSApplication`.

**Get-AzBatchApplicationPackage**, **New-AzBatchApplicationPackage**
 - Removed `Id` property of `PSApplicationPackage`.
 - Renamed `Version` to `Name` on `PSApplicationPackage`.

**Set-AzBatchPoolOSVersion**
 - Removed, this is no longer supported.

**New-AzBatchPool**, **Get-AzBatchPool**
 - Removed `OSDisk` property from `PSVirtualMachineConfiguration`.
 - Removed `TargetOSVersion` from `PSCloudServiceConfiguration`.
 - Renamed `CurrentOSVersion` to `OSVersion` on `PSCloudServiceConfiguration`.
 - The `EnvironmentSettings` property of `PSStartTask` was updated to `IDictionary` for easier use in PowerShell.
 - The `Metadata` property of `PSCloudPool` was updated to `IDictionary` for easier use in PowerShell.

**Get-AzBatchPoolUsageMetrics**
* Removed `DataEgressGiB` and `DataIngressGiB` from `PSPoolUsageMetrics`.

**New-AzBatchJob**, **Get-AzBatchJob**
 - The `EnvironmentSettings` property of `PSJobManagerTask` was updated to `IDictionary` for easier use in PowerShell.
 - The `EnvironmentSettings` property of `PSJobPreparationTask` was updated to `IDictionary` for easier use in PowerShell.
 - The `EnvironmentSettings` property of `PSJobReleaseTask` was updated to `IDictionary` for easier use in PowerShell.
 - The `CommonEnvironmentSettings` property of `PSCloudJob` was updated to `IDictionary` for easier use in PowerShell.
 - The `Metadata` property of `PSCloudJob` was updated to `IDictionary` for easier use in PowerShell.

 **New-AzBatchJobSchedule**, **Get-AzBatchJobSchedule** 
 - The `EnvironmentSettings` property of `PSJobManagerTask` was updated to `IDictionary` for easier use in PowerShell.
 - The `EnvironmentSettings` property of `PSJobPreparationTask` was updated to `IDictionary` for easier use in PowerShell.
 - The `EnvironmentSettings` property of `PSJobReleaseTask` was updated to `IDictionary` for easier use in PowerShell.
 - The `CommonEnvironmentSettings` property of `PSJobSpecification` was updated to `IDictionary` for easier use in PowerShell.
 - The `Metadata` property of `PSPoolSpecification` was updated to `IDictionary` for easier use in PowerShell.
 - The `Metadata` property of `PSJobSpecification` was updated to `IDictionary` for easier use in PowerShell.
 - The `Metadata` property of `PSJobSchedule` was updated to `IDictionary` for easier use in PowerShell.

**Set-AzBatchPoolOSVersion**
 - Removed this cmdlet.