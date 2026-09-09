### Example 1: Update an AzureFrontDoor rule set with batch rules
```powershell
$rule = @{
	RuleName = "rule1"
	Order = 1
	MatchProcessingBehavior = "Continue"
}
Update-AzFrontDoorCdnRuleSet -ResourceGroupName testps-rg-da16jm -ProfileName fdp-v542q6 -RuleSetName ruleset001 -Rule $rule
```

```output
Name       ResourceGroupName
----       -----------------
ruleset001 testps-rg-da16jm
```

Update an AzureFrontDoor rule set with batch rules.

### Example 2: Update an AzureFrontDoor rule set with batch rules via identity
```powershell
$rule = @{
	RuleName = "rule1"
	Order = 1
	MatchProcessingBehavior = "Continue"
}
Get-AzFrontDoorCdnRuleSet -ResourceGroupName testps-rg-da16jm -ProfileName fdp-v542q6 -RuleSetName ruleset001 | Update-AzFrontDoorCdnRuleSet -Rule $rule
```

```output
Name       ResourceGroupName
----       -----------------
ruleset001 testps-rg-da16jm
```

Update an AzureFrontDoor rule set with batch rules via identity.

