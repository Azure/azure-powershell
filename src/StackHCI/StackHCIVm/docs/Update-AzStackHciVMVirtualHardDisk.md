---
external help file:
Module Name: Az.StackHCIVm
online version: https://learn.microsoft.com/powershell/module/az.stackhcivm/update-azstackhcivmvirtualharddisks
schema: 2.0.0
---

# Update-AzStackHCIVmVirtualHardDisk

## SYNOPSIS
The operation to update a virtual hard disk.

## SYNTAX

```
Update-AzStackHCIVmVirtualHardDisk [-ResourceId <String>] [-Tags <Hashtable>] [<CommonParameters>]
```

## DESCRIPTION
The operation to update a virtual hard disk.

## EXAMPLES

### Example 1: Update a Virtual Hard Disk.
```powershell
Update-AzStackHCIVmVirtualHardDisk  -Name "testVhd" -ResourceGroupName "test-rg" -Tags @{TagName = TagValue }
```

```output
Name            ResourceGroupName
----            -----------------
testVhd       test-rg
```

This command updates an exisiting virtual hard disk in the specified resource group.

## PARAMETERS

### -ResourceId
The ARM Resource ID of the virtual hard disk .

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

### -Tags
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

### Microsoft.Azure.PowerShell.Cmdlets.StackHCIVm.Models.Api20230901Preview.IVirtualHardDisks

## NOTES

ALIASES

## RELATED LINKS

