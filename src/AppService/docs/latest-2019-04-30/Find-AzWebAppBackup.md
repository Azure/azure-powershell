---
external help file:
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
 [-Request <IRestoreRequest>] [-DefaultProfile <PSObject>] [-Confirm] [-WhatIf] [<CommonParameters>]
```

### DiscoverSlot
```
Find-AzWebAppBackup -Name <String> -ResourceGroupName <String> -SubscriptionId <String> -Slot <String>
 [-Request <IRestoreRequest>] [-DefaultProfile <PSObject>] [-Confirm] [-WhatIf] [<CommonParameters>]
```

### DiscoverExpandedSlot
```
Find-AzWebAppBackup -Name <String> -ResourceGroupName <String> -SubscriptionId <String> -Slot <String>
 [-AdjustConnectionString] [-AppServicePlan <String>] [-BlobName <String>]
 [-Database <IDatabaseBackupSetting[]>] [-HostingEnvironment <String>] [-IgnoreConflictingHostName]
 [-IgnoreDatabase] [-Kind <String>] [-OperationType <BackupRestoreOperationType>] [-Overwrite]
 [-SiteName <String>] [-StorageAccountUrl <String>] [-DefaultProfile <PSObject>] [-Confirm] [-WhatIf]
 [<CommonParameters>]
```

### DiscoverExpanded
```
Find-AzWebAppBackup -Name <String> -ResourceGroupName <String> -SubscriptionId <String>
 [-AdjustConnectionString] [-AppServicePlan <String>] [-BlobName <String>]
 [-Database <IDatabaseBackupSetting[]>] [-HostingEnvironment <String>] [-IgnoreConflictingHostName]
 [-IgnoreDatabase] [-Kind <String>] [-OperationType <BackupRestoreOperationType>] [-Overwrite]
 [-SiteName <String>] [-StorageAccountUrl <String>] [-DefaultProfile <PSObject>] [-Confirm] [-WhatIf]
 [<CommonParameters>]
```

### DiscoverViaIdentityExpandedSlot
```
Find-AzWebAppBackup -InputObject <IWebSiteIdentity> [-AdjustConnectionString] [-AppServicePlan <String>]
 [-BlobName <String>] [-Database <IDatabaseBackupSetting[]>] [-HostingEnvironment <String>]
 [-IgnoreConflictingHostName] [-IgnoreDatabase] [-Kind <String>] [-OperationType <BackupRestoreOperationType>]
 [-Overwrite] [-SiteName <String>] [-StorageAccountUrl <String>] [-DefaultProfile <PSObject>] [-Confirm]
 [-WhatIf] [<CommonParameters>]
```

### DiscoverViaIdentityExpanded
```
Find-AzWebAppBackup -InputObject <IWebSiteIdentity> [-AdjustConnectionString] [-AppServicePlan <String>]
 [-BlobName <String>] [-Database <IDatabaseBackupSetting[]>] [-HostingEnvironment <String>]
 [-IgnoreConflictingHostName] [-IgnoreDatabase] [-Kind <String>] [-OperationType <BackupRestoreOperationType>]
 [-Overwrite] [-SiteName <String>] [-StorageAccountUrl <String>] [-DefaultProfile <PSObject>] [-Confirm]
 [-WhatIf] [<CommonParameters>]
```

### DiscoverViaIdentity
```
Find-AzWebAppBackup -InputObject <IWebSiteIdentity> [-Request <IRestoreRequest>] [-DefaultProfile <PSObject>]
 [-Confirm] [-WhatIf] [<CommonParameters>]
