﻿<!--
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
* Updated Set-AzureVMChefExtension cmdlet to add following new options :
    - Daemon: Configures the chef-client service for unattended execution. e.g. -Daemon 'none' or e.g. -Daemon 'service'."
    - Secret: The encryption key used to encrypt and decrypt the data bag item values.
    - SecretFile: The path to the file that contains the encryption key used to encrypt and decrypt the data bag item values.

## Version 3.4.0
* New parameters in New-AzureVMSqlServerAutoBackupConfig cmdlet to support Auto Backup for SQL Server 2016 VMs.
	- BackupSystemDbs : Specifies if system databases should be added to Sql Server Managed Backup.
	- BackupScheduleType : Specifies the type of managed backup schedule, manual or automated. If it's manual, schedule settings need to be specified.
	- FullBackupFrequency : Specifies the frequency of Full Backup, daily or weekly.
	- FullBackupStartHour : Specifies the hour of the day when the Sql Server Full Backup should start.
	- FullBackupWindowInHours : Specifies the window (in hours) when Sql Server Full Backup should occur.
	- LogBackupFrequencyInMinutes : Specifies the frequency of Sql Server Log Backup.

## Version 3.3.0
* Updated Set-AzureVMChefExtension cmdlet to add following new options :
    - JsonAttribute : A JSON string to be added to the first run of chef-client. e.g. -JsonAttribute '{"container_service": {"chef-init-test": {"command": "C:\\opscode\\chef\\bin"}}}'
    - ChefServiceInterval : Specifies the frequency (in minutes) at which the chef-service runs. If in case you don't want the chef-service to be installed on the Azure VM then set value as 0 in this field. e.g. -ChefServiceInterval 45
* Updated New-AzureVirtualNetworkGatewayConnection cmdlet to add validation on acceptable input parameter:GatewayConnectionType values sets and it can be case insensitive:
    - GatewayConnectionType : Added validation to accept only set of values:- 'ExpressRoute'/'IPsec'/'Vnet2Vnet'/'VPNClient' and acceptable set of values can be passed in any casing.
* Updating Managed Cache warning message which notifies customer about service deprecation on the following cmdlets :
    - Get-AzureManagedCache
    - Get-AzureManagedCacheAccessKey
    - Get-AzureManagedCacheLocation
    - Get-AzureManagedCacheNamedCache
    - New-AzureManagedCache
    - New-AzureManagedCacheAccessKey
    - New-AzureManagedCacheNamedCache
    - Remove-AzureManagedCache
    - Remove-AzureManagedCacheNamedCache
    - Set-AzureManagedCache
    - Set-AzureManagedCacheNamedCache
* For more information about Managed Cache service deprecation, see http://go.microsoft.com/fwlink/?LinkID=717458

## Version 3.1.0