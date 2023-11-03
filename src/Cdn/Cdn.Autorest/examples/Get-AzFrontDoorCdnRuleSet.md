### Example 1: List AzureFrontDoor rule sets under the profile
```powershell
Get-AzFrontDoorCdnRuleSet -ResourceGroupName testps-rg-da16jm -ProfileName fdp-v542q6
```

```output
Name       ResourceGroupName
----       -----------------
ruleset001 testps-rg-da16jm
ruleset002 testps-rg-da16jm
```

List AzureFrontDoor rule sets under the profile


### Example 2: Get an AzureFrontDoor rule set under the profile
```powershell
Get-AzFrontDoorCdnRuleSet -ResourceGroupName testps-rg-da16jm -ProfileName fdp-v542q6 -RuleSetName ruleset001
```

```output
Name       ResourceGroupName
----       -----------------
ruleset001 testps-rg-da16jm
```

Get an AzureFrontDoor rule set under the profile


### Example 3: Get an AzureFrontDoor rule set under the profile via identity
```powershell
New-AzFrontDoorCdnRuleSet -ResourceGroupName testps-rg-da16jm -ProfileName fdp-v542q6 -RuleSetName ruleset001 | Get-AzFrontDoorCdnRuleSet
```

```output
Name       ResourceGroupName
----       -----------------
ruleset001 testps-rg-da16jm
```

Get an AzureFrontDoor rule set under the profile via identity