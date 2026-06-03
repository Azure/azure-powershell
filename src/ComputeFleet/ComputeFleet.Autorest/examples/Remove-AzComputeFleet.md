### Example 1: Delete a Compute Fleet by name
```powershell
Remove-AzComputeFleet -Name "fleet1" -ResourceGroupName "fleet-ps-tst"
```

Deletes the specified Compute Fleet and all its associated resources. The command does not produce output by default. After deletion, attempting to retrieve the fleet with `Get-AzComputeFleet` will return a "resource not found" error.

### Example 2: Delete a Compute Fleet with PassThru
```powershell
Remove-AzComputeFleet -Name "fleet1" -ResourceGroupName "fleet-ps-tst" -PassThru
```

```output
True
```

Deletes the specified Compute Fleet and returns a boolean indicating success when the `-PassThru` switch is used.