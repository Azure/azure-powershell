### Example 1: Initialize AzStackHCI replication infrastructure
```powershell
Initialize-AzMigrateHCIReplicationInfrastructure -ProjectName "testproj" -ResourceGroupName "test-rg" -SourceApplianceName "testsrcapp" -TargetApplianceName "testtgtapp" -PassThur
```

```output
$true
```

Initialize AzStackHCI replication infrastructure. Cache storage account, replication policy, and replication extension will be created automatically.

### Example 2: Initialize AzStackHCI replication infrastructure with custom cache storage account
```powershell
$cacheStorageAccount = Get-AzStorageAccount -ResourceGroupName "test-rg" -Name "customcachesa"

Initialize-AzMigrateHCIReplicationInfrastructure -ProjectName "testproj" -ResourceGroupName "test-rg" -CacheStorageAccountId $cacheStorageAccount.Id -SourceApplianceName "testsrcapp" -TargetApplianceName "testtgtapp" -PassThur
```

```output
$true
```

Initialize AzStackHCI replication infrastructure with custom cache storage account. Replication policy and replication extension will be created automatically.

