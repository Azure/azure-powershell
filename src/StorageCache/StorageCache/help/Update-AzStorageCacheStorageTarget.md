---
external help file: Az.StorageCache-help.xml
Module Name: Az.StorageCache
online version: https://learn.microsoft.com/powershell/module/az.storagecache/update-azstoragecachestoragetarget
schema: 2.0.0
---

# Update-AzStorageCacheStorageTarget

## SYNOPSIS
Update a Storage Target.
This operation is allowed at any time, but if the cache is down or unhealthy, the actual creation/modification of the Storage Target may be delayed until the cache is healthy again.

## SYNTAX

### UpdateExpanded (Default)
```
Update-AzStorageCacheStorageTarget -CacheName <String> -Name <String> -ResourceGroupName <String>
 [-SubscriptionId <String>] [-BlobNfUsageModel <String>] [-BlobNfVerificationTimer <Int32>]
 [-BlobNfWriteBackTimer <Int32>] [-Junction <INamespaceJunction[]>] [-Nfs3UsageModel <String>]
 [-Nfs3VerificationTimer <Int32>] [-Nfs3WriteBackTimer <Int32>] [-State <String>]
 [-UnknownAttribute <Hashtable>] [-DefaultProfile <PSObject>] [-AsJob] [-NoWait]
 [-WhatIf] [-Confirm] [<CommonParameters>]
```

### UpdateViaIdentityCachExpanded
```
Update-AzStorageCacheStorageTarget -Name <String> -CachInputObject <IStorageCacheIdentity>
 [-BlobNfUsageModel <String>] [-BlobNfVerificationTimer <Int32>] [-BlobNfWriteBackTimer <Int32>]
 [-Junction <INamespaceJunction[]>] [-Nfs3UsageModel <String>] [-Nfs3VerificationTimer <Int32>]
 [-Nfs3WriteBackTimer <Int32>] [-State <String>] [-UnknownAttribute <Hashtable>] [-DefaultProfile <PSObject>]
 [-AsJob] [-NoWait] [-WhatIf] [-Confirm] [<CommonParameters>]
```

### UpdateViaIdentityExpanded
```
Update-AzStorageCacheStorageTarget -InputObject <IStorageCacheIdentity> [-BlobNfUsageModel <String>]
 [-BlobNfVerificationTimer <Int32>] [-BlobNfWriteBackTimer <Int32>] [-Junction <INamespaceJunction[]>]
 [-Nfs3UsageModel <String>] [-Nfs3VerificationTimer <Int32>] [-Nfs3WriteBackTimer <Int32>] [-State <String>]
 [-UnknownAttribute <Hashtable>] [-DefaultProfile <PSObject>] [-AsJob] [-NoWait]
 [-WhatIf] [-Confirm] [<CommonParameters>]
```

## DESCRIPTION
Update a Storage Target.
This operation is allowed at any time, but if the cache is down or unhealthy, the actual creation/modification of the Storage Target may be delayed until the cache is healthy again.

## EXAMPLES

The HPC Cache service is being deprecated.

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
Parameter Sets: UpdateExpanded
Aliases:

Required: True
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -CachInputObject
Identity Parameter

```yaml
Type: Microsoft.Azure.PowerShell.Cmdlets.StorageCache.Models.IStorageCacheIdentity
Parameter Sets: UpdateViaIdentityCachExpanded
Aliases:

Required: True
Position: Named
Default value: None
Accept pipeline input: True (ByValue)
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

### -InputObject
Identity Parameter

```yaml
Type: Microsoft.Azure.PowerShell.Cmdlets.StorageCache.Models.IStorageCacheIdentity
Parameter Sets: UpdateViaIdentityExpanded
Aliases:

Required: True
Position: Named
Default value: None
Accept pipeline input: True (ByValue)
Accept wildcard characters: False
```

### -Junction
List of cache namespace junctions to target for namespace associations.

```yaml
Type: Microsoft.Azure.PowerShell.Cmdlets.StorageCache.Models.INamespaceJunction[]
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
Parameter Sets: UpdateExpanded, UpdateViaIdentityCachExpanded
Aliases: StorageTargetName

Required: True
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
Parameter Sets: UpdateExpanded
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
The ID of the target subscription.

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

### Microsoft.Azure.PowerShell.Cmdlets.StorageCache.Models.IStorageCacheIdentity

## OUTPUTS

### Microsoft.Azure.PowerShell.Cmdlets.StorageCache.Models.IStorageTarget

## NOTES

## RELATED LINKS
