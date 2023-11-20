---
external help file:
Module Name: Az.StackHCIVM
online version: https://learn.microsoft.com/powershell/module/az.stackhcivm/get-azstackhcivmvirtualharddisk
schema: 2.0.0
---

# Get-AzStackHCIVMVirtualHardDisk

## SYNOPSIS
Gets a virtual hard disk

## SYNTAX

```
Get-AzStackHCIVMVirtualHardDisk [-ResourceId <String>] [-DefaultProfile <PSObject>] [-NoWait]
 [<CommonParameters>]
```

## DESCRIPTION
Gets a virtual hard disk

## EXAMPLES

### Example 1: Get a Virtual Hard Disk
```powershell
Get-AzStackHCIVMVirtualHardDisk -Name  "testVhd" -ResourceGroupName "test-rg"
```

```output
Name            ResourceGroupName
----            -----------------
testVhd       test-rg
```

This command gets a specific virtual hard disk in the specified resource group.

### Example 2: List all Virtual Hard Disks in a Resource Group
```powershell
Get-AzStackHCIVMVirtualHardDisk -ResourceGroupName "test-rg"
```

```output
Name            ResourceGroupName
----            -----------------
testVhd       test-rg
```

This command lists all virtual hard disks in the specified resource group.

## PARAMETERS

### -DefaultProfile
The credentials, account, tenant, and subscription used for communication with Azure.

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

### Microsoft.Azure.PowerShell.Cmdlets.StackHCIVM.Models.Api20230901Preview.IVirtualHardDisks

## NOTES

ALIASES

## RELATED LINKS

