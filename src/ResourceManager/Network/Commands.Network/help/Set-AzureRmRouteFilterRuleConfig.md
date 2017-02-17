---
external help file: Microsoft.Azure.Commands.Network.dll-Help.xml
online version: 
schema: 2.0.0
---

# Set-AzureRmRouteFilterRuleConfig

## SYNOPSIS
{{Fill in the Synopsis}}

## SYNTAX

```
Set-AzureRmRouteFilterRuleConfig -Name <String> -RouteFilter <PSRouteFilter> -Access <String>
 -RouteFilterRuleType <String> -Communities <System.Collections.Generic.List`1[System.String]>
```

## DESCRIPTION
{{Fill in the Description}}

## EXAMPLES

### Example 1
```
PS C:\> {{ Add example code here }}
```

{{ Add example description here }}

## PARAMETERS

### -Access
The access type of the rule.
Possible values are: 'Allow', 'Deny'

```yaml
Type: String
Parameter Sets: (All)
Aliases: 
Accepted values: Allow, Deny

Required: True
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -Communities
The route filter rule type of the rule.
Possible values are: 'Community'

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

### -Name
The name of the route filter rule

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
The RouteFilter

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

### -RouteFilterRuleType
The route filter rule type of the rule.
Possible values are: 'Community'

```yaml
Type: String
Parameter Sets: (All)
Aliases: 
Accepted values: Community

Required: True
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

## INPUTS

### Microsoft.Azure.Commands.Network.Models.PSRouteFilter


## OUTPUTS

### Microsoft.Azure.Commands.Network.Models.PSRouteFilter


## NOTES

## RELATED LINKS

