---
external help file:
Module Name: Az.WebSite
online version: https://docs.microsoft.com/en-us/powershell/module/az.website/backup-azwebapp
schema: 2.0.0
---

# Backup-AzWebApp

## SYNOPSIS
Creates a backup of an app.

## SYNTAX

### Backup (Default)
```
Backup-AzWebApp -Name <String> -ResourceGroupName <String> -SubscriptionId <String>
 [-Request <IBackupRequest>] [-DefaultProfile <PSObject>] [-Confirm] [-WhatIf] [<CommonParameters>]
```

### BackupSlot
```
Backup-AzWebApp -Name <String> -ResourceGroupName <String> -SubscriptionId <String> -Slot <String>
 [-Request <IBackupRequest>] [-DefaultProfile <PSObject>] [-Confirm] [-WhatIf] [<CommonParameters>]
```

### BackupExpandedSlot
```
Backup-AzWebApp -Name <String> -ResourceGroupName <String> -SubscriptionId <String> -Slot <String>
 -BackupScheduleFrequencyInterval <Int32> -BackupScheduleFrequencyUnit <FrequencyUnit>
 -BackupScheduleKeepAtLeastOneBackup -BackupScheduleRetentionPeriodInDay <Int32> -StorageAccountUrl <String>
 [-BackupName <String>] [-BackupScheduleStartTime <DateTime>] [-Database <IDatabaseBackupSetting[]>]
 [-Enabled] [-Kind <String>] [-DefaultProfile <PSObject>] [-Confirm] [-WhatIf] [<CommonParameters>]
```

### BackupExpanded
```
Backup-AzWebApp -Name <String> -ResourceGroupName <String> -SubscriptionId <String>
 -BackupScheduleFrequencyInterval <Int32> -BackupScheduleFrequencyUnit <FrequencyUnit>
 -BackupScheduleKeepAtLeastOneBackup -BackupScheduleRetentionPeriodInDay <Int32> -StorageAccountUrl <String>
 [-BackupName <String>] [-BackupScheduleStartTime <DateTime>] [-Database <IDatabaseBackupSetting[]>]
 [-Enabled] [-Kind <String>] [-DefaultProfile <PSObject>] [-Confirm] [-WhatIf] [<CommonParameters>]
```

### BackupBySiteObject
```
Backup-AzWebApp -SubscriptionId <String> -BackupScheduleFrequencyInterval <Int32>
 -BackupScheduleFrequencyUnit <FrequencyUnit> -BackupScheduleKeepAtLeastOneBackup
 -BackupScheduleRetentionPeriodInDay <Int32> -StorageAccountUrl <String> -SiteObject <ISite>
 [-BackupName <String>] [-BackupScheduleStartTime <DateTime>] [-Database <IDatabaseBackupSetting[]>]
 [-Enabled] [-Kind <String>] [-DefaultProfile <PSObject>] [-Confirm] [-WhatIf] [<CommonParameters>]
```

### BackupViaIdentityExpandedSlot
```
Backup-AzWebApp -InputObject <IWebSiteIdentity> -BackupScheduleFrequencyInterval <Int32>
 -BackupScheduleFrequencyUnit <FrequencyUnit> -BackupScheduleKeepAtLeastOneBackup
 -BackupScheduleRetentionPeriodInDay <Int32> -StorageAccountUrl <String> [-BackupName <String>]
 [-BackupScheduleStartTime <DateTime>] [-Database <IDatabaseBackupSetting[]>] [-Enabled] [-Kind <String>]
 [-DefaultProfile <PSObject>] [-Confirm] [-WhatIf] [<CommonParameters>]
```

### BackupViaIdentityExpanded
```
Backup-AzWebApp -InputObject <IWebSiteIdentity> -BackupScheduleFrequencyInterval <Int32>
 -BackupScheduleFrequencyUnit <FrequencyUnit> -BackupScheduleKeepAtLeastOneBackup
 -BackupScheduleRetentionPeriodInDay <Int32> -StorageAccountUrl <String> [-BackupName <String>]
 [-BackupScheduleStartTime <DateTime>] [-Database <IDatabaseBackupSetting[]>] [-Enabled] [-Kind <String>]
 [-DefaultProfile <PSObject>] [-Confirm] [-WhatIf] [<CommonParameters>]
```

### BackupViaIdentity
```
Backup-AzWebApp -InputObject <IWebSiteIdentity> [-Request <IBackupRequest>] [-DefaultProfile <PSObject>]
 [-Confirm] [-WhatIf] [<CommonParameters>]
```

## DESCRIPTION
Creates a backup of an app.

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

### -BackupName
Name of the backup.

```yaml
Type: System.String
Parameter Sets: BackupExpandedSlot, BackupExpanded, BackupBySiteObject, BackupViaIdentityExpandedSlot, BackupViaIdentityExpanded
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
Parameter Sets: BackupExpandedSlot, BackupExpanded, BackupBySiteObject, BackupViaIdentityExpandedSlot, BackupViaIdentityExpanded
Aliases:

Required: False
Position: Named
Default value: 0
Accept pipeline input: False
Accept wildcard characters: False
Dynamic: False
```

