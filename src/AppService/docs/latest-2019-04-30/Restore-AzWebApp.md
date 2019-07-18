---
external help file:
Module Name: Az.WebSite
online version: https://docs.microsoft.com/en-us/powershell/module/az.website/restore-azwebapp
schema: 2.0.0
---

# Restore-AzWebApp

## SYNOPSIS
Recovers a web app to a previous snapshot.

## SYNTAX

### Recover (Default)
```
Restore-AzWebApp -Name <String> -ResourceGroupName <String> -SubscriptionId <String> [-PassThru]
 [-RecoveryEntity <ISnapshotRecoveryRequest>] [-DefaultProfile <PSObject>] [-AsJob] [-NoWait] [-Confirm]
 [-WhatIf] [<CommonParameters>]
```

### RestoreSlot
```
Restore-AzWebApp -Name <String> -ResourceGroupName <String> -SubscriptionId <String> -Slot <String>
 -BackupId <String> [-PassThru] [-Request <IRestoreRequest>] [-DefaultProfile <PSObject>] [-AsJob] [-NoWait]
 [-Confirm] [-WhatIf] [<CommonParameters>]
```

### RestoreExpandedSlot
```
Restore-AzWebApp -Name <String> -ResourceGroupName <String> -SubscriptionId <String> -Slot <String>
 -BackupId <String> [-PassThru] [-IgnoreConflictingHostName] [-Kind <String>] [-Overwrite]
 [-AdjustConnectionString] [-AppServicePlan <String>] [-BlobName <String>]
 [-Database <IDatabaseBackupSetting[]>] [-HostingEnvironment <String>] [-IgnoreDatabase]
 [-OperationType <BackupRestoreOperationType>] [-SiteName <String>] [-StorageAccountUrl <String>]
 [-DefaultProfile <PSObject>] [-AsJob] [-NoWait] [-Confirm] [-WhatIf] [<CommonParameters>]
```

### RestoreExpanded
```
Restore-AzWebApp -Name <String> -ResourceGroupName <String> -SubscriptionId <String> -BackupId <String>
 [-PassThru] [-IgnoreConflictingHostName] [-Kind <String>] [-Overwrite] [-AdjustConnectionString]
 [-AppServicePlan <String>] [-BlobName <String>] [-Database <IDatabaseBackupSetting[]>]
 [-HostingEnvironment <String>] [-IgnoreDatabase] [-OperationType <BackupRestoreOperationType>]
 [-SiteName <String>] [-StorageAccountUrl <String>] [-DefaultProfile <PSObject>] [-AsJob] [-NoWait] [-Confirm]
 [-WhatIf] [<CommonParameters>]
```

### Restore
```
Restore-AzWebApp -Name <String> -ResourceGroupName <String> -SubscriptionId <String> -BackupId <String>
 [-PassThru] [-Request <IRestoreRequest>] [-DefaultProfile <PSObject>] [-AsJob] [-NoWait] [-Confirm] [-WhatIf]
 [<CommonParameters>]
```

### RecoverSlot
```
Restore-AzWebApp -Name <String> -ResourceGroupName <String> -SubscriptionId <String> -Slot <String>
 [-PassThru] [-RecoveryEntity <ISnapshotRecoveryRequest>] [-DefaultProfile <PSObject>] [-AsJob] [-NoWait]
 [-Confirm] [-WhatIf] [<CommonParameters>]
```

### RecoverExpandedSlot
```
Restore-AzWebApp -Name <String> -ResourceGroupName <String> -SubscriptionId <String> -Slot <String>
 [-PassThru] [-IgnoreConflictingHostName] [-Kind <String>] [-Overwrite] [-RecoverConfiguration]
 [-RecoveryTargetId <String>] [-RecoveryTargetLocation <String>] [-SnapshotTime <String>]
 [-DefaultProfile <PSObject>] [-AsJob] [-NoWait] [-Confirm] [-WhatIf] [<CommonParameters>]
```

### RecoverExpanded
```
Restore-AzWebApp -Name <String> -ResourceGroupName <String> -SubscriptionId <String> [-PassThru]
 [-IgnoreConflictingHostName] [-Kind <String>] [-Overwrite] [-RecoverConfiguration]
 [-RecoveryTargetId <String>] [-RecoveryTargetLocation <String>] [-SnapshotTime <String>]
 [-DefaultProfile <PSObject>] [-AsJob] [-NoWait] [-Confirm] [-WhatIf] [<CommonParameters>]
```

