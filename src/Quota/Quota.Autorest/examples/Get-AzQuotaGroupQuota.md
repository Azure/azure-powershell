### Example 1: List all GroupQuotas in a Management Group
```powershell
Get-AzQuotaGroupQuota -ManagementGroupId "mgId"
```

```output
Name                SystemDataCreatedAt SystemDataCreatedBy SystemDataCreatedByType SystemDataLastModifiedAt
----                ------------------- ------------------- ----------------------- ------------------------
testquota755776827                                                                                          
testquota185715322                                                                                          
test2                                                                                                       
testquota1340651747                                                                                         
testlocation                                                                                                
testquota632715476
```

List all GroupQuotas available in the specified management group.

### Example 2: Get a specific GroupQuota by name
```powershell
Get-AzQuotaGroupQuota -ManagementGroupId "mgId" -GroupQuotaName "test2"
```

```output
Name  SystemDataCreatedAt SystemDataCreatedBy SystemDataCreatedByType SystemDataLastModifiedAt SystemDataLastModifiedBy
----  ------------------- ------------------- ----------------------- ------------------------ ------------------------
test2
```

Get details of a specific GroupQuota by its name.

