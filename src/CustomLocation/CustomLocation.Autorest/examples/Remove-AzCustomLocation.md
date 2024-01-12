### Example 1: Deletes the Custom Location.
```powershell
Remove-AzCustomLocation -ResourceGroupName azps_test_cluster -Name azps-customlocation
```

Deletes the Custom Location.

### Example 2: Deletes the Custom Location.
```powershell
$obj = Get-AzCustomLocation -ResourceGroupName azps_test_cluster -Name azps-customlocation
Remove-AzCustomLocation -InputObject $obj
```

Deletes the Custom Location.