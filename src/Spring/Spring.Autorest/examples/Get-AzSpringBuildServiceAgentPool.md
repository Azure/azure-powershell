### Example 1: Get build service agent pool.
```powershell
Get-AzSpringBuildServiceAgentPool -ResourceGroupName azps_test_group_spring -ServiceName azps-spring-01
```

```output
Id                           : /subscriptions/9e223dbe-3399-4e19-88eb-0975f02ac87f/resourceGroups/azps_test_group_spring/providers/Microsoft.AppPlatform/Spring/azps-spring-01/buildServices/default/agentPools/
                               default
Name                         : default
PoolSizeCpu                  : 4
PoolSizeMemory               : 8Gi
PoolSizeName                 : S3
ProvisioningState            : Succeeded
ResourceGroupName            : azps_test_group_spring
SystemDataCreatedAt          :
SystemDataCreatedBy          :
SystemDataCreatedByType      :
SystemDataLastModifiedAt     :
SystemDataLastModifiedBy     :
SystemDataLastModifiedByType :
Type                         : Microsoft.AppPlatform/Spring/buildServices/agentPools
```

Get build service agent pool.

### Example 2: Get build service agent pool.
```powershell
$buildserviceObj = Get-AzSpringBuildService -ResourceGroupName azps_test_group_spring -ServiceName azps-spring-01
Get-AzSpringBuildServiceAgentPool -BuildServiceInputObject $buildserviceObj
```

```output
Id                           : /subscriptions/9e223dbe-3399-4e19-88eb-0975f02ac87f/resourceGroups/azps_test_group_spring/providers/Microsoft.AppPlatform/Spring/azps-spring-01/buildServices/default/agentPools/
                               default
Name                         : default
PoolSizeCpu                  : 4
PoolSizeMemory               : 8Gi
PoolSizeName                 : S3
ProvisioningState            : Succeeded
ResourceGroupName            : azps_test_group_spring
SystemDataCreatedAt          :
SystemDataCreatedBy          :
SystemDataCreatedByType      :
SystemDataLastModifiedAt     :
SystemDataLastModifiedBy     :
SystemDataLastModifiedByType :
Type                         : Microsoft.AppPlatform/Spring/buildServices/agentPools
```

Get build service agent pool.

### Example 3: Get build service agent pool.
```powershell
$serviceObj = Get-AzSpringService -ResourceGroupName azps_test_group_spring -Name azps-spring-01
Get-AzSpringBuildServiceAgentPool -SpringInputObject $serviceObj
```

```output
Id                           : /subscriptions/9e223dbe-3399-4e19-88eb-0975f02ac87f/resourceGroups/azps_test_group_spring/providers/Microsoft.AppPlatform/Spring/azps-spring-01/buildServices/default/agentPools/
                               default
Name                         : default
PoolSizeCpu                  : 4
PoolSizeMemory               : 8Gi
PoolSizeName                 : S3
ProvisioningState            : Succeeded
ResourceGroupName            : azps_test_group_spring
SystemDataCreatedAt          :
SystemDataCreatedBy          :
SystemDataCreatedByType      :
SystemDataLastModifiedAt     :
SystemDataLastModifiedBy     :
SystemDataLastModifiedByType :
Type                         : Microsoft.AppPlatform/Spring/buildServices/agentPools
```

Get build service agent pool.