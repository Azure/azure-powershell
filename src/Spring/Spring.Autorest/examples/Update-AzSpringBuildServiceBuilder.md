### Example 1: Update a KPack builder.
```powershell
$buildpackObj = New-AzSpringBuildpackObject -Id "tanzu-buildpacks/java-azure"
$buildgroupObj = New-AzSpringBuildpacksGroupObject -Buildpack $buildpackObj -Name "mix"
Update-AzSpringBuildServiceBuilder -Name azps-builder -ResourceGroupName azps_test_group_spring -ServiceName azps-spring-01 -BuildpackGroup $buildgroupObj -StackId "io.buildpacks.stacks.bionic" -StackVersion "base"
```

```output
BuildpackGroup               : {{
                                 "name": "mix",
                                 "buildpacks": [
                                   {
                                     "id": "tanzu-buildpacks/java-azure"
                                   }
                                 ]
                               }}
Id                           : /subscriptions/9e223dbe-3399-4e19-88eb-0975f02ac87f/resourceGroups/azps_test_group_spring/providers/Microsoft.AppPlatform/Spring/azps-spring-01/buildServices/default/builders/az
                               ps-builder
Name                         : azps-builder
ProvisioningState            : Succeeded
ResourceGroupName            : azps_test_group_spring
StackId                      : io.buildpacks.stacks.bionic
StackVersion                 : base
SystemDataCreatedAt          : 2024-05-24 上午 08:14:37
SystemDataCreatedBy          : v-jinpel@microsoft.com
SystemDataCreatedByType      : User
SystemDataLastModifiedAt     : 2024-05-28 上午 10:47:05
SystemDataLastModifiedBy     : v-jinpel@microsoft.com
SystemDataLastModifiedByType : User
Type                         : Microsoft.AppPlatform/Spring/buildServices/builders
```

Update a KPack builder.