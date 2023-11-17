### Example 1: List storage cache by subscription.
```powershell
Get-AzStorageCache
```

```output
Location Name              ResourceGroupName
-------- ----              -----------------
eastus   azps-storagecache azps_test_gp_storagecache
```

List storage cache by subscription.

### Example 2: List storage cache by resource group name.
```powershell
Get-AzStorageCache -ResourceGroupName azps_test_gp_storagecache
```

```output
Location Name              ResourceGroupName
-------- ----              -----------------
eastus   azps-storagecache azps_test_gp_storagecache
```

List storage cache by resource group name.

### Example 3: Get a storage cache by name.
```powershell
Get-AzStorageCache -ResourceGroupName azps_test_gp_storagecache -Name azps-storagecache
```

```output
Location Name              ResourceGroupName
-------- ----              -----------------
eastus   azps-storagecache azps_test_gp_storagecache
```

Get a storage cache by name.