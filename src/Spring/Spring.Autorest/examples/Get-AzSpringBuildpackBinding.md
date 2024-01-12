### Example 1: List buildpack binding by name.
```powershell
Get-AzSpringBuildpackBinding -ResourceGroupName azps_test_group_spring -ServiceName azps-spring-01 -BuilderName azps-builder
```

```output
BindingType                  : ApplicationInsights
Id                           : /subscriptions/9e223dbe-3399-4e19-88eb-0975f02ac87f/resourceGroups/azps_test_group_spring/providers/Microsoft.AppPlatform/Spring/azps-spring-01/buildServices/default/builders/az
                               ps-builder/buildpackBindings/azps
LaunchPropertyProperties     : {
                                 "abc": "def",
                                 "any-string": "any-string",
                                 "sampling-rate": "12.0"
                               }
LaunchPropertySecret         : {
                                 "connection-string": "*"
                               }
Name                         : azps
ProvisioningState            : Succeeded
ResourceGroupName            : azps_test_group_spring
SystemDataCreatedAt          : 2023-12-19 上午 03:57:38
SystemDataCreatedBy          : v-jinpel@microsoft.com
SystemDataCreatedByType      : User
SystemDataLastModifiedAt     : 2023-12-19 上午 03:57:38
SystemDataLastModifiedBy     : v-jinpel@microsoft.com
SystemDataLastModifiedByType : User
Type                         : Microsoft.AppPlatform/Spring/buildServices/builders/buildpackBindings
```

List buildpack binding by name.

### Example 2: Get a buildpack binding by name.
```powershell
Get-AzSpringBuildpackBinding -ResourceGroupName azps_test_group_spring -ServiceName azps-spring-01 -BuilderName azps-builder -Name azps
```

```output
BindingType                  : ApplicationInsights
Id                           : /subscriptions/9e223dbe-3399-4e19-88eb-0975f02ac87f/resourceGroups/azps_test_group_spring/providers/Microsoft.AppPlatform/Spring/azps-spring-01/buildServices/default/builders/az
                               ps-builder/buildpackBindings/azps
LaunchPropertyProperties     : {
                                 "abc": "def",
                                 "any-string": "any-string",
                                 "sampling-rate": "12.0"
                               }
LaunchPropertySecret         : {
                                 "connection-string": "*"
                               }
Name                         : azps
ProvisioningState            : Succeeded
ResourceGroupName            : azps_test_group_spring
SystemDataCreatedAt          : 2023-12-19 上午 03:57:38
SystemDataCreatedBy          : v-jinpel@microsoft.com
SystemDataCreatedByType      : User
SystemDataLastModifiedAt     : 2023-12-19 上午 03:57:38
SystemDataLastModifiedBy     : v-jinpel@microsoft.com
SystemDataLastModifiedByType : User
Type                         : Microsoft.AppPlatform/Spring/buildServices/builders/buildpackBindings
```

Get a buildpack binding by name.

### Example 3: Get a buildpack binding by name.
```powershell
$buildserviceObj = Get-AzSpringBuildService -ResourceGroupName azps_test_group_spring -ServiceName azps-spring-01
Get-AzSpringBuildpackBinding -BuildServiceInputObject $buildserviceObj -BuilderName azps-builder -Name azps
```

```output
BindingType                  : ApplicationInsights
Id                           : /subscriptions/9e223dbe-3399-4e19-88eb-0975f02ac87f/resourceGroups/azps_test_group_spring/providers/Microsoft.AppPlatform/Spring/azps-spring-01/buildServices/default/builders/az
                               ps-builder/buildpackBindings/azps
LaunchPropertyProperties     : {
                                 "abc": "def",
                                 "any-string": "any-string",
                                 "sampling-rate": "12.0"
                               }
LaunchPropertySecret         : {
                                 "connection-string": "*"
                               }
Name                         : azps
ProvisioningState            : Succeeded
ResourceGroupName            : azps_test_group_spring
SystemDataCreatedAt          : 2023-12-19 上午 03:57:38
SystemDataCreatedBy          : v-jinpel@microsoft.com
SystemDataCreatedByType      : User
SystemDataLastModifiedAt     : 2023-12-19 上午 03:57:38
SystemDataLastModifiedBy     : v-jinpel@microsoft.com
SystemDataLastModifiedByType : User
Type                         : Microsoft.AppPlatform/Spring/buildServices/builders/buildpackBindings
```

Get a buildpack binding by name.

### Example 4: Get a buildpack binding by name.
```powershell
$serviceObj = Get-AzSpringService -ResourceGroupName azps_test_group_spring -Name azps-spring-01
Get-AzSpringBuildpackBinding -SpringInputObject $serviceObj -BuilderName azps-builder -Name azps
```

```output
BindingType                  : ApplicationInsights
Id                           : /subscriptions/9e223dbe-3399-4e19-88eb-0975f02ac87f/resourceGroups/azps_test_group_spring/providers/Microsoft.AppPlatform/Spring/azps-spring-01/buildServices/default/builders/az
                               ps-builder/buildpackBindings/azps
LaunchPropertyProperties     : {
                                 "abc": "def",
                                 "any-string": "any-string",
                                 "sampling-rate": "12.0"
                               }
LaunchPropertySecret         : {
                                 "connection-string": "*"
                               }
Name                         : azps
ProvisioningState            : Succeeded
ResourceGroupName            : azps_test_group_spring
SystemDataCreatedAt          : 2023-12-19 上午 03:57:38
SystemDataCreatedBy          : v-jinpel@microsoft.com
SystemDataCreatedByType      : User
SystemDataLastModifiedAt     : 2023-12-19 上午 03:57:38
SystemDataLastModifiedBy     : v-jinpel@microsoft.com
SystemDataLastModifiedByType : User
Type                         : Microsoft.AppPlatform/Spring/buildServices/builders/buildpackBindings
```

Get a buildpack binding by name.

### Example 5: Get a buildpack binding by name.
```powershell
$builderservicebuilderObj = Get-AzSpringBuildServiceBuilder -resourceGroupName azps_test_group_spring -ServiceName azps-spring-01 -Name azps-builder
Get-AzSpringBuildpackBinding -BuilderInputObject $builderservicebuilderObj -Name azps
```

```output
BindingType                  : ApplicationInsights
Id                           : /subscriptions/9e223dbe-3399-4e19-88eb-0975f02ac87f/resourceGroups/azps_test_group_spring/providers/Microsoft.AppPlatform/Spring/azps-spring-01/buildServices/default/builders/az
                               ps-builder/buildpackBindings/azps
LaunchPropertyProperties     : {
                                 "abc": "def",
                                 "any-string": "any-string",
                                 "sampling-rate": "12.0"
                               }
LaunchPropertySecret         : {
                                 "connection-string": "*"
                               }
Name                         : azps
ProvisioningState            : Succeeded
ResourceGroupName            : azps_test_group_spring
SystemDataCreatedAt          : 2023-12-19 上午 03:57:38
SystemDataCreatedBy          : v-jinpel@microsoft.com
SystemDataCreatedByType      : User
SystemDataLastModifiedAt     : 2023-12-19 上午 03:57:38
SystemDataLastModifiedBy     : v-jinpel@microsoft.com
SystemDataLastModifiedByType : User
Type                         : Microsoft.AppPlatform/Spring/buildServices/builders/buildpackBindings
```

Get a buildpack binding by name.