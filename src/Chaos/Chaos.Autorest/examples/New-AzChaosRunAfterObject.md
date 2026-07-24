### Example 1: Order one action after another
```powershell
$dependency = [Microsoft.Azure.PowerShell.Cmdlets.Chaos.Models.ActionDependency]@{ ActionId = 'stop-vm'; DependencyType = 'DependsOn' }
New-AzChaosRunAfterObject -Item $dependency
```

```output
Behavior Item
-------- ----
         {stop-vm}
```

Creates an in-memory run-after object so that an action starts only after the `stop-vm` action completes.

### Example 2: Order an action with an explicit behavior
```powershell
$dependency = [Microsoft.Azure.PowerShell.Cmdlets.Chaos.Models.ActionDependency]@{ ActionId = 'stop-vm'; DependencyType = 'DependsOn' }
New-AzChaosRunAfterObject -Item $dependency -Behavior 'WaitForCompletion'
```

```output
Behavior          Item
--------          ----
WaitForCompletion {stop-vm}
```

Creates a run-after object that waits for the referenced action to complete before the dependent action starts.
