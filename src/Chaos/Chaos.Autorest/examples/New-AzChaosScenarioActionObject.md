### Example 1: Create a scenario action for a fault
```powershell
New-AzChaosScenarioActionObject -Name 'stop-vm' -ActionId 'urn:csci:microsoft:virtualMachine:shutdown/1.0' -Duration 'PT10M'
```

```output
Name    ActionId                                     Duration
----    --------                                     --------
stop-vm urn:csci:microsoft:virtualMachine:shutdown/1.0 PT10M
```

Creates an in-memory scenario action that shuts down a virtual machine for ten minutes. Pass the result to `New-AzChaosScenario -Action`.

### Example 2: Create a scenario action with parameters and a delay
```powershell
$cpuParam = New-AzChaosKeyValuePairObject -Key 'pressureLevel' -Value '95'
New-AzChaosScenarioActionObject -Name 'cpu-pressure' -ActionId 'urn:csci:microsoft:agent:cpuPressure/1.0' -Duration 'PT5M' -WaitBefore 'PT1M' -Parameter $cpuParam
```

```output
Name         ActionId                                Duration WaitBefore
----         --------                                -------- ----------
cpu-pressure urn:csci:microsoft:agent:cpuPressure/1.0 PT5M     PT1M
```

Creates a scenario action that applies CPU pressure after a one-minute delay, with a `pressureLevel` action parameter.
