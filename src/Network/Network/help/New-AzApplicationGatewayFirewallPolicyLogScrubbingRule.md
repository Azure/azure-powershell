---
external help file: Microsoft.Azure.PowerShell.Cmdlets.Network.dll-Help.xml
Module Name: Az.Network
online version: https://learn.microsoft.com/powershell/module/az.network/new-azapplicationgatewayfirewallpolicylogscrubbingrule
schema: 2.0.0
---

# New-AzApplicationGatewayFirewallPolicyLogScrubbingRule

## SYNOPSIS
Creates a log scrubbing rule for firewall policy

## SYNTAX

```
New-AzApplicationGatewayFirewallPolicyLogScrubbingRule -State <String> -MatchVariable <String>
 -SelectorMatchOperator <String> [-Selector <String>] [-DefaultProfile <IAzureContextContainer>]
 [<CommonParameters>]
```

## DESCRIPTION
The **New-AzApplicationGatewayFirewallPolicyLogScrubbingRule** creates a log scrubbing rule for firewall policy.

## EXAMPLES

### Example 1
```powershell
$logScrubbingRuleConfig1 = New-AzApplicationGatewayFirewallPolicyLogScrubbingRule -State Enabled -MatchVariable RequestArgNames -SelectorMatchOperator Equals -Selector test
```

The command creates a log scrubbing rule configuration with state as enable, MatchVariable as RequestArgNames, SelectorMatchOperator as Equals and Selector as test
The new log scrubbing rule is stored to $logScrubbingRuleConfig1.

### Example 2
```powershell
$logScrubbingRuleConfig2 = New-AzApplicationGatewayFirewallPolicyLogScrubbingRule -State Enabled -MatchVariable RequestIPAddress -SelectorMatchOperator EqualsAny
```

The command creates a log scrubbing rule configuration with state as enable, MatchVariable as RequestIPAddress, SelectorMatchOperator as EqualsAny
The new log scrubbing rule is stored to $logScrubbingRuleConfig2.

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

### -MatchVariable
The variable to be scrubbed from the logs.

```yaml
Type: System.String
Parameter Sets: (All)
Aliases:
Accepted values: RequestHeaderNames, RequestCookieNames, RequestArgNames, RequestPostArgNames, RequestJSONArgNames, RequestIPAddress

Required: True
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -Selector
When matchVariable is a collection, operator used to specify which elements in the collection this rule applies to.

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

### -SelectorMatchOperator
When matchVariable is a collection, operate on the selector to specify which elements in the collection this rule applies to.

```yaml
Type: System.String
Parameter Sets: (All)
Aliases:
Accepted values: Equals, EqualsAny

Required: True
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -State
Defines the state of log scrubbing rule. Default value is Enabled.

```yaml
Type: System.String
Parameter Sets: (All)
Aliases:
Accepted values: Enabled, Disabled

Required: True
Position: Named
Default value: Enabled
Accept pipeline input: False
Accept wildcard characters: False
```

### CommonParameters
This cmdlet supports the common parameters: -Debug, -ErrorAction, -ErrorVariable, -InformationAction, -InformationVariable, -OutVariable, -OutBuffer, -PipelineVariable, -Verbose, -WarningAction, and -WarningVariable. For more information, see [about_CommonParameters](http://go.microsoft.com/fwlink/?LinkID=113216).

## INPUTS

### None

## OUTPUTS

### Microsoft.Azure.Commands.Network.Models.PSApplicationGatewayFirewallPolicySettings

## NOTES

## RELATED LINKS
