### Example 1: Get a build service agent pool
```powershell
Get-AzSpringBuildServiceAgentPool -ResourceGroupName Springrg -ServiceName sspring-portal01
```

```output
Name    ResourceGroupName ProvisioningState PoolSizeCpu PoolSizeMemory PoolSizeName
----    ----------------- ----------------- ----------- -------------- ------------
default Springrg     Succeeded         2           4Gi            S1
```

Get a build service agent pool.


### Example 2: Get a build service agent pool by pipeline
```powershell
New-AzSpringBuildServiceAgentPool -ResourceGroupName Springrg -ServiceName espring-pwsh01 -PoolSizeName "S1" | Get-AzSpringBuildServiceAgentPool
```

```output
Name    ResourceGroupName ProvisioningState PoolSizeCpu PoolSizeMemory PoolSizeName
----    ----------------- ----------------- ----------- -------------- ------------
default Springrg     Succeeded         2           4Gi            S1
```

Get a build service agent pool by pipeline.