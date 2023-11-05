---
external help file:
Module Name: Az.StackHCIVm
online version: https://learn.microsoft.com/powershell/module/az.stackhcivm/get-azstackhcivmnetworkinterface
schema: 2.0.0
---

# Get-AzStackHCIVmNetworkInterface

## SYNOPSIS
Gets a network interface

## SYNTAX

```
Get-AzStackHCIVmNetworkInterface [-ResourceId <String>] [<CommonParameters>]
```

## DESCRIPTION
Gets a network interface

## EXAMPLES

### Example 1:  Get a Network Interface
```powershell
Get-AzStackHCIVmNetworkInterface -Name "testNic" -ResourceGroupName "test-rg" 
```

```output
Name            ResourceGroupName
----            -----------------
testNic       test-rg
```

This command gets a specific network interface in the specified resource group.

### Example 2: List all Logical Networks in a Resource Group  
```powershell
Get-AzStackHCIVmNetworkInterface -ResourceGroupName 'test-rg'
```

```output
Name            ResourceGroupName
----            -----------------
testNic       test-rg
```
This command lists all network interfaces in the specified resource group.

## PARAMETERS

### -ResourceId
The ARM Id of the network interface.

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

### Microsoft.Azure.PowerShell.Cmdlets.StackHCIVm.Models.Api20230901Preview.INetworkInterfaces

## NOTES

ALIASES

## RELATED LINKS

