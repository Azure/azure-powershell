### Example 1: List KPack builder.
```powershell
Get-AzSpringBuildServiceBuilder -ResourceGroupName azps_test_group_spring -ServiceName azps-spring-01
```

```output
Name         ResourceGroupName      ProvisioningState StackId                     StackVersion
----         -----------------      ----------------- -------                     ------------
azps-builder azps_test_group_spring Succeeded         io.buildpacks.stacks.bionic base
default      azps_test_group_spring Succeeded         io.buildpacks.stacks.bionic base
```

List KPack builder.

### Example 2: Get a KPack builder.
```powershell
Get-AzSpringBuildServiceBuilder -ResourceGroupName azps_test_group_spring -ServiceName azps-spring-01 -Name azps-builder
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
SystemDataCreatedAt          : 2023-12-19 上午 03:16:00
SystemDataCreatedBy          : v-jinpel@microsoft.com
SystemDataCreatedByType      : User
SystemDataLastModifiedAt     : 2023-12-19 上午 03:16:00
SystemDataLastModifiedBy     : v-jinpel@microsoft.com
SystemDataLastModifiedByType : User
Type                         : Microsoft.AppPlatform/Spring/buildServices/builders
```

Get a KPack builder.

### Example 3: Get a KPack builder.
```powershell
$buildserviceObj = Get-AzSpringBuildService -ResourceGroupName azps_test_group_spring -ServiceName azps-spring-01
Get-AzSpringBuildServiceBuilder -BuildServiceInputObject $buildserviceObj -Name azps-builder
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
SystemDataCreatedAt          : 2023-12-19 上午 03:16:00
SystemDataCreatedBy          : v-jinpel@microsoft.com
SystemDataCreatedByType      : User
SystemDataLastModifiedAt     : 2023-12-19 上午 03:16:00
SystemDataLastModifiedBy     : v-jinpel@microsoft.com
SystemDataLastModifiedByType : User
Type                         : Microsoft.AppPlatform/Spring/buildServices/builders
```

Get a KPack builder.

### Example 4: Get a KPack builder.
```powershell
$serviceObj = Get-AzSpringService -ResourceGroupName azps_test_group_spring -Name azps-spring-01
Get-AzSpringBuildServiceBuilder -SpringInputObject $serviceObj -Name azps-builder
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
SystemDataCreatedAt          : 2023-12-19 上午 03:16:00
SystemDataCreatedBy          : v-jinpel@microsoft.com
SystemDataCreatedByType      : User
SystemDataLastModifiedAt     : 2023-12-19 上午 03:16:00
SystemDataLastModifiedBy     : v-jinpel@microsoft.com
SystemDataLastModifiedByType : User
Type                         : Microsoft.AppPlatform/Spring/buildServices/builders
```

Get a KPack builder.