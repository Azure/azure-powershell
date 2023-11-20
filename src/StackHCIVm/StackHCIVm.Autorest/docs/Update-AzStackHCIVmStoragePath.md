---
external help file:
Module Name: Az.StackHCIVM
online version: https://learn.microsoft.com/powershell/module/az.stackhcivm/update-azstackhcivmstoragepath
schema: 2.0.0
---

# Update-AzStackHCIVMStoragePath

## SYNOPSIS
The operation to update a storage path.

## SYNTAX

```
Update-AzStackHCIVMStoragePath [-ResourceId <String>] [-Tag <Hashtable>] [<CommonParameters>]
```

## DESCRIPTION
The operation to update a storage path.

## EXAMPLES

### Example 1: Update a Storage Path.
```powershell
Update-AzStackHCIVMStoragePath  -Name "testVhd" -ResourceGroupName "test-rg" -Tag @{"tagname" = "tagvalue"}
```

```output
Name            ResourceGroupName
----            -----------------
testStoragePath       test-rg
```

This command updates an exisiting storage path in the specified resource group.

## PARAMETERS

### -ResourceId
The ARM Resource ID of the storage path.

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

### -Tag
Resource tags

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

### CommonParameters
This cmdlet supports the common parameters: -Debug, -ErrorAction, -ErrorVariable, -InformationAction, -InformationVariable, -OutVariable, -OutBuffer, -PipelineVariable, -Verbose, -WarningAction, and -WarningVariable. For more information, see [about_CommonParameters](http://go.microsoft.com/fwlink/?LinkID=113216).

## INPUTS

## OUTPUTS

### Microsoft.Azure.PowerShell.Cmdlets.StackHCIVM.Models.Api20230901Preview.IStorageContainers

## NOTES

ALIASES

## RELATED LINKS

