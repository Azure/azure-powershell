### Example 1: Create or update build service agent pool
```powershell
New-AzSpringCloudBuildServiceAgentPool -ResourceGroupName springcloudrg -ServiceName espring-pwsh01 -PoolSizeName "S1"
```

```output
Name        ResourceGroupName ProvisioningState StackId                     StackVersion
----        ----------------- ----------------- -------                     ------------
builderfull springcloudrg     Succeeded         io.buildpacks.stacks.bionic full
```

Create or update build service agent pool.