### RestoreViaIdentityExpandedSlot
```
Restore-AzWebApp -InputObject <IWebSiteIdentity> [-PassThru] [-IgnoreConflictingHostName] [-Kind <String>]
 [-Overwrite] [-AdjustConnectionString] [-AppServicePlan <String>] [-BlobName <String>]
 [-Database <IDatabaseBackupSetting[]>] [-HostingEnvironment <String>] [-IgnoreDatabase]
 [-OperationType <BackupRestoreOperationType>] [-SiteName <String>] [-StorageAccountUrl <String>]
 [-DefaultProfile <PSObject>] [-AsJob] [-NoWait] [-Confirm] [-WhatIf] [<CommonParameters>]
```

### RestoreViaIdentityExpanded
```
Restore-AzWebApp -InputObject <IWebSiteIdentity> [-PassThru] [-IgnoreConflictingHostName] [-Kind <String>]
 [-Overwrite] [-AdjustConnectionString] [-AppServicePlan <String>] [-BlobName <String>]
 [-Database <IDatabaseBackupSetting[]>] [-HostingEnvironment <String>] [-IgnoreDatabase]
 [-OperationType <BackupRestoreOperationType>] [-SiteName <String>] [-StorageAccountUrl <String>]
 [-DefaultProfile <PSObject>] [-AsJob] [-NoWait] [-Confirm] [-WhatIf] [<CommonParameters>]
```

### RestoreViaIdentity
```
Restore-AzWebApp -InputObject <IWebSiteIdentity> [-PassThru] [-Request <IRestoreRequest>]
 [-DefaultProfile <PSObject>] [-AsJob] [-NoWait] [-Confirm] [-WhatIf] [<CommonParameters>]
```

### RecoverViaIdentityExpandedSlot
```
Restore-AzWebApp -InputObject <IWebSiteIdentity> [-PassThru] [-IgnoreConflictingHostName] [-Kind <String>]
 [-Overwrite] [-RecoverConfiguration] [-RecoveryTargetId <String>] [-RecoveryTargetLocation <String>]
 [-SnapshotTime <String>] [-DefaultProfile <PSObject>] [-AsJob] [-NoWait] [-Confirm] [-WhatIf]
 [<CommonParameters>]
```

### RecoverViaIdentityExpanded
```
Restore-AzWebApp -InputObject <IWebSiteIdentity> [-PassThru] [-IgnoreConflictingHostName] [-Kind <String>]
 [-Overwrite] [-RecoverConfiguration] [-RecoveryTargetId <String>] [-RecoveryTargetLocation <String>]
 [-SnapshotTime <String>] [-DefaultProfile <PSObject>] [-AsJob] [-NoWait] [-Confirm] [-WhatIf]
 [<CommonParameters>]
```

### RecoverViaIdentity
```
Restore-AzWebApp -InputObject <IWebSiteIdentity> [-PassThru] [-RecoveryEntity <ISnapshotRecoveryRequest>]
 [-DefaultProfile <PSObject>] [-AsJob] [-NoWait] [-Confirm] [-WhatIf] [<CommonParameters>]
```

## DESCRIPTION
Recovers a web app to a previous snapshot.

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

### -AdjustConnectionString
<code>true</code> if SiteConfig.ConnectionStrings should be set in new app; otherwise, <code>false</code>.

```yaml
Type: System.Management.Automation.SwitchParameter
Parameter Sets: RestoreExpandedSlot, RestoreExpanded, RestoreViaIdentityExpandedSlot, RestoreViaIdentityExpanded
Aliases:

Required: False
Position: Named
Default value: False
Accept pipeline input: False
Accept wildcard characters: False
Dynamic: False
```

### -AppServicePlan
Specify app service plan that will own restored site.

```yaml
Type: System.String
Parameter Sets: RestoreExpandedSlot, RestoreExpanded, RestoreViaIdentityExpandedSlot, RestoreViaIdentityExpanded
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
Dynamic: False
```

### -AsJob
Run the command as a job

