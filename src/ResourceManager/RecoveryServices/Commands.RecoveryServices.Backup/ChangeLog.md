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
* Fix for modifying policy for a protected file share.
* Converted policy timezone to uppercase.

## Version 4.5.0
* Added support for azure file shares in recovery services.

## Version 4.4.1
* Fixed issue with default resource groups not being set.
* Updated common runtime assemblies

## Version 4.4.0
* Added policy filter to Get-AzureRmRecoveryServicesBackItem cmdlet. The command returns the list of backup items protected by the given policy id.
* Updated Microsoft.Azure.Management.RecoveryServices.Backup to version 3.0.0-preview.
* Updated to the latest version of the Azure ClientRuntime.
* Added TargetResourceGroupName parameter to Restore-AzureRmRecoveryServicesBackupItem. The resource group to which the managed disks are restored. Applicable to backup of VM with managed disks.

## Version 4.3.1
* Updated all help files to include full parameter types and correct input/output types.

## Version 4.3.0
* Fixed formatting of OutputType in help files
* Added Get-AzureRmRecoveryServicesBackupStatus cmdlet. This cmdlet takes a VM ID and checks if the VM is protected by some vault in the subscription. If there exists such a vault, the cmdlet outputs the vault details.

## Version 4.2.0
* Added -Vault parameter to RecoveryServices.Backup cmdlets. When passed, this will override the Set-AzureRmRecoveryServicesContext cmdlet.

## Version 4.1.3
* Set minimum dependency of module to PowerShell 5.0

## Version 4.1.2
* Updated to the latest version of the Azure ClientRuntime

## Version 4.1.1
* Fixed issue with cleaning up scripts in build

## Version 4.1.0
* Added ResourceGroup Completer to -ResourceGroup parameters allowing tab completion through resource groups in current subscription
* Added -UseOriginalStorageAccount option to the Restore-AzureRmRecoveryServicesBackupItem cmdlet.
	- Enabling this flag results in restoring disks to their original storage accounts which allows users to maintain the configuration of restored VM as close to the original VMs as possible.
	- It also helps in improving the performance of the restore operation.

## Version 4.0.3
* Fixed bug - Get-AzureRmRecoveryServicesBackupItem should do case insensitive comparison for container name filter.
* Fixed bug - AzureVmItem now has a property that shows the last time a backup operation has happened - LastBackupTime.

## Version 4.0.1
* Fixed assembly loading issue that caused some cmdlets to fail when executing

## Version 4.0.0
* Added cmdlets to perform instant file recovery.
    - Get-AzureRmRecoveryServicesBackupRPMountScript
    - Disable-AzureRmRecoveryServicesBackupRPMountScript
* Updated RecoveryServices.Backup SDK version to the latest
* Updated tests for the Azure VM workload so that, all setups needed for test runs are done by the tests themselves.
* Fixes https://github.com/Azure/azure-powershell/issues/3164
* Add support for online help
    - Run Get-Help with the -Online parameter to open the online help in your default Internet browser

## Version 3.4.1

## Version 3.4.0

## Version 3.3.1

## Version 3.3.0

## Version 3.2.1

## Version 3.2.0

## Version 3.1.0

## Version 3.0.1

## Version 3.0.0

## Version 2.8.0

## Version 2.7.0

## Version 2.6.0

## Version 2.5.0

## Version 2.4.0
* Migrated from Hyak based Azure SDK to Swagger based Azure SDK

## Version 2.3.0
