---
external help file:
Module Name: Az.StorageCache
online version: https://learn.microsoft.com/powershell/module/az.storagecache/get-azstoragecachetarget
schema: 2.0.0
---

# Get-AzStorageCacheTarget

## SYNOPSIS
Returns a Storage Target from a cache.

## SYNTAX

### List (Default)
```
Get-AzStorageCacheTarget -CacheName <String> -ResourceGroupName <String> [-SubscriptionId <String[]>]
 [-DefaultProfile <PSObject>] [<CommonParameters>]
```

### Get
```
Get-AzStorageCacheTarget -CacheName <String> -Name <String> -ResourceGroupName <String>
 [-SubscriptionId <String[]>] [-DefaultProfile <PSObject>] [<CommonParameters>]
```

### GetViaIdentity
```
Get-AzStorageCacheTarget -InputObject <IStorageCacheIdentity> [-DefaultProfile <PSObject>]
 [<CommonParameters>]
```

## DESCRIPTION
Returns a Storage Target from a cache.

## EXAMPLES

### Example 1: List Storage Target by Cache Name.
```powershell
Get-AzStorageCacheTarget -CacheName azps-storagecache -ResourceGroupName azps_test_gp_storagecache
```

```output
Name             Location ResourceGroupName         State
----             -------- -----------------         -----
azps-cachetarget eastus   azps_test_gp_storagecache Ready
```

List Storage Target by Cache Name.

### Example 2: Get a Storage Target by Storage Target Name.
```powershell
Get-AzStorageCacheTarget -CacheName azps-storagecache -ResourceGroupName azps_test_gp_storagecache -Name azps-cachetarget
```

```output
Name             Location ResourceGroupName         State
----             -------- -----------------         -----
azps-cachetarget eastus   azps_test_gp_storagecache Ready
```

Get a Storage Target by Storage Target Name.

## PARAMETERS

### -CacheName
Name of cache.
Length of name must not be greater than 80 and chars must be from the [-0-9a-zA-Z_] char class.

```yaml
Type: System.String
Parameter Sets: Get, List
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

### -InputObject
Identity Parameter
To construct, see NOTES section for INPUTOBJECT properties and create a hash table.

```yaml
Type: Microsoft.Azure.PowerShell.Cmdlets.StorageCache.Models.IStorageCacheIdentity
Parameter Sets: GetViaIdentity
Aliases:

Required: True
Position: Named
Default value: None
Accept pipeline input: True (ByValue)
Accept wildcard characters: False
```

### -Name
Name of Storage Target.

```yaml
Type: System.String
Parameter Sets: Get
Aliases: StorageTargetName

Required: True
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
Parameter Sets: Get, List
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
Type: System.String[]
Parameter Sets: Get, List
Aliases:

Required: False
Position: Named
Default value: (Get-AzContext).Subscription.Id
Accept pipeline input: False
Accept wildcard characters: False
```

### CommonParameters
This cmdlet supports the common parameters: -Debug, -ErrorAction, -ErrorVariable, -InformationAction, -InformationVariable, -OutVariable, -OutBuffer, -PipelineVariable, -Verbose, -WarningAction, and -WarningVariable. For more information, see [about_CommonParameters](http://go.microsoft.com/fwlink/?LinkID=113216).

## INPUTS

### Microsoft.Azure.PowerShell.Cmdlets.StorageCache.Models.IStorageCacheIdentity

## OUTPUTS

### Microsoft.Azure.PowerShell.Cmdlets.StorageCache.Models.Api20230501.IStorageTarget

## NOTES

## RELATED LINKS

