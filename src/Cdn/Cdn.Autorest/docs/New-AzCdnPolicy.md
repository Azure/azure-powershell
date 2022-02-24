---
external help file:
Module Name: Az.Cdn
online version: https://docs.microsoft.com/powershell/module/az.cdn/new-azcdnpolicy
schema: 2.0.0
---

# New-AzCdnPolicy

## SYNOPSIS
Create or update policy with specified rule set name within a resource group.

## SYNTAX

```
New-AzCdnPolicy -Name <String> -ResourceGroupName <String> -Location <String> [-SubscriptionId <String>]
 [-CustomRule <ICustomRule[]>] [-Etag <String>] [-ManagedRuleSet <IManagedRuleSet[]>]
 [-PolicySettingDefaultCustomBlockResponseBody <String>]
 [-PolicySettingDefaultCustomBlockResponseStatusCode <Int32>] [-PolicySettingDefaultRedirectUrl <String>]
 [-PolicySettingEnabledState <PolicyEnabledState>] [-PolicySettingMode <PolicyMode>]
 [-RateLimitRule <IRateLimitRule[]>] [-SkuName <SkuName>] [-Tag <Hashtable>] [-DefaultProfile <PSObject>]
 [-AsJob] [-NoWait] [-Confirm] [-WhatIf] [<CommonParameters>]
```

## DESCRIPTION
Create or update policy with specified rule set name within a resource group.

## EXAMPLES

### Example 1: {{ Add title here }}
```powershell
PS C:\> {{ Add code here }}

{{ Add output here }}
```

{{ Add description here }}

### Example 2: {{ Add title here }}
```powershell
PS C:\> {{ Add code here }}

{{ Add output here }}
```

{{ Add description here }}

## PARAMETERS

### -AsJob
Run the command as a job

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

### -CustomRule
List of rules
To construct, see NOTES section for CUSTOMRULE properties and create a hash table.

```yaml
Type: Microsoft.Azure.PowerShell.Cmdlets.Cdn.Models.Api20210601.ICustomRule[]
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
Type: System.Management.Automation.PSObject
Parameter Sets: (All)
Aliases: AzureRMContext, AzureCredential

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -Etag
Gets a unique read-only string that changes whenever the resource is updated.

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

### -Location
Resource location.

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

### -ManagedRuleSet
List of rule sets.
To construct, see NOTES section for MANAGEDRULESET properties and create a hash table.

```yaml
Type: Microsoft.Azure.PowerShell.Cmdlets.Cdn.Models.Api20210601.IManagedRuleSet[]
Parameter Sets: (All)
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -Name
The name of the CdnWebApplicationFirewallPolicy.

```yaml
Type: System.String
Parameter Sets: (All)
Aliases: PolicyName

Required: True
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -NoWait
Run the command asynchronously

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

### -PolicySettingDefaultCustomBlockResponseBody
If the action type is block, customer can override the response body.
The body must be specified in base64 encoding.

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

### -PolicySettingDefaultCustomBlockResponseStatusCode
If the action type is block, this field defines the default customer overridable http response status code.

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

### -PolicySettingDefaultRedirectUrl
If action type is redirect, this field represents the default redirect URL for the client.

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

### -PolicySettingEnabledState
describes if the policy is in enabled state or disabled state

```yaml
Type: Microsoft.Azure.PowerShell.Cmdlets.Cdn.Support.PolicyEnabledState
Parameter Sets: (All)
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -PolicySettingMode
Describes if it is in detection mode or prevention mode at policy level.

```yaml
Type: Microsoft.Azure.PowerShell.Cmdlets.Cdn.Support.PolicyMode
Parameter Sets: (All)
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -RateLimitRule
List of rules
To construct, see NOTES section for RATELIMITRULE properties and create a hash table.

```yaml
Type: Microsoft.Azure.PowerShell.Cmdlets.Cdn.Models.Api20210601.IRateLimitRule[]
Parameter Sets: (All)
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -ResourceGroupName
Name of the Resource group within the Azure subscription.

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

### -SkuName
Name of the pricing tier.

