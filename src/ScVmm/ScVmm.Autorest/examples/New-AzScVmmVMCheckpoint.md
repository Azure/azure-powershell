### Example 1: Create VM checkpoint
```powershell
New-AzScVmmVMCheckpoint -Name "test-vm" -ResourceGroupName "test-rg-01" -CheckpointName "Test-01" -CheckpointDescription "Test-Desc-01"
```

Creates a VM checkpoint with given Name and Description values for Checkpoint. To get details of the created checkpoint perform a Get VM operation using `Get-AzScVmmVM`.

### Example 2: Create VM checkpoint
```powershell
$CheckpointProperties = '{
    "name": "Test-02",
    "description": "Test-Desc-02"
}'
New-AzScVmmVMCheckpoint -Name "test-vm" -ResourceGroupName "test-rg-01" -JsonString $CheckpointProperties
```

Creates a VM checkpoint with Checkpoint name and description in JsonString. To get details of the created checkpoint perform a Get VM operation using `Get-AzScVmmVM`.
