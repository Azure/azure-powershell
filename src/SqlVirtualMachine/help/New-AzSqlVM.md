---
external help file:
Module Name: Az.SqlVirtualMachine
online version: https://learn.microsoft.com/powershell/module/az.sqlvirtualmachine/new-azsqlvm
schema: 2.0.0
---

# New-AzSqlVM

## SYNOPSIS
Creates or updates a SQL virtual machine.

## SYNTAX

```
New-AzSqlVM -Name <String> -ResourceGroupName <String> -Location <String> [-SubscriptionId <String>]
 [-AdditionalFeatureServerConfigurationIsRServicesEnabled] [-AssessmentSettingEnable]
 [-AssessmentSettingRunImmediately] [-AutoBackupSettingBackupScheduleType <BackupScheduleType>]
 [-AutoBackupSettingBackupSystemDb] [-AutoBackupSettingDaysOfWeek <AutoBackupDaysOfWeek[]>]
 [-AutoBackupSettingEnable] [-AutoBackupSettingEnableEncryption]
 [-AutoBackupSettingFullBackupFrequency <FullBackupFrequencyType>]
 [-AutoBackupSettingFullBackupStartTime <Int32>] [-AutoBackupSettingFullBackupWindowHour <Int32>]
 [-AutoBackupSettingLogBackupFrequency <Int32>] [-AutoBackupSettingPassword <SecureString>]
 [-AutoBackupSettingRetentionPeriod <Int32>] [-AutoBackupSettingStorageAccessKey <String>]
 [-AutoBackupSettingStorageAccountUrl <String>] [-AutoBackupSettingStorageContainerName <String>]
 [-AutoPatchingSettingDayOfWeek <DayOfWeek>] [-AutoPatchingSettingEnable]
 [-AutoPatchingSettingMaintenanceWindowDuration <Int32>]
 [-AutoPatchingSettingMaintenanceWindowStartingHour <Int32>] [-AzureAdAuthenticationSettingClientId <String>]
 [-EnableAutomaticUpgrade] [-IdentityType <IdentityType>]
 [-KeyVaultCredentialSettingAzureKeyVaultUrl <String>] [-KeyVaultCredentialSettingCredentialName <String>]
 [-KeyVaultCredentialSettingEnable] [-KeyVaultCredentialSettingServicePrincipalName <String>]
 [-KeyVaultCredentialSettingServicePrincipalSecret <String>] [-LeastPrivilegeMode <LeastPrivilegeMode>]
 [-LicenseType <SqlServerLicenseType>] [-Offer <String>] [-ScheduleDayOfWeek <AssessmentDayOfWeek>]
 [-ScheduleEnable] [-ScheduleMonthlyOccurrence <Int32>] [-ScheduleStartTime <String>]
 [-ScheduleWeeklyInterval <Int32>] [-Sku <SqlImageSku>]
 [-SqlConnectivityUpdateSettingConnectivityType <ConnectivityType>]
 [-SqlConnectivityUpdateSettingPort <Int32>]
 [-SqlConnectivityUpdateSettingSqlAuthUpdatePassword <SecureString>]
 [-SqlConnectivityUpdateSettingSqlAuthUpdateUserName <String>] [-SqlDataSettingDefaultFilePath <String>]
 [-SqlDataSettingLun <Int32[]>] [-SqlInstanceSettingCollation <String>] [-SqlInstanceSettingIsIfiEnabled]
 [-SqlInstanceSettingIsLpimEnabled] [-SqlInstanceSettingIsOptimizeForAdHocWorkloadsEnabled]
 [-SqlInstanceSettingMaxDop <Int32>] [-SqlInstanceSettingMaxServerMemoryMb <Int32>]
 [-SqlInstanceSettingMinServerMemoryMb <Int32>] [-SqlLogSettingDefaultFilePath <String>]
 [-SqlLogSettingLun <Int32[]>] [-SqlManagementType <SqlManagementMode>]
 [-SqlStorageUpdateSettingDiskConfigurationType <DiskConfigurationType>]
 [-SqlStorageUpdateSettingDiskCount <Int32>] [-SqlStorageUpdateSettingStartingDeviceId <Int32>]
 [-SqlTempDbSettingDataFileCount <Int32>] [-SqlTempDbSettingDataFileSize <Int32>]
 [-SqlTempDbSettingDataGrowth <Int32>] [-SqlTempDbSettingDefaultFilePath <String>]
 [-SqlTempDbSettingLogFileSize <Int32>] [-SqlTempDbSettingLogGrowth <Int32>] [-SqlTempDbSettingLun <Int32[]>]
 [-SqlTempDbSettingPersistFolder] [-SqlTempDbSettingPersistFolderPath <String>]
 [-SqlVirtualMachineGroupResourceId <String>] [-SqlWorkloadTypeUpdateSettingSqlWorkloadType <SqlWorkloadType>]
 [-StorageConfigurationSettingDiskConfigurationType <DiskConfigurationType>]
 [-StorageConfigurationSettingSqlSystemDbOnDataDisk]
 [-StorageConfigurationSettingStorageWorkloadType <StorageWorkloadType>] [-Tag <Hashtable>]
 [-VirtualMachineResourceId <String>] [-WsfcDomainCredentialsClusterBootstrapAccountPassword <SecureString>]
 [-WsfcDomainCredentialsClusterOperatorAccountPassword <SecureString>]
 [-WsfcDomainCredentialsSqlServiceAccountPassword <SecureString>] [-WsfcStaticIP <String>]
 [-DefaultProfile <PSObject>] [-AsJob] [-NoWait] [-Confirm] [-WhatIf] [<CommonParameters>]
```

