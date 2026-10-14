---
external help file: Microsoft.Azure.PowerShell.Cmdlets.Compute.dll-Help.xml
Module Name: Az.Compute
online version: https://learn.microsoft.com/powershell/module/az.compute/get-azinterconnectblock
schema: 2.0.0
---

# Get-AzInterconnectBlock

## SYNOPSIS
Gets the properties of an Interconnect Block or lists Interconnect Blocks in a resource group or subscription.

## SYNTAX

### DefaultParameterSet (Default)
```
Get-AzInterconnectBlock [-ResourceGroupName <String>] [-Name <String>] [-Expand <String>]
 [-DefaultProfile <IAzureContextContainer>] [<CommonParameters>]
```

## DESCRIPTION
The **Get-AzInterconnectBlock** cmdlet retrieves properties of an Interconnect Block, or lists Interconnect Blocks within a resource group or the current subscription.

When neither `-ResourceGroupName` nor `-Name` is specified, all Interconnect Blocks in the current subscription are returned.
When only `-ResourceGroupName` is specified, all Interconnect Blocks in that resource group are returned.
When both `-ResourceGroupName` and `-Name` are specified without wildcards, a single Interconnect Block is returned.
Both parameters support wildcard characters, which trigger a list-and-filter operation instead of a direct GET.

## EXAMPLES

### Example 1: Get a specific Interconnect Block
```powershell
Get-AzInterconnectBlock -ResourceGroupName "myRG" -Name "myICB"
```

This command retrieves the Interconnect Block named "myICB" in the resource group "myRG".

### Example 2: Get an Interconnect Block with instance view
```powershell
Get-AzInterconnectBlock -ResourceGroupName "myRG" -Name "myICB" -Expand "instanceView"
```

This command retrieves the Interconnect Block with its runtime instance view, including current capacity and status information.

### Example 3: List Interconnect Blocks by wildcard name
```powershell
Get-AzInterconnectBlock -ResourceGroupName "myRG" -Name "icb*"
```

This command lists all Interconnect Blocks in "myRG" whose name starts with "icb".

### Example 4: List all Interconnect Blocks in a resource group
```powershell
Get-AzInterconnectBlock -ResourceGroupName "myRG"
```

This command lists all Interconnect Blocks in the resource group "myRG".

### Example 5: List all Interconnect Blocks in the subscription
```powershell
Get-AzInterconnectBlock
```

This command lists all Interconnect Blocks in the current subscription.

## PARAMETERS

### -DefaultProfile
The credentials, account, tenant, and subscription used for communication with Azure.

```yaml
Type: Microsoft.Azure.Commands.Common.Authentication.Abstractions.Core.IAzureContextContainer
Parameter Sets: (All)
Aliases: AzContext, AzureRmContext, AzureCredential

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -Expand
The expand expression to apply on the operation. 'instanceView' retrieves a snapshot of the runtime properties of the Interconnect Block.

```yaml
Type: System.String
Parameter Sets: DefaultParameterSet
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: True (ByPropertyName)
Accept wildcard characters: False
```

### -Name
Specifies the name of the Interconnect Block resource. Supports wildcard characters.

```yaml
Type: System.String
Parameter Sets: DefaultParameterSet
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: True (ByPropertyName)
Accept wildcard characters: True
```

### -ResourceGroupName
Specifies the name of a resource group. Supports wildcard characters.

```yaml
Type: System.String
Parameter Sets: DefaultParameterSet
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: True (ByPropertyName)
Accept wildcard characters: True
```

### CommonParameters
This cmdlet supports the common parameters: -Debug, -ErrorAction, -ErrorVariable, -InformationAction, -InformationVariable, -OutVariable, -OutBuffer, -PipelineVariable, -Verbose, -WarningAction, and -WarningVariable. For more information, see [about_CommonParameters](http://go.microsoft.com/fwlink/?LinkID=113216).

## INPUTS

### System.String

## OUTPUTS

### Microsoft.Azure.Commands.Compute.Automation.Models.PSInterconnectBlock

## NOTES

## RELATED LINKS
