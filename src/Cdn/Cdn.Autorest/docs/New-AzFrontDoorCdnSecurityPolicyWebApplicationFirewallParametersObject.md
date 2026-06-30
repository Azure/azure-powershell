---
external help file:
Module Name: Az.Cdn
online version: https://learn.microsoft.com/powershell/module/Az.Cdn/new-azfrontdoorcdnsecuritypolicywebapplicationfirewallparametersobject
schema: 2.0.0
---

# New-AzFrontDoorCdnSecurityPolicyWebApplicationFirewallParametersObject

## SYNOPSIS
Create an in-memory object for SecurityPolicyWebApplicationFirewallParameters.

## SYNTAX

```
New-AzFrontDoorCdnSecurityPolicyWebApplicationFirewallParametersObject
 [-Association <ISecurityPolicyWebApplicationFirewallAssociation[]>] [-EmbeddedWafCustomRule <Object[]>]
 [-EmbeddedWafCustomRuleAction <String>] [-EmbeddedWafCustomRuleEnabledState <String>]
 [-EmbeddedWafCustomRuleGroupBy <Object[]>] [-EmbeddedWafCustomRuleMatchCondition <Object[]>]
 [-EmbeddedWafCustomRuleName <String>] [-EmbeddedWafCustomRulePriority <Int32>]
 [-EmbeddedWafCustomRuleRateLimitDurationInMinutes <Int32>] [-EmbeddedWafCustomRuleRateLimitThreshold <Int32>]
 [-EmbeddedWafCustomRuleType <String>] [-EmbeddedWafExclusionSelector <String>]
 [-EmbeddedWafExclusionSelectorMatchOperator <String>] [-EmbeddedWafLogScrubbing <Object>]
 [-EmbeddedWafLogScrubbingRule <Object[]>] [-EmbeddedWafLogScrubbingState <String>]
 [-EmbeddedWafManagedRuleAction <String>] [-EmbeddedWafManagedRuleEnabledState <String>]
 [-EmbeddedWafManagedRuleExclusion <Object[]>] [-EmbeddedWafManagedRuleGroupName <String>]
 [-EmbeddedWafManagedRuleGroupOverride <Object[]>] [-EmbeddedWafManagedRuleId <String>]
 [-EmbeddedWafManagedRuleOverride <Object[]>] [-EmbeddedWafManagedRuleSet <Object[]>]
 [-EmbeddedWafManagedRuleSetAction <String>] [-EmbeddedWafManagedRuleSetType <String>]
 [-EmbeddedWafManagedRuleSetVersion <String>] [-EmbeddedWafMatchOperator <String>]
 [-EmbeddedWafMatchSelector <String>] [-EmbeddedWafMatchValue <String[]>] [-EmbeddedWafMatchVariable <String>]
 [-EmbeddedWafNegateCondition <Boolean>] [-EmbeddedWafPolicySetting <Object>]
 [-EmbeddedWafPolicySettingCaptchaExpirationInMinutes <Int32>]
 [-EmbeddedWafPolicySettingCustomBlockResponseBody <String>]
 [-EmbeddedWafPolicySettingCustomBlockResponseStatusCode <Int32>]
 [-EmbeddedWafPolicySettingEnabledState <String>]
 [-EmbeddedWafPolicySettingJavascriptChallengeExpirationInMinutes <Int32>]
 [-EmbeddedWafPolicySettingMode <String>] [-EmbeddedWafPolicySettingRedirectUrl <String>]
 [-EmbeddedWafPolicySettingRequestBodyCheck <String>] [-EmbeddedWafPolicySkuName <String>]
 [-EmbeddedWafTransform <String[]>] [-IsProfileLevel <Boolean>] [-Type <String>] [-WafPolicy <Object>]
 [-WafPolicyId <String>] [<CommonParameters>]
```

## DESCRIPTION
Create an in-memory object for SecurityPolicyWebApplicationFirewallParameters.

Embedded WAF compatibility parameters are accepted to keep the 2025-09 preview help surface visible, but are ignored by this 2026 API version.

## EXAMPLES

