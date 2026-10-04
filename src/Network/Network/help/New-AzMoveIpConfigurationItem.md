---
external help file: Microsoft.Azure.PowerShell.Cmdlets.Network.dll-Help.xml
Module Name: Az.Network
online version: https://learn.microsoft.com/powershell/module/az.network/new-azmoveipconfigurationitem
schema: 2.0.0
---

# New-AzMoveIpConfigurationItem

## SYNOPSIS
Creates a source and target IP configuration pair for a move operation.

## SYNTAX

```
New-AzMoveIpConfigurationItem -SourceIpConfigurationId <String> -TargetIpConfigurationId <String>
 [-DefaultProfile <IAzureContextContainer>] [-AcquirePolicyToken]
 [-ChangeReference <String>] [<CommonParameters>]
```

## DESCRIPTION
The **New-AzMoveIpConfigurationItem** cmdlet creates an in-memory object that identifies
the secondary IP configuration to move and the destination IP configuration. Pass one or
more of these objects to `Move-AzVirtualNetworkIpConfiguration`.

## EXAMPLES

### Example 1: Create an IP configuration move item

```powershell
$sourceId = "/subscriptions/00000000-0000-0000-0000-000000000000/resourceGroups/rg1/providers/Microsoft.Network/networkInterfaces/sourceNic/ipConfigurations/ipconfig1"
$targetId = "/subscriptions/00000000-0000-0000-0000-000000000000/resourceGroups/rg1/providers/Microsoft.Network/networkInterfaces/targetNic/ipConfigurations/ipconfig2"

New-AzMoveIpConfigurationItem -SourceIpConfigurationId $sourceId -TargetIpConfigurationId $targetId
```

```output
SourceIpConfigurationId TargetIpConfigurationId
----------------------- -----------------------
.../sourceNic/...       .../targetNic/...
```

Creates an object that pairs the source secondary IP configuration with its destination.

## PARAMETERS

### -AcquirePolicyToken
Acquire an Azure Policy token automatically for this resource operation.

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

### -ChangeReference
The change reference resource ID for this resource operation.

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

### -SourceIpConfigurationId
The Azure Resource Manager resource ID of the secondary IP configuration to move.

```yaml
Type: System.String
Parameter Sets: (All)
Aliases:

Required: True
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -TargetIpConfigurationId
The Azure Resource Manager resource ID of the destination IP configuration.

```yaml
Type: System.String
Parameter Sets: (All)
Aliases:

Required: True
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### CommonParameters
This cmdlet supports the common parameters: -Debug, -ErrorAction, -ErrorVariable,
-InformationAction, -InformationVariable, -OutVariable, -OutBuffer, -PipelineVariable,
-Verbose, -WarningAction, and -WarningVariable. For more information, see
[about_CommonParameters](http://go.microsoft.com/fwlink/?LinkID=113216).

## INPUTS

### None

## OUTPUTS

### Microsoft.Azure.Commands.Network.Models.PSMoveIpConfigurationItem

## NOTES

## RELATED LINKS

[Move-AzVirtualNetworkIpConfiguration](Move-AzVirtualNetworkIpConfiguration.md)
