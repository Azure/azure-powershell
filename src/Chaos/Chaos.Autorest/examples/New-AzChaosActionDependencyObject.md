### Example 1: Order one action after another succeeds
```powershell
$dependency = New-AzChaosActionDependencyObject -Name 'stop-primary-vm' -OnActionLifecycle 'Success'
New-AzChaosScenarioActionObject -Name 'stop-secondary-vm' -ActionId 'microsoft-compute-shutdown/1.0' -Duration 'PT5M' -RunAfterItem $dependency
```

```output
Name              ActionId                       Duration RunAfterItem
----              --------                       -------- ------------
stop-secondary-vm microsoft-compute-shutdown/1.0 PT5M     {stop-primary-vm}
```

Creates an in-memory action dependency and attaches it to a later scenario action. Use this when a custom scenario must wait for one action to reach a specified lifecycle state before another starts.

### Example 2: Order an action after multiple terminal dependencies
```powershell
$dependencies = @(
    New-AzChaosActionDependencyObject -Name 'stop-zone-two' -OnActionLifecycle 'AnyTerminal'
    New-AzChaosActionDependencyObject -Name 'stop-zone-three' -OnActionLifecycle 'AnyTerminal'
)
New-AzChaosScenarioActionObject -Name 'stop-zone-one' -ActionId 'microsoft-compute-shutdown/1.0' -Duration 'PT2M' -RunAfterItem $dependencies
```

```output
Name          ActionId                       Duration RunAfterItem
----          --------                       -------- ------------
stop-zone-one microsoft-compute-shutdown/1.0 PT2M     {stop-zone-two, stop-zone-three}
```

Creates two action dependencies and attaches them to a later action. The later action can start after both named actions reach a terminal state, which lets a custom scenario express action order without using `-JsonString`.