### Example 1: Create an in-memory object for AzureFrontDoor SecurityPolicyWebApplicationFirewallAssociation
```powershell
$endpoint = Get-AzFrontDoorCdnEndpoint -ResourceGroupName testps-rg-da16jm -ProfileName fdp-v542q6 -EndpointName end001
$association = New-AzFrontDoorCdnSecurityPolicyWebApplicationFirewallAssociationObject -PatternsToMatch @("/*") -Domain @(@{"Id"=$($endpoint.Id)})
New-AzFrontDoorCdnSecurityPolicyWebApplicationFirewallParametersObject  -Association  $association `
            -WafPolicyId $wafPolicyId
```

```output
Association
-----------
{{...
```

Create an in-memory object for AzureFrontDoor SecurityPolicyWebApplicationFirewallAssociation

## PARAMETERS

### -Association
Waf associations.

```yaml
Type: Microsoft.Azure.PowerShell.Cmdlets.Cdn.Models.ISecurityPolicyWebApplicationFirewallAssociation[]
Parameter Sets: (All)
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -EmbeddedWafCustomRule
Embedded WAF custom rules.
This compatibility parameter is accepted for help surface and ignored.

```yaml
Type: System.Object[]
Parameter Sets: (All)
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -EmbeddedWafCustomRuleAction
Embedded WAF custom rule action.
This compatibility parameter is accepted for help surface and ignored.

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

### -EmbeddedWafCustomRuleEnabledState
Embedded WAF custom rule enabled state.
This compatibility parameter is accepted for help surface and ignored.

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

### -EmbeddedWafCustomRuleGroupBy
Embedded WAF custom rule group-by variables.
This compatibility parameter is accepted for help surface and ignored.

```yaml
Type: System.Object[]
Parameter Sets: (All)
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -EmbeddedWafCustomRuleMatchCondition
Embedded WAF custom rule match conditions.
This compatibility parameter is accepted for help surface and ignored.

```yaml
Type: System.Object[]
Parameter Sets: (All)
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -EmbeddedWafCustomRuleName
Embedded WAF custom rule name.
This compatibility parameter is accepted for help surface and ignored.

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

### -EmbeddedWafCustomRulePriority
Embedded WAF custom rule priority.
This compatibility parameter is accepted for help surface and ignored.

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

### -EmbeddedWafCustomRuleRateLimitDurationInMinutes
Embedded WAF custom rule rate limit duration in minutes.
This compatibility parameter is accepted for help surface and ignored.

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

### -EmbeddedWafCustomRuleRateLimitThreshold
Embedded WAF custom rule rate limit threshold.
This compatibility parameter is accepted for help surface and ignored.

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

### -EmbeddedWafCustomRuleType
Embedded WAF custom rule type.
This compatibility parameter is accepted for help surface and ignored.

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

### -EmbeddedWafExclusionSelector
Embedded WAF exclusion selector.
This compatibility parameter is accepted for help surface and ignored.

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

### -EmbeddedWafExclusionSelectorMatchOperator
Embedded WAF exclusion selector match operator.
This compatibility parameter is accepted for help surface and ignored.

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

### -EmbeddedWafLogScrubbing
Embedded WAF log scrubbing object.
This compatibility parameter is accepted for help surface and ignored.

```yaml
Type: System.Object
Parameter Sets: (All)
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -EmbeddedWafLogScrubbingRule
Embedded WAF log scrubbing rules.
This compatibility parameter is accepted for help surface and ignored.

```yaml
Type: System.Object[]
Parameter Sets: (All)
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -EmbeddedWafLogScrubbingState
Embedded WAF log scrubbing state.
This compatibility parameter is accepted for help surface and ignored.

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

### -EmbeddedWafManagedRuleAction
Embedded WAF managed rule action.
This compatibility parameter is accepted for help surface and ignored.

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

### -EmbeddedWafManagedRuleEnabledState
Embedded WAF managed rule enabled state.
This compatibility parameter is accepted for help surface and ignored.

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

### -EmbeddedWafManagedRuleExclusion
Embedded WAF managed rule exclusions.
This compatibility parameter is accepted for help surface and ignored.

```yaml
Type: System.Object[]
Parameter Sets: (All)
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -EmbeddedWafManagedRuleGroupName
Embedded WAF managed rule group name.
This compatibility parameter is accepted for help surface and ignored.

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

### -EmbeddedWafManagedRuleGroupOverride
Embedded WAF managed rule group overrides.
This compatibility parameter is accepted for help surface and ignored.

```yaml
Type: System.Object[]
Parameter Sets: (All)
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -EmbeddedWafManagedRuleId
Embedded WAF managed rule ID.
This compatibility parameter is accepted for help surface and ignored.

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

### -EmbeddedWafManagedRuleOverride
Embedded WAF managed rule overrides.
This compatibility parameter is accepted for help surface and ignored.

```yaml
Type: System.Object[]
Parameter Sets: (All)
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -EmbeddedWafManagedRuleSet
Embedded WAF managed rule sets.
This compatibility parameter is accepted for help surface and ignored.

```yaml
Type: System.Object[]
Parameter Sets: (All)
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -EmbeddedWafManagedRuleSetAction
Embedded WAF managed rule set action.
This compatibility parameter is accepted for help surface and ignored.

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

### -EmbeddedWafManagedRuleSetType
Embedded WAF managed rule set type.
This compatibility parameter is accepted for help surface and ignored.

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

### -EmbeddedWafManagedRuleSetVersion
Embedded WAF managed rule set version.
This compatibility parameter is accepted for help surface and ignored.

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

### -EmbeddedWafMatchOperator
Embedded WAF match operator.
This compatibility parameter is accepted for help surface and ignored.

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

### -EmbeddedWafMatchSelector
Embedded WAF match selector.
This compatibility parameter is accepted for help surface and ignored.

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

### -EmbeddedWafMatchValue
Embedded WAF match values.
This compatibility parameter is accepted for help surface and ignored.

```yaml
Type: System.String[]
Parameter Sets: (All)
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -EmbeddedWafMatchVariable
Embedded WAF match variable.
This compatibility parameter is accepted for help surface and ignored.

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

### -EmbeddedWafNegateCondition
Embedded WAF negate condition flag.
This compatibility parameter is accepted for help surface and ignored.

```yaml
Type: System.Boolean
Parameter Sets: (All)
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -EmbeddedWafPolicySetting
Embedded WAF policy settings object.
This compatibility parameter is accepted for help surface and ignored.

```yaml
Type: System.Object
Parameter Sets: (All)
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -EmbeddedWafPolicySettingCaptchaExpirationInMinutes
Embedded WAF captcha expiration in minutes.
This compatibility parameter is accepted for help surface and ignored.

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

### -EmbeddedWafPolicySettingCustomBlockResponseBody
Embedded WAF policy custom block response body.
This compatibility parameter is accepted for help surface and ignored.

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

### -EmbeddedWafPolicySettingCustomBlockResponseStatusCode
Embedded WAF policy custom block response status code.
This compatibility parameter is accepted for help surface and ignored.

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

### -EmbeddedWafPolicySettingEnabledState
Embedded WAF policy enabled state.
This compatibility parameter is accepted for help surface and ignored.

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

### -EmbeddedWafPolicySettingJavascriptChallengeExpirationInMinutes
Embedded WAF JavaScript challenge expiration in minutes.
This compatibility parameter is accepted for help surface and ignored.

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

### -EmbeddedWafPolicySettingMode
Embedded WAF policy mode.
This compatibility parameter is accepted for help surface and ignored.

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

### -EmbeddedWafPolicySettingRedirectUrl
Embedded WAF policy redirect URL.
This compatibility parameter is accepted for help surface and ignored.

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

### -EmbeddedWafPolicySettingRequestBodyCheck
Embedded WAF policy request body check setting.
This compatibility parameter is accepted for help surface and ignored.

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

### -EmbeddedWafPolicySkuName
Embedded WAF policy SKU name.
This compatibility parameter is accepted for help surface and ignored.

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

### -EmbeddedWafTransform
Embedded WAF match transforms.
This compatibility parameter is accepted for help surface and ignored.

```yaml
Type: System.String[]
Parameter Sets: (All)
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -IsProfileLevel
Indicates if this is a profile-level WAF policy.

```yaml
Type: System.Boolean
Parameter Sets: (All)
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -Type
The type of the security policy.
This compatibility parameter is accepted for 2025-09 embedded WAF help surface and ignored.

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

### -WafPolicy
Embedded Web Application Firewall policy object.
This compatibility parameter is accepted for help surface and ignored.

```yaml
Type: System.Object
Parameter Sets: (All)
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -WafPolicyId
Resource ID.

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

## OUTPUTS

### Microsoft.Azure.PowerShell.Cmdlets.Cdn.Models.SecurityPolicyWebApplicationFirewallParameters

## NOTES

## RELATED LINKS

