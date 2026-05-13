---
external help file: Microsoft.Azure.PowerShell.Cmdlets.Network.dll-Help.xml
Module Name: Az.Network
online version: https://learn.microsoft.com/powershell/module/az.network/remove-azddoscustompolicydetectionrule
schema: 2.0.0
---

# Remove-AzDdosCustomPolicyDetectionRule

## SYNOPSIS
Removes a detection rule from a DDoS custom policy.

## SYNTAX

```
Remove-AzDdosCustomPolicyDetectionRule -DdosCustomPolicy <PSDdosCustomPolicy> -Name <String>
 [-DefaultProfile <IAzureContextContainer>] [-WhatIf] [-Confirm] [<CommonParameters>]
```

## DESCRIPTION
The **Remove-AzDdosCustomPolicyDetectionRule** cmdlet removes a detection rule from a DDoS custom policy object. After removing the rule, you must use **Set-AzDdosCustomPolicy** to persist the changes to Azure.

This cmdlet operates on the policy object in memory before persisting changes to Azure, similar to how **Remove-AzLoadBalancerRuleConfig** works with load balancer configurations.

## EXAMPLES

### Example 1: Remove a detection rule from a DDoS custom policy
```powershell
$policy = Get-AzDdosCustomPolicy -ResourceGroupName "myRG" -Name "myPolicy"
$policy = $policy | Remove-AzDdosCustomPolicyDetectionRule -Name "udpRule1"
$policy | Set-AzDdosCustomPolicy
```

This example retrieves a DDoS custom policy, removes the UDP detection rule from the policy object, and then persists the changes to Azure.

### Example 2: Remove a detection rule using pipeline
```powershell
Get-AzDdosCustomPolicy -ResourceGroupName "myRG" -Name "myPolicy" |
  Remove-AzDdosCustomPolicyDetectionRule -Name "tcpSynRule1" |
  Set-AzDdosCustomPolicy
```

This example demonstrates the full pipeline for retrieving a policy, removing a specific detection rule by name, and persisting the changes.

### Example 3: Remove a detection rule with WhatIf
```powershell
$policy = Get-AzDdosCustomPolicy -ResourceGroupName "myRG" -Name "myPolicy"
$policy | Remove-AzDdosCustomPolicyDetectionRule -Name "tcpRule1" -WhatIf
```

This example shows how to preview the removal of a detection rule without making any changes to the policy object in memory.

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

### -DdosCustomPolicy
Specifies the DDoS custom policy object from which to remove the detection rule. The object can be retrieved with **Get-AzDdosCustomPolicy**.

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

### -Name
Specifies the name of the detection rule to remove.

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

[New-AzDdosCustomPolicy](New-AzDdosCustomPolicy.md)

[Add-AzDdosCustomPolicyDetectionRule](Add-AzDdosCustomPolicyDetectionRule.md)

[Remove-AzDdosCustomPolicy](Remove-AzDdosCustomPolicy.md)

[Set-AzDdosCustomPolicy](Set-AzDdosCustomPolicy.md)

[New-AzDdosCustomPolicyDetectionRule](New-AzDdosCustomPolicyDetectionRule.md)
