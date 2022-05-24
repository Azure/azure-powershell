---
external help file: Microsoft.Azure.PowerShell.Cmdlets.Network.dll-Help.xml
Module Name: Az.Network
online version: https://docs.microsoft.com/powershell/module/az.network/new-azapplicationgatewayfirewallpolicyexclusionmanagedrulegroup
schema: 2.0.0
---

# New-AzApplicationGatewayFirewallPolicyExclusionManagedRuleGroup

## SYNOPSIS
Creates ExclusionManagedRuleGroup entry in ExclusionManagedRuleSets for the firewall policy exclusion.

## SYNTAX

```
New-AzApplicationGatewayFirewallPolicyExclusionManagedRuleGroup -RuleGroupName <String>
 [-Rule <PSApplicationGatewayFirewallPolicyExclusionManagedRule[]>] [-DefaultProfile <IAzureContextContainer>]
 [<CommonParameters>]
```

## DESCRIPTION
The **New-AzApplicationGatewayFirewallPolicyExclusionManagedRuleGroup** creates a exclusionManagedRuleGroup entry in a exclusionManagedRuleSet for a firewall policy exclusion.

## EXAMPLES

### Example 1
```powershell
$ruleGroupEntry = New-AzApplicationGatewayFirewallPolicyExclusionManagedRuleGroup -RuleGroupName $ruleName -Rule $rule1,$rule2
```

Creates an ExclusionManagedRuleGroup entry with group name as $ruleName and Rules as $rule1, $rule2. Assigns the same to $ruleGroupEntry

### Example 2
```powershell
$ruleGroupEntry = New-AzApplicationGatewayFirewallPolicyExclusionManagedRuleGroup -RuleGroupName $ruleName
```

Creates an ExclusionManagedRuleGroup entry with group name as $ruleName. Assigns the same to $ruleGroupEntry

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

### -Rule
List of Rules.

```yaml
Type: Microsoft.Azure.Commands.Network.Models.PSApplicationGatewayFirewallPolicyExclusionManagedRule[]
Parameter Sets: (All)
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -RuleGroupName
Specify the ruleGroupName in a exclusion RuleGroup entry.

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
This cmdlet supports the common parameters: -Debug, -ErrorAction, -ErrorVariable, -InformationAction, -InformationVariable, -OutVariable, -OutBuffer, -PipelineVariable, -Verbose, -WarningAction, and -WarningVariable. For more information, see [about_CommonParameters](http://go.microsoft.com/fwlink/?LinkID=113216).

## INPUTS

### None

## OUTPUTS

### Microsoft.Azure.Commands.Network.Models.PSApplicationGatewayFirewallPolicyExclusionManagedRuleGroup

## NOTES

## RELATED LINKS
