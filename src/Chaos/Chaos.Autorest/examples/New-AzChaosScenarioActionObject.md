### Example 1: Create a scenario action for a fault
```powershell
New-AzChaosScenarioActionObject -Name 'stop-vm' -ActionId 'microsoft-compute-shutdown/1.0' -Duration 'PT10M'
```

```output
Name    ActionId                       Duration
----    --------                       --------
stop-vm microsoft-compute-shutdown/1.0 PT10M
```

Creates an in-memory scenario action that uses the documented compute shutdown action identifier and runs for ten minutes. Pass the result to `New-AzChaosScenario -Action`.

### Example 2: Create a parameterized CPU pressure action
```powershell
$cpuParam = New-AzChaosKeyValuePairObject -Key 'pressureLevel' -Value '95'
New-AzChaosScenarioActionObject -Name 'cpu-pressure' -ActionId 'microsoft-compute-cpuPressure/1.0' -Duration 'PT5M' -WaitBefore 'PT1M' -Parameter $cpuParam
```

```output
Name         ActionId                           Duration WaitBefore Parameter
----         --------                           -------- ---------- ---------
cpu-pressure microsoft-compute-cpuPressure/1.0  PT5M     PT1M      {pressureLevel}
```

Creates an in-memory CPU pressure action using an action identifier that has been verified against the service create path. Use `-Parameter` when the action requires action-specific settings, and `-WaitBefore` when it should wait before starting.
