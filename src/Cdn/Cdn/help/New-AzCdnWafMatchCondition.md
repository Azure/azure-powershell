---
external help file: Microsoft.Azure.PowerShell.Cmdlets.Cdn.dll-Help.xml
Module Name: Az.Cdn
online version:
schema: 2.0.0
---

# New-AzCdnWafMatchCondition

## SYNOPSIS
Creates a CDN WAF match condition for use in a rule.

## SYNTAX

```
New-AzCdnWafMatchCondition -MatchVariable <PSMatchVariable> [-Selector <String>] -Operator <PSOperator>
 [-NegateCondition] -MatchValue <String[]> [-Transform <PSTransform[]>]
 [-DefaultProfile <IAzureContextContainer>] [<CommonParameters>]
```

## DESCRIPTION
The **New-AzCdnWafMatchCondition** cmdlet creates an Azure Content Delivery Network (CDN) 
WebApplication Firewall (WAF) match condition locally, for use in creating a rule.

## EXAMPLES

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

### -MatchValue
The value or values to match against.

```yaml
Type: System.String[]
Parameter Sets: (All)
Aliases:

Required: True
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -MatchVariable
The name of the custom rule.

```yaml
Type: Microsoft.Azure.Commands.Cdn.Models.WebApplicationFirewall.PSMatchVariable
Parameter Sets: (All)
Aliases:
Accepted values: RemoteAddr, Country, RequestMethod, RequestHeader, RequestUri, QueryString, RequestBody, Cookies, PostArgs

Required: True
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -NegateCondition
Make the rule match when the condition is false instead of true.

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

### -Operator
The comparison operator to use for matching.

```yaml
Type: Microsoft.Azure.Commands.Cdn.Models.WebApplicationFirewall.PSOperator
Parameter Sets: (All)
Aliases:
Accepted values: Any, IPMatch, GeoMatch, Equal, Contains, LessThan, GreaterThan, LessThanOrEqual, GreaterThanOrEqual, BeginsWith, EndsWith, RegEx

Required: True
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -Selector
Match a specific key for QueryString, RequestUri, RequestHeaders or RequestBody.

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

### -Transform
The transform to apply before matching.

```yaml
Type: Microsoft.Azure.Commands.Cdn.Models.WebApplicationFirewall.PSTransform[]
Parameter Sets: (All)
Aliases:
Accepted values: Allow, Block, Log, Redirect

Required: False
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

### Microsoft.Azure.Commands.Cdn.Models.WebApplicationFirewall.PSMatchCondition

## NOTES

## RELATED LINKS
