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
* Set-AzureRmVMAEMExtension: Add support for new Premium Disk sizes
* Set-AzureRmVMAEMExtension: Add support for M series

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