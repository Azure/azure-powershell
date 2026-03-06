### Example 1: Create a new GroupQuota location setting
```powershell
$jsonBody = @{
    properties = @{
        enforcementEnabled = "Enabled"
    }
} | ConvertTo-Json

New-AzQuotaGroupQuotaLocationSetting -ManagementGroupId "mgId" -GroupQuotaName "groupquota1" -ResourceProviderName "Microsoft.Compute" -Location "eastus" -JsonString $jsonBody -NoWait
```

```output
Name   EnforcementEnabled ProvisioningState
----   ------------------ -----------------
eastus Enabled            Succeeded
```

Create or configure a location setting for a specified GroupQuota, resource provider, and location. The JsonString parameter specifies whether enforcement is enabled for this location.

