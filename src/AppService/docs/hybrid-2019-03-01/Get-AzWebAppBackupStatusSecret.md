---
external help file:
Module Name: Az.AppService
online version: https://docs.microsoft.com/en-us/powershell/module/az.appservice/get-azwebappbackupstatussecret
schema: 2.0.0
---

# Get-AzWebAppBackupStatusSecret

## SYNOPSIS
Gets status of a web app backup that may be in progress, including secrets associated with the backup, such as the Azure Storage SAS URL.
Also can be used to update the SAS URL for the backup if a new URL is passed in the request body.

## SYNTAX

### ListExpanded (Default)
```
Get-AzWebAppBackupStatusSecret -BackupId <String> -Name <String> -ResourceGroupName <String>
 -SubscriptionId <String[]> [-BackupName <String>] [-BackupScheduleFrequencyInterval <Int32>]
 [-BackupScheduleFrequencyUnit <FrequencyUnit>] [-BackupScheduleKeepAtLeastOneBackup]
 [-BackupScheduleRetentionPeriodInDay <Int32>] [-BackupScheduleStartTime <DateTime>]
 [-Database <IDatabaseBackupSetting[]>] [-Enabled] [-Kind <String>] [-StorageAccountUrl <String>]
 [-DefaultProfile <PSObject>] [-Confirm] [-WhatIf] [<CommonParameters>]
```

### List
```
Get-AzWebAppBackupStatusSecret -BackupId <String> -Name <String> -ResourceGroupName <String>
 -SubscriptionId <String[]> -Request <IBackupRequest> [-DefaultProfile <PSObject>] [-Confirm] [-WhatIf]
 [<CommonParameters>]
```

### ListExpandedSlot
```
Get-AzWebAppBackupStatusSecret -BackupId <String> -Name <String> -ResourceGroupName <String> -Slot <String>
 -SubscriptionId <String[]> [-BackupName <String>] [-BackupScheduleFrequencyInterval <Int32>]
 [-BackupScheduleFrequencyUnit <FrequencyUnit>] [-BackupScheduleKeepAtLeastOneBackup]
 [-BackupScheduleRetentionPeriodInDay <Int32>] [-BackupScheduleStartTime <DateTime>]
 [-Database <IDatabaseBackupSetting[]>] [-Enabled] [-Kind <String>] [-StorageAccountUrl <String>]
 [-DefaultProfile <PSObject>] [-Confirm] [-WhatIf] [<CommonParameters>]
```

### ListSlot
```
Get-AzWebAppBackupStatusSecret -BackupId <String> -Name <String> -ResourceGroupName <String> -Slot <String>
 -SubscriptionId <String[]> -Request <IBackupRequest> [-DefaultProfile <PSObject>] [-Confirm] [-WhatIf]
 [<CommonParameters>]
```

## DESCRIPTION
Gets status of a web app backup that may be in progress, including secrets associated with the backup, such as the Azure Storage SAS URL.
Also can be used to update the SAS URL for the backup if a new URL is passed in the request body.

## EXAMPLES

### Example 1: {{ Add title here }}
```powershell
PS C:\> {{ Add code here }}

{{ Add output here }}
```

{{ Add description here }}

### Example 2: {{ Add title here }}
```powershell
PS C:\> {{ Add code here }}

{{ Add output here }}
```

{{ Add description here }}

## PARAMETERS

### -BackupId
ID of backup.

```yaml
Type: System.String
Parameter Sets: (All)
Aliases:

Required: True
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
Dynamic: False
```

### -BackupName
Name of the backup.

```yaml
Type: System.String
Parameter Sets: ListExpanded, ListExpandedSlot
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
Dynamic: False
```

### -BackupScheduleFrequencyInterval
How often the backup should be executed (e.g.
for weekly backup, this should be set to 7 and FrequencyUnit should be set to Day)

```yaml
Type: System.Int32
Parameter Sets: ListExpanded, ListExpandedSlot
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
Dynamic: False
```

### -BackupScheduleFrequencyUnit
The unit of time for how often the backup should be executed (e.g.
for weekly backup, this should be set to Day and FrequencyInterval should be set to 7)

```yaml
Type: Microsoft.Azure.PowerShell.Cmdlets.AppService.Support.FrequencyUnit
Parameter Sets: ListExpanded, ListExpandedSlot
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
Dynamic: False
```

### -BackupScheduleKeepAtLeastOneBackup
True if the retention policy should always keep at least one backup in the storage account, regardless how old it is; false otherwise.

```yaml
Type: System.Management.Automation.SwitchParameter
Parameter Sets: ListExpanded, ListExpandedSlot
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
Dynamic: False
```

### -BackupScheduleRetentionPeriodInDay
After how many days backups should be deleted.

```yaml
Type: System.Int32
Parameter Sets: ListExpanded, ListExpandedSlot
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
Dynamic: False
```

### -BackupScheduleStartTime
When the schedule should start working.

```yaml
Type: System.DateTime
Parameter Sets: ListExpanded, ListExpandedSlot
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
Dynamic: False
```

### -Database
Databases included in the backup.
To construct, see NOTES section for DATABASE properties and create a hash table.

