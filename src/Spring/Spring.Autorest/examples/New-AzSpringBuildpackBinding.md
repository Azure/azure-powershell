### Example 1: Create a buildpack binding.
```powershell
New-AzSpringBuildpackBinding -BuilderName azps-builder -Name azps -ResourceGroupName azps_test_group_spring -ServiceName azps-spring-01 -BindingType ApplicationInsights -LaunchProperty @{"abc"="def";"any-string"="any-string";"sampling-rate"="12.0"} -LaunchSecret @{"connection-string"="XXXXXXXXXXXXXXXXX=XXXXXXXXXXXXX-XXXXXXXXXXXXXXXXXXX;XXXXXXXXXXXXXXXXX=XXXXXXXXXXXXXXXXXXX"}
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

Create a buildpack binding.
The length of BuildServiceName + BuilderName + BuildpacksBindingName cannot be greater than 30.