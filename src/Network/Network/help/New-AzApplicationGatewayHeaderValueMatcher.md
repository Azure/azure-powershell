---
external help file: Microsoft.Azure.PowerShell.Cmdlets.Network.dll-Help.xml
Module Name: Az.Network
online version: https://learn.microsoft.com/powershell/module/az.network/new-azapplicationgatewayheadervaluematcher
schema: 2.0.0
---

# New-AzApplicationGatewayHeaderValueMatcher

## SYNOPSIS
Creates a **HeaderValueMatcher** object configuration to use in **ApplicationGatewayRewriteRuleHeaderConfiguration** for an application gateway.

## SYNTAX

```
New-AzApplicationGatewayHeaderValueMatcher -Pattern <String> [-IgnoreCase] [-Negate]
 [-DefaultProfile <IAzureContextContainer>] [<CommonParameters>]
```

## DESCRIPTION
**The New-AzApplicationGatewayHeaderValueMatcher** cmdlet creates a Header Value Matcher object for an Azure application gateway.

## EXAMPLES

### Example 1
```powershell
$hvm = New-AzApplicationGatewayHeaderValueMatcher -Pattern ".*" -IgnoreCase -Negate
$requestHeaderConfiguration01 = New-AzApplicationGatewayRewriteRuleHeaderConfiguration -HeaderName "Set-Cookie" -HeaderValue "val" -HeaderValueMatcher $headerValueMatcher
```

This command creates a HeaderValueMatcher configuration and stores the result in the variable named $hvm and then use it in a ApplicationGatewayRewriteRuleHeaderConfiguration object.

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

### -IgnoreCase
Set this flag to ignore during pattern matching

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

### -Negate
Set this flag to negate the result of pattern matching against a header value

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

### -Pattern
Pattern to look for in the header values

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

### Microsoft.Azure.Commands.Network.Models.PSApplicationGatewayHeaderValueMatcher

## NOTES

## RELATED LINKS

[New-AzApplicationGatewayRewriteRuleHeaderConfiguration](./New-AzApplicationGatewayRewriteRuleHeaderConfiguration.md)

[Add-AzApplicationGatewayRewriteRuleSet](./Add-AzApplicationGatewayRewriteRuleSet.md)

[Get-AzApplicationGatewayRewriteRuleSet](./Get-AzApplicationGatewayRewriteRuleSet.md)

[New-AzApplicationGatewayRewriteRuleSet](./New-AzApplicationGatewayRewriteRuleSet.md)

[Remove-AzApplicationGatewayRewriteRuleSet](./Remove-AzApplicationGatewayRewriteRuleSet.md)

[Set-AzApplicationGatewayRewriteRuleSet](./Set-AzApplicationGatewayRewriteRuleSet.md)

[New-AzApplicationGatewayRewriteRule](./New-AzApplicationGatewayRewriteRule.md)

[New-AzApplicationGatewayRewriteRuleActionSet](./New-AzApplicationGatewayRewriteRuleActionSet.md)

[Rewrite HTTP headers and URL with Application Gateway](https://aka.ms/appgwheadercrud)
