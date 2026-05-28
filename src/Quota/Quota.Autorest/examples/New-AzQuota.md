### Example 1: Create or update the quota limit for the specified resource with the requested value
```powershell
$quota = Get-AzQuota -Scope "subscriptions/{subId}/providers/Microsoft.Compute/locations/eastus" -ResourceName "standardFSv2Family"
$limit = New-AzQuotaLimitObject -Value ($quota.Limit.Value + 1)
New-AzQuota -Scope "subscriptions/{subId}/providers/Microsoft.Compute/locations/eastus" -ResourceName "standardFSv2Family" -Name "standardFSv2Family" -Limit $limit
```

```output
Name               NameLocalizedValue         Unit  ETag
----               ------------------         ----  ----
standardFSv2Family Standard FSv2 Family vCPUs Count
```

This command create or update the quota limit for the specified resource with the requested value.