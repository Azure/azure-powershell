---
external help file:
Module Name: Az.SqlVirtualMachine
online version: https://learn.microsoft.com/powershell/module/az.sqlvirtualmachine/update-azsqlvm
schema: 2.0.0
---

# Update-AzSqlVM

## SYNOPSIS
Updates a SQL virtual machine.

## SYNTAX

### UpdateExpanded (Default)
```
Update-AzSqlVM -Name <String> -ResourceGroupName <String> [-SubscriptionId <String>]
 [-AssessmentSettingEnable] [-AssessmentSettingRunImmediately]
 [-AutoBackupSettingBackupScheduleType <BackupScheduleType>] [-AutoBackupSettingBackupSystemDb]
 [-AutoBackupSettingDaysOfWeek <AutoBackupDaysOfWeek[]>] [-AutoBackupSettingEnable]
 [-AutoBackupSettingEnableEncryption] [-AutoBackupSettingFullBackupFrequency <FullBackupFrequencyType>]
 [-AutoBackupSettingFullBackupStartTime <Int32>] [-AutoBackupSettingFullBackupWindowHour <Int32>]
 [-AutoBackupSettingLogBackupFrequency <Int32>] [-AutoBackupSettingPassword <SecureString>]
 [-AutoBackupSettingRetentionPeriod <Int32>] [-AutoBackupSettingStorageAccessKey <String>]
 [-AutoBackupSettingStorageAccountUrl <String>] [-AutoBackupSettingStorageContainerName <String>]
 [-AutoPatchingSettingDayOfWeek <DayOfWeek>] [-AutoPatchingSettingEnable]
 [-AutoPatchingSettingMaintenanceWindowDuration <Int32>]
 [-AutoPatchingSettingMaintenanceWindowStartingHour <Int32>] [-EnableAutomaticUpgrade]
 [-LicenseType <SqlServerLicenseType>] [-Offer <String>] [-ScheduleDayOfWeek <AssessmentDayOfWeek>]
 [-ScheduleEnable] [-ScheduleMonthlyOccurrence <Int32>] [-ScheduleStartTime <String>]
 [-ScheduleWeeklyInterval <Int32>] [-Sku <SqlImageSku>] [-SqlManagementType <SqlManagementMode>]
 [-SqlVirtualMachineGroupResourceId <String>] [-Tag <Hashtable>] [-VirtualMachineResourceId <String>]
 [-WsfcDomainCredentialsClusterBootstrapAccountPassword <SecureString>]
 [-WsfcDomainCredentialsClusterOperatorAccountPassword <SecureString>]
 [-WsfcDomainCredentialsSqlServiceAccountPassword <SecureString>] [-WsfcStaticIP <String>]
 [-DefaultProfile <PSObject>] [-AsJob] [-NoWait] [-Confirm] [-WhatIf] [<CommonParameters>]
```

### UpdateViaIdentity
```
Update-AzSqlVM -InputObject <ISqlVirtualMachineIdentity> [-AssessmentSettingEnable]
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
 [-AutoPatchingSettingMaintenanceWindowStartingHour <Int32>] [-EnableAutomaticUpgrade]
 [-LicenseType <SqlServerLicenseType>] [-Offer <String>] [-ScheduleDayOfWeek <AssessmentDayOfWeek>]
 [-ScheduleEnable] [-ScheduleMonthlyOccurrence <Int32>] [-ScheduleStartTime <String>]
 [-ScheduleWeeklyInterval <Int32>] [-Sku <SqlImageSku>] [-SqlManagementType <SqlManagementMode>]
 [-SqlVirtualMachineGroupResourceId <String>] [-Tag <Hashtable>] [-VirtualMachineResourceId <String>]
 [-WsfcDomainCredentialsClusterBootstrapAccountPassword <SecureString>]
 [-WsfcDomainCredentialsClusterOperatorAccountPassword <SecureString>]
 [-WsfcDomainCredentialsSqlServiceAccountPassword <SecureString>] [-WsfcStaticIP <String>]
 [-DefaultProfile <PSObject>] [-AsJob] [-NoWait] [-Confirm] [-WhatIf] [<CommonParameters>]
```

## DESCRIPTION
Updates a SQL virtual machine.

## EXAMPLES

### Example 1
```powershell
Update-AzSqlVM -ResourceGroupName 'ResourceGroup01' -Name 'sqlvm1' -LicenseType 'AHUB' -Tag @{'newkey'='newvalue'}
```

```output
Location	Name		ResourceGroupName
--------	----		-----------------
eastus		sqlvm1		ResourceGroup01	
```

Update a SQL virtual machine with AHUB billing and add a tag.

### Example 2
```powershell
$sqlVM = Get-AzSqlVM -ResourceGroupName 'ResourceGroup01' -Name 'sqlvm1'
$sqlVM | Update-AzSqlVM -Sku 'Standard' -LicenseType 'AHUB'
```

```output
Location	Name		ResourceGroupName
--------	----		-----------------
eastus		sqlvm1		ResourceGroup01	
```

Update a SQL virtual machine's sku and license type via identity.

