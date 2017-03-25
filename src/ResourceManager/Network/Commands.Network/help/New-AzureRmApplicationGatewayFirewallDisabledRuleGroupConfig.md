---
external help file: Microsoft.Azure.Commands.Network.dll-Help.xml
online version: 
schema: 2.0.0
---

# New-AzureRmApplicationGatewayFirewallDisabledRuleGroupConfig

## SYNOPSIS
Creates a new disabled rule group configuration.

## SYNTAX

```
New-AzureRmApplicationGatewayFirewallDisabledRuleGroupConfig -RuleGroupName <String>
 [-Rules <System.Collections.Generic.List`1[System.Int32]>]
```

## DESCRIPTION
The **New-AzureRmApplicationGatewayFirewallDisabledRuleGroupConfig** cmdlet creates a new disabled rule group configuration.

## EXAMPLES

### Example 1
```
PS C:\> $disabledRuleGroup1 = New-AzureRmApplicationGatewayFirewallDisabledRuleGroupConfig -RuleGroupName "crs_41_sql_injection_attacks" -Rules 981318,981320

```

The command creates a new disabled rule group configuration for the rule group named "crs_41_sql_injection_attacks" with rule 981318 and rule 981320 being disabled. The new disabled rule group configuration is saved in $disabledRuleGroup1.

## PARAMETERS

### -RuleGroupName
The name of the rule group that will be disabled.

```yaml
Type: String
Parameter Sets: (All)
Aliases: 

Required: True
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -Rules
The list of rules that will be disabled.
If null, all rules of the rule group will be disabled.

```yaml
Type: System.Collections.Generic.List`1[System.Int32]
Parameter Sets: (All)
Aliases: 

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

## INPUTS

### None


## OUTPUTS

### Microsoft.Azure.Commands.Network.Models.PSApplicationGatewayFirewallDisabledRuleGroup


## NOTES

## RELATED LINKS

[New-AzureRmApplicationGatewayWebApplicationFirewallConfiguration](./New-AzureRmApplicationGatewayWebApplicationFirewallConfiguration.md)

[Set-AzureRmApplicationGatewayWebApplicationFirewallConfiguration](./Set-AzureRmApplicationGatewayWebApplicationFirewallConfiguration.md)

