### Example 1: Remove a VM Checkpoint
```powershell
Remove-AzScVmmVMCheckpoint -Name "test-vm" -ResourceGroupName "test-rg-01" -CheckpointId "00000000-abcd-0000-abcd-000000000000"
```

Deletes a VM Checkpoint with given `CheckpointId`. To get the list of available checkpoints and their Id, do a get VM operation using `Get-AzScVmmVM`.

### Example 2: Remove a VM Checkpoint
```powershell
$CheckpointProperties = '{
    "id": "00000000-abcd-0000-abcd-000000000000"
}'
Remove-AzScVmmVMCheckpoint -Name "test-vm" -ResourceGroupName "test-rg-01" -JsonString $CheckpointProperties
```

Deletes a VM Checkpoint with given `CheckpointId`. To get the list of available checkpoints and their Id, do a get VM operation using `Get-AzScVmmVM`.