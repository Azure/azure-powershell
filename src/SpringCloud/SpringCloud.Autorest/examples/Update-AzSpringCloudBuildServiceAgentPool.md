### Example 1: Update build service agent pool
```powershell
Update-AzSpringCloudBuildServiceAgentPool -ResourceGroupName springcloudrg -ServiceName espring-pwsh01 -PoolSizeName "S1"
```

```output
Name        ResourceGroupName ProvisioningState StackId                     StackVersion
----        ----------------- ----------------- -------                     ------------
builderfull springcloudrg     Succeeded         io.buildpacks.stacks.bionic full
```

This command updates build service agent pool.