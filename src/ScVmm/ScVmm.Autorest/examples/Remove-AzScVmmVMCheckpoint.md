### Example 1: Remove a VM Checkpoint
```powershell
Remove-AzScVmmVMCheckpoint -MachineId "/subscriptions/00000000-abcd-0000-abcd-000000000000/resourceGroups/test-rg-01/providers/Microsoft.HybridCompute/machines/test-vm" -Id "00000000-1111-0000-1111-000000000000"
```
Deletes a VM Checkpoint with given `checkpointID`. To get the list of available checkpoints and their Id, do a get VM operation using `Get-AzScVmmVM`.
