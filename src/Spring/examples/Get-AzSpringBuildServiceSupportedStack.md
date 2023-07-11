### Example 1: Get all supported stack resource
```powershell
Get-AzSpringBuildServiceSupportedStack -ResourceGroupName Spring-gp-junxi -ServiceName Spring-01
```

```output
Name                             ResourceGroupName StackId                     Version
----                             ----------------- -------                     -------
io.buildpacks.stacks.bionic-base Springrg     io.buildpacks.stacks.bionic base
io.buildpacks.stacks.bionic-full Springrg     io.buildpacks.stacks.bionic full
```

Get all supported stack resource.

### Example 2: Get the supported stack resource
```powershell
Get-AzSpringBuildServiceSupportedStack -ResourceGroupName Spring-gp-junxi -ServiceName Spring-01 -Name io.buildpacks.stacks.bionic-full
```

```output
Name                             ResourceGroupName StackId                     Version
----                             ----------------- -------                     -------
io.buildpacks.stacks.bionic-base Springrg     io.buildpacks.stacks.bionic base
```

Get the supported stack resource.

