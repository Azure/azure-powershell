---
external help file: Microsoft.Azure.PowerShell.Cmdlets.Network.dll-Help.xml
Module Name: Az.Network
online version: https://docs.microsoft.com/powershell/module/az.network/new-azapplicationgatewayfirewallpolicyexclusionmanagedruleset
schema: 2.0.0
---

# New-AzApplicationGatewayFirewallPolicyExclusionManagedRuleSet

## SYNOPSIS
Creates an ExclusionManagedRuleSet for the firewallPolicy exclusion

## SYNTAX

```
New-AzApplicationGatewayFirewallPolicyExclusionManagedRuleSet -RuleSetType <String> -RuleSetVersion <String>
 [-RuleGroup <PSApplicationGatewayFirewallPolicyExclusionManagedRuleGroup[]>]
 [-DefaultProfile <IAzureContextContainer>] [<CommonParameters>]
```

## DESCRIPTION
The **New-AzApplicationGatewayFirewallPolicyExclusionManagedRuleSet** creates an exclusion managed-ruleset for a firewall policy exclusion.

## EXAMPLES

### Example 1
```powershell
$managedRuleSet = New-AzApplicationGatewayFirewallPolicyExclusionManagedRuleSet -RuleSetType $ruleSetType `
-RuleSetVersion $ruleSetVersion -RuleGroup $ruleGroup1, $ruleGroup2
```

Creates an ExclusionManagedRuleSet with ruleSetType as $ruleSetType, ruleSetVersion as $ruleSetVersion and RuleGroups as a list with entires as $ruleGroup1, $ruleGroup2
The new ExclusionManagedRuleSet is assigned to $managedRuleSet

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

### -RuleGroup
Rule Group Overrides.

```yaml
Type: Microsoft.Azure.Commands.Network.Models.PSApplicationGatewayFirewallPolicyExclusionManagedRuleGroup[]
Parameter Sets: (All)
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -RuleSetType
Specify the RuleSetType in a exclusionManagedRuleSet

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

### -RuleSetVersion
Specify the RuleSetVersion in a exclusionManagedRuleSet

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

### Microsoft.Azure.Commands.Network.Models.PSApplicationGatewayFirewallPolicyExclusionManagedRuleSet

## NOTES

## RELATED LINKS
