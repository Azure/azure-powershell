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
* Fixed delay in long running operations [#18567]

## Version 5.4.0
* Added support for Multi-user authorization using Resource Guard for recovery services vault.
* Added support for cross subscription restore for recovery services vault, modified storage account to be fetched from target subscription.

## Version 5.3.1
* Added support for multiple backups per day (hourly) Enhanced policy for workloadType AzureVM.

## Version 5.3.0
* Added support for Trusted VM backup and Enhanced policy for WorkloadType AzureVM.
* Added support for disabling hybrid backup security features in `Set-AzRecoveryServicesVaultProperty` cmdlet. The feature can be re-enabled by setting `DisableHybridBackupSecurityFeature` flag to $false.

## Version 5.2.0
* Azure Backup added support for "Create new virtual machine" and "Replace existing virtual machine" experience for Managed VMs in Restore-AzRecoveryServicesBackupItem cmdlet. To perform a VM restore to AlternateLocation use TargetVMName, TargetVNetName, TargetVNetResourceGroup, TargetSubnetName parameters. To perform a restore to a VM in OriginalLocation, do not provide TargetResourceGroupName and RestoreAsUnmanagedDisks parameters, refer examples for more details.

## Version 5.1.0
* Reverted the configure backup per policy limit for VMs from 1000 to 100. This limit was previously relaxed but as Azure portal has a limit of 100 VMs per policy, we are reverting this limit.
* Added support for multiple backups per day for FileShares.
* Segregated some of the CRR and non-CRR flows based on the SDK update.
* Add EdgeZone parameter to Azure Site recovery service cmdlet `New-AzRecoveryServicesAsrRecoveryPlan`

## Version 5.0.0
* Azure Backup updated validate sets for supported BackupManagementType in `Get-AzRecoveryServicesBackupItem`, `Get-AzRecoveryServicesBackupContainer`, Get-AzRecoveryServicesBackupJob cmdlets.
* Azure Backup added support for SAPHanaDatabase for `Disable-AzRecoveryServicesBackupProtection`, `Unregister-AzRecoveryServicesBackupContainer`, `Get-AzRecoveryServicesBackupItem`, `Get-AzRecoveryServicesBackupContainer` cmdlets.
* Breaking Change: `Get-AzRecoveryServicesBackupJob`, `Get-AzRecoveryServicesBackupContainer` and `Get-AzRecoveryServicesBackupItem` commands will only support `BackupManagementType MAB` instead of `MARS`.
* Azure Site Recovery support for capacity reservation for Azure to Azure provider.

## Version 4.8.0
* Azure Backup fixed issues with StorageConfig
* Azure Backup added NodesList and AutoProtectionPolicy to Get-AzRecoveryServicesBackupProtectableItem Cmdlets.
* Azure Backup fixed GetItemsForContainerParamSet to support fetching the MAB backup item.
* Azure Backup fixed Get-AzRecoveryServicesBackupContainer to support BackupManagementType MAB instead of MARS.
* Added breaking change warning: `Get-AzRecoveryServicesBackupJob`, `Get-AzRecoveryServicesBackupContainer` and `Get-AzRecoveryServicesBackupProtectableItem` commands will only support `BackupManagementType MAB` instead of `MARS` alias, changes will take effect from upcoming breaking release.
* Added support for ZRS disk type for Azure to Azure replication.
* Added Availability zone information in replicated protected item response for Azure to Azure replication.

## Version 4.7.0
* Azure Site Recovery bug fixes for VMware to Azure Reprotect, Update policy and Disable scenarios.
* Azure Backup added the support for UserAssigned MSI in RecoveryServices Vault.

## Version 4.6.0
* Azure Site Recovery multi appliance support for VMware to Azure disaster recovery scenarios using RCM as the control plane.
* Azure Backup fixed targetPhysicalPath issue with SQL CRR
* Azure Backup fixed disable protection for SQL workload
* Azure Backup resolved bug in setting CMK properties in latest release
* Azure Backup removed special characters from register-azrecoveryservicesbackupcontainer command help text

## Version 4.5.0
* Added MSI based restore for managed virtual machines.

## Version 4.4.0
* Added Archive for V1 vaults.
* Added ProtectedItemsCount in Get-AzRecoveryServicesBackupProtectionPolicy.
* Azure site recovery bug fix for azure to azure in update vm properties.

## Version 4.3.0
* Fixed Disable SQL AG AutoProtection.

## Version 4.2.0
* Added cross tenant DS Move.
* Removed restriction to fetch recovery points only for a 30 days time range.
* Enabled CRR for new regions.

## Version 4.1.0
* Fixed security issue with SQL restore, this is a necessary breaking change. TargetContainer becomes mandatory for Alternate Location Restore.
* Removed Set-AzRecoveryServicesBackupProperties cmdlet alias, Set-AzRecoveryServicesBackupProperty is supported.
* Removed Get-AzRecoveryServicesBackupJobDetails cmdlet alias, Get-AzRecoveryServicesBackupJobDetail is supported.
* Added support for cross subscription DS Move.
* Azure Site Recovery support for VMware to Azure disaster recovery scenarios using RCM as the control plane.

## Version 3.6.0
* Azure Site Recovery support for Multiple IP per NIC for Azure to Azure provider.
* Azure Site Recovery support for SqlServerLicenseType for VMware to Azure and HyperV to Azure providers.
* Azure Site Recovery support for Availability set for VMware to Azure and HyperV to Azure providers.
* Azure Site Recovery support for TargetVmSize for VMware to Azure and HyperV to Azure providers.
* Azure Site Recovery support for ResourceTagging for VMware to Azure and HyperV to Azure providers.
* Azure Site Recovery support for Virtual Machine Scale Set for Azure to Azure provider.
* Added support for restoring unmanaged disks vm as managed disks.

## Version 3.5.0
* Added Cross Zonal Restore for managed virtual machines.

## Version 3.4.1
* Added null check for target storage account in FileShare restore.

## Version 3.4.0
* modified policy validation limits as per backup service.
* Added Zone Redundancy for Recovery Service Vaults. 
* Azure Site Recovery support for Proximity placement group for VMware to Azure and HyperV to Azure providers.
* Azure Site Recovery support for Availability zone for VMware to Azure and HyperV to Azure providers.
* Azure Site Recovery support for UseManagedDisk for HyperV to Azure provider

## Version 3.3.0
* Added Cross Region Restore feature.  
* Blocked getting workload config when target item is an availability group.

## Version 3.2.0
* Enabled softdelete feature for SQL.
* Fixed SQL AG restore and removed the container name check.
* Changed container name format for Azure Files backup item.
* Added CMK feature support for Recovery services vault.

## Version 3.1.0
* Made help text and parameter set name changes to `Restore-AzRecoveryServicesBackupItem` cmdlet.

## Version 3.0.1
* Specifying policy BackupTime is in UTC.
* Modifying breaking change warning in Get-AzRecoveryServicesBackupJobDetails cmdlet.
* Updating sample script help text for Set-AzRecoveryServicesBackupProtectionPolicy cmdlet.

## Version 3.0.0
* Fixing Workload Restore for contributor permissions.
* Added new parameter sets and validations for Restore-AzRecoveryServicesBackupItem cmdlet.

## Version 2.12.2
* Added container name validation for workload backup.

## Version 2.12.1
* Fixed the Delete State for workload Backup Items.

## Version 2.12.0
* Azure Backup added a new cmdlet Copy-AzRecoveryServicesVault for DS move feature.
* Get-AzRecoveryServicesBackupJob cmdlet now supports operation type 'BackupDataMove'.
* Modifying the configure backup per policy limit for VMs from 100 to 1000.

## Version 2.11.1
* Improved the Azure Backup container/item discovery experience.

## Version 2.11.0
* Removed project reference to Authentication
* Azure Backup tuned cmdlets help text to be more accurate.
* Azure Backup added support for fetching MAB agent jobs using `Get-AzRecoveryServicesBackupJob` cmdlet.


## Version 2.10.0
* Azure Backup added support for fetching MAB items.
* Azure Site Recovery support to update failover and test failover NIC names, existing NIC reuse.
* Azure Site Recovery supports disk type "StandardSSD_LRS"

## Version 2.9.1
* Azure Site Recovery support for creating recovery plan for zone to zone replication from xml input.
* Updated assembly version of SiteRecovery and Backup cmdlets

## Version 2.9.0
* Azure Site Recovery added support for protecting proximity placement group virtual machines for Azure to Azure provider.
* Azure Site Recovery added support for zone to zone replication.
* Azure Backup Added Long term retention support for Azure FileShare Recovery Points.
* Azure Backup Added disk exclusion properties to `Get-AzRecoveryServicesBackupItem` cmdlet output.
* Added private endpoint for Vault credential file for site recovery service.
* Azure Site Recovery added support for zone to zone replication using recovery plan.

## Version 2.8.0
* Azure Site Recovery added support for doing reprotect and updated vm properties for Azure disk encrypted Virtual Machines.
* Added Azure Site Recovery VmwareToAzure properties DR monitoring
* Azure Backup added support for retrying policy update for failed items.
* Azure Backup Added support for disk exclusion settings during backup and restore.
* Azure Backup Added Support for Restoring Multiple files/folders in AzureFileShare
* Azure Backup Added support for User-specified Resourcegroup support while updating IaasVM Policy

## Version 2.7.0
* Added Support for Restore-as-files for SQL Databases.

## Version 2.6.0
* Azure Backup Added filtering of backup item based on friendly name.
* Fixed Vault credential file download for backup and site recovery service
* Fixes for few properties for update policy of H2A 

## Version 2.5.0
* Azure Site Recovery support for removing a replicated disk.
* Azure Backup added support for adding tags while creating a Recovery Services Vault.

## Version 2.4.0
* Azure Site Recovery change support for managed disk vms encrypted at rest with customer managed keys for Azure to Azure provider.
* Azure Site Recovery support to input disk encryption Set Id as optional input at enabling protection for Vmware to Azure.
* Azure Site Recovery support to input disk encryption Set Id as optional input at disk level to enable protection for Vmware to Azure.
* Azure Site Recovery support to update replication protected item with disk encryption set Map for HyperV to Azure.

* Azure Site Recovery support to update failover and test failover disk names.
* Azure Site Recovery support to update failover and test failover virtual machine names. 
* Azure Site Recovery support for new test failover networking configurations.
* Azure Site Recovery support to update failover and test failover configurations of multiple NICs through powershell.

## Version 2.3.0
* Update references in .psd1 to use relative path
* Azure Site Recovery support for Azure Disk Encryption One Pass for Azure to Azure.

## Version 2.2.0
* Azure Backup added support for enabling and disabling soft delete feature for Recovery Services Vault.

## Version 2.1.0

* Azure Site Recovery support to select disk type at enabling protection.
* Azure Site Recovery bug fix for recovery plan action edit.
* Azure Backup SQL Restore support to accept filestream DBs.
* Azure Backup updated SDK version.


## Version 2.0.1

* Azure Site Recovery support to configure networking resources like NSG, public IP and internal load balancers for Azure to Azure.
* Azure Site Recovery Support to write to managed disk for vMWare to Azure.
* Azure Site Recovery Support to NIC reduction for vMWare to Azure.
* Azure Site Recovery Support to accelerated networking for Azure to Azure.
* Azure Site Recovery Support to agent auto update for Azure to Azure.
* Azure Site Recovery Support to Standard SSD for Azure to Azure.
* Azure Site Recovery Support to Azure Disk Encryption two pass for Azure to Azure.
* Azure Site Recovery Support to protect newly added disk for Azure to Azure.
* Added SoftDelete feature for VM and added tests for soft delete.

## Version 1.4.5
* Update AzureVMpolicy Object with ProtectedItemsCount Attribute
* Added Tests for VM policy and Original Storage Account Restore

## Version 1.4.4
* Fixed miscellaneous typos across module
* Update 'Get-AzRecoveryServicesBackupJobDetail.md'

## Version 1.4.3
* Update 'Get-AzRecoveryServicesBackupJob.md'
* Update 'Get-AzRecoveryServicesBackupContainer.md'
* Update 'Get-AzRecoveryServicesVault.md'
* Update 'Wait-AzRecoveryServicesBackupJob.md'
* Update 'Set-AzRecoveryServicesVaultContext.md'
* Update 'Get-AzRecoveryServicesBackupItem.md'
* Update 'Get-AzRecoveryServicesBackupRecoveryPoint.md'
* Update 'Restore-AzRecoveryServicesBackupItem.md'
* Updated service call for Unregistering container for Azure File Share
* Update 'Set-AzRecoveryServicesAsrAlertSetting.md'

## Version 1.4.2
* Fix for get-policy command for IaaSVMs
* Fixes regarding 'Set-AzRecoveryServicesVaultContext' deprecation

## Version 1.4.1
* IaaSVM policy minimum retention in days changed to 7 from 1

## Version 1.4.0
* Support for Cross subscription Azure to Azure site recovery.
* Marking upcoming breaking changes for Azure Site Recovery.
* Fix for Azure Site Recovery recovery plan end action plan.
* Fix for Azure Site Recovery Update network mapping for Azure to Azure.
* Fix for Azure Site Recovery update protection direction for Azure to Azure for managed disk.
* Other minor fixes.

## Version 1.3.0
* Updated cmdlets with plural nouns to singular, and deprecated plural names.
* Updated table format for SQL in azure VM
* Added alternate method to fetch location in AzureFileShare
* Updated ScheduleRunDays in SchedulePolicy object according to timezone
* Made some attibutes read-only in Get-AzRecoveryServicesBackupWorkloadRecoveryConfig 

## Version 1.2.0
* Added SnapshotRetentionInDays in Azure VM policy to support Instant RP
* Added pipe support for unregister container
 
## Version 1.1.0
* Added Sql server in Azure VM support
* SDK Update
* Removed VMappContainer check in Get-ProtectableItem
* Added Name and ServerName as parameters for Get-ProtectableItem
* Updated internal API for triggering adhoc inquiry

## Version 1.0.1
* Release with updated Authentication dependency

## Version 1.0.0
* General availability of `Az.RecoveryServices` module
