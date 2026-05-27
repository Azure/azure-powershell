### Example 1: Create an in-memory object for EdgeAction
```powershell
New-AzFrontDoorCdnRuleEdgeActionObject -ParameterInvocationPoint ClientRequest -ParameterTypeName DeliveryRuleEdgeActionParameters
```

```output
ParameterInvocationPoint ParameterTypeName
------------------------ -----------------
ClientRequest            DeliveryRuleEdgeActionParameters
```

Create an in-memory object for EdgeAction.

### Example 2: Create an in-memory object for EdgeAction with a reference ID
```powershell
$referenceId = "/subscriptions/testSubId/resourceGroups/testRg/providers/Microsoft.Cdn/profiles/contosoafd/ruleSets/ruleSet01/rules/rule01"
New-AzFrontDoorCdnRuleEdgeActionObject -ParameterInvocationPoint OriginRequest -ParameterTypeName DeliveryRuleUrlRewriteActionParameters -ReferenceId $referenceId
```

```output
ParameterInvocationPoint ParameterTypeName                    ReferenceId
------------------------ -----------------                    -----------
OriginRequest            DeliveryRuleUrlRewriteActionParameters /subscriptions/testSubId/resourceGroups/testRg/providers/Microsoft.Cdn/profiles/contosoafd/ruleSets/ruleSet01/rules/rule01
```

Create an in-memory object for EdgeAction with a reference ID.
