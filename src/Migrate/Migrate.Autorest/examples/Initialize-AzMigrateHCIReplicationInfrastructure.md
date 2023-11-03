### Example 1: Initialize AzStackHCI replication infrastructure
```powershell
Initialize-AzMigrateHCIReplicationInfrastructure -ProjectName "testproj" -ResourceGroupName "test-rg" -SourceApplianceName "testsrcapp" -TargetApplianceName "testtgtapp" -PassThru:$true
```

```output
$true
```

Initialize AzStackHCI replication infrastructure. Cache storage account, replication policy, and replication extension will be created automatically.

### Example 2: Initialize AzStackHCI replication infrastructure with custom cache storage account
```powershell
$cacheStorageAccountId = "/subscriptions/xxx-xxx-xxxx/resourceGroups/test-rg/providers/Microsoft.Storage/storageAccounts/testSa"

Initialize-AzMigrateHCIReplicationInfrastructure -ProjectName "testproj" -ResourceGroupName "test-rg" -CacheStorageAccountId $cacheStorageAccountId -SourceApplianceName "testsrcapp" -TargetApplianceName "testtgtapp" -PassThru:$true
```

```output
$true
```

Initialize AzStackHCI replication infrastructure with custom cache storage account. Replication policy and replication extension will be created automatically.

