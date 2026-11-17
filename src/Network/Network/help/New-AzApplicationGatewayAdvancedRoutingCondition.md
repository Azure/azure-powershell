---
external help file: Microsoft.Azure.PowerShell.Cmdlets.Network.dll-Help.xml
Module Name: Az.Network
online version: https://learn.microsoft.com/powershell/module/az.network/new-azapplicationgatewayadvancedroutingcondition
schema: 2.0.0
---

# New-AzApplicationGatewayAdvancedRoutingCondition

## SYNOPSIS
Creates a routing condition for an application gateway advanced routing condition set.

## SYNTAX

### MatchByValues (Default)
```
New-AzApplicationGatewayAdvancedRoutingCondition -ConditionType <String> [-PropertyName <String>]
 -PropertyValues <String[]> [-DefaultProfile <IAzureContextContainer>]
 [-AcquirePolicyToken] [-ChangeReference <String>] [<CommonParameters>]
```

### MatchByPattern
```
New-AzApplicationGatewayAdvancedRoutingCondition -ConditionType <String> [-PropertyName <String>]
 -Pattern <String> [-IgnoreCase] [-Negate] [-DefaultProfile <IAzureContextContainer>]
 [-AcquirePolicyToken] [-ChangeReference <String>] [<CommonParameters>]
```

## DESCRIPTION
The **New-AzApplicationGatewayAdvancedRoutingCondition** cmdlet creates a condition that is evaluated against a property of the incoming request. Use **PropertyValues** to match the property against a list of literal values, or **Pattern** to match it against a fixed string or a regular expression. Exactly one of the two must be supplied. **PropertyName** is required when **ConditionType** is Header or QueryString, and does not apply when it is Path, ClientIP or Method.

## EXAMPLES

### Example 1: Create a condition that matches a request header against literal values
```powershell
$condition = New-AzApplicationGatewayAdvancedRoutingCondition -ConditionType Header -PropertyName "X-Region" -PropertyValues "emea", "apac"
```

This command creates a condition that matches when the X-Region request header is either emea or apac.

### Example 2: Create a condition that matches the request path against a regular expression
```powershell
$condition = New-AzApplicationGatewayAdvancedRoutingCondition -ConditionType Path -Pattern "^/api/v2/.*" -IgnoreCase
```

This command creates a condition that matches any request path beginning with /api/v2/, ignoring case.

## PARAMETERS

### -AcquirePolicyToken
Acquire an Azure Policy token automatically for this resource operation.

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

### -ChangeReference
The change reference resource ID for this resource operation.

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

### -ConditionType
The type of request property the condition is evaluated against

```yaml
Type: System.String
Parameter Sets: (All)
Aliases:
Accepted values: Header, QueryString, Path, ClientIP, Method

Required: True
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

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
Set this flag to make the pattern comparison case insensitive

```yaml
Type: System.Management.Automation.SwitchParameter
Parameter Sets: MatchByPattern
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -Negate
Set this flag to negate the condition given by the pattern

```yaml
Type: System.Management.Automation.SwitchParameter
Parameter Sets: MatchByPattern
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -Pattern
Pattern, either a fixed string or a regular expression, the request property is matched against.
Not applicable when ConditionType is ClientIP or Method

```yaml
Type: System.String
Parameter Sets: MatchByPattern
Aliases:

Required: True
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -PropertyName
Name of the request property the condition is evaluated against.
Required when ConditionType is Header or QueryString, and not applicable when ConditionType is Path, ClientIP or Method

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

### -PropertyValues
Values the request property is matched against

```yaml
Type: System.String[]
Parameter Sets: MatchByValues
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

### Microsoft.Azure.Commands.Network.Models.PSApplicationGatewayAdvancedRoutingCondition

## NOTES

## RELATED LINKS
