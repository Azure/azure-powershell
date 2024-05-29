### Example 1: Create an in-memory object for ProfileScrubbingRules and the value of matchVariable is RequestIPAddress
```powershell
New-AzFrontDoorCdnProfileScrubbingRulesObject -MatchVariable RequestIPAddress -State Enabled
```

```output
MatchVariable    Selector SelectorMatchOperator State
-------------    -------- --------------------- -----
RequestIPAddress          EqualsAny             Enabled
```

Create an in-memory object for ProfileScrubbingRules and the value of matchVariable is RequestIPAddress

### Example 2: Create an in-memory object for ProfileScrubbingRules and disbale the Scrubbing rule
```powershell
New-AzFrontDoorCdnProfileScrubbingRulesObject -MatchVariable RequestUri -State Disabled
```

```output
MatchVariable Selector SelectorMatchOperator State
------------- -------- --------------------- -----
RequestUri             EqualsAny             Disabled
```

Create an in-memory object for ProfileScrubbingRules and disbale the Scrubbing rule