## DESCRIPTION
Creates or updates a SQL virtual machine.

## EXAMPLES

### Example 1
```powershell
New-AzSqlVM -ResourceGroupName 'ResourceGroup01' -Name 'sqlvm1' -Location 'eastus'
```

```output
Location	Name		ResourceGroupName
--------	----		-----------------
eastus		sqlvm1		ResourceGroup01	
```



### Example 2
```powershell
New-AzSqlVM -ResourceGroupName 'ResourceGroup01' -Name 'sqlvm1' -Location 'eastus' -Sku 'Developer' -LicenseType 'PAYG'
```

```output
Location	Name		ResourceGroupName
--------	----		-----------------
eastus		sqlvm1		ResourceGroup01	
```



## PARAMETERS

### -AdditionalFeatureServerConfigurationIsRServicesEnabled
Enable or disable R services (SQL 2016 onwards).

```yaml
Type: System.Management.Automation.SwitchParameter
Parameter Sets: (All)
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -AsJob
Run the command as a job

```yaml
Type: System.Management.Automation.SwitchParameter
Parameter Sets: (All)
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -AssessmentSettingEnable
Enable or disable SQL best practices Assessment feature on SQL virtual machine.

```yaml
Type: System.Management.Automation.SwitchParameter
Parameter Sets: (All)
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -AssessmentSettingRunImmediately
Run SQL best practices Assessment immediately on SQL virtual machine.

```yaml
Type: System.Management.Automation.SwitchParameter
Parameter Sets: (All)
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -AutoBackupSettingBackupScheduleType
Backup schedule type.

```yaml
Type: Microsoft.Azure.PowerShell.Cmdlets.SqlVirtualMachine.Support.BackupScheduleType
Parameter Sets: (All)
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -AutoBackupSettingBackupSystemDb
Include or exclude system databases from auto backup.

```yaml
Type: System.Management.Automation.SwitchParameter
Parameter Sets: (All)
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -AutoBackupSettingDaysOfWeek
Days of the week for the backups when FullBackupFrequency is set to Weekly.

```yaml
Type: Microsoft.Azure.PowerShell.Cmdlets.SqlVirtualMachine.Support.AutoBackupDaysOfWeek[]
Parameter Sets: (All)
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -AutoBackupSettingEnable
Enable or disable autobackup on SQL virtual machine.

```yaml
Type: System.Management.Automation.SwitchParameter
Parameter Sets: (All)
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -AutoBackupSettingEnableEncryption
Enable or disable encryption for backup on SQL virtual machine.

```yaml
Type: System.Management.Automation.SwitchParameter
Parameter Sets: (All)
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -AutoBackupSettingFullBackupFrequency
Frequency of full backups.
In both cases, full backups begin during the next scheduled time window.

```yaml
Type: Microsoft.Azure.PowerShell.Cmdlets.SqlVirtualMachine.Support.FullBackupFrequencyType
Parameter Sets: (All)
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -AutoBackupSettingFullBackupStartTime
Start time of a given day during which full backups can take place.
0-23 hours.

```yaml
Type: System.Int32
Parameter Sets: (All)
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -AutoBackupSettingFullBackupWindowHour
Duration of the time window of a given day during which full backups can take place.
1-23 hours.

```yaml
Type: System.Int32
Parameter Sets: (All)
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -AutoBackupSettingLogBackupFrequency
Frequency of log backups.
5-60 minutes.