```yaml
Type: Microsoft.Azure.PowerShell.Cmdlets.Cdn.Support.SkuName
Parameter Sets: (All)
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -SubscriptionId
Azure Subscription ID.

```yaml
Type: System.String
Parameter Sets: (All)
Aliases:

Required: False
Position: Named
Default value: (Get-AzContext).Subscription.Id
Accept pipeline input: False
Accept wildcard characters: False
```

### -Tag
Resource tags.

```yaml
Type: System.Collections.Hashtable
Parameter Sets: (All)
Aliases:

Required: False
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
Shows what would happen if the cmdlet runs.
The cmdlet is not run.

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

### Microsoft.Azure.PowerShell.Cmdlets.Cdn.Models.Api20210601.ICdnWebApplicationFirewallPolicy

## NOTES

ALIASES

COMPLEX PARAMETER PROPERTIES

To create the parameters described below, construct a hash table containing the appropriate properties. For information on hash tables, run Get-Help about_Hash_Tables.


CUSTOMRULE <ICustomRule[]>: List of rules
  - `Action <ActionType>`: Describes what action to be applied when rule matches
  - `MatchCondition <IMatchCondition[]>`: List of match conditions.
    - `MatchValue <String[]>`: List of possible match values.
    - `MatchVariable <WafMatchVariable>`: Match variable to compare against.
    - `Operator <Operator>`: Describes operator to be matched
    - `[NegateCondition <Boolean?>]`: Describes if the result of this condition should be negated.
    - `[Selector <String>]`: Selector can used to match a specific key for QueryString, Cookies, RequestHeader or PostArgs.
    - `[Transform <TransformType[]>]`: List of transforms.
  - `Name <String>`: Defines the name of the custom rule
  - `Priority <Int32>`: Defines in what order this rule be evaluated in the overall list of custom rules
  - `[EnabledState <CustomRuleEnabledState?>]`: Describes if the custom rule is in enabled or disabled state. Defaults to Enabled if not specified.

MANAGEDRULESET <IManagedRuleSet[]>: List of rule sets.
  - `RuleSetType <String>`: Defines the rule set type to use.
  - `RuleSetVersion <String>`: Defines the version of the rule set to use.
  - `[AnomalyScore <Int32?>]`: Verizon only : If the rule set supports anomaly detection mode, this describes the threshold for blocking requests.
  - `[RuleGroupOverride <IManagedRuleGroupOverride[]>]`: Defines the rule overrides to apply to the rule set.
    - `RuleGroupName <String>`: Describes the managed rule group within the rule set to override
    - `[Rule <IManagedRuleOverride[]>]`: List of rules that will be disabled. If none specified, all rules in the group will be disabled.
      - `RuleId <String>`: Identifier for the managed rule.
      - `[Action <ActionType?>]`: Describes the override action to be applied when rule matches.
      - `[EnabledState <ManagedRuleEnabledState?>]`: Describes if the managed rule is in enabled or disabled state. Defaults to Disabled if not specified.

RATELIMITRULE <IRateLimitRule[]>: List of rules
  - `Action <ActionType>`: Describes what action to be applied when rule matches
  - `MatchCondition <IMatchCondition[]>`: List of match conditions.
    - `MatchValue <String[]>`: List of possible match values.
    - `MatchVariable <WafMatchVariable>`: Match variable to compare against.
    - `Operator <Operator>`: Describes operator to be matched
    - `[NegateCondition <Boolean?>]`: Describes if the result of this condition should be negated.
    - `[Selector <String>]`: Selector can used to match a specific key for QueryString, Cookies, RequestHeader or PostArgs.
    - `[Transform <TransformType[]>]`: List of transforms.
  - `Name <String>`: Defines the name of the custom rule
  - `Priority <Int32>`: Defines in what order this rule be evaluated in the overall list of custom rules
  - `RateLimitDurationInMinute <Int32>`: Defines rate limit duration. Default is 1 minute.
  - `RateLimitThreshold <Int32>`: Defines rate limit threshold.
  - `[EnabledState <CustomRuleEnabledState?>]`: Describes if the custom rule is in enabled or disabled state. Defaults to Enabled if not specified.

## RELATED LINKS

