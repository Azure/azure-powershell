### Example 1: Update build service agent pool.
```powershell
New-AzSpringBuildServiceAgentPool -ResourceGroupName azps_test_group_spring -ServiceName azps-spring-01 -PoolSizeName "S3"
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

Update build service agent pool.