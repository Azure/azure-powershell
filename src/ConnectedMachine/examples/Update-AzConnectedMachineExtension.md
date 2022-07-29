### Example 1: Update an extension
```powershell
$splat = @{
            ResourceGroupName = "connectedMachines"
            MachineName = "linux-eastus1_1"
            Name = "customScript"
            Settings = @{
                commandToExecute = "ls -l"
            }
        }
Update-AzConnectedMachineExtension @splat
```

```output
Name         Location ProvisioningState
----         -------- -----------------
customScript eastus   Succeeded
```

Updates an extension on a specific machine.

### Example 2: Update an extension with location specified via the pipeline
```powershell
$extToUpdate = Get-AzConnectedMachineExtension -ResourceGroupName connectedMachines -MachineName linux-eastus1_1 -Name customScript
$extToUpdate | Update-AzConnectedMachineExtension -Settings @{
                commandToExecute = "ls -l"
            }
```

```output
Name         Location ProvisioningState
----         -------- -----------------
customScript eastus   Succeeded
```

Updates a specific extension passed in via the pipeline.
Here we are using the extension passed in via the pipeline to help us identify which extension we want to operate on and are specifying what we want to change via the normal parameters (like `-Settings`)

### Example 3: Update an extension with extension parameters specified via the pipeline
```powershell
$extToUpdate = Get-AzConnectedMachineExtension -ResourceGroupName connectedMachines -MachineName linux-eastus1_1 -Name customScript
# Update the settings on the object that will be used via the pipeline
$extToUpdate.Setting.commandToExecute = "ls -l"
$splat = @{
            ResourceGroupName = "connectedMachines"
            MachineName = "linux-eastus1_1"
            Name = "customScript"
        }
$extToUpdate | Update-AzConnectedMachineExtension @splat
```

```output
Name         Location ProvisioningState
----         -------- -----------------
customScript eastus   Succeeded
```

Updates a specific extension passed in via the pipeline.
Here we are using the extension passed in via the pipeline to provide the changes we want to make on the extension. The location of the extension is not retrieved via the pipeline but rather via the parameters specified normally (by the splat parameter).

### Example 4: Using an extension object as both the location and parameters for updating
```powershell
$extToUpdate = Get-AzConnectedMachineExtension -ResourceGroupName connectedMachines -MachineName linux-eastus1_1 -Name customScript
# Update the settings on the object that will be used via the pipeline
$extToUpdate.Setting.commandToExecute = "ls -l"
$extToUpdate | Update-AzConnectedMachineExtension -ExtensionParameter $extToUpdate
```

```output
Name         Location ProvisioningState
----         -------- -----------------
customScript eastus   Succeeded
```

Updates a specific extension passed in via the pipeline.
Here we are using the extension passed in via the pipeline to help us identify which extension we want to operate on. In addition to that, we are using the parameters of the extension object to specify what to update.
