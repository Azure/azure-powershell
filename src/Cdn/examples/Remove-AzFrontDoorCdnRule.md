### Example 1: Delete an AzureFrontDoor delivery rule within the specified rule set
```powershell
Remove-AzFrontDoorCdnRule -ResourceGroupName testps-rg-da16jm -ProfileName fdp-v542q6 -RuleSetName ruleset001 -Name rule1
```

Delete an AzureFrontDoor delivery rule within the specified rule set


### Example 2: Delete an AzureFrontDoor delivery rule within the specified rule set via identity
```powershell
Get-AzFrontDoorCdnRule -ResourceGroupName testps-rg-da16jm -ProfileName fdp-v542q6 -RuleSetName ruleset001 -Name rule1 | Remove-AzFrontDoorCdnRule
```

Delete an AzureFrontDoor delivery rule within the specified rule set via identity
