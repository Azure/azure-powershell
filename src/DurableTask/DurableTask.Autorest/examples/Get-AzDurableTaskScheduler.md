### Example 1: List all schedulers in a subscription
```powershell
Get-AzDurableTaskScheduler
```

```output
Endpoint                     : https://test.northcentralus.1.durabletask.io
IPAllowlist                  : {10.0.0.0/8}
Id                           : /subscriptions/EE9BD735-67CE-4A90-89C4-439D3F6A4C93/resourceGroups/rgopenapi/providers/Microsoft.DurableTask/schedulers/testscheduler
Location                     : North Central US
Name                         : testscheduler
ProvisioningState            : Succeeded
ResourceGroupName            : rgopenapi
SkuCapacity                  : 3
SkuName                      : Dedicated
SkuRedundancyState           : Zone
SystemDataCreatedAt          : 4/17/2024 3:34:17 PM
SystemDataCreatedBy          : tenmbevaunjzikxowqexrsx
SystemDataCreatedByType      : User
SystemDataLastModifiedAt     : 4/17/2024 3:34:17 PM
SystemDataLastModifiedBy     : xfvdcegtj
SystemDataLastModifiedByType : User
Tag                          : {
                                 "department": "research",
                                 "development": "true"
                               }
Type                         : Microsoft.DurableTask/schedulers
```

Lists all Durable Task schedulers in the current subscription.

### Example 2: Get a specific scheduler by name
```powershell
Get-AzDurableTaskScheduler -ResourceGroupName "rgopenapi" -Name "testscheduler"
```

```output
Endpoint                     : https://test.northcentralus.1.durabletask.io
IPAllowlist                  : {10.0.0.0/8}
Id                           : /subscriptions/EE9BD735-67CE-4A90-89C4-439D3F6A4C93/resourceGroups/rgopenapi/providers/Microsoft.DurableTask/schedulers/testscheduler
Location                     : North Central US
Name                         : testscheduler
ProvisioningState            : Succeeded
ResourceGroupName            : rgopenapi
SkuCapacity                  : 3
SkuName                      : Dedicated
SkuRedundancyState           : Zone
SystemDataCreatedAt          : 4/17/2024 3:34:17 PM
SystemDataCreatedBy          : tenmbevaunjzikxowqexrsx
SystemDataCreatedByType      : User
SystemDataLastModifiedAt     : 4/17/2024 3:34:17 PM
SystemDataLastModifiedBy     : xfvdcegtj
SystemDataLastModifiedByType : User
Tag                          : {
                                 "department": "research",
                                 "development": "true"
                               }
Type                         : Microsoft.DurableTask/schedulers
```

Gets the details of a specific Durable Task scheduler by name and resource group.

### Example 3: List schedulers in a resource group
```powershell
Get-AzDurableTaskScheduler -ResourceGroupName "rgopenapi"
```

```output
Endpoint                     : https://test.northcentralus.1.durabletask.io
IPAllowlist                  : {10.0.0.0/8}
Id                           : /subscriptions/EE9BD735-67CE-4A90-89C4-439D3F6A4C93/resourceGroups/rgopenapi/providers/Microsoft.DurableTask/schedulers/testscheduler
Location                     : North Central US
Name                         : testscheduler
ProvisioningState            : Succeeded
ResourceGroupName            : rgopenapi
SkuCapacity                  : 3
SkuName                      : Dedicated
SkuRedundancyState           : Zone
SystemDataCreatedAt          : 4/17/2024 3:34:17 PM
SystemDataCreatedBy          : tenmbevaunjzikxowqexrsx
SystemDataCreatedByType      : User
SystemDataLastModifiedAt     : 4/17/2024 3:34:17 PM
SystemDataLastModifiedBy     : xfvdcegtj
SystemDataLastModifiedByType : User
Tag                          : {
                                 "department": "research",
                                 "development": "true"
                               }
Type                         : Microsoft.DurableTask/schedulers
```

Lists all Durable Task schedulers in a specific resource group.

### Example 4: Get a scheduler using pipeline input
```powershell
$scheduler = Get-AzDurableTaskScheduler -ResourceGroupName "rgopenapi" -Name "testscheduler"
$scheduler | Get-AzDurableTaskScheduler
```

```output
Endpoint                     : https://test.northcentralus.1.durabletask.io
IPAllowlist                  : {10.0.0.0/8}
Id                           : /subscriptions/EE9BD735-67CE-4A90-89C4-439D3F6A4C93/resourceGroups/rgopenapi/providers/Microsoft.DurableTask/schedulers/testscheduler
Location                     : North Central US
Name                         : testscheduler
ProvisioningState            : Succeeded
ResourceGroupName            : rgopenapi
SkuCapacity                  : 3
SkuName                      : Dedicated
SkuRedundancyState           : Zone
SystemDataCreatedAt          : 4/17/2024 3:34:17 PM
SystemDataCreatedBy          : tenmbevaunjzikxowqexrsx
SystemDataCreatedByType      : User
SystemDataLastModifiedAt     : 4/17/2024 3:34:17 PM
SystemDataLastModifiedBy     : xfvdcegtj
SystemDataLastModifiedByType : User
Tag                          : {
                                 "department": "research",
                                 "development": "true"
                               }
Type                         : Microsoft.DurableTask/schedulers
```

Gets a scheduler using an input object via pipeline (GetViaIdentity parameter set).
