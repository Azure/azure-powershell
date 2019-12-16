<!--
    Please leave this section at the top of the change log.

    Changes for the upcoming release should go under the section titled "Upcoming Release", and should adhere to the following format:

    ## Upcoming Release
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
## Upcoming Release

## Version 2.0.2
* Update references in .psd1 to use relative path
* Fix issue #10602, where **New-AzBatchPool** did not properly send `VirtualMachineConfiguration.ContainerConfiguration` or `VirtualMachineConfiguration.DataDisks` to the server.

## Version 2.0.1
* Renamed `CoreQuota` on `BatchAccountContext` to `DedicatedCoreQuota`. There is also a new `LowPriorityCoreQuota`.
  - This impacts **Get-AzBatchAccount**.
* **New-AzBatchTask** `-ResourceFile` parameter now takes a collection of `PSResourceFile` objects, which can be constructed using the new **New-AzBatchResourceFile** cmdlet.
* New **New-AzBatchResourceFile** cmdlet to help create `PSResourceFile` objects. These can be supplied to **New-AzBatchTask** on the `-ResourceFile` parameter.
  - This supports two new kinds of resource file in addition to the existing `HttpUrl` way:
    - `AutoStorageContainerName` based resource files download an entire auto-storage container to the Batch node.
    - `StorageContainerUrl` based resource files download the container specified in the URL to the Batch node.
* Removed `ApplicationPackages` property of `PSApplication` returned by **Get-AzBatchApplication**.
  - The specific packages inside of an application now can be retrieved using **Get-AzBatchApplicationPackage**. For example: `Get-AzBatchApplication -AccountName myaccount -ResourceGroupName myresourcegroup -ApplicationId myapplication`.
* Renamed `ApplicationId` to `ApplicationName` on **Get-AzBatchApplicationPackage**, **New-AzBatchApplicationPackage**, **Remove-AzBatchApplicationPackage**, **Get-AzBatchApplication**, **New-AzBatchApplication**, **Remove-AzBatchApplication**, and **Set-AzBatchApplication**.
  - `ApplicationId` now is an alias of `ApplicationName`.
* Added new `PSWindowsUserConfiguration` property to `PSUserAccount`.
* Renamed `Version` to `Name` on `PSApplicationPackage`.
* Renamed `BlobSource` to `HttpUrl` on `PSResourceFile`.
* Removed `OSDisk` property from `PSVirtualMachineConfiguration`.
* Removed **Set-AzBatchPoolOSVersion**. This operation is no longer supported.
* Removed `TargetOSVersion` from `PSCloudServiceConfiguration`.
* Renamed `CurrentOSVersion` to `OSVersion` on `PSCloudServiceConfiguration`.
* Removed `DataEgressGiB` and `DataIngressGiB` from `PSPoolUsageMetrics`.
* Removed **Get-AzBatchNodeAgentSku** and replaced it with  **Get-AzBatchSupportedImage**. 
  - **Get-AzBatchSupportedImage** returns the same data as **Get-AzBatchNodeAgentSku** but in a more friendly format.
  - New non-verified images are also now returned. Additional information about `Capabilities` and `BatchSupportEndOfLife` for each image is also included.
* Added ability to mount remote file-systems on each node of a pool via the new `MountConfiguration` parameter of **New-AzBatchPool**.
* Now support network security rules blocking network access to a pool based on the source port of the traffic. This is done via the `SourcePortRanges` property on `PSNetworkSecurityGroupRule`.
* When running a container, Batch now supports executing the task in the container working directory or in the Batch task working directory. This is controlled by the `WorkingDirectory` property on `PSTaskContainerSettings`.
* Added ability to specify a collection of public IPs on `PSNetworkConfiguration` via the new `PublicIPs` property. This guarantees nodes in the Pool will have an IP from the list user provided IPs.
* When not specified, the default value of `WaitForSuccess` on `PSSTartTask` is now `$True` (was `$False`).
* When not specified, the default value of `Scope` on `PSAutoUserSpecification` is now `Pool` (was `Task` on Windows and `Pool` on Linux).

## Version 1.1.2
* **Get-AzBatchNodeAgentSku** is deprecated and will be replaced by **Get-AzBatchSupportImage** in version 2.0.0.

## Version 1.1.1
* Fixed typo in help message and documentation to capitalize Windows
* Fixed miscellaneous typos across module

## Version 1.1.0
* Updated cmdlets with plural nouns to singular, and deprecated plural names.

## Version 1.0.0
* General availability of `Az.Batch` module
* Added the ability to see what version of the Azure Batch Node Agent is running on each of the VMs in a pool, via the new `NodeAgentInformation` property on `PSComputeNode`.
* Removed the `ValidationStatus` property from `PSTaskCounts`.
* The `Caching` default for `PSDataDisk` is now `ReadWrite` instead of `None`.
