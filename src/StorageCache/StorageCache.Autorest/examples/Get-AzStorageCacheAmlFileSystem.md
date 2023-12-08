### Example 1: List AML file system by Subscription.
```powershell
Get-AzStorageCacheAmlFileSystem
```

```output
Name          Location ResourceGroupName         HealthState SkuName
----          -------- -----------------         ----------- -------
azps-cache-fs eastus   azps_test_gp_storagecache Available   AMLFS-Durable-Premium-250
```

List AML file system by Subscription.

### Example 2: Gets AML file system by ResourceGroup.
```powershell
Get-AzStorageCacheAmlFileSystem -ResourceGroupName azps_test_gp_storagecache
```

```output
Name          Location ResourceGroupName         HealthState SkuName
----          -------- -----------------         ----------- -------
azps-cache-fs eastus   azps_test_gp_storagecache Available   AMLFS-Durable-Premium-250
```

Gets AML file system by ResourceGroup.

### Example 3: Get AML file system by Name.
```powershell
Get-AzStorageCacheAmlFileSystem -ResourceGroupName azps_test_gp_storagecache -Name azps-cache-fs
```

```output
Name          Location ResourceGroupName         HealthState SkuName
----          -------- -----------------         ----------- -------
azps-cache-fs eastus   azps_test_gp_storagecache Available   AMLFS-Durable-Premium-250
```

Get AML file system by Name.