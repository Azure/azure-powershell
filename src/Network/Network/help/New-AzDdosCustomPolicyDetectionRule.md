---
external help file: Microsoft.Azure.PowerShell.Cmdlets.Network.dll-Help.xml
Module Name: Az.Network
online version: https://learn.microsoft.com/powershell/module/az.network/new-azddoscustompolicydetectionrule
schema: 2.0.0
---

# New-AzDdosCustomPolicyDetectionRule

## SYNOPSIS
Creates a DDoS custom policy detection rule.

## SYNTAX

```
New-AzDdosCustomPolicyDetectionRule -Name <String> -TrafficType <String> -PacketsPerSecond <Int32>
 [-DefaultProfile <IAzureContextContainer>] [-WhatIf] [-Confirm]
 [-AcquirePolicyToken] [-ChangeReference <String>] [<CommonParameters>]
```

## DESCRIPTION
The **New-AzDdosCustomPolicyDetectionRule** cmdlet creates a DDoS custom policy detection rule object. This object is used as input to the **New-AzDdosCustomPolicy** cmdlet to specify detection rules for a DDoS custom policy.

## EXAMPLES

### Example 1: Create a TCP detection rule
```powershell
$rule = New-AzDdosCustomPolicyDetectionRule -Name "tcpRule1" -TrafficType Tcp -PacketsPerSecond 1000000
```

This example creates a TCP detection rule with a threshold of 1,000,000 packets per second.

### Example 2: Create multiple detection rules
```powershell
$tcpRule = New-AzDdosCustomPolicyDetectionRule -Name "tcpRule1" -TrafficType Tcp -PacketsPerSecond 1000000
$udpRule = New-AzDdosCustomPolicyDetectionRule -Name "udpRule1" -TrafficType Udp -PacketsPerSecond 100000
$tcpSynRule = New-AzDdosCustomPolicyDetectionRule -Name "tcpSynRule1" -TrafficType TcpSyn -PacketsPerSecond 50000
```

This example creates three detection rules with different traffic types and thresholds.

### Example 3: Use detection rules with New-AzDdosCustomPolicy
```powershell
$rule1 = New-AzDdosCustomPolicyDetectionRule -Name "tcpRule1" -TrafficType Tcp -PacketsPerSecond 1000000
$rule2 = New-AzDdosCustomPolicyDetectionRule -Name "udpRule1" -TrafficType Udp -PacketsPerSecond 100000
$policy = New-AzDdosCustomPolicy -ResourceGroupName "myRG" -Name "myPolicy" -Location "eastus" -DetectionRule @($rule1, $rule2)
```

This example creates two detection rules and uses them to create a new DDoS custom policy.

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

### -Name
Specifies the name of the detection rule.

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
Specifies the packets per second threshold for the DDoS detection rule.

```yaml
Type: System.Int32
Parameter Sets: (All)
Aliases:

Required: True
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -TrafficType
Specifies the traffic type for the DDoS detection rule. The acceptable values for this parameter are:

- Tcp
- Udp
- TcpSyn

```yaml
Type: System.String
Parameter Sets: (All)
Aliases:
Accepted values: Tcp, Udp, TcpSyn

Required: True
Position: Named
Default value: None
Accept pipeline input: False
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
This cmdlet supports the common parameters: -Debug, -ErrorAction, -ErrorVariable, -InformationAction, -InformationVariable, -OutVariable, -OutBuffer, -PipelineVariable, -Verbose, -WarningAction, and -WarningVariable. For more information, see [about_CommonParameters](http://go.microsoft.com/fwlink/?LinkID=113216).

## INPUTS

## OUTPUTS

### Microsoft.Azure.Commands.Network.Models.PSDdosCustomPolicyDetectionRule

## NOTES

## RELATED LINKS

[New-AzDdosCustomPolicy](./New-AzDdosCustomPolicy.md)

[Get-AzDdosCustomPolicy](./Get-AzDdosCustomPolicy.md)

[Remove-AzDdosCustomPolicy](./Remove-AzDdosCustomPolicy.md)
