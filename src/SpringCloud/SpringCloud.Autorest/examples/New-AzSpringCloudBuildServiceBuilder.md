### Example 1: Create or update a KPack builder
```powershell
New-AzSpringCloudBuildServiceBuilder -ResourceGroupName springcloudrg -ServiceName sspring-portal01 -Name builder01 -StackId 'io.buildpacks.stacks.bionic' -StackVersion 'base'
```

```output
Name      ResourceGroupName ProvisioningState StackId                     StackVersion
----      ----------------- ----------------- -------                     ------------
builder01 springcloudrg     Succeeded         io.buildpacks.stacks.bionic base
```

Create or update a KPack builder.