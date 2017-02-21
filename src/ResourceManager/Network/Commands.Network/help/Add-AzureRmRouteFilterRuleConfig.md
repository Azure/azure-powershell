---
external help file: Microsoft.Azure.Commands.Network.dll-Help.xml
online version: 
schema: 2.0.0
---

# Add-AzureRmRouteFilterRuleConfig

## SYNOPSIS
Adds a route filter rule to a route filter.

## SYNTAX

```
Add-AzureRmRouteFilterRuleConfig -Name <String> -RouteFilter <PSRouteFilter> -Access <String>
 -RouteFilterRuleType <String> -Communities <System.Collections.Generic.List`1[System.String]>
 [-InformationAction <ActionPreference>] [-InformationVariable <String>]
```

## DESCRIPTION
The Add-AzureRmRouteFilterRuleConfig cmdlet adds a route filter rule to an Azure route filter.

## EXAMPLES

### --------------------------  Example 1: Add a route filter rule to a route filter  --------------------------
@{paragraph=PS C:\\\>}

```
PS C:\>$RouteFilter = Get-AzureRmRouteFilter -ResourceGroupName "ResourceGroup11" -Name "routefilter01"
					  PS C:\> Add-AzureRmRouteFilterRuleConfig -Name "rule13" -Access Allow -RouteFilterRuleType Community -RouteFilter $RouteFilter
```

The first command gets a route filter named routefilter01 by using the Get-AzureRmRouteFilter cmdlet.
The command stores the filter in the $RouteFilter variable.

## PARAMETERS

### -Name
Specifies a name of the route filter rule to add to the route filter.

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

### -RouteFilter
Specifies the route filter to which this cmdlet adds a route filter rule.

```yaml
Type: PSRouteFilter
Parameter Sets: (All)
Aliases: 

Required: True
Position: Named
Default value: None
Accept pipeline input: True (ByValue)
Accept wildcard characters: False
```

### -Access
Specifies the access of the route filter rule, Valid values are Deny or Allow.

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

### -RouteFilterRuleType
Specifies the route filter rule type.
Valid values are: Community

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

### -Communities
Specifies a list of bgp community value.

```yaml
Type: System.Collections.Generic.List`1[System.String]
Parameter Sets: (All)
Aliases: 

Required: True
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -InformationAction
@{Text=}

```yaml
Type: ActionPreference
Parameter Sets: (All)
Aliases: infa

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -InformationVariable
@{Text=}

```yaml
Type: String
Parameter Sets: (All)
Aliases: iv

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

## INPUTS

## OUTPUTS

## NOTES
Keywords: azure, azurerm, arm, resource, management, manager, network, networking

## RELATED LINKS

[Get-AzureRmRouteFilterRuleConfig]()

[Get-AzureRmRouteFilter]()

[New-AzureRmRouteFilterRuleConfigConfig]()

[Remove-AzureRmRouteFilterRuleConfigConfig]()

[Set-AzureRmRouteFilterRuleConfigConfig]()

[Set-AzureRmRouteFilter]()