```yaml
Type: System.Management.Automation.SwitchParameter
Parameter Sets: (All)
Aliases:

Required: False
Position: Named
Default value: False
Accept pipeline input: False
Accept wildcard characters: False
Dynamic: False
```

### -BackupId
ID of the backup.

```yaml
Type: System.String
Parameter Sets: RestoreSlot, RestoreExpandedSlot, RestoreExpanded, Restore
Aliases:

Required: True
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
Dynamic: False
```

### -BlobName
Name of a blob which contains the backup.

```yaml
Type: System.String
Parameter Sets: RestoreExpandedSlot, RestoreExpanded, RestoreViaIdentityExpandedSlot, RestoreViaIdentityExpanded
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
Dynamic: False
```

### -Database
Collection of databases which should be restored.
This list has to match the list of databases included in the backup.
To construct, see NOTES section for DATABASE properties and create a hash table.

```yaml
Type: Microsoft.Azure.PowerShell.Cmdlets.WebSite.Models.Api20160801.IDatabaseBackupSetting[]
Parameter Sets: RestoreExpandedSlot, RestoreExpanded, RestoreViaIdentityExpandedSlot, RestoreViaIdentityExpanded
Aliases: Databases

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

### -HostingEnvironment
App Service Environment name, if needed (only when restoring an app to an App Service Environment).

```yaml
Type: System.String
Parameter Sets: RestoreExpandedSlot, RestoreExpanded, RestoreViaIdentityExpandedSlot, RestoreViaIdentityExpanded
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
Dynamic: False
```

### -IgnoreConflictingHostName
If true, custom hostname conflicts will be ignored when recovering to a target web app.This setting is only necessary when RecoverConfiguration is enabled.

```yaml
Type: System.Management.Automation.SwitchParameter
Parameter Sets: RestoreExpandedSlot, RestoreExpanded, RecoverExpandedSlot, RecoverExpanded, RestoreViaIdentityExpandedSlot, RestoreViaIdentityExpanded, RecoverViaIdentityExpandedSlot, RecoverViaIdentityExpanded
Aliases: IgnoreConflictingHostNames

Required: False
Position: Named
Default value: False
Accept pipeline input: False
Accept wildcard characters: False
Dynamic: False
```

### -IgnoreDatabase
Ignore the databases and only restore the site content

```yaml
Type: System.Management.Automation.SwitchParameter
Parameter Sets: RestoreExpandedSlot, RestoreExpanded, RestoreViaIdentityExpandedSlot, RestoreViaIdentityExpanded
Aliases: IgnoreDatabases

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
Parameter Sets: RestoreViaIdentityExpandedSlot, RestoreViaIdentityExpanded, RestoreViaIdentity, RecoverViaIdentityExpandedSlot, RecoverViaIdentityExpanded, RecoverViaIdentity
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
Parameter Sets: RestoreExpandedSlot, RestoreExpanded, RecoverExpandedSlot, RecoverExpanded, RestoreViaIdentityExpandedSlot, RestoreViaIdentityExpanded, RecoverViaIdentityExpandedSlot, RecoverViaIdentityExpanded
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
Parameter Sets: Recover, RestoreSlot, RestoreExpandedSlot, RestoreExpanded, Restore, RecoverSlot, RecoverExpandedSlot, RecoverExpanded
Aliases:

Required: True
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
Dynamic: False
```

### -NoWait
Run the command asynchronously

```yaml
Type: System.Management.Automation.SwitchParameter
Parameter Sets: (All)
Aliases:

Required: False
Position: Named
Default value: False
Accept pipeline input: False
Accept wildcard characters: False
Dynamic: False
```

### -OperationType
Operation type.

```yaml
Type: Microsoft.Azure.PowerShell.Cmdlets.WebSite.Support.BackupRestoreOperationType
Parameter Sets: RestoreExpandedSlot, RestoreExpanded, RestoreViaIdentityExpandedSlot, RestoreViaIdentityExpanded
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
Dynamic: False
```

### -Overwrite
If <code>true</code> the recovery operation can overwrite source app; otherwise, <code>false</code>.

```yaml
Type: System.Management.Automation.SwitchParameter
Parameter Sets: RestoreExpandedSlot, RestoreExpanded, RecoverExpandedSlot, RecoverExpanded, RestoreViaIdentityExpandedSlot, RestoreViaIdentityExpanded, RecoverViaIdentityExpandedSlot, RecoverViaIdentityExpanded
Aliases:

