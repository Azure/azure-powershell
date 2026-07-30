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

### Example 2: Create a scenario action with a delay and description
```powershell
New-AzChaosScenarioActionObject -Name 'delayed-stop-vm' -ActionId 'microsoft-compute-shutdown/1.0' -Duration 'PT5M' -WaitBefore 'PT1M' -Description 'Stop the virtual machine after a one-minute delay.'
```

```output
Name            ActionId                       Duration WaitBefore
----            --------                       -------- ----------
delayed-stop-vm microsoft-compute-shutdown/1.0 PT5M     PT1M
```

Creates an in-memory shutdown action that waits one minute before it starts. Use `-WaitBefore` when a custom scenario needs a delay before this action runs.
