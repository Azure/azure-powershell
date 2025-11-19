### Example 1: Update GroupQuotasLimitsRequest for a GroupQuota
```powershell
$limitObject = New-AzQuotaLimitObject -Value 100
Update-AzQuotaGroupQuotaLimitsRequest -GroupQuotaName "groupquota1" -ManagementGroupId "mgId" -ResourceProviderName "Microsoft.Compute" -ResourceName "standardav2family" -Region "eastus" -Limit $limitObject
```

```output
RequestId                            ProvisioningState RequestedLimit
---------                            ----------------- --------------
00000000-0000-0000-0000-000000000000 Accepted          100
```

Updates a GroupQuotasLimitsRequest for a specified GroupQuota, resource provider, resource, and region with new quota limits.

