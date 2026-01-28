### Example 1: Create a new GroupQuota
```powershell
New-AzQuotaGroupQuota -ManagementGroupId "admintest"  -GroupQuotaName "groupquota1" -DisplayName "My Test Quota Group"
```

```output
Name                                 SystemDataCreatedAt SystemDataCreatedBy SystemDataCreatedByType
----                                 ------------------- ------------------- -----------------------
{guid}
```

Create a new GroupQuota with the specified name and display name within a management group.

