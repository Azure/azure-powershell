### Example 1: Set an extension on a machine
```powershell
$Settings = @{ "commandToExecute" = "powershell.exe -c Get-Process" }
Set-AzConnectedMachineExtension -Name custom -ResourceGroupName ContosoTest -MachineName win-eastus1 -Location eastus -Publisher "Microsoft.Compute" -TypeHandlerVersion 1.10 -Settings $Settings -ExtensionType CustomScriptExtension
```

```output
Name   Location ProvisioningState
----   -------- -----------------
custom eastus   Succeeded
```

Sets an extension on a machine.

### Example 2: Set an extension with extension parameters specified via the pipeline
```powershell
$otherExtension = Get-AzConnectedMachineExtension -Name custom -ResourceGroupName ContosoTest -MachineName other
$otherExtension | Set-AzConnectedMachineExtension -Name custom -ResourceGroupName ContosoTest -MachineName important
```

```output
Name   Location ProvisioningState
----   -------- -----------------
custom eastus   Succeeded
```

This sets an extension with the extension parameters provided by the object passed in via the pipeline. This is great if you want to grab the parameters of one machine and apply it to another machine.
