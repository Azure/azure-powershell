### Example 1: Create a new Durable Task scheduler with basic settings
```powershell
New-AzDurableTaskScheduler -Name "testscheduler" -ResourceGroupName "rgopenapi" -Location "northcentralus" -SkuCapacity 3 -SkuName "Dedicated" -IPAllowlist @("10.0.0.0/8") -Tag @{department="research"; development="true"}
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

Creates a new Durable Task scheduler with Dedicated SKU, IP allowlist, and tags. Output shows all returned properties.

### Example 2: Create a scheduler with JSON file
```powershell
New-AzDurableTaskScheduler -Name "testscheduler" -ResourceGroupName "rgopenapi" -JsonFilePath "./scheduler.json"
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

Creates a Durable Task scheduler using a JSON configuration file. Output shows full resource details.

### Example 3: Create a scheduler with capacity configuration
```powershell
New-AzDurableTaskScheduler -Name "testscheduler" -ResourceGroupName "rgopenapi" -Location "northcentralus" -SkuName "Dedicated" -SkuCapacity 1
```

```output
Endpoint                     : https://test.northcentralus.1.durabletask.io
IPAllowlist                  : {0.0.0.0/0}
Id                           : /subscriptions/EE9BD735-67CE-4A90-89C4-439D3F6A4C93/resourceGroups/rgopenapi/providers/Microsoft.DurableTask/schedulers/testscheduler
Location                     : North Central US
Name                         : testscheduler
ProvisioningState            : Succeeded
ResourceGroupName            : rgopenapi
SkuCapacity                  : 1
SkuName                      : Dedicated
SkuRedundancyState           : Zone
SystemDataCreatedAt          : 4/17/2024 3:34:17 PM
SystemDataCreatedBy          : tenmbevaunjzikxowqexrsx
SystemDataCreatedByType      : User
SystemDataLastModifiedAt     : 4/17/2024 3:34:17 PM
SystemDataLastModifiedBy     : xfvdcegtj
SystemDataLastModifiedByType : User
Tag                          : {
                               }
Type                         : Microsoft.DurableTask/schedulers
```

Creates a Durable Task scheduler with a specific SKU capacity and shows the full returned object.
