### Example 1: Tells a Stopped state cache to transition to Active state.
```powershell
Start-AzStorageCache -Name azps-storagecache -ResourceGroupName azps_test_gp_storagecache
```

Tells a Stopped state cache to transition to Active state.

### Example 2: Tells a Stopped state cache to transition to Active state.
```powershell
Start-AzStorageCache -Name azps-storagecache -ResourceGroupName azps_test_gp_storagecache -PassThru
```

```output
True
```

Tells a Stopped state cache to transition to Active state.