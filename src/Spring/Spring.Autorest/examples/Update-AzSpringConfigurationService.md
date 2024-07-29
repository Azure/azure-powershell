### Example 1: Update the default Application Configuration Service or Update the existing Application Configuration Service.
```powershell
$servicegitObj = New-AzSpringConfigurationServiceGitObject -Label "master" -Name "ghatest" -Pattern "app/dev" -Uri "https://github.com/lijinpei2008/ghatest"
Update-AzSpringConfigurationService -ResourceGroupName azps_test_group_spring -ServiceName azps-spring-01 -GitRepository $servicegitObj
```

```output
Generation                   :
GitPropertyRepository        : {{
                                 "name": "ghatest",
                                 "patterns": [ "app/dev" ],
                                 "uri": "https://github.com/lijinpei2008/ghatest",
                                 "label": "master"
                               }}
Id                           : /subscriptions/9e223dbe-3399-4e19-88eb-0975f02ac87f/resourceGroups/azps_test_group_spring/providers/Microsoft.AppPlatform/Spring/azps-spring-01/configurationServices/default
Instance                     : {{
                                 "name": "application-configuration-service-75c6854898-lqswl",
                                 "status": "Running"
                               }, {
                                 "name": "application-configuration-service-75c6854898-nrcf7",
                                 "status": "Running"
                               }}
Name                         : default
ProvisioningState            : Succeeded
ResourceGroupName            : azps_test_group_spring
ResourceRequestCpu           : 500m
ResourceRequestInstanceCount : 2
ResourceRequestMemory        : 1Gi
SystemDataCreatedAt          : 2024-05-24 上午 07:04:16
SystemDataCreatedBy          : v-jinpel@microsoft.com
SystemDataCreatedByType      : User
SystemDataLastModifiedAt     : 2024-05-28 上午 10:16:39
SystemDataLastModifiedBy     : v-jinpel@microsoft.com
SystemDataLastModifiedByType : User
Type                         : Microsoft.AppPlatform/Spring/configurationServices
```

Update the default Application Configuration Service or Update the existing Application Configuration Service.