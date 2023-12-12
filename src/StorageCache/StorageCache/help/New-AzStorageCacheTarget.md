---
external help file:
Module Name: Az.StorageCache
online version: https://learn.microsoft.com/powershell/module/az.storagecache/new-azstoragecachetarget
schema: 2.0.0
---

# New-AzStorageCacheTarget

## SYNOPSIS
Create or update a Storage Target.
This operation is allowed at any time, but if the cache is down or unhealthy, the actual creation/modification of the Storage Target may be delayed until the cache is healthy again.

## SYNTAX

```
New-AzStorageCacheTarget -CacheName <String> -Name <String> -ResourceGroupName <String>
 [-SubscriptionId <String>] [-BlobNfTarget <String>] [-BlobNfUsageModel <String>]
 [-BlobNfVerificationTimer <Int32>] [-BlobNfWriteBackTimer <Int32>] [-ClfTarget <String>]
 [-Junction <INamespaceJunction[]>] [-Nfs3Target <String>] [-Nfs3UsageModel <String>]
 [-Nfs3VerificationTimer <Int32>] [-Nfs3WriteBackTimer <Int32>] [-State <OperationalStateType>]
 [-TargetType <StorageTargetType>] [-UnknownAttribute <Hashtable>] [-DefaultProfile <PSObject>] [-AsJob]
 [-NoWait] [-Confirm] [-WhatIf] [<CommonParameters>]
```

## DESCRIPTION
Create or update a Storage Target.
This operation is allowed at any time, but if the cache is down or unhealthy, the actual creation/modification of the Storage Target may be delayed until the cache is healthy again.

## EXAMPLES

### Example 1: Create or update a Storage Target.
```powershell
New-AzStorageCacheTarget -CacheName azps-storagecache -Name azps-cachetarget -ResourceGroupName azps_test_gp_storagecache -Nfs3Target "10.0.44.44" -Nfs3UsageModel "READ_WRITE" -Nfs3VerificationTimer 30 -TargetType 'nfs3'
```

```output
Name             Location ResourceGroupName         State
----             -------- -----------------         -----
azps-cachetarget eastus   azps_test_gp_storagecache Ready
```

Create or update a Storage Target.
This operation is allowed at any time, but if the cache is down or unhealthy, the actual creation/modification of the Storage Target may be delayed until the cache is healthy again.

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

### -BlobNfTarget
Resource ID of the storage container.

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

### -BlobNfUsageModel
Identifies the StorageCache usage model to be used for this storage target.

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

### -BlobNfVerificationTimer
Amount of time (in seconds) the cache waits before it checks the back-end storage for file updates.

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

### -BlobNfWriteBackTimer
Amount of time (in seconds) the cache waits after the last file change before it copies the changed file to back-end storage.

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

### -CacheName
Name of cache.
Length of name must not be greater than 80 and chars must be from the [-0-9a-zA-Z_] char class.

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

### -ClfTarget
Resource ID of storage container.

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

### -Junction
List of cache namespace junctions to target for namespace associations.
To construct, see NOTES section for JUNCTION properties and create a hash table.

```yaml
Type: Microsoft.Azure.PowerShell.Cmdlets.StorageCache.Models.Api20230501.INamespaceJunction[]
Parameter Sets: (All)
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -Name
Name of Storage Target.

```yaml
Type: System.String
Parameter Sets: (All)
Aliases: StorageTargetName

Required: True
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -Nfs3Target
IP address or host name of an NFSv3 host (e.g., 10.0.44.44).

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

### -Nfs3UsageModel
Identifies the StorageCache usage model to be used for this storage target.

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

### -Nfs3VerificationTimer
Amount of time (in seconds) the cache waits before it checks the back-end storage for file updates.

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

### -Nfs3WriteBackTimer
Amount of time (in seconds) the cache waits after the last file change before it copies the changed file to back-end storage.

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

### -ResourceGroupName
The name of the resource group.
The name is case insensitive.

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

### -State
Storage target operational state.

```yaml
Type: Microsoft.Azure.PowerShell.Cmdlets.StorageCache.Support.OperationalStateType
Parameter Sets: (All)
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -SubscriptionId
The ID of the target subscription.

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

### -TargetType
Type of the Storage Target.

```yaml
Type: Microsoft.Azure.PowerShell.Cmdlets.StorageCache.Support.StorageTargetType
Parameter Sets: (All)
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -UnknownAttribute
Dictionary of string-\>string pairs containing information about the Storage Target.

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

### Microsoft.Azure.PowerShell.Cmdlets.StorageCache.Models.Api20230501.IStorageTarget

## NOTES

ALIASES

COMPLEX PARAMETER PROPERTIES

To create the parameters described below, construct a hash table containing the appropriate properties. For information on hash tables, run Get-Help about_Hash_Tables.


`JUNCTION <INamespaceJunction[]>`: List of cache namespace junctions to target for namespace associations.
  - `[NamespacePath <String>]`: Namespace path on a cache for a Storage Target.
  - `[NfsAccessPolicy <String>]`: Name of the access policy applied to this junction.
  - `[NfsExport <String>]`: NFS export where targetPath exists.
  - `[TargetPath <String>]`: Path in Storage Target to which namespacePath points.

## RELATED LINKS

