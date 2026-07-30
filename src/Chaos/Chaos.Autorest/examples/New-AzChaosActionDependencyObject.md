### Example 1: Create a dependency on a completed action
```powershell
$dependency = New-AzChaosActionDependencyObject -Name 'stop-vm' -OnActionLifecycle 'Success'
New-AzChaosScenarioActionObject -Name 'start-vm' -ActionId 'urn:csci:microsoft:virtualMachine:start/1.0' -Duration 'PT5M' -RunAfterItem $dependency
```

```output
Name     ActionId                                  Duration RunAfterItem
----     --------                                  -------- ------------
start-vm urn:csci:microsoft:virtualMachine:start/1.0 PT5M     {stop-vm}
```

Creates an in-memory dependency that waits for the `stop-vm` action to succeed, then passes it to `New-AzChaosScenarioActionObject -RunAfterItem`. Use this pattern when a custom scenario action must run only after another action reaches a specific lifecycle state.

### Example 2: Create multiple dependencies for a follow-up action
```powershell
$dependencies = @(
    New-AzChaosActionDependencyObject -Name 'stop-vm' -OnActionLifecycle 'Success'
    New-AzChaosActionDependencyObject -Name 'network-delay' -OnActionLifecycle 'AnyTerminal'
)
New-AzChaosScenarioActionObject -Name 'collect-logs' -ActionId 'urn:csci:microsoft:agent:custom/1.0' -Duration 'PT2M' -RunAfterItem $dependencies
```

```output
Name         ActionId                              Duration RunAfterItem
----         --------                              -------- ------------
collect-logs urn:csci:microsoft:agent:custom/1.0   PT2M     {stop-vm, network-delay}
```

Creates two action dependencies and attaches them to a later action. The first dependency waits for `stop-vm` to succeed, and the second allows `collect-logs` to start after `network-delay` reaches any terminal state. Pass the resulting actions to `New-AzChaosScenario -Action` to preserve the intended run order without using `-JsonString`.