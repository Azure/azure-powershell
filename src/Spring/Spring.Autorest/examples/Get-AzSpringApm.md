### Example 1: Get the APM by ServiceName.
```powershell
Get-AzSpringApm -ResourceGroupName azps_test_group_spring -ServiceName azps-spring-01
```

```output
ApmProperty                  : {
                                 "sampling-rate": "12.0",
                                 "any-string": "any-string"
                               }
Id                           : /subscriptions/9e223dbe-3399-4e19-88eb-0975f02ac87f/resourceGroups/azps_test_group_spring/providers/Microsoft.AppPlatform/Spring/azps-spring-01/apms/azps-apm
Name                         : azps-apm
PropertiesType               : ApplicationInsights
ProvisioningState            : Succeeded
ResourceGroupName            : azps_test_group_spring
Secret                       : {
                               }
SystemDataCreatedAt          : 2024-04-27 上午 11:37:47
SystemDataCreatedBy          : v-jinpel@microsoft.com
SystemDataCreatedByType      : User
SystemDataLastModifiedAt     : 2024-04-27 上午 11:37:47
SystemDataLastModifiedBy     : v-jinpel@microsoft.com
SystemDataLastModifiedByType : User
Type                         : Microsoft.AppPlatform/Spring/apms
```

Get the APM by ServiceName.

### Example 2: Get the APM by name.
```powershell
Get-AzSpringApm -ResourceGroupName azps_test_group_spring -ServiceName azps-spring-01 -Name azps-apm
```

```output
ApmProperty                  : {
                                 "sampling-rate": "12.0",
                                 "any-string": "any-string"
                               }
Id                           : /subscriptions/9e223dbe-3399-4e19-88eb-0975f02ac87f/resourceGroups/azps_test_group_spring/providers/Microsoft.AppPlatform/Spring/azps-spring-01/apms/azps-apm
Name                         : azps-apm
PropertiesType               : ApplicationInsights
ProvisioningState            : Succeeded
ResourceGroupName            : azps_test_group_spring
Secret                       : {
                               }
SystemDataCreatedAt          : 2024-04-27 上午 11:37:47
SystemDataCreatedBy          : v-jinpel@microsoft.com
SystemDataCreatedByType      : User
SystemDataLastModifiedAt     : 2024-04-27 上午 11:37:47
SystemDataLastModifiedBy     : v-jinpel@microsoft.com
SystemDataLastModifiedByType : User
Type                         : Microsoft.AppPlatform/Spring/apms
```

Get the APM by name.