```

## DESCRIPTION
Discovers an existing app backup that can be restored from a blob in Azure storage.
Use this to get information about the databases stored in a backup.

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
Parameter Sets: DiscoverExpandedSlot, DiscoverExpanded, DiscoverViaIdentityExpandedSlot, DiscoverViaIdentityExpanded
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
Parameter Sets: DiscoverExpandedSlot, DiscoverExpanded, DiscoverViaIdentityExpandedSlot, DiscoverViaIdentityExpanded
Aliases:

Required: False
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
Parameter Sets: DiscoverExpandedSlot, DiscoverExpanded, DiscoverViaIdentityExpandedSlot, DiscoverViaIdentityExpanded
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
Parameter Sets: DiscoverExpandedSlot, DiscoverExpanded, DiscoverViaIdentityExpandedSlot, DiscoverViaIdentityExpanded
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

### -HostingEnvironment
App Service Environment name, if needed (only when restoring an app to an App Service Environment).

```yaml
Type: System.String
Parameter Sets: DiscoverExpandedSlot, DiscoverExpanded, DiscoverViaIdentityExpandedSlot, DiscoverViaIdentityExpanded
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
Dynamic: False
```

### -IgnoreConflictingHostName
Changes a logic when restoring an app with custom domains.
<code>true</code> to remove custom domains automatically.
If <code>false</code>, custom domains are added to the app's object when it is being restored, but that might fail due to conflicts during the operation.

```yaml
Type: System.Management.Automation.SwitchParameter
Parameter Sets: DiscoverExpandedSlot, DiscoverExpanded, DiscoverViaIdentityExpandedSlot, DiscoverViaIdentityExpanded
Aliases:

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
Parameter Sets: DiscoverExpandedSlot, DiscoverExpanded, DiscoverViaIdentityExpandedSlot, DiscoverViaIdentityExpanded
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
Parameter Sets: DiscoverViaIdentityExpandedSlot, DiscoverViaIdentityExpanded, DiscoverViaIdentity
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
Parameter Sets: DiscoverExpandedSlot, DiscoverExpanded, DiscoverViaIdentityExpandedSlot, DiscoverViaIdentityExpanded
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
Parameter Sets: Discover, DiscoverSlot, DiscoverExpandedSlot, DiscoverExpanded
Aliases:

Required: True
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
Dynamic: False
```

### -OperationType
Operation type.

```yaml
Type: Microsoft.Azure.PowerShell.Cmdlets.WebSite.Support.BackupRestoreOperationType
Parameter Sets: DiscoverExpandedSlot, DiscoverExpanded, DiscoverViaIdentityExpandedSlot, DiscoverViaIdentityExpanded
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
Dynamic: False
```

### -Overwrite
<code>true</code> if the restore operation can overwrite target app; otherwise, <code>false</code>.
<code>true</code> is needed if trying to restore over an existing app.

```yaml
Type: System.Management.Automation.SwitchParameter
Parameter Sets: DiscoverExpandedSlot, DiscoverExpanded, DiscoverViaIdentityExpandedSlot, DiscoverViaIdentityExpanded
Aliases:

Required: False
Position: Named
Default value: False
Accept pipeline input: False
Accept wildcard characters: False
Dynamic: False
```

### -Request
Description of a restore request.
To construct, see NOTES section for REQUEST properties and create a hash table.

```yaml
Type: Microsoft.Azure.PowerShell.Cmdlets.WebSite.Models.Api20180201.IRestoreRequest
Parameter Sets: Discover, DiscoverSlot, DiscoverViaIdentity
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
Parameter Sets: Discover, DiscoverSlot, DiscoverExpandedSlot, DiscoverExpanded
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
Parameter Sets: DiscoverExpandedSlot, DiscoverExpanded, DiscoverViaIdentityExpandedSlot, DiscoverViaIdentityExpanded
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
Dynamic: False
```

### -Slot
Name of the deployment slot.
If a slot is not specified, the API will perform discovery for the production slot.

```yaml
Type: System.String
Parameter Sets: DiscoverSlot, DiscoverExpandedSlot
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
Parameter Sets: DiscoverExpandedSlot, DiscoverExpanded, DiscoverViaIdentityExpandedSlot, DiscoverViaIdentityExpanded
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
Parameter Sets: Discover, DiscoverSlot, DiscoverExpandedSlot, DiscoverExpanded
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

### Microsoft.Azure.PowerShell.Cmdlets.WebSite.Models.Api20180201.IRestoreRequest

## OUTPUTS

### Microsoft.Azure.PowerShell.Cmdlets.WebSite.Models.Api20180201.IRestoreRequest

## ALIASES

### Find-AzWebAppBackupSlot

## NOTES

### COMPLEX PARAMETER PROPERTIES
To create the parameters described below, construct a hash table containing the appropriate properties. For information on hash tables, run Get-Help about_Hash_Tables.

#### DATABASE <IDatabaseBackupSetting[]>: Collection of databases which should be restored. This list has to match the list of databases included in the backup.
  - `DatabaseType <DatabaseType>`: Database type (e.g. SqlAzure / MySql).
  - `[ConnectionString <String>]`: Contains a connection string to a database which is being backed up or restored. If the restore should happen to a new database, the database name inside is the new one.
  - `[ConnectionStringName <String>]`: Contains a connection string name that is linked to the SiteConfig.ConnectionStrings.         This is used during restore with overwrite connection strings options.
  - `[Name <String>]`: 

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

