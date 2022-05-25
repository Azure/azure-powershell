---
external help file:
Module Name: Az.SqlVirtualMachine
online version: https://docs.microsoft.com/en-us/powershell/module/az.sqlvirtualmachine/new-azsqlvirtualmachinesqlvirtualmachine
schema: 2.0.0
---

# New-AzSqlVirtualMachineSqlVirtualMachine

## SYNOPSIS
Creates or updates a SQL virtual machine.

## SYNTAX

```
New-AzSqlVirtualMachineSqlVirtualMachine -Name <String> -ResourceGroupName <String> -Location <String>
 [-SubscriptionId <String>] [-AdditionalFeatureServerConfigurationIsRServicesEnabled]
 [-AssessmentSettingEnable] [-AssessmentSettingRunImmediately]
 [-AutoBackupSettingBackupScheduleType <BackupScheduleType>] [-AutoBackupSettingBackupSystemDb]
 [-AutoBackupSettingDaysOfWeek <AutoBackupDaysOfWeek[]>] [-AutoBackupSettingEnable]
 [-AutoBackupSettingEnableEncryption] [-AutoBackupSettingFullBackupFrequency <FullBackupFrequencyType>]
 [-AutoBackupSettingFullBackupStartTime <Int32>] [-AutoBackupSettingFullBackupWindowHour <Int32>]
 [-AutoBackupSettingLogBackupFrequency <Int32>] [-AutoBackupSettingPassword <String>]
 [-AutoBackupSettingRetentionPeriod <Int32>] [-AutoBackupSettingStorageAccessKey <String>]
 [-AutoBackupSettingStorageAccountUrl <String>] [-AutoBackupSettingStorageContainerName <String>]
 [-AutoPatchingSettingDayOfWeek <DayOfWeek>] [-AutoPatchingSettingEnable]
 [-AutoPatchingSettingMaintenanceWindowDuration <Int32>]
 [-AutoPatchingSettingMaintenanceWindowStartingHour <Int32>] [-IdentityType <IdentityType>]
 [-KeyVaultCredentialSettingAzureKeyVaultUrl <String>] [-KeyVaultCredentialSettingCredentialName <String>]
 [-KeyVaultCredentialSettingEnable] [-KeyVaultCredentialSettingServicePrincipalName <String>]
 [-KeyVaultCredentialSettingServicePrincipalSecret <String>] [-ScheduleDayOfWeek <AssessmentDayOfWeek>]
 [-ScheduleEnable] [-ScheduleMonthlyOccurrence <Int32>] [-ScheduleStartTime <String>]
 [-ScheduleWeeklyInterval <Int32>] [-SqlConnectivityUpdateSettingConnectivityType <ConnectivityType>]
 [-SqlConnectivityUpdateSettingPort <Int32>] [-SqlConnectivityUpdateSettingSqlAuthUpdatePassword <String>]
 [-SqlConnectivityUpdateSettingSqlAuthUpdateUserName <String>] [-SqlDataSettingDefaultFilePath <String>]
 [-SqlDataSettingLun <Int32[]>] [-SqlImageOffer <String>] [-SqlImageSku <SqlImageSku>]
 [-SqlInstanceSettingCollation <String>] [-SqlInstanceSettingIsOptimizeForAdHocWorkloadsEnabled]
 [-SqlInstanceSettingMaxDop <Int32>] [-SqlInstanceSettingMaxServerMemoryMb <Int32>]
 [-SqlInstanceSettingMinServerMemoryMb <Int32>] [-SqlLogSettingDefaultFilePath <String>]
 [-SqlLogSettingLun <Int32[]>] [-SqlManagement <SqlManagementMode>]
 [-SqlServerLicenseType <SqlServerLicenseType>]
 [-SqlStorageUpdateSettingDiskConfigurationType <DiskConfigurationType>]
 [-SqlStorageUpdateSettingDiskCount <Int32>] [-SqlStorageUpdateSettingStartingDeviceId <Int32>]
 [-SqlTempDbSettingDataFileCount <Int32>] [-SqlTempDbSettingDataFileSize <Int32>]
 [-SqlTempDbSettingDataGrowth <Int32>] [-SqlTempDbSettingDefaultFilePath <String>]
 [-SqlTempDbSettingLogFileSize <Int32>] [-SqlTempDbSettingLogGrowth <Int32>] [-SqlTempDbSettingLun <Int32[]>]
 [-SqlVirtualMachineGroupResourceId <String>] [-SqlWorkloadTypeUpdateSettingSqlWorkloadType <SqlWorkloadType>]
 [-StorageConfigurationSettingDiskConfigurationType <DiskConfigurationType>]
 [-StorageConfigurationSettingSqlSystemDbOnDataDisk]
 [-StorageConfigurationSettingStorageWorkloadType <StorageWorkloadType>] [-Tag <Hashtable>]
 [-VirtualMachineResourceId <String>] [-WsfcDomainCredentialsClusterBootstrapAccountPassword <String>]
 [-WsfcDomainCredentialsClusterOperatorAccountPassword <String>]
 [-WsfcDomainCredentialsSqlServiceAccountPassword <String>] [-DefaultProfile <PSObject>] [-AsJob] [-NoWait]
 [-PassThru] [-Confirm] [-WhatIf] [<CommonParameters>]
```

## DESCRIPTION
Creates or updates a SQL virtual machine.

## EXAMPLES

### Example 1: {{ Add title here }}
```powershell
{{ Add code here }}
```

```output
{{ Add output here }}
```

{{ Add description here }}

### Example 2: {{ Add title here }}
```powershell
{{ Add code here }}
```

```output
{{ Add output here }}
```

{{ Add description here }}

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
Enable or disable assessment feature on SQL virtual machine.

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
Run assessment immediately on SQL virtual machine.

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
Type: System.String
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
Aliases: SqlVirtualMachineName

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

### -PassThru
Returns true when the command succeeds

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
Type: System.String
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

### -SqlImageOffer
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

### -SqlImageSku
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

### -SqlManagement
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

### -SqlServerLicenseType
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
SQL Server default file count

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
SQL Server default file size

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
SQL Server default file autoGrowth size

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
SQL Server default file size

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
SQL Server default file autoGrowth size

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
Type: System.String
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
Type: System.String
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

### Microsoft.Azure.PowerShell.Cmdlets.SqlVirtualMachine.Models.Api20211101Preview.ISqlVirtualMachine

## NOTES

ALIASES

## RELATED LINKS

