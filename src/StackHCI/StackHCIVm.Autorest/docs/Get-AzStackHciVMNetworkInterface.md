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

### List1 (Default)
```
Get-AzStackHCIVmNetworkInterface [-SubscriptionId <String[]>] [-DefaultProfile <PSObject>]
 [<CommonParameters>]
```

### ByResourceId
```
Get-AzStackHCIVmNetworkInterface [-ResourceId <String>] [<CommonParameters>]
```

### Get
```
Get-AzStackHCIVmNetworkInterface -Name <String> -ResourceGroupName <String> [-SubscriptionId <String[]>]
 [-DefaultProfile <PSObject>] [<CommonParameters>]
```

### List
```
Get-AzStackHCIVmNetworkInterface -ResourceGroupName <String> [-SubscriptionId <String[]>]
 [-DefaultProfile <PSObject>] [<CommonParameters>]
```

## DESCRIPTION
Gets a network interface

## EXAMPLES

### Example 1:  Get a Network Interface
```powershell
PS C:\> Get-AzStackHCIVmNetworkInterface -Name "testNic" -ResourceGroupName "test-rg" 
```

```output
Name            ResourceGroupName
----            -----------------
testNic       test-rg
```

This command gets a specific network interface in the specified resource group.

### Example 2: List all Logical Networks in a Resource Group  
```powershell
PS C:\> Get-AzStackHCIVmNetworkInterface -ResourceGroupName 'test-rg'
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
Parameter Sets: Get, List, List1
Aliases: AzureRMContext, AzureCredential

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -Name
Name of the network interface

```yaml
Type: System.String
Parameter Sets: Get
Aliases: NetworkInterfaceName

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
Parameter Sets: Get, List
Aliases:

Required: True
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -ResourceId
The ARM Id of the network interface.

```yaml
Type: System.String
Parameter Sets: ByResourceId
Aliases:

Required: False
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

## OUTPUTS

### Microsoft.Azure.PowerShell.Cmdlets.StackHCIVm.Models.Api20230901Preview.INetworkInterfaces

## NOTES

ALIASES

## RELATED LINKS

