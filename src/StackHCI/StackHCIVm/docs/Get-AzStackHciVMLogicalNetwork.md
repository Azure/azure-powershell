---
external help file:
Module Name: Az.StackHCIVm
online version: https://learn.microsoft.com/powershell/module/az.stackhcivm/get-azstackhcivmlogicalnetwork
schema: 2.0.0
---

# Get-AzStackHCIVmLogicalNetwork

## SYNOPSIS
Gets a logical network

## SYNTAX

```
Get-AzStackHCIVmLogicalNetwork [-ResourceId <String>] [<CommonParameters>]
```

## DESCRIPTION
Gets a logical network

## EXAMPLES

### Example 1:  Get a Logical Network
```powershell
Get-AzStackHCIVmLogicalNetwork -Name "testLnet" -ResourceGroupName "test-rg" 
```

```output
Name            ResourceGroupName
----            -----------------
testLnet       test-rg
```

This command gets a specific logical network in the specified resource group.

### Example 2: List all Logical Networks in a Resource Group  
```powershell
Get-AzStackHCIVmImage -ResourceGroupName 'test-rg'
```

```output
Name            ResourceGroupName
----            -----------------
testLnet       test-rg
```
This command lists all logical networks in the specified resource group.

## PARAMETERS

### -ResourceId
The ARM ID of the logical network.

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

### Microsoft.Azure.PowerShell.Cmdlets.StackHCIVm.Models.Api20230901Preview.ILogicalNetworks

## NOTES

ALIASES

## RELATED LINKS