Required: False
Position: Named
Default value: False
Accept pipeline input: False
Accept wildcard characters: False
Dynamic: False
```

### -PassThru
When specified, PassThru will force the cmdlet return a 'bool' given that there isn't a return type by default.

```yaml
Type: System.Management.Automation.SwitchParameter
Parameter Sets: (All)
Aliases:

Required: False
Position: Named
Default value: False
Accept pipeline input: False
Accept wildcard characters: False
Dynamic: False
```

### -RecoverConfiguration
If true, site configuration, in addition to content, will be reverted.

```yaml
Type: System.Management.Automation.SwitchParameter
Parameter Sets: RecoverExpandedSlot, RecoverExpanded, RecoverViaIdentityExpandedSlot, RecoverViaIdentityExpanded
Aliases:

Required: False
Position: Named
Default value: False
Accept pipeline input: False
Accept wildcard characters: False
Dynamic: False
```

### -RecoveryEntity
Details about app recovery operation.
To construct, see NOTES section for RECOVERYENTITY properties and create a hash table.

```yaml
Type: Microsoft.Azure.PowerShell.Cmdlets.WebSite.Models.Api20160301.ISnapshotRecoveryRequest
Parameter Sets: Recover, RecoverSlot, RecoverViaIdentity
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: True (ByValue)
Accept wildcard characters: False
Dynamic: False
```

### -RecoveryTargetId
ARM resource ID of the target app.
/subscriptions/{subId}/resourceGroups/{resourceGroupName}/providers/Microsoft.Web/sites/{siteName} for production slots and /subscriptions/{subId}/resourceGroups/{resourceGroupName}/providers/Microsoft.Web/sites/{siteName}/slots/{slotName} for other slots.

```yaml
Type: System.String
Parameter Sets: RecoverExpandedSlot, RecoverExpanded, RecoverViaIdentityExpandedSlot, RecoverViaIdentityExpanded
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
Dynamic: False
```

### -RecoveryTargetLocation
Geographical location of the target web app, e.g.
SouthEastAsia, SouthCentralUS

```yaml
Type: System.String
Parameter Sets: RecoverExpandedSlot, RecoverExpanded, RecoverViaIdentityExpandedSlot, RecoverViaIdentityExpanded
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
Dynamic: False
```

### -Request
Description of a restore request.
To construct, see NOTES section for REQUEST properties and create a hash table.

```yaml
Type: Microsoft.Azure.PowerShell.Cmdlets.WebSite.Models.Api20180201.IRestoreRequest
Parameter Sets: RestoreSlot, Restore, RestoreViaIdentity
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
Parameter Sets: Recover, RestoreSlot, RestoreExpandedSlot, RestoreExpanded, Restore, RecoverSlot, RecoverExpandedSlot, RecoverExpanded
Aliases:

Required: True
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
Dynamic: False
```

### -SiteName
Name of an app.

```yaml
Type: System.String
Parameter Sets: RestoreExpandedSlot, RestoreExpanded, RestoreViaIdentityExpandedSlot, RestoreViaIdentityExpanded
Aliases:

Required: False
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
Parameter Sets: RestoreSlot, RestoreExpandedSlot, RecoverSlot, RecoverExpandedSlot
Aliases:

Required: True
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
Dynamic: False
```

### -SnapshotTime
Point in time in which the app recovery should be attempted, formatted as a DateTime string.

```yaml
Type: System.String
Parameter Sets: RecoverExpandedSlot, RecoverExpanded, RecoverViaIdentityExpandedSlot, RecoverViaIdentityExpanded
Aliases:

Required: False
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
Parameter Sets: RestoreExpandedSlot, RestoreExpanded, RestoreViaIdentityExpandedSlot, RestoreViaIdentityExpanded
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
Parameter Sets: Recover, RestoreSlot, RestoreExpandedSlot, RestoreExpanded, Restore, RecoverSlot, RecoverExpandedSlot, RecoverExpanded
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

### Microsoft.Azure.PowerShell.Cmdlets.WebSite.Models.Api20160301.ISnapshotRecoveryRequest

