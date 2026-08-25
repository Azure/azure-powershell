---
external help file: Microsoft.Azure.PowerShell.Cmdlets.Network.dll-Help.xml
Module Name: Az.Network
online version: https://learn.microsoft.com/powershell/module/az.network/move-azvirtualnetworkipconfiguration
schema: 2.0.0
---

# Move-AzVirtualNetworkIpConfiguration

## SYNOPSIS
Moves secondary IP configurations between network interfaces.

## SYNTAX

```
Move-AzVirtualNetworkIpConfiguration -ResourceGroupName <String> -VirtualNetworkName <String>
 -MoveIpConfigurationItem <PSMoveIpConfigurationItem[]> [-AsJob] [-PassThru]
 [-DefaultProfile <IAzureContextContainer>] [-ProgressAction <ActionPreference>] [-WhatIf] [-Confirm]
 [-AcquirePolicyToken] [-ChangeReference <String>] [<CommonParameters>]
```

## DESCRIPTION
The **Move-AzVirtualNetworkIpConfiguration** cmdlet moves one or more secondary private
IP configurations to destination network interfaces. Create each source and target pair
with `New-AzMoveIpConfigurationItem`, and specify the virtual network that contains the
IP configurations.

The operation is long-running. Use `AsJob` to run it in the background.

## EXAMPLES

### Example 1: Move a secondary IP configuration

```powershell
$sourceId = "/subscriptions/00000000-0000-0000-0000-000000000000/resourceGroups/rg1/providers/Microsoft.Network/networkInterfaces/sourceNic/ipConfigurations/ipconfig1"
$targetId = "/subscriptions/00000000-0000-0000-0000-000000000000/resourceGroups/rg1/providers/Microsoft.Network/networkInterfaces/targetNic/ipConfigurations/ipconfig2"
$moveItem = New-AzMoveIpConfigurationItem -SourceIpConfigurationId $sourceId -TargetIpConfigurationId $targetId

Move-AzVirtualNetworkIpConfiguration -ResourceGroupName "rg1" -VirtualNetworkName "vnet1" `
    -MoveIpConfigurationItem $moveItem -PassThru
```

```output
True
```

Moves the specified secondary IP configuration and returns `True` after the operation
completes.

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

### -AsJob
Runs the cmdlet in the background and returns a job that tracks the operation.

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

### -MoveIpConfigurationItem
The source and target IP configuration pairs to move. Create each item with
`New-AzMoveIpConfigurationItem`.

```yaml
Type: Microsoft.Azure.Commands.Network.Models.PSMoveIpConfigurationItem[]
Parameter Sets: (All)
Aliases:

Required: True
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -PassThru
Returns `True` when the operation completes. By default, this cmdlet does not generate
output.

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

### -ProgressAction
{{ Fill ProgressAction Description }}

```yaml
Type: System.Management.Automation.ActionPreference
Parameter Sets: (All)
Aliases: proga

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -ResourceGroupName
The name of the resource group that contains the virtual network.

```yaml
Type: System.String
Parameter Sets: (All)
Aliases:

Required: True
Position: Named
Default value: None
Accept pipeline input: True (ByPropertyName)
Accept wildcard characters: False
```

### -VirtualNetworkName
The name of the virtual network that contains the IP configurations.

```yaml
Type: System.String
Parameter Sets: (All)
Aliases:

Required: True
Position: Named
Default value: None
Accept pipeline input: True (ByPropertyName)
Accept wildcard characters: False
```

### -Confirm
Prompts you for confirmation before running the cmdlet.

```yaml
Type: System.Management.Automation.SwitchParameter
Parameter Sets: (All)
Aliases: cf

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -WhatIf
Shows what would happen if the cmdlet runs. The cmdlet is not run.

```yaml
Type: System.Management.Automation.SwitchParameter
Parameter Sets: (All)
Aliases: wi

Required: False
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

### System.String

## OUTPUTS

### System.Boolean

## NOTES

## RELATED LINKS

[New-AzMoveIpConfigurationItem](New-AzMoveIpConfigurationItem.md)
