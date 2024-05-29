### Example 1: Get the container registries resource.
```powershell
Get-AzSpringContainerRegistry -ResourceGroupName azps_test_group_spring -ServiceName azps-spring-01
```

```output
Credentials                  : {
                                 "type": "BasicAuth",
                                 "server": "azpsacr0523.azurecr.io",
                                 "username": "azpsacr0523"
                               }
Id                           : /subscriptions/9e223dbe-3399-4e19-88eb-0975f02ac87f/resourceGroups/azps_test_group_spring/providers/Microsoft.AppPlatform/Spring/azps-spring-01/containerRegistries/default
Name                         : default
ProvisioningState            : Succeeded
ResourceGroupName            : azps_test_group_spring
SystemDataCreatedAt          : 2024-05-24 上午 07:55:46
SystemDataCreatedBy          : v-jinpel@microsoft.com
SystemDataCreatedByType      : User
SystemDataLastModifiedAt     : 2024-05-24 上午 07:55:46
SystemDataLastModifiedBy     : v-jinpel@microsoft.com
SystemDataLastModifiedByType : User
Type                         : Microsoft.AppPlatform/Spring/containerRegistries
```

Get the container registries resource.

### Example 2: Get the container registries resource.
```powershell
Get-AzSpringContainerRegistry -ResourceGroupName azps_test_group_spring -ServiceName azps-spring-01 -Name default
```

```output
Credentials                  : {
                                 "type": "BasicAuth",
                                 "server": "azpsacr0523.azurecr.io",
                                 "username": "azpsacr0523"
                               }
Id                           : /subscriptions/9e223dbe-3399-4e19-88eb-0975f02ac87f/resourceGroups/azps_test_group_spring/providers/Microsoft.AppPlatform/Spring/azps-spring-01/containerRegistries/default
Name                         : default
ProvisioningState            : Succeeded
ResourceGroupName            : azps_test_group_spring
SystemDataCreatedAt          : 2024-05-24 上午 07:55:46
SystemDataCreatedBy          : v-jinpel@microsoft.com
SystemDataCreatedByType      : User
SystemDataLastModifiedAt     : 2024-05-24 上午 07:55:46
SystemDataLastModifiedBy     : v-jinpel@microsoft.com
SystemDataLastModifiedByType : User
Type                         : Microsoft.AppPlatform/Spring/containerRegistries
```

Get the container registries resource.