### -BackupScheduleFrequencyUnit
The unit of time for how often the backup should be executed (e.g.
for weekly backup, this should be set to Day and FrequencyInterval should be set to 7)

```yaml
Type: Microsoft.Azure.PowerShell.Cmdlets.WebSite.Support.FrequencyUnit
Parameter Sets: BackupExpandedSlot, BackupExpanded, BackupBySiteObject, BackupViaIdentityExpandedSlot, BackupViaIdentityExpanded
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
Parameter Sets: BackupExpandedSlot, BackupExpanded, BackupBySiteObject, BackupViaIdentityExpandedSlot, BackupViaIdentityExpanded
Aliases:

Required: False
Position: Named
Default value: False
Accept pipeline input: False
Accept wildcard characters: False
Dynamic: False
```

### -BackupScheduleRetentionPeriodInDay
After how many days backups should be deleted.

```yaml
Type: System.Int32
Parameter Sets: BackupExpandedSlot, BackupExpanded, BackupBySiteObject, BackupViaIdentityExpandedSlot, BackupViaIdentityExpanded
Aliases:

Required: False
Position: Named
Default value: 0
Accept pipeline input: False
Accept wildcard characters: False
Dynamic: False
```

### -BackupScheduleStartTime
When the schedule should start working.

```yaml
Type: System.DateTime
Parameter Sets: BackupExpandedSlot, BackupExpanded, BackupBySiteObject, BackupViaIdentityExpandedSlot, BackupViaIdentityExpanded
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
Type: Microsoft.Azure.PowerShell.Cmdlets.WebSite.Models.Api20160801.IDatabaseBackupSetting[]
Parameter Sets: BackupExpandedSlot, BackupExpanded, BackupBySiteObject, BackupViaIdentityExpandedSlot, BackupViaIdentityExpanded
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
Parameter Sets: BackupExpandedSlot, BackupExpanded, BackupBySiteObject, BackupViaIdentityExpandedSlot, BackupViaIdentityExpanded
Aliases:

Required: False
Position: Named
Default value: False
Accept pipeline input: False
Accept wildcard characters: False
Dynamic: False
```

### -InputObject
Identity Parameter

```yaml
Type: Microsoft.Azure.PowerShell.Cmdlets.WebSite.Models.IWebSiteIdentity
Parameter Sets: BackupViaIdentityExpandedSlot, BackupViaIdentityExpanded, BackupViaIdentity
Aliases:

Required: True
Position: Named
Default value: None
Accept pipeline input: True (ByValue)
Accept wildcard characters: False
Dynamic: False
```

### -Kind
Kind of resource.

```yaml
Type: System.String
Parameter Sets: BackupExpandedSlot, BackupExpanded, BackupBySiteObject, BackupViaIdentityExpandedSlot, BackupViaIdentityExpanded
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
Dynamic: False
```

### -Name
Name of the app.

```yaml
Type: System.String
Parameter Sets: Backup, BackupSlot, BackupExpandedSlot, BackupExpanded
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
Type: Microsoft.Azure.PowerShell.Cmdlets.WebSite.Models.Api20180201.IBackupRequest
Parameter Sets: Backup, BackupSlot, BackupViaIdentity
Aliases:

Required: False
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
Parameter Sets: Backup, BackupSlot, BackupExpandedSlot, BackupExpanded
Aliases:

Required: True
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
Dynamic: False
```

### -SiteObject
The object representation of the web app or slot.

```yaml
Type: Microsoft.Azure.PowerShell.Cmdlets.WebSite.Models.Api20180201.ISite
Parameter Sets: BackupBySiteObject
Aliases: WebApp, WebAppSlot

Required: True
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
Dynamic: False
```

### -Slot
Name of the deployment slot.
If a slot is not specified, the API will create a backup for the production slot.

```yaml
Type: System.String
Parameter Sets: BackupSlot, BackupExpandedSlot
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
Parameter Sets: BackupExpandedSlot, BackupExpanded, BackupBySiteObject, BackupViaIdentityExpandedSlot, BackupViaIdentityExpanded
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
Type: System.String
Parameter Sets: Backup, BackupSlot, BackupExpandedSlot, BackupExpanded, BackupBySiteObject
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

### Microsoft.Azure.PowerShell.Cmdlets.WebSite.Models.IWebSiteIdentity

### Microsoft.Azure.PowerShell.Cmdlets.WebSite.Models.Api20180201.IBackupRequest

## OUTPUTS

### Microsoft.Azure.PowerShell.Cmdlets.WebSite.Models.Api20160801.IBackupItem

## ALIASES

### Backup-AzWebAppSlot

### New-AzWebAppBackup

### New-AzWebAppSlotBackup

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

