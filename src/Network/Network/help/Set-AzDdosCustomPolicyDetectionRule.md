---
external help file: Microsoft.Azure.PowerShell.Cmdlets.Network.dll-Help.xml
Module Name: Az.Network
online version: https://learn.microsoft.com/powershell/module/az.network/set-azddoscustompolicydetectionrule
schema: 2.0.0
---

# Set-AzDdosCustomPolicyDetectionRule

## SYNOPSIS
Updates an existing detection rule on a DDoS custom policy object.

## SYNTAX

```
Set-AzDdosCustomPolicyDetectionRule -DdosCustomPolicy <PSDdosCustomPolicy> -Name <String>
 [-TrafficType <String>] [-PacketsPerSecond <Int32>] [-DefaultProfile <IAzureContextContainer>]
 [-AcquirePolicyToken] [-ChangeReference <String>] [-WhatIf] [-Confirm] [<CommonParameters>]
```

## DESCRIPTION
The **Set-AzDdosCustomPolicyDetectionRule** cmdlet updates an existing detection rule selected by its case-insensitive name. Specify **TrafficType**, **PacketsPerSecond**, or both. Properties that are not specified retain their current values.

The cmdlet updates the supplied policy object. Pass the updated policy to **Set-AzDdosCustomPolicy** to persist the changes to Azure.

## EXAMPLES

### Example 1: Update the packet threshold
```powershell
$policy = Get-AzDdosCustomPolicy -ResourceGroupName "myRG" -Name "myPolicy"
$policy = $policy |
    Set-AzDdosCustomPolicyDetectionRule -Name "tcpRule" -PacketsPerSecond 120000
```

This example updates the packet threshold of `tcpRule` while preserving its traffic type.

### Example 2: Update the traffic type
```powershell
$policy = $policy |
    Set-AzDdosCustomPolicyDetectionRule -Name "tcpRule" -TrafficType TcpSyn
```

This example changes the traffic type of `tcpRule` to `TcpSyn`. A policy can contain only one detection rule for each traffic type.

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

### -DdosCustomPolicy
Specifies the DDoS custom policy object containing the detection rule to update.

```yaml
Type: Microsoft.Azure.Commands.Network.Models.PSDdosCustomPolicy
Parameter Sets: (All)
Aliases:

Required: True
Position: Named
Default value: None
Accept pipeline input: True (ByPropertyName, ByValue)
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

### -Name
Specifies the name of the detection rule to update. Name matching is case-insensitive.

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

### -PacketsPerSecond
Specifies the updated packets per second threshold. If omitted, the existing threshold is preserved.

```yaml
Type: System.Int32
Parameter Sets: (All)
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -TrafficType
Specifies the updated traffic type. Allowed values are `Tcp`, `Udp`, and `TcpSyn`. If omitted, the existing traffic type is preserved.

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

### Microsoft.Azure.Commands.Network.Models.PSDdosCustomPolicy

## OUTPUTS

### Microsoft.Azure.Commands.Network.Models.PSDdosCustomPolicy

## NOTES

## RELATED LINKS

[Get-AzDdosCustomPolicy](Get-AzDdosCustomPolicy.md)

[Set-AzDdosCustomPolicy](Set-AzDdosCustomPolicy.md)

[Get-AzDdosCustomPolicyDetectionRule](Get-AzDdosCustomPolicyDetectionRule.md)

[Add-AzDdosCustomPolicyDetectionRule](Add-AzDdosCustomPolicyDetectionRule.md)

[Remove-AzDdosCustomPolicyDetectionRule](Remove-AzDdosCustomPolicyDetectionRule.md)
