### Example 1: Create a dependency on a completed action
```powershell
$dependency = New-AzChaosActionDependencyObject -Name 'stop-vm' -OnActionLifecycle 'Success'
New-AzChaosScenarioActionObject -Name 'stop-secondary-vm' -ActionId 'microsoft-compute-shutdown/1.0' -Duration 'PT5M' -RunAfterItem $dependency
```

```output
Name              ActionId                       Duration RunAfterItem
----              --------                       -------- ------------
stop-secondary-vm microsoft-compute-shutdown/1.0 PT5M     {stop-vm}
```

Creates an in-memory dependency that waits for the `stop-vm` action to succeed, then passes it to `New-AzChaosScenarioActionObject -RunAfterItem` on a later shutdown action. Use this pattern when a custom scenario action must run only after another action reaches a specific lifecycle state.

### Example 2: Create multiple dependencies for a follow-up action
```powershell
$dependencies = @(
    New-AzChaosActionDependencyObject -Name 'stop-vm' -OnActionLifecycle 'Success'
    New-AzChaosActionDependencyObject -Name 'stop-zone-two' -OnActionLifecycle 'AnyTerminal'
)
New-AzChaosScenarioActionObject -Name 'stop-zone-three' -ActionId 'microsoft-compute-shutdown/1.0' -Duration 'PT2M' -RunAfterItem $dependencies
```

```output
Name            ActionId                       Duration RunAfterItem
----            --------                       -------- ------------
stop-zone-three microsoft-compute-shutdown/1.0 PT2M     {stop-vm, stop-zone-two}
```

Creates two action dependencies and attaches them to a later action. The first dependency waits for `stop-vm` to succeed, and the second allows `stop-zone-three` to start after `stop-zone-two` reaches any terminal state. Pass the resulting actions to `New-AzChaosScenario -Action` to preserve the intended run order without using `-JsonString`.
