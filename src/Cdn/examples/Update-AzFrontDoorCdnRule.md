### Example 1: Update an AzureFrontDoor delivery rule within the specified rule set
```powershell
Update-AzFrontDoorCdnRule -ResourceGroupName testps-rg-da16jm -ProfileName fdp-v542q6 -RuleSetName ruleset001 -Name rule1 -Order 99
```

```output
Name  ResourceGroupName
----  -----------------
rule1 testps-rg-da16jm
```

