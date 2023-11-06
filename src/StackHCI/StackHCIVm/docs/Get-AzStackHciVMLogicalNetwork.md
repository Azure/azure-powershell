---
external help file:
Module Name: Az.StackHCIVm
online version: https://learn.microsoft.com/powershell/module/az.stackhcivm/get-azstackhcivmlogicalnetwork
schema: 2.0.0
---

# Get-AzStackHciVMLogicalNetwork

## SYNOPSIS
Gets a logical network.

## SYNTAX

### List1 (Default)
```
Get-AzStackHciVMLogicalNetwork [-SubscriptionId <String[]>] [-DefaultProfile <PSObject>] [<CommonParameters>]
```

### ByResourceId
```
Get-AzStackHciVMLogicalNetwork [-ResourceId <String>] [<CommonParameters>]
```

### Get
```
Get-AzStackHciVMLogicalNetwork -Name <String> -ResourceGroupName <String> [-SubscriptionId <String[]>]
 [-DefaultProfile <PSObject>] [<CommonParameters>]
```

### List
```
Get-AzStackHciVMLogicalNetwork -ResourceGroupName <String> [-SubscriptionId <String[]>]
 [-DefaultProfile <PSObject>] [<CommonParameters>]
```

## DESCRIPTION
Gets a logical network.

## EXAMPLES

### Example 1:  Get a Logical Network
```powershell
PS C:\> Get-AzStackHCIVmLogicalNetwork -Name "testLnet" -ResourceGroupName "test-rg" 
```

```output
Name            ResourceGroupName
----            -----------------
testLnet       test-rg
```

This command gets a specific logical network in the specified resource group.

### Example 2: List all Logical Networks in a Resource Group  
```powershell
PS C:\> Get-AzStackHCIVmLogicalNetwork -ResourceGroupName 'test-rg'
```

```output
Name            ResourceGroupName
----            -----------------
testLnet       test-rg
```
This command lists all logical networks in the specified resource group.

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
Name of the logical network

```yaml
Type: System.String
Parameter Sets: Get
Aliases: LogicalNetworkName

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
The ARM ID of the logical network.

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

### Microsoft.Azure.PowerShell.Cmdlets.StackHCIVm.Models.Api20230901Preview.ILogicalNetworks

## NOTES

ALIASES

## RELATED LINKS

