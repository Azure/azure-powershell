### Example 1: Update a KPack builder
```powershell
Update-AzSpringCloudBuildServiceBuilder -ResourceGroupName springcloudrg -ServiceName sspring-portal01 -Name builder01 -StackId 'io.buildpacks.stacks.bionic' -StackVersion 'base'
```

```output
Name      ResourceGroupName ProvisioningState StackId                     StackVersion
----      ----------------- ----------------- -------                     ------------
builder01 springcloudrg     Succeeded         io.buildpacks.stacks.bionic base
```

This command updates a KPack builder.