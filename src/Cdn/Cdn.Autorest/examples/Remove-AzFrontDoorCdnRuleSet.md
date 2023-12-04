### Example 1: Delete an AzureFrontDoor rule set under the profile
```powershell
Remove-AzFrontDoorCdnRuleSet -ResourceGroupName testps-rg-da16jm -ProfileName fdp-v542q6 -RuleSetName ruleset001
```

Delete an AzureFrontDoor rule set under the profile


### Example 2: Delete an AzureFrontDoor rule set under the profile via identity
```powershell
Get-AzFrontDoorCdnRuleSet -ResourceGroupName testps-rg-da16jm -ProfileName fdp-v542q6 -RuleSetName ruleset001 | Remove-AzFrontDoorCdnRuleSet
```

Delete an AzureFrontDoor rule set under the profile via identity