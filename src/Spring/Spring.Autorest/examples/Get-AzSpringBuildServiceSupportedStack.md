### Example 1: List supported stack resource.
```powershell
Get-AzSpringBuildServiceSupportedStack -ResourceGroupName azps_test_group_spring -ServiceName azps-spring-01
```

```output
Name                             ResourceGroupName      StackId                     Version
----                             -----------------      -------                     -------
io.buildpacks.stacks.bionic-base azps_test_group_spring io.buildpacks.stacks.bionic base
io.buildpacks.stacks.bionic-full azps_test_group_spring io.buildpacks.stacks.bionic full
io.buildpacks.stacks.jammy-base  azps_test_group_spring io.buildpacks.stacks.jammy  base
io.buildpacks.stacks.jammy-full  azps_test_group_spring io.buildpacks.stacks.jammy  full
io.buildpacks.stacks.jammy-tiny  azps_test_group_spring io.buildpacks.stacks.jammy  tiny
```

List supported stack resource.

### Example 2: Get the supported stack resource.
```powershell
Get-AzSpringBuildServiceSupportedStack -ResourceGroupName azps_test_group_spring -ServiceName azps-spring-01 -Name io.buildpacks.stacks.bionic-base
```

```output
Id                           : /subscriptions/9e223dbe-3399-4e19-88eb-0975f02ac87f/resourceGroups/azps_test_group_spring/providers/Microsoft.AppPlatform/Spring/azps-spring-01/buildServices/default/supportedSt
                               acks/io.buildpacks.stacks.bionic-base
Name                         : io.buildpacks.stacks.bionic-base
ResourceGroupName            : azps_test_group_spring
StackId                      : io.buildpacks.stacks.bionic
SystemDataCreatedAt          :
SystemDataCreatedBy          :
SystemDataCreatedByType      :
SystemDataLastModifiedAt     :
SystemDataLastModifiedBy     :
SystemDataLastModifiedByType :
Type                         : Microsoft.AppPlatform/Spring/buildServices/supportedStacks
Version                      : base
```

Get the supported stack resource.

### Example 3: Get the supported stack resource.
```powershell
$serviceObj = Get-AzSpringService -ResourceGroupName azps_test_group_spring -Name azps-spring-01
Get-AzSpringBuildServiceSupportedStack -SpringInputObject $serviceObj -Name io.buildpacks.stacks.bionic-base
```

```output
Id                           : /subscriptions/9e223dbe-3399-4e19-88eb-0975f02ac87f/resourceGroups/azps_test_group_spring/providers/Microsoft.AppPlatform/Spring/azps-spring-01/buildServices/default/supportedSt
                               acks/io.buildpacks.stacks.bionic-base
Name                         : io.buildpacks.stacks.bionic-base
ResourceGroupName            : azps_test_group_spring
StackId                      : io.buildpacks.stacks.bionic
SystemDataCreatedAt          :
SystemDataCreatedBy          :
SystemDataCreatedByType      :
SystemDataLastModifiedAt     :
SystemDataLastModifiedBy     :
SystemDataLastModifiedByType :
Type                         : Microsoft.AppPlatform/Spring/buildServices/supportedStacks
Version                      : base
```

Get the supported stack resource.

### Example 4: Get the supported stack resource.
```powershell
$buildserviceObj = Get-AzSpringBuildService -ResourceGroupName azps_test_group_spring -ServiceName azps-spring-01
Get-AzSpringBuildServiceSupportedStack -BuildServiceInputObject $buildserviceObj -Name io.buildpacks.stacks.bionic-base
```

```output
Id                           : /subscriptions/9e223dbe-3399-4e19-88eb-0975f02ac87f/resourceGroups/azps_test_group_spring/providers/Microsoft.AppPlatform/Spring/azps-spring-01/buildServices/default/supportedSt
                               acks/io.buildpacks.stacks.bionic-base
Name                         : io.buildpacks.stacks.bionic-base
ResourceGroupName            : azps_test_group_spring
StackId                      : io.buildpacks.stacks.bionic
SystemDataCreatedAt          :
SystemDataCreatedBy          :
SystemDataCreatedByType      :
SystemDataLastModifiedAt     :
SystemDataLastModifiedBy     :
SystemDataLastModifiedByType :
Type                         : Microsoft.AppPlatform/Spring/buildServices/supportedStacks
Version                      : base
```

Get the supported stack resource.