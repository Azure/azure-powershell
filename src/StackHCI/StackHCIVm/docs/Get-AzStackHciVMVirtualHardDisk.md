---
external help file:
Module Name: Az.StackHCIVm
online version: https://learn.microsoft.com/powershell/module/az.stackhcivm/get-azstackhcivmvirtualharddisk
schema: 2.0.0
---

# Get-AzStackHCIVmVirtualHardDisk

## SYNOPSIS
Gets a virtual hard disk

## SYNTAX

```
Get-AzStackHCIVmVirtualHardDisk [-ResourceId <String>] [<CommonParameters>]
```

## DESCRIPTION
Gets a virtual hard disk

## EXAMPLES

### Example 1: Get a Virtual Hard Disk
```powershell
Get-AzStackHCIVmVirtualHardDisk -Name  "testVhd" -ResourceGroupName "test-rg"
```

```output
Name            ResourceGroupName
----            -----------------
testVhd       test-rg
```

This command gets a specific virtual hard disk in the specified resource group.

### Example 2: List all Virtual Hard Disks in a Resource Group
```powershell
Get-AzStackHCIVmVirtualHardDisk -ResourceGroupName "test-rg"
```

```output
Name            ResourceGroupName
----            -----------------
testVhd       test-rg
```

This command lists all virtual hard disks in the specified resource group.

## PARAMETERS

### -ResourceId
The ARM ID of the virtual hard disk.

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

### Microsoft.Azure.PowerShell.Cmdlets.StackHCIVm.Models.Api20230901Preview.IVirtualHardDisks

## NOTES

ALIASES

## RELATED LINKS

