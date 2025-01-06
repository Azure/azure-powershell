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
* upgraded nuget package to signed package.
* Fixed 'Object reference not set to an instance of an object' error when setting null values inside job `CommonEnvironmentSettings` property. 

## Version 3.6.4
* Migrate Batch SDK to generated SDK
  - Removed "Microsoft.Azure.Management.Batch" Version="15.0.0" PackageReference
  - Added Batch.Management.Sdk ProjectReference

## Version 3.6.3
* Fixed secrets exposure in example documentation.

## Version 3.6.2
* Fixed a bug where `New-AzBatchApplicationPackage` wouldn't work if the application `AllowUpdates` parameter was set to `$false`.

## Version 3.6.1
* Removed the out-of-date breaking change message for `Get-AzBatchCertificate` and `New-AzBatchCertificate`.

## Version 3.6.0
* Added new properties `ResourceTags`  and `UpgradePolicy` to `PSCloudPool` and `PSPoolSpecification`.
* Added new property `UpgradingOS` to `PSNodeCounts`.
* Added new properties `Caching`, `DiskSizeGB`, `ManagedDisk` and `WriteAcceleratorEnabled` to `PSOSDisk`.
* Added new properties `SecurityProfile` and `ServiceArtifactReference` to `PSVirtualMachineConfigurations`.
* Added new property `ScaleSetVmResourceId` to `PSVirtualMachineInfo`.

## Version 3.5.0
* Removed cmdlets: `Get-AzBatchPoolStatistic` and `Get-AzBatchJobStatistic`
* Deprecated cmdlets: `Get-AzBatchCertificate` and `New-AzBatchCertificate`
  - The Batch account certificates feature is deprecated. Please transition to using Azure Key Vault to securely access and install certificates on your Batch pools, [learn more](https://learn.microsoft.com/azure/batch/batch-certificate-migration-guide)

## Version 3.4.0
* Added new property `Encryption` of type `EncryptionProperties` to `AccountCreateParameters`.
  - Configures how customer data is encrypted inside the Batch account.

## Version 3.3.0
* Added new properties `CurrentNodeCommunicationMode` (read only) and `TargetCommunicationMode` of type `NodeCommunicationMode` to `PSCloudPool`.
  - Valid values for `NodeCommunicationMode`: Default, Classic, Simplified
  - When the `PSCloudPool` is updated with a new `TargetCommunicationMode` value, the Batch service will attempt to update the pool to the new value the next time the pool is resized down to zero compute nodes and back up.
* `PSPrivateLinkServiceConnectionState`'s `ActionRequired` property required has been renamed to `ActionsRequired`. The old property has been marked as obsolete, and now just returns the new property. This should not impact existing consumers.

## Version 3.2.1
* Fixed a bug wherein creating a new JobSchedule does not properly submit Output Files.

## Version 3.2.0

* Updated Az.Batch to use `Microsoft.Azure.Batch` SDK version 15.3.0
  - Add ability to assign user-assigned managed identities to `PSCloudPool`. These identities will be made available on each node in the pool, and can be used to access various resources.
  - Added `IdentityReference` property to the following models to support accessing resources via managed identity:
    - `PSAzureBlobFileSystemConfiguration`
    - `PSOutputFileBlobContainerDestination`
    - `PSContainerRegistry`
    - `PSResourceFile`
    - `PSUploadBatchServiceLogsConfiguration`
  - Added new `extensions` property to `PSVirtualMachineConfiguration` on `PSCloudPool` to specify virtual machine extensions for nodes
  - Added the ability to specify availability zones using a new property `NodePlacementConfiguration` on `VirtualMachineConfiguration`
  - Added new `OSDisk` property to `VirtualMachineConfiguration`, which contains settings for the operating system disk of the Virtual Machine.
    - The `Placement` property on `PSDiffDiskSettings` specifies the ephemeral disk placement for operating system disks for all VMs in the pool. Setting it to "CacheDisk" will store the ephemeral OS disk on the VM cache.
  - Added `MaxParallelTasks` property on `PSCloudJob` to control the maximum allowed tasks per job (defaults to -1, meaning unlimited).
  - Added `VirtualMachineInfo` property on `PSComputeNode` which contains information about the current state of the virtual machine, including the exact version of the marketplace image the VM is using.
  - Added `RecurrenceInterval` property to `PSSchedule` to control the interval between the start times of two successive job under a job schedule.
  - Added a new 'Get-AzBatchComputeNodeExtension' command, which gets a specific extension by name, or a list of all extensions, for a given compute node.
* Updated Az.Batch`Microsoft.Azure.Management.Batch` SDK version 14.0.0.
  - Added a new `Get-AzBatchSupportedVirtualMachineSku` command, which gets the list of Batch-supported Virtual Machine VM sizes available at a given location.
  - Added a new `Get-AzBatchTaskSlotCount` command, which gets the number of task slots required by a given job.
  - 'MaxTasksPerComputeNode' has been renamed to 'TaskSlotsPerNode', to match a change in functionality.
    - 'MaxTasksPerComputeNode' will remain as an alias but will be removed in a coming update.

## Version 3.1.1
* Removed assembly `System.Text.Encodings.Web.dll` [#16062]

## Version 3.1.0
* Updated Az.Batch to use `Microsoft.Azure.Management.Batch` SDK version to 11.0.0
* Added the ability to set the BatchAccount Identity in the `New-AzBatchAccount` cmdlet

## Version 3.0.0
* Updated Az.Batch to use `Microsoft.Azure.Batch` SDK version 13.0.0 and `Microsoft.Azure.Management.Batch` SDK version 9.0.0.
* Added the ability to select the kind of certificate being added using the new `-CertificateKind` parameter to `New-AzBatchCertificate`.
* Removed `ApplicationPackages` property from `PSApplication` which was previously always `$null`.
  - The specific packages inside of an application now can be retrieved using `Get-AzBatchApplicationPackage`. For example: `Get-AzBatchApplication -AccountName myaccount -ResourceGroupName myresourcegroup -ApplicationId myapplication`.
* When creating a pool using `New-AzBatchPool`, the `VirtualMachineImageId` property of `PSImageReference` can now only refer to a Shared Image Gallery image.
* When creating a pool using `New-AzBatchPool`, the pool can be provisioned without a public IP using the new `PublicIPAddressConfiguration` property of `PSNetworkConfiguration`.
  - The `PublicIPs` property of `PSNetworkConfiguration` has moved in to `PSPublicIPAddressConfiguration` as well. This property can only be specified if `IPAddressProvisioningType` is `UserManaged`.

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
