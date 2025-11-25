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

## Version 3.0.14
* Added TargetCapacityReservationGroupId parameter in the following cmdlets
 - `New-AzMigrateServerReplication`
 - `Set-AzMigrateServerReplication`
 - `Start-AzMigrateServerMigration`
* Updated Migrate.RecoveryServices to stable API version 2025-08-01

## Version 2.10.1
* Fixed bugs in `Initialize-AzMigrateLocalReplicationInfrastructure`
  - Correct AMH solution tool name of "ServerMigration_DataReplication" is now being passed in to address replication count missing and UX experience load issues in Azure Migrate on Azure portal.
* Address Join-Path compatibility issue in older version of PowerShell environment such as PowerShell 5.1 in the following commands
 - `Initialize-AzMigrateLocalReplicationInfrastructure`
 - `Initialize-AzMigrateReplicationInfrastructure`
 - `New-AzMigrateLocalServerReplication`
 - `Get-AzMigrateLocalServerReplication`
 - `Set-AzMigrateLocalServerReplication`
 - `Start-AzMigrateLocalServerMigration`

## Version 2.10.0
* Fixed bugs in `New-AzMigrateLocalDiskMappingObject`: Only validate for non-512 physical sector size of VHD when `-PhysicalSectorSize` parameter is given
* Fixed bugs in `New-AzMigrateLocalServerReplication`: Only validate for non-512 physical sector size of VHD when `-PhysicalSectorSize` parameter is given. Removed reserved words validation for source disk names as it is no longer required. Added ARM id validation for input parameters
* Fixed bugs in `Set-AzMigrateLocalServerReplication`: Added ARM id validation for input parameters
* Fixed bugs in `Get-AzMigrateLocalServerReplication`: Added ARM id validation for input parameters
* Enhanced Get-AzMigrateServerMigrationStatus to add support for the -Expedite parameter.

## Version 2.9.0
* Added `-OsType` as an optional parameter to command `Set-AzMigrateLocalServerReplication` to allow user-specified OS type.
* Fixed bugs in `New-AzMigrateServerReplication` caused by deprecation of `Get-AzVmSize -location`
* Removed `-TargetStoragePathId` parameter from command `New-AzMigrateLocalDiskMappingObject` until the feature to associate each disk to their own storage container path is supported.
* Added `-SourceApplianceName` and `-TargetApplianceName` as required parameters to command `New-AzMigrateLocalServerReplication` to allow users to specify appliance pairs of their choosing.
* Enhanced resource validations in `Initialize-AzMigrateLocalReplicationInfrastructure` and `New-AzMigrateLocalServerReplication`.

## Version 2.8.0
* Implemented the Get-AzMigrateServerMigrationStatus cmdlet to retrieve the replication status of servers in Azure Migrate.
* Fixed bugs in `New-AzMigrateLocalServerReplication` that caused HyperVSite or VMwareSite not found.

## Version 2.7.1

* Added validation for Data.Replication
  - Added validation to protect virtual machines in `New-AzMigrateLocalServerReplication`

## Version 2.7.0
* Updated Data.Replication to newer API version
  - Updated Data.Replication to point to stable API version 2024-09-01
* Rebranded Data.Replication cmdlets
  - Rebranded Data.Replication cmdlets from Azure Stack HCI to Azure Local

## Version 2.6.0
* Upgraded nuget package to signed package.
* Added support for PremiumV2 disk type.
* Added SBM support.

## Version 2.5.0
* Validated user login with Microsoft Managed System Identity (MSI) in `Initialize-AzMigrateHCIReplicationInfrastructure`
* Passed appropriate Hyper-V Generation value based on source VMware firmware type in `New-AzMigrateHCIServerReplication`
* Added support for LinuxLicenseType in Az.Migrate module.

## Version 2.4.0
* Removed "at lease one NIC needs to be user selected" constrain when creating/updating server replication (protected item)
* Added retries for calls to internal Get commands

## Version 2.3.1
* Introduced secrets detection feature to safeguard sensitive data.

## Version 2.3.0
* Added support for `Data.Replication`

## Version 2.2.0
* Fixed key vault SPN Id coming as null for some users
* Added support for Windows Server OS upgrade while migrating the server to Azure using Azure Migrate
* Updated OsUpgradeVersion parameter for Azure Migrate

## Version 2.1.0
* Added parameter `CacheStorageAccountId` to `Initialize-AzMigrateReplicationInfrastructure`
* Added support for OS Disk Swap and Test Migrate Subnet Selection

## Version 2.0.0
* Updated ApiVersion to 2022-05-01
* Added support for pause and resume
  * `Suspend-AzMigrateServerReplication`
  * `Resume-AzMigrateServerReplication`
* [Breaking Change] Removed unless cmdlets
  * `Get-AzMigrateReplicationEligibilityResult`
  * `Get-AzMigrateReplicationProtectionIntent`
  * `Get-AzMigrateReplicationVaultSetting`
  * `Get-AzMigrateSupportedOperatingSystem`
  * `New-AzMigrateReplicationProtectionIntent`
  * `New-AzMigrateReplicationVaultSetting`
## Version 1.1.3
* Fixed a cross-subscription issue

## Version 1.1.2
* Added check for invalid IP address

## Version 1.1.1
* Supported duplicate disk UUID in source disk.
* Supported subnets in same VNet for AVSet.
* Supported runAsAccount fetching for multiple Vcenters in same site.

## Version 1.1.0
* Added SQL Server license type.
* Added CRN feature.
* Added resource tags feature.
* Updated to 2021-02-10 api version.

## Version 1.0.2
* Fixed an issue in Initialize-AzMigrateReplicationInfrastructure.ps1

## Version 1.0.1
* Nullref Bug fixed in get discovered server and initialize replication infrastructure commandlets.

## Version 1.0.0
* Az.Migrate GA
* Incorporated Initialize-AzMigrateReplicationInfrastructure as a cmdlet in the Az.Migrate module, from the external script that is run currently today.
* Made some parameters of New-AzMigrateServerReplication, New-AzMigrateDiskMapping case insensitive.
* Added support for scale appliance change, to handle new V3 keys.

## Version 0.2.0
* Bug fixed in update replication migration item to pass all properties (changed/unchanged) to service, and not just the changed ones.
* Bug fixed in enable migrate to pick correct run as account id for VMware Cbt provider.
* Added new parameter (MachineName) in get replication migration item, to get replication migration item by friendly name.
* Bug fixed in enable migrate to stop passing Target Boot Diagnostic Storage Account if it is in a different subscription id than the target VM.
* Fix to in online URLs of existing code doc.

## Version 0.1.1
* Bug fixed in enable replication, to make default user scenario migrate all disks by default. Earlier the cmdlet was only migrating the OS disk, which was a bug.

## Version 0.1.0
* First preview release for module Az.Migrate. The cmdlets to support common scenarios of Migrate like enable replication, update replication item, get migration items, migrate, test migrate and clean up have been exposed.
