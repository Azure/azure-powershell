### Example 1: Get all supported stack resource
```powershell
Get-AzSpringCloudBuildServiceSupportedStack -ResourceGroupName SpringCloud-gp-junxi -ServiceName springcloud-01
```

```output
Name                             ResourceGroupName StackId                     Version
----                             ----------------- -------                     -------
io.buildpacks.stacks.bionic-base springcloudrg     io.buildpacks.stacks.bionic base
io.buildpacks.stacks.bionic-full springcloudrg     io.buildpacks.stacks.bionic full
```

Get all supported stack resource.

### Example 2: Get the supported stack resource
```powershell
Get-AzSpringCloudBuildServiceSupportedStack -ResourceGroupName SpringCloud-gp-junxi -ServiceName springcloud-01 -Name io.buildpacks.stacks.bionic-full
```

```output
Name                             ResourceGroupName StackId                     Version
----                             ----------------- -------                     -------
io.buildpacks.stacks.bionic-base springcloudrg     io.buildpacks.stacks.bionic base
```

Get the supported stack resource.

