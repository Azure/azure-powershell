---
external help file: Az.FrontDoor-help.xml
Module Name: Az.FrontDoor
online version: https://learn.microsoft.com/powershell/module/Az.FrontDoor/new-azfrontdoorrulesengineruleobject
schema: 2.0.0
---

# New-AzFrontDoorRulesEngineRuleObject

## SYNOPSIS
Create an in-memory object for RulesEngineRule.

## SYNTAX

```
New-AzFrontDoorRulesEngineRuleObject -Action <IRulesEngineAction> -Name <String> -Priority <Int32>
 [-MatchCondition <IRulesEngineMatchCondition[]>] [-MatchProcessingBehavior <String>]
 [<CommonParameters>]
```

## DESCRIPTION
Create an in-memory object for RulesEngineRule.

## EXAMPLES

### Example 1: Create new PSRulesEngineRule object and demonstrate how to see the subfields.
```powershell
New-AzFrontDoorRulesEngineRuleObject -Name rules1 -Priority 0 -Action $rulesEngineAction -MatchProcessingBehavior Stop -MatchCondition $rulesEngineMatchCondition

Name                    : rules1
Priority                : 0
MatchProcessingBehavior : Stop
MatchCondition          : {Microsoft.Azure.Commands.FrontDoor.Models.PSRulesEngineMatchCondition}
Action                  : Microsoft.Azure.Commands.FrontDoor.Models.PSRulesEngineAction


$rulesEngineRule1.Action

RequestHeaderActions           ResponseHeaderActions RouteConfigurationOverride
--------------------           --------------------- --------------------------
{headeraction1, headeraction2} {}                    Microsoft.Azure.Commands.FrontDoor.Models.PSForwardingConfiguration

$rulesEngineRule1.MatchCondition[0]

RulesEngineMatchVariable : RequestHeader
RulesEngineMatchValue    : {allowoverride}
Selector                 : Rules-Engine-Route-Forward
RulesEngineOperator      : Equal
NegateCondition          : False
Transforms               : {Lowercase, Uppercase}
```

Create new PSRulesEngineRule object and demonstrate how to see the subfields.

### Example 2: Expect output when passing in invalid priority value.
```powershell
New-AzFrontDoorRulesEngineRuleObject -Name rules1 -Priority -1
```

```output
New-AzFrontDoorRulesEngineRuleObject : Cannot validate argument on parameter 'Priority'. The -1 argument is less than the minimum allowed range of 0. Supply an argument that is greater than or equal to 0 and then try the command again.
At line:1 char:81
+ ... ule1 = New-AzFrontDoorRulesEngineRuleObject -Name rules1 -Priority -1
+                                                                        ~~
+ CategoryInfo          : InvalidData: (:) [New-AzFrontDoorRulesEngineRuleObject], ParameterBindingValidationException
+ FullyQualifiedErrorId : ParameterArgumentValidationError,Microsoft.Azure.Commands.FrontDoor.Cmdlets.NewFrontDoorRulesEngineRuleObject
```

Expect output when passing in invalid priority value.

## PARAMETERS

### -Action
Actions to perform on the request and response if all of the match conditions are met.

```yaml
Type: Microsoft.Azure.PowerShell.Cmdlets.FrontDoor.Models.IRulesEngineAction
Parameter Sets: (All)
Aliases:

Required: True
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -MatchCondition
A list of match conditions that must meet in order for the actions of this rule to run.
Having no match conditions means the actions will always run.

```yaml
Type: Microsoft.Azure.PowerShell.Cmdlets.FrontDoor.Models.IRulesEngineMatchCondition[]
Parameter Sets: (All)
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -MatchProcessingBehavior
If this rule is a match should the rules engine continue running the remaining rules or stop.
If not present, defaults to Continue.

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

### -Name
A name to refer to this specific rule.

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

### -Priority
A priority assigned to this rule.
.

```yaml
Type: System.Int32
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

## OUTPUTS

### Microsoft.Azure.PowerShell.Cmdlets.FrontDoor.Models.RulesEngineRule

## NOTES

## RELATED LINKS
