---
external help file: Microsoft.Azure.PowerShell.Cmdlets.Network.dll-Help.xml
Module Name: Az.Network
online version: https://learn.microsoft.com/powershell/module/az.network/new-azapplicationgatewayfirewallpolicymanagedruleoverride
schema: 2.0.0
---

# New-AzApplicationGatewayFirewallPolicyManagedRuleOverride

## SYNOPSIS
Creates a managedRuleOverride entry for RuleGroupOverrideGroup entry.

## SYNTAX

```
New-AzApplicationGatewayFirewallPolicyManagedRuleOverride -RuleId <String> [-State <String>] [-Action <String>]
 [-Sensitivity <String>] [-DefaultProfile <IAzureContextContainer>] [<CommonParameters>]
```

## DESCRIPTION
The **New-AzApplicationGatewayFirewallPolicyManagedRuleOverride** creates a ruleOverride entry.

## EXAMPLES

### Example 1
```powershell
$ruleOverrideEntry = New-AzApplicationGatewayFirewallPolicyManagedRuleOverride -RuleId $ruleId -State Disabled
```

Creates a ruleOverride Entry with RuleId as $ruleId and State as Disabled.

### Example 2
```powershell
$ruleOverrideEntry = New-AzApplicationGatewayFirewallPolicyManagedRuleOverride -RuleId $ruleId -State Enabled -Action Log
```

Creates a ruleOverride Entry with RuleId as $ruleId, State as Enabled and Action as Log.

### Example 3
```powershell
$ruleOverrideEntry = New-AzApplicationGatewayFirewallPolicyManagedRuleOverride -RuleId $ruleId -State Enabled -Action Log -Sensitivity Low
```

Creates a ruleOverride Entry with RuleId as $ruleId, State as Enabled, Action as Log and Sensitivity as Low.

## PARAMETERS

### -Action
Specify the Action in override rule entry.

```yaml
Type: System.String
Parameter Sets: (All)
Aliases:
Accepted values: AnomalyScoring, Allow, Block, Log

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

### -RuleId
Specify the RuleId in override rule entry.

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

### -Sensitivity
Describes the override sensitivity to be applied when rule matches.

```yaml
Type: System.String
Parameter Sets: (All)
Aliases:
Accepted values: None, Low, Medium, High

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -State
Specify the RuleId in override rule entry.

```yaml
Type: System.String
Parameter Sets: (All)
Aliases:
Accepted values: Disabled, Enabled

Required: False
Position: Named
Default value: Disabled
Accept pipeline input: False
Accept wildcard characters: False
```

### CommonParameters
This cmdlet supports the common parameters: -Debug, -ErrorAction, -ErrorVariable, -InformationAction, -InformationVariable, -OutVariable, -OutBuffer, -PipelineVariable, -Verbose, -WarningAction, and -WarningVariable. For more information, see [about_CommonParameters](http://go.microsoft.com/fwlink/?LinkID=113216).

## INPUTS

### None

## OUTPUTS

### Microsoft.Azure.Commands.Network.Models.PSApplicationGatewayFirewallPolicyManagedRuleOverride

## NOTES

## RELATED LINKS