### Example 3
```powershell
Update-AzSqlVM -ResourceGroupName 'ResourceGroup01' -Name 'sqlvm1' -AutoBackupSettingEnable `
-AutoBackupSettingBackupScheduleType manual -AutoBackupSettingFullBackupFrequency Weekly -AutoBackupSettingFullBackupStartTime 5 `
-AutoBackupSettingFullBackupWindowHour 2 -AutoBackupSettingStorageAccessKey 'keyvalue' -AutoBackupSettingStorageAccountUrl `
'https://storagename.blob.core.windows.net/' -AutoBackupSettingRetentionPeriod 10 -AutoBackupSettingLogBackupFrequency 60 `
-AutoBackupSettingStorageContainerName 'storagecontainername'
```

```output
Location	Name		ResourceGroupName
--------	----		-----------------
eastus		sqlvm1		ResourceGroup01	
```

Update a SQL virtual machine to enable auto backup.

### Example 4
```powershell
Update-AzSqlVM -ResourceGroupName 'ResourceGroup01' -Name 'sqlvm1' -AutoBackupSettingEnable:$false
```

```output
Location	Name		ResourceGroupName
--------	----		-----------------
eastus		sqlvm1		ResourceGroup01	
```

Update a SQL virtual machine to disable auto backup.

### Example 5
```powershell
Update-AzSqlVM -ResourceGroupName 'ResourceGroup01' -Name 'sqlvm1' `
-AutoPatchingSettingDayOfWeek Thursday `
-AutoPatchingSettingMaintenanceWindowDuration 120 -AutoPatchingSettingMaintenanceWindowStartingHour 3 -AutoPatchingSettingEnable
```

```output
Location	Name		ResourceGroupName
--------	----		-----------------
eastus		sqlvm1		ResourceGroup01	
```

Update a SQL virtual machine to enable auto patching.

### Example 6
```powershell
Update-AzSqlVM -ResourceGroupName 'ResourceGroup01' -Name 'sqlvm1' -AutoPatchingSettingEnable:$false
```

```output
Location	Name		ResourceGroupName
--------	----		-----------------
eastus		sqlvm1		ResourceGroup01	
```

Update a SQL virtual machine to disable auto patching.

### Example 7
```powershell
Update-AzSqlVM -ResourceGroupName 'ResourceGroup01' -Name 'sqlvm1' -AssessmentSettingEnable
```

```output
Location	Name		ResourceGroupName
--------	----		-----------------
eastus		sqlvm1		ResourceGroup01	
```

Update a SQL virtual machine to enable assessment.

### Example 8
```powershell
# $pwd is the password for cluster accounts
$securepwd = ConvertTo-SecureString -String $pwd -AsPlainText -Force
Update-AzSqlVM -ResourceGroupName 'ResourceGroup01' -Name 'sqlvm1' `
-SqlVirtualMachineGroupResourceId '<group resource id>' `
-WsfcDomainCredentialsClusterBootstrapAccountPassword $securepwd `
-WsfcDomainCredentialsClusterOperatorAccountPassword $securepwd `
-WsfcDomainCredentialsSqlServiceAccountPassword $securepwd 
```

```output
Location	Name		ResourceGroupName
--------	----		-----------------
eastus		sqlvm1		ResourceGroup01	
```

Update a SQL virtual machine to add it to a SQL VM group.

### Example 9
```powershell
Update-AzSqlVM -ResourceGroupName 'ResourceGroup01' -Name 'sqlvm1' -SqlVirtualMachineGroupResourceId ''
```

```output
Location	Name		ResourceGroupName
--------	----		-----------------
eastus		sqlvm1		ResourceGroup01	
```

Update a SQL virtual machine to remove it from a SQL VM group.

### Example 10
```powershell
Update-AzSqlVM -ResourceGroupName 'ResourceGroup01' -Name 'sqlvm1'  -Tag @{'newkey'='newvalue'} -AsJob
```

```output
Location	Name		ResourceGroupName
--------	----		-----------------
eastus		sqlvm1		ResourceGroup01	
```

Update a SQL virtual machine's tag as a background job.

## PARAMETERS

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

### -InputObject
Identity Parameter
To construct, see NOTES section for INPUTOBJECT properties and create a hash table.

```yaml
Type: Microsoft.Azure.PowerShell.Cmdlets.SqlVirtualMachine.Models.ISqlVirtualMachineIdentity
Parameter Sets: UpdateViaIdentity
Aliases:

Required: True
Position: Named
Default value: None
Accept pipeline input: True (ByValue)
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

### -Name
Name of the SQL virtual machine.

```yaml
Type: System.String
Parameter Sets: UpdateExpanded
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
Parameter Sets: UpdateExpanded
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

### -SubscriptionId
Subscription ID that identifies an Azure subscription.

```yaml
Type: System.String
Parameter Sets: UpdateExpanded
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

### Microsoft.Azure.PowerShell.Cmdlets.SqlVirtualMachine.Models.ISqlVirtualMachineIdentity

## OUTPUTS

### Microsoft.Azure.PowerShell.Cmdlets.SqlVirtualMachine.Models.Api20220801Preview.ISqlVirtualMachine

## NOTES

## RELATED LINKS

