### Example 1: Create a new GroupQuota
```powershell
New-AzQuotaGroupQuota -ManagementGroupId "mgId" -GroupQuotaName "groupquota1" -DisplayName "My Test Quota Group"
```

```output
Name         DisplayName          ProvisioningState GroupType
----         -----------          ----------------- ---------
groupquota1  My Test Quota Group  Succeeded         AllocationGroup
```

Create a new GroupQuota with the specified name and display name within a management group.

