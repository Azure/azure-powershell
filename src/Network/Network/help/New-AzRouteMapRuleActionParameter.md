---
external help file: Microsoft.Azure.PowerShell.Cmdlets.Network.dll-Help.xml
Module Name: Az.Network
online version: https://learn.microsoft.com/powershell/module/az.network/new-azroutemapruleactionparameter
schema: 2.0.0
---

# New-AzRouteMapRuleActionParameter

## SYNOPSIS
Create a route map rule action parameter for the rule action.

## SYNTAX

```powershell
New-AzRouteMapRuleActionParameter -RoutePrefix <String[]> -Community <String[]> -AsPath <String[]>
```

## DESCRIPTION
Create a route map rule action parameter for the rule action.

## EXAMPLES

### Example 1

```powershell
# creating new route map rule action
New-AzRouteMapRuleActionParameter -AsPath @("12345")

```

```output
RoutePrefix :
Community   :
AsPath      : {12345}
Name        :
Etag        :
Id          :

```

## PARAMETERS

### -AsPath
As Path

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

### -Community
Community

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

### -RoutePrefix
Route Prefix

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

### System.String

## OUTPUTS

### Microsoft.Azure.Commands.Network.Models.PSRouteMapRuleActionParameter

## NOTES

## RELATED LINKS

[New-AzRouteMapRule](./New-AzRouteMapRule.md)

[New-AzRouteMapRuleAction](./New-AzRouteMapRuleAction.md)
