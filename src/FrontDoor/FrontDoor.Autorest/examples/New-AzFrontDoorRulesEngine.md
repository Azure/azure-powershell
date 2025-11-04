### Example 1: Create a new rules engine configuration for specified front door.
```powershell
New-AzFrontDoorRulesEngine -ResourceGroupName $resourceGroupName -FrontDoorName $frontDoorName -Name myRulesEngine -Rule $rulesEngineRule1
```

```output
Name          RulesEngineRules
----          ----------------
myRulesEngine {rules1}
```

Create a new rules engine configuration for specified front door.