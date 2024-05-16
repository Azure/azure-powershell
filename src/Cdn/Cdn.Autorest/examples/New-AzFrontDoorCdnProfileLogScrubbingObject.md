### Example 1: Create an in-memory object for ProfileUpgradeParameters, for two LogScrubbingRules
```powershell
$scrubbingRule1 = New-AzFrontDoorCdnProfileScrubbingRulesObject -MatchVariable RequestIPAddress -State Enabled
$scrubbingRule2 = New-AzFrontDoorCdnProfileScrubbingRulesObject -MatchVariable RequestUri -State Enabled
New-AzFrontDoorCdnProfileLogScrubbingObject -ScrubbingRule @($scrubbingRule1, $scrubbingRule2) -State Enabled
```

```output
State
-----
Enabled
```

Create an in-memory object for ProfileUpgradeParameters, for two LogScrubbingRules

