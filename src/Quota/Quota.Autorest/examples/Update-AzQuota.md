### Example 1: Update the quota limit for a specific resource to the specified value
```powershell
$limit = New-AzQuotaLimitObject -Value 1001
Update-AzQuota -Scope "subscriptions/9e223dbe-3399-4e19-88eb-0975f02ac87f/providers/Microsoft.Network/locations/eastus2" -ResourceName "PublicIPAddresses" -Name "PublicIPAddresses" -Limit $limit
```

```output
Name              NameLocalizedValue  Unit  ETag
----              ------------------  ----  ----
PublicIPAddresses Public IP Addresses Count
```

This command update the quota limit for a specific resource to the specified value.

### Example 2: Update the quota limit for a specific resource to the specified value by pipeline
```powershell
$limit = New-AzQuotaLimitObject -Value 1007
Get-AzQuota -Scope "subscriptions/9e223dbe-3399-4e19-88eb-0975f02ac87f/providers/Microsoft.Network/locations/eastus2" -ResourceName "PublicIPAddresses" | Update-AzQuota -Name "PublicIPAddresses" -Limit $limit
```

```output
Name              NameLocalizedValue  Unit  ETag
----              ------------------  ----  ----
PublicIPAddresses Public IP Addresses Count
```

This command update the quota limit for a specific resource to the specified value by pipeline.