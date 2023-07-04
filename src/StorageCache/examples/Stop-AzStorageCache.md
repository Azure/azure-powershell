### Example 1: Tells an Active cache to transition to Stopped state.
```powershell
Stop-AzStorageCache -Name azps-storagecache -ResourceGroupName azps_test_gp_storagecache
```

Tells an Active cache to transition to Stopped state.

### Example 2: Tells an Active cache to transition to Stopped state.
```powershell
Stop-AzStorageCache -Name azps-storagecache -ResourceGroupName azps_test_gp_storagecache -PassThru
```

```output
True
```

Tells an Active cache to transition to Stopped state.