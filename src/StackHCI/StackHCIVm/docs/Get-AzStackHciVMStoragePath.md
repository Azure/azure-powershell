---
external help file:
Module Name: Az.StackHCIVm
online version: https://learn.microsoft.com/powershell/module/az.stackhcivm/get-azstackhcivmstoragepath
schema: 2.0.0
---

# Get-AzStackHCIVmStoragePath

## SYNOPSIS
Gets a storage path

## SYNTAX

```
Get-AzStackHCIVmStoragePath [-ResourceId <String>] [<CommonParameters>]
```

## DESCRIPTION
Gets a storage path

## EXAMPLES

### Example 1: Get a Storage Path
```powershell
Get-AzStackHCIVmStoragePath -Name  "testStoragePath" -ResourceGroupName "test-rg"
```

```output
Name            ResourceGroupName
----            -----------------
testStoragePath       test-rg
```

This command gets a specific storage path in the specified resource group.

### Example 2: List all Storage Paths in a Resource Group
```powershell
Get-AzStackHCIVmStoragePath  -ResourceGroupName "test-rg"
```

```output
Name            ResourceGroupName
----            -----------------
testStoragePath       test-rg
```

This command lists all storage paths in the specified resource group.

## PARAMETERS

### -ResourceId
The ARM  ID of the storage path.

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

### Microsoft.Azure.PowerShell.Cmdlets.StackHCIVm.Models.Api20230901Preview.IStorageContainers

## NOTES

ALIASES

## RELATED LINKS

