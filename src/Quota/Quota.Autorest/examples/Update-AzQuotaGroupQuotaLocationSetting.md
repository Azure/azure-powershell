### Example 1: Update GroupQuota location setting
```powershell
Update-AzQuotaGroupQuotaLocationSetting -ManagementGroupId "mgId" -GroupQuotaName "groupquota1" -ResourceProviderName "Microsoft.Compute" -Location "eastus"
```

```output
Name   EnforcementEnabled ProvisioningState
----   ------------------ -----------------
eastus True               Succeeded
```

Update the location setting for a specified GroupQuota, resource provider, and location.