```yaml
Type: System.Int32
Parameter Sets: (All)
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -AutoBackupSettingPassword
Password for encryption on backup.

```yaml
Type: System.Security.SecureString
Parameter Sets: (All)
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -AutoBackupSettingRetentionPeriod
Retention period of backup: 1-90 days.

```yaml
Type: System.Int32
Parameter Sets: (All)
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -AutoBackupSettingStorageAccessKey
Storage account key where backup will be taken to.

```yaml
Type: System.String
Parameter Sets: (All)
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -AutoBackupSettingStorageAccountUrl
Storage account url where backup will be taken to.

```yaml
Type: System.String
Parameter Sets: (All)
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -AutoBackupSettingStorageContainerName
Storage container name where backup will be taken to.

```yaml
Type: System.String
Parameter Sets: (All)
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -AutoPatchingSettingDayOfWeek
Day of week to apply the patch on.

```yaml
Type: Microsoft.Azure.PowerShell.Cmdlets.SqlVirtualMachine.Support.DayOfWeek
Parameter Sets: (All)
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -AutoPatchingSettingEnable
Enable or disable autopatching on SQL virtual machine.

```yaml
Type: System.Management.Automation.SwitchParameter
Parameter Sets: (All)
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -AutoPatchingSettingMaintenanceWindowDuration
Duration of patching.

```yaml
Type: System.Int32
Parameter Sets: (All)
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -AutoPatchingSettingMaintenanceWindowStartingHour
Hour of the day when patching is initiated.
Local VM time.

```yaml
Type: System.Int32
Parameter Sets: (All)
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -AzureAdAuthenticationSettingClientId
The client Id of the Managed Identity to query Microsoft Graph API.
An empty string must be used for the system assigned Managed Identity

```yaml
Type: System.String
Parameter Sets: (All)
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -DefaultProfile
The credentials, account, tenant, and subscription used for communication with Azure.

```yaml
Type: System.Management.Automation.PSObject
Parameter Sets: (All)
Aliases: AzureRMContext, AzureCredential

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -EnableAutomaticUpgrade
Enable automatic upgrade of Sql IaaS extension Agent.

```yaml
Type: System.Management.Automation.SwitchParameter
Parameter Sets: (All)
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -IdentityType
The identity type.
Set this to 'SystemAssigned' in order to automatically create and assign an Azure Active Directory principal for the resource.

```yaml
Type: Microsoft.Azure.PowerShell.Cmdlets.SqlVirtualMachine.Support.IdentityType
Parameter Sets: (All)
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -KeyVaultCredentialSettingAzureKeyVaultUrl
Azure Key Vault url.

```yaml
Type: System.String
Parameter Sets: (All)
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -KeyVaultCredentialSettingCredentialName
Credential name.

```yaml
Type: System.String
Parameter Sets: (All)
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -KeyVaultCredentialSettingEnable
Enable or disable key vault credential setting.

```yaml
Type: System.Management.Automation.SwitchParameter
Parameter Sets: (All)
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -KeyVaultCredentialSettingServicePrincipalName
Service principal name to access key vault.

```yaml
Type: System.String
Parameter Sets: (All)
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -KeyVaultCredentialSettingServicePrincipalSecret
Service principal name secret to access key vault.

```yaml
Type: System.String
Parameter Sets: (All)
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -LeastPrivilegeMode
SQL IaaS Agent least privilege mode.

```yaml
Type: Microsoft.Azure.PowerShell.Cmdlets.SqlVirtualMachine.Support.LeastPrivilegeMode
Parameter Sets: (All)
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -LicenseType
SQL Server license type.

```yaml
Type: Microsoft.Azure.PowerShell.Cmdlets.SqlVirtualMachine.Support.SqlServerLicenseType
Parameter Sets: (All)
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -Location
Resource location.

```yaml
Type: System.String
Parameter Sets: (All)
Aliases:

Required: True
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -Name
Name of the SQL virtual machine.

```yaml
Type: System.String
Parameter Sets: (All)
Aliases: SqlVirtualMachineName, SqlVMName

Required: True
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -NoWait
Run the command asynchronously

```yaml
Type: System.Management.Automation.SwitchParameter
Parameter Sets: (All)
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -Offer
SQL image offer.
Examples include SQL2016-WS2016, SQL2017-WS2016.

```yaml
Type: System.String
Parameter Sets: (All)
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -ResourceGroupName
Name of the resource group that contains the resource.
You can obtain this value from the Azure Resource Manager API or the portal.

```yaml
Type: System.String
Parameter Sets: (All)
Aliases:

Required: True
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -ScheduleDayOfWeek
Day of the week to run assessment.

