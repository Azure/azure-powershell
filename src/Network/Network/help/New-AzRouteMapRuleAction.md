---
external help file: Microsoft.Azure.PowerShell.Cmdlets.Network.dll-Help.xml
Module Name: Az.Network
online version: https://learn.microsoft.com/powershell/module/az.network/new-azroutemapruleaction
schema: 2.0.0
---

# New-AzRouteMapRuleAction

## SYNOPSIS
Create a route map rule action.

## SYNTAX

```
New-AzRouteMapRuleAction -Type <String> [-Parameter <PSRouteMapRuleActionParameter[]>]
 [-DefaultProfile <IAzureContextContainer>] [-WhatIf] [-Confirm] [<CommonParameters>]
```

## DESCRIPTION
Create a route map rule action.

## EXAMPLES

### Example 1

```powershell
# creating new route map rule action
$routeMapRuleActionParameter1 = New-AzRouteMapRuleActionParameter -AsPath @("12345")
New-AzRouteMapRuleAction -Type "Add" -Parameter @($routeMapRuleActionParameter1)
```

```output
Type           : Add
Parameters     : {}
ParametersText : [
                   {
                     "AsPath": [
                       "12345"
                     ]
                   }
                 ]
Name           :
Etag           :
Id             :
```

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

### -Parameter
The route map rule action parameter.

```yaml
Type: Microsoft.Azure.Commands.Network.Models.PSRouteMapRuleActionParameter[]
Parameter Sets: (All)
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -Type
The route map rule action type.

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
Shows what would happen if the cmdlet runs. The cmdlet is not run.

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

### Microsoft.Azure.Commands.Network.Models.PSRouteMapRuleActionParameter

### System.String

## OUTPUTS

### Microsoft.Azure.Commands.Network.Models.PSRouteMapRuleAction

## NOTES

## RELATED LINKS

[New-AzRouteMapRule](./New-AzRouteMapRule.md)

[New-AzRouteMapRuleActionParameter](./New-AzRouteMapRuleActionParameter.md)
