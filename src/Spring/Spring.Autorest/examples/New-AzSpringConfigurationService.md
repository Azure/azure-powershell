### Example 1: Create the default Application Configuration Service or Create the existing Application Configuration Service.
```powershell
$servicegitObj = New-AzSpringConfigurationServiceGitObject -Label "master" -Name "ghatest" -Pattern "app/dev" -Uri "https://github.com/lijinpei2008/ghatest"
New-AzSpringConfigurationService -ResourceGroupName azps_test_group_spring -ServiceName azps-spring-01 -GitRepository $servicegitObj
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
                                 "name": "application-configuration-service-7c6755755b-mrz4m",
                                 "status": "Running"
                               }, {
                                 "name": "application-configuration-service-7c6755755b-rnz7j",
                                 "status": "Running"
                               }}
Name                         : default
ProvisioningState            : Succeeded
ResourceGroupName            : azps_test_group_spring
ResourceRequestCpu           : 500m
ResourceRequestInstanceCount : 2
ResourceRequestMemory        : 1Gi
SystemDataCreatedAt          : 2024-04-26 上午 07:46:44
SystemDataCreatedBy          : v-jinpel@microsoft.com
SystemDataCreatedByType      : User
SystemDataLastModifiedAt     : 2024-04-26 上午 07:46:44
SystemDataLastModifiedBy     : v-jinpel@microsoft.com
SystemDataLastModifiedByType : User
Type                         : Microsoft.AppPlatform/Spring/configurationServices
```

Create the default Application Configuration Service or Create the existing Application Configuration Service.