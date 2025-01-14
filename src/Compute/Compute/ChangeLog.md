
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
* Upgraded Azure.Core to 1.44.1.
* Compute gallery related cmdlets will now use 2024-03-03 GalleryRP API calls. 

## Version 9.0.0
* Made `-PublicIpSku` parameter Standard by default in `New-AzVM`

## Version 8.5.0
* Added optional parameters `-SecurityPostureId` and `-SecurityPostureExcludeExtension` to cmdlets `New-AzVmss` and `New-AzVmssConfig`.
* Updated image aliases to be up-to-date in the azure-powershell\src\Compute\Strategies\ComputeRp\Images.json file.
* Added `NvmeDisk` argument completer to `DiffDiskPlacement` parameter for `Set-AzVMOSDisk` and `Set-AzVmssStorageProfile` cmdlets, allowing options for disk placement as `CacheDisk`, `ResourceDisk`, or `NvmeDisk`.

## Version 8.4.0
* Added `SkuProfileVmSize` and `SkuProfileAllocationStrategy` parameters to `New-AzVmss`, `New-AzVmssConfig`, and `Update-AzVmss` cmdlets for VMSS Instance Mix operations.
* Added a new optional parameter `-GenerateSshKey-type` to the `New-AzVM` cmdlet, allowing users to specify the type of SSH key to generate (Ed25519 or RSA).
* Added cx waning to the `New-AzVM` cmdlet, The default value of `publicIpSku` parameter will be changed from Basic to Standard.
* Added `EnableResilientVMCreate` and `EnableResilientVMDelete` parameters to `Update-AzVmss` and `New-AzVmssConfig` cmdlets for enhanced VM resilience options.
* Added `IsVMInStandByPool` property to `PSVirtualMachineInstanceView` object. [#25736]

## Version 8.3.0
* Fixed secrets exposure in example documentation.
* References are updated to use 2024-07-01 ComputeRP and 2024-03-02 DiskRP REST API calls.
* Added information on how to find VM Images when using `New-AzVM` with `-Image` parameter.
* Added `TimeCreated` read-only field to `PSVirtualMachineScaleSetVMProfile` object.
* Added parameter `-ResourceIdsOnly` to `Get-AzCapacityReservationGroup` cmdlet.
* Changed the `Set-AzVMOperatingSystem` cmdlet when the `-VM` parameter is used without an OSProfile. Now it will not throw a null reference exception when `-Credential` is not provided.
* Added parameter `-ForceDetach` to `Remove-AzVMDataDisk` cmdlet.

## Version 8.2.0
* Renamed parameter `-VmId` to `-SourceId` and added `-VmId` as an alias to `New-AzRestorePointCollection` cmdlet.

## Version 8.1.0
* Added parameter `-SourceResourceId` to cmdlet `Add-AzVMDataDisk`.
* Added parameter `-IdentityType` to cmdlet `Update-AzDiskEncryptionSet`.
* Added `Invoke-AzSpotPlacementScore` cmdlet, which calls the latest Spot Placement Score API. Set the original `Invoke-AzSpotPlacementRecommender` as alias to avoid breaking changes.

## Version 8.0.0
* Added new optional parameter `SecureVMGuestStateSAS` to cmdlet `Grant-AzDiskAccess`.
* [Breaking Change] Added ValidateNotNullOrEmpty for `-ResourceGroupName` and `-VMScaleSetName` parameters to `Get-AzVmss` cmdlet. [#20095]
* Added `Etag` property to PSVirtualMachine and PSVirtualMachineScaleSet objects.   
* Added parameters `-IfMatch` and `-IfNoneMatch` to `Update-AzVM`, `Update-AzVmss`, `New-AzVm`, `New-AzVmss`, `New-AzVmConfig`, and `New-AzVmssConfig` cmdlets.
* [Breaking Change] Cmdlet `New-AzGalleryImageDefinition` will default parameter `-HyperVGeneration` to `V2` if it is not set as `V1` explicitly, and also default parameter `-Feature` by adding `@{Name='SecurityType';Value='TrustedLaunchSupported'}` if the `SecurityType` feature is not set explicitly. 
* Resolved the bug with `New-AzVMConfig` for `-CommunityGalleryImageId` and `-SharedGalleryImageId` parameters.
* [Breaking Change] Added ValidateNotNullOrEmpty for `-ResourceGroupName` and `-VMScaleSetName` parameters to `Get-AzVmss` cmdlet. [#20095]
* [Breaking Change] Added new business logic to `New-AzVmss` and `New-AzVM` cmdlets. When the user explicitly sets the `SecurityType` to `Standard`, the Image alias defaults to `Win2022AzureEdition` to make future migrations to Trusted Launch easier.

## Version 7.3.0
* Added cmdlet `Invoke-AzSpotPlacementRecommender`.
* Fixed `Update-AzCapacityReservationGroup` to remove Subscriptions from SharingProfile.

## Version 7.2.0
* Added parameters `-scriptUriManagedIdentity`, `-outputBlobManagedIdentity`, `-errorBlobMangedIdentity`, and `-TreatFailureAsDeploymentFailure` to cmdlets `Set-AzVmRunCommand` and `Set-AzVmssRunCommand`. 
* Added new parameter `-EnableAutomaticOSUpgrade` to `New-AzVmss` cmdlet.
* Renamed parameter `-AutoOSUpgrade` to `-EnableAutomaticOSUpgrade` in `New-AzVmssConfig` cmdlet for consistency. Using `-AutoOSUpgrade` as parameter name will continue to work as it is added as an alias.
* Upgraded Azure.Core to 1.37.0.
* Az.Compute is updated to use the 2023-07-03 GalleryRP, 2024-03-01 ComputeRP and 2023-10-02 DiskRP API.
* Added new parameter `-TierOption` to `New-AzSnapshotConfig`.
* Added breaking change warnings for the May 2024 release. The warnings are for:
  `New-AzGalleryImageVersion` defaulting to turn on TrustedLaunchSupported and HyperVGeneration to V2.
  `New-AzVM` and `New-AzVmss` will default to the image `Windows Server 2022 Azure Edition` instead of `Windows 2016 Datacenter` by default.
  `Get-AzVmss` will no longer allow empty values to `ResourceGroupName` and `VMScaleSetName` to avoid a bug where it will just return nothing.
* Added a new parameter `-SharingProfile` to `New-AzCapacityReservationGroup` and `Update-AzCapacityReservationGroup`.
* Added the new parameter `SourceImageVMId` to the `New-AzGalleryImageVersion` cmdlet. Also added some error messages for this new parameter and the existing parameter `SourceImageId`. 
* Updated parameter `-TargetRegion` in `New-AzGalleryImageVersion` and `Update-AzGalleryImageVersion` to accept `ExcludeFromLatest` field. 

## Version 7.1.2
* Fixed `New-AzVM` when a source image is specified to avoid an error on the `Version` value.

## Version 7.1.1
* Fixed `New-AzVmss` to correctly work when using `-EdgeZone` by creating the Load Balancer in the correct edge zone.
* Removed references to image aliases in `New-AzVM` and `New-AzVmss` to images that were removed.
* Az.Compute is updated to use the 2023-09-01 ComputeRP REST API calls. 

## Version 7.1.0
* Added new parameter `-ElasticSanResourceId` to `New-AzSnapshotConfig` cmdlet.
* Added new parameter `-OptimizedForFrequentAttach` to `New-AzDiskConfig` cmdlet.
* Added new examples in `New-AzVM` and `New-AzVmss` for TrustedLaunch default usage.
* Fixed the `New-AzVM` bug to avoid accessing the `EncryptionAtHost` property for subscriptions who cannot access it since it is behind a feature flag.
* Updated `Get-AzVmExtension` to return instanceView when used with `-Status`.
* Reverted SSH Private Key File permission changes in `New-AzVm`.

## Version 7.0.0
* Added update functionality in `Update-AzVmss` for parameters `SecurityType`, `EnableSecureBoot`, and `EnableVtpm` for the parameter set with the Put operation.
* Upgraded Azure.Core to 1.35.0.
* [Breaking change] Removed unversioned and outdated linux image aliases of `CentOS`, `RHEL`, `UbuntuLTS` and `Debian`.
* [Breaking change] `New-AzVmss` will default to `OrchestrationMode` set as  `Flexible` if it is not set as `Uniform` explicitly.
* `New-AzVmss` can now create VMSS with `OrchestrationMode` set to `Flexible` using `-SinglePlacementGroup` and `-UpgradePolicy`.
* Removed unversioned and outdated images from New-AzVmss `-ImageName` argument completers.
* [Breaking Change] Added defaulting logic for VM and VMSS creation to set SecurityType to TrustedLaunch and SecureBootEnabled and VTpmEnalbed to true when those are not set by the user.
* [Breaking Change] Added defaulting logic for Disk creation to default to TrustedLaunch when able. Allows the user to turn this off by setting the SecurityType to Standard.
* Added new parameter `-VirtualMachineScaleSetId` to `Update-AzVm` cmdlet.
* Fixed `New-AzVmss` and `New-Azvm` to use `SharedGalleryImageId` parameter.
* Reduced File Permissions from 0644 to 0600 for SSH Private Key File in `New-AzVm`.
* Removed GuestAttestaion vm extension installation for Vmss and Vm creation cmdlets. 


## Version 6.3.0
* Added `-Hibernate` switch parameter to `Stop-AzVmss` default parameter set. 
* For `Get-AzVmRunCommand`, a bug is fixed to work when returning a list of RunCommands [#22403]
* Updated Azure.Core to 1.34.0.
* Added new cmdlets `Get-AzHostSize` and `Update-AzHost`.
* Added the `Standard` value to the `SecurityType` parameter to the cmdlets `Set-AzDiskSecurityType`, `New-AzvmssConfig`, `Set-AzVmssSecurityProfile`, `Update-AzVmss`, `New-AzVmss`, `New-AzVMConfig`, `Set-AzVMsecurityProfile`, and `New-AzVM`.
* Fixed `Update-AzVMSS` to update ImageReferenceSKU [#22195]
* Updated the above change to include `New-AzVMConfig` as 1 scenario was initially missed when only using this cmdlet.

## Version 6.2.0
* Fixed the `Update-AzVmss` cmdlet so the `AutomaticRepairGracePeriod`, `AutomaticRepairAction`, and `EnableAutomaticRepair` parameters function correctly.
* Updated help doc for `New-AzVM`, `New-AzVMConfig`, `New-AzVmss`, `New-AzVmssConfig`, `Update-AzVM`, and `Update-AzVmss` to include parameters that were previously added for Trusted Launch features.
* Updated Azure.Core to 1.33.0.

## Version 6.1.0
* Added useful examples to the `New-AzVMConfig` help doc.
* Added new `ResourceId` parameter to the `Get-AzVmss` cmdlet.
* Added `-SecurityType`, `-EnableSecureBoot` and `-EnableVtpm` parameters to `New-AzVm`,`New-AzVmConfig`, `New-AzVmss`, `New-AzVmssConfig`, `Update-AzVm` and `Update-AzVmss` cmdlets.
* Configured parameter flags `-EnableSecureBoot` and `-EnableVtpm` to default to True for TrustedLaunch and ConfidentialVM values for the `-SecurityType` parameter in `New-AzVm`,`New-AzVmConfig`, `New-AzVmss`, `New-AzVmssConfig`, `Update-AzVm` and `Update-AzVmss` cmdlets.
* Added a message to the user when they provide an outdated image alias to `New-AzVM` via the `-Image` parameter or to `New-AzVmss` via the `-ImageName` parameter.
  The non-versioned image aliases were updated to versioned values in October 2023, and this message is to help urge customers to use the newer versioned image alias values.
* Changed the installation behavior for the `GuestAttestation` extension in `New-AzVM` and `New-AzVmss` to set the property `EnableAutomaticUpgrade` to true.
* Changes to `Set-AzVMOperatingSystem` to correct unnecessary mandatory parameters.
* Changed the region for example 3 to eastus2 in the `New-AzVM` doc to resolve SKU not available errors.

## Version 6.0.0
* Added new switch parameter `OSImageScheduledEventEnabled` and string parameter `OSImageScheduledEventNotBeforeTimeoutInMinutes` to the cmdlets `New-AzVmssConfig` and `Update-AzVmss`.
* Fixed an issue that `Add-AzVhd` throws `FileNotFoundException` on Windows PowerShell. [#21321]
* Removed the `NextLink` parameter and parameter set from the `Get-AzVM` cmdlet.

## Version 5.7.1
* Added a breaking change warning to the `Get-AzVM` cmdlet to show that the `NextLink` parameter and parameter set will be removed in June 2023. The parameter has been non-functional for a long time. 
* Updated the breaking change warning in `New-AzVM` and `New-AzVmss` regarding using the new versioned image aliases to indicate that certain aliases will be removed next breaking change release.
* Updated the `Get-AzVMRunCommand` to include the `ProvisioningState` value. Fix [#21473]
* Updated Azure.Core to 1.31.0.

## Version 5.7.0
* Addressed bug in `Remove-AzVmss` to throw error when `-InstanceId` is null. [#21162]
* Added `-CustomData`, `-AdminPassword`, and `-ExactVersion` parameters to `Invoke-AzVMReimage`.
* Removed the image alias `CoreOS` as the publisher CoreOS no longer has any images for Azure. 
  Updated the names of the `openSUSE-Leap` and `SLES` aliases to `OpenSuseLeap154` and `SuseSles15SP4` respectively. Updated these aliases to point to an image that actually exists.
* Added a breaking change warning to `New-AzVM` and `New-AzVmss` for future planned image alias removals due to the images reaching their End of Support date. 
* Added new descriptive and versioned alias names for the Linux image aliases, including a new alias for  the `Kinvolk` publisher.
* Added 'ImageDeprecationStatus' to the output of Get-AzVmImage.

## Version 5.6.0
* Added `-NetworkAccessPolicy` parameter to `New-AzSnapshotUpdateConfig`.
* Added `-SharedGalleryImageId` parameter to `New-AzVM`, `New-AzVmConfig`, `New-AzVmss`, `New-AzVmssConfig`, `Update-AzVmss`, and `Set-AzVmssStorageProfile`.
* Updated `Set-AzVMDiagnosticsExtension` to correct capitalization by passing "StorageAccount" as configuration property instead of "storageAccount".
* Added condition in Automapper configurations to check for null Tag values for `PSDiskUpdate` and `PSSnapshotUpdate` to fix bug in Update-AzDisk and Update-AzSnapshot.

## Version 5.5.0
* Added breaking change message for `New-AzVmss`.
* Added `-PerformancePlus` parameter to `New-AzDiskConfig`
* Added 'MaxSurge' to Set-AzVmssRollingUpgradePolicyCommand
* Added support for 'latest' in 'Get-AzvmImage' '-Version' parameter
* Added `CompletionPercent` property to PSDisk object. 

## Version 5.4.0
* Added `-SkipIdentity`, `-PathUserIdentity`, `-IsTest` parameter to `Set-AzVMAEMExtension` 
* Added `ConsistencyMode` parameter to `New-AzRestorePoint`.
* Updated the storage account type value in several locations from the outdated `StandardLRS` to the current `Standard_LRS`.
* Filled in missing parameter descriptions across multiple parameters and improved some existing parameter descriptions.
* Updated Compute PS to use the new .Net SDK version 59.0.0. This includes an approved breaking change for a non-functional feature. 
  - The type of the property `Source` of type `Microsoft.Azure.Management.Compute.Models.GalleryDataDiskImage`, `Microsoft.Azure.Management.Compute.Models.GalleryOSDiskImage`, and `Microsoft.Azure.Management.Compute.Models.GalleryImageVersionStorageProfile` has changed from `Microsoft.Azure.Management.Compute.Models.GalleryArtifactVersionSource` to `Microsoft.Azure.Management.Compute.Models.GalleryDiskImageSource`.
* Updated the broken `UbuntuLTS` image alias to use its original sku version of `16.04-LTS` instead of the nonexistent image `20.04-LTS`. This fixes an issue introduced in the version 5.3.0 release. 
* Updated Set-AzVMRunCommand and Set-AzVmssRunCommand ScriptLocalPath parameter set to work with Linux and with files that have comments.
* Added `-TargetExtendedLocation` parameter to `New-AzGalleryImageVersion` and `Update-AzGalleryImageVersion`
* Added `-AllowDeletionOfReplicatedLocation` to `Update-AzGalleryImageVersion`

## Version 5.3.0
* Removed the image `Win2008R2SP1` from the list of available images and documentation. This image is no longer available on the backend so the client tools need to sync to that change.
* Fixed a bug for creating Linux VM's from SIG/Community Gallery Images
* Added `ImageReferenceId` string parameter to the `New-AzVmssConfig` cmdlet. This allows gallery image references to be added for the Confidential VM feature.
* Added `SecurityEncryptionType` and `SecureVMDiskEncryptionSet` string parameters to the `Set-AzVmssStorageProfile` cmdlet for the Confidential VM feature.

## Version 5.2.0
* Fixed issue found for `Set-AzVmssVMRunCommand` [#19985]
* Fixed `Get-AzVm` cmdlet when parameter "-Status" is provided, return property `OsName`, `OsVersion` and `HyperVGeneration`
* Fixed `New-AzVM` cmdlet when creating VM with bootdiagnostic storage causes exception `Kind` cannot be null. 

## Version 5.1.1
* Upgraded AutoMapper to Microsoft.Azure.PowerShell.AutoMapper 6.2.2 with fix [#18721]

## Version 5.1.0
* Fixed EdgeZone does not pass to VM for `New-AzVM` "SimpleParameterSet" [#18978] 
* Added 'ScriptFilePath' parameter set for `Set-AzVMRunCommand` and `Set-AzVmssVMRunCommand` to allow users to pass in the path of the file that has the run command script
* Added `-AsJob` optional parameter to `Remove-AzVMExtension` cmdlet.
* Added `-EdgeZone` optional parameter for `Get-AzComputeResourceSku` and `New-AzSnapshotUpdateConfig` cmdlets.
* Added Disk Delete Optional parameters `OsDisk Deletion Option` and `Delete Option` to the `Set-AzVmssStorageProfile` (OS Disk) and `Add-AzVmssDataDisk` (Data Disk)
* Improved printed output for `Get-AzComputeResourceSku`
* Updated `Get-AzHost` cmdlet logic to return Host for `-ResourceId` parameterset.
* Added `-OSDiskSizeGB` optional parameter for `Set-AzVmssStorageProfile`.
* Improved cmdlet description for `Set-AzVM` and added examples.
* Updated property mapping for parameter `Encryption` of `New-AzGalleryImageVersion`
* Updated list format to display all VmssVmRunCommand properties for `Get-AzVmssVmRunCommand`
* Updated `Get-AzGallery`, `New-AzGallery`, `Update-AzGallery`, `Get-AzGalleryImageDefinition`, `Get-AzGalleryImageVersion`, `New-AzVm` and `New-AzVmss` to support community galleries

## Version 5.0.0
* Added the `TimeCreated` property to the Virtual Machine and Virtual Machine Scale Set models.
* Added Confidential VM functionality to multiple cmdlets.
  * Added new parameter `SecureVMDiskEncryptionSet` to cmdlet `Set-AzDiskSecurityProfile`.
  * Added new parameters `SecureVMDiskEncryptionSet` and `SecurityEncryptionType` to cmdlet `Set-AzVMOSDisk`.
* Improved cmdlet descriptions and parameter descriptions for VM/VMSS creation.
* Added the 'BaseRegularPriorityCount' integer property to the following cmdlets: `New-AzVmssConfig` and `Update-AzVmssConfig`
* Added the 'RegularPriorityPercentage' integer property to the following cmdlets: `New-AzVmssConfig` and `Update-AzVmssConfig`
* Added Breaking Changes for Add-AzVMAdditionalUnattendContent and Get-AzGallery cmdlets
* Added `-DiskControllerType` property to the following cmdlets: `New-AzVm`, `New-AzVmss`, `New-AzVmConfig`, `Set-AzVmssStorageProfile`

## Version 4.31.0
* Added Trusted Launch Generic Breaking Change warning for `New-AzVM`, `New-AzDisk` and `New-AzVMSS` cmdlets.
* `Get-AzVMRunCommand` now shows all the properties of VMRunCommand in a list format.
* Added new Parameter `-PublicIpSku` to the `NewAzVM` cmdlet with acceptable values : "Basic" and "Standard". 
* Added Generic Breaking Change PublicIpSku Warning and Overridden `-Zone` logic when `-PublicIpSku` is explicitly provided.
* Added Disk Delete Optional parameters `OsDisk Deletion Option` and `Delete Option` to the `Set-AzVmssStorageProfile` (OS Disk) and `Add-AzVmssDataDisk` (Data Disk)
* Improved printed output for `Get-AzComputeResourceSku`
* Updated `Update-AzVm` to give constructive error messages when empty variables are passed in parameters. [#15081]
* Added `Zone` and `IntentVMSizeList` optional parameters to the cmdlet `New-AzProximityPlacementGroup`.
* Added parameters to Gallery cmdlets for Community Galleries
* For `New-AzGalleryImageVersion`, `CVMEncryptionType` and `CVMDiskEncryptionSetID` added as keys for parameter `-Target`.

## Version 4.30.0
* Added parameters `PackageFileName`, `ConfigFileName` for `New-AzGalleryApplicationVersion`

## Version 4.29.0
* Added image alias 'Win2022AzureEditionCore'
* Added the `-DisableIntegrityMonitoring` switch parameter to the `New-AzVM` cmdlet. 
  Changed the default behavior for `New-AzVM` and `New-AzVmss` when these conditions are met:
  1) `-DisableIntegrityMonitoring` is not true.
  2) `SecurityType` on the SecurityProfile is `TrustedLaunch`.
  3) `VTpmEnabled` on the SecurityProfile is true.
  4) `SecureBootEnabled` on the SecurityProfile is true. 
  Now `New-AzVM` will install the `Guest Attestation` extension to the new VM when these conditions are met.
  Now `New-AzVmss` will install the `Guest Attestation` extension to the new Vmss when these conditions are met and installed to all VM instances in the Vmss.
* Added `-UserAssignedIdentity` and `-FederatedClientId` to the following cmdlets:
    - `New-AzDiskEncryptionSetConfig`
    - `Update-AzDiskEncryptionSet`
* Added `-TreatFailureAsDeploymentFailure` to cmdlets `Add-AzVmGalleryApplication` and `Add-AzVmssGalleryApplication`
* Removed Exceptions for when SinglePlacementGroup is set to true in 'OrchestrationMode'

## Version 4.28.0
* For `Add-AzVhd` upon upload failure using DirectUploadToManagedDisk parameter set, the SAS will be revoked and the created managed disk will be deleted.
* An unresolved path can be passed in for '-LocalFilePath' for `Add-AzVhd`. The cmdlet with unresolve the path itself.
* Added `-DataAccessAuthMode` parameter to Add-AzVhd DirectUploadToManagedDisk parameter set. 
* Added `-EnabldUltraSSD` parameter to New-AzHostGroup.

## Version 4.27.0
* Edited `New-AzVm` cmdlet internal logic to use the `PlatformFaultDomain` value in the `PSVirtualMachine` object passed to it in the new virtual machine.
* Added a new cmdlet named `Restart-AzHost` to restart dedicated hosts. 
* Added `-DataAccessAuthMode` parameter to the following cmdlets:
    - `New-AzDiskConfig`
    - `New-AzDiskUpdateConfig`
    - `New-AzSnapshotConfig`
    - `New-AzSnapshotUpdateConfig`
* Added `-Architecture` parameter to the following cmdlets:
    - `New-AzDiskConfig`
    - `New-AzDiskUpdateConfig`
    - `New-AzSnapshotConfig`
    - `New-AzSnapshotUpdateConfig`
    - `New-AzGalleryImageDefinition`
* Added `-InstanceView` parameter to `Get-AzRestorePoint`
* Added parameter `-ScriptString` to `Invoke-AzvmRunCommand` and `Invoke-AzvmssRunCommand`
* Added parameter `-ScaleInPolicyForceDeletion` to `Update-Azvmss`

## Version 4.26.0
* Added `-ImageReferenceId` parameter to following cmdlets: `New-AzVm`, `New-AzVmConfig`, `New-AzVmss`, `Set-AzVmssStorageProfile`
* Added functionality for cross-tenant image reference for VM, VMSS, Managed Disk, and Gallery Image Version creation. 
* `New-AzGallery` can take in `-Permission` parameter to set its sharingProfile property.
* `Update-AzGallery` can update sharingProfile.
* `Get-AzGallery` can take in `-Expand` parameter for expanded resource view.
* New parameter set for the following cmdlets to support Shared Image Gallery Direct Sharing
    - Get-AzGallery
    - Get-AzGalleryImageDefinition
    - Get-AzGalleryImageVersion
* Updates and improvements to `Add-AzVhd`
    - Added `-DiskHyperVGeneration` and `-DiskOsType` parameters to the DirectUploadToManagedDisk parameter set for upload to more robust managed disk settings.
    - Updated progress output functions so that it works with VHD files with "&" character in its name.
    - Updated so that uploading dynamically sized VHD files are converted to fixed size during upload.
    - Fixed a bug in uploading a differencing disk.
    - Automatically delete converted/resized VHD files after upload.
    - Fixed a bug that indicates `-ResourceGroupName` parameter as optional when it is actually mandatory.

## Version 4.25.0
* Updated `New-AzVM` to create a new storage account for boot diagnostics if one does not exist. This will prevent the cmdlet from using a random storage account in the current subscription to use for boot diagnostics.
* Added `AutomaticRepairAction` string parameter to the `New-AzVmssConfig` and `Update-AzVmss` cmdlets.
* Updated `Get-AzVm` to include `GetVirtualMachineById` parameter set.
* Edited the documentation for the cmdlet `Set-AzVMADDomainExtension` to ensure the example is accurate. 
* Improved description and examples for disk creation.
* Added new parameters to `New-AzRestorePoint` and `New-AzRestorePointCollection` for copying Restore Points and Restore Point Collections.
* Added `Zone` and `PlacementGroupId` Parameters to `Repair-AzVmssServiceFabricUpdateDomain`.
* Edited `New-AzVmss` logic to better check for null properties when the parameter `OrchestrationMode` is used.

## Version 4.24.1
* Updated New-AzVM feature for `vCPUsAvailable` and `vCPUsPerCore` parameters. Cmdlets will not try to use the new `VMCustomizationPreview` feature if the user does not have access to that feature. [#17370]

## Version 4.24.0
* Upgraded Compute .NET SDK package reference to version 52.0.0
* Updated `New-AzSshKey` cmdlet to write file paths to generated keys to the Warning stream instead of the console.
* Added `vCPUsAvailable` and `vCPUsPerCore` integer parameters to the `New-AzVm`, `New-AzVmConfig`, and `Update-AzVm` cmdlets.

## Version 4.23.0
* Remove ProvisioningDetails property from PSRestorePoint object.
* Updated `Set-AzVmExtension` cmdlet to properly display `-Name` and `-Location` parameters as mandatory.
* Edited `New-AzVmssConfig` second example so it runs successfully by changing the Tag input to the correct format. 
* Added `Hibernate` parameter to `Stop-AzVm` cmdlet. 
* Added `HibernationEnabled` parameter to `New-AzVm`, `New-AzVmConfig`, and `Update-AzVm` cmdlets.
* Added `EnableHotpatching` parameter to the `Set-AzVmssOSProfile` cmdlet.
* Added 'ForceDeletion' parameter to Remove-AzVM and Remove-AzVMSS.

## Version 4.22.0
* Updated `UserData` parameter in VM and VMSS cmdlets to pipe by the Property Name to ensure piping scenarios occur correctly.
* Changed `New-AzVM` cmdlet when using the SimpleParameterSet to not create a `PublicIPAddress` when a `PublicIPAddress` name is not provided.
* Added `PlatformFaultDomain` parameter to cmdlets: `New-AzVM` and `New-AzVMConfig`
* Added `-Feature` parameter for `New-AzGalleryImageDefinition`
* Added `DiffDiskPlacement` string parameter to `Set-AzVmOSDisk` and `Set-AzVmssStorageProfile` cmdlets.

## Version 4.21.0
* Contains updates to the following powershell cmdlets
    - `SetAzVmssDiskEncryptionExtension` : Added extension parameters for the cmdlet to work with test extensions and parameter `EncryptFormatAll` for Virtual Machine Scale Sets
    - `GetAzVmssVMDiskEncryptionStatus`	 : Modified the functionality of the cmdlet to properly display the encryption status of data disks of Virtual Machine Scale Sets
    - `SetAzDiskEncryptionExtension`     : Fixed a bug in the cmdlet in the migrate scenario from 2pass to 1pass encryption
* Added `Add-AzVhd` to convert VHD using Hyper-V
* Added `UserData` parameter to VM and VMSS cmdlets
* Added string parameter `PublicNetworkAccess` to DiskConfig and SnapshotConfig cmdlets
* Added boolean parameter `AcceleratedNetwork` to DiskConfig and SnapshotConfig cmdlets
* Added `CompletionPercent` property to the PSSnapshot model so it is visible to the user.

## Version 4.20.0
* Added cmdlets to support gallery applications and versions:
    - Get-AzGalleryApplication
    - Get-AzGalleryApplicationVersion
    - New-AzGalleryApplication
    - New-AzGalleryApplicationVersion
    - Remove-AzGalleryApplication
    - Remove-AzGalleryApplicationVersion
    - Update-AzGalleryApplication
    - Update-AzGalleryApplicationVersion

## Version 4.19.0
* Update-AzVM will update ApplicationProfile.
* Added new cmdlets:
    - Add-AzVmssRunCommand
    - Remove-AzVmssRunCommand

## Version 4.18.0
* Added cmdlets for adding VMGalleryApplication property to VM/VMSS
    - New-AzVmGalleryApplication
    - New-AzVmssGalleryApplication
    - Add-AzVmGalleryApplication
    - Add-AzVmssGalleryApplication
    - Remove-AzVmGalleryApplication
    - Remove-AzVmssGalleryApplication
* Added support for proxy and debug settings for VM Extension for SAP (AEM)
* Updated New-AzGalleryImageVersion to take in the 'Encryption' property correctly from '-TargetRegion' parameter. 
* Updated Set-AzVmBootDiagnostic to default to managed storage account if not provided.
* Edited New-AzVmss defaulting behavior when `OrchestrationMode` is set to Flexible.
    - Removed NAT Pool.
    - Removed UpgradePolicy. Throws an error if provided.
    - SinglePlacementGroup must be false. Throws an error if true. 
    - Networking Profile's API version is 2020-11-01 or later.
    - Networking Profile IP Configurations Primary property is set to true.

## Version 4.17.1
* Updated Compute .NET SDK package reference to version 49.1.0
* Fixed a bug in `Get-AzVM` that caused incorrect power status output.

## Version 4.17.0
* Added new parameters `-LinuxConfigurationPatchMode`, `-WindowsConfigurationPatchMode`, and `-LinuxConfigurationProvisionVMAgent` to `Set-AzVmssOSProfile`
* Added new parameters `-SshKeyName` and `-GenerateSshKey` to `New-AzVM` to create a VM with SSH
* Fixed a bug in `Add-AzVHD` on Linux that caused uploads to fail for certain destination URI
* Added new cmdlets for Restore Points and Restore Point Collection:
    - 'New-AzRestorePoint'
    - 'New-AzRestorePointCollection'
    - 'Get-AzRestorePoint'
    - 'Get-AzRestorePointCollection'
    - 'Update-AzRestorePointCollection'
    - 'Remove-AzRestorePoint'
    - 'Remove-AzRestorePointCollection'
* Added new parameters '-EnableSpotRestore' and '-SpotRestoreTimeout' to 'New-AzVMSSConfig' to enable Spot Restore Policy 
* Added new cmdlets: `Update-AzCapacityReservationGroup` and `Update-AzCapacityReservation`

## Version 4.16.0
* Fixed the warning in `New-AzVM` cmdlet stating the sku of the VM is being defaulted even if a sku size is provided by the user. Now it only occurs when the user does not provide a sku size.
* Edited `Set-AzVmOperatingSystem` cmdlet to no longer overwrite any existing EnableAutomaticUpdates value on the passed in virtual machine if it exists.
* Updated Compute module to use the latest .Net SDK version 48.0.0.
* Added new cmdlets for the Capacity Reservation Feature:
    - `New-AzCapacityReservationGroup`
    - `Remove-AzCapacityReservationGroup`
    - `Get-AzCapacityReservationGroup`
    - `New-AzCapacityReservation`
    - `Remove-AzCapacityReservation`
    - `Get-AzCapacityReservation`
* Added a new parameter `-CapacityReservationGroupId` to the following cmdlets:
    - `New-AzVm`
    - `New-AzVmConfig`
    - `New-AzVmss`
    - `New-AzVmssConfig`
    - `Update-AzVm`
    - `Update-AzVmss`

## Version 4.15.0
* Added optional parameter `-OrchestrationMode` to `New-AzVmss` and `New-AzVmssConfig`
* Updated the following cmdlets to work when the resource uses a remote image source using AKS or Shared Image Gallery.
    - `Update-AzVm`
    - `Update-AzVmss`
    - `Update-AzGalleryImageVersion`
* Added parameters `-EnableCrossZoneUpgrade` and `-PrioritizeUnhealthyInstance` to the `Set-AzVmssRollingUpgradePolicy`  
* Added `AssessmentMode` parameter to the `Set-AzVMOperatingSystem` cmdlet.
* Fixed a bug in `Add-AzVmssNetworkInterfaceConfiguration`
* Fixed IOPS and throughput check in `Test-AzVMAEMExtension`
* Added new cmdlets for 2020-12-01 DiskRP API version
    - New-AzDiskPurchasePlanConfig
    - Set-AzDiskSecurityProfile
* Changed Cmdlets for 2020-12-01 DiskRP API version
    - New-AzDiskConfig
    - New-AzSnapshotConfig
    - New-AzSnapshotUpdateConfig
    - New-AzDiskUpdateConfig
    - New-AzDiskEncryptionSetConfig
    - Update-AzDiskEncryptionSet

## Version 4.14.0
* Updated Compute module to use the latest .Net SDK version 47.0.0.

## Version 4.13.0
* Added `Invoke-AzVmInstallPatch` to support patch installation in VMs using PowerShell.
* Updated Compute module to use the latest .Net SDK version 46.0.0.
* Added optional parameter `-EdgeZone` to the following cmdlets:
    - `Get-AzVMImage
    - `Get-AzVMImageOffer`
    - `Get-AzVMImageSku`
    - `New-AzDiskConfig`
    - `New-AzImageConfig`
    - `New-AzSnapshotConfig`
    - `New-AzVM`
    - `New-AzVmssConfig`
    - `New-AzVMSS`
* Added cmdlets to create, update, delete, and get new Azure resource: Ssh Public Key
    - `New-AzSshKey`
    - `Remove-AzSshKey`
    - `Get-AzSshKey`
    - `Update-AzSshKey`

## Version 4.12.0
* Updated the `Set-AzVMDiskEncryptionExtension` cmdlet to support ADE extension migration from two pass (version with AAD input parameters) to single pass (version without AAD input parameters).
    - Added a switch parameter `-Migrate` to trigger migration workflow.
    - Added a switch parameter `-MigrationRecovery` to trigger recovery workflow for VMs experiencing failures after migration from two pass ADE.
* Added `Win2019Datacenter` in the argument completer list for `Image` parameter in the `New-AzVM` cmdlet.

## Version 4.11.0
* Fixed a bug when 1 data disk attached to VMSS for Remove-AzVmssDataDisk [#13368]
* Added new cmdlets to support TrustedLaunch related cmdlets:
    - `Set-AzVmSecurityProfile`
    - `Set-AzVmUefi`
    - `Set-AzVmssSecurityProfile`
    - `Set-AzVmssUefi`
* Edited default value for Size parameter in New-AzVM cmdlet from Standard_DS1_v2 to Standard_D2s_v3.

## Version 4.10.0
* Added parameter `-EnableHotpatching` to the `Set-AzVMOperatingSystem` cmdlet for Windows machines. 
* Added parameter `-PatchMode` to the Linux parameter sets in the cmdlet `Set-AzVMOperatingSystem`. 
* [Breaking Change] Breaking changes for users in the public preview for the VM Guest Patching feature.
    - Removed property `RebootStatus` from the `Microsoft.Azure.Management.Compute.Models.LastPatchInstallationSummary` object. 
    - Removed property `StartedBy` from the `Microsoft.Azure.Management.Compute.Models.LastPatchInstallationSummary` object.
    - Renamed property `Kbid` to `KbId` in the `Microsoft.Azure.Management.Compute.Models.VirtualMachineSoftwarePatchProperties` object. 
    - Renamed property `patches` to `availablePatches` in the `Microsoft.Azure.Management.Compute.Models.VirtualMachineAssessPatchesResult` object. 
    - Renamed object `Microsoft.Azure.Management.Compute.Models.SoftwareUpdateRebootBehavior` to `Microsoft.Azure.Management.Compute.Models.VMGuestPatchRebootBehavior`.
    - Renamed object `Microsoft.Azure.Management.Compute.Models.InGuestPatchMode` to `Microsoft.Azure.Management.Compute.Models.WindowsVMGuestPatchMode`.
* [Breaking Change] Removed all `ContainerService` cmdlets. The Container Service API was deprecated in January 2020. 
    - `Add-AzContainerServiceAgentPoolProfile`
    - `Get-AzContainerService`
    - `New-AzContainerService`
    - `New-AzContainerServiceConfig`
    - `Remove-AzContainerService`
    - `Remove-AzContainerServiceAgentPoolProfile`
    - `Update-AzContainerService`

## Version 4.9.0
* Added parameter `-EnableAutomaticUpgrade` to `Set-AzVmExtension` and `Add-AzVmssExtension`.
* Removed FilterExpression parameter from `Get-AzVMImage` cmdlet documentation. 
* Added deprecation message to the ContainerService cmdlets:
    - `Add-AzureRmContainerServiceAgentPoolProfileCommand`
    - `Get-AzContainerService`
    - `New-AzContainerService`
    - `New-AzContainerServiceConfig`
    - `Remove-AzContainerService`
    - `Remove-AzContainerServiceAgentPoolProfile`
    - `Update-AzContainerService`
* Added parameter `-BurstingEnabled` to `New-AzDiskConfig` and `New-AzDiskUpdateConfig`
* Added `-GroupByApplicationId` and `-GroupByUserAgent` parameters to the `Export-AzLogAnalyticThrottledRequest` and `Export-AzLogAnalyticRequestRateByInterval` cmdlets.
* Added `VMParameterSet` parameter set to `Get-AzVMExtension` cmdlet. Added new parameter `-VM` to this parameter set. 

## Version 4.8.0
* New parameter `VM` in new parameter set `VMParameterSet` added to `Get-AzVMDscExtensionStatus` and `Get-AzVMDscExtension` cmdlets. 
* Edited `New-AzSnapshot` cmdlet to check for existing snapshot with the same name in the same resource group. 
    - Throws an error if a duplicate snapshot exists. 

## Version 4.7.0
* Edited Get-AzVm to filter by `-Name` prior to checking for throttling due to too many resources. 
* New cmdlet `Start-AzVmssRollingExtensionUpgrade`.
## Version 4.6.0
* Added `-VmssId` parameter to `New-AzVm`
* Added `PlatformFaultDomainCount` parameter to the `New-AzVmss` cmdlet.
* New cmdlet `Get-AzDiskEncryptionSetAssociatedResource`
* Added `Tier` and `LogicalSectorSize` optional parameters to the New-AzDiskConfig cmdlet. 
* Added `Tier`, `MaxSharesCount`, `DiskIOPSReadOnly`, and `DiskMBpsReadOnly` optional parameters to the `New-AzDiskUpdateConfig` cmdlet. 
* Modified `Get-AzVmBootDiagnostics` cmdlet to use the new RetrieveBootDiagnosticsData API instead of directly accessing the BootDiagnostics properties on the virtual machine.  

## Version 4.5.0
* Fixed issue in `Update-ASRRecoveryPlan` by populating FailoverTypes
* Added the `-Top` and `-OrderBy` optional parameters to the `Get-AzVmImage` cmdlet. 

## Version 4.4.0
* Added the `-EncryptionType` optional parameter to `New-AzVmDiskEncryptionSetConfig`
* New cmdlets for new resource type: DiskAccess `Get-AzDiskAccess`, `New-AzDiskAccess`, `Get-AzDiskAccess`
* Added optional parameters `-DiskAccessId` and `-NetworkAccessPolicy` to `New-AzSnapshotConfig`
* Added optional parameters `-DiskAccessId` and `-NetworkAccessPolicy` to `New-AzDiskConfig`
* Added `PatchStatus` property to VirtualMachine Instance View
* Added `VMHealth` property to the virtual machine's instance view, which is the returned object when `Get-AzVm` is invoked with `-Status`
* Added `AssignedHost` field to `Get-AzVM` and `Get-AzVmss` instance views. The field shows the resource id of the virtual machine instance
* Added optional parameter `-SupportAutomaticPlacement` to `New-AzHostGroup` 
* Added the `-HostGroupId` parameter to `New-AzVm` and `New-AzVmss`

## Version 4.3.1
* Patched `-EncryptionAtHost` parameter in `New-AzVm` to remove default value of false [#12776]

## Version 4.3.0
* Added `-EncryptionAtHost` parameter to `New-AzVm`, `New-AzVmss`, `New-AzVMConfig`, `New-AzVmssConfig`, `Update-AzVM`, and `Update-AzVmss`
* Added `SecurityProfile` to `Get-AzVM` and `Get-AzVmss` return object
* Added `-InstanceView` switch as optional parameter to `Get-AzHostGroup`
* Added new cmdlet `Invoke-AzVmPatchAssessment`

## Version 4.2.1
* Added warning when using `New-AzVmss` without "latest" image version
* Added '-Location' as optional positional parameter to Get-AzComputeResourceSku cmdlet

## Version 4.2.0
* Added SimulateEviction parameter to Set-AzVM and Set-AzVmssVM cmdlets.
* Added 'Premium_LRS' to the argument completer of StorageAccountType parameter for New-AzGalleryImageVersion cmdlet.
* Added Substatuses to VMCustomScriptExtension [#11297]
* Added 'Delete' to the argument completer of EvictionPolicy parameter for New-AzVM and New-AzVMConfig cmdlets.
* Fixed name of new VM Extension for SAP

## Version 4.1.0
* Added HostId parameter to `Update-AzVM` cmdlet
* Updated Help documents for `New-AzVMConfig`, `New-AzVmssConfig`, `Update-AzVmss`, `Set-AzVMOperatingSystem` and `Set-AzVmssOsProfile` cmdlets.
* Breaking changes
    - FilterExpression parameter is removed from `Get-AzVMImage` cmdlet.
    - AssignIdentity parameter is removed from `New-AzVmssConfig`, `New-AzVMConfig` and `Update-AzVM` cmdlets.
    - AutomaticRepairMaxInstanceRepairsPercent is removed from `New-AzVmssConfig` and `Update-AzVmss` cmdlets.
    - AvailabilitySetsColocationStatus, VirtualMachinesColocationStatus and VirtualMachineScaleSetsColocationStatus properties are removed from ProximityPlacementGroup.
    - MaxInstanceRepairsPercent property is removed from AutomaticRepairsPolicy.
    - The types of AvailabilitySets, VirtualMachines and VirtualMachineScaleSets are changed from IList<SubResource> to IList<SubResourceWithColocationStatus>.
* Description for `Get-AzVM` cmdlet has been updated to better describe it. 

## Version 3.7.0
* Added `Set-AzVmssOrchestrationServiceState` cmdlet.
* `Get-AzVmss` with -InstanceView shows OrchestrationService states.

## Version 3.6.0
* Added the following parameters to `New-AzDiskConfig` cmdlet: 
    - DiskIOPSReadOnly, DiskMBpsReadOnly, MaxSharesCount, GalleryImageReference
* Allowed Encryption property to Target parameter of `New-AzGalleryImageVersion` cmdlet.
* Fixed tempDisk issue for `Set-AzVmss` -Reimage and `Invoke-AzVMReimage` cmdlets. [#11354]
* Added support to below cmdlets for new SAP Extension
    - `Set-AzVMAEMExtension`
    - `Get-AzVMAEMExtension`
    - `Remove-AzVMAEMExtension`
    - `Update-AzVMAEMExtension`
* Fixed errors in examples of help document
* Showed the exact string value for VM PowerState in the table format.
* `New-AzVmssConfig`: fixed serialization of AutomaticRepairs property when SinglePlacementGroup is disabled. [#11257]

## Version 3.5.0
* Allowed empty value for ProximityPlacementGroupId during update

## Version 3.4.0
* Limit the number of VM status to 100 to avoid throttling when Get-AzVM -Status is performed without VM name.
* Add Update-AzDiskEncryptionSet cmdlet
* Add EncryptionType and DiskEncryptionSetId parameters to the following cmdlets:
    - New-AzDiskUpdateConfig, New-AzSnapshotUpdateConfig
* Add ColocationStatus parameter to Get-AzProximityPlacementGroup cmdlet.
* Fix broken example code for 'Revoke-AzSnapshotAccess' and 'Grant-AzSnapshotAccess'
* Fix broken example code for 'Set-AzDiskDiskEncryptionKey' and 'Set-AzDiskKeyEncryptionKey'

## Version 3.3.0
* Fix Set-AzVMCustomScriptExtension cmdlet for a VM with managed OD disk which does not have OS profile.
* Updated the example of `Set-AzVMAccessExtension` to use version 2.4 instead of 2.0

## Version 3.2.0
* Add ProximityPlacementGroupId parameter to the following cmdlets:
    - Update-AzAvailabilitySet, Update-AzVM, Update-AzVmss
* Change ProximityPlacementGroup parameter to ProximityPlacementGroupId parameter in New-AzVM and New-AzVmss.
  (ProximityPlacementGroup parameter is still supported as an alias)
* Update help message for VM and VMSS priority.
* Update references in .psd1 to use relative path

## Version 3.1.0
* VM Reapply feature
    - Add Reapply parameter to Set-AzVM cmdlet
* VM Scale Set AutomaticRepairs feature:
    - Add EnableAutomaticRepair, AutomaticRepairGracePeriod, and AutomaticRepairMaxInstanceRepairsPercent parameters to the following cmdlets:
        New-AzVmssConfig
        Update-AzVmss
* Cross tenant gallery image support for New-AzVM
* Add 'Spot' to the argument completer of Priority parameter in New-AzVM, New-AzVMConfig and New-AzVmss cmdlets
* Add DiskIOPSReadWrite and DiskMBpsReadWrite parameters to Add-AzVmssDataDisk cmdlet
* Change SourceImageId parameter of New-AzGalleryImageVersion cmdlet to optional
* Add OSDiskImage and DataDiskImage parameters to New-AzGalleryImageVersion cmdlet
* Add HyperVGeneration parameter to New-AzGalleryImageDefinition cmdlet
* Add SkipExtensionsOnOverprovisionedVMs parameters to New-AzVmss, New-AzVmssConfig and Update-AzVmss cmdlets

## Version 3.0.0
* Disk Encryption Set feature
    - New cmdlets:
        New-AzDiskEncryptionSetConfig
        New-AzDiskEncryptionSet
        Get-AzDiskEncryptionSet
        Remove-AzDiskEncryptionSet
    - DiskEncryptionSetId parameter is added to the following cmdlets:
        Set-AzImageOSDisk
        Set-AzVMOSDisk
        Set-AzVmssStorageProfile        
        Add-AzImageDataDisk
        New-AzVMDataDisk
        Set-AzVMDataDisk
        Add-AzVMDataDisk
        Add-AzVmssDataDisk
        Add-AzVmssVMDataDisk
    - DiskEncryptionSetId and EncryptionType parameters are added to the following cmdlets:
        New-AzDiskConfig
        New-AzSnapshotConfig
* Add PublicIPAddressVersion parameter to New-AzVmssIPConfig
* Move FileUris of custom script extension from public setting to protected setting
* Add ScaleInPolicy to New-AzVmss, New-AzVmssConfig and Update-AzVmss cmdlets
* Breaking changes
    - UploadSizeInBytes parameter is used instead of DiskSizeGB for New-AzDiskConfig when CreateOption is Upload
    - PublishingProfile.Source.ManagedImage.Id is replaced with StorageProfile.Source.Id in GalleryImageVersion object

## Version 2.7.0
* Add Priority, EvictionPolicy, and MaxPrice parameters to New-AzVM and New-AzVmss cmdlets
* Fix warning message and help document for Add-AzVMAdditionalUnattendContent and Add-AzVMSshPublicKey cmdlets
* Fix -skipVmBackup exception for Linux VMs with managed disks for Set-AzVMDiskEncryptionExtension. 
* Fix bug in update encryption settings in Set-AzVMDiskEncryptionExtension, two pass scenario.

## Version 2.6.0
* Add UploadSizeInBytes parameter tp New-AzDiskConfig
* Add Incremental parameter to New-AzSnapshotConfig
* Add a low priority virtual machine feature:
    - MaxPrice, EvictionPolicy and Priority parameters are added to New-AzVMConfig.
    - MaxPrice parameter is added to New-AzVmssConfig, Update-AzVM and Update-AzVmss cmdlets.
* Fix VM reference issue for Get-AzAvailabilitySet cmdlet when it lists all availability sets in the subscription.
* Fix the null exception for Get-AzRemoteDesktopFile.
* Fix VHD Seek method for end-relative position.
* Fix UltraSSD issue for New-AzVM and Update-AzVM.
* Fix code to allow non default extension publisher, type and name for Get-AzVMDiskEncryptionStatus

## Version 2.5.0
* Add VmssId to New-AzVMConfig cmdlet
* Add TerminateScheduledEvents and TerminateScheduledEventNotBeforeTimeoutInMinutes parameters to New-AzVmssConfig and Update-AzVmss
* Add HyperVGeneration property to VM image object
* Add Host and HostGroup features
    - New cmdlets:
        New-AzHostGroup
        New-AzHost
        Get-AzHostGroup
        Get-AzHost
        Remove-AzHostGroup
        Remove-AzHost
    - HostId parameter is added to New-AzVMConfig and New-AzVM
* Fixed miscellaneous typos across module
* Update example in `Invoke-AzVMRunCommand` documentation to use correct parameter name
* Update `-VolumeType` description in `Set-AzVMDiskEncryptionExtension` and `Set-AzVmssDiskEncryptionExtension` reference documentation

## Version 2.4.1
* Add missing properties (ComputerName, OsName, OsVersion and HyperVGeneration) of VM instance view object.

## Version 2.4.0
* Add HyperVGeneration parameter to New-AzImageConfig
* Use the extension type instead of the name when disabling vmss disk encryption

## Version 2.3.0
* New-AzVm and New-AzVmss simple parameter sets now accept the `ProximityPlacementGroup` parameter.
* Fix typo in `New-AzVM` reference documentation

## Version 2.2.0
* Added `NoWait` parameter that starts the operation and returns immediately, before the operation is completed.
    - Updated cmdlets:
        Export-AzLogAnalyticRequestRateByInterval
        Export-AzLogAnalyticThrottledRequest
        Remove-AzVM
        Remove-AzVMAccessExtension
        Remove-AzVMAEMExtension
        Remove-AzVMChefExtension
        Remove-AzVMCustomScriptExtension
        Remove-AzVMDiagnosticsExtension
        Remove-AzVMDiskEncryptionExtension
        Remove-AzVMDscExtension
        Remove-AzVMSqlServerExtension
        Restart-AzVM
        Set-AzVM
        Set-AzVMAccessExtension
        Set-AzVMADDomainExtension
        Set-AzVMAEMExtension
        Set-AzVMBginfoExtension
        Set-AzVMChefExtension
        Set-AzVMCustomScriptExtension
        Set-AzVMDiagnosticsExtension
        Set-AzVMDscExtension
        Set-AzVMExtension
        Start-AzVM
        Stop-AzVM
        Update-AzVM

## Version 2.1.0
* Add ProtectFromScaleIn and ProtectFromScaleSetAction parameters to Update-AzVmssVM cmdlet.
* New-AzVM simple parameter set now uses by default an available location if 'East US' is not supported

## Version 2.0.0
* Proximity placement group feature.
    - The following new cmdlets are added:
        New-AzProximityPlacementGroup
        Get-AzProximityPlacementGroup
        Remove-AzProximityPlacementGroup
    - The new parameter, ProximityPlacementGroupId, is added to the following cmdlets:
        New-AzAvailabilitySet
        New-AzVMConfig
        New-AzVmssConfig
* StorageAccountType parameter is added to New-AzGalleryImageVersion.
* TargetRegion of New-AzGalleryImageVersion can contain StorageAccountType.
* SkipShutdown switch parameter is added to Stop-AzVM and Stop-AzVmss
* Breaking changes
    - Set-AzVMBootDiagnostics is changed to Set-AzVMBootDiagnostic.
    - Export-AzLogAnalyticThrottledRequests is changed to Export-AzLogAnalyticThrottledRequests.

## Version 1.8.0
* Fix issue with AEM installation if resource ids of disks had lowercase resourcegroups in resource id
* Updated cmdlets with plural nouns to singular, and deprecated plural names.
* Fix documentation for wildcards

## Version 1.7.0
* Add HyperVGeneration parameter to New-AzDiskConfig and New-AzSnapshotConfig
* Allow VM creation with galley image from other tenants. 

## Version 1.6.0
* Fix issue with path resolution in Get-AzVmBootDiagnosticsData
* Update Compute client library to 25.0.0.
* Add new parameter sets to Set-AzVMCustomScriptExtension
    - Accepts PSVirtualMachine object from pipeline
    - Accepts Resource Id and a VirtualMachineCustomScriptExtensionContext also from pipeline

## Version 1.5.0
* Add wildcard support to Get cmdlets

## Version 1.4.0
* Fix issue with ID parameter sets
* Update Get-AzVMExtension to list all installed extension if Name parameter is not provided
* Add Tag and ResourceId parameters to Update-AzImage cmdlet
* Get-AzVmssVM without instance ID and with InstanceView can list VMSS VMs with instance view.

## Version 1.3.0
* AEM extension: Add support for UltraSSD and P60,P70 and P80 disks
* Update help description for Set-AzVMBootDiagnostics
* Update help description and example for Update-AzImage

## Version 1.2.0
* Add Invoke-AzVMReimage cmdlet
* Add TempDisk parameter to Set-AzVmss
* Fix the warning message of New-AzVM
* Add ProvisionAfterExtension parameter to Add-AzVmssExtension

## Version 1.1.0
* Name is now optional in ID parameter set for Restart/Start/Stop/Remove/Set-AzVM and Save-AzVMImage
* Updated the description of ID in help files
* Fix backward compatibility issue with Az.Accounts module

## Version 1.0.0
* General availability of `Az.Compute` module
* Breaking changes
    - IdentityIds are removed from Identity property in PSVirtualMachine and PSVirtualMachineScaleSet object.
    - The type of InstanceView property of PSVirtualMachineScaleSetVM object is changed from VirtualMachineInstanceView to VirtualMachineScaleSetVMInstanceView.
    - AutoOSUpgradePolicy and AutomaticOSUpgrade properties are removed from UpgradePolicy property.
    - The type of Sku property in PSSnapshotUpdate object is changed from DiskSku to SnapshotSku.
    - VmScaleSetVMParameterSet is removed from Add-AzVMDataDisk.
