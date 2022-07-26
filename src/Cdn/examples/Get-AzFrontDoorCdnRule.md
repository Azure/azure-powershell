### Example 1: list AzureFrontDoor delivery rules within the specified rule set
```powershell
Get-AzFrontDoorCdnRule -ResourceGroupName testps-rg-da16jm -ProfileName fdp-v542q6 -RuleSetName ruleset001
```

```output
Name      ResourceGroupName
----      -----------------
testrule1 testps-rg-da16jm
testrule2 testps-rg-da16jm
rule1     testps-rg-da16jm
```

list AzureFrontDoor delivery rules within the specified rule set


### Example 2: Get an AzureFrontDoor delivery rule within the specified rule set
```powershell
Get-AzFrontDoorCdnRule -ResourceGroupName testps-rg-da16jm -ProfileName fdp-v542q6 -RuleSetName ruleset001 -Name rule1
```

```output
Name  ResourceGroupName
----  -----------------
rule1 testps-rg-da16jm
```

Get an AzureFrontDoor delivery rule within the specified rule set


