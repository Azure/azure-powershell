---
external help file: Az.WebSite-help.xml
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
 [-RecoveryEntity <ISnapshotRecoveryRequest>] [-DefaultProfile <PSObject>] [-AsJob] [-WhatIf] [-Confirm]
 [<CommonParameters>]
```

### RestoreExpanded
```
Restore-AzWebApp -Name <String> -ResourceGroupName <String> -SubscriptionId <String> -BackupId <String>
 [-PassThru] [-IgnoreConflictingHostName <Boolean>] [-Kind <String>] -Overwrite <Boolean>
 [-AdjustConnectionString <Boolean>] [-AppServicePlan <String>] [-BlobName <String>]
 [-Database <IDatabaseBackupSetting[]>] [-HostingEnvironment <String>] [-IgnoreDatabas <Boolean>]
 [-OperationType <BackupRestoreOperationType>] [-SiteName <String>] -StorageAccountUrl <String>
 [-DefaultProfile <PSObject>] [-AsJob] [-WhatIf] [-Confirm] [<CommonParameters>]
```

### Restore
```
Restore-AzWebApp -Name <String> -ResourceGroupName <String> -SubscriptionId <String> -BackupId <String>
 [-PassThru] [-Request <IRestoreRequest>] [-DefaultProfile <PSObject>] [-AsJob] [-WhatIf] [-Confirm]
 [<CommonParameters>]
```

### RecoverExpanded
```
Restore-AzWebApp -Name <String> -ResourceGroupName <String> -SubscriptionId <String> [-PassThru]
 [-IgnoreConflictingHostName <Boolean>] [-Kind <String>] -Overwrite <Boolean> [-RecoverConfiguration <Boolean>]
 [-RecoveryTargetId <String>] [-RecoveryTargetLocation <String>] [-SnapshotTime <String>]
 [-DefaultProfile <PSObject>] [-AsJob] [-WhatIf] [-Confirm] [<CommonParameters>]
```

### RestoreViaIdentityExpanded
```
Restore-AzWebApp -InputObject <IWebSiteIdentity> [-PassThru] [-IgnoreConflictingHostName <Boolean>]
 [-Kind <String>] -Overwrite <Boolean> [-AdjustConnectionString <Boolean>] [-AppServicePlan <String>]
 [-BlobName <String>] [-Database <IDatabaseBackupSetting[]>] [-HostingEnvironment <String>]
 [-IgnoreDatabas <Boolean>] [-OperationType <BackupRestoreOperationType>] [-SiteName <String>]
 -StorageAccountUrl <String> [-DefaultProfile <PSObject>] [-AsJob] [-WhatIf] [-Confirm] [<CommonParameters>]
```

### RestoreViaIdentity
```
Restore-AzWebApp -InputObject <IWebSiteIdentity> [-PassThru] [-Request <IRestoreRequest>]
 [-DefaultProfile <PSObject>] [-AsJob] [-WhatIf] [-Confirm] [<CommonParameters>]
```

### RecoverViaIdentityExpanded
```
Restore-AzWebApp -InputObject <IWebSiteIdentity> [-PassThru] [-IgnoreConflictingHostName <Boolean>]
 [-Kind <String>] -Overwrite <Boolean> [-RecoverConfiguration <Boolean>] [-RecoveryTargetId <String>]
 [-RecoveryTargetLocation <String>] [-SnapshotTime <String>] [-DefaultProfile <PSObject>] [-AsJob] [-WhatIf]
 [-Confirm] [<CommonParameters>]
```

### RecoverViaIdentity
```
Restore-AzWebApp -InputObject <IWebSiteIdentity> [-PassThru] [-RecoveryEntity <ISnapshotRecoveryRequest>]
 [-DefaultProfile <PSObject>] [-AsJob] [-WhatIf] [-Confirm] [<CommonParameters>]
```

## DESCRIPTION
Recovers a web app to a previous snapshot.

## EXAMPLES

### Example 1
```powershell
PS C:\> {{ Add example code here }}
```

{{ Add example description here }}

## PARAMETERS

### -AdjustConnectionString
\<code\>true\</code\> if SiteConfig.ConnectionStrings should be set in new app; otherwise, \<code\>false\</code\>.

```yaml
Type: System.Boolean
Parameter Sets: RestoreExpanded, RestoreViaIdentityExpanded
Aliases:

Required: False
Position: Named
Default value: False
Accept pipeline input: False
Accept wildcard characters: False
```

### -AppServicePlan
Specify app service plan that will own restored site.

```yaml
Type: System.String
Parameter Sets: RestoreExpanded, RestoreViaIdentityExpanded
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
Default value: False
Accept pipeline input: False
Accept wildcard characters: False
```

### -BackupId
ID of the backup.

```yaml
Type: System.String
Parameter Sets: RestoreExpanded, Restore
Aliases:

Required: True
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -BlobName
Name of a blob which contains the backup.

```yaml
Type: System.String
Parameter Sets: RestoreExpanded, RestoreViaIdentityExpanded
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -Database
Collection of databases which should be restored.
This list has to match the list of databases included in the backup.

```yaml
Type: Microsoft.Azure.PowerShell.Cmdlets.WebSite.Models.Api20160801.IDatabaseBackupSetting[]
Parameter Sets: RestoreExpanded, RestoreViaIdentityExpanded
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

### -HostingEnvironment
App Service Environment name, if needed (only when restoring an app to an App Service Environment).

