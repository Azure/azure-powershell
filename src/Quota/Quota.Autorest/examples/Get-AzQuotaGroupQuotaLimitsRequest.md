### Example 1: List GroupQuotasLimitsRequests for a GroupQuota
```powershell
Get-AzQuotaGroupQuotaLimitsRequest -GroupQuotaName "groupquota1" -ManagementGroupId "mgId" -ResourceProviderName "Microsoft.Compute" -ResourceName "standardav2family"
```

```output
RequestId                            ProvisioningState RequestedLimit
---------                            ----------------- --------------
00000000-0000-0000-0000-000000000000 Succeeded         150
11111111-1111-1111-1111-111111111111 Failed            200
```

List all GroupQuotasLimitsRequests for a specified GroupQuota, resource provider, and resource.

### Example 2: Get a specific GroupQuotasLimitsRequest by RequestId
```powershell
Get-AzQuotaGroupQuotaLimitsRequest -GroupQuotaName "groupquota1" -ManagementGroupId "mgId" -ResourceProviderName "Microsoft.Compute" -ResourceName "standardav2family" -RequestId "00000000-0000-0000-0000-000000000000"
```

```output
RequestId                            ProvisioningState RequestedLimit
---------                            ----------------- --------------
00000000-0000-0000-0000-000000000000 Succeeded         150
```

Get details of a specific GroupQuotasLimitsRequest by its request ID.

