---
external help file:
Module Name: Az.StorageCache
online version: https://learn.microsoft.com/powershell/module/az.storagecache/get-azstoragecache
schema: 2.0.0
---

# Get-AzStorageCache

## SYNOPSIS
Returns a cache.

## SYNTAX

### List (Default)
```
Get-AzStorageCache [-SubscriptionId <String[]>] [-DefaultProfile <PSObject>] [<CommonParameters>]
```

### Get
```
Get-AzStorageCache -Name <String> -ResourceGroupName <String> [-SubscriptionId <String[]>]
 [-DefaultProfile <PSObject>] [<CommonParameters>]
```

### GetViaIdentity
```
Get-AzStorageCache -InputObject <IStorageCacheIdentity> [-DefaultProfile <PSObject>] [<CommonParameters>]
```

### List1
```
Get-AzStorageCache -ResourceGroupName <String> [-SubscriptionId <String[]>] [-DefaultProfile <PSObject>]
 [<CommonParameters>]
```

## DESCRIPTION
Returns a cache.

## EXAMPLES

### Example 1: List storage cache by subscription.
```powershell
Get-AzStorageCache
```

```output
Location Name              ResourceGroupName
-------- ----              -----------------
eastus   azps-storagecache azps_test_gp_storagecache
```

List storage cache by subscription.

### Example 2: List storage cache by resource group name.
```powershell
Get-AzStorageCache -ResourceGroupName azps_test_gp_storagecache
```

```output
Location Name              ResourceGroupName
-------- ----              -----------------
eastus   azps-storagecache azps_test_gp_storagecache
```

List storage cache by resource group name.

### Example 3: Get a storage cache by name.
```powershell
Get-AzStorageCache -ResourceGroupName azps_test_gp_storagecache -Name azps-storagecache
```

```output
Location Name              ResourceGroupName
-------- ----              -----------------
eastus   azps-storagecache azps_test_gp_storagecache
```

Get a storage cache by name.

## PARAMETERS

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
Name of cache.
Length of name must not be greater than 80 and chars must be from the [-0-9a-zA-Z_] char class.

```yaml
Type: System.String
Parameter Sets: Get
Aliases: CacheName

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
Parameter Sets: Get, List1
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
Parameter Sets: Get, List, List1
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

### Microsoft.Azure.PowerShell.Cmdlets.StorageCache.Models.Api20230501.ICache

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

