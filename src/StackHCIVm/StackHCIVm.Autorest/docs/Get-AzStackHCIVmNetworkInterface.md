---
external help file:
Module Name: Az.StackHCIVM
online version: https://learn.microsoft.com/powershell/module/az.stackhcivm/get-azstackhcivmnetworkinterface
schema: 2.0.0
---

# Get-AzStackHCIVMNetworkInterface

## SYNOPSIS
Gets a network interface

## SYNTAX

```
Get-AzStackHCIVMNetworkInterface [-ResourceId <String>] [-DefaultProfile <PSObject>] [-NoWait]
 [<CommonParameters>]
```

## DESCRIPTION
Gets a network interface

## EXAMPLES

### Example 1:  Get a Network Interface
```powershell
Get-AzStackHCIVMNetworkInterface -Name 'testNic' -ResourceGroupName 'test-rg' 
```

```output
Name            ResourceGroupName
----            -----------------
testNic       test-rg
```

This command gets a specific network interface in the specified resource group.

### Example 2: List all Logical Networks in a Resource Group  
```powershell
Get-AzStackHCIVMNetworkInterface -ResourceGroupName 'test-rg'
```

```output
Name            ResourceGroupName
----            -----------------
testNic       test-rg
```
This command lists all network interfaces in the specified resource group.

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

### Microsoft.Azure.PowerShell.Cmdlets.StackHCIVM.Models.Api20230901Preview.INetworkInterfaces

## NOTES

ALIASES

## RELATED LINKS

