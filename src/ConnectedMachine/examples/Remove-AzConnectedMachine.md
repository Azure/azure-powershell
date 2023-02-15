### Example 1: Remove a connected machine
```powershell
Remove-AzConnectedMachine -Name myMachine -ResourceGroupName myRG
```

Deletes the connected machine.

### Example 2: Remove connected machines via the pipeline
```powershell
Get-AzConnectedMachine -ResourceGroupName contoso-connected-machines | Remove-AzConnectedMachine
```

Removes all machines in the `contoso-connected-machines` resource group.
