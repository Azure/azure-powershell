---
external help file:
Module Name: Az.StorageCache
online version: https://learn.microsoft.com/powershell/module/Az.StorageCache/new-AzStorageCacheTargetSpaceAllocationObject
schema: 2.0.0
---

# New-AzStorageCacheTargetSpaceAllocationObject

## SYNOPSIS
Create an in-memory object for StorageTargetSpaceAllocation.

## SYNTAX

```
New-AzStorageCacheTargetSpaceAllocationObject [-AllocationPercentage <Int32>] [-Name <String>]
 [<CommonParameters>]
```

## DESCRIPTION
Create an in-memory object for StorageTargetSpaceAllocation.

## EXAMPLES

### Example 1: Create an in-memory object for StorageTargetSpaceAllocation.
```powershell
New-AzStorageCacheTargetSpaceAllocationObject -AllocationPercentage 100 -Name azps-cachetarget
```

```output
AllocationPercentage Name
-------------------- ----
100                  azps-cachetarget
```

Create an in-memory object for StorageTargetSpaceAllocation.

## PARAMETERS

### -AllocationPercentage
The percentage of cache space allocated for this storage target.

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

### -Name
Name of the storage target.

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

### CommonParameters
This cmdlet supports the common parameters: -Debug, -ErrorAction, -ErrorVariable, -InformationAction, -InformationVariable, -OutVariable, -OutBuffer, -PipelineVariable, -Verbose, -WarningAction, and -WarningVariable. For more information, see [about_CommonParameters](http://go.microsoft.com/fwlink/?LinkID=113216).

## INPUTS

## OUTPUTS

### Microsoft.Azure.PowerShell.Cmdlets.StorageCache.Models.Api20230501.StorageTargetSpaceAllocation

## NOTES

ALIASES

## RELATED LINKS