```yaml
Type: Microsoft.Azure.PowerShell.Cmdlets.SqlVirtualMachine.Support.AssessmentDayOfWeek
Parameter Sets: (All)
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -ScheduleEnable
Enable or disable assessment schedule on SQL virtual machine.

```yaml
Type: System.Management.Automation.SwitchParameter
Parameter Sets: (All)
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -ScheduleMonthlyOccurrence
Occurrence of the DayOfWeek day within a month to schedule assessment.
Takes values: 1,2,3,4 and -1.
Use -1 for last DayOfWeek day of the month

```yaml
Type: System.Int32
Parameter Sets: (All)
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -ScheduleStartTime
Time of the day in HH:mm format.
Eg.
17:30

```yaml
Type: System.String
Parameter Sets: (All)
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -ScheduleWeeklyInterval
Number of weeks to schedule between 2 assessment runs.
Takes value from 1-6

```yaml
Type: System.Int32
Parameter Sets: (All)
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -Sku
SQL Server edition type.

```yaml
Type: Microsoft.Azure.PowerShell.Cmdlets.SqlVirtualMachine.Support.SqlImageSku
Parameter Sets: (All)
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -SqlConnectivityUpdateSettingConnectivityType
SQL Server connectivity option.

```yaml
Type: Microsoft.Azure.PowerShell.Cmdlets.SqlVirtualMachine.Support.ConnectivityType
Parameter Sets: (All)
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -SqlConnectivityUpdateSettingPort
SQL Server port.

```yaml
Type: System.Int32
Parameter Sets: (All)
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -SqlConnectivityUpdateSettingSqlAuthUpdatePassword
SQL Server sysadmin login password.

```yaml
Type: System.Security.SecureString
Parameter Sets: (All)
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -SqlConnectivityUpdateSettingSqlAuthUpdateUserName
SQL Server sysadmin login to create.

```yaml
Type: System.String
Parameter Sets: (All)
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -SqlDataSettingDefaultFilePath
SQL Server default file path

```yaml
Type: System.String
Parameter Sets: (All)
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -SqlDataSettingLun
Logical Unit Numbers for the disks.

```yaml
Type: System.Int32[]
Parameter Sets: (All)
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -SqlInstanceSettingCollation
SQL Server Collation.

```yaml
Type: System.String
Parameter Sets: (All)
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -SqlInstanceSettingIsIfiEnabled
SQL Server IFI.

```yaml
Type: System.Management.Automation.SwitchParameter
Parameter Sets: (All)
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -SqlInstanceSettingIsLpimEnabled
SQL Server LPIM.

```yaml
Type: System.Management.Automation.SwitchParameter
Parameter Sets: (All)
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -SqlInstanceSettingIsOptimizeForAdHocWorkloadsEnabled
SQL Server Optimize for Adhoc workloads.

```yaml
Type: System.Management.Automation.SwitchParameter
Parameter Sets: (All)
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -SqlInstanceSettingMaxDop
SQL Server MAXDOP.

```yaml
Type: System.Int32
Parameter Sets: (All)
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -SqlInstanceSettingMaxServerMemoryMb
SQL Server maximum memory.

```yaml
Type: System.Int32
Parameter Sets: (All)
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -SqlInstanceSettingMinServerMemoryMb
SQL Server minimum memory.

```yaml
Type: System.Int32
Parameter Sets: (All)
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -SqlLogSettingDefaultFilePath
SQL Server default file path

```yaml
Type: System.String
Parameter Sets: (All)
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -SqlLogSettingLun
Logical Unit Numbers for the disks.

```yaml
Type: System.Int32[]
Parameter Sets: (All)
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -SqlManagementType
SQL Server Management type.

```yaml
Type: Microsoft.Azure.PowerShell.Cmdlets.SqlVirtualMachine.Support.SqlManagementMode
Parameter Sets: (All)
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -SqlStorageUpdateSettingDiskConfigurationType
Disk configuration to apply to SQL Server.

```yaml
Type: Microsoft.Azure.PowerShell.Cmdlets.SqlVirtualMachine.Support.DiskConfigurationType
Parameter Sets: (All)
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -SqlStorageUpdateSettingDiskCount
Virtual machine disk count.

```yaml
Type: System.Int32
Parameter Sets: (All)
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -SqlStorageUpdateSettingStartingDeviceId
Device id of the first disk to be updated.

```yaml
Type: System.Int32
Parameter Sets: (All)
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -SqlTempDbSettingDataFileCount
SQL Server tempdb data file count

```yaml
Type: System.Int32
Parameter Sets: (All)
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -SqlTempDbSettingDataFileSize
SQL Server tempdb data file size

