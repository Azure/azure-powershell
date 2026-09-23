### Example 1: Update GroupQuotasLimitsRequest for a GroupQuota
```powershell
$quotaLimit = @{
    ResourceName = "standardav2family"
    Limit = 100
}
Update-AzQuotaGroupQuotaLimitsRequest -GroupQuotaName "groupquota1" -ManagementGroupId "admintest" -ResourceProviderName "Microsoft.Compute" -Location "eastus" -Value $quotaLimit
```

```output
Name                                 SystemDataCreatedAt SystemDataCreatedBy SystemDataCreatedByType
----                                 ------------------- ------------------- -----------------------
{guid}
```

Updates a GroupQuotasLimitsRequest for a specified GroupQuota, resource provider, resource, and region with new quota limits.

