---
external help file:
Module Name: Az.AppService
online version: https://docs.microsoft.com/en-us/powershell/module/az.appservice/backup-azwebapp
schema: 2.0.0
---

# Backup-AzWebApp

## SYNOPSIS
Creates a backup of an app.

## SYNTAX

### BackupExpanded (Default)
```
Backup-AzWebApp -Name <String> -ResourceGroupName <String> -SubscriptionId <String> [-BackupName <String>]
 [-BackupScheduleFrequencyInterval <Int32>] [-BackupScheduleFrequencyUnit <FrequencyUnit>]
 [-BackupScheduleKeepAtLeastOneBackup] [-BackupScheduleRetentionPeriodInDay <Int32>]
 [-BackupScheduleStartTime <DateTime>] [-Database <IDatabaseBackupSetting[]>] [-Enabled] [-Kind <String>]
 [-StorageAccountUrl <String>] [-DefaultProfile <PSObject>] [-Confirm] [-WhatIf] [<CommonParameters>]
```

### Backup
```
Backup-AzWebApp -Name <String> -ResourceGroupName <String> -SubscriptionId <String> -Request <IBackupRequest>
 [-DefaultProfile <PSObject>] [-Confirm] [-WhatIf] [<CommonParameters>]
```

### BackupExpandedSlot
```
Backup-AzWebApp -Name <String> -ResourceGroupName <String> -Slot <String> -SubscriptionId <String>
 [-BackupName <String>] [-BackupScheduleFrequencyInterval <Int32>]
 [-BackupScheduleFrequencyUnit <FrequencyUnit>] [-BackupScheduleKeepAtLeastOneBackup]
 [-BackupScheduleRetentionPeriodInDay <Int32>] [-BackupScheduleStartTime <DateTime>]
 [-Database <IDatabaseBackupSetting[]>] [-Enabled] [-Kind <String>] [-StorageAccountUrl <String>]
 [-DefaultProfile <PSObject>] [-Confirm] [-WhatIf] [<CommonParameters>]
```

### BackupSlot
```
Backup-AzWebApp -Name <String> -ResourceGroupName <String> -Slot <String> -SubscriptionId <String>
 -Request <IBackupRequest> [-DefaultProfile <PSObject>] [-Confirm] [-WhatIf] [<CommonParameters>]
```

### BackupViaIdentity
```
Backup-AzWebApp -InputObject <IAppServiceIdentity> -Request <IBackupRequest> [-DefaultProfile <PSObject>]
 [-Confirm] [-WhatIf] [<CommonParameters>]
```

### BackupViaIdentityExpanded
```
Backup-AzWebApp -InputObject <IAppServiceIdentity> [-BackupName <String>]
 [-BackupScheduleFrequencyInterval <Int32>] [-BackupScheduleFrequencyUnit <FrequencyUnit>]
 [-BackupScheduleKeepAtLeastOneBackup] [-BackupScheduleRetentionPeriodInDay <Int32>]
 [-BackupScheduleStartTime <DateTime>] [-Database <IDatabaseBackupSetting[]>] [-Enabled] [-Kind <String>]
 [-StorageAccountUrl <String>] [-DefaultProfile <PSObject>] [-Confirm] [-WhatIf] [<CommonParameters>]
```

### BackupViaIdentityExpandedSlot
```
Backup-AzWebApp -InputObject <IAppServiceIdentity> [-BackupName <String>]
 [-BackupScheduleFrequencyInterval <Int32>] [-BackupScheduleFrequencyUnit <FrequencyUnit>]
 [-BackupScheduleKeepAtLeastOneBackup] [-BackupScheduleRetentionPeriodInDay <Int32>]
 [-BackupScheduleStartTime <DateTime>] [-Database <IDatabaseBackupSetting[]>] [-Enabled] [-Kind <String>]
 [-StorageAccountUrl <String>] [-DefaultProfile <PSObject>] [-Confirm] [-WhatIf] [<CommonParameters>]
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
Parameter Sets: BackupExpanded, BackupExpandedSlot, BackupViaIdentityExpanded, BackupViaIdentityExpandedSlot
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
Parameter Sets: BackupExpanded, BackupExpandedSlot, BackupViaIdentityExpanded, BackupViaIdentityExpandedSlot
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
Parameter Sets: BackupExpanded, BackupExpandedSlot, BackupViaIdentityExpanded, BackupViaIdentityExpandedSlot
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
Parameter Sets: BackupExpanded, BackupExpandedSlot, BackupViaIdentityExpanded, BackupViaIdentityExpandedSlot
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
Parameter Sets: BackupExpanded, BackupExpandedSlot, BackupViaIdentityExpanded, BackupViaIdentityExpandedSlot
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
Parameter Sets: BackupExpanded, BackupExpandedSlot, BackupViaIdentityExpanded, BackupViaIdentityExpandedSlot
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
Parameter Sets: BackupExpanded, BackupExpandedSlot, BackupViaIdentityExpanded, BackupViaIdentityExpandedSlot
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
Parameter Sets: BackupExpanded, BackupExpandedSlot, BackupViaIdentityExpanded, BackupViaIdentityExpandedSlot
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
Dynamic: False
```

