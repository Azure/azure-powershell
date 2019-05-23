---
external help file: Az.WebSite-help.xml
Module Name: Az.WebSite
online version: https://docs.microsoft.com/en-us/powershell/module/az.website/find-azwebappbackup
schema: 2.0.0
---

# Find-AzWebAppBackup

## SYNOPSIS
Discovers an existing app backup that can be restored from a blob in Azure storage.
Use this to get information about the databases stored in a backup.

## SYNTAX

### Discover (Default)
```
Find-AzWebAppBackup -Name <String> -ResourceGroupName <String> -SubscriptionId <String>
 [-Request <IRestoreRequest>] [-DefaultProfile <PSObject>] [-WhatIf] [-Confirm] [<CommonParameters>]
```

### DiscoverExpanded
```
Find-AzWebAppBackup -Name <String> -ResourceGroupName <String> -SubscriptionId <String>
 [-AdjustConnectionString <Boolean>] [-AppServicePlan <String>] [-BlobName <String>]
 [-Database <IDatabaseBackupSetting[]>] [-HostingEnvironment <String>] [-IgnoreConflictingHostName <Boolean>]
 [-IgnoreDatabas <Boolean>] [-Kind <String>] [-OperationType <BackupRestoreOperationType>] -Overwrite <Boolean>
 [-SiteName <String>] -StorageAccountUrl <String> [-DefaultProfile <PSObject>] [-WhatIf] [-Confirm]
 [<CommonParameters>]
```

### DiscoverViaIdentityExpanded
```
Find-AzWebAppBackup -InputObject <IWebSiteIdentity> [-AdjustConnectionString <Boolean>]
 [-AppServicePlan <String>] [-BlobName <String>] [-Database <IDatabaseBackupSetting[]>]
 [-HostingEnvironment <String>] [-IgnoreConflictingHostName <Boolean>] [-IgnoreDatabas <Boolean>]
 [-Kind <String>] [-OperationType <BackupRestoreOperationType>] -Overwrite <Boolean> [-SiteName <String>]
 -StorageAccountUrl <String> [-DefaultProfile <PSObject>] [-WhatIf] [-Confirm] [<CommonParameters>]
```

### DiscoverViaIdentity
```
Find-AzWebAppBackup -InputObject <IWebSiteIdentity> [-Request <IRestoreRequest>] [-DefaultProfile <PSObject>]
 [-WhatIf] [-Confirm] [<CommonParameters>]
```

## DESCRIPTION
Discovers an existing app backup that can be restored from a blob in Azure storage.
Use this to get information about the databases stored in a backup.

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
Parameter Sets: DiscoverExpanded, DiscoverViaIdentityExpanded
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
Parameter Sets: DiscoverExpanded, DiscoverViaIdentityExpanded
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -BlobName
Name of a blob which contains the backup.

```yaml
Type: System.String
Parameter Sets: DiscoverExpanded, DiscoverViaIdentityExpanded
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
Parameter Sets: DiscoverExpanded, DiscoverViaIdentityExpanded
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
Parameter Sets: DiscoverExpanded, DiscoverViaIdentityExpanded
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
Parameter Sets: DiscoverExpanded, DiscoverViaIdentityExpanded
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
Parameter Sets: DiscoverExpanded, DiscoverViaIdentityExpanded
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
Parameter Sets: DiscoverViaIdentityExpanded, DiscoverViaIdentity
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
Parameter Sets: DiscoverExpanded, DiscoverViaIdentityExpanded
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -Name
Name of the app.

```yaml
Type: System.String
Parameter Sets: Discover, DiscoverExpanded
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
Parameter Sets: DiscoverExpanded, DiscoverViaIdentityExpanded
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
Parameter Sets: DiscoverExpanded, DiscoverViaIdentityExpanded
Aliases:

Required: True
Position: Named
Default value: False
Accept pipeline input: False
Accept wildcard characters: False
```

### -Request
Description of a restore request.

```yaml
Type: Microsoft.Azure.PowerShell.Cmdlets.WebSite.Models.Api20180201.IRestoreRequest
Parameter Sets: Discover, DiscoverViaIdentity
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
Parameter Sets: Discover, DiscoverExpanded
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
Parameter Sets: DiscoverExpanded, DiscoverViaIdentityExpanded
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
Parameter Sets: DiscoverExpanded, DiscoverViaIdentityExpanded
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
Parameter Sets: Discover, DiscoverExpanded
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

### Microsoft.Azure.PowerShell.Cmdlets.WebSite.Models.Api20180201.IRestoreRequest
## NOTES

## RELATED LINKS

[https://docs.microsoft.com/en-us/powershell/module/az.website/find-azwebappbackup](https://docs.microsoft.com/en-us/powershell/module/az.website/find-azwebappbackup)

