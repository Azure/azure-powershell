### Example 1: Create a mongo cluster
```powershell
$password = ConvertTo-SecureString 'CliTest2026!Pw' -AsPlainText -Force
New-AzDocumentDBMongoCluster -Name myCluster -ResourceGroupName myResourceGroup -Location eastus2 `
    -AdministratorUserName testadmin -AdministratorPassword $password `
    -ComputeTier M30 -StorageSizeGb 128 -StorageType PremiumSSD `
    -ShardingShardCount 1 -HighAvailabilityTargetMode Disabled
```

```output
Name        Location ProvisioningState
----        -------- -----------------
myCluster   eastus2  Succeeded
```

Create a mongo cluster with native authentication, an M30 compute tier, 128 GB of
PremiumSSD storage, a single shard, and high availability disabled.

### Example 2: Create a mongo cluster with Microsoft Entra authentication and additional properties
```powershell
$password = ConvertTo-SecureString 'CliTest2026!Pw' -AsPlainText -Force
New-AzDocumentDBMongoCluster -Name myCluster -ResourceGroupName myResourceGroup -Location eastus2 `
    -AdministratorUserName testadmin -AdministratorPassword $password `
    -ComputeTier M30 -StorageSizeGb 128 -StorageType PremiumSSD `
    -ShardingShardCount 1 -HighAvailabilityTargetMode Disabled `
    -ServerVersion 7.0 -PublicNetworkAccess Enabled `
    -AuthConfigAllowedMode NativeAuth,MicrosoftEntraID -Tag @{ env = 'prod'; team = 'cli' }
```

```output
Name        Location ProvisioningState
----        -------- -----------------
myCluster   eastus2  Succeeded
```

Create a mongo cluster that allows both native and Microsoft Entra ID authentication,
pins the server version, enables public network access, and applies resource tags.