```yaml
Type: Microsoft.Azure.PowerShell.Cmdlets.AppService.Models.Api20160801.IDatabaseBackupSetting[]
Parameter Sets: ListExpanded, ListExpandedSlot
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
Dynamic: False
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
Dynamic: False
```

### -Enabled
True if the backup schedule is enabled (must be included in that case), false if the backup schedule should be disabled.

```yaml
Type: System.Management.Automation.SwitchParameter
Parameter Sets: ListExpanded, ListExpandedSlot
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
Dynamic: False
```

### -Kind
Kind of resource.

```yaml
Type: System.String
Parameter Sets: ListExpanded, ListExpandedSlot
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
Dynamic: False
```

### -Name
Name of web app.

```yaml
Type: System.String
Parameter Sets: (All)
Aliases:

Required: True
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
Dynamic: False
```

### -Request
Description of a backup which will be performed.
To construct, see NOTES section for REQUEST properties and create a hash table.

```yaml
Type: Microsoft.Azure.PowerShell.Cmdlets.AppService.Models.Api20180201.IBackupRequest
Parameter Sets: List, ListSlot
Aliases:

Required: True
Position: Named
Default value: None
Accept pipeline input: True (ByValue)
Accept wildcard characters: False
Dynamic: False
```

### -ResourceGroupName
Name of the resource group to which the resource belongs.

```yaml
Type: System.String
Parameter Sets: (All)
Aliases:

Required: True
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
Dynamic: False
```

### -Slot
Name of web app slot.
If not specified then will default to production slot.

```yaml
Type: System.String
Parameter Sets: ListExpandedSlot, ListSlot
Aliases:

Required: True
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
Dynamic: False
```

### -StorageAccountUrl
SAS URL to the container.

```yaml
Type: System.String
Parameter Sets: ListExpanded, ListExpandedSlot
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
Dynamic: False
```

### -SubscriptionId
Your Azure subscription ID.
This is a GUID-formatted string (e.g.
00000000-0000-0000-0000-000000000000).

```yaml
Type: System.String[]
Parameter Sets: (All)
Aliases:

Required: True
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
Dynamic: False
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
Dynamic: False
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
Dynamic: False
```

### CommonParameters
This cmdlet supports the common parameters: -Debug, -ErrorAction, -ErrorVariable, -InformationAction, -InformationVariable, -OutVariable, -OutBuffer, -PipelineVariable, -Verbose, -WarningAction, and -WarningVariable. For more information, see [about_CommonParameters](http://go.microsoft.com/fwlink/?LinkID=113216).

## INPUTS

### Microsoft.Azure.PowerShell.Cmdlets.AppService.Models.Api20180201.IBackupRequest

## OUTPUTS

### Microsoft.Azure.PowerShell.Cmdlets.AppService.Models.Api20160801.IBackupItem

## ALIASES

### Get-AzWebAppBackupStatusSecretSlot

## NOTES

### COMPLEX PARAMETER PROPERTIES
To create the parameters described below, construct a hash table containing the appropriate properties. For information on hash tables, run Get-Help about_Hash_Tables.

#### DATABASE <IDatabaseBackupSetting[]>: Databases included in the backup.
  - `DatabaseType <DatabaseType>`: Database type (e.g. SqlAzure / MySql).
  - `[ConnectionString <String>]`: Contains a connection string to a database which is being backed up or restored. If the restore should happen to a new database, the database name inside is the new one.
  - `[ConnectionStringName <String>]`: Contains a connection string name that is linked to the SiteConfig.ConnectionStrings.         This is used during restore with overwrite connection strings options.
  - `[Name <String>]`: 

#### REQUEST <IBackupRequest>: Description of a backup which will be performed.
  - `BackupScheduleFrequencyInterval <Int32>`: How often the backup should be executed (e.g. for weekly backup, this should be set to 7 and FrequencyUnit should be set to Day)
  - `BackupScheduleFrequencyUnit <FrequencyUnit>`: The unit of time for how often the backup should be executed (e.g. for weekly backup, this should be set to Day and FrequencyInterval should be set to 7)
  - `BackupScheduleKeepAtLeastOneBackup <Boolean>`: True if the retention policy should always keep at least one backup in the storage account, regardless how old it is; false otherwise.
  - `BackupScheduleRetentionPeriodInDay <Int32>`: After how many days backups should be deleted.
  - `StorageAccountUrl <String>`: SAS URL to the container.
  - `[Kind <String>]`: Kind of resource.
  - `[BackupName <String>]`: Name of the backup.
  - `[BackupScheduleStartTime <DateTime?>]`: When the schedule should start working.
  - `[Database <IDatabaseBackupSetting[]>]`: Databases included in the backup.
    - `DatabaseType <DatabaseType>`: Database type (e.g. SqlAzure / MySql).
    - `[ConnectionString <String>]`: Contains a connection string to a database which is being backed up or restored. If the restore should happen to a new database, the database name inside is the new one.
    - `[ConnectionStringName <String>]`: Contains a connection string name that is linked to the SiteConfig.ConnectionStrings.         This is used during restore with overwrite connection strings options.
    - `[Name <String>]`: 
  - `[Enabled <Boolean?>]`: True if the backup schedule is enabled (must be included in that case), false if the backup schedule should be disabled.

## RELATED LINKS

