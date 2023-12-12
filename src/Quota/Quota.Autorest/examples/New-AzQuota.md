### Example 1: Create or update the quota limit for the specified resource with the requested value
```powershell
$quota = Get-AzQuota -Scope "subscriptions/{subId}/providers/Microsoft.Network/locations/eastus2" -ResourceName "PublicIPAddresses"
$limit = New-AzQuotaLimitObject -Value ($quota.Limit.Value + 1)
New-AzQuota -Scope "subscriptions/{subId}/providers/Microsoft.Network/locations/eastus2" -ResourceName "PublicIPAddresses" -Name "PublicIPAddresses" -Limit $limit
```

```output
Name              NameLocalizedValue  Unit  ETag
----              ------------------  ----  ----
PublicIPAddresses Public IP Addresses Count
```

This command create or update the quota limit for the specified resource with the requested value.