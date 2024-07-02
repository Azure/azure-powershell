### Example 1: Update an APM.
```powershell
$apmProperty = @{"any-string"="any-string";"sampling-rate"="12.0"}
Update-AzSpringApm -Name azps-apm -ResourceGroupName azps_test_group_spring -ServiceName azps-spring-01 -ApmProperty $apmProperty -PropertiesType ApplicationInsights -Secret @{"connection-string"="XXXXXXXXXXXXXXXXX=XXXXXXXXXXXXX-XXXXXXXXXXXXXXXXXXX;XXXXXXXXXXXXXXXXX=XXXXXXXXXXXXXXXXXXX"}
```

```output
ApmProperty                  : {
                                 "any-string": "any-string",
                                 "sampling-rate": "12.0"
                               }
Id                           : /subscriptions/9e223dbe-3399-4e19-88eb-0975f02ac87f/resourceGroups/azps_test_group_spring/providers/Microsoft.AppPlatform/Spring/azps-spring-01/apms/azps-apm
Name                         : azps-apm
PropertiesType               : ApplicationInsights
ProvisioningState            : Succeeded
ResourceGroupName            : azps_test_group_spring
Secret                       : {
                               }
SystemDataCreatedAt          : 2024-05-27 上午 04:29:55
SystemDataCreatedBy          : v-jinpel@microsoft.com
SystemDataCreatedByType      : User
SystemDataLastModifiedAt     : 2024-05-28 下午 12:26:24
SystemDataLastModifiedBy     : v-jinpel@microsoft.com
SystemDataLastModifiedByType : User
Type                         : Microsoft.AppPlatform/Spring/apms
```

Update an APM.