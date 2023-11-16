### Example 1: Deletes the Custom Location.
```powershell
PS C:\> Remove-AzCustomLocation -ResourceGroupName azps_test_group -Name azps_test_cluster

```

Deletes the Custom Location.

### Example 2: Deletes the Custom Location.
```powershell
PS C:\> Get-AzCustomLocation -ResourceGroupName azps_test_group -Name azps_test_cluster | Remove-AzCustomLocation

```

Deletes the Custom Location.