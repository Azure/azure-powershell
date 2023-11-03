---
external help file:
Module Name: Az.StorageCache
online version: https://learn.microsoft.com/powershell/module/az.storagecache/invoke-azstoragecacheamlfilesystemarchive
schema: 2.0.0
---

# Invoke-AzStorageCacheAmlFileSystemArchive

## SYNOPSIS
Archive data from the AML file system.

## SYNTAX

### ArchiveExpanded (Default)
```
Invoke-AzStorageCacheAmlFileSystemArchive -AmlFilesystemName <String> -ResourceGroupName <String>
 [-SubscriptionId <String>] [-FilesystemPath <String>] [-DefaultProfile <PSObject>] [-PassThru] [-Confirm]
 [-WhatIf] [<CommonParameters>]
```

### ArchiveViaIdentityExpanded
```
Invoke-AzStorageCacheAmlFileSystemArchive -InputObject <IStorageCacheIdentity> [-FilesystemPath <String>]
 [-DefaultProfile <PSObject>] [-PassThru] [-Confirm] [-WhatIf] [<CommonParameters>]
```

## DESCRIPTION
Archive data from the AML file system.

## EXAMPLES

### Example 1: Archive data from the AML file system.
```powershell
Invoke-AzStorageCacheAmlFileSystemArchive -AmlFilesystemName azps-cache-fs-4 -ResourceGroupName azps_test_gp_storagecache
```

Archive data from the AML file system.

### Example 2: Archive data from the AML file system.
```powershell
Invoke-AzStorageCacheAmlFileSystemArchive -AmlFilesystemName azps-cache-fs-4 -ResourceGroupName azps_test_gp_storagecache -PassThru
```

```output
True
```

Archive data from the AML file system.

## PARAMETERS

### -AmlFilesystemName
Name for the AML file system.
Allows alphanumerics, underscores, and hyphens.
Start and end with alphanumeric.

```yaml
Type: System.String
Parameter Sets: ArchiveExpanded
Aliases:

Required: True
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -DefaultProfile
The DefaultProfile parameter is not functional.
Use the SubscriptionId parameter when available if executing the cmdlet against a different subscription.

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

### -FilesystemPath
Lustre file system path to archive relative to the file system root.
Specify '/' to archive all modified data.

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

### -InputObject
Identity Parameter
To construct, see NOTES section for INPUTOBJECT properties and create a hash table.

```yaml
Type: Microsoft.Azure.PowerShell.Cmdlets.StorageCache.Models.IStorageCacheIdentity
Parameter Sets: ArchiveViaIdentityExpanded
Aliases:

Required: True
Position: Named
Default value: None
Accept pipeline input: True (ByValue)
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
The name of the resource group.
The name is case insensitive.

```yaml
Type: System.String
Parameter Sets: ArchiveExpanded
Aliases:

Required: True
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -SubscriptionId
The ID of the target subscription.

```yaml
Type: System.String
Parameter Sets: ArchiveExpanded
Aliases:

Required: False
Position: Named
Default value: (Get-AzContext).Subscription.Id
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

### Microsoft.Azure.PowerShell.Cmdlets.StorageCache.Models.IStorageCacheIdentity

## OUTPUTS

### System.Boolean

## NOTES

ALIASES

COMPLEX PARAMETER PROPERTIES

To create the parameters described below, construct a hash table containing the appropriate properties. For information on hash tables, run Get-Help about_Hash_Tables.


`INPUTOBJECT <IStorageCacheIdentity>`: Identity Parameter
  - `[AmlFilesystemName <String>]`: Name for the AML file system. Allows alphanumerics, underscores, and hyphens. Start and end with alphanumeric.
  - `[CacheName <String>]`: Name of cache. Length of name must not be greater than 80 and chars must be from the [-0-9a-zA-Z_] char class.
  - `[Id <String>]`: Resource identity path
  - `[Location <String>]`: The name of Azure region.
  - `[OperationId <String>]`: The ID of an ongoing async operation.
  - `[ResourceGroupName <String>]`: The name of the resource group. The name is case insensitive.
  - `[StorageTargetName <String>]`: Name of Storage Target.
  - `[SubscriptionId <String>]`: The ID of the target subscription.

## RELATED LINKS

