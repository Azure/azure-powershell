##TODO##: cmdlet requires -JsonString parameter with properties.enforcementEnabled, example doesn't match implementation

### Example 1: Create a new GroupQuota location setting
```powershell
New-AzQuotaGroupQuotaLocationSetting -ManagementGroupId "mgId" -GroupQuotaName "groupquota1" -ResourceProviderName "Microsoft.Compute" -Location "eastus"
```

```output
Name   EnforcementEnabled ProvisioningState
----   ------------------ -----------------
eastus True               Succeeded
```

Create or configure a location setting for a specified GroupQuota, resource provider, and location.

