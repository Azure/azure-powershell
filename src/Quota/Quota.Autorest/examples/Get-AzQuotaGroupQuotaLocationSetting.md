### Example 1: Get GroupQuota location setting
```powershell
Get-AzQuotaGroupQuotaLocationSetting -ManagementGroupId "mgId" -GroupQuotaName "groupquota1" -ResourceProviderName "Microsoft.Compute" -Location "eastus"
```

```output
Name   EnforcementEnabled ProvisioningState
----   ------------------ -----------------
eastus True               Succeeded
```

Get the location setting for a specified GroupQuota, resource provider, and location.