```yaml
Type: System.Int32
Parameter Sets: (All)
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -SqlTempDbSettingDataGrowth
SQL Server tempdb data file autoGrowth size

```yaml
Type: System.Int32
Parameter Sets: (All)
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -SqlTempDbSettingDefaultFilePath
SQL Server default file path

```yaml
Type: System.String
Parameter Sets: (All)
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -SqlTempDbSettingLogFileSize
SQL Server tempdb log file size

```yaml
Type: System.Int32
Parameter Sets: (All)
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -SqlTempDbSettingLogGrowth
SQL Server tempdb log file autoGrowth size

```yaml
Type: System.Int32
Parameter Sets: (All)
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -SqlTempDbSettingLun
Logical Unit Numbers for the disks.

```yaml
Type: System.Int32[]
Parameter Sets: (All)
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -SqlTempDbSettingPersistFolder
SQL Server tempdb persist folder choice

```yaml
Type: System.Management.Automation.SwitchParameter
Parameter Sets: (All)
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -SqlTempDbSettingPersistFolderPath
SQL Server tempdb persist folder location

```yaml
Type: System.String
Parameter Sets: (All)
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -SqlVirtualMachineGroupResourceId
ARM resource id of the SQL virtual machine group this SQL virtual machine is or will be part of.

```yaml
Type: System.String
Parameter Sets: (All)
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -SqlWorkloadTypeUpdateSettingSqlWorkloadType
SQL Server workload type.

```yaml
Type: Microsoft.Azure.PowerShell.Cmdlets.SqlVirtualMachine.Support.SqlWorkloadType
Parameter Sets: (All)
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -StorageConfigurationSettingDiskConfigurationType
Disk configuration to apply to SQL Server.

```yaml
Type: Microsoft.Azure.PowerShell.Cmdlets.SqlVirtualMachine.Support.DiskConfigurationType
Parameter Sets: (All)
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -StorageConfigurationSettingSqlSystemDbOnDataDisk
SQL Server SystemDb Storage on DataPool if true.

```yaml
Type: System.Management.Automation.SwitchParameter
Parameter Sets: (All)
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -StorageConfigurationSettingStorageWorkloadType
Storage workload type.

```yaml
Type: Microsoft.Azure.PowerShell.Cmdlets.SqlVirtualMachine.Support.StorageWorkloadType
Parameter Sets: (All)
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -SubscriptionId
Subscription ID that identifies an Azure subscription.

```yaml
Type: System.String
Parameter Sets: (All)
Aliases:

Required: False
Position: Named
Default value: (Get-AzContext).Subscription.Id
Accept pipeline input: False
Accept wildcard characters: False
```

### -Tag
Resource tags.

```yaml
Type: System.Collections.Hashtable
Parameter Sets: (All)
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -VirtualMachineResourceId
ARM Resource id of underlying virtual machine created from SQL marketplace image.

```yaml
Type: System.String
Parameter Sets: (All)
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -WsfcDomainCredentialsClusterBootstrapAccountPassword
Cluster bootstrap account password.

```yaml
Type: System.Security.SecureString
Parameter Sets: (All)
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -WsfcDomainCredentialsClusterOperatorAccountPassword
Cluster operator account password.

```yaml
Type: System.Security.SecureString
Parameter Sets: (All)
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -WsfcDomainCredentialsSqlServiceAccountPassword
SQL service account password.

```yaml
Type: System.Security.SecureString
Parameter Sets: (All)
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -WsfcStaticIP
Domain credentials for setting up Windows Server Failover Cluster for SQL availability group.

```yaml
Type: System.String
Parameter Sets: (All)
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -Confirm
Prompts you for confirmation before running the cmdlet.

```yaml
Type: System.Management.Automation.SwitchParameter
Parameter Sets: (All)
Aliases: cf

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -WhatIf
Shows what would happen if the cmdlet runs.
The cmdlet is not run.

```yaml
Type: System.Management.Automation.SwitchParameter
Parameter Sets: (All)
Aliases: wi

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### CommonParameters
This cmdlet supports the common parameters: -Debug, -ErrorAction, -ErrorVariable, -InformationAction, -InformationVariable, -OutVariable, -OutBuffer, -PipelineVariable, -Verbose, -WarningAction, and -WarningVariable. For more information, see [about_CommonParameters](http://go.microsoft.com/fwlink/?LinkID=113216).

## INPUTS

## OUTPUTS

### Microsoft.Azure.PowerShell.Cmdlets.SqlVirtualMachine.Models.Api20220801Preview.ISqlVirtualMachine

## NOTES

ALIASES

## RELATED LINKS

