
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

## Version 5.9.2
* This module is outdated and will go out of support on 29 February 2024.
* The Az.Compute module has all the capabilities of AzureRM.Compute and provides the following improvements:
    - Greater security with token cache encryption and improved authentication.
    - Availability in Azure Cloud Shell and on Linux and macOS.
    - Support for all Azure services.
    - Allows use of Azure access tokens.
* We encourage you to start using the Az module as soon as possible to take advantage of these improvements.
* [Update your scripts](https://docs.microsoft.com/powershell/azure/migrate-from-azurerm-to-az) that use AzureRM PowerShell modules to use Az PowerShell modules by 29 February 2024.
* To automatically update your scripts, follow the [quickstart guide](https://docs.microsoft.com/powershell/azure/quickstart-migrate-azurerm-to-az-automatically).

## Version 5.9.0
* Fixed identity issue for SystemAssigned identity
* Update dependencies for type mapping issue

## Version 5.8.0
* Add Add-AzureRmVmssVMDataDisk and Remove-AzureRmVmssVMDataDisk cmdlets
* Get-AzureRmVMImage shows AutomaticOSUpgradeProperties
* Fixed SetAzureRmVMChefExtension -BootstrapOptions and -JsonAttribute option values are not setting in json format.

## Version 5.7.2
* Add EnableUltraSSD switch parameter to New-AzureRmVMConfiig and New-AzureRmVmssConfig.
* Add UltraSSDEnabled parameter to Update-AuzreRmVM and Update-AzureRmVmss.
* Shared Gallery cmdlets

## Version 5.7.1
* Add DiskIOPSReadWrite and  DiskMBpsReadWrite parameters to New-AzureRmDiskConfig and New-AzureRmDiskUpdateConfig cmdlets 
* Add DiffDiskSetting parameter to Set-AzureRmVmOSDisk and Set-AzureRmVmssStorageProfile cmdlets
* Add Location parameter to Get-AzureRmVM
* Added new sizes to the whitelist of VM sizes for which accelerated networking will be turned on when using the simple param set for `New-AzureRmVm`
* Added ResourceName argument completer to all cmdlets.

## Version 5.7.0
* Fix Get-AzureRmVM -ResourceGroupName <rg> to return more than 50 results if needed
* Added an example of the `SimpleParameterSet` to New-AzureRmVmss cmdlet help.
* Fixed a typo in the Azure Disk Encryption progress message

## Version 5.6.0
* Move dependencies on Keyvault and Storage to the common dependencies
* Add support for more virutal machine sizes to AEM cmdlets
* Add PublicIPPrefix parameter to New-AzureRmVmssIpConfig
* Add ResourceId parameter to Invoke-AzureRmVMRunCommand cmdelt
* Add Invoke-AzureRmVmssVMRunCommand cmdlet
* Update the Compute client library to version 22.0.0

## Version 5.5.2
* Fixed the issue that target is missing in error output.
* Fixed issue with storage account type for VM with managed disk
* Fixed issue with default resource groups not being set.
* Fix AEM Extension cmdlets for other environments, for example Azure China
* Updated common runtime assemblies

## Version 5.5.1
* Fixed the issue that target is missing in error output.
* Fixed issue with storage account type for VM with managed disk
* Fixed issue with default resource groups not being set.
* Fix AEM Extension cmdlets for other environments, for example Azure China

## Version 5.5.0
* Updated to the latest version of the Azure ClientRuntime.
* Add EvictionPolicy parameter to New-AzureRmVmssConfig
* Use default location in the DiskFileParameterSet of New-AzureRmVm if no Location is specified.
* Fix parameter description in Save-AzureRmVMImage
* Fix Get-AzureRmVMDiskEncryptionStatus cmdlet for certain singlepass related scenarios

## Version 5.4.0
* Fix issue with creating a vm using `DiskFileParameterSet` in `New-AzureRmVm` failing because of `PremiumLRS` storage account type renaming.
* Fix Invoke-AzureRmVMRunCommand cmdlet
* Update Get-AzureRmAvailabilitySet to enable list all availability sets in a subscription.  (ResouceGroupName parameter is now optional.)
* Update SimpleParameterSet of `New-AzureRmVm` to enable Accelerated Network on qualifying vms.
* Update New-AzureRmVmss simple parameter set to fail creating the vmss when a user specified LB already exists.
* Update example for New-AzureRmDisk
* Add example for `New-AzureRmVM`
* Updated all help files to include full parameter types and correct input/output types.
* Update description for Set-AzureRmVMOSDisk
* Update Example 1 for Set-AzureRmVMBginfoExtension to correct spelling and prefix. 

## Version 5.3.0
* Add -Tag parameter to Update/New-AzureRmAvailabilitySet
* Add example for `Add-AzureRmVmssExtension`
* Add examples for `Remove-AzureRmVmssExtension`
* Update help for `Set-AzureRmVMAccessExtension`
* Update SimpleParameterSet for New-AzureRmVmss to set SinglePlacementGroup to false by default and add switch parameter `SinglePlacementGroup` that enables the user to create the VMSS in a single placement group.
* Fixed Disable-AzureRmVmDiskEncryption to work for VMs encrypted without AAD parameters

## Version 5.2.0
* IP Tag feature for VMSS
    - `New-AzureRmVmssIpTagConfig` cmdlet is added
    - IpTag parameter is added to New-AzureRmVmssIpConfig
* Auto OS Rollback feature for VMSS
    - DisableAutoRollback parameters are added to New-AzureRmVmssConfig and Update-AzureRmVmss
* OS Upgrade History feature for Vmss
    - OSUpgradeHistory switch parameter is added to Get-AzureRmVmss
* Fixed formatting of OutputType in help files

## Version 5.1.1
* ResourceId tab completer applied to the cmdelts top level resource id parameters if any.
* `Get-AzureRmVmDiskEncryptionStatus` fixes an issue observed for VMs with no data disks
* Update Compute client library version to fix following cmdlets
    - Grant-AzureRmDiskAccess
    - Grant-AzureRmSnapshotAccess
    - Save-AzureRmVMImage
* Fixed following cmdlets to show `operation ID` and `operation status` correctly:
    - Start-AzureRmVM
    - Stop-AzureRmVM
    - Restart-AzureRmVM
    - Set-AzureRmVM
    - Remove-AzuerRmVM
    - Set-AzureRmVmss
    - Start-AzureRmVmssRollingOSUpgrade
    - Stop-AzureRmVmssRollingUpgrade
    - Start-AzureRmVmss
    - Restart-AzureRmVmss
    - Stop-AzureRmVmss
    - Remove-AzureRmVmss
    - ConvertTo-AzureRmVMManagedDisk
    - Revoke-AzureRmSnapshotAccess
    - Remove-AzureRmSnapshot
    - Revoke-AzureRmDiskAccess
    - Remove-AzureRmDisk
    - Remove-AzureRmContainerService
    - Remove-AzureRmAvailabilitySet


## Version 5.1.0
* VMSS VM Update feature
    - Added `Update-AzureRmVmssVM` and `New-AzureRmVMDataDisk` cmdlets
    - Add VirtualMachineScaleSetVM parameter to `Add-AzureRmVMDataDisk` cmdlet to support adding a data disk to Vmss VM.

## Version 5.0.0
* `New-AzureRmVm` and `New-AzureRmVmss` support verbose output of parameters
* `New-AzureRmVm` and `New-AzureRmVmss` (simple parameter set) support assigning user defined and(or) system defined identities to the VM(s).
* VMSS Redeploy and PerformMaintenance feature
    -  Add new switch parameter -Redeploy and -PerformMaintenance to `Set-AzureRmVmss` and `Set-AzureRmVmssVM`
* Add DisableVMAgent switch parameter to `Set-AzureRmVMOperatingSystem` cmdlet
* `New-AzureRmVm` and `New-AzureRmVmss` (simple parameter set) support a `Win10` image.
* `Repair-AzureRmVmssServiceFabricUpdateDomain` cmdlet is added.
* Set minimum dependency of module to PowerShell 5.0
* Introduce multiple breaking changes
    - Please refer to the migration guide for more details
* `Set-AzureRmVmDiskEncryptionExtension` makes AAD parameters optional

## Version 4.6.0
* `Get-AzureRmVmssDiskEncryptionStatus` supports encryption status at data disk level
* `Get-AzureRmVmssVmDiskEncryptionStatus` supports encryption status at data disk level
* Update for Zone Resilient
* `New-AzureRmVm` and `New-AzureRmVmss` (simple parameter set) support availability zones.
* Updated to the latest version of the Azure ClientRuntime

## Version 4.5.0
* `New-AzureRmVM` and `New-AzureRmVMSS` support data disks.
* `New-AzureRmVM` and `New-AzureRmVMSS` support custom image by name or by id.
* Log analytic feature
    - Added `Export-AzureRmLogAnalyticRequestRateByInterval` cmdlet
    - Added `Export-AzureRmLogAnalyticThrottledRequests` cmdlet
* Fix issue with Default Resource Group in CloudShell

## Version 4.4.0
* `New-AzureRmVMSS` prints connection strings in verbose mode.
* `New-AzureRmVmss` supports public IP address, load balancing rules, inbound NAT rules.
* WriteAccelerator feature
    - Added WriteAccelerator switch parameter to the following cmdlets:
          Set-AzureRmVMOSDisk
          Set-AzureRmVMDataDisk
          Add-AzureRmVMDataDisk
          Add-AzureRmVmssDataDisk
    - Added OsDiskWriteAccelerator switch parameter to the following cmdlet:
          Set-AzureRmVmssStorageProfile.
    - Added OsDiskWriteAccelerator Boolean parameter to the following cmdlets:
          Update-AzureRmVM
          Update-AzureRmVmss

## Version 4.3.2
* Fix ErrorAction issue for some of Get cmdlets.

## Version 4.3.1
* `New-AzureRmVm` and `New-AzureRmVmss` get information about an image from Azure.

## Version 4.3.0
* Added `FullyQualifiedDomainName` to `PSVirtualMachinScaleSet`.
* Added `AvailabilitySetName` parameter to the simplified parameterset of `New-AzureRmVm`.
* Corrected usage of `Login-AzureRmAccount` to use `Connect-AzureRmAccount`
* User assigned identity support for VM and VM scale set
- IdentityType and IdentityId parameters are added to New-AzureRmVMConfig, New-AzureRmVmssConfig, Update-AzureRmVM and Update-AzureRmVmss
* Added EnableIPForwarding parameter to Add-AzureRmVmssNetworkInterfaceConfig
* Added Priority parameter to New-AzureRmVmssConfig

## Version 4.2.0
* Added simplified parameter set to New-AzureRmVmss, which creates a Virtual Machine Scale Set and all required resources using smart defaults
* Added Location Completer to -Location parameters allowing tab completion through valid Locations
* Added ResourceGroup Completer to -ResourceGroup parameters allowing tab completion through resource groups in current subscription
* Obsoleted -Tags in favor of -Tag for New-AzureRmVm and Update-AzureRmVm
* Fixed Get-AzureRmComputeResourceSku cmdlet when Zone is included in restriction.
* Updated Diagnostics Agent configuration schema for Azure Monitor sink support.
* Fixed a non-existing resource group creation problem for New-AzureRmVM

## Version 4.1.1
* Get-AzureRmComputeResourceSku shows zone information.
* Update Disable-AzureRmVmssDiskEncryption to fix issue https://github.com/Azure/azure-powershell/issues/5038
* Added -AsJob support for long-running Compute cmdlets. Allows selected cmdlets to run in the background and return a job to track and control progress.
    - Affected cmdlets include: New-, Update-, Set-, Remove-, Start-, Restart-, Stop- cmdlets for Virtual Machines and Virtual Machine Scale Sets
* Added simplified parameter set to New-AzureRmVM, which creates a Virtual Machine and all required resources using smart defaults

## Version 4.0.1
* Fixed assembly loading issue that caused some cmdlets to fail when executing

## Version 4.0.0
* Azure Disk Encryption Extension Commands
    - New Parameter for 'Set-AzureRmVmDiskEncryptionExtension': '-EncryptFormatAll' encrypt formats data disks
    - New Parameters for 'Set-AzureRmVmDiskEncryptionExtension': '-ExtensionPublisherName' and '-ExtensionType' allow switching to other versions of the extension
    - New Parameters for 'Disable-AzureRmVmDiskEncryption': '-ExtensionPublisherName' and '-ExtensionType' allow switching to other versions of the extension
    - New Parameters for 'Get-AzureRmVmDiskEncryptionStatus': '-ExtensionPublisherName' and '-ExtensionType' allow switching to other versions of the extension
* Set-AzureRmVMAEMExtension: Add support for Dv3 and Ev3 series
* Add support for online help
    - Run Get-Help with the -Online parameter to open the online help in your default Internet browser

## Version 3.4.1

## Version 3.4.0
* Run Command feature:
    - New cmdlet: 'Invoke-AzureRmVMRunCommand' invokes a run command on a VM
    - New cmdlet: 'Get-AzureRmVMRunCommandDocument' shows available run command documents
* Add 'StorageAccountType' parameter to Set-AzureRmDataDisk
* Availability Zone support for virtual machine, VM scale set, and disk
    - New paramter: 'Zone' is added to New-AzureRmVM, New-AzureRmVMConfig, New-AzureRmVmssConfig, New-AzureRmDiskConfig
* VM scale set rolling upgrade feature:
    - New cmdlet: 'Start-AzureRmVmssRollingOSUpgrade' invokes OS rolling upgrade of VM scale set
    - New cmdlet: 'Set-AzureRmVmssRollingUpgradePolicy' sets upgrade policy for VM scale set rolling upgrade.
    - New cmdlet: 'Stop-AzureRmVmssRollingUpgrade' cancels rolling upgrade of VM scale set
    - New cmdlet: 'Get-AzureRmVmssRollingUpgrade' shows the status of VM scale set rolling upgrade.
* AssignIdentity switch parameter is introduced for system assigned identity.
    - New parameter: 'AssignIdentity' is added to New-AzureRmVMConfig, New-AzureRmVmssConfig and Update-AzureRmVM
* Vmss disk encryption feature:
    - New cmdlet: 'Set-AzureRmVmssDiskEncryptionExtension' enables disk encryption on VM scale set
    - New cmdlet: 'Disable-AzureRmVmssDiskEncryption' disables disk encryption on VM scale set
    - New cmdlet: 'Get-AzureRmVmssDiskEncryptionStatus' shows the disk encryption status of a VM scale set
    - New cmdelt: 'Get-AzureRmVmssVMDiskEncryptionStatus' shows the disk encryption status of VMs in a VM scale set

## Version 3.3.1
*
## Version 3.3.0
* Set-AzureRmVMAEMExtension: Add support for new Premium Disk sizes
* Set-AzureRmVMAEMExtension: Add support for M series
* Add ForceUpdateTag parameter to Add-AzureRmVmssExtension
* Add Primary parameter to New-AzureRmVmssIpConfig
* Add EnableAcceleratedNetworking parameter to Add-AzureRmVmssNetworkInterfaceConfig
* Add InstanceId to Set-AzureRmVmss
* Expose MaintenanceRedeployStatus to Get-AzureRmVM -Status output
* Expose Restriction and Capability to the table format of Get-AzureRmComputeResourceSku

## Version 3.2.1
- Fix issue with VM DIsk and VM Disk snapshot create and update cmdlets, (link)[https://github.com/azure/azure-powershell/issues/4309]
  - New-AzureRmDisk
  - New-AzureRmSnapshot
  - Update-AzureRmDisk
  - Update-AzureRmSnapshot

## Version 3.2.0
* Storage account type support for Image disk:
    - 'StorageAccountType' parameter is added to Set-AzureRmImageOsDisk and Add-AzureRmImageDataDisk
* PrivateIP and PublicIP feature in Vmss Ip Configuration:
    - 'PrivateIPAddressVersion', 'PublicIPAddressConfigurationName', 'PublicIPAddressConfigurationIdleTimeoutInMinutes', 'DnsSetting' names are added to New-AzureRmVmssIpConfig
    - 'PrivateIPAddressVersion' parameter for specifying IPv4 or IPv6 is added to New-AzureRmVmssIpConfig
* Performance Maintenance feature:
    - 'PerformMaintenance' switch parameter is added to Restart-AzureRmVM.
    - Get-AzureRmVM -Status shows the information of performance maintenance of the given VM
* Virtual Machine Identity feature:
    - 'IdentityType' parameter is added to New-AzureRmVMConfig and UpdateAzureRmVM
    - Get-AzureRmVM shows the information of the identity of the given VM
* Vmss Identity feature:
    - 'IdentityType' parameter is added to to New-AzureRmVmssConfig
    - Get-AzureRmVmss shows the information of the identity of the given Vmss
* Vmss Boot Diagnostics feature:
    - New cmdlet for setting boot diagnostics of Vmss object: Set-AzureRmVmssBootDiagnostics
    - 'BootDiagnostic' parameter is added to New-AzureRmVmssConfig
* Vmss LicenseType feature:
    - 'LicenseType' parameter is added to New-AzureRmVmssConfig
* RecoveryPolicyMode support:
    - 'RecoveryPolicyMode' paramter is added to New-AzureRmVmssConfig
* Compute Resource Sku feature:
    - New cmdlet 'Get-AzureRmComputeResourceSku' list all compute resource skus

## Version 3.1.0
* Fix Test-AzureRmVMAEMExtension for virtual machines with multiple managed disks
* Updated Set-AzureRmVMAEMExtension: Add caching information for Premium managed disks
* Add-AzureRmVhd: The size limit on vhd is increased to 4TB.
* Stop-AzureRmVM: Clarify documentation for STayProvisioned parameter
* New-AzureRmDiskUpdateConfig
  * Deprecated parameters CreateOption, StorageAccountId, ImageReference, SourceUri, SourceResourceId
* Set-AzureRmDiskUpdateImageReference: Deprecated cmdlet
* New-AzureRmSnapshotUpdateConfig
  * Deprecated parameters CreateOption, StorageAccountId, ImageReference, SourceUri, SourceResourceId
* Set-AzureRmSnapshotUpdateImageReference: Deprecated Cmdlet

## Version 3.0.1

## Version 3.0.0
* Updated Set-AzureRmVMAEMExtension and Test-AzureRmVMAEMExtension cmdlets to support Premium managed disks
* Backup encryption settings for IaaS VMs and restore on failure
* ChefServiceInterval option is renamed to ChefDaemonInterval now. Old one will continue to work however.
* Remove duplicated DataDiskNames and NetworkInterfaceIDs properties from PS VM object.
  - Make DataDiskNames and NetworkInterfaceIDs parameters optional in Remove-AzureRmVMDataDisk and Remove-AzureRmVMNetworkInterface, respectively.
* Fix the piping issue of Get cmdlets when the Get cmdlets return a list object.
* Cmdlets that conflicted with RDFE cmdlets have been renamed. See issue https://github.com/Azure/azure-powershell/issues/2917 for more details
    - `New-AzureVMSqlServerAutoBackupConfig` has been renamed to `New-AzureRmVMSqlServerAutoBackupConfig`
    - `New-AzureVMSqlServerAutoPatchingConfig` has been renamed to `New-AzureRmVMSqlServerAutoPatchingConfig`
    - `New-AzureVMSqlServerKeyVaultCredentialConfig` has been renamed to `New-AzureRmVMSqlServerKeyVaultCredentialConfig`

## Version 2.9.0
* Fix bug in Get-* cmdlets, to allow retrieving multiple pages of data (more than 120 items)

## Version 2.8.0
* Updated Set-AzureRmVMAEMExtension and Test-AzureRmVMAEMExtension cmdlets to support managed disks

## Version 2.7.0
* Updated Set-AzureRmVMDscExtension cmdlet WmfVersion parameter to support "5.1"
* Updated Set-AzureRmVMChefExtension cmdlet to add following new options :
  - Daemon: Configures the chef-client service for unattended execution. e.g. -Daemon 'none' or e.g. -Daemon 'service'."
  - Secret: The encryption key used to encrypt and decrypt the data bag item values.
  - SecretFile: The path to the file that contains the encryption key used to encrypt and decrypt the data bag item values.
* Fix for Get-AzureRmVM: Get-AzureRmVM did not display anything when the output includes availability set property.
* New cmdlets:
    - Update-AzureRmAvailabilitySet: can update an unmanaged availability set to a managed availability set.
    - Add-AzureRmVmssDataDisk, Remove-AzureRmVmssDataDisk
* New parameter, SkipVmBackup, for cmdlet Set-AzureRmVMDiskEncryptionExtension to allow user to skip backup creation for Linux VMs

## Version 2.6.0
* New cmdlets for Managed disk
    - Disk cmdlets: New-AzureRmDisk, Update-AzureRmDisk, Get-AzureRmDisk, Remove-AzureRmDisk,
                    Grant-AzureRmDiskAccess, Revoke-AzureRmDiskAccess,
                    New-AzureRmDiskConfig, Set-AzureRmDiskDiskEncryptionKey, Set-AzureRmDiskImageReference, Set-AzureRmDiskKeyEncryptionKey,
                    New-AzureRmDiskUpdateConfig, Set-AzureRmDiskUpdateDiskEncryptionKey, Set-AzureRmDiskUpdateImageReference, Set-AzureRmDiskUpdateKeyEncryptionKey
    - Snapshot cmdlets: New-AzureRmSnapshot, Update-AzureRmSnapshot, Get-AzureRmSnapshot, Remove-AzureRmSnapshot,
                        Grant-AzureRmSnapshotAccess, Revoke-AzureRmSnapshotAccess,
                        New-AzureRmSnapshotConfig, Set-AzureRmSnapshotDiskEncryptionKey, Set-AzureRmSnapshotImageReference, Set-AzureRmSnapshotKeyEncryptionKey,
                        New-AzureRmSnapshotUpdateConfig, Set-AzureRmSnapshotUpdateDiskEncryptionKey, Set-AzureRmSnapshotUpdateImageReference, Set-AzureRmSnapshotUpdateKeyEncryptionKey
    - Image cmdlets: New-AzureRmImage, Get-AzureRmImage, Remove-AzureRmImage,
                     New-AzureRmImageConfig, Set-AzureRmImageOsDisk, Add-AzureRmImageDataDisk, Remove-AzureRmImageDataDisk
    - VM cmdlet: ConvertTo-AzureRmVMManagedDisk

## Version 2.5.0
* Fix Get-AzureRmVM with -Status issue: Get-AzureRmVM throws an exception when Get-AzureRmVM lists multiple VMs and some of the VMs are deleted during Get-AzureRmVM is performed.
* New parameters in New-AzureRmVMSqlServerAutoBackupConfig cmdlet to support Auto Backup for SQL Server 2016 VMs.
    - BackupSystemDbs : Specifies if system databases should be added to Sql Server Managed Backup.
    - BackupScheduleType : Specifies the type of managed backup schedule, manual or automated. If it's manual, schedule settings need to be specified.
    - FullBackupFrequency : Specifies the frequency of Full Backup, daily or weekly.
    - FullBackupStartHour : Specifies the hour of the day when the Sql Server Full Backup should start.
    - FullBackupWindowInHours : Specifies the window (in hours) when Sql Server Full Backup should occur.
    - LogBackupFrequencyInMinutes : Specifies the frequency of Sql Server Log Backup.
* New-AzureVMSqlServer* cmdlets are renamed to New-AzureRmVMSqlServer* now. Old ones will continue to work however.

## Version 2.4.0
* Add Remove-AzureRmVMSecret cmdlet.
* Based on user feedback (https://github.com/Azure/azure-powershell/issues/1384), we've added a DisplayHint property to VM object to enable Compact and Expand display modes. This is similar to `Get -Date - DisplayHint Date` cmdlet. By default, the return of `Get-AzureRmVm -ResourceGroupName <rg-name> -Name <vm-name>` will be compact. You can expand the output using `-DisplayHint Expand` parameter.
* UPCOMING BREAKING CHANGE Notification: We've added a warning about removing ` DataDiskNames` and ` NetworkInterfaceIDs` properties from the returned VM object from `Get-AzureRmVm -ResourceGroupName <rg-name> -Name <vm-name` cmdlet. Please update your scripts to access these properties in the following way:
    - `$vm.StorageProfile.DataDisks`
    - `$vm.NetworkProfile.NetworkInterfaces`
* Updated Set-AzureRmVMChefExtension cmdlet to add following new options :
    - JsonAttribute : A JSON string to be added to the first run of chef-client. e.g. -JsonAttribute '{"container_service": {"chef-init-test": {"command": "C:\\opscode\\chef\\bin"}}}'
    - ChefServiceInterval : Specifies the frequency (in minutes) at which the chef-service runs. If in case you don't want the chef-service to be installed on the Azure VM then set value as 0 in this field. e.g. -ChefServiceInterval 45

## Version 2.3.0
* Update formats for list of VMs, VMScaleSets and ContainerService
    - The default format of Get-AzureRmVM, Get-AzureRmVmss and Get-AzureRmContainerService is not table format when these cmdlets call List Operation
* Fix overprovision issue for VMScaleSet
    - Because of the bug in Compute client library (and Swagger spec) regarding overprovision property of VMScaleSet, this property did not show up correctly.
* Better piping scenario for VMScaleSets and ContainerService cmdlets
    - VMScaleSet and ContainerService now have "ResourceGroupName" property, so when piping Get command to Delete/Update command, -ResourceGroupName is not required.
* Separate paremater sets for Set-AzureRmVM with Generalized and Redeploy parameter
* Reduce time taken by Get-AzureRmVMDiskEncryptionStatus cmdlet from two minutes to under five seconds
* Allow Set-AzureRmVMDiskEncryptionStatus to be used with VHDs residing in multiple resource groups
