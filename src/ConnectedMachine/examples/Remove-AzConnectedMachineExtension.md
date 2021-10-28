### Example 1: Remove a machine extension.
```powershell
PS C:\> Remove-AzConnectedMachineExtension -MachineName myMachine -ResourceGroupName myRG -Name custom

```

Deletes the extension on the machine.

### Example 2: Remove extension via the pipeline
```powershell
PS C:\> Get-AzConnectedMachineExtension -ResourceGroupName contoso-connected-machines -MachineName myMachine | Remove-AzConnectedMachineExtension

```

Removes all extensions in the specified machine.
