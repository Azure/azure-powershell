### Example 1: Update the quota limit for a specific resource to the specified value
```powershell
$quota = Get-AzQuota -Scope "subscriptions/{subId}/providers/Microsoft.Compute/locations/eastus" -ResourceName "standardFSv2Family"
$limit = New-AzQuotaLimitObject -Value ($quota.Limit.Value + 1)
Update-AzQuota -Scope "subscriptions/{subId}/providers/Microsoft.Compute/locations/eastus" -ResourceName "standardFSv2Family" -Limit $limit
```

```output
Name               NameLocalizedValue         Unit  ETag
----               ------------------         ----  ----
standardFSv2Family Standard FSv2 Family vCPUs Count
```

This command update the quota limit for a specific resource to the specified value.

### Example 2: Update the quota limit for a specific resource to the specified value by pipeline
```powershell
$quota = Get-AzQuota -Scope "subscriptions/{subId}/providers/Microsoft.Compute/locations/eastus" -ResourceName "standardFSv2Family"
$limit = New-AzQuotaLimitObject -Value ($quota.Limit.Value + 1)
Get-AzQuota -Scope "subscriptions/{subId}/providers/Microsoft.Compute/locations/eastus" -ResourceName "standardFSv2Family" | Update-AzQuota -Limit $limit
```

```output
Name               NameLocalizedValue         Unit  ETag
----               ------------------         ----  ----
standardFSv2Family Standard FSv2 Family vCPUs Count
```

This command update the quota limit for a specific resource to the specified value by pipeline.