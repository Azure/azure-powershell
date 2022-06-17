### Example 1: Add a new extension to a machine
```powershell
$Settings = @{ "commandToExecute" = "powershell.exe -c Get-Process" }
New-AzConnectedMachineExtension -Name custom -ResourceGroupName ContosoTest -MachineName win-eastus1 -Location eastus -Publisher "Microsoft.Compute" -TypeHandlerVersion 1.10 -Settings $Settings -ExtensionType CustomScriptExtension
```

```output
Name   Location ProvisioningState
----   -------- -----------------
custom eastus   Succeeded
```

Sets an extension on a machine.

### Example 2: Add a new extension with extension parameters specified via the pipeline
```powershell
$otherExtension = Get-AzConnectedMachineExtension -Name custom -ResourceGroupName ContosoTest -MachineName other
$otherExtension | New-AzConnectedMachineExtension -Name custom -ResourceGroupName ContosoTest -MachineName important
```

```output
Name   Location ProvisioningState
----   -------- -----------------
custom eastus   Succeeded
```

This creates a new extension with the extension parameters provided by the object passed in via the pipeline. This is great if you want to grab the parameters of one machine and apply it to another machine.

### Example 3: Add a new extension with location specified via the pipeline
```powershell
$identity = [Microsoft.Azure.PowerShell.Cmdlets.ConnectedMachine.Models.ConnectedMachineIdentity]@{
    Id = "/subscriptions/$($SubscriptionId)/resourceGroups/$($ResourceGroupName)/providers/Microsoft.HybridCompute/machines/$MachineName/extensions/$ExtensionName"
}
$Settings = @{ "commandToExecute" = "powershell.exe -c Get-Process" }
$identity | New-AzConnectedMachineExtension -Location eastus -Publisher "Microsoft.Compute" -TypeHandlerVersion 1.10 -Settings $Settings -ExtensionType CustomScriptExtension
```

```output
Name   Location ProvisioningState
----   -------- -----------------
custom eastus   Succeeded
```

This creates a new machine extension using the identity provided via the pipeline. You likely won't do this, but it's possible.

### Example 4: Add a new extension using an extension object as both the location and parameters for updating
```powershell
$ext = Get-AzConnectedMachineExtension -Name custom -ResourceGroupName ContosoTest -MachineName other
$ext | New-AzConnectedMachineExtension -ExtensionParameter $ext
```

This creates a new machine extension using the identity provided via the pipeline and the extension details provided by the passed in extension object. You likely won't do this, but it's possible.
