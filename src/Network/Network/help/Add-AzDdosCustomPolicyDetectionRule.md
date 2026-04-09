---
external help file: Microsoft.Azure.PowerShell.Cmdlets.Network.dll-Help.xml
Module Name: Az.Network
online version: https://learn.microsoft.com/powershell/module/az.network/add-azddoscustompolicydetectionrule
schema: 2.0.0
---

# Add-AzDdosCustomPolicyDetectionRule

## SYNOPSIS
Adds a detection rule to an in-memory DDoS custom policy.

## SYNTAX

```
Add-AzDdosCustomPolicyDetectionRule -DdosCustomPolicy <PSDdosCustomPolicy> -Name <String> -TrafficType <String>
 -PacketsPerSecond <Int32> [-DefaultProfile <IAzureContextContainer>] [-WhatIf] [-Confirm]
 [<CommonParameters>]
```

## DESCRIPTION
The **Add-AzDdosCustomPolicyDetectionRule** cmdlet adds a detection rule to a DDoS custom policy object in memory. After adding the rule, use **Set-AzDdosCustomPolicy** to persist the updated policy to Azure.

This follows the same mutation-on-parent workflow used by Load Balancer child configuration cmdlets, where the child configuration is added to the local parent object first and then saved with the parent **Set** cmdlet.

## EXAMPLES

### Example 1: Add a detection rule and persist the change
```powershell
Get-AzDdosCustomPolicy -ResourceGroupName "myRG" -Name "myPolicy" |
  Add-AzDdosCustomPolicyDetectionRule -Name "tcpSynRule1" -TrafficType TcpSyn -PacketsPerSecond 50000 |
  Set-AzDdosCustomPolicy
```

This example gets an existing DDoS custom policy, adds a TCP SYN detection rule to the in-memory policy object, and then persists the updated policy to Azure.

### Example 2: Add a detection rule to a local policy object
```powershell
$policy = Get-AzDdosCustomPolicy -ResourceGroupName "myRG" -Name "myPolicy"
$updatedPolicy = $policy | Add-AzDdosCustomPolicyDetectionRule -Name "udpRule1" -TrafficType Udp -PacketsPerSecond 100000
```

This example updates only the local policy object. The change is not sent to Azure until **Set-AzDdosCustomPolicy** is called.

### Example 3: Preview an add operation
```powershell
$policy = Get-AzDdosCustomPolicy -ResourceGroupName "myRG" -Name "myPolicy"
$policy | Add-AzDdosCustomPolicyDetectionRule -Name "tcpRule1" -TrafficType Tcp -PacketsPerSecond 1000000 -WhatIf
```

This example shows the add operation without applying the change.

## PARAMETERS

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

### -DdosCustomPolicy
Specifies the DDoS custom policy object to update in memory.

```yaml
Type: Microsoft.Azure.Commands.Network.Models.PSDdosCustomPolicy
Parameter Sets: (All)
Aliases:

Required: True
Position: Named
Default value: None
Accept pipeline input: True (ByValue)
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
Specifies the name of the detection rule to add.

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
Specifies the packets-per-second threshold for the detection rule being added.

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
Specifies the traffic type for the detection rule. Accepted values are Tcp, Udp, and TcpSyn.

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
This cmdlet supports the common parameters: -Debug, -ErrorAction, -ErrorActionPreference, -ErrorVariable, -InformationAction, -InformationVariable, -OutBuffer, -OutVariable, -PipelineVariable, -Verbose, -WarningAction, and -WarningVariable. For more information, see [about_CommonParameters](http://go.microsoft.com/fwlink/?LinkID=113216).

## INPUTS

### Microsoft.Azure.Commands.Network.Models.PSDdosCustomPolicy

## OUTPUTS

### Microsoft.Azure.Commands.Network.Models.PSDdosCustomPolicy

## NOTES

## RELATED LINKS

[Get-AzDdosCustomPolicy](Get-AzDdosCustomPolicy.md)

[Set-AzDdosCustomPolicy](Set-AzDdosCustomPolicy.md)

[Remove-AzDdosCustomPolicyDetectionRule](Remove-AzDdosCustomPolicyDetectionRule.md)

[New-AzDdosCustomPolicyDetectionRule](New-AzDdosCustomPolicyDetectionRule.md)