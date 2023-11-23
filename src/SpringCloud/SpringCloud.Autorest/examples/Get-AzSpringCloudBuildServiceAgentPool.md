### Example 1: Get a build service agent pool
```powershell
Get-AzSpringCloudBuildServiceAgentPool -ResourceGroupName springcloudrg -ServiceName sspring-portal01
```

```output
Name    ResourceGroupName ProvisioningState PoolSizeCpu PoolSizeMemory PoolSizeName
----    ----------------- ----------------- ----------- -------------- ------------
default springcloudrg     Succeeded         2           4Gi            S1
```

Get a build service agent pool.


### Example 2: Get a build service agent pool by pipeline
```powershell
New-AzSpringCloudBuildServiceAgentPool -ResourceGroupName springcloudrg -ServiceName espring-pwsh01 -PoolSizeName "S1" | Get-AzSpringCloudBuildServiceAgentPool
```

```output
Name    ResourceGroupName ProvisioningState PoolSizeCpu PoolSizeMemory PoolSizeName
----    ----------------- ----------------- ----------- -------------- ------------
default springcloudrg     Succeeded         2           4Gi            S1
```

Get a build service agent pool by pipeline.