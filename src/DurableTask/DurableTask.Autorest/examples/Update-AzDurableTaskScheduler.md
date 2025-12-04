### Example 1: Update scheduler tags and IP allowlist
```powershell
Update-AzDurableTaskScheduler -Name "testscheduler" -ResourceGroupName "rgopenapi" -Tag @{hello="world"} -IPAllowlist @("10.0.0.0/8")
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
                                  "hello": "world"
                               }
Type                         : Microsoft.DurableTask/schedulers
```

Updates the tags and IP allowlist for an existing Durable Task scheduler. Output shows all returned properties, with Tag reflecting the update.

### Example 2: Update scheduler SKU capacity
```powershell
Update-AzDurableTaskScheduler -Name "testscheduler" -ResourceGroupName "rgopenapi" -SkuName "Dedicated" -SkuCapacity 3
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
                               }
Type                         : Microsoft.DurableTask/schedulers
```

Updates the SKU capacity of an existing scheduler. Output shows all returned properties, with SkuName and SkuCapacity reflecting the update.

### Example 3: Update scheduler using pipeline input
```powershell
$scheduler = Get-AzDurableTaskScheduler -ResourceGroupName "rgopenapi" -Name "testscheduler"
$scheduler | Update-AzDurableTaskScheduler -Tag @{hello="world"}
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
                                  "hello": "world"
                               }
Type                         : Microsoft.DurableTask/schedulers
```

Updates a scheduler using pipeline input (UpdateViaIdentityExpanded parameter set). Output shows all returned properties, with Tag reflecting the update.

