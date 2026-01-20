### Example 1: Update GroupQuotasLimitsRequest for a GroupQuota
```powershell
$limitObject = New-AzQuotaLimitObject -Value 100
Update-AzQuotaGroupQuotaLimitsRequest -GroupQuotaName "groupquota1" -ManagementGroupId "admintest"  -ResourceProviderName "Microsoft.Compute" -ResourceName "standardav2family" -Region "eastus" -Limit $limitObject
```

```output
Name                                 SystemDataCreatedAt SystemDataCreatedBy SystemDataCreatedByType
----                                 ------------------- ------------------- -----------------------
{guid}
```

Updates a GroupQuotasLimitsRequest for a specified GroupQuota, resource provider, resource, and region with new quota limits.