### Microsoft.Azure.PowerShell.Cmdlets.WebSite.Models.Api20180201.IRestoreRequest

## OUTPUTS

### System.Boolean

## ALIASES

### Restore-AzWebAppBackup

### Restore-AzWebAppSlot

## NOTES

### COMPLEX PARAMETER PROPERTIES
To create the parameters described below, construct a hash table containing the appropriate properties. For information on hash tables, run Get-Help about_Hash_Tables.

#### DATABASE <IDatabaseBackupSetting[]>: Collection of databases which should be restored. This list has to match the list of databases included in the backup.
  - `DatabaseType <DatabaseType>`: Database type (e.g. SqlAzure / MySql).
  - `[ConnectionString <String>]`: Contains a connection string to a database which is being backed up or restored. If the restore should happen to a new database, the database name inside is the new one.
  - `[ConnectionStringName <String>]`: Contains a connection string name that is linked to the SiteConfig.ConnectionStrings.         This is used during restore with overwrite connection strings options.
  - `[Name <String>]`: 

#### RECOVERYENTITY <ISnapshotRecoveryRequest>: Details about app recovery operation.
  - `Overwrite <Boolean>`: If <code>true</code> the recovery operation can overwrite source app; otherwise, <code>false</code>.
  - `[Kind <String>]`: Kind of resource.
  - `[IgnoreConflictingHostName <Boolean?>]`: If true, custom hostname conflicts will be ignored when recovering to a target web app.         This setting is only necessary when RecoverConfiguration is enabled.
  - `[RecoverConfiguration <Boolean?>]`: If true, site configuration, in addition to content, will be reverted.
  - `[RecoveryTargetId <String>]`: ARM resource ID of the target app.         /subscriptions/{subId}/resourceGroups/{resourceGroupName}/providers/Microsoft.Web/sites/{siteName} for production slots and         /subscriptions/{subId}/resourceGroups/{resourceGroupName}/providers/Microsoft.Web/sites/{siteName}/slots/{slotName} for other slots.
  - `[RecoveryTargetLocation <String>]`: Geographical location of the target web app, e.g. SouthEastAsia, SouthCentralUS
  - `[SnapshotTime <String>]`: Point in time in which the app recovery should be attempted, formatted as a DateTime string.

#### REQUEST <IRestoreRequest>: Description of a restore request.
  - `Overwrite <Boolean>`: <code>true</code> if the restore operation can overwrite target app; otherwise, <code>false</code>. <code>true</code> is needed if trying to restore over an existing app.
  - `StorageAccountUrl <String>`: SAS URL to the container.
  - `[Kind <String>]`: Kind of resource.
  - `[AdjustConnectionString <Boolean?>]`: <code>true</code> if SiteConfig.ConnectionStrings should be set in new app; otherwise, <code>false</code>.
  - `[AppServicePlan <String>]`: Specify app service plan that will own restored site.
  - `[BlobName <String>]`: Name of a blob which contains the backup.
  - `[Database <IDatabaseBackupSetting[]>]`: Collection of databases which should be restored. This list has to match the list of databases included in the backup.
    - `DatabaseType <DatabaseType>`: Database type (e.g. SqlAzure / MySql).
    - `[ConnectionString <String>]`: Contains a connection string to a database which is being backed up or restored. If the restore should happen to a new database, the database name inside is the new one.
    - `[ConnectionStringName <String>]`: Contains a connection string name that is linked to the SiteConfig.ConnectionStrings.         This is used during restore with overwrite connection strings options.
    - `[Name <String>]`: 
  - `[HostingEnvironment <String>]`: App Service Environment name, if needed (only when restoring an app to an App Service Environment).
  - `[IgnoreConflictingHostName <Boolean?>]`: Changes a logic when restoring an app with custom domains. <code>true</code> to remove custom domains automatically. If <code>false</code>, custom domains are added to         the app's object when it is being restored, but that might fail due to conflicts during the operation.
  - `[IgnoreDatabase <Boolean?>]`: Ignore the databases and only restore the site content
  - `[OperationType <BackupRestoreOperationType?>]`: Operation type.
  - `[SiteName <String>]`: Name of an app.

## RELATED LINKS

