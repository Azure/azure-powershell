### Example 1: List all KPack builder
```powershell
Get-AzSpringCloudBuildServiceBuilder -ResourceGroupName springcloudrg -ServiceName sspring-portal01
```

```output
Name    ResourceGroupName ProvisioningState StackId                     StackVersion
----    ----------------- ----------------- -------                     ------------
default springcloudrg     Succeeded         io.buildpacks.stacks.bionic base
```

List all KPack builder.

### Example 2: List all KPack builders under build service
```powershell
Get-AzSpringCloudBuildServiceBuilder -ResourceGroupName springcloudrg -ServiceName sspring-portal01 -Name default
```

```output
Name    ResourceGroupName ProvisioningState StackId                     StackVersion
----    ----------------- ----------------- -------                     ------------
default springcloudrg     Succeeded         io.buildpacks.stacks.bionic base
```

List all KPack builders under build service.

### Example 2: Get a KPack builder by pipeline
```powershell
New-AzSpringCloudBuildServiceBuilder -ResourceGroupName springcloudrg -ServiceName sspring-portal01 -Name builder03 -StackId 'io.buildpacks.stacks.bionic' -StackVersion 'base' | Get-AzSpringCloudBuildServiceBuilder
```

```output
Name    ResourceGroupName ProvisioningState StackId                     StackVersion
----    ----------------- ----------------- -------                     ------------
builder01 springcloudrg     Succeeded         io.buildpacks.stacks.bionic base
```

Get a KPack builder by pipeline.