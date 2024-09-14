### Example 1: Create VM checkpoint
```powershell
New-AzScVmmVMCheckpoint -MachineId "/subscriptions/00000000-abcd-0000-abcd-000000000000/resourceGroups/test-rg-01/providers/Microsoft.HybridCompute/machines/test-vm"
```

Creates a VM checkpoint. To get details of the created checkpoint perform a Get VM operation using `Get-AzScVmmVM`.

### Example 2: Create VM checkpoint
```powershell
New-AzScVmmVMCheckpoint -MachineId "/subscriptions/00000000-abcd-0000-abcd-000000000000/resourceGroups/test-rg-01/providers/Microsoft.HybridCompute/machines/test-vm" -Name "Checkpoint1" -Description "Test-Checkpoint"
```

Creates a VM checkpoint with given Name and Description values for Checkpoint.  To get details of the created checkpoint perform a Get VM operation using `Get-AzScVmmVM`.
