---
external help file: Az.FrontDoor-help.xml
Module Name: Az.FrontDoor
online version: https://learn.microsoft.com/powershell/module/Az.FrontDoor/new-azfrontdoorwafmatchconditionobject
schema: 2.0.0
---

# New-AzFrontDoorWafMatchConditionObject

## SYNOPSIS
Create an in-memory object for MatchCondition.

## SYNTAX

```
New-AzFrontDoorWafMatchConditionObject -MatchValue <String[]> -MatchVariable <String>
 -OperatorProperty <String> [-NegateCondition <Boolean>] [-Selector <String>] [-Transform <String[]>]
 [<CommonParameters>]
```

## DESCRIPTION
Create an in-memory object for MatchCondition.

## EXAMPLES

### Example 1: Create MatchCondition Object for WAF policy creation
```powershell
New-AzFrontDoorWafMatchConditionObject -MatchVariable RequestHeader -OperatorProperty Contains -Selector "User-Agent" -MatchValue "Windows"
```

```output
MatchValue       : {Windows}
MatchVariable    : RequestHeader
NegateCondition  :
OperatorProperty : Contains
Selector         : User-Agent
Transform        :
```

Create MatchCondition Object for WAF policy creation

### Example 2: Create MatchCondition Object for WAF policy creation
```powershell
New-AzFrontDoorWafMatchConditionObject -MatchVariable RequestHeader -OperatorProperty Contains -Selector "User-Agent" -MatchValue "WINDOWS" -Transform Uppercase
```

```output
MatchValue       : {WINDOWS}
MatchVariable    : RequestHeader
NegateCondition  :
OperatorProperty : Contains
Selector         : User-Agent
Transform        : {Uppercase}
```

Create a MatchCondition object

## PARAMETERS

### -MatchValue
List of possible match values.

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
Request variable to compare with.

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

### -NegateCondition
Describes if the result of this condition should be negated.

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

### -OperatorProperty
Comparison type to use for matching with the variable value.

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

### -Selector
Match against a specific key from the QueryString, PostArgs, RequestHeader or Cookies variables.
Default is null.

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
List of transforms.

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

### CommonParameters
This cmdlet supports the common parameters: -Debug, -ErrorAction, -ErrorVariable, -InformationAction, -InformationVariable, -OutVariable, -OutBuffer, -PipelineVariable, -Verbose, -WarningAction, and -WarningVariable. For more information, see [about_CommonParameters](http://go.microsoft.com/fwlink/?LinkID=113216).

## INPUTS

## OUTPUTS

### Microsoft.Azure.PowerShell.Cmdlets.FrontDoor.Models.MatchCondition

## NOTES

## RELATED LINKS
