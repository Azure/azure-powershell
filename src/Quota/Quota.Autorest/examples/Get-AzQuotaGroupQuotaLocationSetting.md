### Example 1: Get GroupQuota location setting
```powershell
Get-AzQuotaGroupQuotaLocationSetting -ManagementGroupId "mgId" -GroupQuotaName "groupquota1" -ResourceProviderName "Microsoft.Compute" -Location "eastus"
```

```output
Name   EnforcementEnabled ProvisioningState
----   ------------------ -----------------
eastus Enabled            Succeeded
```

Get the location setting for a specified GroupQuota, resource provider, and location. 

Note: If enforcement has not been configured for this GroupQuota/location, this command will return a "not found" message, which is expected behavior.