```yaml
Type: System.String
Parameter Sets: RestoreExpanded, RestoreViaIdentityExpanded
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -IgnoreConflictingHostName
Changes a logic when restoring an app with custom domains.
\<code\>true\</code\> to remove custom domains automatically.
If \<code\>false\</code\>, custom domains are added to the app's object when it is being restored, but that might fail due to conflicts during the operation.

```yaml
Type: System.Boolean
Parameter Sets: RestoreExpanded, RecoverExpanded, RestoreViaIdentityExpanded, RecoverViaIdentityExpanded
Aliases:

Required: False
Position: Named
Default value: False
Accept pipeline input: False
Accept wildcard characters: False
```

### -IgnoreDatabas
Ignore the databases and only restore the site content

```yaml
Type: System.Boolean
Parameter Sets: RestoreExpanded, RestoreViaIdentityExpanded
Aliases:

Required: False
Position: Named
Default value: False
Accept pipeline input: False
Accept wildcard characters: False
```

### -InputObject
Identity Parameter

```yaml
Type: Microsoft.Azure.PowerShell.Cmdlets.WebSite.Models.IWebSiteIdentity
Parameter Sets: RestoreViaIdentityExpanded, RestoreViaIdentity, RecoverViaIdentityExpanded, RecoverViaIdentity
Aliases:

Required: True
Position: Named
Default value: None
Accept pipeline input: True (ByValue)
Accept wildcard characters: False
```

### -Kind
Kind of resource.

```yaml
Type: System.String
Parameter Sets: RestoreExpanded, RecoverExpanded, RestoreViaIdentityExpanded, RecoverViaIdentityExpanded
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -Name
Name of web app.

```yaml
Type: System.String
Parameter Sets: Recover, RestoreExpanded, Restore, RecoverExpanded
Aliases:

Required: True
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -OperationType
Operation type.

```yaml
Type: Microsoft.Azure.PowerShell.Cmdlets.WebSite.Support.BackupRestoreOperationType
Parameter Sets: RestoreExpanded, RestoreViaIdentityExpanded
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -Overwrite
\<code\>true\</code\> if the restore operation can overwrite target app; otherwise, \<code\>false\</code\>.
\<code\>true\</code\> is needed if trying to restore over an existing app.

```yaml
Type: System.Boolean
Parameter Sets: RestoreExpanded, RecoverExpanded, RestoreViaIdentityExpanded, RecoverViaIdentityExpanded
Aliases:

Required: True
Position: Named
Default value: False
Accept pipeline input: False
Accept wildcard characters: False
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
```

### -RecoverConfiguration
If true, site configuration, in addition to content, will be reverted.

```yaml
Type: System.Boolean
Parameter Sets: RecoverExpanded, RecoverViaIdentityExpanded
Aliases:

Required: False
Position: Named
Default value: False
Accept pipeline input: False
Accept wildcard characters: False
```

### -RecoveryEntity
Details about app recovery operation.

```yaml
Type: Microsoft.Azure.PowerShell.Cmdlets.WebSite.Models.Api20160301.ISnapshotRecoveryRequest
Parameter Sets: Recover, RecoverViaIdentity
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: True (ByValue)
Accept wildcard characters: False
```

### -RecoveryTargetId
ARM resource ID of the target app.
/subscriptions/{subId}/resourceGroups/{resourceGroupName}/providers/Microsoft.Web/sites/{siteName} for production slots and /subscriptions/{subId}/resourceGroups/{resourceGroupName}/providers/Microsoft.Web/sites/{siteName}/slots/{slotName} for other slots.

```yaml
Type: System.String
Parameter Sets: RecoverExpanded, RecoverViaIdentityExpanded
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -RecoveryTargetLocation
Geographical location of the target web app, e.g.
SouthEastAsia, SouthCentralUS

```yaml
Type: System.String
Parameter Sets: RecoverExpanded, RecoverViaIdentityExpanded
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -Request
Description of a restore request.

```yaml
Type: Microsoft.Azure.PowerShell.Cmdlets.WebSite.Models.Api20180201.IRestoreRequest
Parameter Sets: Restore, RestoreViaIdentity
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: True (ByValue)
Accept wildcard characters: False
```

### -ResourceGroupName
Name of the resource group to which the resource belongs.

```yaml
Type: System.String
Parameter Sets: Recover, RestoreExpanded, Restore, RecoverExpanded
Aliases:

Required: True
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -SiteName
Name of an app.

```yaml
Type: System.String
Parameter Sets: RestoreExpanded, RestoreViaIdentityExpanded
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -SnapshotTime
Point in time in which the app recovery should be attempted, formatted as a DateTime string.

```yaml
Type: System.String
Parameter Sets: RecoverExpanded, RecoverViaIdentityExpanded
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -StorageAccountUrl
SAS URL to the container.

```yaml
Type: System.String
Parameter Sets: RestoreExpanded, RestoreViaIdentityExpanded
Aliases:

Required: True
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -SubscriptionId
Your Azure subscription ID.
This is a GUID-formatted string (e.g.
00000000-0000-0000-0000-000000000000).

```yaml
Type: System.String
Parameter Sets: Recover, RestoreExpanded, Restore, RecoverExpanded
Aliases:

Required: True
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

### System.Boolean
## NOTES

## RELATED LINKS

[https://docs.microsoft.com/en-us/powershell/module/az.website/restore-azwebapp](https://docs.microsoft.com/en-us/powershell/module/az.website/restore-azwebapp)

