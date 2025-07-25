### Example 1: Delete a Fleet
```powershell
Remove-AzFleet -Name ttt -ResourceGroupName ps1-test
```

This command deletes a Fleet resource asynchronously with a long running operation.

### Example 2: Delete a Fleet
```powershell
$f = Get-AzFleet -Name sss -ResourceGroupName ps1-test
Remove-AzFleet -InputObject $f
```

This command deletes a Fleet resource with fleet object.

