### Example 1: Create new PSRulesEngineRule object and demonstrate how to see the subfields.
<!-- Skip: Output cannot be splitted from code -->
```powershell
New-AzFrontDoorRulesEngineRuleObject -Name rules1 -Priority 0 -Action $rulesEngineAction -MatchProcessingBehavior Stop -MatchCondition $rulesEngineMatchCondition
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