### -InputObject
Identity Parameter
To construct, see NOTES section for INPUTOBJECT properties and create a hash table.

```yaml
Type: Microsoft.Azure.PowerShell.Cmdlets.AppService.Models.IAppServiceIdentity
Parameter Sets: BackupViaIdentity, BackupViaIdentityExpanded, BackupViaIdentityExpandedSlot
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
Parameter Sets: BackupExpanded, BackupExpandedSlot, BackupViaIdentityExpanded, BackupViaIdentityExpandedSlot
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
Parameter Sets: Backup, BackupExpanded, BackupExpandedSlot, BackupSlot
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
Parameter Sets: Backup, BackupSlot, BackupViaIdentity
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
Parameter Sets: Backup, BackupExpanded, BackupExpandedSlot, BackupSlot
Aliases:

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
Parameter Sets: BackupExpandedSlot, BackupSlot
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
Parameter Sets: BackupExpanded, BackupExpandedSlot, BackupViaIdentityExpanded, BackupViaIdentityExpandedSlot
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
Parameter Sets: Backup, BackupExpanded, BackupExpandedSlot, BackupSlot
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

### Microsoft.Azure.PowerShell.Cmdlets.AppService.Models.IAppServiceIdentity

## OUTPUTS

### Microsoft.Azure.PowerShell.Cmdlets.AppService.Models.Api20160801.IBackupItem

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

#### INPUTOBJECT <IAppServiceIdentity>: Identity Parameter
  - `[AnalysisName <String>]`: Analysis Name
  - `[ApiName <String>]`: The managed API name.
  - `[BackupId <String>]`: ID of the backup.
  - `[BaseAddress <String>]`: Module base address.
  - `[CertificateOrderName <String>]`: Name of the certificate order.
  - `[ConnectionName <String>]`: The connection name.
  - `[DeletedSiteId <String>]`: The numeric ID of the deleted app, e.g. 12345
  - `[DetectorName <String>]`: Detector Resource Name
  - `[DiagnosticCategory <String>]`: Diagnostic Category
  - `[DiagnosticsName <String>]`: Name of the diagnostics item.
  - `[DomainName <String>]`: Name of the domain.
  - `[DomainOwnershipIdentifierName <String>]`: Name of domain ownership identifier.
  - `[EntityName <String>]`: Name of the hybrid connection.
  - `[FunctionName <String>]`: Function name.
  - `[GatewayName <String>]`: Name of the gateway. Only the 'primary' gateway is supported.
  - `[HostName <String>]`: Hostname in the hostname binding.
  - `[HostingEnvironmentName <String>]`: Name of the hosting environment.
  - `[Id <String>]`: Resource identity path
  - `[Instance <String>]`: Name of the instance in the multi-role pool.
  - `[InstanceId <String>]`: ID of web app instance.
  - `[Location <String>]`: 
  - `[Name <String>]`: Name of the certificate.
  - `[NamespaceName <String>]`: Name of the Service Bus namespace.
  - `[OperationId <String>]`: GUID of the operation.
  - `[PremierAddOnName <String>]`: Add-on name.
  - `[ProcessId <String>]`: PID.
  - `[PublicCertificateName <String>]`: Public certificate name.
  - `[RelayName <String>]`: Name of the Service Bus relay.
  - `[ResourceGroupName <String>]`: Name of the resource group to which the resource belongs.
  - `[RouteName <String>]`: Name of the Virtual Network route.
  - `[SiteExtensionId <String>]`: Site extension name.
  - `[SiteName <String>]`: Site Name
  - `[Slot <String>]`: Name of web app slot. If not specified then will default to production slot.
  - `[SnapshotId <String>]`: The ID of the snapshot to read.
  - `[SourceControlType <String>]`: Type of source control
  - `[SubscriptionId <String>]`: Your Azure subscription ID. This is a GUID-formatted string (e.g. 00000000-0000-0000-0000-000000000000).
  - `[ThreadId <String>]`: TID.
  - `[View <String>]`: The type of view. This can either be "summary" or "detailed".
  - `[VnetName <String>]`: Name of the Virtual Network.
  - `[WebJobName <String>]`: Name of Web Job.
  - `[WorkerName <String>]`: Name of worker machine, which typically starts with RD.
  - `[WorkerPoolName <String>]`: Name of the worker pool.

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

