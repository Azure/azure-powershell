### Example 1: Remove a connected machine
```powershell
PS C:\> Remove-AzConnectedMachine -Name myMachine -ResourceGroupName myRG

```

Deletes the connected machine.

### Example 2: Remove connected machines via the pipeline
```powershell
PS C:\> Get-AzConnectedMachine -ResourceGroupName contoso-connected-machines | Remove-AzConnectedMachine

```

Removes all machines in the `contoso-connected-machines` resource group.
