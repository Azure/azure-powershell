### Example 1: List all GroupQuotas in a Management Group
```powershell
Get-AzQuotaGroupQuota -ManagementGroupId "mgId"
```

```output
Name                  DisplayName              ProvisioningState GroupType
----                  -----------              ----------------- ---------
groupquota1          Test Quota Group          Succeeded         AllocationGroup
groupquota2          Production Quota Group    Succeeded         AllocationGroup
```

List all GroupQuotas available in the specified management group.

### Example 2: Get a specific GroupQuota by name
```powershell
Get-AzQuotaGroupQuota -ManagementGroupId "mgId" -GroupQuotaName "groupquota1"
```

```output
Name         DisplayName       ProvisioningState GroupType
----         -----------       ----------------- ---------
groupquota1  Test Quota Group  Succeeded         AllocationGroup
```

Get details of a specific GroupQuota by its name.

